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
            ((System.ComponentModel.ISupportInitialize)(this.nudCaractMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDiasCambio)).BeginInit();
            this.SuspendLayout();
            // 
            // chkMinCarac
            // 
            this.chkMinCarac.AutoSize = true;
            this.chkMinCarac.Location = new System.Drawing.Point(250, 111);
            this.chkMinCarac.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkMinCarac.Name = "chkMinCarac";
            this.chkMinCarac.Size = new System.Drawing.Size(254, 24);
            this.chkMinCarac.TabIndex = 1;
            this.chkMinCarac.Text = "Cantidad minima de caracteres";
            this.chkMinCarac.UseVisualStyleBackColor = true;
            // 
            // chkNumyLet
            // 
            this.chkNumyLet.AutoSize = true;
            this.chkNumyLet.Location = new System.Drawing.Point(250, 237);
            this.chkNumyLet.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkNumyLet.Name = "chkNumyLet";
            this.chkNumyLet.Size = new System.Drawing.Size(261, 24);
            this.chkNumyLet.TabIndex = 4;
            this.chkNumyLet.Text = "Debe contener numeros y letras";
            this.chkNumyLet.UseVisualStyleBackColor = true;
            // 
            // chkMayusyMin
            // 
            this.chkMayusyMin.AutoSize = true;
            this.chkMayusyMin.Location = new System.Drawing.Point(250, 177);
            this.chkMayusyMin.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkMayusyMin.Name = "chkMayusyMin";
            this.chkMayusyMin.Size = new System.Drawing.Size(330, 24);
            this.chkMayusyMin.TabIndex = 3;
            this.chkMayusyMin.Text = "Combinacion de mayusculas y minusculas";
            this.chkMayusyMin.UseVisualStyleBackColor = true;
            // 
            // chkDatosPerson
            // 
            this.chkDatosPerson.AutoSize = true;
            this.chkDatosPerson.Location = new System.Drawing.Point(250, 420);
            this.chkDatosPerson.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkDatosPerson.Name = "chkDatosPerson";
            this.chkDatosPerson.Size = new System.Drawing.Size(288, 24);
            this.chkDatosPerson.TabIndex = 7;
            this.chkDatosPerson.Text = "No debe contener datos personales";
            this.chkDatosPerson.UseVisualStyleBackColor = true;
            // 
            // chkReutContra
            // 
            this.chkReutContra.AutoSize = true;
            this.chkReutContra.Location = new System.Drawing.Point(250, 355);
            this.chkReutContra.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkReutContra.Name = "chkReutContra";
            this.chkReutContra.Size = new System.Drawing.Size(288, 24);
            this.chkReutContra.TabIndex = 6;
            this.chkReutContra.Text = "No se permite reutilizar contraseñas";
            this.chkReutContra.UseVisualStyleBackColor = true;
            // 
            // chkCaractEsp
            // 
            this.chkCaractEsp.AutoSize = true;
            this.chkCaractEsp.Location = new System.Drawing.Point(250, 300);
            this.chkCaractEsp.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkCaractEsp.Name = "chkCaractEsp";
            this.chkCaractEsp.Size = new System.Drawing.Size(346, 24);
            this.chkCaractEsp.TabIndex = 5;
            this.chkCaractEsp.Text = "Debe contener al menos 1 caracter especial";
            this.chkCaractEsp.UseVisualStyleBackColor = true;
            // 
            // lblseguridad
            // 
            this.lblseguridad.AutoSize = true;
            this.lblseguridad.Location = new System.Drawing.Point(344, 40);
            this.lblseguridad.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblseguridad.Name = "lblseguridad";
            this.lblseguridad.Size = new System.Drawing.Size(403, 20);
            this.lblseguridad.TabIndex = 16;
            this.lblseguridad.Text = "Configuracion de seguridad en contraseñas de usuarios";
            // 
            // btnGuardarCambios
            // 
            this.btnGuardarCambios.Location = new System.Drawing.Point(250, 592);
            this.btnGuardarCambios.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnGuardarCambios.Name = "btnGuardarCambios";
            this.btnGuardarCambios.Size = new System.Drawing.Size(243, 48);
            this.btnGuardarCambios.TabIndex = 8;
            this.btnGuardarCambios.Text = "Guardar cambios";
            this.btnGuardarCambios.UseVisualStyleBackColor = true;
            this.btnGuardarCambios.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // nudCaractMin
            // 
            this.nudCaractMin.Location = new System.Drawing.Point(582, 106);
            this.nudCaractMin.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nudCaractMin.Name = "nudCaractMin";
            this.nudCaractMin.Size = new System.Drawing.Size(93, 26);
            this.nudCaractMin.TabIndex = 2;
            // 
            // btnVolveradmin
            // 
            this.btnVolveradmin.Location = new System.Drawing.Point(548, 592);
            this.btnVolveradmin.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnVolveradmin.Name = "btnVolveradmin";
            this.btnVolveradmin.Size = new System.Drawing.Size(243, 48);
            this.btnVolveradmin.TabIndex = 9;
            this.btnVolveradmin.Text = "Volver";
            this.btnVolveradmin.UseVisualStyleBackColor = true;
            this.btnVolveradmin.Click += new System.EventHandler(this.btnVolveradmin_Click);
            // 
            // lblDiasCambio
            // 
            this.lblDiasCambio.AutoSize = true;
            this.lblDiasCambio.Location = new System.Drawing.Point(273, 484);
            this.lblDiasCambio.Name = "lblDiasCambio";
            this.lblDiasCambio.Size = new System.Drawing.Size(242, 20);
            this.lblDiasCambio.TabIndex = 17;
            this.lblDiasCambio.Text = "Días para cambio de contraseña:";
            // 
            // nudDiasCambio
            // 
            this.nudDiasCambio.Location = new System.Drawing.Point(555, 482);
            this.nudDiasCambio.Maximum = new decimal(new int[] {
            365,
            0,
            0,
            0});
            this.nudDiasCambio.Name = "nudDiasCambio";
            this.nudDiasCambio.Size = new System.Drawing.Size(75, 26);
            this.nudDiasCambio.TabIndex = 18;
            this.nudDiasCambio.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudDiasCambio.Value = new decimal(new int[] {
            90,
            0,
            0,
            0});
            // 
            // frmSegContraseña
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 692);
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
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmSegContraseña";
            this.Text = "Administrador";
            this.Load += new System.EventHandler(this.frmadmin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudCaractMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDiasCambio)).EndInit();
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
    }
}