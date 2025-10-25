namespace Vista
{
    partial class frmCambioPass
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCambioPass));
            this.txtNuevaPass = new System.Windows.Forms.TextBox();
            this.pctLogo = new System.Windows.Forms.PictureBox();
            this.txtPassActual = new System.Windows.Forms.TextBox();
            this.btnCambiar = new System.Windows.Forms.Button();
            this.pctFondo = new System.Windows.Forms.PictureBox();
            this.txtConfirmaPass = new System.Windows.Forms.TextBox();
            this.lblUsuariocont = new System.Windows.Forms.Label();
            this.pctValidaciones = new System.Windows.Forms.PictureBox();
            this.pctMostrar2 = new System.Windows.Forms.PictureBox();
            this.pctOcultar2 = new System.Windows.Forms.PictureBox();
            this.pctOcultar3 = new System.Windows.Forms.PictureBox();
            this.pctMostrar3 = new System.Windows.Forms.PictureBox();
            this.pctOcultar = new System.Windows.Forms.PictureBox();
            this.pctMostrar = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pctLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctFondo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctValidaciones)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctMostrar2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctOcultar2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctOcultar3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctMostrar3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctOcultar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctMostrar)).BeginInit();
            this.SuspendLayout();
            // 
            // txtNuevaPass
            // 
            this.txtNuevaPass.Font = new System.Drawing.Font("Bahnschrift", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNuevaPass.Location = new System.Drawing.Point(103, 165);
            this.txtNuevaPass.MaxLength = 25;
            this.txtNuevaPass.Name = "txtNuevaPass";
            this.txtNuevaPass.Size = new System.Drawing.Size(185, 25);
            this.txtNuevaPass.TabIndex = 2;
            this.txtNuevaPass.Enter += new System.EventHandler(this.txtNuevaPass_Enter);
            this.txtNuevaPass.Leave += new System.EventHandler(this.txtNuevaPass_Leave);
            // 
            // pctLogo
            // 
            this.pctLogo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pctLogo.BackColor = System.Drawing.Color.Transparent;
            this.pctLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pctLogo.Image = ((System.Drawing.Image)(resources.GetObject("pctLogo.Image")));
            this.pctLogo.Location = new System.Drawing.Point(125, 15);
            this.pctLogo.Name = "pctLogo";
            this.pctLogo.Size = new System.Drawing.Size(150, 95);
            this.pctLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pctLogo.TabIndex = 21;
            this.pctLogo.TabStop = false;
            // 
            // txtPassActual
            // 
            this.txtPassActual.BackColor = System.Drawing.Color.White;
            this.txtPassActual.Font = new System.Drawing.Font("Bahnschrift", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassActual.Location = new System.Drawing.Point(103, 125);
            this.txtPassActual.MaxLength = 25;
            this.txtPassActual.Name = "txtPassActual";
            this.txtPassActual.Size = new System.Drawing.Size(185, 25);
            this.txtPassActual.TabIndex = 1;
            this.txtPassActual.Enter += new System.EventHandler(this.txtPassActual_Enter);
            this.txtPassActual.Leave += new System.EventHandler(this.txtPassActual_Leave);
            // 
            // btnCambiar
            // 
            this.btnCambiar.BackColor = System.Drawing.Color.White;
            this.btnCambiar.Font = new System.Drawing.Font("Bahnschrift", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCambiar.ForeColor = System.Drawing.Color.Black;
            this.btnCambiar.Location = new System.Drawing.Point(103, 260);
            this.btnCambiar.Margin = new System.Windows.Forms.Padding(4);
            this.btnCambiar.Name = "btnCambiar";
            this.btnCambiar.Size = new System.Drawing.Size(185, 30);
            this.btnCambiar.TabIndex = 4;
            this.btnCambiar.Text = "Cambiar";
            this.btnCambiar.UseVisualStyleBackColor = false;
            this.btnCambiar.Click += new System.EventHandler(this.btnCambiar_Click);
            // 
            // pctFondo
            // 
            this.pctFondo.BackgroundImage = global::Vista.Properties.Resources.WoodenPlankCyan;
            this.pctFondo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pctFondo.Location = new System.Drawing.Point(0, 0);
            this.pctFondo.Name = "pctFondo";
            this.pctFondo.Size = new System.Drawing.Size(400, 325);
            this.pctFondo.TabIndex = 23;
            this.pctFondo.TabStop = false;
            // 
            // txtConfirmaPass
            // 
            this.txtConfirmaPass.Font = new System.Drawing.Font("Bahnschrift", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConfirmaPass.Location = new System.Drawing.Point(103, 205);
            this.txtConfirmaPass.MaxLength = 25;
            this.txtConfirmaPass.Name = "txtConfirmaPass";
            this.txtConfirmaPass.Size = new System.Drawing.Size(185, 25);
            this.txtConfirmaPass.TabIndex = 3;
            this.txtConfirmaPass.Enter += new System.EventHandler(this.txtConfirmaPass_Enter);
            this.txtConfirmaPass.Leave += new System.EventHandler(this.txtConfirmaPass_Leave);
            // 
            // lblUsuariocont
            // 
            this.lblUsuariocont.Font = new System.Drawing.Font("Bahnschrift", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuariocont.ForeColor = System.Drawing.Color.White;
            this.lblUsuariocont.Location = new System.Drawing.Point(0, 305);
            this.lblUsuariocont.Name = "lblUsuariocont";
            this.lblUsuariocont.Size = new System.Drawing.Size(400, 20);
            this.lblUsuariocont.TabIndex = 30;
            this.lblUsuariocont.Text = "Usuario";
            this.lblUsuariocont.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pctValidaciones
            // 
            this.pctValidaciones.BackColor = System.Drawing.Color.Transparent;
            this.pctValidaciones.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pctValidaciones.Cursor = System.Windows.Forms.Cursors.Help;
            this.pctValidaciones.Image = ((System.Drawing.Image)(resources.GetObject("pctValidaciones.Image")));
            this.pctValidaciones.Location = new System.Drawing.Point(75, 127);
            this.pctValidaciones.Name = "pctValidaciones";
            this.pctValidaciones.Size = new System.Drawing.Size(20, 20);
            this.pctValidaciones.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pctValidaciones.TabIndex = 41;
            this.pctValidaciones.TabStop = false;
            // 
            // pctMostrar2
            // 
            this.pctMostrar2.BackColor = System.Drawing.Color.Transparent;
            this.pctMostrar2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pctMostrar2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pctMostrar2.Image = ((System.Drawing.Image)(resources.GetObject("pctMostrar2.Image")));
            this.pctMostrar2.Location = new System.Drawing.Point(294, 159);
            this.pctMostrar2.Name = "pctMostrar2";
            this.pctMostrar2.Size = new System.Drawing.Size(35, 35);
            this.pctMostrar2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pctMostrar2.TabIndex = 42;
            this.pctMostrar2.TabStop = false;
            // 
            // pctOcultar2
            // 
            this.pctOcultar2.BackColor = System.Drawing.Color.Transparent;
            this.pctOcultar2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pctOcultar2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pctOcultar2.Image = ((System.Drawing.Image)(resources.GetObject("pctOcultar2.Image")));
            this.pctOcultar2.Location = new System.Drawing.Point(294, 159);
            this.pctOcultar2.Name = "pctOcultar2";
            this.pctOcultar2.Size = new System.Drawing.Size(35, 35);
            this.pctOcultar2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pctOcultar2.TabIndex = 43;
            this.pctOcultar2.TabStop = false;
            // 
            // pctOcultar3
            // 
            this.pctOcultar3.BackColor = System.Drawing.Color.Transparent;
            this.pctOcultar3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pctOcultar3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pctOcultar3.Image = ((System.Drawing.Image)(resources.GetObject("pctOcultar3.Image")));
            this.pctOcultar3.Location = new System.Drawing.Point(294, 199);
            this.pctOcultar3.Name = "pctOcultar3";
            this.pctOcultar3.Size = new System.Drawing.Size(35, 35);
            this.pctOcultar3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pctOcultar3.TabIndex = 45;
            this.pctOcultar3.TabStop = false;
            // 
            // pctMostrar3
            // 
            this.pctMostrar3.BackColor = System.Drawing.Color.Transparent;
            this.pctMostrar3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pctMostrar3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pctMostrar3.Image = ((System.Drawing.Image)(resources.GetObject("pctMostrar3.Image")));
            this.pctMostrar3.Location = new System.Drawing.Point(294, 199);
            this.pctMostrar3.Name = "pctMostrar3";
            this.pctMostrar3.Size = new System.Drawing.Size(35, 35);
            this.pctMostrar3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pctMostrar3.TabIndex = 44;
            this.pctMostrar3.TabStop = false;
            // 
            // pctOcultar
            // 
            this.pctOcultar.BackColor = System.Drawing.Color.Transparent;
            this.pctOcultar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pctOcultar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pctOcultar.Image = ((System.Drawing.Image)(resources.GetObject("pctOcultar.Image")));
            this.pctOcultar.Location = new System.Drawing.Point(294, 119);
            this.pctOcultar.Name = "pctOcultar";
            this.pctOcultar.Size = new System.Drawing.Size(35, 35);
            this.pctOcultar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pctOcultar.TabIndex = 47;
            this.pctOcultar.TabStop = false;
            // 
            // pctMostrar
            // 
            this.pctMostrar.BackColor = System.Drawing.Color.Transparent;
            this.pctMostrar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pctMostrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pctMostrar.Image = ((System.Drawing.Image)(resources.GetObject("pctMostrar.Image")));
            this.pctMostrar.Location = new System.Drawing.Point(294, 119);
            this.pctMostrar.Name = "pctMostrar";
            this.pctMostrar.Size = new System.Drawing.Size(35, 35);
            this.pctMostrar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pctMostrar.TabIndex = 46;
            this.pctMostrar.TabStop = false;
            // 
            // frmCambioPass
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(400, 325);
            this.ControlBox = false;
            this.Controls.Add(this.pctOcultar);
            this.Controls.Add(this.pctMostrar);
            this.Controls.Add(this.pctOcultar3);
            this.Controls.Add(this.pctMostrar3);
            this.Controls.Add(this.pctOcultar2);
            this.Controls.Add(this.pctMostrar2);
            this.Controls.Add(this.pctValidaciones);
            this.Controls.Add(this.lblUsuariocont);
            this.Controls.Add(this.txtConfirmaPass);
            this.Controls.Add(this.txtNuevaPass);
            this.Controls.Add(this.pctLogo);
            this.Controls.Add(this.txtPassActual);
            this.Controls.Add(this.btnCambiar);
            this.Controls.Add(this.pctFondo);
            this.Font = new System.Drawing.Font("Bahnschrift", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCambioPass";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmRecupero";
            this.Load += new System.EventHandler(this.frmCambioPass_Load);
            this.Shown += new System.EventHandler(this.frmCambioPass_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.pctLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctFondo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctValidaciones)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctMostrar2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctOcultar2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctOcultar3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctMostrar3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctOcultar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctMostrar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtNuevaPass;
        private System.Windows.Forms.PictureBox pctLogo;
        private System.Windows.Forms.TextBox txtPassActual;
        private System.Windows.Forms.Button btnCambiar;
        private System.Windows.Forms.PictureBox pctFondo;
        private System.Windows.Forms.TextBox txtConfirmaPass;
        private System.Windows.Forms.Label lblUsuariocont;
        private System.Windows.Forms.PictureBox pctValidaciones;
        private System.Windows.Forms.PictureBox pctMostrar2;
        private System.Windows.Forms.PictureBox pctOcultar2;
        private System.Windows.Forms.PictureBox pctOcultar3;
        private System.Windows.Forms.PictureBox pctMostrar3;
        private System.Windows.Forms.PictureBox pctOcultar;
        private System.Windows.Forms.PictureBox pctMostrar;
    }
}