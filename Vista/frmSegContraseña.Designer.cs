namespace Vista
{
    partial class frmSegContraseña
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSegContraseña));
            this.chkMinCarac = new System.Windows.Forms.CheckBox();
            this.chkNumyLet = new System.Windows.Forms.CheckBox();
            this.chkMayusyMin = new System.Windows.Forms.CheckBox();
            this.chkDatosPerson = new System.Windows.Forms.CheckBox();
            this.chkReutContra = new System.Windows.Forms.CheckBox();
            this.chkCaractEsp = new System.Windows.Forms.CheckBox();
            this.lblseguridad = new System.Windows.Forms.Label();
            this.btnGuardarCambios = new System.Windows.Forms.Button();
            this.nudCaractMin = new System.Windows.Forms.NumericUpDown();
            this.btnVolveradmin = new System.Windows.Forms.Button();
            this.lblDiasCambio = new System.Windows.Forms.Label();
            this.nudDiasCambio = new System.Windows.Forms.NumericUpDown();
            this.pctClose = new System.Windows.Forms.PictureBox();
            this.pctMinimize = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.nudCaractMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDiasCambio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctMinimize)).BeginInit();
            this.SuspendLayout();
            // 
            // chkMinCarac
            // 
            this.chkMinCarac.AutoSize = true;
            this.chkMinCarac.Location = new System.Drawing.Point(167, 72);
            this.chkMinCarac.Name = "chkMinCarac";
            this.chkMinCarac.Size = new System.Drawing.Size(171, 17);
            this.chkMinCarac.TabIndex = 1;
            this.chkMinCarac.Text = "Cantidad minima de caracteres";
            this.chkMinCarac.UseVisualStyleBackColor = true;
            // 
            // chkNumyLet
            // 
            this.chkNumyLet.AutoSize = true;
            this.chkNumyLet.Location = new System.Drawing.Point(167, 154);
            this.chkNumyLet.Name = "chkNumyLet";
            this.chkNumyLet.Size = new System.Drawing.Size(176, 17);
            this.chkNumyLet.TabIndex = 4;
            this.chkNumyLet.Text = "Debe contener numeros y letras";
            this.chkNumyLet.UseVisualStyleBackColor = true;
            // 
            // chkMayusyMin
            // 
            this.chkMayusyMin.AutoSize = true;
            this.chkMayusyMin.Location = new System.Drawing.Point(167, 115);
            this.chkMayusyMin.Name = "chkMayusyMin";
            this.chkMayusyMin.Size = new System.Drawing.Size(223, 17);
            this.chkMayusyMin.TabIndex = 3;
            this.chkMayusyMin.Text = "Combinacion de mayusculas y minusculas";
            this.chkMayusyMin.UseVisualStyleBackColor = true;
            // 
            // chkDatosPerson
            // 
            this.chkDatosPerson.AutoSize = true;
            this.chkDatosPerson.Location = new System.Drawing.Point(167, 273);
            this.chkDatosPerson.Name = "chkDatosPerson";
            this.chkDatosPerson.Size = new System.Drawing.Size(195, 17);
            this.chkDatosPerson.TabIndex = 7;
            this.chkDatosPerson.Text = "No debe contener datos personales";
            this.chkDatosPerson.UseVisualStyleBackColor = true;
            // 
            // chkReutContra
            // 
            this.chkReutContra.AutoSize = true;
            this.chkReutContra.Location = new System.Drawing.Point(167, 231);
            this.chkReutContra.Name = "chkReutContra";
            this.chkReutContra.Size = new System.Drawing.Size(193, 17);
            this.chkReutContra.TabIndex = 6;
            this.chkReutContra.Text = "No se permite reutilizar contraseñas";
            this.chkReutContra.UseVisualStyleBackColor = true;
            // 
            // chkCaractEsp
            // 
            this.chkCaractEsp.AutoSize = true;
            this.chkCaractEsp.Location = new System.Drawing.Point(167, 195);
            this.chkCaractEsp.Name = "chkCaractEsp";
            this.chkCaractEsp.Size = new System.Drawing.Size(235, 17);
            this.chkCaractEsp.TabIndex = 5;
            this.chkCaractEsp.Text = "Debe contener al menos 1 caracter especial";
            this.chkCaractEsp.UseVisualStyleBackColor = true;
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
            // btnGuardarCambios
            // 
            this.btnGuardarCambios.Location = new System.Drawing.Point(167, 385);
            this.btnGuardarCambios.Name = "btnGuardarCambios";
            this.btnGuardarCambios.Size = new System.Drawing.Size(162, 31);
            this.btnGuardarCambios.TabIndex = 8;
            this.btnGuardarCambios.Text = "Guardar cambios";
            this.btnGuardarCambios.UseVisualStyleBackColor = true;
            this.btnGuardarCambios.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // nudCaractMin
            // 
            this.nudCaractMin.Location = new System.Drawing.Point(388, 69);
            this.nudCaractMin.Name = "nudCaractMin";
            this.nudCaractMin.Size = new System.Drawing.Size(62, 20);
            this.nudCaractMin.TabIndex = 2;
            // 
            // btnVolveradmin
            // 
            this.btnVolveradmin.Location = new System.Drawing.Point(365, 385);
            this.btnVolveradmin.Name = "btnVolveradmin";
            this.btnVolveradmin.Size = new System.Drawing.Size(162, 31);
            this.btnVolveradmin.TabIndex = 9;
            this.btnVolveradmin.Text = "Volver";
            this.btnVolveradmin.UseVisualStyleBackColor = true;
            this.btnVolveradmin.Click += new System.EventHandler(this.btnVolveradmin_Click);
            // 
            // lblDiasCambio
            // 
            this.lblDiasCambio.AutoSize = true;
            this.lblDiasCambio.Location = new System.Drawing.Point(182, 315);
            this.lblDiasCambio.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDiasCambio.Name = "lblDiasCambio";
            this.lblDiasCambio.Size = new System.Drawing.Size(165, 13);
            this.lblDiasCambio.TabIndex = 17;
            this.lblDiasCambio.Text = "Días para cambio de contraseña:";
            // 
            // nudDiasCambio
            // 
            this.nudDiasCambio.Location = new System.Drawing.Point(370, 313);
            this.nudDiasCambio.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.nudDiasCambio.Maximum = new decimal(new int[] {
            365,
            0,
            0,
            0});
            this.nudDiasCambio.Name = "nudDiasCambio";
            this.nudDiasCambio.Size = new System.Drawing.Size(50, 20);
            this.nudDiasCambio.TabIndex = 18;
            this.nudDiasCambio.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudDiasCambio.Value = new decimal(new int[] {
            90,
            0,
            0,
            0});
            // 
            // pctClose
            // 
            this.pctClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(40)))));
            this.pctClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pctClose.Image = ((System.Drawing.Image)(resources.GetObject("pctClose.Image")));
            this.pctClose.Location = new System.Drawing.Point(758, 2);
            this.pctClose.Name = "pctClose";
            this.pctClose.Size = new System.Drawing.Size(40, 40);
            this.pctClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pctClose.TabIndex = 21;
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
            this.pctMinimize.TabIndex = 23;
            this.pctMinimize.TabStop = false;
            this.pctMinimize.Click += new System.EventHandler(this.pctMinimize_Click);
            // 
            // frmSegContraseña
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pctMinimize);
            this.Controls.Add(this.pctClose);
            this.Controls.Add(this.nudDiasCambio);
            this.Controls.Add(this.lblDiasCambio);
            this.Controls.Add(this.btnVolveradmin);
            this.Controls.Add(this.nudCaractMin);
            this.Controls.Add(this.btnGuardarCambios);
            this.Controls.Add(this.lblseguridad);
            this.Controls.Add(this.chkDatosPerson);
            this.Controls.Add(this.chkReutContra);
            this.Controls.Add(this.chkCaractEsp);
            this.Controls.Add(this.chkNumyLet);
            this.Controls.Add(this.chkMayusyMin);
            this.Controls.Add(this.chkMinCarac);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmSegContraseña";
            this.Text = "Administrador";
            this.Load += new System.EventHandler(this.frmadmin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudCaractMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDiasCambio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctMinimize)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkMinCarac;
        private System.Windows.Forms.CheckBox chkNumyLet;
        private System.Windows.Forms.CheckBox chkMayusyMin;
        private System.Windows.Forms.CheckBox chkDatosPerson;
        private System.Windows.Forms.CheckBox chkReutContra;
        private System.Windows.Forms.CheckBox chkCaractEsp;
        private System.Windows.Forms.Label lblseguridad;
        private System.Windows.Forms.Button btnGuardarCambios;
        private System.Windows.Forms.NumericUpDown nudCaractMin;
        private System.Windows.Forms.Button btnVolveradmin;
        private System.Windows.Forms.Label lblDiasCambio;
        private System.Windows.Forms.NumericUpDown nudDiasCambio;
        private System.Windows.Forms.PictureBox pctClose;
        private System.Windows.Forms.PictureBox pctMinimize;
    }
}