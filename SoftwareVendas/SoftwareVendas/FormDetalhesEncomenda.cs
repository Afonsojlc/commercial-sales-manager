using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace SoftwareVendas
{
    public partial class FormDetalhesEncomenda : Form
    {
        private readonly int idEncomenda;
        private string estadoOriginal = "";

        public FormDetalhesEncomenda(int numeroEncomenda)
        {
            InitializeComponent();
            idEncomenda = numeroEncomenda;

            ConfigurarInterface();
            CarregarDadosGlobais();
        }

        #region 1. Interface and UI Setup

        private void ConfigurarInterface()
        {
            cmbEstado.Items.AddRange(new string[] { "PENDENTE", "PAGA", "FECHADA", "DESPACHADO", "A ENTREGAR", "CANCELADA" });
            cmbEstado.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEstado.SelectedIndexChanged += cmbEstado_SelectedIndexChanged;

            EstilizarGrelha();

            ConfigurarBotao("btnSair", "Sair", Color.FromArgb(231, 76, 60), btnSair_Click);
            ConfigurarBotao("btnModificar", "Modificar Encomenda", Color.FromArgb(52, 152, 219), btnModificar_Click);
            ConfigurarBotao("btnGuardar", "Guardar Alterações", Color.FromArgb(46, 204, 113), btnGuardar_Click, false);

            // Add Order Note Print / PDF generation button
            Button btnImprimir = new Button
            {
                Name = "btnImprimir",
                Text = "Imprimir / PDF",
                BackColor = Color.FromArgb(41, 128, 185),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand,
                Size = new Size(160, 42)
            };
            btnImprimir.FlatAppearance.BorderSize = 0;

            if (btnModificar != null)
            {
                btnImprimir.Location = new Point(btnModificar.Left - 175, btnModificar.Top);
            }
            else
            {
                btnImprimir.Location = new Point(50, this.ClientSize.Height - 60);
            }

            btnImprimir.Click += BtnImprimir_Click;
            this.Controls.Add(btnImprimir);
            btnImprimir.BringToFront();
        }

        private void ConfigurarBotao(string nomeCrtl, string texto, Color corFundo, EventHandler eventoClick, bool visivel = true)
        {
            Control[] controls = Controls.Find(nomeCrtl, true);
            if (controls.Length > 0 && controls[0] is Button btn)
            {
                btn.Text = texto;
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 0;
                btn.BackColor = corFundo;
                btn.ForeColor = Color.White;
                btn.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                btn.Cursor = Cursors.Hand;
                btn.Visible = visivel;

                if (eventoClick != null)
                {
                    btn.Click -= eventoClick;
                    btn.Click += eventoClick;
                }
            }
        }

        private void EstilizarGrelha()
        {
            if (dgvLinhas == null) return;

            dgvLinhas.BackgroundColor = Color.White;
            dgvLinhas.BorderStyle = BorderStyle.FixedSingle;
            dgvLinhas.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvLinhas.EnableHeadersVisualStyles = false;
            dgvLinhas.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(44, 62, 80);
            dgvLinhas.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvLinhas.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvLinhas.DefaultCellStyle.SelectionBackColor = Color.White;
            dgvLinhas.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvLinhas.RowHeadersVisible = false;
            dgvLinhas.ReadOnly = true;
            dgvLinhas.AllowUserToAddRows = false;
        }

        private void AtualizarComboBoxEstado(string estado)
        {
            cmbEstado.SelectedIndexChanged -= cmbEstado_SelectedIndexChanged;
            cmbEstado.SelectedItem = cmbEstado.Items.Contains(estado) ? estado : cmbEstado.Items[0];
            cmbEstado.SelectedIndexChanged += cmbEstado_SelectedIndexChanged;
        }

        #endregion

        #region 2. Data Access (Optimized via Centralized Connection)

        private void CarregarDadosGlobais()
        {
            using (SqlConnection con = DatabaseConfig.ObterConexao())
            {
                try
                {
                    con.Open();
                    CarregarDadosEncomenda(con);
                    CarregarLinhasEncomenda(con);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Falha ao comunicar com a Base de Dados:\n{ex.Message}", "Erro Crítico", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void CarregarDadosEncomenda(SqlConnection con)
        {
            string query = @"
                SELECT 
                    E.Data_Encomenda, E.Valor_Total, E.Estado, E.Desconto_Global,
                    C.Nome_Cliente, C.NIF, C.Email, C.Telefone
                FROM Encomenda E
                INNER JOIN Clientes C ON E.ID_Cliente = C.ID_Cliente
                WHERE E.Numero_Encomenda = @id";

            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@id", idEncomenda);
                using (SqlDataReader rd = cmd.ExecuteReader())
                {
                    if (rd.Read())
                    {
                        decimal total = Convert.ToDecimal(rd["Valor_Total"]);
                        decimal desconto = rd["Desconto_Global"] != DBNull.Value ? Convert.ToDecimal(rd["Desconto_Global"]) : 0;
                        estadoOriginal = rd["Estado"].ToString()?.Trim().ToUpper() ?? "PENDENTE";

                        label6.Text = rd["Nome_Cliente"].ToString() ?? "Desconhecido";
                        label7.Text = rd["NIF"].ToString() ?? "N/A";
                        label8.Text = rd["Email"].ToString() ?? "N/A";
                        label9.Text = rd["Telefone"].ToString() ?? "N/A";

                        label11.Text = idEncomenda.ToString();
                        label13.Text = Convert.ToDateTime(rd["Data_Encomenda"]).ToString("dd/MM/yyyy");
                        label16.Text = total.ToString("C2");
                        label19.Text = desconto > 0 ? $"{desconto}%" : "0%";

                        AtualizarComboBoxEstado(estadoOriginal);
                    }
                }
            }
        }

        private void CarregarLinhasEncomenda(SqlConnection con)
        {
            string query = @"
                SELECT 
                    Codigo_Material as 'Código', Descricao as 'Produto / Descrição', 
                    Quantidade as 'Qtd', Preco as 'Preço Unit. (€)', 
                    Desconto as 'Desc. (%)', Imposto as 'IVA (%)',
                    (Quantidade * Preco) as 'Subtotal (€)'
                FROM Linha_Encomenda 
                WHERE NE = @id ORDER BY Linha_Encomenda ASC";

            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@id", idEncomenda);
                DataTable dt = new DataTable();

                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.Fill(dt);
                }

                dgvLinhas.DataSource = dt;

                if (dgvLinhas.Columns.Count > 0)
                {
                    dgvLinhas.Columns["Código"].Width = 80;
                    dgvLinhas.Columns["Produto / Descrição"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dgvLinhas.Columns["Preço Unit. (€)"].DefaultCellStyle.Format = "C2";
                    dgvLinhas.Columns["Subtotal (€)"].DefaultCellStyle.Format = "C2";
                }
                dgvLinhas.ClearSelection();
            }
        }

        #endregion

        #region 3. Business Rules and Actions

        private void cmbEstado_SelectedIndexChanged(object? sender, EventArgs e)
        {
            Control[] btnControls = Controls.Find("btnGuardar", true);
            if (btnControls.Length > 0 && btnControls[0] is Button btnGuardar)
            {
                btnGuardar.Visible = (cmbEstado.SelectedItem?.ToString() ?? "") != estadoOriginal;
            }
        }

        private void btnGuardar_Click(object? sender, EventArgs e)
        {
            string novoEstado = cmbEstado.SelectedItem?.ToString() ?? "";

            if (novoEstado == estadoOriginal) return;

            DialogResult resposta = MessageBox.Show(
                $"Confirma a alteração do estado da Encomenda Nº {idEncomenda} para '{novoEstado}'?",
                "Confirmar Gravação", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            if (resposta == DialogResult.Yes)
            {
                using (SqlConnection con = DatabaseConfig.ObterConexao())
                {
                    try
                    {
                        con.Open();
                        using (SqlCommand cmd = new SqlCommand("UPDATE Encomenda SET Estado = @estado WHERE Numero_Encomenda = @id", con))
                        {
                            cmd.Parameters.AddWithValue("@estado", novoEstado);
                            cmd.Parameters.AddWithValue("@id", idEncomenda);
                            cmd.ExecuteNonQuery();
                        }

                        estadoOriginal = novoEstado;
                        DialogResult = DialogResult.OK;
                        Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Falha ao atualizar o estado:\n{ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnModificar_Click(object? sender, EventArgs e)
        {
            Hide();
            using (Form1 formModificar = new Form1())
            {
                formModificar.PrepararModoModificacao(idEncomenda);
                if (formModificar.ShowDialog() == DialogResult.OK)
                {
                    CarregarDadosGlobais();
                }
            }
            Show();
        }

        private void btnSair_Click(object? sender, EventArgs e)
        {
            if ((cmbEstado.SelectedItem?.ToString() ?? "") != estadoOriginal)
            {
                if (MessageBox.Show("O estado foi alterado mas não gravado.\nDeseja sair mesmo assim?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                {
                    return;
                }
            }
            Close();
        }

        /// <summary>
        /// Generates and previews the official Order Note document for printing or PDF export.
        /// </summary>
        private void BtnImprimir_Click(object? sender, EventArgs e)
        {
            try
            {
                PrintDocument doc = new PrintDocument();
                doc.DocumentName = $"Nota_Encomenda_{idEncomenda}";
                doc.PrintPage += Doc_PrintPage;

                using (PrintPreviewDialog preview = new PrintPreviewDialog())
                {
                    preview.Document = doc;
                    preview.Width = 900;
                    preview.Height = 700;
                    preview.StartPosition = FormStartPosition.CenterScreen;
                    preview.Text = $"Pré-visualização da Nota de Encomenda Nº {idEncomenda}";
                    preview.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao inicializar visualização de impressão:\n{ex.Message}", "Erro de Impressão", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Doc_PrintPage(object sender, PrintPageEventArgs e)
        {
            Graphics g = e.Graphics!;
            Font fontTitulo = new Font("Segoe UI", 16, FontStyle.Bold);
            Font fontSubtitulo = new Font("Segoe UI", 9.5F, FontStyle.Regular);
            Font fontSecao = new Font("Segoe UI", 11, FontStyle.Bold);
            Font fontTexto = new Font("Segoe UI", 9.5F, FontStyle.Regular);
            Font fontTabelaHead = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            Brush brushPreto = Brushes.Black;
            Brush brushCinza = new SolidBrush(Color.FromArgb(100, 110, 120));
            Pen penCinza = new Pen(Color.FromArgb(200, 205, 210), 1);
            Pen penLinhaGrossa = new Pen(Color.FromArgb(44, 62, 80), 2);

            int x = 50;
            int y = 50;
            int larguraUtil = e.PageBounds.Width - 100;

            // 1. Header
            g.DrawString("NOTA DE ENCOMENDA", fontTitulo, brushPreto, x, y);
            y += 28;
            g.DrawString("Gestão Comercial & Distribuição de Material Elétrico", fontSubtitulo, brushCinza, x, y);
            y += 22;
            g.DrawLine(penLinhaGrossa, x, y, x + larguraUtil, y);
            y += 15;

            // 2. Order Meta info
            g.DrawString($"Encomenda Nº: {idEncomenda}", fontSecao, brushPreto, x, y);
            g.DrawString($"Data: {label13.Text}", fontTexto, brushPreto, x + 250, y);
            g.DrawString($"Estado: {cmbEstado.SelectedItem?.ToString() ?? estadoOriginal}", fontTexto, brushPreto, x + 420, y);
            g.DrawString($"Comercial: {Sessao.Nome}", fontTexto, brushPreto, x + 580, y);
            y += 28;
            g.DrawLine(penCinza, x, y, x + larguraUtil, y);
            y += 15;

            // 3. Client details box
            g.DrawString("DADOS DO CLIENTE", fontSecao, brushPreto, x, y);
            y += 22;
            g.DrawString($"Cliente: {label6.Text}", fontTexto, brushPreto, x + 10, y);
            g.DrawString($"NIF: {label7.Text}", fontTexto, brushPreto, x + 400, y);
            y += 20;
            g.DrawString($"Email: {label8.Text}", fontTexto, brushPreto, x + 10, y);
            g.DrawString($"Telefone: {label9.Text}", fontTexto, brushPreto, x + 400, y);
            y += 25;
            g.DrawLine(penCinza, x, y, x + larguraUtil, y);
            y += 15;

            // 4. Products table header
            g.DrawString("ARTIGOS ENCOMENDADOS", fontSecao, brushPreto, x, y);
            y += 24;

            int colXCod = x;
            int colXQtd = x + 100;
            int colXDesc = x + 160;
            int colXPreco = x + 430;
            int colXDescTxt = x + 530;
            int colXTotal = x + 630;

            g.FillRectangle(new SolidBrush(Color.FromArgb(240, 242, 245)), x, y, larguraUtil, 24);
            g.DrawString("CÓDIGO", fontTabelaHead, brushPreto, colXCod + 5, y + 4);
            g.DrawString("QTD", fontTabelaHead, brushPreto, colXQtd, y + 4);
            g.DrawString("DESCRIÇÃO", fontTabelaHead, brushPreto, colXDesc, y + 4);
            g.DrawString("PREÇO", fontTabelaHead, brushPreto, colXPreco, y + 4);
            g.DrawString("DESC.", fontTabelaHead, brushPreto, colXDescTxt, y + 4);
            g.DrawString("TOTAL", fontTabelaHead, brushPreto, colXTotal, y + 4);
            y += 26;

            // 5. Products table rows
            if (dgvLinhas != null)
            {
                foreach (DataGridViewRow row in dgvLinhas.Rows)
                {
                    if (row.IsNewRow) continue;

                    string cod = row.Cells[0].Value?.ToString() ?? "";
                    string qtd = row.Cells[1].Value?.ToString() ?? "";
                    string desc = row.Cells[2].Value?.ToString() ?? "";
                    if (desc.Length > 32) desc = desc.Substring(0, 29) + "...";
                    string preco = row.Cells[3].Value?.ToString() ?? "";
                    string descLinha = row.Cells[4].Value?.ToString() ?? "";
                    string totLinha = row.Cells[5].Value?.ToString() ?? "";

                    g.DrawString(cod, fontTexto, brushPreto, colXCod + 5, y);
                    g.DrawString(qtd, fontTexto, brushPreto, colXQtd, y);
                    g.DrawString(desc, fontTexto, brushPreto, colXDesc, y);
                    g.DrawString(preco, fontTexto, brushPreto, colXPreco, y);
                    g.DrawString(descLinha, fontTexto, brushPreto, colXDescTxt, y);
                    g.DrawString(totLinha, fontTexto, brushPreto, colXTotal, y);

                    y += 20;
                    g.DrawLine(penCinza, x, y, x + larguraUtil, y);
                    y += 4;
                }
            }

            y += 15;

            // 6. Totals section
            int xTotais = x + 450;
            g.DrawString($"Desconto Global: {label19.Text}", fontTexto, brushPreto, xTotais, y);
            y += 22;
            g.DrawString($"TOTAL A PAGAR: {label16.Text}", fontTitulo, brushPreto, xTotais, y);
            y += 45;

            // 7. Signatures section
            g.DrawLine(penLinhaGrossa, x, y, x + 300, y);
            g.DrawLine(penLinhaGrossa, x + 400, y, x + larguraUtil, y);
            y += 6;
            g.DrawString("Assinatura do Cliente / Carimbo", fontSubtitulo, brushCinza, x + 40, y);
            g.DrawString("O Comercial / Responsável de Vendas", fontSubtitulo, brushCinza, x + 430, y);
        }

        #endregion

        #region Hidden Designer Stubs

        private void label16_Click(object sender, EventArgs e) { }
        private void label3_Click(object sender, EventArgs e) { }
        private void label18_Click(object sender, EventArgs e) { }

        #endregion
    }
}