using System;

namespace Vista
{
    partial class frmRecupero
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRecupero));
            this.pctBordeInferior = new System.Windows.Forms.PictureBox();
            this.pctLogo = new System.Windows.Forms.PictureBox();
            this.txtdni = new System.Windows.Forms.TextBox();
            this.pctMinimize = new System.Windows.Forms.PictureBox();
            this.pctClose = new System.Windows.Forms.PictureBox();
            this.btnSiguiente = new System.Windows.Forms.Button();
            this.pctFondo = new System.Windows.Forms.PictureBox();
            this.pctBorde = new System.Windows.Forms.PictureBox();
            this.lblrecuperocontraseña = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtrespuesta = new System.Windows.Forms.TextBox();
            this.cmbpreguntasseg = new System.Windows.Forms.ComboBox();
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.btnVolver = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pctBordeInferior)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctMinimize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctFondo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctBorde)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            this.SuspendLayout();
            // 
            // pctBordeInferior
            // 
            this.pctBordeInferior.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(40)))));
            this.pctBordeInferior.Location = new System.Drawing.Point(-2, 348);
            this.pctBordeInferior.Name = "pctBordeInferior";
            this.pctBordeInferior.Size = new System.Drawing.Size(402, 22);
            this.pctBordeInferior.TabIndex = 22;
            this.pctBordeInferior.TabStop = false;
            // 
            // pctLogo
            // 
            this.pctLogo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pctLogo.BackColor = System.Drawing.Color.Transparent;
            this.pctLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pctLogo.Image = ((System.Drawing.Image)(resources.GetObject("pctLogo.Image")));
            this.pctLogo.Location = new System.Drawing.Point(134, 50);
            this.pctLogo.Name = "pctLogo";
            this.pctLogo.Size = new System.Drawing.Size(118, 72);
            this.pctLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pctLogo.TabIndex = 21;
            this.pctLogo.TabStop = false;
            // 
            // txtdni
            // 
            this.txtdni.BackColor = System.Drawing.Color.White;
            this.txtdni.Font = new System.Drawing.Font("Bahnschrift", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtdni.Location = new System.Drawing.Point(168, 134);
            this.txtdni.MaxLength = 25;
            this.txtdni.Name = "txtdni";
            this.txtdni.Size = new System.Drawing.Size(163, 30);
            this.txtdni.TabIndex = 15;
            // 
            // pctMinimize
            // 
            this.pctMinimize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(40)))));
            this.pctMinimize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pctMinimize.Image = global::Vista.Properties.Resources.WhiteMinimize;
            this.pctMinimize.Location = new System.Drawing.Point(2, 2);
            this.pctMinimize.Name = "pctMinimize";
            this.pctMinimize.Size = new System.Drawing.Size(40, 40);
            this.pctMinimize.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pctMinimize.TabIndex = 20;
            this.pctMinimize.TabStop = false;
            this.pctMinimize.Click += new System.EventHandler(this.pctMinimize_Click);
            // 
            // pctClose
            // 
            this.pctClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(40)))));
            this.pctClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pctClose.Image = global::Vista.Properties.Resources.CircleX;
            this.pctClose.Location = new System.Drawing.Point(357, 2);
            this.pctClose.Name = "pctClose";
            this.pctClose.Size = new System.Drawing.Size(40, 40);
            this.pctClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pctClose.TabIndex = 19;
            this.pctClose.TabStop = false;
            this.pctClose.Click += new System.EventHandler(this.PctClose_Click);
            // 
            // btnSiguiente
            // 
            this.btnSiguiente.BackColor = System.Drawing.Color.White;
            this.btnSiguiente.FlatAppearance.BorderColor = System.Drawing.Color.MidnightBlue;
            this.btnSiguiente.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnSiguiente.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnSiguiente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSiguiente.Font = new System.Drawing.Font("Bahnschrift", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSiguiente.ForeColor = System.Drawing.Color.Black;
            this.btnSiguiente.Location = new System.Drawing.Point(16, 313);
            this.btnSiguiente.Margin = new System.Windows.Forms.Padding(4);
            this.btnSiguiente.Name = "btnSiguiente";
            this.btnSiguiente.Size = new System.Drawing.Size(186, 28);
            this.btnSiguiente.TabIndex = 18;
            this.btnSiguiente.Text = "Siguiente";
            this.btnSiguiente.UseVisualStyleBackColor = false;
            this.btnSiguiente.Click += new System.EventHandler(this.btnSiguiente_Click);
            // 
            // pctFondo
            // 
            this.pctFondo.BackgroundImage = global::Vista.Properties.Resources.WoodenPlankCyan;
            this.pctFondo.Location = new System.Drawing.Point(-2, 2);
            this.pctFondo.Name = "pctFondo";
            this.pctFondo.Size = new System.Drawing.Size(402, 361);
            this.pctFondo.TabIndex = 23;
            this.pctFondo.TabStop = false;
            // 
            // pctBorde
            // 
            this.pctBorde.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(40)))));
            this.pctBorde.Location = new System.Drawing.Point(-2, 0);
            this.pctBorde.Name = "pctBorde";
            this.pctBorde.Size = new System.Drawing.Size(402, 44);
            this.pctBorde.TabIndex = 24;
            this.pctBorde.TabStop = false;
            this.pctBorde.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pctBorde_MouseDown);
            this.pctBorde.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pctBorde_MouseMove);
            this.pctBorde.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pctBorde_MouseUp);
            // 
            // lblrecuperocontraseña
            // 
            this.lblrecuperocontraseña.AutoSize = true;
            this.lblrecuperocontraseña.BackColor = System.Drawing.Color.Transparent;
            this.lblrecuperocontraseña.ForeColor = System.Drawing.SystemColors.Control;
            this.lblrecuperocontraseña.Location = new System.Drawing.Point(82, 9);
            this.lblrecuperocontraseña.Name = "lblrecuperocontraseña";
            this.lblrecuperocontraseña.Size = new System.Drawing.Size(268, 21);
            this.lblrecuperocontraseña.TabIndex = 25;
            this.lblrecuperocontraseña.Text = "Recupero de usuario o contraseña";
            this.lblrecuperocontraseña.Click += new System.EventHandler(this.label1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.label1.Location = new System.Drawing.Point(35, 138);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 21);
            this.label1.TabIndex = 26;
            this.label1.Text = "Ingrese su D.N.I";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.label2.Location = new System.Drawing.Point(35, 178);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(240, 21);
            this.label2.TabIndex = 27;
            this.label2.Text = "Elija su pregunta de seguridad";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.label3.Location = new System.Drawing.Point(35, 247);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(167, 21);
            this.label3.TabIndex = 29;
            this.label3.Text = "Ingrese la respuesta";
            // 
            // txtrespuesta
            // 
            this.txtrespuesta.BackColor = System.Drawing.Color.White;
            this.txtrespuesta.Font = new System.Drawing.Font("Bahnschrift", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtrespuesta.Location = new System.Drawing.Point(38, 278);
            this.txtrespuesta.MaxLength = 25;
            this.txtrespuesta.Name = "txtrespuesta";
            this.txtrespuesta.Size = new System.Drawing.Size(293, 30);
            this.txtrespuesta.TabIndex = 30;
            this.txtrespuesta.TextChanged += new System.EventHandler(this.txtrespuesta_TextChanged);
            // 
            // cmbpreguntasseg
            // 
            this.cmbpreguntasseg.FormattingEnabled = true;
            this.cmbpreguntasseg.Location = new System.Drawing.Point(42, 208);
            this.cmbpreguntasseg.Name = "cmbpreguntasseg";
            this.cmbpreguntasseg.Size = new System.Drawing.Size(289, 29);
            this.cmbpreguntasseg.TabIndex = 31;
            this.cmbpreguntasseg.SelectedIndexChanged += new System.EventHandler(this.cmbpreguntasseg_SelectedIndexChanged);
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            // 
            // btnVolver
            // 
            this.btnVolver.Location = new System.Drawing.Point(209, 313);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(71, 28);
            this.btnVolver.TabIndex = 32;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmRecupero
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(400, 370);
            this.ControlBox = false;
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.cmbpreguntasseg);
            this.Controls.Add(this.txtrespuesta);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblrecuperocontraseña);
            this.Controls.Add(this.pctMinimize);
            this.Controls.Add(this.pctClose);
            this.Controls.Add(this.pctBorde);
            this.Controls.Add(this.pctBordeInferior);
            this.Controls.Add(this.pctLogo);
            this.Controls.Add(this.txtdni);
            this.Controls.Add(this.btnSiguiente);
            this.Controls.Add(this.pctFondo);
            this.Font = new System.Drawing.Font("Bahnschrift", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRecupero";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmRecupero";
            this.Load += new System.EventHandler(this.frmRecupero_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pctBordeInferior)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctMinimize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctFondo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctBorde)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbpreguntasseg.Items.Add("¿Cuál es el nombre de tu primera mascota?");
            cmbpreguntasseg.Items.Add("¿Cuál es tu comida favorita?");
            cmbpreguntasseg.Items.Add("¿Cuál es el segundo nombre de tu madre?");
        }

        #endregion

        private System.Windows.Forms.PictureBox pctBordeInferior;
        private System.Windows.Forms.PictureBox pctLogo;
        private System.Windows.Forms.TextBox txtdni;
        private System.Windows.Forms.PictureBox pctMinimize;
        private System.Windows.Forms.PictureBox pctClose;
        private System.Windows.Forms.Button btnSiguiente;
        private System.Windows.Forms.PictureBox pctFondo;
        private System.Windows.Forms.PictureBox pctBorde;
        private System.Windows.Forms.Label lblrecuperocontraseña;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtrespuesta;
        private System.Windows.Forms.ComboBox cmbpreguntasseg;
        private System.IO.FileSystemWatcher fileSystemWatcher1;
        private System.Windows.Forms.Button btnVolver;
    }
}