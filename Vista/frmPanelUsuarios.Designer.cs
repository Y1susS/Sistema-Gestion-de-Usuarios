namespace Vista
{
    partial class frmPanelUsuarios
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPanelUsuarios));
            this.btnGestionUsuarios = new System.Windows.Forms.Button();
            this.btnGestionPermisos = new System.Windows.Forms.Button();
            this.btnGestionValidaciones = new System.Windows.Forms.Button();
            this.btnRegistroClientes = new System.Windows.Forms.Button();
            this.btnPreguntas = new System.Windows.Forms.Button();
            this.btnCambiarContrasena = new System.Windows.Forms.Button();
            this.lblDiasRestantesContrasena = new System.Windows.Forms.Label();
            this.pctClose = new System.Windows.Forms.PictureBox();
            this.pctMinimize = new System.Windows.Forms.PictureBox();
            this.pctFondo = new System.Windows.Forms.PictureBox();
            this.pctBorde = new System.Windows.Forms.PictureBox();
            this.lblAdministrador = new System.Windows.Forms.Label();
            this.pctBordeInferior = new System.Windows.Forms.PictureBox();
            this.pctLogo = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pctClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctMinimize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctFondo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctBorde)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctBordeInferior)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGestionUsuarios
            // 
            this.btnGestionUsuarios.Font = new System.Drawing.Font("Bahnschrift", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGestionUsuarios.Location = new System.Drawing.Point(17, 187);
            this.btnGestionUsuarios.Name = "btnGestionUsuarios";
            this.btnGestionUsuarios.Size = new System.Drawing.Size(175, 35);
            this.btnGestionUsuarios.TabIndex = 1;
            this.btnGestionUsuarios.Text = "Gestionar Usuarios";
            this.btnGestionUsuarios.UseVisualStyleBackColor = true;
            this.btnGestionUsuarios.Click += new System.EventHandler(this.btnGestionUsuarios_Click);
            // 
            // btnGestionPermisos
            // 
            this.btnGestionPermisos.Font = new System.Drawing.Font("Bahnschrift", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGestionPermisos.Location = new System.Drawing.Point(17, 237);
            this.btnGestionPermisos.Name = "btnGestionPermisos";
            this.btnGestionPermisos.Size = new System.Drawing.Size(175, 35);
            this.btnGestionPermisos.TabIndex = 2;
            this.btnGestionPermisos.Text = "Gestionar Permisos";
            this.btnGestionPermisos.UseVisualStyleBackColor = true;
            this.btnGestionPermisos.Click += new System.EventHandler(this.btnGestionPermisos_Click);
            // 
            // btnGestionValidaciones
            // 
            this.btnGestionValidaciones.Font = new System.Drawing.Font("Bahnschrift", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGestionValidaciones.Location = new System.Drawing.Point(17, 287);
            this.btnGestionValidaciones.Name = "btnGestionValidaciones";
            this.btnGestionValidaciones.Size = new System.Drawing.Size(175, 35);
            this.btnGestionValidaciones.TabIndex = 3;
            this.btnGestionValidaciones.Text = "Gestionar Validaciones";
            this.btnGestionValidaciones.UseVisualStyleBackColor = true;
            this.btnGestionValidaciones.Click += new System.EventHandler(this.btnGestionContraseñas_Click);
            // 
            // btnRegistroClientes
            // 
            this.btnRegistroClientes.Font = new System.Drawing.Font("Bahnschrift", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegistroClientes.Location = new System.Drawing.Point(209, 187);
            this.btnRegistroClientes.Name = "btnRegistroClientes";
            this.btnRegistroClientes.Size = new System.Drawing.Size(175, 35);
            this.btnRegistroClientes.TabIndex = 4;
            this.btnRegistroClientes.Text = "Registro de Clientes";
            this.btnRegistroClientes.UseVisualStyleBackColor = true;
            this.btnRegistroClientes.Click += new System.EventHandler(this.btnRegistroClientes_Click);
            // 
            // btnPreguntas
            // 
            this.btnPreguntas.Font = new System.Drawing.Font("Bahnschrift", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPreguntas.Location = new System.Drawing.Point(209, 287);
            this.btnPreguntas.Name = "btnPreguntas";
            this.btnPreguntas.Size = new System.Drawing.Size(175, 35);
            this.btnPreguntas.TabIndex = 6;
            this.btnPreguntas.Text = "Preguntas de Seguridad";
            this.btnPreguntas.UseVisualStyleBackColor = true;
            this.btnPreguntas.Click += new System.EventHandler(this.btnPreguntas_Click);
            // 
            // btnCambiarContrasena
            // 
            this.btnCambiarContrasena.Font = new System.Drawing.Font("Bahnschrift", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCambiarContrasena.Location = new System.Drawing.Point(209, 237);
            this.btnCambiarContrasena.Name = "btnCambiarContrasena";
            this.btnCambiarContrasena.Size = new System.Drawing.Size(175, 35);
            this.btnCambiarContrasena.TabIndex = 5;
            this.btnCambiarContrasena.Text = "Cambiar Contraseña";
            this.btnCambiarContrasena.UseVisualStyleBackColor = true;
            this.btnCambiarContrasena.Click += new System.EventHandler(this.btnCambiarContrasena_Click);
            // 
            // lblDiasRestantesContrasena
            // 
            this.lblDiasRestantesContrasena.BackColor = System.Drawing.Color.Transparent;
            this.lblDiasRestantesContrasena.Font = new System.Drawing.Font("Bahnschrift", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDiasRestantesContrasena.ForeColor = System.Drawing.Color.White;
            this.lblDiasRestantesContrasena.Location = new System.Drawing.Point(11, 339);
            this.lblDiasRestantesContrasena.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDiasRestantesContrasena.Name = "lblDiasRestantesContrasena";
            this.lblDiasRestantesContrasena.Size = new System.Drawing.Size(378, 22);
            this.lblDiasRestantesContrasena.TabIndex = 8;
            this.lblDiasRestantesContrasena.Text = "Dias Restantes";
            this.lblDiasRestantesContrasena.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.pctClose.TabIndex = 19;
            this.pctClose.TabStop = false;
            this.pctClose.Click += new System.EventHandler(this.pctClose_Click);
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
            this.pctMinimize.TabIndex = 21;
            this.pctMinimize.TabStop = false;
            this.pctMinimize.Click += new System.EventHandler(this.pctMinimize_Click);
            // 
            // pctFondo
            // 
            this.pctFondo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pctFondo.BackgroundImage")));
            this.pctFondo.Location = new System.Drawing.Point(0, 0);
            this.pctFondo.Name = "pctFondo";
            this.pctFondo.Size = new System.Drawing.Size(400, 400);
            this.pctFondo.TabIndex = 22;
            this.pctFondo.TabStop = false;
            // 
            // pctBorde
            // 
            this.pctBorde.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(40)))));
            this.pctBorde.Location = new System.Drawing.Point(-2, 0);
            this.pctBorde.Name = "pctBorde";
            this.pctBorde.Size = new System.Drawing.Size(402, 44);
            this.pctBorde.TabIndex = 23;
            this.pctBorde.TabStop = false;
            // 
            // lblAdministrador
            // 
            this.lblAdministrador.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(40)))));
            this.lblAdministrador.Font = new System.Drawing.Font("Bahnschrift", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAdministrador.ForeColor = System.Drawing.Color.White;
            this.lblAdministrador.Location = new System.Drawing.Point(48, 10);
            this.lblAdministrador.Name = "lblAdministrador";
            this.lblAdministrador.Size = new System.Drawing.Size(303, 24);
            this.lblAdministrador.TabIndex = 3;
            this.lblAdministrador.Text = "Menú de Administrador";
            this.lblAdministrador.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pctBordeInferior
            // 
            this.pctBordeInferior.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(40)))));
            this.pctBordeInferior.Location = new System.Drawing.Point(-2, 378);
            this.pctBordeInferior.Name = "pctBordeInferior";
            this.pctBordeInferior.Size = new System.Drawing.Size(402, 22);
            this.pctBordeInferior.TabIndex = 24;
            this.pctBordeInferior.TabStop = false;
            // 
            // pctLogo
            // 
            this.pctLogo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pctLogo.BackColor = System.Drawing.Color.Transparent;
            this.pctLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pctLogo.Image = ((System.Drawing.Image)(resources.GetObject("pctLogo.Image")));
            this.pctLogo.Location = new System.Drawing.Point(124, 68);
            this.pctLogo.Name = "pctLogo";
            this.pctLogo.Size = new System.Drawing.Size(150, 95);
            this.pctLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pctLogo.TabIndex = 25;
            this.pctLogo.TabStop = false;
            // 
            // frmPanelUsuarios
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(400, 400);
            this.Controls.Add(this.pctLogo);
            this.Controls.Add(this.pctBordeInferior);
            this.Controls.Add(this.pctMinimize);
            this.Controls.Add(this.pctClose);
            this.Controls.Add(this.lblDiasRestantesContrasena);
            this.Controls.Add(this.btnCambiarContrasena);
            this.Controls.Add(this.btnPreguntas);
            this.Controls.Add(this.btnRegistroClientes);
            this.Controls.Add(this.lblAdministrador);
            this.Controls.Add(this.btnGestionValidaciones);
            this.Controls.Add(this.btnGestionPermisos);
            this.Controls.Add(this.btnGestionUsuarios);
            this.Controls.Add(this.pctBorde);
            this.Controls.Add(this.pctFondo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmPanelUsuarios";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.frmPanelUsuarios_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pctClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctMinimize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctFondo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctBorde)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctBordeInferior)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGestionUsuarios;
        private System.Windows.Forms.Button btnGestionPermisos;
        private System.Windows.Forms.Button btnGestionValidaciones;
        private System.Windows.Forms.Button btnRegistroClientes;
        private System.Windows.Forms.Button btnPreguntas;
        private System.Windows.Forms.Button btnCambiarContrasena;
        private System.Windows.Forms.Label lblDiasRestantesContrasena;
        private System.Windows.Forms.PictureBox pctClose;
        private System.Windows.Forms.PictureBox pctMinimize;
        private System.Windows.Forms.PictureBox pctFondo;
        private System.Windows.Forms.PictureBox pctBorde;
        private System.Windows.Forms.Label lblAdministrador;
        private System.Windows.Forms.PictureBox pctBordeInferior;
        private System.Windows.Forms.PictureBox pctLogo;
    }
}