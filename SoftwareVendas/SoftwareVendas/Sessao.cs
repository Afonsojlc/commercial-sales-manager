namespace SoftwareVendas
{
    public static class Sessao
    {
        public static int ID_Vendedor { get; set; } 

        // Session state holder for the currently authenticated sales representative
        public static string Nome { get; set; } = "";
        public static string Cargo { get; set; } = "Vendedor";

        public static decimal PercentagemComissao { get; set; } = 5.0m;
    }
}