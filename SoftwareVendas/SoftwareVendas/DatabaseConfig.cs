using Microsoft.Data.SqlClient;
using System;

namespace SoftwareVendas
{
    /// <summary>
    /// Centralized database configuration and connection provider.
    /// </summary>
    public static class DatabaseConfig
    {
        /// <summary>
        /// Default connection string targeting Microsoft SQL Server instance.
        /// Can be customized at runtime or retrieved from settings.
        /// </summary>
        public static string ConnectionString { get; set; } =
            @"Server=DESKTOP-P0S20G1\SQLEXPRESS;Database=Software_Vendas_Pai;Trusted_Connection=True;TrustServerCertificate=True;";

        /// <summary>
        /// Creates and returns a new SqlConnection instance using the active connection string.
        /// </summary>
        public static SqlConnection ObterConexao()
        {
            return new SqlConnection(ConnectionString);
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
    }
}
