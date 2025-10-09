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
            this.txtConfirmaPass = new System.Windows.Forms.TextBox();
            this.pctLogo = new System.Windows.Forms.PictureBox();
            this.txtNuevaPass = new System.Windows.Forms.TextBox();
            this.pctMinimize = new System.Windows.Forms.PictureBox();
            this.pctClose = new System.Windows.Forms.PictureBox();
            this.btnCambiar = new System.Windows.Forms.Button();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.lblMensaje = new System.Windows.Forms.Label();
            this.pctFondo = new System.Windows.Forms.PictureBox();
            this.lblPrimerIngreso = new System.Windows.Forms.Label();
            this.pctMostrar = new System.Windows.Forms.PictureBox();
            this.pctOcultar = new System.Windows.Forms.PictureBox();
            this.pctMostrar2 = new System.Windows.Forms.PictureBox();
            this.pctOcultar2 = new System.Windows.Forms.PictureBox();
            this.pnlBorde = new System.Windows.Forms.Panel();
            this.pnlBordeInferior = new System.Windows.Forms.Panel();
            this.pctValidaciones = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pctLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctMinimize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctFondo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctMostrar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctOcultar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctMostrar2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctOcultar2)).BeginInit();
            this.pnlBorde.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctValidaciones)).BeginInit();
            this.SuspendLayout();
            // 
            // txtConfirmaPass
            // 
            this.txtConfirmaPass.Font = new System.Drawing.Font("Bahnschrift", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConfirmaPass.Location = new System.Drawing.Point(107, 269);
            this.txtConfirmaPass.MaxLength = 25;
            this.txtConfirmaPass.Name = "txtConfirmaPass";
            this.txtConfirmaPass.Size = new System.Drawing.Size(185, 25);
            this.txtConfirmaPass.TabIndex = 3;
            this.txtConfirmaPass.Enter += new System.EventHandler(this.txtConfirmaPass_Enter);
            this.txtConfirmaPass.Leave += new System.EventHandler(this.txtConfirmaPass_Leave);
            // 
            // pctLogo
            // 
            this.pctLogo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pctLogo.BackColor = System.Drawing.Color.Transparent;
            this.pctLogo.Image = ((System.Drawing.Image)(resources.GetObject("pctLogo.Image")));
            this.pctLogo.Location = new System.Drawing.Point(126, 56);
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
            this.txtNuevaPass.Location = new System.Drawing.Point(107, 219);
            this.txtNuevaPass.MaxLength = 25;
            this.txtNuevaPass.Name = "txtNuevaPass";
            this.txtNuevaPass.Size = new System.Drawing.Size(185, 25);
            this.txtNuevaPass.TabIndex = 2;
            this.txtNuevaPass.Enter += new System.EventHandler(this.txtNuevaPass_Enter);
            this.txtNuevaPass.Leave += new System.EventHandler(this.txtNuevaPass_Leave);
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
            this.pctMinimize.TabIndex = 20;
            this.pctMinimize.TabStop = false;
            this.pctMinimize.Click += new System.EventHandler(this.pctMinimize_Click_1);
            // 
            // pctClose
            // 
            this.pctClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(40)))));
            this.pctClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pctClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.pctClose.Image = ((System.Drawing.Image)(resources.GetObject("pctClose.Image")));
            this.pctClose.Location = new System.Drawing.Point(360, 0);
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
            this.btnCambiar.Font = new System.Drawing.Font("Bahnschrift", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCambiar.ForeColor = System.Drawing.Color.Black;
            this.btnCambiar.Location = new System.Drawing.Point(107, 318);
            this.btnCambiar.Margin = new System.Windows.Forms.Padding(4);
            this.btnCambiar.Name = "btnCambiar";
            this.btnCambiar.Size = new System.Drawing.Size(185, 30);
            this.btnCambiar.TabIndex = 3;
            this.btnCambiar.Text = "Cambiar";
            this.btnCambiar.UseVisualStyleBackColor = false;
            this.btnCambiar.Click += new System.EventHandler(this.btnCambiar_Click);
            // 
            // lblUsuario
            // 
            this.lblUsuario.Font = new System.Drawing.Font("Bahnschrift", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuario.ForeColor = System.Drawing.Color.White;
            this.lblUsuario.Location = new System.Drawing.Point(0, 360);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(400, 18);
            this.lblUsuario.TabIndex = 25;
            this.lblUsuario.Text = "Usuario";
            this.lblUsuario.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMensaje
            // 
            this.lblMensaje.Font = new System.Drawing.Font("Bahnschrift", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMensaje.ForeColor = System.Drawing.Color.White;
            this.lblMensaje.Location = new System.Drawing.Point(0, 164);
            this.lblMensaje.Name = "lblMensaje";
            this.lblMensaje.Size = new System.Drawing.Size(400, 40);
            this.lblMensaje.TabIndex = 26;
            this.lblMensaje.Text = "Mensaje";
            this.lblMensaje.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pctFondo
            // 
            this.pctFondo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pctFondo.BackgroundImage")));
            this.pctFondo.Location = new System.Drawing.Point(0, 0);
            this.pctFondo.Name = "pctFondo";
            this.pctFondo.Size = new System.Drawing.Size(400, 400);
            this.pctFondo.TabIndex = 27;
            this.pctFondo.TabStop = false;
            // 
            // lblPrimerIngreso
            // 
            this.lblPrimerIngreso.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(40)))));
            this.lblPrimerIngreso.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPrimerIngreso.Font = new System.Drawing.Font("Bahnschrift", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrimerIngreso.ForeColor = System.Drawing.Color.White;
            this.lblPrimerIngreso.Location = new System.Drawing.Point(40, 0);
            this.lblPrimerIngreso.Name = "lblPrimerIngreso";
            this.lblPrimerIngreso.Size = new System.Drawing.Size(320, 40);
            this.lblPrimerIngreso.TabIndex = 33;
            this.lblPrimerIngreso.Text = "Primer Ingreso";
            this.lblPrimerIngreso.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pctMostrar
            // 
            this.pctMostrar.BackColor = System.Drawing.Color.Transparent;
            this.pctMostrar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pctMostrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pctMostrar.Image = ((System.Drawing.Image)(resources.GetObject("pctMostrar.Image")));
            this.pctMostrar.Location = new System.Drawing.Point(299, 213);
            this.pctMostrar.Name = "pctMostrar";
            this.pctMostrar.Size = new System.Drawing.Size(35, 35);
            this.pctMostrar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pctMostrar.TabIndex = 34;
            this.pctMostrar.TabStop = false;
            // 
            // pctOcultar
            // 
            this.pctOcultar.BackColor = System.Drawing.Color.Transparent;
            this.pctOcultar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pctOcultar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pctOcultar.Image = ((System.Drawing.Image)(resources.GetObject("pctOcultar.Image")));
            this.pctOcultar.Location = new System.Drawing.Point(299, 213);
            this.pctOcultar.Name = "pctOcultar";
            this.pctOcultar.Size = new System.Drawing.Size(35, 35);
            this.pctOcultar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pctOcultar.TabIndex = 35;
            this.pctOcultar.TabStop = false;
            // 
            // pctMostrar2
            // 
            this.pctMostrar2.BackColor = System.Drawing.Color.Transparent;
            this.pctMostrar2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pctMostrar2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pctMostrar2.Image = ((System.Drawing.Image)(resources.GetObject("pctMostrar2.Image")));
            this.pctMostrar2.Location = new System.Drawing.Point(299, 263);
            this.pctMostrar2.Name = "pctMostrar2";
            this.pctMostrar2.Size = new System.Drawing.Size(35, 35);
            this.pctMostrar2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pctMostrar2.TabIndex = 36;
            this.pctMostrar2.TabStop = false;
            // 
            // pctOcultar2
            // 
            this.pctOcultar2.BackColor = System.Drawing.Color.Transparent;
            this.pctOcultar2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pctOcultar2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pctOcultar2.Image = ((System.Drawing.Image)(resources.GetObject("pctOcultar2.Image")));
            this.pctOcultar2.Location = new System.Drawing.Point(299, 263);
            this.pctOcultar2.Name = "pctOcultar2";
            this.pctOcultar2.Size = new System.Drawing.Size(35, 35);
            this.pctOcultar2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pctOcultar2.TabIndex = 37;
            this.pctOcultar2.TabStop = false;
            // 
            // pnlBorde
            // 
            this.pnlBorde.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(40)))));
            this.pnlBorde.Controls.Add(this.lblPrimerIngreso);
            this.pnlBorde.Controls.Add(this.pctClose);
            this.pnlBorde.Controls.Add(this.pctMinimize);
            this.pnlBorde.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBorde.Location = new System.Drawing.Point(0, 0);
            this.pnlBorde.Name = "pnlBorde";
            this.pnlBorde.Size = new System.Drawing.Size(400, 40);
            this.pnlBorde.TabIndex = 38;
            // 
            // pnlBordeInferior
            // 
            this.pnlBordeInferior.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(40)))));
            this.pnlBordeInferior.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBordeInferior.Location = new System.Drawing.Point(0, 380);
            this.pnlBordeInferior.Name = "pnlBordeInferior";
            this.pnlBordeInferior.Size = new System.Drawing.Size(400, 20);
            this.pnlBordeInferior.TabIndex = 39;
            // 
            // pctValidaciones
            // 
            this.pctValidaciones.BackColor = System.Drawing.Color.Transparent;
            this.pctValidaciones.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pctValidaciones.Cursor = System.Windows.Forms.Cursors.Help;
            this.pctValidaciones.Image = ((System.Drawing.Image)(resources.GetObject("pctValidaciones.Image")));
            this.pctValidaciones.Location = new System.Drawing.Point(79, 221);
            this.pctValidaciones.Name = "pctValidaciones";
            this.pctValidaciones.Size = new System.Drawing.Size(20, 20);
            this.pctValidaciones.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pctValidaciones.TabIndex = 40;
            this.pctValidaciones.TabStop = false;
            // 
            // frmPrimerIngreso
            // 
            this.AcceptButton = this.btnCambiar;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(400, 400);
            this.ControlBox = false;
            this.Controls.Add(this.lblUsuario);
            this.Controls.Add(this.pctValidaciones);
            this.Controls.Add(this.pnlBordeInferior);
            this.Controls.Add(this.pnlBorde);
            this.Controls.Add(this.pctOcultar2);
            this.Controls.Add(this.pctMostrar2);
            this.Controls.Add(this.pctOcultar);
            this.Controls.Add(this.pctMostrar);
            this.Controls.Add(this.lblMensaje);
            this.Controls.Add(this.txtConfirmaPass);
            this.Controls.Add(this.pctLogo);
            this.Controls.Add(this.txtNuevaPass);
            this.Controls.Add(this.btnCambiar);
            this.Controls.Add(this.pctFondo);
            this.Font = new System.Drawing.Font("Bahnschrift", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPrimerIngreso";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmRegistro";
            this.Load += new System.EventHandler(this.frmPrimerIngreso_Load);
            this.Shown += new System.EventHandler(this.frmPrimerIngreso_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.pctLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctMinimize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctFondo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctMostrar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctOcultar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctMostrar2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctOcultar2)).EndInit();
            this.pnlBorde.ResumeLayout(false);
            this.pnlBorde.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctValidaciones)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtConfirmaPass;
        private System.Windows.Forms.PictureBox pctLogo;
        private System.Windows.Forms.TextBox txtNuevaPass;
        private System.Windows.Forms.PictureBox pctMinimize;
        private System.Windows.Forms.PictureBox pctClose;
        private System.Windows.Forms.Button btnCambiar;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.Label lblMensaje;
        private System.Windows.Forms.PictureBox pctFondo;
        private System.Windows.Forms.Label lblPrimerIngreso;
        private System.Windows.Forms.PictureBox pctMostrar;
        private System.Windows.Forms.PictureBox pctOcultar;
        private System.Windows.Forms.PictureBox pctMostrar2;
        private System.Windows.Forms.PictureBox pctOcultar2;
        private System.Windows.Forms.Panel pnlBorde;
        private System.Windows.Forms.Panel pnlBordeInferior;
        private System.Windows.Forms.PictureBox pctValidaciones;
    }
}