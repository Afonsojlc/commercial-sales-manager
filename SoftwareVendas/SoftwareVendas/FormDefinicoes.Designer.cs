namespace SoftwareVendas
{
    partial class FormDefinicoes
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
            grpUtilizador = new GroupBox();
            lblInfoComissao = new Label();
            lblInfoCargo = new Label();
            lblInfoNome = new Label();
            grpBaseDados = new GroupBox();
            btnTestar = new Button();
            txtConnectionString = new TextBox();
            lblConn = new Label();
            pnlFooter = new Panel();
            btnGuardar = new Button();
            btnFechar = new Button();
            pnlHeader.SuspendLayout();
            grpUtilizador.SuspendLayout();
            grpBaseDados.SuspendLayout();
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
            pnlHeader.Size = new Size(680, 80);
            pnlHeader.TabIndex = 0;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.White;
            lblTitulo.Location = new Point(25, 15);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(270, 30);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Definições da Aplicação";
            // 
            // lblSubtitulo
            // 
            lblSubtitulo.AutoSize = true;
            lblSubtitulo.Font = new Font("Segoe UI", 9.5F);
            lblSubtitulo.ForeColor = Color.FromArgb(189, 195, 199);
            lblSubtitulo.Location = new Point(27, 48);
            lblSubtitulo.Name = "lblSubtitulo";
            lblSubtitulo.Size = new Size(310, 17);
            lblSubtitulo.TabIndex = 1;
            lblSubtitulo.Text = "Configurações de sistema e perfil comercial ativo";
            // 
            // grpUtilizador
            // 
            grpUtilizador.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            grpUtilizador.Controls.Add(lblInfoComissao);
            grpUtilizador.Controls.Add(lblInfoCargo);
            grpUtilizador.Controls.Add(lblInfoNome);
            grpUtilizador.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            grpUtilizador.ForeColor = Color.FromArgb(44, 62, 80);
            grpUtilizador.Location = new Point(25, 100);
            grpUtilizador.Name = "grpUtilizador";
            grpUtilizador.Size = new Size(630, 130);
            grpUtilizador.TabIndex = 1;
            grpUtilizador.TabStop = false;
            grpUtilizador.Text = "Perfil Comercial Ativo";
            // 
            // lblInfoComissao
            // 
            lblInfoComissao.AutoSize = true;
            lblInfoComissao.Font = new Font("Segoe UI", 10F);
            lblInfoComissao.Location = new Point(20, 95);
            lblInfoComissao.Name = "lblInfoComissao";
            lblInfoComissao.Size = new Size(190, 19);
            lblInfoComissao.TabIndex = 2;
            lblInfoComissao.Text = "Percentagem de Comissão: --%";
            // 
            // lblInfoCargo
            // 
            lblInfoCargo.AutoSize = true;
            lblInfoCargo.Font = new Font("Segoe UI", 10F);
            lblInfoCargo.Location = new Point(20, 65);
            lblInfoCargo.Name = "lblInfoCargo";
            lblInfoCargo.Size = new Size(120, 19);
            lblInfoCargo.TabIndex = 1;
            lblInfoCargo.Text = "Cargo: --";
            // 
            // lblInfoNome
            // 
            lblInfoNome.AutoSize = true;
            lblInfoNome.Font = new Font("Segoe UI", 10F);
            lblInfoNome.Location = new Point(20, 35);
            lblInfoNome.Name = "lblInfoNome";
            lblInfoNome.Size = new Size(130, 19);
            lblInfoNome.TabIndex = 0;
            lblInfoNome.Text = "Utilizador: --";
            // 
            // grpBaseDados
            // 
            grpBaseDados.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            grpBaseDados.Controls.Add(btnTestar);
            grpBaseDados.Controls.Add(txtConnectionString);
            grpBaseDados.Controls.Add(lblConn);
            grpBaseDados.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            grpBaseDados.ForeColor = Color.FromArgb(44, 62, 80);
            grpBaseDados.Location = new Point(25, 245);
            grpBaseDados.Name = "grpBaseDados";
            grpBaseDados.Size = new Size(630, 175);
            grpBaseDados.TabIndex = 2;
            grpBaseDados.TabStop = false;
            grpBaseDados.Text = "Conexão SQL Server";
            // 
            // btnTestar
            // 
            btnTestar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnTestar.BackColor = Color.FromArgb(52, 73, 94);
            btnTestar.Cursor = Cursors.Hand;
            btnTestar.FlatAppearance.BorderSize = 0;
            btnTestar.FlatStyle = FlatStyle.Flat;
            btnTestar.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnTestar.ForeColor = Color.White;
            btnTestar.Location = new Point(475, 125);
            btnTestar.Name = "btnTestar";
            btnTestar.Size = new Size(140, 35);
            btnTestar.TabIndex = 2;
            btnTestar.Text = "Testar Conexão";
            btnTestar.UseVisualStyleBackColor = false;
            // 
            // txtConnectionString
            // 
            txtConnectionString.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtConnectionString.Font = new Font("Consolas", 9.5F);
            txtConnectionString.Location = new Point(20, 55);
            txtConnectionString.Multiline = true;
            txtConnectionString.Name = "txtConnectionString";
            txtConnectionString.Size = new Size(595, 60);
            txtConnectionString.TabIndex = 1;
            // 
            // lblConn
            // 
            lblConn.AutoSize = true;
            lblConn.Font = new Font("Segoe UI", 9.5F);
            lblConn.Location = new Point(20, 30);
            lblConn.Name = "lblConn";
            lblConn.Size = new Size(175, 17);
            lblConn.TabIndex = 0;
            lblConn.Text = "String de Conexão (ADO.NET):";
            // 
            // pnlFooter
            // 
            pnlFooter.BackColor = Color.FromArgb(240, 242, 245);
            pnlFooter.Controls.Add(btnGuardar);
            pnlFooter.Controls.Add(btnFechar);
            pnlFooter.Dock = DockStyle.Bottom;
            pnlFooter.Location = new Point(0, 440);
            pnlFooter.Name = "pnlFooter";
            pnlFooter.Size = new Size(680, 65);
            pnlFooter.TabIndex = 3;
            // 
            // btnGuardar
            // 
            btnGuardar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnGuardar.BackColor = Color.FromArgb(39, 174, 96);
            btnGuardar.Cursor = Cursors.Hand;
            btnGuardar.FlatAppearance.BorderSize = 0;
            btnGuardar.FlatStyle = FlatStyle.Flat;
            btnGuardar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnGuardar.ForeColor = Color.White;
            btnGuardar.Location = new Point(395, 15);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(130, 38);
            btnGuardar.TabIndex = 1;
            btnGuardar.Text = "Gravar";
            btnGuardar.UseVisualStyleBackColor = false;
            // 
            // btnFechar
            // 
            btnFechar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnFechar.BackColor = Color.FromArgb(108, 117, 125);
            btnFechar.Cursor = Cursors.Hand;
            btnFechar.FlatAppearance.BorderSize = 0;
            btnFechar.FlatStyle = FlatStyle.Flat;
            btnFechar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnFechar.ForeColor = Color.White;
            btnFechar.Location = new Point(535, 15);
            btnFechar.Name = "btnFechar";
            btnFechar.Size = new Size(120, 38);
            btnFechar.TabIndex = 0;
            btnFechar.Text = "Fechar";
            btnFechar.UseVisualStyleBackColor = false;
            // 
            // FormDefinicoes
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(240, 242, 245);
            ClientSize = new Size(680, 505);
            Controls.Add(grpBaseDados);
            Controls.Add(grpUtilizador);
            Controls.Add(pnlHeader);
            Controls.Add(pnlFooter);
            Font = new Font("Segoe UI", 9.5F);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormDefinicoes";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Definições do Sistema";
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            grpUtilizador.ResumeLayout(false);
            grpUtilizador.PerformLayout();
            grpBaseDados.ResumeLayout(false);
            grpBaseDados.PerformLayout();
            pnlFooter.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlHeader;
        private Label lblTitulo;
        private Label lblSubtitulo;
        private GroupBox grpUtilizador;
        private Label lblInfoComissao;
        private Label lblInfoCargo;
        private Label lblInfoNome;
        private GroupBox grpBaseDados;
        private TextBox txtConnectionString;
        private Label lblConn;
        private Button btnTestar;
        private Panel pnlFooter;
        private Button btnGuardar;
        private Button btnFechar;
    }
}
