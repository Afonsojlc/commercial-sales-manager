using System;
using System.IO;
using System.Text.Json;

namespace SoftwareVendas
{
    public static class ConfiguracaoEmpresa
    {
        public static string NomeEmpresa { get; set; } = "AJLC Soluctions";
        public static string Subtitulo { get; set; } = "Gestão Comercial & Distribuição de Material Elétrico";
        public static string NIF { get; set; } = "509 999 999";
        public static string Morada { get; set; } = "Zona Industrial Maia I, Rua do Progresso, 45";
        public static string CodigoPostal { get; set; } = "4470-001 Maia";
        public static string Telefone { get; set; } = "229 000 000";
        public static string Email { get; set; } = "geral@ajlc.pt";

        private static readonly string ConfigFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "empresa_config.json");

        static ConfiguracaoEmpresa()
        {
            Carregar();
        }

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
            catch { }
        }

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
            catch { }
        }

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
    }
}
