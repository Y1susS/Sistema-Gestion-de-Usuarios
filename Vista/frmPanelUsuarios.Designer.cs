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
            this.btnGestionUsuarios = new System.Windows.Forms.Button();
            this.btnGestionPermisos = new System.Windows.Forms.Button();
            this.btnGestionContraseñas = new System.Windows.Forms.Button();
            this.lblAdministrador = new System.Windows.Forms.Label();
            this.btnRegistroClientes = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnPreguntas = new System.Windows.Forms.Button();
            this.btnCambiarContrasena = new System.Windows.Forms.Button();
            this.lblDiasRestantesContrasena = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnGestionUsuarios
            // 
            this.btnGestionUsuarios.Location = new System.Drawing.Point(321, 169);
            this.btnGestionUsuarios.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnGestionUsuarios.Name = "btnGestionUsuarios";
            this.btnGestionUsuarios.Size = new System.Drawing.Size(225, 55);
            this.btnGestionUsuarios.TabIndex = 1;
            this.btnGestionUsuarios.Text = "Gestionar usuarios";
            this.btnGestionUsuarios.UseVisualStyleBackColor = true;
            this.btnGestionUsuarios.Click += new System.EventHandler(this.btnGestionUsuarios_Click);
            // 
            // btnGestionPermisos
            // 
            this.btnGestionPermisos.Location = new System.Drawing.Point(321, 255);
            this.btnGestionPermisos.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnGestionPermisos.Name = "btnGestionPermisos";
            this.btnGestionPermisos.Size = new System.Drawing.Size(225, 55);
            this.btnGestionPermisos.TabIndex = 2;
            this.btnGestionPermisos.Text = "Gestionar permisos";
            this.btnGestionPermisos.UseVisualStyleBackColor = true;
            this.btnGestionPermisos.Click += new System.EventHandler(this.btnGestionPermisos_Click);
            // 
            // btnGestionContraseñas
            // 
            this.btnGestionContraseñas.Location = new System.Drawing.Point(321, 346);
            this.btnGestionContraseñas.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnGestionContraseñas.Name = "btnGestionContraseñas";
            this.btnGestionContraseñas.Size = new System.Drawing.Size(225, 55);
            this.btnGestionContraseñas.TabIndex = 3;
            this.btnGestionContraseñas.Text = "Gestion Contraseñas";
            this.btnGestionContraseñas.UseVisualStyleBackColor = true;
            this.btnGestionContraseñas.Click += new System.EventHandler(this.btnGestionContraseñas_Click);
            // 
            // lblAdministrador
            // 
            this.lblAdministrador.AutoSize = true;
            this.lblAdministrador.Location = new System.Drawing.Point(364, 125);
            this.lblAdministrador.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAdministrador.Name = "lblAdministrador";
            this.lblAdministrador.Size = new System.Drawing.Size(151, 20);
            this.lblAdministrador.TabIndex = 3;
            this.lblAdministrador.Text = "Menu Administrador";
            // 
            // btnRegistroClientes
            // 
            this.btnRegistroClientes.Location = new System.Drawing.Point(634, 169);
            this.btnRegistroClientes.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnRegistroClientes.Name = "btnRegistroClientes";
            this.btnRegistroClientes.Size = new System.Drawing.Size(225, 55);
            this.btnRegistroClientes.TabIndex = 4;
            this.btnRegistroClientes.Text = "Registro de Clientes";
            this.btnRegistroClientes.UseVisualStyleBackColor = true;
            this.btnRegistroClientes.Click += new System.EventHandler(this.btnRegistroClientes_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(634, 492);
            this.btnSalir.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(225, 55);
            this.btnSalir.TabIndex = 7;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnPreguntas
            // 
            this.btnPreguntas.Location = new System.Drawing.Point(634, 346);
            this.btnPreguntas.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnPreguntas.Name = "btnPreguntas";
            this.btnPreguntas.Size = new System.Drawing.Size(225, 55);
            this.btnPreguntas.TabIndex = 6;
            this.btnPreguntas.Text = "Preguntas de Seguridad";
            this.btnPreguntas.UseVisualStyleBackColor = true;
            this.btnPreguntas.Click += new System.EventHandler(this.btnPreguntas_Click);
            // 
            // btnCambiarContrasena
            // 
            this.btnCambiarContrasena.Location = new System.Drawing.Point(634, 255);
            this.btnCambiarContrasena.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCambiarContrasena.Name = "btnCambiarContrasena";
            this.btnCambiarContrasena.Size = new System.Drawing.Size(225, 55);
            this.btnCambiarContrasena.TabIndex = 5;
            this.btnCambiarContrasena.Text = "Cambiar Contraseña";
            this.btnCambiarContrasena.UseVisualStyleBackColor = true;
            this.btnCambiarContrasena.Click += new System.EventHandler(this.btnCambiarContrasena_Click);
            // 
            // lblDiasRestantesContrasena
            // 
            this.lblDiasRestantesContrasena.AutoSize = true;
            this.lblDiasRestantesContrasena.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDiasRestantesContrasena.Location = new System.Drawing.Point(35, 636);
            this.lblDiasRestantesContrasena.Name = "lblDiasRestantesContrasena";
            this.lblDiasRestantesContrasena.Size = new System.Drawing.Size(185, 26);
            this.lblDiasRestantesContrasena.TabIndex = 8;
            this.lblDiasRestantesContrasena.Text = "Dias cambio pass";
            // 
            // frmPanelUsuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 692);
            this.Controls.Add(this.lblDiasRestantesContrasena);
            this.Controls.Add(this.btnCambiarContrasena);
            this.Controls.Add(this.btnPreguntas);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnRegistroClientes);
            this.Controls.Add(this.lblAdministrador);
            this.Controls.Add(this.btnGestionContraseñas);
            this.Controls.Add(this.btnGestionPermisos);
            this.Controls.Add(this.btnGestionUsuarios);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmPanelUsuarios";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.frmPanelUsuarios_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGestionUsuarios;
        private System.Windows.Forms.Button btnGestionPermisos;
        private System.Windows.Forms.Button btnGestionContraseñas;
        private System.Windows.Forms.Label lblAdministrador;
        private System.Windows.Forms.Button btnRegistroClientes;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnPreguntas;
        private System.Windows.Forms.Button btnCambiarContrasena;
        private System.Windows.Forms.Label lblDiasRestantesContrasena;
    }
}