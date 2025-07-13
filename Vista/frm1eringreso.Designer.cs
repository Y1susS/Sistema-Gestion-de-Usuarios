namespace Vista
{
    partial class frm1eringreso
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
            this.lbl1ercontraseña = new System.Windows.Forms.Label();
            this.lblnuevacontraseña2 = new System.Windows.Forms.Label();
            this.lblnuevacontraseña1 = new System.Windows.Forms.Label();
            this.txtContraActual = new System.Windows.Forms.TextBox();
            this.txtContraNueva2 = new System.Windows.Forms.TextBox();
            this.txtContraNueva1 = new System.Windows.Forms.TextBox();
            this.btnSiguiente = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbl1ercontraseña
            // 
            this.lbl1ercontraseña.AutoSize = true;
            this.lbl1ercontraseña.Location = new System.Drawing.Point(175, 92);
            this.lbl1ercontraseña.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl1ercontraseña.Name = "lbl1ercontraseña";
            this.lbl1ercontraseña.Size = new System.Drawing.Size(269, 16);
            this.lbl1ercontraseña.TabIndex = 0;
            this.lbl1ercontraseña.Text = "Ingrese la contraseña que recibio por e-mail";
            // 
            // lblnuevacontraseña2
            // 
            this.lblnuevacontraseña2.AutoSize = true;
            this.lblnuevacontraseña2.Location = new System.Drawing.Point(175, 171);
            this.lblnuevacontraseña2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblnuevacontraseña2.Name = "lblnuevacontraseña2";
            this.lblnuevacontraseña2.Size = new System.Drawing.Size(171, 16);
            this.lblnuevacontraseña2.TabIndex = 1;
            this.lblnuevacontraseña2.Text = "Repita la nueva contraseña";
            // 
            // lblnuevacontraseña1
            // 
            this.lblnuevacontraseña1.AutoSize = true;
            this.lblnuevacontraseña1.Location = new System.Drawing.Point(175, 130);
            this.lblnuevacontraseña1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblnuevacontraseña1.Name = "lblnuevacontraseña1";
            this.lblnuevacontraseña1.Size = new System.Drawing.Size(176, 16);
            this.lblnuevacontraseña1.TabIndex = 2;
            this.lblnuevacontraseña1.Text = "Ingrese la nueva contraseña";
            // 
            // txtContraActual
            // 
            this.txtContraActual.Location = new System.Drawing.Point(529, 92);
            this.txtContraActual.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtContraActual.Name = "txtContraActual";
            this.txtContraActual.Size = new System.Drawing.Size(253, 22);
            this.txtContraActual.TabIndex = 3;
            // 
            // txtContraNueva2
            // 
            this.txtContraNueva2.Location = new System.Drawing.Point(529, 162);
            this.txtContraNueva2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtContraNueva2.Name = "txtContraNueva2";
            this.txtContraNueva2.Size = new System.Drawing.Size(253, 22);
            this.txtContraNueva2.TabIndex = 4;
            // 
            // txtContraNueva1
            // 
            this.txtContraNueva1.Location = new System.Drawing.Point(529, 127);
            this.txtContraNueva1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtContraNueva1.Name = "txtContraNueva1";
            this.txtContraNueva1.Size = new System.Drawing.Size(253, 22);
            this.txtContraNueva1.TabIndex = 5;
            // 
            // btnSiguiente
            // 
            this.btnSiguiente.Location = new System.Drawing.Point(325, 217);
            this.btnSiguiente.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSiguiente.Name = "btnSiguiente";
            this.btnSiguiente.Size = new System.Drawing.Size(253, 34);
            this.btnSiguiente.TabIndex = 6;
            this.btnSiguiente.Text = "Siguiente";
            this.btnSiguiente.UseVisualStyleBackColor = true;
            this.btnSiguiente.Click += new System.EventHandler(this.btn_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(696, 304);
            this.btnSalir.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(100, 28);
            this.btnSalir.TabIndex = 7;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // frm1eringreso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnSiguiente);
            this.Controls.Add(this.txtContraNueva1);
            this.Controls.Add(this.txtContraNueva2);
            this.Controls.Add(this.txtContraActual);
            this.Controls.Add(this.lblnuevacontraseña1);
            this.Controls.Add(this.lblnuevacontraseña2);
            this.Controls.Add(this.lbl1ercontraseña);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frm1eringreso";
            this.Text = "1er Ingreso - Actualizacion de contraseña";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl1ercontraseña;
        private System.Windows.Forms.Label lblnuevacontraseña2;
        private System.Windows.Forms.Label lblnuevacontraseña1;
        private System.Windows.Forms.TextBox txtContraActual;
        private System.Windows.Forms.TextBox txtContraNueva2;
        private System.Windows.Forms.TextBox txtContraNueva1;
        private System.Windows.Forms.Button btnSiguiente;
        private System.Windows.Forms.Button btnSalir;
    }
}