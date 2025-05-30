namespace Vista
{
    partial class frmAdmin
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
            this.chkmincarac = new System.Windows.Forms.CheckBox();
            this.chkcantpreg = new System.Windows.Forms.CheckBox();
            this.chknumylet = new System.Windows.Forms.CheckBox();
            this.chkmaymin = new System.Windows.Forms.CheckBox();
            this.chkdatper = new System.Windows.Forms.CheckBox();
            this.chkreucont = new System.Windows.Forms.CheckBox();
            this.chkaut2p = new System.Windows.Forms.CheckBox();
            this.chkcaresp = new System.Windows.Forms.CheckBox();
            this.lblseguridad = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnvolver = new System.Windows.Forms.Button();
            this.btnguardarcambios = new System.Windows.Forms.Button();
            this.nupcaracteres = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.nupcaracteres)).BeginInit();
            this.SuspendLayout();
            // 
            // chkmincarac
            // 
            this.chkmincarac.AutoSize = true;
            this.chkmincarac.Location = new System.Drawing.Point(167, 72);
            this.chkmincarac.Name = "chkmincarac";
            this.chkmincarac.Size = new System.Drawing.Size(171, 17);
            this.chkmincarac.TabIndex = 0;
            this.chkmincarac.Text = "Cantidad minima de caracteres";
            this.chkmincarac.UseVisualStyleBackColor = true;
            // 
            // chkcantpreg
            // 
            this.chkcantpreg.AutoSize = true;
            this.chkcantpreg.Location = new System.Drawing.Point(167, 108);
            this.chkcantpreg.Name = "chkcantpreg";
            this.chkcantpreg.Size = new System.Drawing.Size(192, 17);
            this.chkcantpreg.TabIndex = 1;
            this.chkcantpreg.Text = "Cantidad de preguntas a responder";
            this.chkcantpreg.UseVisualStyleBackColor = true;
            // 
            // chknumylet
            // 
            this.chknumylet.AutoSize = true;
            this.chknumylet.Location = new System.Drawing.Point(167, 183);
            this.chknumylet.Name = "chknumylet";
            this.chknumylet.Size = new System.Drawing.Size(176, 17);
            this.chknumylet.TabIndex = 3;
            this.chknumylet.Text = "Debe contener numeros y letras";
            this.chknumylet.UseVisualStyleBackColor = true;
            // 
            // chkmaymin
            // 
            this.chkmaymin.AutoSize = true;
            this.chkmaymin.Location = new System.Drawing.Point(167, 147);
            this.chkmaymin.Name = "chkmaymin";
            this.chkmaymin.Size = new System.Drawing.Size(223, 17);
            this.chkmaymin.TabIndex = 2;
            this.chkmaymin.Text = "Combinacion de mayusculas y minusculas";
            this.chkmaymin.UseVisualStyleBackColor = true;
            // 
            // chkdatper
            // 
            this.chkdatper.AutoSize = true;
            this.chkdatper.Location = new System.Drawing.Point(167, 329);
            this.chkdatper.Name = "chkdatper";
            this.chkdatper.Size = new System.Drawing.Size(195, 17);
            this.chkdatper.TabIndex = 7;
            this.chkdatper.Text = "No debe contener datos personales";
            this.chkdatper.UseVisualStyleBackColor = true;
            // 
            // chkreucont
            // 
            this.chkreucont.AutoSize = true;
            this.chkreucont.Location = new System.Drawing.Point(167, 293);
            this.chkreucont.Name = "chkreucont";
            this.chkreucont.Size = new System.Drawing.Size(193, 17);
            this.chkreucont.TabIndex = 6;
            this.chkreucont.Text = "No se permite reutilizar contraseñas";
            this.chkreucont.UseVisualStyleBackColor = true;
            // 
            // chkaut2p
            // 
            this.chkaut2p.AutoSize = true;
            this.chkaut2p.Location = new System.Drawing.Point(167, 254);
            this.chkaut2p.Name = "chkaut2p";
            this.chkaut2p.Size = new System.Drawing.Size(146, 17);
            this.chkaut2p.TabIndex = 5;
            this.chkaut2p.Text = "Autenticacion en 2 pasos";
            this.chkaut2p.UseVisualStyleBackColor = true;
            // 
            // chkcaresp
            // 
            this.chkcaresp.AutoSize = true;
            this.chkcaresp.Location = new System.Drawing.Point(167, 218);
            this.chkcaresp.Name = "chkcaresp";
            this.chkcaresp.Size = new System.Drawing.Size(235, 17);
            this.chkcaresp.TabIndex = 4;
            this.chkcaresp.Text = "Debe contener al menos 1 caracter especial";
            this.chkcaresp.UseVisualStyleBackColor = true;
            // 
            // lblseguridad
            // 
            this.lblseguridad.AutoSize = true;
            this.lblseguridad.Location = new System.Drawing.Point(229, 26);
            this.lblseguridad.Name = "lblseguridad";
            this.lblseguridad.Size = new System.Drawing.Size(269, 13);
            this.lblseguridad.TabIndex = 16;
            this.lblseguridad.Text = "Configuracion de seguridad en contraseñas de usuarios";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(365, 105);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(24, 20);
            this.textBox1.TabIndex = 17;
            // 
            // btnvolver
            // 
            this.btnvolver.Location = new System.Drawing.Point(400, 385);
            this.btnvolver.Name = "btnvolver";
            this.btnvolver.Size = new System.Drawing.Size(162, 31);
            this.btnvolver.TabIndex = 18;
            this.btnvolver.Text = "Volver";
            this.btnvolver.UseVisualStyleBackColor = true;
            // 
            // btnguardarcambios
            // 
            this.btnguardarcambios.Location = new System.Drawing.Point(167, 385);
            this.btnguardarcambios.Name = "btnguardarcambios";
            this.btnguardarcambios.Size = new System.Drawing.Size(162, 31);
            this.btnguardarcambios.TabIndex = 19;
            this.btnguardarcambios.Text = "Guardar cambios";
            this.btnguardarcambios.UseVisualStyleBackColor = true;
            // 
            // nupcaracteres
            // 
            this.nupcaracteres.Location = new System.Drawing.Point(388, 69);
            this.nupcaracteres.Name = "nupcaracteres";
            this.nupcaracteres.Size = new System.Drawing.Size(62, 20);
            this.nupcaracteres.TabIndex = 20;
            // 
            // frmAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.nupcaracteres);
            this.Controls.Add(this.btnguardarcambios);
            this.Controls.Add(this.btnvolver);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.lblseguridad);
            this.Controls.Add(this.chkdatper);
            this.Controls.Add(this.chkreucont);
            this.Controls.Add(this.chkaut2p);
            this.Controls.Add(this.chkcaresp);
            this.Controls.Add(this.chknumylet);
            this.Controls.Add(this.chkmaymin);
            this.Controls.Add(this.chkcantpreg);
            this.Controls.Add(this.chkmincarac);
            this.Name = "frmAdmin";
            this.Text = "Administrador";
            this.Load += new System.EventHandler(this.frmadmin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nupcaracteres)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkmincarac;
        private System.Windows.Forms.CheckBox chkcantpreg;
        private System.Windows.Forms.CheckBox chknumylet;
        private System.Windows.Forms.CheckBox chkmaymin;
        private System.Windows.Forms.CheckBox chkdatper;
        private System.Windows.Forms.CheckBox chkreucont;
        private System.Windows.Forms.CheckBox chkaut2p;
        private System.Windows.Forms.CheckBox chkcaresp;
        private System.Windows.Forms.Label lblseguridad;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnvolver;
        private System.Windows.Forms.Button btnguardarcambios;
        private System.Windows.Forms.NumericUpDown nupcaracteres;
    }
}