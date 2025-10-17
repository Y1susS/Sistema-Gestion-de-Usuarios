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
            this.btnBuscarPresup = new System.Windows.Forms.Button();
            this.dgvPresupuestos = new System.Windows.Forms.DataGridView();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.lblDescripcionPresup = new System.Windows.Forms.Label();
            this.lblFiltrarpor = new System.Windows.Forms.Label();
            this.lblFechaPresup = new System.Windows.Forms.Label();
            this.lblVendedorPresup = new System.Windows.Forms.Label();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.txtVendedor = new System.Windows.Forms.TextBox();
            this.btnSeleccionPresup = new System.Windows.Forms.Button();
            this.lblDocumentoPresup = new System.Windows.Forms.Label();
            this.txtDocumento = new System.Windows.Forms.TextBox();
            this.cmbTipoDni = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPresupuestos)).BeginInit();
            this.SuspendLayout();
            // 
            // btnBuscarPresup
            // 
            this.btnBuscarPresup.Location = new System.Drawing.Point(648, 79);
            this.btnBuscarPresup.Name = "btnBuscarPresup";
            this.btnBuscarPresup.Size = new System.Drawing.Size(75, 23);
            this.btnBuscarPresup.TabIndex = 0;
            this.btnBuscarPresup.Text = "Buscar";
            this.btnBuscarPresup.UseVisualStyleBackColor = true;
            this.btnBuscarPresup.Click += new System.EventHandler(this.btnBuscarPresup_Click);
            this.btnBuscarPresup.Enter += new System.EventHandler(this.btnBuscarPresup_Click);
            // 
            // dgvPresupuestos
            // 
            this.dgvPresupuestos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPresupuestos.Location = new System.Drawing.Point(38, 202);
            this.dgvPresupuestos.Name = "dgvPresupuestos";
            this.dgvPresupuestos.RowHeadersWidth = 51;
            this.dgvPresupuestos.RowTemplate.Height = 24;
            this.dgvPresupuestos.Size = new System.Drawing.Size(803, 236);
            this.dgvPresupuestos.TabIndex = 1;
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(311, 60);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(233, 22);
            this.txtDescripcion.TabIndex = 2;
            this.txtDescripcion.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDescripcion_KeyDown);
            // 
            // lblDescripcionPresup
            // 
            this.lblDescripcionPresup.AutoSize = true;
            this.lblDescripcionPresup.Location = new System.Drawing.Point(127, 66);
            this.lblDescripcionPresup.Name = "lblDescripcionPresup";
            this.lblDescripcionPresup.Size = new System.Drawing.Size(79, 16);
            this.lblDescripcionPresup.TabIndex = 6;
            this.lblDescripcionPresup.Text = "Descripcion";
            // 
            // lblFiltrarpor
            // 
            this.lblFiltrarpor.AutoSize = true;
            this.lblFiltrarpor.Location = new System.Drawing.Point(95, 26);
            this.lblFiltrarpor.Name = "lblFiltrarpor";
            this.lblFiltrarpor.Size = new System.Drawing.Size(152, 16);
            this.lblFiltrarpor.TabIndex = 7;
            this.lblFiltrarpor.Text = "Filtrar Presupuestos por:";
            // 
            // lblFechaPresup
            // 
            this.lblFechaPresup.AutoSize = true;
            this.lblFechaPresup.Location = new System.Drawing.Point(140, 100);
            this.lblFechaPresup.Name = "lblFechaPresup";
            this.lblFechaPresup.Size = new System.Drawing.Size(45, 16);
            this.lblFechaPresup.TabIndex = 8;
            this.lblFechaPresup.Text = "Fecha";
            // 
            // lblVendedorPresup
            // 
            this.lblVendedorPresup.AutoSize = true;
            this.lblVendedorPresup.Location = new System.Drawing.Point(127, 132);
            this.lblVendedorPresup.Name = "lblVendedorPresup";
            this.lblVendedorPresup.Size = new System.Drawing.Size(67, 16);
            this.lblVendedorPresup.TabIndex = 9;
            this.lblVendedorPresup.Text = "Vendedor";
            // 
            // dtpFecha
            // 
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(311, 93);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(112, 22);
            this.dtpFecha.TabIndex = 10;
            // 
            // txtVendedor
            // 
            this.txtVendedor.Location = new System.Drawing.Point(311, 132);
            this.txtVendedor.Name = "txtVendedor";
            this.txtVendedor.Size = new System.Drawing.Size(233, 22);
            this.txtVendedor.TabIndex = 11;
            this.txtVendedor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtVendedor_KeyDown);
            // 
            // btnSeleccionPresup
            // 
            this.btnSeleccionPresup.Location = new System.Drawing.Point(648, 125);
            this.btnSeleccionPresup.Name = "btnSeleccionPresup";
            this.btnSeleccionPresup.Size = new System.Drawing.Size(75, 23);
            this.btnSeleccionPresup.TabIndex = 12;
            this.btnSeleccionPresup.Text = "Seleccionar";
            this.btnSeleccionPresup.UseVisualStyleBackColor = true;
            this.btnSeleccionPresup.Click += new System.EventHandler(this.btnSeleccionPresup_Click);
            // 
            // lblDocumentoPresup
            // 
            this.lblDocumentoPresup.AutoSize = true;
            this.lblDocumentoPresup.Location = new System.Drawing.Point(127, 166);
            this.lblDocumentoPresup.Name = "lblDocumentoPresup";
            this.lblDocumentoPresup.Size = new System.Drawing.Size(76, 16);
            this.lblDocumentoPresup.TabIndex = 13;
            this.lblDocumentoPresup.Text = "Documento";
            // 
            // txtDocumento
            // 
            this.txtDocumento.Location = new System.Drawing.Point(373, 163);
            this.txtDocumento.Name = "txtDocumento";
            this.txtDocumento.Size = new System.Drawing.Size(118, 22);
            this.txtDocumento.TabIndex = 14;
            this.txtDocumento.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtDocumento.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDocumento_KeyDown);
            // 
            // cmbTipoDni
            // 
            this.cmbTipoDni.FormattingEnabled = true;
            this.cmbTipoDni.Location = new System.Drawing.Point(311, 163);
            this.cmbTipoDni.Name = "cmbTipoDni";
            this.cmbTipoDni.Size = new System.Drawing.Size(56, 24);
            this.cmbTipoDni.TabIndex = 15;
            // 
            // frmBuscarPresupuesto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(876, 449);
            this.Controls.Add(this.cmbTipoDni);
            this.Controls.Add(this.txtDocumento);
            this.Controls.Add(this.lblDocumentoPresup);
            this.Controls.Add(this.btnSeleccionPresup);
            this.Controls.Add(this.txtVendedor);
            this.Controls.Add(this.dtpFecha);
            this.Controls.Add(this.lblVendedorPresup);
            this.Controls.Add(this.lblFechaPresup);
            this.Controls.Add(this.lblFiltrarpor);
            this.Controls.Add(this.lblDescripcionPresup);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.dgvPresupuestos);
            this.Controls.Add(this.btnBuscarPresup);
            this.Name = "frmBuscarPresupuesto";
            this.Text = "frmBuscarPresupuesto";
            ((System.ComponentModel.ISupportInitialize)(this.dgvPresupuestos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBuscarPresup;
        private System.Windows.Forms.DataGridView dgvPresupuestos;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Label lblDescripcionPresup;
        private System.Windows.Forms.Label lblFiltrarpor;
        private System.Windows.Forms.Label lblFechaPresup;
        private System.Windows.Forms.Label lblVendedorPresup;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.TextBox txtVendedor;
        private System.Windows.Forms.Button btnSeleccionPresup;
        private System.Windows.Forms.Label lblDocumentoPresup;
        private System.Windows.Forms.TextBox txtDocumento;
        private System.Windows.Forms.ComboBox cmbTipoDni;
    }
}