namespace Vista
{
    partial class frmPermisos
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
            this.lblpermisos = new System.Windows.Forms.Label();
            this.btnVolver = new System.Windows.Forms.Button();
            this.cmbusuarios = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.dgvusuarios = new System.Windows.Forms.DataGridView();
            this.btnguardar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvusuarios)).BeginInit();
            this.SuspendLayout();
            // 
            // lblpermisos
            // 
            this.lblpermisos.AutoSize = true;
            this.lblpermisos.Location = new System.Drawing.Point(278, 36);
            this.lblpermisos.Name = "lblpermisos";
            this.lblpermisos.Size = new System.Drawing.Size(102, 13);
            this.lblpermisos.TabIndex = 0;
            this.lblpermisos.Text = "Gestion de permisos";
            // 
            // btnVolver
            // 
            this.btnVolver.Location = new System.Drawing.Point(557, 312);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(92, 29);
            this.btnVolver.TabIndex = 1;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // cmbusuarios
            // 
            this.cmbusuarios.FormattingEnabled = true;
            this.cmbusuarios.Location = new System.Drawing.Point(45, 89);
            this.cmbusuarios.Name = "cmbusuarios";
            this.cmbusuarios.Size = new System.Drawing.Size(154, 21);
            this.cmbusuarios.TabIndex = 2;
            this.cmbusuarios.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(47, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Seleccione un rol";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(309, 89);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(163, 21);
            this.comboBox1.TabIndex = 4;
            // 
            // dgvusuarios
            // 
            this.dgvusuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvusuarios.Location = new System.Drawing.Point(141, 188);
            this.dgvusuarios.Name = "dgvusuarios";
            this.dgvusuarios.Size = new System.Drawing.Size(257, 65);
            this.dgvusuarios.TabIndex = 5;
            // 
            // btnguardar
            // 
            this.btnguardar.Location = new System.Drawing.Point(557, 263);
            this.btnguardar.Name = "btnguardar";
            this.btnguardar.Size = new System.Drawing.Size(92, 29);
            this.btnguardar.TabIndex = 6;
            this.btnguardar.Text = "Guardar";
            this.btnguardar.UseVisualStyleBackColor = true;
            // 
            // frmPermisos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnguardar);
            this.Controls.Add(this.dgvusuarios);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbusuarios);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.lblpermisos);
            this.Name = "frmPermisos";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dgvusuarios)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblpermisos;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.ComboBox cmbusuarios;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.DataGridView dgvusuarios;
        private System.Windows.Forms.Button btnguardar;
    }
}