using System.Globalization;

namespace SoftwareVendas
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Enforce Portuguese culture (pt-PT) globally for standard Euro (€) formatting and comma decimals
            var culturaPt = new CultureInfo("pt-PT");
            CultureInfo.DefaultThreadCurrentCulture = culturaPt;
            CultureInfo.DefaultThreadCurrentUICulture = culturaPt;

            ApplicationConfiguration.Initialize();
            Application.Run(new FormLogin());
        }
    }
}