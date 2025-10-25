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
            this.btnSiguienterecupero = new System.Windows.Forms.Button();
            this.txtrespuesta = new System.Windows.Forms.TextBox();
            this.cmbpreguntasseg = new System.Windows.Forms.ComboBox();
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.pctLogo = new System.Windows.Forms.PictureBox();
            this.pctFondo = new System.Windows.Forms.PictureBox();
            this.lblRecuperacion = new System.Windows.Forms.Label();
            this.lblPreguntarecupero = new System.Windows.Forms.Label();
            this.pnlBorde = new System.Windows.Forms.Panel();
            this.pctMinimize = new System.Windows.Forms.PictureBox();
            this.pctClose = new System.Windows.Forms.PictureBox();
            this.pnlBordeInferior = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctFondo)).BeginInit();
            this.pnlBorde.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctMinimize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctClose)).BeginInit();
            this.SuspendLayout();
            // 
            // txtdni
            // 
            this.txtdni.BackColor = System.Drawing.Color.White;
            this.txtdni.Font = new System.Drawing.Font("Bahnschrift", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtdni.Location = new System.Drawing.Point(107, 171);
            this.txtdni.MaxLength = 25;
            this.txtdni.Name = "txtdni";
            this.txtdni.Size = new System.Drawing.Size(185, 25);
            this.txtdni.TabIndex = 15;
            this.txtdni.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtdni.TextChanged += new System.EventHandler(this.txtdni_TextChanged_1);
            this.txtdni.Enter += new System.EventHandler(this.txtdni_Enter);
            this.txtdni.Leave += new System.EventHandler(this.txtdni_Leave);
            // 
            // btnSiguienterecupero
            // 
            this.btnSiguienterecupero.BackColor = System.Drawing.Color.White;
            this.btnSiguienterecupero.Font = new System.Drawing.Font("Bahnschrift", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSiguienterecupero.ForeColor = System.Drawing.Color.Black;
            this.btnSiguienterecupero.Location = new System.Drawing.Point(107, 335);
            this.btnSiguienterecupero.Margin = new System.Windows.Forms.Padding(4);
            this.btnSiguienterecupero.Name = "btnSiguienterecupero";
            this.btnSiguienterecupero.Size = new System.Drawing.Size(185, 30);
            this.btnSiguienterecupero.TabIndex = 18;
            this.btnSiguienterecupero.Text = "Siguiente";
            this.btnSiguienterecupero.UseVisualStyleBackColor = false;
            this.btnSiguienterecupero.Click += new System.EventHandler(this.btnSiguiente_Click);
            // 
            // txtrespuesta
            // 
            this.txtrespuesta.BackColor = System.Drawing.Color.White;
            this.txtrespuesta.Font = new System.Drawing.Font("Bahnschrift", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtrespuesta.Location = new System.Drawing.Point(107, 287);
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
            this.cmbpreguntasseg.Location = new System.Drawing.Point(41, 229);
            this.cmbpreguntasseg.Name = "cmbpreguntasseg";
            this.cmbpreguntasseg.Size = new System.Drawing.Size(315, 26);
            this.cmbpreguntasseg.TabIndex = 31;
            this.cmbpreguntasseg.SelectedIndexChanged += new System.EventHandler(this.cmbpreguntasseg_SelectedIndexChanged);
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            // 
            // pctLogo
            // 
            this.pctLogo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pctLogo.BackColor = System.Drawing.Color.Transparent;
            this.pctLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pctLogo.Image = ((System.Drawing.Image)(resources.GetObject("pctLogo.Image")));
            this.pctLogo.Location = new System.Drawing.Point(126, 57);
            this.pctLogo.Name = "pctLogo";
            this.pctLogo.Size = new System.Drawing.Size(150, 95);
            this.pctLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pctLogo.TabIndex = 21;
            this.pctLogo.TabStop = false;
            // 
            // pctFondo
            // 
            this.pctFondo.BackgroundImage = global::Vista.Properties.Resources.WoodenPlankCyan;
            this.pctFondo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pctFondo.Location = new System.Drawing.Point(0, 0);
            this.pctFondo.Name = "pctFondo";
            this.pctFondo.Size = new System.Drawing.Size(400, 400);
            this.pctFondo.TabIndex = 23;
            this.pctFondo.TabStop = false;
            // 
            // lblRecuperacion
            // 
            this.lblRecuperacion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(40)))));
            this.lblRecuperacion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblRecuperacion.Font = new System.Drawing.Font("Bahnschrift", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecuperacion.ForeColor = System.Drawing.Color.White;
            this.lblRecuperacion.Location = new System.Drawing.Point(40, 0);
            this.lblRecuperacion.Name = "lblRecuperacion";
            this.lblRecuperacion.Size = new System.Drawing.Size(320, 40);
            this.lblRecuperacion.TabIndex = 32;
            this.lblRecuperacion.Text = "Recuperación";
            this.lblRecuperacion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPreguntarecupero
            // 
            this.lblPreguntarecupero.BackColor = System.Drawing.Color.Transparent;
            this.lblPreguntarecupero.Font = new System.Drawing.Font("Bahnschrift", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPreguntarecupero.ForeColor = System.Drawing.Color.White;
            this.lblPreguntarecupero.Location = new System.Drawing.Point(0, 209);
            this.lblPreguntarecupero.Name = "lblPreguntarecupero";
            this.lblPreguntarecupero.Size = new System.Drawing.Size(400, 18);
            this.lblPreguntarecupero.TabIndex = 33;
            this.lblPreguntarecupero.Text = "Ingrese una pregunta";
            this.lblPreguntarecupero.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlBorde
            // 
            this.pnlBorde.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(40)))));
            this.pnlBorde.Controls.Add(this.lblRecuperacion);
            this.pnlBorde.Controls.Add(this.pctMinimize);
            this.pnlBorde.Controls.Add(this.pctClose);
            this.pnlBorde.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBorde.Location = new System.Drawing.Point(0, 0);
            this.pnlBorde.Name = "pnlBorde";
            this.pnlBorde.Size = new System.Drawing.Size(400, 40);
            this.pnlBorde.TabIndex = 34;
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
            this.pctClose.Location = new System.Drawing.Point(360, 0);
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
            this.pnlBordeInferior.Location = new System.Drawing.Point(0, 380);
            this.pnlBordeInferior.Name = "pnlBordeInferior";
            this.pnlBordeInferior.Size = new System.Drawing.Size(400, 20);
            this.pnlBordeInferior.TabIndex = 35;
            // 
            // frmRecupero
            // 
            this.AcceptButton = this.btnSiguienterecupero;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(400, 400);
            this.ControlBox = false;
            this.Controls.Add(this.pnlBordeInferior);
            this.Controls.Add(this.pnlBorde);
            this.Controls.Add(this.lblPreguntarecupero);
            this.Controls.Add(this.cmbpreguntasseg);
            this.Controls.Add(this.txtrespuesta);
            this.Controls.Add(this.pctLogo);
            this.Controls.Add(this.txtdni);
            this.Controls.Add(this.btnSiguienterecupero);
            this.Controls.Add(this.pctFondo);
            this.Font = new System.Drawing.Font("Bahnschrift", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRecupero";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmRecupero";
            this.Load += new System.EventHandler(this.frmRecupero_Load);
            this.Shown += new System.EventHandler(this.frmRecupero_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctFondo)).EndInit();
            this.pnlBorde.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pctMinimize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctClose)).EndInit();
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
        private System.Windows.Forms.PictureBox pctLogo;
        private System.Windows.Forms.TextBox txtdni;
        private System.Windows.Forms.Button btnSiguienterecupero;
        private System.Windows.Forms.PictureBox pctFondo;
        private System.Windows.Forms.TextBox txtrespuesta;
        private System.Windows.Forms.ComboBox cmbpreguntasseg;
        private System.IO.FileSystemWatcher fileSystemWatcher1;
        private System.Windows.Forms.Label lblRecuperacion;
        private System.Windows.Forms.Label lblPreguntarecupero;
        private System.Windows.Forms.Panel pnlBorde;
        private System.Windows.Forms.PictureBox pctMinimize;
        private System.Windows.Forms.PictureBox pctClose;
        private System.Windows.Forms.Panel pnlBordeInferior;
    }
}