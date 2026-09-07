using System;
using System.Windows.Forms;

namespace SoftwareVendas
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            // Start the application directly with the Blazor Host (FormMenu)
            // The router inside App.razor will show the Login page first.
            Application.Run(new FormMenu());
        }
    }
}
