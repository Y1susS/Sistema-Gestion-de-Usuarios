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
            this.lblbkuppredeterminado = new System.Windows.Forms.Label();
            this.lblbkuppersonalizado = new System.Windows.Forms.Label();
            this.btnGuardarUbicacionSeleccionada = new System.Windows.Forms.Button();
            this.btnExaminar = new System.Windows.Forms.Button();
            this.txtRutaBackup = new System.Windows.Forms.TextBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.pgbGuardadoRapido = new System.Windows.Forms.ProgressBar();
            this.pgbGuardadoPersonalizado = new System.Windows.Forms.ProgressBar();
            this.gpbupredeterminada = new System.Windows.Forms.GroupBox();
            this.gpbupersonalizada = new System.Windows.Forms.GroupBox();
            this.gpbrestore = new System.Windows.Forms.GroupBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.lblseleccionubicacion = new System.Windows.Forms.Label();
            this.btnCargarBackup = new System.Windows.Forms.Button();
            this.txtExaminarBackup = new System.Windows.Forms.TextBox();
            this.btnExaminarBackup = new System.Windows.Forms.Button();
            this.gpbupredeterminada.SuspendLayout();
            this.gpbupersonalizada.SuspendLayout();
            this.gpbrestore.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnGuardarrapido
            // 
            this.btnGuardarrapido.ForeColor = System.Drawing.Color.Black;
            this.btnGuardarrapido.Location = new System.Drawing.Point(315, 70);
            this.btnGuardarrapido.Margin = new System.Windows.Forms.Padding(4);
            this.btnGuardarrapido.Name = "btnGuardarrapido";
            this.btnGuardarrapido.Size = new System.Drawing.Size(250, 30);
            this.btnGuardarrapido.TabIndex = 1;
            this.btnGuardarrapido.Text = "Guardado predeterminado";
            this.btnGuardarrapido.UseVisualStyleBackColor = true;
            this.btnGuardarrapido.Click += new System.EventHandler(this.btnGuardarrapido_Click);
            // 
            // lblbkuppredeterminado
            // 

            this.label1.Location = new System.Drawing.Point(2, 35);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(877, 18);
            this.label1.TabIndex = 2;
            this.label1.Text = "Se guardará una copia de la base de datos en la ubicación \"C:\\BackUps\" de su comp" +
    "utadora";
            this.lblbkuppredeterminado.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblbkuppersonalizado
            // 

            this.label2.Location = new System.Drawing.Point(2, 32);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(877, 18);
            this.label2.TabIndex = 5;
            this.label2.Text = "Elija una ubicación donde guardar la copia de seguridad";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnGuardarUbicacionSeleccionada
            // 
            this.btnGuardarUbicacionSeleccionada.ForeColor = System.Drawing.Color.Black;
            this.btnGuardarUbicacionSeleccionada.Location = new System.Drawing.Point(315, 110);
            this.btnGuardarUbicacionSeleccionada.Margin = new System.Windows.Forms.Padding(4);
            this.btnGuardarUbicacionSeleccionada.Name = "btnGuardarUbicacionSeleccionada";
            this.btnGuardarUbicacionSeleccionada.Size = new System.Drawing.Size(250, 30);
            this.btnGuardarUbicacionSeleccionada.TabIndex = 4;
            this.btnGuardarUbicacionSeleccionada.Text = "Guardado personalizado";
            this.btnGuardarUbicacionSeleccionada.UseVisualStyleBackColor = true;
            this.btnGuardarUbicacionSeleccionada.Click += new System.EventHandler(this.btnGuardarUbicacionSeleccionada_Click);
            // 
            // btnExaminar
            // 
            this.btnExaminar.ForeColor = System.Drawing.Color.Black;
            this.btnExaminar.Location = new System.Drawing.Point(15, 67);
            this.btnExaminar.Margin = new System.Windows.Forms.Padding(4);
            this.btnExaminar.Name = "btnExaminar";
            this.btnExaminar.Size = new System.Drawing.Size(125, 30);
            this.btnExaminar.TabIndex = 6;
            this.btnExaminar.Text = "Examinar";
            this.btnExaminar.UseVisualStyleBackColor = true;
            this.btnExaminar.Click += new System.EventHandler(this.btnExaminar_Click);
            // 
            // txtRutaBackup
            // 
            this.txtRutaBackup.Location = new System.Drawing.Point(148, 70);
            this.txtRutaBackup.Margin = new System.Windows.Forms.Padding(4);
            this.txtRutaBackup.Name = "txtRutaBackup";
            this.txtRutaBackup.Size = new System.Drawing.Size(717, 25);
            this.txtRutaBackup.TabIndex = 8;
            // 
            // pgbGuardadoRapido
            // 
            this.pgbGuardadoRapido.Location = new System.Drawing.Point(15, 115);
            this.pgbGuardadoRapido.Margin = new System.Windows.Forms.Padding(4);
            this.pgbGuardadoRapido.Name = "pgbGuardadoRapido";
            this.pgbGuardadoRapido.Size = new System.Drawing.Size(850, 20);
            this.pgbGuardadoRapido.TabIndex = 9;
            // 
            // pgbGuardadoPersonalizado
            // 
            this.pgbGuardadoPersonalizado.Location = new System.Drawing.Point(15, 155);
            this.pgbGuardadoPersonalizado.Margin = new System.Windows.Forms.Padding(4);
            this.pgbGuardadoPersonalizado.Name = "pgbGuardadoPersonalizado";
            this.pgbGuardadoPersonalizado.Size = new System.Drawing.Size(850, 20);
            this.pgbGuardadoPersonalizado.TabIndex = 10;
            // 

            // 
            // gpbupersonalizada
            // 
            this.gpbupersonalizada.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(40)))));
            this.gpbupersonalizada.Controls.Add(this.pgbGuardadoPersonalizado);
            this.gpbupersonalizada.Controls.Add(this.txtRutaBackup);
            this.gpbupersonalizada.Controls.Add(this.btnExaminar);
            this.gpbupersonalizada.Controls.Add(this.btnGuardarUbicacionSeleccionada);
            this.gpbupersonalizada.Controls.Add(this.lblbkuppersonalizado);
            this.gpbupersonalizada.ForeColor = System.Drawing.Color.White;
            this.gpbupersonalizada.Location = new System.Drawing.Point(15, 190);
            this.gpbupersonalizada.Margin = new System.Windows.Forms.Padding(4);
            this.gpbupersonalizada.Name = "gpbupersonalizada";
            this.gpbupersonalizada.Padding = new System.Windows.Forms.Padding(4);
            this.gpbupersonalizada.Size = new System.Drawing.Size(825, 200);
            this.gpbupersonalizada.TabIndex = 13;
            this.gpbupersonalizada.TabStop = false;
            this.gpbupersonalizada.Text = "Ubicación personalizada";
            // 
            // gpbrestore
            // 
            this.gpbrestore.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(40)))));
            this.gpbrestore.Controls.Add(this.progressBar1);
            this.gpbrestore.Controls.Add(this.lblseleccionubicacion);
            this.gpbrestore.Controls.Add(this.btnCargarBackup);
            this.gpbrestore.Controls.Add(this.txtExaminarBackup);
            this.gpbrestore.Controls.Add(this.btnExaminarBackup);
            this.gpbrestore.ForeColor = System.Drawing.Color.White;
            this.gpbrestore.Location = new System.Drawing.Point(15, 405);
            this.gpbrestore.Margin = new System.Windows.Forms.Padding(4);
            this.gpbrestore.Name = "gpbrestore";
            this.gpbrestore.Padding = new System.Windows.Forms.Padding(4);
            this.gpbrestore.Size = new System.Drawing.Size(825, 200);
            this.gpbrestore.TabIndex = 15;
            this.gpbrestore.TabStop = false;
            this.gpbrestore.Text = "Restaurar Back Up";

            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(40)))));
            this.groupBox1.Controls.Add(this.pgbGuardadoRapido);
            this.groupBox1.Controls.Add(this.btnGuardarrapido);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(10, 10);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(880, 160);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ubicación predeterminada";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(40)))));
            this.groupBox2.Controls.Add(this.pgbGuardadoPersonalizado);
            this.groupBox2.Controls.Add(this.txtRutaBackup);
            this.groupBox2.Controls.Add(this.btnExaminar);
            this.groupBox2.Controls.Add(this.btnGuardarUbicacionSeleccionada);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.ForeColor = System.Drawing.Color.White;
            this.groupBox2.Location = new System.Drawing.Point(10, 180);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(880, 200);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Ubicación personalizada";
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(40)))));
            this.groupBox3.Controls.Add(this.progressBar1);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.btnCargarBackup);
            this.groupBox3.Controls.Add(this.txtExaminarBackup);
            this.groupBox3.Controls.Add(this.btnExaminarBackup);
            this.groupBox3.ForeColor = System.Drawing.Color.White;
            this.groupBox3.Location = new System.Drawing.Point(10, 390);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox3.Size = new System.Drawing.Size(880, 200);
            this.groupBox3.TabIndex = 15;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Cargar Back Up";

            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(15, 155);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(4);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(850, 20);
            this.progressBar1.TabIndex = 11;
            // 
            // lblseleccionubicacion
            // 

            this.label3.Location = new System.Drawing.Point(2, 32);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(877, 18);
            this.label3.TabIndex = 11;
            this.label3.Text = "Seleccione la ubicación del archivo Back Up";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnCargarBackup
            // 
            this.btnCargarBackup.ForeColor = System.Drawing.Color.Black;
            this.btnCargarBackup.Location = new System.Drawing.Point(315, 110);
            this.btnCargarBackup.Margin = new System.Windows.Forms.Padding(4);
            this.btnCargarBackup.Name = "btnCargarBackup";
            this.btnCargarBackup.Size = new System.Drawing.Size(250, 30);
            this.btnCargarBackup.TabIndex = 11;
            this.btnCargarBackup.Text = "Cargar Back Up ";
            this.btnCargarBackup.UseVisualStyleBackColor = true;
            this.btnCargarBackup.Click += new System.EventHandler(this.btnCargarBackup_Click_1);
            // 
            // txtExaminarBackup
            // 
            this.txtExaminarBackup.Location = new System.Drawing.Point(148, 70);
            this.txtExaminarBackup.Margin = new System.Windows.Forms.Padding(4);
            this.txtExaminarBackup.Name = "txtExaminarBackup";
            this.txtExaminarBackup.Size = new System.Drawing.Size(717, 25);
            this.txtExaminarBackup.TabIndex = 11;
            // 
            // btnExaminarBackup
            // 
            this.btnExaminarBackup.ForeColor = System.Drawing.Color.Black;
            this.btnExaminarBackup.Location = new System.Drawing.Point(15, 67);
            this.btnExaminarBackup.Margin = new System.Windows.Forms.Padding(4);
            this.btnExaminarBackup.Name = "btnExaminarBackup";
            this.btnExaminarBackup.Size = new System.Drawing.Size(125, 30);
            this.btnExaminarBackup.TabIndex = 11;
            this.btnExaminarBackup.Text = "Examinar";
            this.btnExaminarBackup.UseVisualStyleBackColor = true;
            this.btnExaminarBackup.Click += new System.EventHandler(this.btnExaminarBackup_Click_1);
            // 
            // frmBackUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Vista.Properties.Resources.WoodenPlankCyan;

            this.ClientSize = new System.Drawing.Size(900, 600);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Bahnschrift", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmBackUp";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmbackup";
            this.Shown += new System.EventHandler(this.frmBackUp_Shown);
            this.gpbupredeterminada.ResumeLayout(false);
            this.gpbupersonalizada.ResumeLayout(false);
            this.gpbupersonalizada.PerformLayout();
            this.gpbrestore.ResumeLayout(false);
            this.gpbrestore.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnGuardarrapido;
        private System.Windows.Forms.Label lblbkuppredeterminado;
        private System.Windows.Forms.Label lblbkuppersonalizado;
        private System.Windows.Forms.Button btnGuardarUbicacionSeleccionada;
        private System.Windows.Forms.Button btnExaminar;
        private System.Windows.Forms.TextBox txtRutaBackup;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.ProgressBar pgbGuardadoRapido;
        private System.Windows.Forms.ProgressBar pgbGuardadoPersonalizado;
        private System.Windows.Forms.GroupBox gpbupredeterminada;
        private System.Windows.Forms.GroupBox gpbupersonalizada;
        private System.Windows.Forms.TextBox txtExaminarBackup;
        private System.Windows.Forms.GroupBox gpbrestore;
        private System.Windows.Forms.Button btnExaminarBackup;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label lblseleccionubicacion;
        private System.Windows.Forms.Button btnCargarBackup;
    }
}