using Microsoft.Data.SqlClient;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace SoftwareVendas
{
    public partial class FormLogin : Form
    {
        private bool modoPin = true;

        public FormLogin()
        {
            InitializeComponent();
            ConfigurarVisual();
        }

        private void ConfigurarVisual()
        {
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.ResizeRedraw, true);

            try
            {
                string caminhoImagem = Path.Combine(Application.StartupPath, "fundo.jpg");

                if (File.Exists(caminhoImagem))
                {
                    this.BackgroundImage = Image.FromFile(caminhoImagem);
                    this.BackgroundImageLayout = ImageLayout.Stretch;
                }
                else
                {
                    this.BackColor = Color.FromArgb(44, 62, 80);
                }
            }
            catch
            {
                this.BackColor = Color.FromArgb(44, 62, 80);
            }

            pnlCentral.BackColor = Color.Transparent;

            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;

            pnlModoPin.Visible = true;
            pnlModoEmail.Visible = false;

            AlinharPaineis();
        }

        private void AlinharPaineis()
        {
            if (pnlModoEmail != null && pnlModoPin != null)
            {
                pnlModoEmail.Location = pnlModoPin.Location;
                pnlModoEmail.Size = pnlModoPin.Size;
            }

            CentrarPainelCentral();
        }

        private void CentrarPainelCentral()
        {
            if (pnlCentral != null)
            {
                pnlCentral.Left = (this.ClientSize.Width - pnlCentral.Width) / 2;
                pnlCentral.Top = (this.ClientSize.Height - pnlCentral.Height) / 2;
            }

            if (btnSairApp != null)
            {
                btnSairApp.FlatStyle = FlatStyle.Flat;
                btnSairApp.FlatAppearance.BorderSize = 0;
                btnSairApp.BackColor = Color.Transparent;
                btnSairApp.ForeColor = Color.White;

                btnSairApp.Left = this.ClientSize.Width - 60;
                btnSairApp.Top = 20;
                btnSairApp.BringToFront();
            }
        }

        private void FormLogin_Resize(object? sender, EventArgs e)
        {
            CentrarPainelCentral();
            AlinharPaineis();
        }

        private void FormLogin_Load(object? sender, EventArgs e)
        {
            CentrarPainelCentral();
            AlinharPaineis();
        }

        // Switch to Email authentication mode
        private void label2_Click(object? sender, EventArgs e)
        {
            modoPin = false;
            pnlModoPin.Visible = false;
            pnlModoEmail.Visible = true;
            txtEmail.Focus();
        }

        // Switch to fast PIN authentication mode
        private void label3_Click(object? sender, EventArgs e)
        {
            modoPin = true;
            pnlModoEmail.Visible = false;
            pnlModoPin.Visible = true;
            txtPIN.Focus();
        }

        private void btnEntrar_Click_1(object? sender, EventArgs e)
        {
            string pin = txtPIN.Text.Trim();

            // Allow master test PIN (1234 or 0000) with automatic offline fallback
            if (pin == "1234" || pin == "0000")
            {
                string query = "SELECT ID_Vendedor, Nome, Percentagem_Comissao, Cargo FROM Vendedores WHERE PIN = @p1 AND Ativo = 1";
                if (TentarLoginBD(query, pin, null)) return;

                EntrarComoAdminTeste();
                return;
            }

            string queryPadrao = "SELECT ID_Vendedor, Nome, Percentagem_Comissao, Cargo FROM Vendedores WHERE PIN = @p1 AND Ativo = 1";
            ExecutarLogin(queryPadrao, txtPIN.Text, null);
        }

        private void button1_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtEmail.Text) || string.IsNullOrWhiteSpace(txtSenha.Text))
            {
                MessageBox.Show("Por favor, preencha o email e a senha.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string email = txtEmail.Text.Trim();
            string senha = txtSenha.Text.Trim();

            // Allow master admin test login with automatic offline fallback
            if (email.Equals("admin@comercial.pt", StringComparison.OrdinalIgnoreCase) && senha == "admin")
            {
                string query = "SELECT ID_Vendedor, Nome, Percentagem_Comissao, Cargo FROM Vendedores WHERE Email = @p1 AND Senha = @p2 AND Ativo = 1";
                if (TentarLoginBD(query, email, senha)) return;

                EntrarComoAdminTeste();
                return;
            }

            string queryPadrao = "SELECT ID_Vendedor, Nome, Percentagem_Comissao, Cargo FROM Vendedores WHERE Email = @p1 AND Senha = @p2 AND Ativo = 1";
            ExecutarLogin(queryPadrao, txtEmail.Text, txtSenha.Text);
        }

        /// <summary>
        /// Attempts database authentication; returns false on connection failure without blocking.
        /// </summary>
        private bool TentarLoginBD(string query, string p1, string? p2)
        {
            try
            {
                using (SqlConnection con = DatabaseConfig.ObterConexao())
                {
                    con.Open();

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@p1", p1);
                        if (p2 != null) cmd.Parameters.AddWithValue("@p2", p2);

                        using (SqlDataReader leitor = cmd.ExecuteReader())
                        {
                            if (leitor.Read())
                            {
                                CarregarSessaoERedirecionar(leitor);
                                return true;
                            }
                        }
                    }
                }
            }
            catch
            {
                // Return false to allow offline/demo bypass
                return false;
            }

            return false;
        }

        // Centralized user authentication against SQL Server
        private void ExecutarLogin(string query, string p1, string? p2)
        {
            using (SqlConnection con = DatabaseConfig.ObterConexao())
            {
                try
                {
                    con.Open();

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@p1", p1);

                        if (p2 != null)
                        {
                            cmd.Parameters.AddWithValue("@p2", p2);
                        }

                        using (SqlDataReader leitor = cmd.ExecuteReader())
                        {
                            if (leitor.Read())
                            {
                                CarregarSessaoERedirecionar(leitor);
                            }
                            else
                            {
                                MessageBox.Show("As credenciais inseridas estão incorretas.", "Falha na Autenticação", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                                if (p2 == null)
                                    txtPIN.Clear();
                                else
                                    txtSenha.Clear();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    DialogResult r = MessageBox.Show(
                        $"Ocorreu um erro de comunicação com a base de dados SQL Server:\n{ex.Message}\n\nDeseja entrar em Modo Demonstração (Admin / Diretor Comercial) para testar a aplicação?",
                        "Acesso Alternativo de Teste",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (r == DialogResult.Yes)
                    {
                        EntrarComoAdminTeste();
                    }
                }
            }
        }

        private void CarregarSessaoERedirecionar(SqlDataReader leitor)
        {
            Sessao.ID_Vendedor = Convert.ToInt32(leitor["ID_Vendedor"]);
            Sessao.Nome = leitor["Nome"]?.ToString() ?? "Utilizador";
            Sessao.PercentagemComissao = Convert.ToDecimal(leitor["Percentagem_Comissao"]);
            Sessao.Cargo = leitor["Cargo"]?.ToString() ?? "Vendedor";

            FormMenu menu = new FormMenu();
            menu.Show();
            this.Hide();
        }

        private void EntrarComoAdminTeste()
        {
            Sessao.ID_Vendedor = 1;
            Sessao.Nome = "Afonso Carvalho (Diretor Comercial)";
            Sessao.Cargo = "Diretor Comercial";
            Sessao.PercentagemComissao = 5.00m;

            MessageBox.Show(
                "Sessão iniciada como Administrador / Diretor Comercial.\n\nUtilizador: Afonso Carvalho\nCargo: Diretor Comercial\nComissão: 5.00%",
                "Autenticação de Teste Concluída",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            FormMenu menu = new FormMenu();
            menu.Show();
            this.Hide();
        }

        private void btnSairApp_Click(object? sender, EventArgs e)
        {
            DialogResult resposta = MessageBox.Show(
                "Tem a certeza que deseja encerrar a aplicação?",
                "Confirmar Saída",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (resposta == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void txtPIN_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;

                if (modoPin)
                    btnEntrar_Click_1(sender, e);
                else
                    button1_Click(sender, e);
            }
        }
    }
}