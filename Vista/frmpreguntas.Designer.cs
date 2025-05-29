namespace Vista
{
    partial class frmpreguntas
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
            this.lblpreguntasseg = new System.Windows.Forms.Label();
            this.lblcomida = new System.Windows.Forms.Label();
            this.lblnombremadre = new System.Windows.Forms.Label();
            this.lblprimeramascota = new System.Windows.Forms.Label();
            this.txtmadre = new System.Windows.Forms.TextBox();
            this.txtcomida = new System.Windows.Forms.TextBox();
            this.txtmascota = new System.Windows.Forms.TextBox();
            this.btnsiguiente = new System.Windows.Forms.Button();
            this.txtrespuestas = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblpreguntasseg
            // 
            this.lblpreguntasseg.AutoSize = true;
            this.lblpreguntasseg.Location = new System.Drawing.Point(221, 29);
            this.lblpreguntasseg.Name = "lblpreguntasseg";
            this.lblpreguntasseg.Size = new System.Drawing.Size(186, 13);
            this.lblpreguntasseg.TabIndex = 0;
            this.lblpreguntasseg.Text = "Responda las preguntas de seguridad";
            // 
            // lblcomida
            // 
            this.lblcomida.AutoSize = true;
            this.lblcomida.Location = new System.Drawing.Point(104, 144);
            this.lblcomida.Name = "lblcomida";
            this.lblcomida.Size = new System.Drawing.Size(141, 13);
            this.lblcomida.TabIndex = 1;
            this.lblcomida.Text = "¿Cual es tu comida favorita?";
            // 
            // lblnombremadre
            // 
            this.lblnombremadre.AutoSize = true;
            this.lblnombremadre.Location = new System.Drawing.Point(104, 97);
            this.lblnombremadre.Name = "lblnombremadre";
            this.lblnombremadre.Size = new System.Drawing.Size(206, 13);
            this.lblnombremadre.TabIndex = 2;
            this.lblnombremadre.Text = "¿Cual es el segundo nombre de tu madre?";
            this.lblnombremadre.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblnombremadre.Click += new System.EventHandler(this.label2_Click);
            // 
            // lblprimeramascota
            // 
            this.lblprimeramascota.AutoSize = true;
            this.lblprimeramascota.Location = new System.Drawing.Point(104, 189);
            this.lblprimeramascota.Name = "lblprimeramascota";
            this.lblprimeramascota.Size = new System.Drawing.Size(210, 13);
            this.lblprimeramascota.TabIndex = 3;
            this.lblprimeramascota.Text = "¿Cual es el nombre de tu primera mascota?";
            // 
            // txtmadre
            // 
            this.txtmadre.Location = new System.Drawing.Point(358, 97);
            this.txtmadre.Name = "txtmadre";
            this.txtmadre.Size = new System.Drawing.Size(173, 20);
            this.txtmadre.TabIndex = 4;
            // 
            // txtcomida
            // 
            this.txtcomida.Location = new System.Drawing.Point(358, 141);
            this.txtcomida.Name = "txtcomida";
            this.txtcomida.Size = new System.Drawing.Size(173, 20);
            this.txtcomida.TabIndex = 5;
            // 
            // txtmascota
            // 
            this.txtmascota.Location = new System.Drawing.Point(358, 189);
            this.txtmascota.Name = "txtmascota";
            this.txtmascota.Size = new System.Drawing.Size(173, 20);
            this.txtmascota.TabIndex = 6;
            // 
            // btnsiguiente
            // 
            this.btnsiguiente.Location = new System.Drawing.Point(251, 226);
            this.btnsiguiente.Name = "btnsiguiente";
            this.btnsiguiente.Size = new System.Drawing.Size(156, 22);
            this.btnsiguiente.TabIndex = 7;
            this.btnsiguiente.Text = "Siguiente";
            this.btnsiguiente.UseVisualStyleBackColor = true;
            this.btnsiguiente.Click += new System.EventHandler(this.btnsiguiente_Click);
            // 
            // txtrespuestas
            // 
            this.txtrespuestas.AutoSize = true;
            this.txtrespuestas.Location = new System.Drawing.Point(412, 69);
            this.txtrespuestas.Name = "txtrespuestas";
            this.txtrespuestas.Size = new System.Drawing.Size(63, 13);
            this.txtrespuestas.TabIndex = 8;
            this.txtrespuestas.Text = "Respuestas";
            // 
            // frmpreguntas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtrespuestas);
            this.Controls.Add(this.btnsiguiente);
            this.Controls.Add(this.txtmascota);
            this.Controls.Add(this.txtcomida);
            this.Controls.Add(this.txtmadre);
            this.Controls.Add(this.lblprimeramascota);
            this.Controls.Add(this.lblnombremadre);
            this.Controls.Add(this.lblcomida);
            this.Controls.Add(this.lblpreguntasseg);
            this.Name = "frmpreguntas";
            this.Text = "Preguntas de seguridad";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblpreguntasseg;
        private System.Windows.Forms.Label lblcomida;
        private System.Windows.Forms.Label lblnombremadre;
        private System.Windows.Forms.Label lblprimeramascota;
        private System.Windows.Forms.TextBox txtmadre;
        private System.Windows.Forms.TextBox txtcomida;
        private System.Windows.Forms.TextBox txtmascota;
        private System.Windows.Forms.Button btnsiguiente;
        private System.Windows.Forms.Label txtrespuestas;
    }
}