using System;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.AspNetCore.Components.WebView.WindowsForms;
using Microsoft.Extensions.DependencyInjection;

namespace SoftwareVendas
{
    public partial class FormMenu : Form
    {
        public FormMenu()
        {
            this.Text = "AJLC Soluctions";
            this.WindowState = FormWindowState.Maximized;
            this.Icon = SystemIcons.Application;

            var services = new ServiceCollection();
            services.AddWindowsFormsBlazorWebView();
            
            var blazorWebView = new BlazorWebView
            {
                Dock = DockStyle.Fill,
                HostPage = "wwwroot\\index.html",
                Services = services.BuildServiceProvider()
            };

            blazorWebView.RootComponents.Add<Components.App>("#app");
            this.Controls.Add(blazorWebView);
        }
    }
}
