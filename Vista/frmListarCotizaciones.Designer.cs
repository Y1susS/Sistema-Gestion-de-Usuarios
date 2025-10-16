namespace Vista
{
    partial class frmListarCotizaciones
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmListarCotizaciones));
            this.dvgCotizaciones = new System.Windows.Forms.DataGridView();
            this.btnEditarCotizacion = new System.Windows.Forms.Button();
            this.btnBuscarCotización = new System.Windows.Forms.Button();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.lblFiltrar = new System.Windows.Forms.Label();
            this.lblVendedor = new System.Windows.Forms.Label();
            this.lblDecripcion = new System.Windows.Forms.Label();
            this.txtVendedor = new System.Windows.Forms.TextBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.btnEliminarCotizacion = new System.Windows.Forms.Button();
            this.chkFechaActivo = new System.Windows.Forms.CheckBox();
            this.pnlBordeInferior = new System.Windows.Forms.Panel();
            this.pnlBorde = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.pctMinimize = new System.Windows.Forms.PictureBox();
            this.pctClose = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dvgCotizaciones)).BeginInit();
            this.pnlBorde.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctMinimize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctClose)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dvgCotizaciones
            // 
            this.dvgCotizaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dvgCotizaciones.Location = new System.Drawing.Point(15, 248);
            this.dvgCotizaciones.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dvgCotizaciones.Name = "dvgCotizaciones";
            this.dvgCotizaciones.Size = new System.Drawing.Size(778, 324);
            this.dvgCotizaciones.TabIndex = 8039;
            // 
            // btnEditarCotizacion
            // 
            this.btnEditarCotizacion.BackColor = System.Drawing.Color.White;
            this.btnEditarCotizacion.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnEditarCotizacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditarCotizacion.Font = new System.Drawing.Font("Bahnschrift", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditarCotizacion.ForeColor = System.Drawing.Color.Black;
            this.btnEditarCotizacion.Location = new System.Drawing.Point(553, 79);
            this.btnEditarCotizacion.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnEditarCotizacion.Name = "btnEditarCotizacion";
            this.btnEditarCotizacion.Size = new System.Drawing.Size(158, 33);
            this.btnEditarCotizacion.TabIndex = 8040;
            this.btnEditarCotizacion.Text = "Editar Cotizacion";
            this.btnEditarCotizacion.UseVisualStyleBackColor = false;
            this.btnEditarCotizacion.Click += new System.EventHandler(this.btnEditarCotizacion_Click);
            // 
            // btnBuscarCotización
            // 
            this.btnBuscarCotización.BackColor = System.Drawing.Color.White;
            this.btnBuscarCotización.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnBuscarCotización.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscarCotización.Font = new System.Drawing.Font("Bahnschrift", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscarCotización.ForeColor = System.Drawing.Color.Black;
            this.btnBuscarCotización.Location = new System.Drawing.Point(553, 41);
            this.btnBuscarCotización.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnBuscarCotización.Name = "btnBuscarCotización";
            this.btnBuscarCotización.Size = new System.Drawing.Size(158, 33);
            this.btnBuscarCotización.TabIndex = 8042;
            this.btnBuscarCotización.Text = "Buscar Cotización";
            this.btnBuscarCotización.UseVisualStyleBackColor = false;
            this.btnBuscarCotización.Click += new System.EventHandler(this.btnBuscarCotización_Click);
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescripcion.Font = new System.Drawing.Font("Bahnschrift", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescripcion.ForeColor = System.Drawing.Color.Black;
            this.txtDescripcion.Location = new System.Drawing.Point(180, 50);
            this.txtDescripcion.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(350, 25);
            this.txtDescripcion.TabIndex = 8043;
            this.txtDescripcion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblFiltrar
            // 
            this.lblFiltrar.Font = new System.Drawing.Font("Bahnschrift", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFiltrar.Location = new System.Drawing.Point(0, 10);
            this.lblFiltrar.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFiltrar.Name = "lblFiltrar";
            this.lblFiltrar.Size = new System.Drawing.Size(778, 25);
            this.lblFiltrar.TabIndex = 8044;
            this.lblFiltrar.Text = "Filtrar cotizaciones por :";
            this.lblFiltrar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblVendedor
            // 
            this.lblVendedor.Font = new System.Drawing.Font("Bahnschrift", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVendedor.Location = new System.Drawing.Point(101, 120);
            this.lblVendedor.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblVendedor.Name = "lblVendedor";
            this.lblVendedor.Size = new System.Drawing.Size(70, 25);
            this.lblVendedor.TabIndex = 8045;
            this.lblVendedor.Text = "Vendedor";
            this.lblVendedor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDecripcion
            // 
            this.lblDecripcion.Font = new System.Drawing.Font("Bahnschrift", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDecripcion.Location = new System.Drawing.Point(10, 50);
            this.lblDecripcion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDecripcion.Name = "lblDecripcion";
            this.lblDecripcion.Size = new System.Drawing.Size(163, 25);
            this.lblDecripcion.TabIndex = 8047;
            this.lblDecripcion.Text = "Descripción del mueble";
            this.lblDecripcion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtVendedor
            // 
            this.txtVendedor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtVendedor.Font = new System.Drawing.Font("Bahnschrift", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVendedor.ForeColor = System.Drawing.Color.Black;
            this.txtVendedor.Location = new System.Drawing.Point(180, 120);
            this.txtVendedor.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.txtVendedor.Name = "txtVendedor";
            this.txtVendedor.Size = new System.Drawing.Size(350, 25);
            this.txtVendedor.TabIndex = 8049;
            this.txtVendedor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Font = new System.Drawing.Font("Bahnschrift", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Location = new System.Drawing.Point(180, 85);
            this.dateTimePicker1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(265, 25);
            this.dateTimePicker1.TabIndex = 8050;
            // 
            // btnEliminarCotizacion
            // 
            this.btnEliminarCotizacion.BackColor = System.Drawing.Color.White;
            this.btnEliminarCotizacion.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnEliminarCotizacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminarCotizacion.Font = new System.Drawing.Font("Bahnschrift", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminarCotizacion.ForeColor = System.Drawing.Color.Black;
            this.btnEliminarCotizacion.Location = new System.Drawing.Point(553, 120);
            this.btnEliminarCotizacion.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnEliminarCotizacion.Name = "btnEliminarCotizacion";
            this.btnEliminarCotizacion.Size = new System.Drawing.Size(158, 33);
            this.btnEliminarCotizacion.TabIndex = 8051;
            this.btnEliminarCotizacion.Text = "Eliminiar Cotización";
            this.btnEliminarCotizacion.UseVisualStyleBackColor = false;
            this.btnEliminarCotizacion.Click += new System.EventHandler(this.btnEliminarCotizacion_Click);
            // 
            // chkFechaActivo
            // 
            this.chkFechaActivo.Font = new System.Drawing.Font("Bahnschrift", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkFechaActivo.Location = new System.Drawing.Point(106, 85);
            this.chkFechaActivo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkFechaActivo.Name = "chkFechaActivo";
            this.chkFechaActivo.Size = new System.Drawing.Size(66, 25);
            this.chkFechaActivo.TabIndex = 8052;
            this.chkFechaActivo.Text = "Fecha";
            this.chkFechaActivo.UseVisualStyleBackColor = true;
            // 
            // pnlBordeInferior
            // 
            this.pnlBordeInferior.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(40)))));
            this.pnlBordeInferior.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBordeInferior.Location = new System.Drawing.Point(0, 587);
            this.pnlBordeInferior.Name = "pnlBordeInferior";
            this.pnlBordeInferior.Size = new System.Drawing.Size(808, 20);
            this.pnlBordeInferior.TabIndex = 8054;
            // 
            // pnlBorde
            // 
            this.pnlBorde.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(40)))));
            this.pnlBorde.Controls.Add(this.lblTitulo);
            this.pnlBorde.Controls.Add(this.pctMinimize);
            this.pnlBorde.Controls.Add(this.pctClose);
            this.pnlBorde.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBorde.Location = new System.Drawing.Point(0, 0);
            this.pnlBorde.Name = "pnlBorde";
            this.pnlBorde.Size = new System.Drawing.Size(808, 40);
            this.pnlBorde.TabIndex = 8053;
            // 
            // lblTitulo
            // 
            this.lblTitulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(40)))));
            this.lblTitulo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitulo.Font = new System.Drawing.Font("Bahnschrift", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(40, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(728, 40);
            this.lblTitulo.TabIndex = 15;
            this.lblTitulo.Text = "Login";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            // 
            // pctClose
            // 
            this.pctClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(40)))));
            this.pctClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pctClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.pctClose.Image = ((System.Drawing.Image)(resources.GetObject("pctClose.Image")));
            this.pctClose.Location = new System.Drawing.Point(768, 0);
            this.pctClose.Name = "pctClose";
            this.pctClose.Size = new System.Drawing.Size(40, 40);
            this.pctClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pctClose.TabIndex = 20;
            this.pctClose.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnEliminarCotizacion);
            this.panel1.Controls.Add(this.btnEditarCotizacion);
            this.panel1.Controls.Add(this.btnBuscarCotización);
            this.panel1.Controls.Add(this.chkFechaActivo);
            this.panel1.Controls.Add(this.txtDescripcion);
            this.panel1.Controls.Add(this.lblFiltrar);
            this.panel1.Controls.Add(this.dateTimePicker1);
            this.panel1.Controls.Add(this.lblVendedor);
            this.panel1.Controls.Add(this.txtVendedor);
            this.panel1.Controls.Add(this.lblDecripcion);
            this.panel1.Location = new System.Drawing.Point(15, 55);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(778, 167);
            this.panel1.TabIndex = 8055;
            // 
            // frmListarCotizaciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(808, 607);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlBordeInferior);
            this.Controls.Add(this.pnlBorde);
            this.Controls.Add(this.dvgCotizaciones);
            this.Font = new System.Drawing.Font("Bahnschrift", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmListarCotizaciones";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmListarCotizaciones";
            this.Load += new System.EventHandler(this.frmListarCotizaciones_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.dvgCotizaciones)).EndInit();
            this.pnlBorde.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pctMinimize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctClose)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dvgCotizaciones;
        private System.Windows.Forms.Button btnEditarCotizacion;
        private System.Windows.Forms.Button btnBuscarCotización;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Label lblFiltrar;
        private System.Windows.Forms.Label lblVendedor;
        private System.Windows.Forms.Label lblDecripcion;
        private System.Windows.Forms.TextBox txtVendedor;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button btnEliminarCotizacion;
        private System.Windows.Forms.CheckBox chkFechaActivo;
        private System.Windows.Forms.Panel pnlBordeInferior;
        private System.Windows.Forms.Panel pnlBorde;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.PictureBox pctMinimize;
        private System.Windows.Forms.PictureBox pctClose;
        private System.Windows.Forms.Panel panel1;
    }
}