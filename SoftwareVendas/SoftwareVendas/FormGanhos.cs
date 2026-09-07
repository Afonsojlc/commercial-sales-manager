using Microsoft.Data.SqlClient;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace SoftwareVendas
{
    /// <summary>
    /// Financial and commission performance dashboard for sales representatives.
    /// Calculates real-time sales metrics, periodic revenue, and commission earnings.
    /// </summary>
    public partial class FormGanhos : Form
    {
        public FormGanhos()
        {
            InitializeComponent();
            ConfigurarDesign();

            btnAtualizar.Click += (s, e) => CarregarDados();
            btnFechar.Click += (s, e) => this.Close();
        }

        private void FormGanhos_Load(object? sender, EventArgs e)
        {
            CarregarDados();
        }

        private void ConfigurarDesign()
        {
            this.DoubleBuffered = true;

            // Header information reflecting current authenticated user
            lblSubtitulo.Text = $"Vendedor: {Sessao.Nome} ({Sessao.Cargo}) | Taxa de Comissão: {Sessao.PercentagemComissao:N2}%";

            // Grid styling consistent with the rest of the application
            dgvGanhos.EnableHeadersVisualStyles = false;
            dgvGanhos.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(44, 62, 80);
            dgvGanhos.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvGanhos.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            dgvGanhos.ColumnHeadersHeight = 42;
            dgvGanhos.RowTemplate.Height = 36;
            dgvGanhos.DefaultCellStyle.Font = new Font("Segoe UI", 10F);
            dgvGanhos.DefaultCellStyle.SelectionBackColor = Color.FromArgb(52, 152, 219);
            dgvGanhos.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvGanhos.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 249, 250);
            dgvGanhos.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;

            this.Load += FormGanhos_Load;
        }

        /// <summary>
        /// Retrieves orders from the database and updates dashboard metrics and transaction grid.
        /// </summary>
        private void CarregarDados()
        {
            dgvGanhos.Rows.Clear();

            decimal faturadoHoje = 0m;
            decimal faturadoMes = 0m;
            int totalEncomendas = 0;
            decimal taxaComissao = Sessao.PercentagemComissao / 100m;

            DateTime hoje = DateTime.Today;

            string query = @"
                SELECT 
                    E.Numero_Encomenda,
                    E.Data_Encomenda,
                    ISNULL(C.Nome_Cliente, 'Cliente Não Identificado') AS Nome_Cliente,
                    ISNULL(E.Estado, 'Pendente') AS Estado,
                    ISNULL(E.Valor_Total, 0) AS Valor_Total
                FROM Encomenda E
                LEFT JOIN Clientes C ON E.ID_Cliente = C.ID_Cliente
                WHERE E.ID_Vendedor = @idVendedor OR @idVendedor = 0
                ORDER BY E.Data_Encomenda DESC, E.Numero_Encomenda DESC";

            try
            {
                using (SqlConnection con = DatabaseConfig.ObterConexao())
                {
                    con.Open();

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@idVendedor", Sessao.ID_Vendedor);

                        using (SqlDataReader rd = cmd.ExecuteReader())
                        {
                            while (rd.Read())
                            {
                                int ne = Convert.ToInt32(rd["Numero_Encomenda"]);
                                DateTime dataEnc = rd["Data_Encomenda"] != DBNull.Value ? Convert.ToDateTime(rd["Data_Encomenda"]) : DateTime.MinValue;
                                string cliente = rd["Nome_Cliente"]?.ToString() ?? "N/A";
                                string estado = rd["Estado"]?.ToString() ?? "Pendente";
                                decimal valorTotal = Convert.ToDecimal(rd["Valor_Total"]);

                                decimal comissaoLinha = valorTotal * taxaComissao;

                                // Aggregate metrics
                                if (dataEnc.Date == hoje)
                                {
                                    faturadoHoje += valorTotal;
                                }

                                if (dataEnc.Month == hoje.Month && dataEnc.Year == hoje.Year)
                                {
                                    faturadoMes += valorTotal;
                                }

                                totalEncomendas++;

                                dgvGanhos.Rows.Add(
                                    ne,
                                    dataEnc != DateTime.MinValue ? dataEnc.ToString("dd/MM/yyyy") : "N/A",
                                    cliente,
                                    estado,
                                    valorTotal.ToString("C2"),
                                    comissaoLinha.ToString("C2")
                                );
                            }
                        }
                    }
                }

                // Update metric cards
                lblHojeValor.Text = faturadoHoje.ToString("C2");
                lblMesValor.Text = faturadoMes.ToString("C2");
                lblComissaoValor.Text = (faturadoMes * taxaComissao).ToString("C2");
                lblQtdValor.Text = totalEncomendas.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocorreu um erro ao carregar os dados de vendas:\n{ex.Message}", "Erro de Base de Dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
