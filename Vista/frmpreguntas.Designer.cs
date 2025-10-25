namespace Vista
{
    partial class frmPreguntas
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPreguntas));
            this.lblInstrucciones = new System.Windows.Forms.Label();
            this.lblUsuariopregserg = new System.Windows.Forms.Label();
            this.txtRespuesta1 = new System.Windows.Forms.TextBox();
            this.txtRespuesta2 = new System.Windows.Forms.TextBox();
            this.txtRespuesta3 = new System.Windows.Forms.TextBox();
            this.btnSiguientepregseg = new System.Windows.Forms.Button();
            this.lblrespuestasseg = new System.Windows.Forms.Label();
            this.cmbPregunta1 = new System.Windows.Forms.ComboBox();
            this.cmbPregunta2 = new System.Windows.Forms.ComboBox();
            this.cmbPregunta3 = new System.Windows.Forms.ComboBox();
            this.lblPreguntasseg = new System.Windows.Forms.Label();
            this.pnlBorde = new System.Windows.Forms.Panel();
            this.lblTitulopreguntasseg = new System.Windows.Forms.Label();
            this.pctMinimize = new System.Windows.Forms.PictureBox();
            this.pctClose = new System.Windows.Forms.PictureBox();
            this.lblAdorno = new System.Windows.Forms.Label();
            this.pnlBotones = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pctLogo = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pnlBorde.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctMinimize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctClose)).BeginInit();
            this.pnlBotones.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // lblInstrucciones
            // 
            this.lblInstrucciones.BackColor = System.Drawing.Color.Transparent;
            this.lblInstrucciones.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblInstrucciones.ForeColor = System.Drawing.Color.White;
            this.lblInstrucciones.Location = new System.Drawing.Point(0, 167);
            this.lblInstrucciones.Name = "lblInstrucciones";
            this.lblInstrucciones.Size = new System.Drawing.Size(600, 25);
            this.lblInstrucciones.TabIndex = 1;
            this.lblInstrucciones.Text = "Instrucciones";
            this.lblInstrucciones.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblUsuariopregserg
            // 
            this.lblUsuariopregserg.BackColor = System.Drawing.Color.Transparent;
            this.lblUsuariopregserg.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblUsuariopregserg.ForeColor = System.Drawing.Color.White;
            this.lblUsuariopregserg.Location = new System.Drawing.Point(0, 385);
            this.lblUsuariopregserg.Name = "lblUsuariopregserg";
            this.lblUsuariopregserg.Size = new System.Drawing.Size(600, 20);
            this.lblUsuariopregserg.TabIndex = 2;
            this.lblUsuariopregserg.Text = "Usuario";
            this.lblUsuariopregserg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtRespuesta1
            // 
            this.txtRespuesta1.Location = new System.Drawing.Point(360, 33);
            this.txtRespuesta1.Name = "txtRespuesta1";
            this.txtRespuesta1.Size = new System.Drawing.Size(225, 25);
            this.txtRespuesta1.TabIndex = 2;
            this.txtRespuesta1.TextChanged += new System.EventHandler(this.txtRespuesta1_TextChanged);
            // 
            // txtRespuesta2
            // 
            this.txtRespuesta2.Location = new System.Drawing.Point(360, 73);
            this.txtRespuesta2.Name = "txtRespuesta2";
            this.txtRespuesta2.Size = new System.Drawing.Size(225, 25);
            this.txtRespuesta2.TabIndex = 4;
            this.txtRespuesta2.TextChanged += new System.EventHandler(this.txtRespuesta2_TextChanged);
            // 
            // txtRespuesta3
            // 
            this.txtRespuesta3.Location = new System.Drawing.Point(360, 114);
            this.txtRespuesta3.Name = "txtRespuesta3";
            this.txtRespuesta3.Size = new System.Drawing.Size(225, 25);
            this.txtRespuesta3.TabIndex = 6;
            this.txtRespuesta3.TextChanged += new System.EventHandler(this.txtRespuesta3_TextChanged);
            // 
            // btnSiguientepregseg
            // 
            this.btnSiguientepregseg.Location = new System.Drawing.Point(152, 5);
            this.btnSiguientepregseg.Name = "btnSiguientepregseg";
            this.btnSiguientepregseg.Size = new System.Drawing.Size(275, 30);
            this.btnSiguientepregseg.TabIndex = 7;
            this.btnSiguientepregseg.Text = "Siguiente";
            this.btnSiguientepregseg.UseVisualStyleBackColor = true;
            this.btnSiguientepregseg.Click += new System.EventHandler(this.btnsiguiente_Click);
            // 
            // lblrespuestasseg
            // 
            this.lblrespuestasseg.ForeColor = System.Drawing.Color.White;
            this.lblrespuestasseg.Location = new System.Drawing.Point(360, 0);
            this.lblrespuestasseg.Name = "lblrespuestasseg";
            this.lblrespuestasseg.Size = new System.Drawing.Size(225, 30);
            this.lblrespuestasseg.TabIndex = 8;
            this.lblrespuestasseg.Text = "Respuestas";
            this.lblrespuestasseg.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbPregunta1
            // 
            this.cmbPregunta1.FormattingEnabled = true;
            this.cmbPregunta1.Location = new System.Drawing.Point(15, 33);
            this.cmbPregunta1.Name = "cmbPregunta1";
            this.cmbPregunta1.Size = new System.Drawing.Size(330, 26);
            this.cmbPregunta1.TabIndex = 1;
            // 
            // cmbPregunta2
            // 
            this.cmbPregunta2.FormattingEnabled = true;
            this.cmbPregunta2.Location = new System.Drawing.Point(15, 73);
            this.cmbPregunta2.Name = "cmbPregunta2";
            this.cmbPregunta2.Size = new System.Drawing.Size(330, 26);
            this.cmbPregunta2.TabIndex = 3;
            // 
            // cmbPregunta3
            // 
            this.cmbPregunta3.FormattingEnabled = true;
            this.cmbPregunta3.Location = new System.Drawing.Point(15, 113);
            this.cmbPregunta3.Name = "cmbPregunta3";
            this.cmbPregunta3.Size = new System.Drawing.Size(330, 26);
            this.cmbPregunta3.TabIndex = 5;
            // 
            // lblPreguntasseg
            // 
            this.lblPreguntasseg.ForeColor = System.Drawing.Color.White;
            this.lblPreguntasseg.Location = new System.Drawing.Point(15, 0);
            this.lblPreguntasseg.Name = "lblPreguntasseg";
            this.lblPreguntasseg.Size = new System.Drawing.Size(330, 30);
            this.lblPreguntasseg.TabIndex = 12;
            this.lblPreguntasseg.Text = "Preguntas";
            this.lblPreguntasseg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlBorde
            // 
            this.pnlBorde.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(40)))));
            this.pnlBorde.Controls.Add(this.lblTitulopreguntasseg);
            this.pnlBorde.Controls.Add(this.pctMinimize);
            this.pnlBorde.Controls.Add(this.pctClose);
            this.pnlBorde.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBorde.Location = new System.Drawing.Point(0, 0);
            this.pnlBorde.Name = "pnlBorde";
            this.pnlBorde.Size = new System.Drawing.Size(600, 40);
            this.pnlBorde.TabIndex = 24;
            // 
            // lblTitulopreguntasseg
            // 
            this.lblTitulopreguntasseg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitulopreguntasseg.Font = new System.Drawing.Font("Bahnschrift", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulopreguntasseg.ForeColor = System.Drawing.Color.White;
            this.lblTitulopreguntasseg.Location = new System.Drawing.Point(40, 0);
            this.lblTitulopreguntasseg.Name = "lblTitulopreguntasseg";
            this.lblTitulopreguntasseg.Size = new System.Drawing.Size(520, 40);
            this.lblTitulopreguntasseg.TabIndex = 8028;
            this.lblTitulopreguntasseg.Text = "Preguntas de seguridad";
            this.lblTitulopreguntasseg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pctMinimize
            // 
            this.pctMinimize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(40)))));
            this.pctMinimize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pctMinimize.Dock = System.Windows.Forms.DockStyle.Left;
            this.pctMinimize.Image = ((System.Drawing.Image)(resources.GetObject("pctMinimize.Image")));
            this.pctMinimize.Location = new System.Drawing.Point(0, 0);
            this.pctMinimize.Name = "pctMinimize";
            this.pctMinimize.Size = new System.Drawing.Size(40, 40);
            this.pctMinimize.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pctMinimize.TabIndex = 22;
            this.pctMinimize.TabStop = false;
            this.pctMinimize.Click += new System.EventHandler(this.pctMinimize_Click);
            // 
            // pctClose
            // 
            this.pctClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(40)))));
            this.pctClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pctClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.pctClose.Image = ((System.Drawing.Image)(resources.GetObject("pctClose.Image")));
            this.pctClose.Location = new System.Drawing.Point(560, 0);
            this.pctClose.Name = "pctClose";
            this.pctClose.Size = new System.Drawing.Size(40, 40);
            this.pctClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pctClose.TabIndex = 20;
            this.pctClose.TabStop = false;
            this.pctClose.Click += new System.EventHandler(this.pctClose_Click_1);
            // 
            // lblAdorno
            // 
            this.lblAdorno.BackColor = System.Drawing.Color.Transparent;
            this.lblAdorno.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblAdorno.Location = new System.Drawing.Point(0, 40);
            this.lblAdorno.Name = "lblAdorno";
            this.lblAdorno.Size = new System.Drawing.Size(600, 10);
            this.lblAdorno.TabIndex = 26;
            this.lblAdorno.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlBotones
            // 
            this.pnlBotones.BackColor = System.Drawing.Color.Transparent;
            this.pnlBotones.Controls.Add(this.btnSiguientepregseg);
            this.pnlBotones.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBotones.Location = new System.Drawing.Point(0, 340);
            this.pnlBotones.Name = "pnlBotones";
            this.pnlBotones.Size = new System.Drawing.Size(600, 45);
            this.pnlBotones.TabIndex = 28;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Transparent;
            this.panel3.Controls.Add(this.lblrespuestasseg);
            this.panel3.Controls.Add(this.lblPreguntasseg);
            this.panel3.Controls.Add(this.txtRespuesta1);
            this.panel3.Controls.Add(this.txtRespuesta2);
            this.panel3.Controls.Add(this.cmbPregunta1);
            this.panel3.Controls.Add(this.txtRespuesta3);
            this.panel3.Controls.Add(this.cmbPregunta2);
            this.panel3.Controls.Add(this.cmbPregunta3);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 192);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(600, 148);
            this.panel3.TabIndex = 30;
            // 
            // pctLogo
            // 
            this.pctLogo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pctLogo.BackColor = System.Drawing.Color.Transparent;
            this.pctLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pctLogo.Image = ((System.Drawing.Image)(resources.GetObject("pctLogo.Image")));
            this.pctLogo.Location = new System.Drawing.Point(225, 55);
            this.pctLogo.Name = "pctLogo";
            this.pctLogo.Size = new System.Drawing.Size(150, 95);
            this.pctLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pctLogo.TabIndex = 31;
            this.pctLogo.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(40)))));
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 405);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(600, 20);
            this.panel2.TabIndex = 25;
            // 
            // frmPreguntas
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImage = global::Vista.Properties.Resources.WoodenPlankCyan;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(600, 425);
            this.Controls.Add(this.lblInstrucciones);
            this.Controls.Add(this.pctLogo);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.lblAdorno);
            this.Controls.Add(this.pnlBorde);
            this.Controls.Add(this.pnlBotones);
            this.Controls.Add(this.lblUsuariopregserg);
            this.Controls.Add(this.panel2);
            this.Font = new System.Drawing.Font("Bahnschrift", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmPreguntas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Preguntas de seguridad";
            this.Load += new System.EventHandler(this.frmPreguntas_Load);
            this.Shown += new System.EventHandler(this.frmPreguntas_Shown);
            this.pnlBorde.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pctMinimize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctClose)).EndInit();
            this.pnlBotones.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lblInstrucciones;
        private System.Windows.Forms.Label lblUsuariopregserg;
        private System.Windows.Forms.TextBox txtRespuesta1;
        private System.Windows.Forms.TextBox txtRespuesta2;
        private System.Windows.Forms.TextBox txtRespuesta3;
        private System.Windows.Forms.Button btnSiguientepregseg;
        private System.Windows.Forms.Label lblrespuestasseg;
        private System.Windows.Forms.ComboBox cmbPregunta1;
        private System.Windows.Forms.ComboBox cmbPregunta2;
        private System.Windows.Forms.ComboBox cmbPregunta3;
        private System.Windows.Forms.Label lblPreguntasseg;
        private System.Windows.Forms.Panel pnlBorde;
        private System.Windows.Forms.PictureBox pctMinimize;
        private System.Windows.Forms.PictureBox pctClose;
        private System.Windows.Forms.Label lblAdorno;
        private System.Windows.Forms.Panel pnlBotones;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox pctLogo;
        private System.Windows.Forms.Label lblTitulopreguntasseg;
        private System.Windows.Forms.Panel panel2;
    }
}