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
            this.btnGuardarCambioscont = new System.Windows.Forms.Button();
            this.nudCaractMin = new System.Windows.Forms.NumericUpDown();
            this.lblDiasCambio = new System.Windows.Forms.Label();
            this.nudDiasCambio = new System.Windows.Forms.NumericUpDown();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblseguridad = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pnlBorde = new System.Windows.Forms.Panel();
            this.lblTitulovalidaciones = new System.Windows.Forms.Label();
            this.pctMinimize = new System.Windows.Forms.PictureBox();
            this.pctClose = new System.Windows.Forms.PictureBox();
            this.pnlBordeInferior = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.nudCaractMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDiasCambio)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.pnlBorde.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctMinimize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctClose)).BeginInit();
            this.SuspendLayout();
            // 
            // chkMinCarac
            // 
            this.chkMinCarac.Dock = System.Windows.Forms.DockStyle.Left;
            this.chkMinCarac.Location = new System.Drawing.Point(0, 0);
            this.chkMinCarac.Name = "chkMinCarac";
            this.chkMinCarac.Size = new System.Drawing.Size(245, 40);
            this.chkMinCarac.TabIndex = 1;
            this.chkMinCarac.Text = "Cantidad minima de caracteres";
            this.chkMinCarac.UseVisualStyleBackColor = true;
            // 
            // chkNumyLet
            // 
            this.chkNumyLet.Dock = System.Windows.Forms.DockStyle.Top;
            this.chkNumyLet.Location = new System.Drawing.Point(0, 160);
            this.chkNumyLet.Name = "chkNumyLet";
            this.chkNumyLet.Size = new System.Drawing.Size(325, 40);
            this.chkNumyLet.TabIndex = 4;
            this.chkNumyLet.Text = "Debe contener numeros y letras";
            this.chkNumyLet.UseVisualStyleBackColor = true;
            // 
            // chkMayusyMin
            // 
            this.chkMayusyMin.Dock = System.Windows.Forms.DockStyle.Top;
            this.chkMayusyMin.Location = new System.Drawing.Point(0, 200);
            this.chkMayusyMin.Name = "chkMayusyMin";
            this.chkMayusyMin.Size = new System.Drawing.Size(325, 40);
            this.chkMayusyMin.TabIndex = 3;
            this.chkMayusyMin.Text = "Combinacion de mayusculas y minusculas";
            this.chkMayusyMin.UseVisualStyleBackColor = true;
            // 
            // chkDatosPerson
            // 
            this.chkDatosPerson.Dock = System.Windows.Forms.DockStyle.Top;
            this.chkDatosPerson.Location = new System.Drawing.Point(0, 40);
            this.chkDatosPerson.Name = "chkDatosPerson";
            this.chkDatosPerson.Size = new System.Drawing.Size(325, 40);
            this.chkDatosPerson.TabIndex = 7;
            this.chkDatosPerson.Text = "No debe contener datos personales";
            this.chkDatosPerson.UseVisualStyleBackColor = true;
            // 
            // chkReutContra
            // 
            this.chkReutContra.Dock = System.Windows.Forms.DockStyle.Top;
            this.chkReutContra.Location = new System.Drawing.Point(0, 80);
            this.chkReutContra.Name = "chkReutContra";
            this.chkReutContra.Size = new System.Drawing.Size(325, 40);
            this.chkReutContra.TabIndex = 6;
            this.chkReutContra.Text = "No se permite reutilizar contraseñas";
            this.chkReutContra.UseVisualStyleBackColor = true;
            // 
            // chkCaractEsp
            // 
            this.chkCaractEsp.Dock = System.Windows.Forms.DockStyle.Top;
            this.chkCaractEsp.Location = new System.Drawing.Point(0, 120);
            this.chkCaractEsp.Name = "chkCaractEsp";
            this.chkCaractEsp.Size = new System.Drawing.Size(325, 40);
            this.chkCaractEsp.TabIndex = 5;
            this.chkCaractEsp.Text = "Debe contener al menos 1 caracter especial";
            this.chkCaractEsp.UseVisualStyleBackColor = true;
            // 
            // btnGuardarCambioscont
            // 
            this.btnGuardarCambioscont.Location = new System.Drawing.Point(150, 405);
            this.btnGuardarCambioscont.Name = "btnGuardarCambioscont";
            this.btnGuardarCambioscont.Size = new System.Drawing.Size(175, 30);
            this.btnGuardarCambioscont.TabIndex = 8;
            this.btnGuardarCambioscont.Text = "Guardar cambios";
            this.btnGuardarCambioscont.UseVisualStyleBackColor = true;
            this.btnGuardarCambioscont.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // nudCaractMin
            // 
            this.nudCaractMin.Location = new System.Drawing.Point(260, 7);
            this.nudCaractMin.Name = "nudCaractMin";
            this.nudCaractMin.Size = new System.Drawing.Size(65, 25);
            this.nudCaractMin.TabIndex = 2;
            this.nudCaractMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblDiasCambio
            // 
            this.lblDiasCambio.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblDiasCambio.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblDiasCambio.Location = new System.Drawing.Point(0, 0);
            this.lblDiasCambio.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDiasCambio.Name = "lblDiasCambio";
            this.lblDiasCambio.Size = new System.Drawing.Size(245, 41);
            this.lblDiasCambio.TabIndex = 17;
            this.lblDiasCambio.Text = "    Días para cambio de contraseña";
            this.lblDiasCambio.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // nudDiasCambio
            // 
            this.nudDiasCambio.Location = new System.Drawing.Point(260, 8);
            this.nudDiasCambio.Margin = new System.Windows.Forms.Padding(2);
            this.nudDiasCambio.Maximum = new decimal(new int[] {
            365,
            0,
            0,
            0});
            this.nudDiasCambio.Name = "nudDiasCambio";
            this.nudDiasCambio.Size = new System.Drawing.Size(65, 25);
            this.nudDiasCambio.TabIndex = 18;
            this.nudDiasCambio.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudDiasCambio.Value = new decimal(new int[] {
            90,
            0,
            0,
            0});
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblDiasCambio);
            this.panel1.Controls.Add(this.nudDiasCambio);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 240);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(325, 41);
            this.panel1.TabIndex = 25;
            // 
            // lblseguridad
            // 
            this.lblseguridad.BackColor = System.Drawing.Color.Transparent;
            this.lblseguridad.Font = new System.Drawing.Font("Bahnschrift", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblseguridad.ForeColor = System.Drawing.Color.White;
            this.lblseguridad.Location = new System.Drawing.Point(0, 55);
            this.lblseguridad.Name = "lblseguridad";
            this.lblseguridad.Size = new System.Drawing.Size(475, 45);
            this.lblseguridad.TabIndex = 16;
            this.lblseguridad.Text = "Configuración de las validaciones en \r\nlas contraseñas de los usuarios";
            this.lblseguridad.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.chkMinCarac);
            this.panel2.Controls.Add(this.nudCaractMin);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(325, 40);
            this.panel2.TabIndex = 29;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Transparent;
            this.panel3.Controls.Add(this.panel1);
            this.panel3.Controls.Add(this.chkMayusyMin);
            this.panel3.Controls.Add(this.chkNumyLet);
            this.panel3.Controls.Add(this.chkCaractEsp);
            this.panel3.Controls.Add(this.chkReutContra);
            this.panel3.Controls.Add(this.chkDatosPerson);
            this.panel3.Controls.Add(this.panel2);
            this.panel3.ForeColor = System.Drawing.Color.White;
            this.panel3.Location = new System.Drawing.Point(75, 110);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(325, 285);
            this.panel3.TabIndex = 30;
            // 
            // pnlBorde
            // 
            this.pnlBorde.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(40)))));
            this.pnlBorde.Controls.Add(this.lblTitulovalidaciones);
            this.pnlBorde.Controls.Add(this.pctMinimize);
            this.pnlBorde.Controls.Add(this.pctClose);
            this.pnlBorde.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBorde.Location = new System.Drawing.Point(0, 0);
            this.pnlBorde.Name = "pnlBorde";
            this.pnlBorde.Size = new System.Drawing.Size(475, 40);
            this.pnlBorde.TabIndex = 31;
            // 
            // lblTitulovalidaciones
            // 
            this.lblTitulovalidaciones.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(40)))));
            this.lblTitulovalidaciones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitulovalidaciones.Font = new System.Drawing.Font("Bahnschrift", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulovalidaciones.ForeColor = System.Drawing.Color.White;
            this.lblTitulovalidaciones.Location = new System.Drawing.Point(40, 0);
            this.lblTitulovalidaciones.Name = "lblTitulovalidaciones";
            this.lblTitulovalidaciones.Size = new System.Drawing.Size(395, 40);
            this.lblTitulovalidaciones.TabIndex = 15;
            this.lblTitulovalidaciones.Text = "Validaciones";
            this.lblTitulovalidaciones.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pctMinimize
            // 
            this.pctMinimize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(40)))));
            this.pctMinimize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pctMinimize.Dock = System.Windows.Forms.DockStyle.Left;
            this.pctMinimize.Image = ((System.Drawing.Image)(resources.GetObject("pctMinimize.Image")));
            this.pctMinimize.Location = new System.Drawing.Point(0, 0);
            this.pctMinimize.Name = "pctMinimize";
            this.pctMinimize.Size = new System.Drawing.Size(40, 40);
            this.pctMinimize.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pctMinimize.TabIndex = 22;
            this.pctMinimize.TabStop = false;
            this.pctMinimize.Click += new System.EventHandler(this.pctMinimize_Click);
            // 
            // pctClose
            // 
            this.pctClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(40)))));
            this.pctClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pctClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.pctClose.Image = ((System.Drawing.Image)(resources.GetObject("pctClose.Image")));
            this.pctClose.Location = new System.Drawing.Point(435, 0);
            this.pctClose.Name = "pctClose";
            this.pctClose.Size = new System.Drawing.Size(40, 40);
            this.pctClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pctClose.TabIndex = 20;
            this.pctClose.TabStop = false;
            this.pctClose.Click += new System.EventHandler(this.pctClose_Click);
            // 
            // pnlBordeInferior
            // 
            this.pnlBordeInferior.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(40)))));
            this.pnlBordeInferior.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBordeInferior.Location = new System.Drawing.Point(0, 445);
            this.pnlBordeInferior.Name = "pnlBordeInferior";
            this.pnlBordeInferior.Size = new System.Drawing.Size(475, 20);
            this.pnlBordeInferior.TabIndex = 32;
            // 
            // frmSegContraseña
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImage = global::Vista.Properties.Resources.WoodenPlankCyan;
            this.ClientSize = new System.Drawing.Size(475, 465);
            this.Controls.Add(this.pnlBordeInferior);
            this.Controls.Add(this.pnlBorde);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.lblseguridad);
            this.Controls.Add(this.btnGuardarCambioscont);
            this.Font = new System.Drawing.Font("Bahnschrift", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmSegContraseña";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Administrador";
            this.Load += new System.EventHandler(this.frmadmin_Load);
            this.Shown += new System.EventHandler(this.frmSegContraseña_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.nudCaractMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDiasCambio)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.pnlBorde.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pctMinimize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctClose)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox chkMinCarac;
        private System.Windows.Forms.CheckBox chkNumyLet;
        private System.Windows.Forms.CheckBox chkMayusyMin;
        private System.Windows.Forms.CheckBox chkDatosPerson;
        private System.Windows.Forms.CheckBox chkReutContra;
        private System.Windows.Forms.CheckBox chkCaractEsp;
        private System.Windows.Forms.Button btnGuardarCambioscont;
        private System.Windows.Forms.NumericUpDown nudCaractMin;
        private System.Windows.Forms.Label lblDiasCambio;
        private System.Windows.Forms.NumericUpDown nudDiasCambio;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblseguridad;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel pnlBorde;
        private System.Windows.Forms.Label lblTitulovalidaciones;
        private System.Windows.Forms.PictureBox pctMinimize;
        private System.Windows.Forms.PictureBox pctClose;
        private System.Windows.Forms.Panel pnlBordeInferior;
    }
}