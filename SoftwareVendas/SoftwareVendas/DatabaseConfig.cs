using Microsoft.Data.SqlClient;
using System;

namespace SoftwareVendas
{
    /// <summary>
    /// Centralized database configuration and connection provider with automatic local instance detection.
    /// </summary>
    public static class DatabaseConfig
    {
        #region Connection State & Settings

        private static string _connectionString =
            @"Server=(localdb)\MSSQLLocalDB;Database=Software_Vendas_Pai;Trusted_Connection=True;TrustServerCertificate=True;";

        private static bool _instanciaDetectada = false;
        private static bool _conexaoAtiva = false;

        public static bool ConexaoAtiva
        {
            get
            {
                if (!_instanciaDetectada)
                {
                    DetectarMelhorInstancia();
                }
                return _conexaoAtiva;
            }
        }

        public static string ConnectionString
        {
            get
            {
                if (!_instanciaDetectada)
                {
                    DetectarMelhorInstancia();
                }
                return _connectionString;
            }
            set
            {
                _connectionString = value;
                _instanciaDetectada = true;
                _conexaoAtiva = TestarConexao(out _);
            }
        }

        private static readonly string[] ServidoresCandidatos = new[]
        {
            @"DESKTOP-P0S20G1\SQLEXPRESS",
            @"localhost\SQLEXPRESS",
            @".\SQLEXPRESS",
            @"(localdb)\MSSQLLocalDB",
            @"localhost"
        };

        public static void ForcarRedetecao()
        {
            _instanciaDetectada = false;
            DetectarMelhorInstancia();
        }

        #endregion

        #region Auto-Discovery & Connectivity Checks

        /// <summary>
        /// Attempts to connect to known SQL Server instances and selects the first active one.
        /// </summary>
        public static void DetectarMelhorInstancia()
        {
            foreach (string servidor in ServidoresCandidatos)
            {
                string connStr = $"Server={servidor};Database=Software_Vendas_Pai;Trusted_Connection=True;TrustServerCertificate=True;Connection Timeout=2;";
                try
                {
                    using (SqlConnection con = new SqlConnection(connStr))
                    {
                        con.Open();
                        _connectionString = connStr;
                        _instanciaDetectada = true;
                        _conexaoAtiva = true;
                        return;
                    }
                }
                catch
                {
                    // Continue scanning candidate instances
                }
            }

            _instanciaDetectada = true;
            _conexaoAtiva = false;
        }

        /// <summary>
        /// Tests database connectivity and returns true if successful.
        /// </summary>
        public static bool TestarConexao(out string mensagemErro)
        {
            try
            {
                using (SqlConnection con = ObterConexao())
                {
                    con.Open();
                    mensagemErro = string.Empty;
                    return true;
                }
            }
            catch (Exception ex)
            {
                mensagemErro = ex.Message;
                return false;
            }
        }

        #endregion

        #region Connection Factory

        /// <summary>
        /// Creates and returns a new SqlConnection instance using the active connection string.
        /// </summary>
        public static SqlConnection ObterConexao()
        {
            return new SqlConnection(ConnectionString);
        }

        #endregion
    }
}
