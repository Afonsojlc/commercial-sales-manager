using System;
using System.IO;
using System.Text.Json;

namespace SoftwareVendas
{
    /// <summary>
    /// Manages enterprise profile settings and JSON persistence for headers and printable documents.
    /// </summary>
    public static class ConfiguracaoEmpresa
    {
        #region Company Profile Properties

        public static string NomeEmpresa { get; set; } = "AJLC Soluctions";
        public static string Subtitulo { get; set; } = "Gestão Comercial & Distribuição de Material Elétrico";
        public static string NIF { get; set; } = "509 999 999";
        public static string Morada { get; set; } = "Zona Industrial Maia I, Rua do Progresso, 45";
        public static string CodigoPostal { get; set; } = "4470-001 Maia";
        public static string Telefone { get; set; } = "229 000 000";
        public static string Email { get; set; } = "geral@ajlc.pt";

        private static readonly string ConfigFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "empresa_config.json");

        #endregion

        #region Configuration Persistence

        static ConfiguracaoEmpresa()
        {
            Carregar();
        }

        /// <summary>
        /// Loads saved company details from the local configuration file.
        /// </summary>
        public static void Carregar()
        {
            try
            {
                if (File.Exists(ConfigFilePath))
                {
                    string json = File.ReadAllText(ConfigFilePath);
                    var dados = JsonSerializer.Deserialize<EmpresaDadosDTO>(json);
                    if (dados != null)
                    {
                        if (!string.IsNullOrWhiteSpace(dados.NomeEmpresa)) NomeEmpresa = dados.NomeEmpresa;
                        if (!string.IsNullOrWhiteSpace(dados.Subtitulo)) Subtitulo = dados.Subtitulo;
                        if (!string.IsNullOrWhiteSpace(dados.NIF)) NIF = dados.NIF;
                        if (!string.IsNullOrWhiteSpace(dados.Morada)) Morada = dados.Morada;
                        if (!string.IsNullOrWhiteSpace(dados.CodigoPostal)) CodigoPostal = dados.CodigoPostal;
                        if (!string.IsNullOrWhiteSpace(dados.Telefone)) Telefone = dados.Telefone;
                        if (!string.IsNullOrWhiteSpace(dados.Email)) Email = dados.Email;
                    }
                }
            }
            catch
            {
                // Fallback to default in-memory values if file read fails
            }
        }

        /// <summary>
        /// Persists company profile values to local JSON storage.
        /// </summary>
        public static void Guardar()
        {
            try
            {
                var dados = new EmpresaDadosDTO
                {
                    NomeEmpresa = NomeEmpresa,
                    Subtitulo = Subtitulo,
                    NIF = NIF,
                    Morada = Morada,
                    CodigoPostal = CodigoPostal,
                    Telefone = Telefone,
                    Email = Email
                };
                string json = JsonSerializer.Serialize(dados, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(ConfigFilePath, json);
            }
            catch
            {
                // Suppress disk write exceptions on restricted environments
            }
        }

        #endregion

        #region Data Transfer Object

        private class EmpresaDadosDTO
        {
            public string? NomeEmpresa { get; set; }
            public string? Subtitulo { get; set; }
            public string? NIF { get; set; }
            public string? Morada { get; set; }
            public string? CodigoPostal { get; set; }
            public string? Telefone { get; set; }
            public string? Email { get; set; }
        }

        #endregion
    }
}
