using System;

namespace SoftwareVendas
{
    /// <summary>
    /// Global session container holding credentials, permissions, and demo state for the active user.
    /// </summary>
    public static class Sessao
    {
        #region Session State

        public static int ID_Vendedor { get; set; }
        public static string Nome { get; set; } = "";
        public static string Cargo { get; set; } = "Vendedor";
        public static string Email { get; set; } = "";
        public static string Telemovel { get; set; } = "";
        public static string PIN { get; set; } = "";
        public static decimal PercentagemComissao { get; set; } = 5.0m;
        public static bool IsDemo { get; set; } = false;

        #endregion

        #region Authorization & Role Helpers

        /// <summary>
        /// Returns true if the authenticated user has managerial privileges (Diretor Comercial, Director, Administrador, or Demo Director).
        /// </summary>
        public static bool IsDiretorOuAdmin =>
            IsDemo ||
            (!string.IsNullOrWhiteSpace(Cargo) && (
                Cargo.IndexOf("Diretor", StringComparison.OrdinalIgnoreCase) >= 0 ||
                Cargo.IndexOf("Director", StringComparison.OrdinalIgnoreCase) >= 0 ||
                Cargo.IndexOf("Admin", StringComparison.OrdinalIgnoreCase) >= 0 ||
                Cargo.IndexOf("Gerente", StringComparison.OrdinalIgnoreCase) >= 0
            ));

        /// <summary>
        /// Resets all session parameters upon logout.
        /// </summary>
        public static void Limpar()
        {
            ID_Vendedor = 0;
            Nome = "";
            Cargo = "Vendedor";
            Email = "";
            Telemovel = "";
            PIN = "";
            PercentagemComissao = 5.0m;
            IsDemo = false;
        }

        /// <summary>
        /// Configures session specifically for offline demonstration mode as requested.
        /// </summary>
        public static void IniciarModoDemonstracao()
        {
            ID_Vendedor = 999;
            Nome = "Afonso Carvalho";
            Cargo = "DEMO";
            Email = "afonso.carvalho@geral.pt";
            Telemovel = "912345678";
            PIN = "1234";
            PercentagemComissao = 5.0m;
            IsDemo = true;
        }

        #endregion
    }
}