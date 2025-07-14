namespace Vista
{
    partial class FrmLoguin
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLoguin));
            this.btnLogin = new System.Windows.Forms.Button();
            this.pctClose = new System.Windows.Forms.PictureBox();
            this.pctBorde = new System.Windows.Forms.PictureBox();
            this.pctMinimize = new System.Windows.Forms.PictureBox();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.lnkRecuperar = new System.Windows.Forms.LinkLabel();
            this.pctLogo = new System.Windows.Forms.PictureBox();
            this.txtContrasenia = new System.Windows.Forms.TextBox();
            this.pctBordeInferior = new System.Windows.Forms.PictureBox();
            this.pctFondo = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pctClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctBorde)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctMinimize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctBordeInferior)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctFondo)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.White;
            this.btnLogin.FlatAppearance.BorderColor = System.Drawing.Color.MidnightBlue;
            this.btnLogin.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnLogin.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.Font = new System.Drawing.Font("Bahnschrift", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.ForeColor = System.Drawing.Color.Black;
            this.btnLogin.Location = new System.Drawing.Point(110, 303);
            this.btnLogin.Margin = new System.Windows.Forms.Padding(4);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(186, 28);
            this.btnLogin.TabIndex = 4;
            this.btnLogin.Text = "Iniciar Sesión";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // pctClose
            // 
            this.pctClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(40)))));
            this.pctClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pctClose.Image = ((System.Drawing.Image)(resources.GetObject("pctClose.Image")));
            this.pctClose.Location = new System.Drawing.Point(357, 2);
            this.pctClose.Name = "pctClose";
            this.pctClose.Size = new System.Drawing.Size(40, 40);
            this.pctClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pctClose.TabIndex = 8;
            this.pctClose.TabStop = false;
            this.pctClose.Click += new System.EventHandler(this.PctClose_Click);
            // 
            // pctBorde
            // 
            this.pctBorde.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(40)))));
            this.pctBorde.Location = new System.Drawing.Point(-2, 0);
            this.pctBorde.Name = "pctBorde";
            this.pctBorde.Size = new System.Drawing.Size(402, 44);
            this.pctBorde.TabIndex = 9;
            this.pctBorde.TabStop = false;
            this.pctBorde.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pctBorde_MouseDown);
            this.pctBorde.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pctBorde_MouseMove);
            this.pctBorde.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pctBorde_MouseUp);
            // 
            // pctMinimize
            // 
            this.pctMinimize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(40)))));
            this.pctMinimize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pctMinimize.Image = ((System.Drawing.Image)(resources.GetObject("pctMinimize.Image")));
            this.pctMinimize.Location = new System.Drawing.Point(2, 2);
            this.pctMinimize.Name = "pctMinimize";
            this.pctMinimize.Size = new System.Drawing.Size(40, 40);
            this.pctMinimize.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pctMinimize.TabIndex = 11;
            this.pctMinimize.TabStop = false;
            this.pctMinimize.Click += new System.EventHandler(this.PctMinimize_Click);
            // 
            // txtUsuario
            // 
            this.txtUsuario.BackColor = System.Drawing.Color.White;
            this.txtUsuario.Font = new System.Drawing.Font("Bahnschrift", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuario.Location = new System.Drawing.Point(110, 177);
            this.txtUsuario.MaxLength = 25;
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(186, 25);
            this.txtUsuario.TabIndex = 1;
            this.txtUsuario.Enter += new System.EventHandler(this.txtUsuario_Enter);
            this.txtUsuario.Leave += new System.EventHandler(this.txtUsuario_Leave);
            // 
            // lnkRecuperar
            // 
            this.lnkRecuperar.AutoSize = true;
            this.lnkRecuperar.BackColor = System.Drawing.Color.Transparent;
            this.lnkRecuperar.Font = new System.Drawing.Font("Bahnschrift", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkRecuperar.LinkColor = System.Drawing.Color.White;
            this.lnkRecuperar.Location = new System.Drawing.Point(98, 265);
            this.lnkRecuperar.Name = "lnkRecuperar";
            this.lnkRecuperar.Size = new System.Drawing.Size(211, 18);
            this.lnkRecuperar.TabIndex = 3;
            this.lnkRecuperar.TabStop = true;
            this.lnkRecuperar.Text = "Recuperar usuario/contraseña";
            this.lnkRecuperar.VisitedLinkColor = System.Drawing.Color.Blue;
            this.lnkRecuperar.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkRecuperar_LinkClicked);
            // 
            // pctLogo
            // 
            this.pctLogo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pctLogo.BackColor = System.Drawing.Color.Transparent;
            this.pctLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pctLogo.Image = ((System.Drawing.Image)(resources.GetObject("pctLogo.Image")));
            this.pctLogo.Location = new System.Drawing.Point(129, 78);
            this.pctLogo.Name = "pctLogo";
            this.pctLogo.Size = new System.Drawing.Size(150, 95);
            this.pctLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pctLogo.TabIndex = 12;
            this.pctLogo.TabStop = false;
            // 
            // txtContrasenia
            // 
            this.txtContrasenia.Font = new System.Drawing.Font("Bahnschrift", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtContrasenia.Location = new System.Drawing.Point(110, 222);
            this.txtContrasenia.MaxLength = 25;
            this.txtContrasenia.Name = "txtContrasenia";
            this.txtContrasenia.Size = new System.Drawing.Size(186, 25);
            this.txtContrasenia.TabIndex = 2;
            this.txtContrasenia.Enter += new System.EventHandler(this.txtContrasenia_Enter);
            this.txtContrasenia.Leave += new System.EventHandler(this.txtContrasenia_Leave);
            // 
            // pctBordeInferior
            // 
            this.pctBordeInferior.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(40)))));
            this.pctBordeInferior.Location = new System.Drawing.Point(-2, 378);
            this.pctBordeInferior.Name = "pctBordeInferior";
            this.pctBordeInferior.Size = new System.Drawing.Size(402, 22);
            this.pctBordeInferior.TabIndex = 13;
            this.pctBordeInferior.TabStop = false;
            // 
            // pctFondo
            // 
            this.pctFondo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pctFondo.BackgroundImage")));
            this.pctFondo.Location = new System.Drawing.Point(0, 0);
            this.pctFondo.Name = "pctFondo";
            this.pctFondo.Size = new System.Drawing.Size(400, 400);
            this.pctFondo.TabIndex = 14;
            this.pctFondo.TabStop = false;
            // 
            // FrmLoguin
            // 
            this.AcceptButton = this.btnLogin;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(400, 400);
            this.ControlBox = false;
            this.Controls.Add(this.pctBordeInferior);
            this.Controls.Add(this.txtContrasenia);
            this.Controls.Add(this.pctLogo);
            this.Controls.Add(this.lnkRecuperar);
            this.Controls.Add(this.txtUsuario);
            this.Controls.Add(this.pctMinimize);
            this.Controls.Add(this.pctClose);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.pctBorde);
            this.Controls.Add(this.pctFondo);
            this.Font = new System.Drawing.Font("Bahnschrift", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmLoguin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menú";
            this.Load += new System.EventHandler(this.FrmLoguin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pctClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctBorde)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctMinimize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctBordeInferior)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctFondo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.PictureBox pctClose;
        private System.Windows.Forms.PictureBox pctBorde;
        private System.Windows.Forms.PictureBox pctMinimize;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.LinkLabel lnkRecuperar;
        private System.Windows.Forms.PictureBox pctLogo;
        private System.Windows.Forms.TextBox txtContrasenia;
        private System.Windows.Forms.PictureBox pctBordeInferior;
        private System.Windows.Forms.PictureBox pctFondo;
    }
}

