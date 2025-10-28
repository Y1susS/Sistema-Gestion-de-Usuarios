namespace Vista
{
    partial class frmBuscarPresupuesto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBuscarPresupuesto));
            this.btnBuscarPresup = new System.Windows.Forms.Button();
            this.dgvPresupuestos = new System.Windows.Forms.DataGridView();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.lblDescripcionPresup = new System.Windows.Forms.Label();
            this.lblFechaPresup = new System.Windows.Forms.Label();
            this.lblVendedorPresup = new System.Windows.Forms.Label();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.txtVendedor = new System.Windows.Forms.TextBox();
            this.btnSeleccionPresup = new System.Windows.Forms.Button();
            this.lblDocumentoPresup = new System.Windows.Forms.Label();
            this.txtDocumento = new System.Windows.Forms.TextBox();
            this.cmbTipoDni = new System.Windows.Forms.ComboBox();
            this.pnlBorde = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.pctMinimize = new System.Windows.Forms.PictureBox();
            this.pctClose = new System.Windows.Forms.PictureBox();
            this.pnlOpciones = new System.Windows.Forms.Panel();
            this.pnlBordeInferior = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPresupuestos)).BeginInit();
            this.pnlBorde.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctMinimize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctClose)).BeginInit();
            this.pnlOpciones.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnBuscarPresup
            // 

            this.btnBuscarPresup.Location = new System.Drawing.Point(65, 150);
            this.btnBuscarPresup.Name = "btnBuscarPresup";
            this.btnBuscarPresup.Size = new System.Drawing.Size(139, 30);
            this.btnBuscarPresup.TabIndex = 0;
            this.btnBuscarPresup.Text = "Buscar";
            this.btnBuscarPresup.UseVisualStyleBackColor = true;
            this.btnBuscarPresup.Click += new System.EventHandler(this.btnBuscarPresup_Click);
            this.btnBuscarPresup.Enter += new System.EventHandler(this.btnBuscarPresup_Click);
            // 
            // dgvPresupuestos
            // 
            this.dgvPresupuestos.BackgroundColor = System.Drawing.Color.White;
            this.dgvPresupuestos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;

            this.dgvPresupuestos.Location = new System.Drawing.Point(10, 245);
            this.dgvPresupuestos.Name = "dgvPresupuestos";
            this.dgvPresupuestos.RowHeadersWidth = 51;
            this.dgvPresupuestos.RowTemplate.Height = 24;
            this.dgvPresupuestos.Size = new System.Drawing.Size(750, 275);
            this.dgvPresupuestos.TabIndex = 1;
            // 
            // txtDescripcion
            // 

            this.txtDescripcion.Location = new System.Drawing.Point(5, 30);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(400, 25);
            this.txtDescripcion.TabIndex = 2;
            this.txtDescripcion.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDescripcion_KeyDown);
            // 
            // lblDescripcionPresup
            // 

            this.lblDescripcionPresup.ForeColor = System.Drawing.Color.White;
            this.lblDescripcionPresup.Location = new System.Drawing.Point(160, 5);
            this.lblDescripcionPresup.Name = "lblDescripcionPresup";
            this.lblDescripcionPresup.Size = new System.Drawing.Size(90, 25);
            this.lblDescripcionPresup.TabIndex = 6;
            this.lblDescripcionPresup.Text = "Descripción";
            this.lblDescripcionPresup.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblFechaPresup
            // 
            this.lblFechaPresup.ForeColor = System.Drawing.Color.White;
            this.lblFechaPresup.Location = new System.Drawing.Point(97, 60);
            this.lblFechaPresup.Name = "lblFechaPresup";
            this.lblFechaPresup.Size = new System.Drawing.Size(50, 25);
            this.lblFechaPresup.TabIndex = 8;
            this.lblFechaPresup.Text = "Fecha";
            this.lblFechaPresup.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblVendedorPresup
            // 

            this.lblVendedorPresup.ForeColor = System.Drawing.Color.White;
            this.lblVendedorPresup.Location = new System.Drawing.Point(77, 90);
            this.lblVendedorPresup.Name = "lblVendedorPresup";
            this.lblVendedorPresup.Size = new System.Drawing.Size(70, 25);
            this.lblVendedorPresup.TabIndex = 9;
            this.lblVendedorPresup.Text = "Vendedor";
            this.lblVendedorPresup.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dtpFecha
            // 
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;

            this.dtpFecha.Location = new System.Drawing.Point(151, 60);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(155, 25);
            this.dtpFecha.TabIndex = 10;
            // 
            // txtVendedor
            // 

            this.txtVendedor.Location = new System.Drawing.Point(151, 90);
            this.txtVendedor.Name = "txtVendedor";
            this.txtVendedor.Size = new System.Drawing.Size(175, 25);
            this.txtVendedor.TabIndex = 11;
            this.txtVendedor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtVendedor_KeyDown);
            // 
            // btnSeleccionPresup
            // 

            this.btnSeleccionPresup.Location = new System.Drawing.Point(208, 150);
            this.btnSeleccionPresup.Name = "btnSeleccionPresup";
            this.btnSeleccionPresup.Size = new System.Drawing.Size(139, 30);
            this.btnSeleccionPresup.TabIndex = 12;
            this.btnSeleccionPresup.Text = "Seleccionar";
            this.btnSeleccionPresup.UseVisualStyleBackColor = true;
            this.btnSeleccionPresup.Click += new System.EventHandler(this.btnSeleccionPresup_Click);
            // 
            // lblDocumentoPresup
            // 

            this.lblDocumentoPresup.ForeColor = System.Drawing.Color.White;
            this.lblDocumentoPresup.Location = new System.Drawing.Point(64, 120);
            this.lblDocumentoPresup.Name = "lblDocumentoPresup";
            this.lblDocumentoPresup.Size = new System.Drawing.Size(83, 25);
            this.lblDocumentoPresup.TabIndex = 13;
            this.lblDocumentoPresup.Text = "Documento";
            this.lblDocumentoPresup.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtDocumento
            // 

            this.txtDocumento.Location = new System.Drawing.Point(222, 120);
            this.txtDocumento.Name = "txtDocumento";
            this.txtDocumento.Size = new System.Drawing.Size(125, 25);
            this.txtDocumento.TabIndex = 14;
            this.txtDocumento.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtDocumento.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDocumento_KeyDown);
            // 
            // cmbTipoDni
            // 
            this.cmbTipoDni.FormattingEnabled = true;

            this.cmbTipoDni.Location = new System.Drawing.Point(151, 120);
            this.cmbTipoDni.Name = "cmbTipoDni";
            this.cmbTipoDni.Size = new System.Drawing.Size(65, 26);
            this.cmbTipoDni.TabIndex = 15;
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
            this.pnlBorde.Size = new System.Drawing.Size(770, 40);
            this.pnlBorde.TabIndex = 8046;
            // 
            // lblTitulo
            // 
            this.lblTitulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(40)))));
            this.lblTitulo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitulo.Font = new System.Drawing.Font("Bahnschrift", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(40, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(690, 40);
            this.lblTitulo.TabIndex = 23;
            this.lblTitulo.Text = "Buscar presupuesto";
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
            this.pctMinimize.Click += new System.EventHandler(this.pctMinimize_Click);
            // 
            // pctClose
            // 
            this.pctClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(40)))));
            this.pctClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pctClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.pctClose.Image = ((System.Drawing.Image)(resources.GetObject("pctClose.Image")));
            this.pctClose.Location = new System.Drawing.Point(730, 0);
            this.pctClose.Name = "pctClose";
            this.pctClose.Size = new System.Drawing.Size(40, 40);
            this.pctClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pctClose.TabIndex = 20;
            this.pctClose.TabStop = false;
            this.pctClose.Click += new System.EventHandler(this.pctClose_Click);
            // 
            // pnlOpciones
            // 
            this.pnlOpciones.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(40)))));
            this.pnlOpciones.Controls.Add(this.lblDescripcionPresup);
            this.pnlOpciones.Controls.Add(this.btnBuscarPresup);
            this.pnlOpciones.Controls.Add(this.cmbTipoDni);
            this.pnlOpciones.Controls.Add(this.txtDescripcion);
            this.pnlOpciones.Controls.Add(this.btnSeleccionPresup);
            this.pnlOpciones.Controls.Add(this.txtDocumento);
            this.pnlOpciones.Controls.Add(this.lblFechaPresup);
            this.pnlOpciones.Controls.Add(this.lblDocumentoPresup);
            this.pnlOpciones.Controls.Add(this.lblVendedorPresup);
            this.pnlOpciones.Controls.Add(this.dtpFecha);
            this.pnlOpciones.Controls.Add(this.txtVendedor);
            this.pnlOpciones.Location = new System.Drawing.Point(180, 50);
            this.pnlOpciones.Name = "pnlOpciones";
            this.pnlOpciones.Size = new System.Drawing.Size(410, 185);
            this.pnlOpciones.TabIndex = 8047;
            this.pnlOpciones.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlOpciones_Paint);
            // 
            // pnlBordeInferior
            // 
            this.pnlBordeInferior.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(40)))));
            this.pnlBordeInferior.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBordeInferior.Location = new System.Drawing.Point(0, 530);
            this.pnlBordeInferior.Name = "pnlBordeInferior";
            this.pnlBordeInferior.Size = new System.Drawing.Size(770, 20);
            this.pnlBordeInferior.TabIndex = 8048;
            // 
            // frmBuscarPresupuesto
            // 

            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Vista.Properties.Resources.WoodenPlankCyan;
            this.ClientSize = new System.Drawing.Size(770, 550);
            this.Controls.Add(this.pnlBordeInferior);
            this.Controls.Add(this.pnlOpciones);
            this.Controls.Add(this.pnlBorde);
            this.Controls.Add(this.dgvPresupuestos);
            this.Font = new System.Drawing.Font("Bahnschrift", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmBuscarPresupuesto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmBuscarPresupuesto";
            ((System.ComponentModel.ISupportInitialize)(this.dgvPresupuestos)).EndInit();
            this.pnlBorde.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pctMinimize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctClose)).EndInit();
            this.pnlOpciones.ResumeLayout(false);
            this.pnlOpciones.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnBuscarPresup;
        private System.Windows.Forms.DataGridView dgvPresupuestos;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Label lblDescripcionPresup;
        private System.Windows.Forms.Label lblFechaPresup;
        private System.Windows.Forms.Label lblVendedorPresup;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.TextBox txtVendedor;
        private System.Windows.Forms.Button btnSeleccionPresup;
        private System.Windows.Forms.Label lblDocumentoPresup;
        private System.Windows.Forms.TextBox txtDocumento;
        private System.Windows.Forms.ComboBox cmbTipoDni;
        private System.Windows.Forms.Panel pnlBorde;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.PictureBox pctMinimize;
        private System.Windows.Forms.PictureBox pctClose;
        private System.Windows.Forms.Panel pnlOpciones;
        private System.Windows.Forms.Panel pnlBordeInferior;
    }
}