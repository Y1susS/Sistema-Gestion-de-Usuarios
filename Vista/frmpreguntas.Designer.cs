﻿namespace Vista
{
    partial class frmPreguntas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPreguntas));
            this.lblInstrucciones = new System.Windows.Forms.Label();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.txtRespuesta1 = new System.Windows.Forms.TextBox();
            this.txtRespuesta2 = new System.Windows.Forms.TextBox();
            this.txtRespuesta3 = new System.Windows.Forms.TextBox();
            this.btnSiguiente = new System.Windows.Forms.Button();
            this.txtrespuestas = new System.Windows.Forms.Label();
            this.cmbPregunta1 = new System.Windows.Forms.ComboBox();
            this.cmbPregunta2 = new System.Windows.Forms.ComboBox();
            this.cmbPregunta3 = new System.Windows.Forms.ComboBox();
            this.lblPreguntas = new System.Windows.Forms.Label();
            this.btnvolver = new System.Windows.Forms.Button();
            this.pctClose = new System.Windows.Forms.PictureBox();
            this.pctMinimize = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pctClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctMinimize)).BeginInit();
            this.SuspendLayout();
            // 
            // lblInstrucciones
            // 
            this.lblInstrucciones.AutoSize = true;
            this.lblInstrucciones.Location = new System.Drawing.Point(12, 96);
            this.lblInstrucciones.Name = "lblInstrucciones";
            this.lblInstrucciones.Size = new System.Drawing.Size(70, 13);
            this.lblInstrucciones.TabIndex = 1;
            this.lblInstrucciones.Text = "Instrucciones";
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Location = new System.Drawing.Point(198, 34);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(43, 13);
            this.lblUsuario.TabIndex = 2;
            this.lblUsuario.Text = "Usuario";
            this.lblUsuario.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtRespuesta1
            // 
            this.txtRespuesta1.Location = new System.Drawing.Point(399, 192);
            this.txtRespuesta1.Name = "txtRespuesta1";
            this.txtRespuesta1.Size = new System.Drawing.Size(173, 20);
            this.txtRespuesta1.TabIndex = 2;
            // 
            // txtRespuesta2
            // 
            this.txtRespuesta2.Location = new System.Drawing.Point(399, 231);
            this.txtRespuesta2.Name = "txtRespuesta2";
            this.txtRespuesta2.Size = new System.Drawing.Size(173, 20);
            this.txtRespuesta2.TabIndex = 4;
            // 
            // txtRespuesta3
            // 
            this.txtRespuesta3.Location = new System.Drawing.Point(399, 271);
            this.txtRespuesta3.Name = "txtRespuesta3";
            this.txtRespuesta3.Size = new System.Drawing.Size(173, 20);
            this.txtRespuesta3.TabIndex = 6;
            // 
            // btnSiguiente
            // 
            this.btnSiguiente.Location = new System.Drawing.Point(265, 348);
            this.btnSiguiente.Name = "btnSiguiente";
            this.btnSiguiente.Size = new System.Drawing.Size(156, 22);
            this.btnSiguiente.TabIndex = 7;
            this.btnSiguiente.Text = "Siguiente";
            this.btnSiguiente.UseVisualStyleBackColor = true;
            this.btnSiguiente.Click += new System.EventHandler(this.btnsiguiente_Click);
            // 
            // txtrespuestas
            // 
            this.txtrespuestas.AutoSize = true;
            this.txtrespuestas.Location = new System.Drawing.Point(446, 156);
            this.txtrespuestas.Name = "txtrespuestas";
            this.txtrespuestas.Size = new System.Drawing.Size(63, 13);
            this.txtrespuestas.TabIndex = 8;
            this.txtrespuestas.Text = "Respuestas";
            // 
            // cmbPregunta1
            // 
            this.cmbPregunta1.FormattingEnabled = true;
            this.cmbPregunta1.Location = new System.Drawing.Point(48, 192);
            this.cmbPregunta1.Name = "cmbPregunta1";
            this.cmbPregunta1.Size = new System.Drawing.Size(235, 21);
            this.cmbPregunta1.TabIndex = 1;
            // 
            // cmbPregunta2
            // 
            this.cmbPregunta2.FormattingEnabled = true;
            this.cmbPregunta2.Location = new System.Drawing.Point(48, 231);
            this.cmbPregunta2.Name = "cmbPregunta2";
            this.cmbPregunta2.Size = new System.Drawing.Size(235, 21);
            this.cmbPregunta2.TabIndex = 3;
            // 
            // cmbPregunta3
            // 
            this.cmbPregunta3.FormattingEnabled = true;
            this.cmbPregunta3.Location = new System.Drawing.Point(48, 271);
            this.cmbPregunta3.Name = "cmbPregunta3";
            this.cmbPregunta3.Size = new System.Drawing.Size(235, 21);
            this.cmbPregunta3.TabIndex = 5;
            // 
            // lblPreguntas
            // 
            this.lblPreguntas.AutoSize = true;
            this.lblPreguntas.Location = new System.Drawing.Point(127, 156);
            this.lblPreguntas.Name = "lblPreguntas";
            this.lblPreguntas.Size = new System.Drawing.Size(55, 13);
            this.lblPreguntas.TabIndex = 12;
            this.lblPreguntas.Text = "Preguntas";
            // 
            // btnvolver
            // 
            this.btnvolver.Location = new System.Drawing.Point(265, 377);
            this.btnvolver.Name = "btnvolver";
            this.btnvolver.Size = new System.Drawing.Size(156, 22);
            this.btnvolver.TabIndex = 8;
            this.btnvolver.Text = "Volver";
            this.btnvolver.UseVisualStyleBackColor = true;
            this.btnvolver.Click += new System.EventHandler(this.btnvolver_Click);
            // 
            // pctClose
            // 
            this.pctClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(40)))));
            this.pctClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pctClose.Image = ((System.Drawing.Image)(resources.GetObject("pctClose.Image")));
            this.pctClose.Location = new System.Drawing.Point(748, 7);
            this.pctClose.Name = "pctClose";
            this.pctClose.Size = new System.Drawing.Size(40, 40);
            this.pctClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pctClose.TabIndex = 19;
            this.pctClose.TabStop = false;
            this.pctClose.Click += new System.EventHandler(this.pctClose_Click);
            // 
            // pctMinimize
            // 
            this.pctMinimize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(40)))));
            this.pctMinimize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pctMinimize.Image = ((System.Drawing.Image)(resources.GetObject("pctMinimize.Image")));
            this.pctMinimize.Location = new System.Drawing.Point(12, 7);
            this.pctMinimize.Name = "pctMinimize";
            this.pctMinimize.Size = new System.Drawing.Size(40, 40);
            this.pctMinimize.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pctMinimize.TabIndex = 21;
            this.pctMinimize.TabStop = false;
            this.pctMinimize.Click += new System.EventHandler(this.pctMinimize_Click);
            // 
            // frmPreguntas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pctMinimize);
            this.Controls.Add(this.pctClose);
            this.Controls.Add(this.btnvolver);
            this.Controls.Add(this.lblPreguntas);
            this.Controls.Add(this.cmbPregunta3);
            this.Controls.Add(this.cmbPregunta2);
            this.Controls.Add(this.cmbPregunta1);
            this.Controls.Add(this.txtrespuestas);
            this.Controls.Add(this.btnSiguiente);
            this.Controls.Add(this.txtRespuesta3);
            this.Controls.Add(this.txtRespuesta2);
            this.Controls.Add(this.txtRespuesta1);
            this.Controls.Add(this.lblUsuario);
            this.Controls.Add(this.lblInstrucciones);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmPreguntas";
            this.Text = "Preguntas de seguridad";
            this.Load += new System.EventHandler(this.frmPreguntas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pctClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctMinimize)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblInstrucciones;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.TextBox txtRespuesta1;
        private System.Windows.Forms.TextBox txtRespuesta2;
        private System.Windows.Forms.TextBox txtRespuesta3;
        private System.Windows.Forms.Button btnSiguiente;
        private System.Windows.Forms.Label txtrespuestas;
        private System.Windows.Forms.ComboBox cmbPregunta1;
        private System.Windows.Forms.ComboBox cmbPregunta2;
        private System.Windows.Forms.ComboBox cmbPregunta3;
        private System.Windows.Forms.Label lblPreguntas;
        private System.Windows.Forms.Button btnvolver;
        private System.Windows.Forms.PictureBox pctClose;
        private System.Windows.Forms.PictureBox pctMinimize;
    }
}