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
            this.txtContrasenia2 = new System.Windows.Forms.TextBox();
            this.pctLogo = new System.Windows.Forms.PictureBox();
            this.txtContrasenia1 = new System.Windows.Forms.TextBox();
            this.pctMinimize = new System.Windows.Forms.PictureBox();
            this.pctClose = new System.Windows.Forms.PictureBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.pctFondo = new System.Windows.Forms.PictureBox();
            this.pctBorde = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pctBordeInferior)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctMinimize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctFondo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctBorde)).BeginInit();
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
            // txtContrasenia2
            // 
            this.txtContrasenia2.Font = new System.Drawing.Font("Bahnschrift", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtContrasenia2.Location = new System.Drawing.Point(110, 222);
            this.txtContrasenia2.MaxLength = 25;
            this.txtContrasenia2.Name = "txtContrasenia2";
            this.txtContrasenia2.Size = new System.Drawing.Size(186, 25);
            this.txtContrasenia2.TabIndex = 16;
            // 
            // pctLogo
            // 
            this.pctLogo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pctLogo.BackColor = System.Drawing.Color.Transparent;
            this.pctLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pctLogo.Image = ((System.Drawing.Image)(resources.GetObject("pctLogo.Image")));
            this.pctLogo.Location = new System.Drawing.Point(129, 63);
            this.pctLogo.Name = "pctLogo";
            this.pctLogo.Size = new System.Drawing.Size(150, 95);
            this.pctLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pctLogo.TabIndex = 21;
            this.pctLogo.TabStop = false;
            // 
            // txtContrasenia1
            // 
            this.txtContrasenia1.BackColor = System.Drawing.Color.White;
            this.txtContrasenia1.Font = new System.Drawing.Font("Bahnschrift", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtContrasenia1.Location = new System.Drawing.Point(110, 177);
            this.txtContrasenia1.MaxLength = 25;
            this.txtContrasenia1.Name = "txtContrasenia1";
            this.txtContrasenia1.Size = new System.Drawing.Size(186, 25);
            this.txtContrasenia1.TabIndex = 15;
            this.txtContrasenia1.TextChanged += new System.EventHandler(this.txtContrasenia1_TextChanged);
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
            this.pctClose.Click += new System.EventHandler(this.pctClose_Click);
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.White;
            this.btnLogin.FlatAppearance.BorderColor = System.Drawing.Color.MidnightBlue;
            this.btnLogin.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnLogin.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.Font = new System.Drawing.Font("Bahnschrift", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.ForeColor = System.Drawing.Color.Black;
            this.btnLogin.Location = new System.Drawing.Point(110, 303);
            this.btnLogin.Margin = new System.Windows.Forms.Padding(4);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(186, 28);
            this.btnLogin.TabIndex = 18;
            this.btnLogin.Text = "Siguiente";
            this.btnLogin.UseVisualStyleBackColor = false;
            // 
            // pctFondo
            // 
            this.pctFondo.BackgroundImage = global::Vista.Properties.Resources.WoodenPlankCyan;
            this.pctFondo.Location = new System.Drawing.Point(-2, -1);
            this.pctFondo.Name = "pctFondo";
            this.pctFondo.Size = new System.Drawing.Size(405, 373);
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
            // frmRecupero
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(400, 370);
            this.ControlBox = false;
            this.Controls.Add(this.pctMinimize);
            this.Controls.Add(this.pctClose);
            this.Controls.Add(this.pctBorde);
            this.Controls.Add(this.pctBordeInferior);
            this.Controls.Add(this.txtContrasenia2);
            this.Controls.Add(this.pctLogo);
            this.Controls.Add(this.txtContrasenia1);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.pctFondo);
            this.Font = new System.Drawing.Font("Bahnschrift", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRecupero";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmRecupero";
            ((System.ComponentModel.ISupportInitialize)(this.pctBordeInferior)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctMinimize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctFondo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctBorde)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pctBordeInferior;
        private System.Windows.Forms.TextBox txtContrasenia2;
        private System.Windows.Forms.PictureBox pctLogo;
        private System.Windows.Forms.TextBox txtContrasenia1;
        private System.Windows.Forms.PictureBox pctMinimize;
        private System.Windows.Forms.PictureBox pctClose;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.PictureBox pctFondo;
        private System.Windows.Forms.PictureBox pctBorde;
    }
}