namespace SoftwareVendas
{
    partial class FormGanhos
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            pnlHeader = new Panel();
            lblTitulo = new Label();
            lblSubtitulo = new Label();
            pnlCards = new Panel();
            cardHoje = new Panel();
            lblHojeValor = new Label();
            lblHojeTitulo = new Label();
            cardMes = new Panel();
            lblMesValor = new Label();
            lblMesTitulo = new Label();
            cardComissao = new Panel();
            lblComissaoValor = new Label();
            lblComissaoTitulo = new Label();
            cardQtd = new Panel();
            lblQtdValor = new Label();
            lblQtdTitulo = new Label();
            dgvGanhos = new DataGridView();
            colNE = new DataGridViewTextBoxColumn();
            colData = new DataGridViewTextBoxColumn();
            colCliente = new DataGridViewTextBoxColumn();
            colEstado = new DataGridViewTextBoxColumn();
            colValor = new DataGridViewTextBoxColumn();
            colComissao = new DataGridViewTextBoxColumn();
            pnlFooter = new Panel();
            btnAtualizar = new Button();
            btnFechar = new Button();
            pnlHeader.SuspendLayout();
            pnlCards.SuspendLayout();
            cardHoje.SuspendLayout();
            cardMes.SuspendLayout();
            cardComissao.SuspendLayout();
            cardQtd.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvGanhos).BeginInit();
            pnlFooter.SuspendLayout();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.FromArgb(44, 62, 80);
            pnlHeader.Controls.Add(lblSubtitulo);
            pnlHeader.Controls.Add(lblTitulo);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(1000, 90);
            pnlHeader.TabIndex = 0;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.White;
            lblTitulo.Location = new Point(25, 18);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(420, 32);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Painel de Comissões && Desempenho";
            // 
            // lblSubtitulo
            // 
            lblSubtitulo.AutoSize = true;
            lblSubtitulo.Font = new Font("Segoe UI", 10.5F);
            lblSubtitulo.ForeColor = Color.FromArgb(189, 195, 199);
            lblSubtitulo.Location = new Point(27, 54);
            lblSubtitulo.Name = "lblSubtitulo";
            lblSubtitulo.Size = new Size(160, 19);
            lblSubtitulo.TabIndex = 1;
            lblSubtitulo.Text = "Vendedor: -- | Comissão: --%";
            // 
            // pnlCards
            // 
            pnlCards.Controls.Add(cardQtd);
            pnlCards.Controls.Add(cardComissao);
            pnlCards.Controls.Add(cardMes);
            pnlCards.Controls.Add(cardHoje);
            pnlCards.Dock = DockStyle.Top;
            pnlCards.Location = new Point(0, 90);
            pnlCards.Name = "pnlCards";
            pnlCards.Padding = new Padding(20, 15, 20, 15);
            pnlCards.Size = new Size(1000, 120);
            pnlCards.TabIndex = 1;
            // 
            // cardHoje
            // 
            cardHoje.BackColor = Color.White;
            cardHoje.BorderStyle = BorderStyle.FixedSingle;
            cardHoje.Controls.Add(lblHojeValor);
            cardHoje.Controls.Add(lblHojeTitulo);
            cardHoje.Location = new Point(25, 15);
            cardHoje.Name = "cardHoje";
            cardHoje.Size = new Size(220, 90);
            cardHoje.TabIndex = 0;
            // 
            // lblHojeTitulo
            // 
            lblHojeTitulo.AutoSize = true;
            lblHojeTitulo.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblHojeTitulo.ForeColor = Color.FromArgb(127, 140, 141);
            lblHojeTitulo.Location = new Point(15, 15);
            lblHojeTitulo.Name = "lblHojeTitulo";
            lblHojeTitulo.Size = new Size(100, 15);
            lblHojeTitulo.TabIndex = 0;
            lblHojeTitulo.Text = "FATURADO HOJE";
            // 
            // lblHojeValor
            // 
            lblHojeValor.AutoSize = true;
            lblHojeValor.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblHojeValor.ForeColor = Color.FromArgb(44, 62, 80);
            lblHojeValor.Location = new Point(15, 40);
            lblHojeValor.Name = "lblHojeValor";
            lblHojeValor.Size = new Size(74, 30);
            lblHojeValor.TabIndex = 1;
            lblHojeValor.Text = "0,00 €";
            // 
            // cardMes
            // 
            cardMes.BackColor = Color.White;
            cardMes.BorderStyle = BorderStyle.FixedSingle;
            cardMes.Controls.Add(lblMesValor);
            cardMes.Controls.Add(lblMesTitulo);
            cardMes.Location = new Point(265, 15);
            cardMes.Name = "cardMes";
            cardMes.Size = new Size(220, 90);
            cardMes.TabIndex = 1;
            // 
            // lblMesTitulo
            // 
            lblMesTitulo.AutoSize = true;
            lblMesTitulo.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblMesTitulo.ForeColor = Color.FromArgb(127, 140, 141);
            lblMesTitulo.Location = new Point(15, 15);
            lblMesTitulo.Name = "lblMesTitulo";
            lblMesTitulo.Size = new Size(116, 15);
            lblMesTitulo.TabIndex = 0;
            lblMesTitulo.Text = "FATURADO NO MÊS";
            // 
            // lblMesValor
            // 
            lblMesValor.AutoSize = true;
            lblMesValor.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblMesValor.ForeColor = Color.FromArgb(41, 128, 185);
            lblMesValor.Location = new Point(15, 40);
            lblMesValor.Name = "lblMesValor";
            lblMesValor.Size = new Size(74, 30);
            lblMesValor.TabIndex = 1;
            lblMesValor.Text = "0,00 €";
            // 
            // cardComissao
            // 
            cardComissao.BackColor = Color.White;
            cardComissao.BorderStyle = BorderStyle.FixedSingle;
            cardComissao.Controls.Add(lblComissaoValor);
            cardComissao.Controls.Add(lblComissaoTitulo);
            cardComissao.Location = new Point(505, 15);
            cardComissao.Name = "cardComissao";
            cardComissao.Size = new Size(220, 90);
            cardComissao.TabIndex = 2;
            // 
            // lblComissaoTitulo
            // 
            lblComissaoTitulo.AutoSize = true;
            lblComissaoTitulo.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblComissaoTitulo.ForeColor = Color.FromArgb(127, 140, 141);
            lblComissaoTitulo.Location = new Point(15, 15);
            lblComissaoTitulo.Name = "lblComissaoTitulo";
            lblComissaoTitulo.Size = new Size(130, 15);
            lblComissaoTitulo.TabIndex = 0;
            lblComissaoTitulo.Text = "COMISSÃO ACUMULADA";
            // 
            // lblComissaoValor
            // 
            lblComissaoValor.AutoSize = true;
            lblComissaoValor.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblComissaoValor.ForeColor = Color.FromArgb(39, 174, 96);
            lblComissaoValor.Location = new Point(15, 40);
            lblComissaoValor.Name = "lblComissaoValor";
            lblComissaoValor.Size = new Size(74, 30);
            lblComissaoValor.TabIndex = 1;
            lblComissaoValor.Text = "0,00 €";
            // 
            // cardQtd
            // 
            cardQtd.BackColor = Color.White;
            cardQtd.BorderStyle = BorderStyle.FixedSingle;
            cardQtd.Controls.Add(lblQtdValor);
            cardQtd.Controls.Add(lblQtdTitulo);
            cardQtd.Location = new Point(745, 15);
            cardQtd.Name = "cardQtd";
            cardQtd.Size = new Size(220, 90);
            cardQtd.TabIndex = 3;
            // 
            // lblQtdTitulo
            // 
            lblQtdTitulo.AutoSize = true;
            lblQtdTitulo.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblQtdTitulo.ForeColor = Color.FromArgb(127, 140, 141);
            lblQtdTitulo.Location = new Point(15, 15);
            lblQtdTitulo.Name = "lblQtdTitulo";
            lblQtdTitulo.Size = new Size(136, 15);
            lblQtdTitulo.TabIndex = 0;
            lblQtdTitulo.Text = "TOTAL DE ENCOMENDAS";
            // 
            // lblQtdValor
            // 
            lblQtdValor.AutoSize = true;
            lblQtdValor.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblQtdValor.ForeColor = Color.FromArgb(142, 68, 173);
            lblQtdValor.Location = new Point(15, 40);
            lblQtdValor.Name = "lblQtdValor";
            lblQtdValor.Size = new Size(26, 30);
            lblQtdValor.TabIndex = 1;
            lblQtdValor.Text = "0";
            // 
            // dgvGanhos
            // 
            dgvGanhos.AllowUserToAddRows = false;
            dgvGanhos.AllowUserToDeleteRows = false;
            dgvGanhos.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvGanhos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvGanhos.BackgroundColor = Color.White;
            dgvGanhos.BorderStyle = BorderStyle.None;
            dgvGanhos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvGanhos.Columns.AddRange(new DataGridViewColumn[] {
                colNE, colData, colCliente, colEstado, colValor, colComissao
            });
            dgvGanhos.Location = new Point(25, 225);
            dgvGanhos.Name = "dgvGanhos";
            dgvGanhos.ReadOnly = true;
            dgvGanhos.RowHeadersVisible = false;
            dgvGanhos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvGanhos.Size = new Size(950, 360);
            dgvGanhos.TabIndex = 2;
            // 
            // colNE
            // 
            colNE.FillWeight = 50F;
            colNE.HeaderText = "Nº Encomenda";
            colNE.Name = "colNE";
            colNE.ReadOnly = true;
            // 
            // colData
            // 
            colData.FillWeight = 65F;
            colData.HeaderText = "Data";
            colData.Name = "colData";
            colData.ReadOnly = true;
            // 
            // colCliente
            // 
            colCliente.FillWeight = 140F;
            colCliente.HeaderText = "Cliente";
            colCliente.Name = "colCliente";
            colCliente.ReadOnly = true;
            // 
            // colEstado
            // 
            colEstado.FillWeight = 65F;
            colEstado.HeaderText = "Estado";
            colEstado.Name = "colEstado";
            colEstado.ReadOnly = true;
            // 
            // colValor
            // 
            colValor.FillWeight = 75F;
            colValor.HeaderText = "Valor Total (€)";
            colValor.Name = "colValor";
            colValor.ReadOnly = true;
            // 
            // colComissao
            // 
            colComissao.FillWeight = 75F;
            colComissao.HeaderText = "Comissão (€)";
            colComissao.Name = "colComissao";
            colComissao.ReadOnly = true;
            // 
            // pnlFooter
            // 
            pnlFooter.BackColor = Color.FromArgb(240, 242, 245);
            pnlFooter.Controls.Add(btnAtualizar);
            pnlFooter.Controls.Add(btnFechar);
            pnlFooter.Dock = DockStyle.Bottom;
            pnlFooter.Location = new Point(0, 600);
            pnlFooter.Name = "pnlFooter";
            pnlFooter.Size = new Size(1000, 70);
            pnlFooter.TabIndex = 3;
            // 
            // btnAtualizar
            // 
            btnAtualizar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnAtualizar.BackColor = Color.FromArgb(52, 152, 219);
            btnAtualizar.Cursor = Cursors.Hand;
            btnAtualizar.FlatAppearance.BorderSize = 0;
            btnAtualizar.FlatStyle = FlatStyle.Flat;
            btnAtualizar.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            btnAtualizar.ForeColor = Color.White;
            btnAtualizar.Location = new Point(690, 15);
            btnAtualizar.Name = "btnAtualizar";
            btnAtualizar.Size = new Size(135, 40);
            btnAtualizar.TabIndex = 1;
            btnAtualizar.Text = "Atualizar";
            btnAtualizar.UseVisualStyleBackColor = false;
            // 
            // btnFechar
            // 
            btnFechar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnFechar.BackColor = Color.FromArgb(108, 117, 125);
            btnFechar.Cursor = Cursors.Hand;
            btnFechar.FlatAppearance.BorderSize = 0;
            btnFechar.FlatStyle = FlatStyle.Flat;
            btnFechar.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            btnFechar.ForeColor = Color.White;
            btnFechar.Location = new Point(840, 15);
            btnFechar.Name = "btnFechar";
            btnFechar.Size = new Size(135, 40);
            btnFechar.TabIndex = 0;
            btnFechar.Text = "Fechar";
            btnFechar.UseVisualStyleBackColor = false;
            // 
            // FormGanhos
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(240, 242, 245);
            ClientSize = new Size(1000, 670);
            Controls.Add(dgvGanhos);
            Controls.Add(pnlCards);
            Controls.Add(pnlHeader);
            Controls.Add(pnlFooter);
            Font = new Font("Segoe UI", 9.5F);
            MinimumSize = new Size(900, 600);
            Name = "FormGanhos";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Gestão Comercial - Painel de Comissões e Ganhos";
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            pnlCards.ResumeLayout(false);
            cardHoje.ResumeLayout(false);
            cardHoje.PerformLayout();
            cardMes.ResumeLayout(false);
            cardMes.PerformLayout();
            cardComissao.ResumeLayout(false);
            cardComissao.PerformLayout();
            cardQtd.ResumeLayout(false);
            cardQtd.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvGanhos).EndInit();
            pnlFooter.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlHeader;
        private Label lblTitulo;
        private Label lblSubtitulo;
        private Panel pnlCards;
        private Panel cardHoje;
        private Label lblHojeValor;
        private Label lblHojeTitulo;
        private Panel cardMes;
        private Label lblMesValor;
        private Label lblMesTitulo;
        private Panel cardComissao;
        private Label lblComissaoValor;
        private Label lblComissaoTitulo;
        private Panel cardQtd;
        private Label lblQtdValor;
        private Label lblQtdTitulo;
        private DataGridView dgvGanhos;
        private DataGridViewTextBoxColumn colNE;
        private DataGridViewTextBoxColumn colData;
        private DataGridViewTextBoxColumn colCliente;
        private DataGridViewTextBoxColumn colEstado;
        private DataGridViewTextBoxColumn colValor;
        private DataGridViewTextBoxColumn colComissao;
        private Panel pnlFooter;
        private Button btnAtualizar;
        private Button btnFechar;
    }
}
