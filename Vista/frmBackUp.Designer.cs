namespace Vista
{
    partial class frmBackUp
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
            this.btnGuardarrapido = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnGuardarUbicacionSeleccionada = new System.Windows.Forms.Button();
            this.btnExaminar = new System.Windows.Forms.Button();
            this.txtRutaBackup = new System.Windows.Forms.TextBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.pgbGuardadoRapido = new System.Windows.Forms.ProgressBar();
            this.pgbGuardadoPersonalizado = new System.Windows.Forms.ProgressBar();
            this.btnSalir = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnGuardarrapido
            // 
            this.btnGuardarrapido.Location = new System.Drawing.Point(211, 43);
            this.btnGuardarrapido.Name = "btnGuardarrapido";
            this.btnGuardarrapido.Size = new System.Drawing.Size(234, 36);
            this.btnGuardarrapido.TabIndex = 1;
            this.btnGuardarrapido.Text = "Guardado Rapido";
            this.btnGuardarrapido.UseVisualStyleBackColor = true;
            this.btnGuardarrapido.Click += new System.EventHandler(this.btnGuardarrapido_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(139, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(442, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Se guardara una copia de la base de datos en la carpeta \"C:\\BackUps\" de su comput" +
    "adora";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(191, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(272, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Elija una ubicacion donde guardar la copia de seguridad";
            // 
            // btnGuardarUbicacionSeleccionada
            // 
            this.btnGuardarUbicacionSeleccionada.Location = new System.Drawing.Point(211, 80);
            this.btnGuardarUbicacionSeleccionada.Name = "btnGuardarUbicacionSeleccionada";
            this.btnGuardarUbicacionSeleccionada.Size = new System.Drawing.Size(234, 36);
            this.btnGuardarUbicacionSeleccionada.TabIndex = 4;
            this.btnGuardarUbicacionSeleccionada.Text = "Guardar en Ubicacion Seleccionada";
            this.btnGuardarUbicacionSeleccionada.UseVisualStyleBackColor = true;
            this.btnGuardarUbicacionSeleccionada.Click += new System.EventHandler(this.btnGuardarUbicacionSeleccionada_Click);
            // 
            // btnExaminar
            // 
            this.btnExaminar.Location = new System.Drawing.Point(13, 35);
            this.btnExaminar.Name = "btnExaminar";
            this.btnExaminar.Size = new System.Drawing.Size(118, 36);
            this.btnExaminar.TabIndex = 6;
            this.btnExaminar.Text = "Examinar";
            this.btnExaminar.UseVisualStyleBackColor = true;
            this.btnExaminar.Click += new System.EventHandler(this.btnExaminar_Click);
            // 
            // txtRutaBackup
            // 
            this.txtRutaBackup.Location = new System.Drawing.Point(142, 44);
            this.txtRutaBackup.Name = "txtRutaBackup";
            this.txtRutaBackup.Size = new System.Drawing.Size(473, 20);
            this.txtRutaBackup.TabIndex = 8;
            // 
            // pgbGuardadoRapido
            // 
            this.pgbGuardadoRapido.Location = new System.Drawing.Point(13, 96);
            this.pgbGuardadoRapido.Name = "pgbGuardadoRapido";
            this.pgbGuardadoRapido.Size = new System.Drawing.Size(602, 14);
            this.pgbGuardadoRapido.TabIndex = 9;
            // 
            // pgbGuardadoPersonalizado
            // 
            this.pgbGuardadoPersonalizado.Location = new System.Drawing.Point(13, 131);
            this.pgbGuardadoPersonalizado.Name = "pgbGuardadoPersonalizado";
            this.pgbGuardadoPersonalizado.Size = new System.Drawing.Size(602, 14);
            this.pgbGuardadoPersonalizado.TabIndex = 10;
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(286, 422);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(114, 36);
            this.btnSalir.TabIndex = 7;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(283, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(109, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "REALIZAR BACK UP";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pgbGuardadoRapido);
            this.groupBox1.Controls.Add(this.btnGuardarrapido);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 69);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(631, 151);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Metodo Rapido";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.pgbGuardadoPersonalizado);
            this.groupBox2.Controls.Add(this.txtRutaBackup);
            this.groupBox2.Controls.Add(this.btnExaminar);
            this.groupBox2.Controls.Add(this.btnGuardarUbicacionSeleccionada);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(12, 240);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(630, 169);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Ubicacion Perzonalizada";
            // 
            // frmBackUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(674, 470);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnSalir);
            this.Name = "frmBackUp";
            this.Text = "frmbackup";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnGuardarrapido;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnGuardarUbicacionSeleccionada;
        private System.Windows.Forms.Button btnExaminar;
        private System.Windows.Forms.TextBox txtRutaBackup;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.ProgressBar pgbGuardadoRapido;
        private System.Windows.Forms.ProgressBar pgbGuardadoPersonalizado;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}