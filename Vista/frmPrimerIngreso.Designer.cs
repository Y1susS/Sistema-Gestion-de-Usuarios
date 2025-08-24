namespace Vista
{
    partial class frmPrimerIngreso
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrimerIngreso));
            this.pctBordeInferior = new System.Windows.Forms.PictureBox();
            this.txtConfirmaPass = new System.Windows.Forms.TextBox();
            this.pctLogo = new System.Windows.Forms.PictureBox();
            this.txtNuevaPass = new System.Windows.Forms.TextBox();
            this.pctMinimize = new System.Windows.Forms.PictureBox();
            this.pctClose = new System.Windows.Forms.PictureBox();
            this.btnCambiar = new System.Windows.Forms.Button();
            this.pctBorde = new System.Windows.Forms.PictureBox();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.lblMensaje = new System.Windows.Forms.Label();
            this.pctFondo = new System.Windows.Forms.PictureBox();
            this.lblLogin = new System.Windows.Forms.Label();
            this.pctMostrar = new System.Windows.Forms.PictureBox();
            this.pctOcultar = new System.Windows.Forms.PictureBox();
            this.pctMostrar2 = new System.Windows.Forms.PictureBox();
            this.pctOcultar2 = new System.Windows.Forms.PictureBox();
            this.lblRestriccionesTexto = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pctBordeInferior)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctMinimize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctBorde)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctFondo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctMostrar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctOcultar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctMostrar2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctOcultar2)).BeginInit();
            this.SuspendLayout();
            // 
            // pctBordeInferior
            // 
            this.pctBordeInferior.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(40)))));
            this.pctBordeInferior.Location = new System.Drawing.Point(-2, 506);
            this.pctBordeInferior.Name = "pctBordeInferior";
            this.pctBordeInferior.Size = new System.Drawing.Size(525, 22);
            this.pctBordeInferior.TabIndex = 22;
            this.pctBordeInferior.TabStop = false;
            // 
            // txtConfirmaPass
            // 
            this.txtConfirmaPass.Font = new System.Drawing.Font("Bahnschrift", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConfirmaPass.Location = new System.Drawing.Point(162, 269);
            this.txtConfirmaPass.MaxLength = 25;
            this.txtConfirmaPass.Name = "txtConfirmaPass";
            this.txtConfirmaPass.Size = new System.Drawing.Size(185, 30);
            this.txtConfirmaPass.TabIndex = 3;
            this.txtConfirmaPass.Enter += new System.EventHandler(this.txtConfirmaPass_Enter);
            this.txtConfirmaPass.Leave += new System.EventHandler(this.txtConfirmaPass_Leave);
            // 
            // pctLogo
            // 
            this.pctLogo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pctLogo.BackColor = System.Drawing.Color.Transparent;
            this.pctLogo.Image = ((System.Drawing.Image)(resources.GetObject("pctLogo.Image")));
            this.pctLogo.Location = new System.Drawing.Point(188, 61);
            this.pctLogo.Name = "pctLogo";
            this.pctLogo.Size = new System.Drawing.Size(150, 95);
            this.pctLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pctLogo.TabIndex = 21;
            this.pctLogo.TabStop = false;
            // 
            // txtNuevaPass
            // 
            this.txtNuevaPass.BackColor = System.Drawing.Color.White;
            this.txtNuevaPass.Font = new System.Drawing.Font("Bahnschrift", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNuevaPass.Location = new System.Drawing.Point(162, 220);
            this.txtNuevaPass.MaxLength = 25;
            this.txtNuevaPass.Name = "txtNuevaPass";
            this.txtNuevaPass.Size = new System.Drawing.Size(185, 30);
            this.txtNuevaPass.TabIndex = 2;
            this.txtNuevaPass.Enter += new System.EventHandler(this.txtNuevaPass_Enter);
            this.txtNuevaPass.Leave += new System.EventHandler(this.txtNuevaPass_Leave);
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
            this.pctMinimize.TabIndex = 20;
            this.pctMinimize.TabStop = false;
            this.pctMinimize.Click += new System.EventHandler(this.pctMinimize_Click_1);
            // 
            // pctClose
            // 
            this.pctClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(40)))));
            this.pctClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pctClose.Image = ((System.Drawing.Image)(resources.GetObject("pctClose.Image")));
            this.pctClose.Location = new System.Drawing.Point(483, 2);
            this.pctClose.Name = "pctClose";
            this.pctClose.Size = new System.Drawing.Size(40, 40);
            this.pctClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pctClose.TabIndex = 18;
            this.pctClose.TabStop = false;
            this.pctClose.Click += new System.EventHandler(this.pctClose_Click_1);
            // 
            // btnCambiar
            // 
            this.btnCambiar.BackColor = System.Drawing.Color.White;
            this.btnCambiar.FlatAppearance.BorderColor = System.Drawing.Color.MidnightBlue;
            this.btnCambiar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnCambiar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnCambiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCambiar.Font = new System.Drawing.Font("Bahnschrift", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCambiar.ForeColor = System.Drawing.Color.Black;
            this.btnCambiar.Location = new System.Drawing.Point(162, 317);
            this.btnCambiar.Margin = new System.Windows.Forms.Padding(4);
            this.btnCambiar.Name = "btnCambiar";
            this.btnCambiar.Size = new System.Drawing.Size(185, 30);
            this.btnCambiar.TabIndex = 3;
            this.btnCambiar.Text = "Cambiar";
            this.btnCambiar.UseVisualStyleBackColor = false;
            this.btnCambiar.Click += new System.EventHandler(this.btnCambiar_Click);
            // 
            // pctBorde
            // 
            this.pctBorde.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(40)))));
            this.pctBorde.Location = new System.Drawing.Point(-2, 0);
            this.pctBorde.Name = "pctBorde";
            this.pctBorde.Size = new System.Drawing.Size(525, 44);
            this.pctBorde.TabIndex = 19;
            this.pctBorde.TabStop = false;
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Font = new System.Drawing.Font("Bahnschrift", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuario.ForeColor = System.Drawing.Color.White;
            this.lblUsuario.Location = new System.Drawing.Point(2, 480);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(76, 23);
            this.lblUsuario.TabIndex = 25;
            this.lblUsuario.Text = "Usuario";
            // 
            // lblMensaje
            // 
            this.lblMensaje.Font = new System.Drawing.Font("Bahnschrift", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMensaje.ForeColor = System.Drawing.Color.White;
            this.lblMensaje.Location = new System.Drawing.Point(72, 159);
            this.lblMensaje.Name = "lblMensaje";
            this.lblMensaje.Size = new System.Drawing.Size(376, 48);
            this.lblMensaje.TabIndex = 26;
            this.lblMensaje.Text = "Mensaje";
            this.lblMensaje.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pctFondo
            // 
            this.pctFondo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pctFondo.BackgroundImage")));
            this.pctFondo.Location = new System.Drawing.Point(0, 0);
            this.pctFondo.Name = "pctFondo";
            this.pctFondo.Size = new System.Drawing.Size(523, 528);
            this.pctFondo.TabIndex = 27;
            this.pctFondo.TabStop = false;
            // 
            // lblLogin
            // 
            this.lblLogin.AutoSize = true;
            this.lblLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(40)))));
            this.lblLogin.Font = new System.Drawing.Font("Bahnschrift", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLogin.ForeColor = System.Drawing.Color.White;
            this.lblLogin.Location = new System.Drawing.Point(165, 9);
            this.lblLogin.Name = "lblLogin";
            this.lblLogin.Size = new System.Drawing.Size(182, 30);
            this.lblLogin.TabIndex = 33;
            this.lblLogin.Text = "Primer Ingreso";
            // 
            // pctMostrar
            // 
            this.pctMostrar.BackColor = System.Drawing.Color.Transparent;
            this.pctMostrar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pctMostrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pctMostrar.Image = ((System.Drawing.Image)(resources.GetObject("pctMostrar.Image")));
            this.pctMostrar.Location = new System.Drawing.Point(353, 220);
            this.pctMostrar.Name = "pctMostrar";
            this.pctMostrar.Size = new System.Drawing.Size(35, 35);
            this.pctMostrar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pctMostrar.TabIndex = 34;
            this.pctMostrar.TabStop = false;
            //this.pctMostrar.Click += new System.EventHandler(this.pctMostrar_Click);
            // 
            // pctOcultar
            // 
            this.pctOcultar.BackColor = System.Drawing.Color.Transparent;
            this.pctOcultar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pctOcultar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pctOcultar.Image = ((System.Drawing.Image)(resources.GetObject("pctOcultar.Image")));
            this.pctOcultar.Location = new System.Drawing.Point(353, 220);
            this.pctOcultar.Name = "pctOcultar";
            this.pctOcultar.Size = new System.Drawing.Size(35, 35);
            this.pctOcultar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pctOcultar.TabIndex = 35;
            this.pctOcultar.TabStop = false;
            //this.pctOcultar.Click += new System.EventHandler(this.pctOcultar_Click);
            // 
            // pctMostrar2
            // 
            this.pctMostrar2.BackColor = System.Drawing.Color.Transparent;
            this.pctMostrar2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pctMostrar2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pctMostrar2.Image = ((System.Drawing.Image)(resources.GetObject("pctMostrar2.Image")));
            this.pctMostrar2.Location = new System.Drawing.Point(353, 269);
            this.pctMostrar2.Name = "pctMostrar2";
            this.pctMostrar2.Size = new System.Drawing.Size(35, 35);
            this.pctMostrar2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pctMostrar2.TabIndex = 36;
            this.pctMostrar2.TabStop = false;
            //this.pctMostrar2.Click += new System.EventHandler(this.pctMostrar2_Click);
            // 
            // pctOcultar2
            // 
            this.pctOcultar2.BackColor = System.Drawing.Color.Transparent;
            this.pctOcultar2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pctOcultar2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pctOcultar2.Image = ((System.Drawing.Image)(resources.GetObject("pctOcultar2.Image")));
            this.pctOcultar2.Location = new System.Drawing.Point(353, 269);
            this.pctOcultar2.Name = "pctOcultar2";
            this.pctOcultar2.Size = new System.Drawing.Size(35, 35);
            this.pctOcultar2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pctOcultar2.TabIndex = 37;
            this.pctOcultar2.TabStop = false;
            //this.pctOcultar2.Click += new System.EventHandler(this.pctOcultar2_Click);
            // 
            // lblRestriccionesTexto
            // 
            this.lblRestriccionesTexto.BackColor = System.Drawing.Color.Black;
            this.lblRestriccionesTexto.Font = new System.Drawing.Font("Bahnschrift SemiBold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRestriccionesTexto.ForeColor = System.Drawing.Color.White;
            this.lblRestriccionesTexto.Location = new System.Drawing.Point(73, 386);
            this.lblRestriccionesTexto.Margin = new System.Windows.Forms.Padding(3);
            this.lblRestriccionesTexto.Name = "lblRestriccionesTexto";
            this.lblRestriccionesTexto.Size = new System.Drawing.Size(376, 48);
            this.lblRestriccionesTexto.TabIndex = 26;
            this.lblRestriccionesTexto.Text = "Restricciones PW";
            this.lblRestriccionesTexto.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmPrimerIngreso
            // 
            this.AcceptButton = this.btnCambiar;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(523, 527);
            this.ControlBox = false;
            this.Controls.Add(this.lblRestriccionesTexto);
            this.Controls.Add(this.pctOcultar2);
            this.Controls.Add(this.pctMostrar2);
            this.Controls.Add(this.pctOcultar);
            this.Controls.Add(this.pctMostrar);
            this.Controls.Add(this.lblLogin);
            this.Controls.Add(this.lblMensaje);
            this.Controls.Add(this.lblUsuario);
            this.Controls.Add(this.pctBordeInferior);
            this.Controls.Add(this.txtConfirmaPass);
            this.Controls.Add(this.pctLogo);
            this.Controls.Add(this.txtNuevaPass);
            this.Controls.Add(this.pctMinimize);
            this.Controls.Add(this.pctClose);
            this.Controls.Add(this.btnCambiar);
            this.Controls.Add(this.pctBorde);
            this.Controls.Add(this.pctFondo);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPrimerIngreso";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmRegistro";
            this.Load += new System.EventHandler(this.frmPrimerIngreso_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pctBordeInferior)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctMinimize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctBorde)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctFondo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctMostrar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctOcultar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctMostrar2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctOcultar2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pctBordeInferior;
        private System.Windows.Forms.TextBox txtConfirmaPass;
        private System.Windows.Forms.PictureBox pctLogo;
        private System.Windows.Forms.TextBox txtNuevaPass;
        private System.Windows.Forms.PictureBox pctMinimize;
        private System.Windows.Forms.PictureBox pctClose;
        private System.Windows.Forms.Button btnCambiar;
        private System.Windows.Forms.PictureBox pctBorde;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.Label lblMensaje;
        private System.Windows.Forms.PictureBox pctFondo;
        private System.Windows.Forms.Label lblLogin;
        private System.Windows.Forms.PictureBox pctMostrar;
        private System.Windows.Forms.PictureBox pctOcultar;
        private System.Windows.Forms.PictureBox pctMostrar2;
        private System.Windows.Forms.PictureBox pctOcultar2;
        private System.Windows.Forms.Label lblRestriccionesTexto;
    }
}