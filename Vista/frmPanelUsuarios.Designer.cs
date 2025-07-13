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
            this.SuspendLayout();
            // 
            // btnGestionUsuarios
            // 
            this.btnGestionUsuarios.Location = new System.Drawing.Point(214, 110);
            this.btnGestionUsuarios.Name = "btnGestionUsuarios";
            this.btnGestionUsuarios.Size = new System.Drawing.Size(150, 36);
            this.btnGestionUsuarios.TabIndex = 0;
            this.btnGestionUsuarios.Text = "Gestionar usuarios";
            this.btnGestionUsuarios.UseVisualStyleBackColor = true;
            this.btnGestionUsuarios.Click += new System.EventHandler(this.btnGestionUsuarios_Click);
            // 
            // btnGestionPermisos
            // 
            this.btnGestionPermisos.Location = new System.Drawing.Point(214, 166);
            this.btnGestionPermisos.Name = "btnGestionPermisos";
            this.btnGestionPermisos.Size = new System.Drawing.Size(150, 36);
            this.btnGestionPermisos.TabIndex = 1;
            this.btnGestionPermisos.Text = "Gestionar permisos";
            this.btnGestionPermisos.UseVisualStyleBackColor = true;
            this.btnGestionPermisos.Click += new System.EventHandler(this.btnGestionPermisos_Click);
            // 
            // btnGestionContraseñas
            // 
            this.btnGestionContraseñas.Location = new System.Drawing.Point(214, 225);
            this.btnGestionContraseñas.Name = "btnGestionContraseñas";
            this.btnGestionContraseñas.Size = new System.Drawing.Size(150, 36);
            this.btnGestionContraseñas.TabIndex = 2;
            this.btnGestionContraseñas.Text = "Gestion Contraseñas";
            this.btnGestionContraseñas.UseVisualStyleBackColor = true;
            this.btnGestionContraseñas.Click += new System.EventHandler(this.btnGestionContraseñas_Click);
            // 
            // lblAdministrador
            // 
            this.lblAdministrador.AutoSize = true;
            this.lblAdministrador.Location = new System.Drawing.Point(243, 81);
            this.lblAdministrador.Name = "lblAdministrador";
            this.lblAdministrador.Size = new System.Drawing.Size(100, 13);
            this.lblAdministrador.TabIndex = 3;
            this.lblAdministrador.Text = "Menu Administrador";
            // 
            // btnRegistroClientes
            // 
            this.btnRegistroClientes.Location = new System.Drawing.Point(423, 110);
            this.btnRegistroClientes.Name = "btnRegistroClientes";
            this.btnRegistroClientes.Size = new System.Drawing.Size(150, 36);
            this.btnRegistroClientes.TabIndex = 4;
            this.btnRegistroClientes.Text = "Registro de Clientes";
            this.btnRegistroClientes.UseVisualStyleBackColor = true;
            this.btnRegistroClientes.Click += new System.EventHandler(this.btnRegistroClientes_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(423, 320);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(150, 36);
            this.btnSalir.TabIndex = 5;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnPreguntas
            // 
            this.btnPreguntas.Location = new System.Drawing.Point(423, 225);
            this.btnPreguntas.Name = "btnPreguntas";
            this.btnPreguntas.Size = new System.Drawing.Size(150, 36);
            this.btnPreguntas.TabIndex = 6;
            this.btnPreguntas.Text = "Preguntas de Seguridad";
            this.btnPreguntas.UseVisualStyleBackColor = true;
            this.btnPreguntas.Click += new System.EventHandler(this.btnPreguntas_Click);
            // 
            // btnCambiarContrasena
            // 
            this.btnCambiarContrasena.Location = new System.Drawing.Point(423, 166);
            this.btnCambiarContrasena.Name = "btnCambiarContrasena";
            this.btnCambiarContrasena.Size = new System.Drawing.Size(150, 36);
            this.btnCambiarContrasena.TabIndex = 7;
            this.btnCambiarContrasena.Text = "Cambiar Contraseña";
            this.btnCambiarContrasena.UseVisualStyleBackColor = true;
            this.btnCambiarContrasena.Click += new System.EventHandler(this.btnCambiarContrasena_Click);
            // 
            // frmPanelUsuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnCambiarContrasena);
            this.Controls.Add(this.btnPreguntas);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnRegistroClientes);
            this.Controls.Add(this.lblAdministrador);
            this.Controls.Add(this.btnGestionContraseñas);
            this.Controls.Add(this.btnGestionPermisos);
            this.Controls.Add(this.btnGestionUsuarios);
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
    }
}