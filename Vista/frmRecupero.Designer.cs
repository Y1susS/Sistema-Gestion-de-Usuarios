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
            this.txtdni = new System.Windows.Forms.TextBox();
            this.btnSiguiente = new System.Windows.Forms.Button();
            this.txtrespuesta = new System.Windows.Forms.TextBox();
            this.cmbpreguntasseg = new System.Windows.Forms.ComboBox();
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.pctMinimize = new System.Windows.Forms.PictureBox();
            this.pctClose = new System.Windows.Forms.PictureBox();
            this.pctBorde = new System.Windows.Forms.PictureBox();
            this.pctBordeInferior = new System.Windows.Forms.PictureBox();
            this.pctLogo = new System.Windows.Forms.PictureBox();
            this.pctFondo = new System.Windows.Forms.PictureBox();
            this.lblLogin = new System.Windows.Forms.Label();
            this.lblPregunta = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctMinimize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctBorde)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctBordeInferior)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctFondo)).BeginInit();
            this.SuspendLayout();
            // 
            // txtdni
            // 
            this.txtdni.BackColor = System.Drawing.Color.White;
            this.txtdni.Font = new System.Drawing.Font("Bahnschrift", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtdni.Location = new System.Drawing.Point(109, 173);
            this.txtdni.MaxLength = 25;
            this.txtdni.Name = "txtdni";
            this.txtdni.Size = new System.Drawing.Size(185, 25);
            this.txtdni.TabIndex = 15;
            this.txtdni.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtdni.TextChanged += new System.EventHandler(this.txtdni_TextChanged_1);
            this.txtdni.Enter += new System.EventHandler(this.txtdni_Enter);
            this.txtdni.Leave += new System.EventHandler(this.txtdni_Leave);
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
            this.btnSiguiente.Location = new System.Drawing.Point(109, 335);
            this.btnSiguiente.Margin = new System.Windows.Forms.Padding(4);
            this.btnSiguiente.Name = "btnSiguiente";
            this.btnSiguiente.Size = new System.Drawing.Size(185, 30);
            this.btnSiguiente.TabIndex = 18;
            this.btnSiguiente.Text = "Siguiente";
            this.btnSiguiente.UseVisualStyleBackColor = false;
            this.btnSiguiente.Click += new System.EventHandler(this.btnSiguiente_Click);
            // 
            // txtrespuesta
            // 
            this.txtrespuesta.BackColor = System.Drawing.Color.White;
            this.txtrespuesta.Font = new System.Drawing.Font("Bahnschrift", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtrespuesta.Location = new System.Drawing.Point(109, 290);
            this.txtrespuesta.MaxLength = 25;
            this.txtrespuesta.Name = "txtrespuesta";
            this.txtrespuesta.Size = new System.Drawing.Size(185, 25);
            this.txtrespuesta.TabIndex = 30;
            this.txtrespuesta.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtrespuesta.TextChanged += new System.EventHandler(this.txtrespuesta_TextChanged);
            this.txtrespuesta.Enter += new System.EventHandler(this.txtrespuesta_Enter);
            this.txtrespuesta.Leave += new System.EventHandler(this.txtrespuesta_Leave);
            // 
            // cmbpreguntasseg
            // 
            this.cmbpreguntasseg.Font = new System.Drawing.Font("Bahnschrift", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbpreguntasseg.FormattingEnabled = true;
            this.cmbpreguntasseg.Location = new System.Drawing.Point(41, 231);
            this.cmbpreguntasseg.Name = "cmbpreguntasseg";
            this.cmbpreguntasseg.Size = new System.Drawing.Size(315, 26);
            this.cmbpreguntasseg.TabIndex = 31;
            this.cmbpreguntasseg.SelectedIndexChanged += new System.EventHandler(this.cmbpreguntasseg_SelectedIndexChanged);
            this.cmbpreguntasseg.Enter += new System.EventHandler(this.cmbpreguntasseg_Enter);
            this.cmbpreguntasseg.Leave += new System.EventHandler(this.cmbpreguntasseg_Leave);
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
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
            // pctBordeInferior
            // 
            this.pctBordeInferior.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(40)))));
            this.pctBordeInferior.Location = new System.Drawing.Point(-2, 378);
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
            this.pctLogo.Location = new System.Drawing.Point(128, 60);
            this.pctLogo.Name = "pctLogo";
            this.pctLogo.Size = new System.Drawing.Size(150, 95);
            this.pctLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pctLogo.TabIndex = 21;
            this.pctLogo.TabStop = false;
            // 
            // pctFondo
            // 
            this.pctFondo.BackgroundImage = global::Vista.Properties.Resources.WoodenPlankCyan;
            this.pctFondo.Location = new System.Drawing.Point(0, 0);
            this.pctFondo.Name = "pctFondo";
            this.pctFondo.Size = new System.Drawing.Size(400, 400);
            this.pctFondo.TabIndex = 23;
            this.pctFondo.TabStop = false;
            // 
            // lblLogin
            // 
            this.lblLogin.AutoSize = true;
            this.lblLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(40)))));
            this.lblLogin.Font = new System.Drawing.Font("Bahnschrift", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLogin.ForeColor = System.Drawing.Color.White;
            this.lblLogin.Location = new System.Drawing.Point(137, 9);
            this.lblLogin.Name = "lblLogin";
            this.lblLogin.Size = new System.Drawing.Size(134, 24);
            this.lblLogin.TabIndex = 32;
            this.lblLogin.Text = "Recuperación";
            this.lblLogin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPregunta
            // 
            this.lblPregunta.AutoSize = true;
            this.lblPregunta.BackColor = System.Drawing.Color.Transparent;
            this.lblPregunta.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPregunta.ForeColor = System.Drawing.Color.White;
            this.lblPregunta.Location = new System.Drawing.Point(119, 210);
            this.lblPregunta.Name = "lblPregunta";
            this.lblPregunta.Size = new System.Drawing.Size(165, 19);
            this.lblPregunta.TabIndex = 33;
            this.lblPregunta.Text = "Ingrese una pregunta";
            // 
            // frmRecupero
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(400, 400);
            this.ControlBox = false;
            this.Controls.Add(this.lblPregunta);
            this.Controls.Add(this.lblLogin);
            this.Controls.Add(this.cmbpreguntasseg);
            this.Controls.Add(this.txtrespuesta);
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
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctMinimize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctBorde)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctBordeInferior)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctFondo)).EndInit();
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
        private System.Windows.Forms.TextBox txtrespuesta;
        private System.Windows.Forms.ComboBox cmbpreguntasseg;
        private System.IO.FileSystemWatcher fileSystemWatcher1;
        private System.Windows.Forms.Label lblLogin;
        private System.Windows.Forms.Label lblPregunta;
    }
}