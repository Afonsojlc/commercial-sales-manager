using System;
using System.Windows.Forms;

namespace SoftwareVendas
{
    /// <summary>
    /// System configuration dialog allowing users to inspect active session credentials
    /// and configure the database connection string.
    /// </summary>
    public partial class FormDefinicoes : Form
    {
        public FormDefinicoes()
        {
            InitializeComponent();
            CarregarDados();

            btnTestar.Click += BtnTestar_Click;
            btnGuardar.Click += BtnGuardar_Click;
            btnFechar.Click += (s, e) => this.Close();
        }

        private void CarregarDados()
        {
            // Populate active user session data
            lblInfoNome.Text = $"Utilizador: {Sessao.Nome}";
            lblInfoCargo.Text = $"Cargo: {Sessao.Cargo}";
            lblInfoComissao.Text = $"Percentagem de Comissão: {Sessao.PercentagemComissao:N2}%";

            // Populate connection string from centralized configuration
            txtConnectionString.Text = DatabaseConfig.ConnectionString;
        }

        private void BtnTestar_Click(object? sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            string stringTeste = txtConnectionString.Text.Trim();
            string stringOriginal = DatabaseConfig.ConnectionString;

            DatabaseConfig.ConnectionString = stringTeste;

            if (DatabaseConfig.TestarConexao(out string erro))
            {
                MessageBox.Show("Conexão à base de dados SQL Server estabelecida com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                DatabaseConfig.ConnectionString = stringOriginal;
                MessageBox.Show($"Falha ao conectar à base de dados:\n{erro}", "Erro de Conexão", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            Cursor.Current = Cursors.Default;
        }

        private void BtnGuardar_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtConnectionString.Text))
            {
                MessageBox.Show("A string de conexão não pode estar vazia.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DatabaseConfig.ConnectionString = txtConnectionString.Text.Trim();
            MessageBox.Show("Configurações atualizadas com sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
    }
}
