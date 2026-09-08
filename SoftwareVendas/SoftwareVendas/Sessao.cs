namespace SoftwareVendas
{
    /// <summary>
    /// Global session container holding credentials and commission terms for the active sales representative.
    /// </summary>
    public static class Sessao
    {
        #region Session State

        public static int ID_Vendedor { get; set; }
        public static string Nome { get; set; } = "";
        public static string Cargo { get; set; } = "Vendedor";
        public static decimal PercentagemComissao { get; set; } = 5.0m;

        #endregion
    }
}