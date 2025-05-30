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
            this.txt1ercontraseña = new System.Windows.Forms.TextBox();
            this.txtnuevacontraseña2 = new System.Windows.Forms.TextBox();
            this.txtnuevacontraseña1 = new System.Windows.Forms.TextBox();
            this.btn = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbl1ercontraseña
            // 
            this.lbl1ercontraseña.AutoSize = true;
            this.lbl1ercontraseña.Location = new System.Drawing.Point(131, 75);
            this.lbl1ercontraseña.Name = "lbl1ercontraseña";
            this.lbl1ercontraseña.Size = new System.Drawing.Size(212, 13);
            this.lbl1ercontraseña.TabIndex = 0;
            this.lbl1ercontraseña.Text = "Ingrese la contraseña que recibio por e-mail";
            // 
            // lblnuevacontraseña2
            // 
            this.lblnuevacontraseña2.AutoSize = true;
            this.lblnuevacontraseña2.Location = new System.Drawing.Point(131, 139);
            this.lblnuevacontraseña2.Name = "lblnuevacontraseña2";
            this.lblnuevacontraseña2.Size = new System.Drawing.Size(138, 13);
            this.lblnuevacontraseña2.TabIndex = 1;
            this.lblnuevacontraseña2.Text = "Repita la nueva contraseña";
            // 
            // lblnuevacontraseña1
            // 
            this.lblnuevacontraseña1.AutoSize = true;
            this.lblnuevacontraseña1.Location = new System.Drawing.Point(131, 106);
            this.lblnuevacontraseña1.Name = "lblnuevacontraseña1";
            this.lblnuevacontraseña1.Size = new System.Drawing.Size(142, 13);
            this.lblnuevacontraseña1.TabIndex = 2;
            this.lblnuevacontraseña1.Text = "Ingrese la nueva contraseña";
            // 
            // txt1ercontraseña
            // 
            this.txt1ercontraseña.Location = new System.Drawing.Point(397, 75);
            this.txt1ercontraseña.Name = "txt1ercontraseña";
            this.txt1ercontraseña.Size = new System.Drawing.Size(191, 20);
            this.txt1ercontraseña.TabIndex = 3;
            // 
            // txtnuevacontraseña2
            // 
            this.txtnuevacontraseña2.Location = new System.Drawing.Point(397, 132);
            this.txtnuevacontraseña2.Name = "txtnuevacontraseña2";
            this.txtnuevacontraseña2.Size = new System.Drawing.Size(191, 20);
            this.txtnuevacontraseña2.TabIndex = 4;
            // 
            // txtnuevacontraseña1
            // 
            this.txtnuevacontraseña1.Location = new System.Drawing.Point(397, 103);
            this.txtnuevacontraseña1.Name = "txtnuevacontraseña1";
            this.txtnuevacontraseña1.Size = new System.Drawing.Size(191, 20);
            this.txtnuevacontraseña1.TabIndex = 5;
            // 
            // btn
            // 
            this.btn.Location = new System.Drawing.Point(244, 176);
            this.btn.Name = "btn";
            this.btn.Size = new System.Drawing.Size(190, 28);
            this.btn.TabIndex = 6;
            this.btn.Text = "Ingresar";
            this.btn.UseVisualStyleBackColor = true;
            this.btn.Click += new System.EventHandler(this.btn_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(522, 247);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(75, 23);
            this.btnSalir.TabIndex = 7;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // frm1eringreso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btn);
            this.Controls.Add(this.txtnuevacontraseña1);
            this.Controls.Add(this.txtnuevacontraseña2);
            this.Controls.Add(this.txt1ercontraseña);
            this.Controls.Add(this.lblnuevacontraseña1);
            this.Controls.Add(this.lblnuevacontraseña2);
            this.Controls.Add(this.lbl1ercontraseña);
            this.Name = "frm1eringreso";
            this.Text = "1er Ingreso - Actualizacion de contraseña";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl1ercontraseña;
        private System.Windows.Forms.Label lblnuevacontraseña2;
        private System.Windows.Forms.Label lblnuevacontraseña1;
        private System.Windows.Forms.TextBox txt1ercontraseña;
        private System.Windows.Forms.TextBox txtnuevacontraseña2;
        private System.Windows.Forms.TextBox txtnuevacontraseña1;
        private System.Windows.Forms.Button btn;
        private System.Windows.Forms.Button btnSalir;
    }
}