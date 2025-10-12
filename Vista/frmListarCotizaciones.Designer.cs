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
            this.dvgCotizaciones = new System.Windows.Forms.DataGridView();
            this.btnEditarCotizacion = new System.Windows.Forms.Button();
            this.btnBuscarCotización = new System.Windows.Forms.Button();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.lblFiltrar = new System.Windows.Forms.Label();
            this.lblVendedor = new System.Windows.Forms.Label();
            this.lblFecha = new System.Windows.Forms.Label();
            this.lblDecripcion = new System.Windows.Forms.Label();
            this.txtVendedor = new System.Windows.Forms.TextBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.btnEliminarCotizacion = new System.Windows.Forms.Button();
            this.chkFechaActivo = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dvgCotizaciones)).BeginInit();
            this.SuspendLayout();
            // 
            // dvgCotizaciones
            // 
            this.dvgCotizaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dvgCotizaciones.Location = new System.Drawing.Point(31, 173);
            this.dvgCotizaciones.Name = "dvgCotizaciones";
            this.dvgCotizaciones.Size = new System.Drawing.Size(772, 265);
            this.dvgCotizaciones.TabIndex = 8039;
            // 
            // btnEditarCotizacion
            // 
            this.btnEditarCotizacion.BackColor = System.Drawing.Color.White;
            this.btnEditarCotizacion.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnEditarCotizacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditarCotizacion.ForeColor = System.Drawing.Color.Black;
            this.btnEditarCotizacion.Location = new System.Drawing.Point(657, 28);
            this.btnEditarCotizacion.Name = "btnEditarCotizacion";
            this.btnEditarCotizacion.Size = new System.Drawing.Size(146, 30);
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
            this.btnBuscarCotización.ForeColor = System.Drawing.Color.Black;
            this.btnBuscarCotización.Location = new System.Drawing.Point(490, 60);
            this.btnBuscarCotización.Name = "btnBuscarCotización";
            this.btnBuscarCotización.Size = new System.Drawing.Size(146, 30);
            this.btnBuscarCotización.TabIndex = 8042;
            this.btnBuscarCotización.Text = "Buscar Cotización";
            this.btnBuscarCotización.UseVisualStyleBackColor = false;
            this.btnBuscarCotización.Click += new System.EventHandler(this.btnBuscarCotización_Click);
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescripcion.Font = new System.Drawing.Font("Bahnschrift", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescripcion.ForeColor = System.Drawing.Color.Black;
            this.txtDescripcion.Location = new System.Drawing.Point(180, 28);
            this.txtDescripcion.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(271, 28);
            this.txtDescripcion.TabIndex = 8043;
            this.txtDescripcion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblFiltrar
            // 
            this.lblFiltrar.AutoSize = true;
            this.lblFiltrar.Location = new System.Drawing.Point(28, 9);
            this.lblFiltrar.Name = "lblFiltrar";
            this.lblFiltrar.Size = new System.Drawing.Size(115, 13);
            this.lblFiltrar.TabIndex = 8044;
            this.lblFiltrar.Text = "Filtrar cotizaciones por:";
            // 
            // lblVendedor
            // 
            this.lblVendedor.AutoSize = true;
            this.lblVendedor.Location = new System.Drawing.Point(56, 100);
            this.lblVendedor.Name = "lblVendedor";
            this.lblVendedor.Size = new System.Drawing.Size(53, 13);
            this.lblVendedor.TabIndex = 8045;
            this.lblVendedor.Text = "Vendedor";
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Location = new System.Drawing.Point(56, 69);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(37, 13);
            this.lblFecha.TabIndex = 8046;
            this.lblFecha.Text = "Fecha";
            // 
            // lblDecripcion
            // 
            this.lblDecripcion.AutoSize = true;
            this.lblDecripcion.Location = new System.Drawing.Point(56, 37);
            this.lblDecripcion.Name = "lblDecripcion";
            this.lblDecripcion.Size = new System.Drawing.Size(117, 13);
            this.lblDecripcion.TabIndex = 8047;
            this.lblDecripcion.Text = "Descripción del mueble";
            // 
            // txtVendedor
            // 
            this.txtVendedor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtVendedor.Font = new System.Drawing.Font("Bahnschrift", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVendedor.ForeColor = System.Drawing.Color.Black;
            this.txtVendedor.Location = new System.Drawing.Point(180, 92);
            this.txtVendedor.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.txtVendedor.Name = "txtVendedor";
            this.txtVendedor.Size = new System.Drawing.Size(271, 28);
            this.txtVendedor.TabIndex = 8049;
            this.txtVendedor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(180, 63);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 8050;
            // 
            // btnEliminarCotizacion
            // 
            this.btnEliminarCotizacion.BackColor = System.Drawing.Color.White;
            this.btnEliminarCotizacion.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnEliminarCotizacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminarCotizacion.ForeColor = System.Drawing.Color.Black;
            this.btnEliminarCotizacion.Location = new System.Drawing.Point(657, 92);
            this.btnEliminarCotizacion.Name = "btnEliminarCotizacion";
            this.btnEliminarCotizacion.Size = new System.Drawing.Size(146, 30);
            this.btnEliminarCotizacion.TabIndex = 8051;
            this.btnEliminarCotizacion.Text = "Eliminiar Cotización";
            this.btnEliminarCotizacion.UseVisualStyleBackColor = false;
            this.btnEliminarCotizacion.Click += new System.EventHandler(this.btnEliminarCotizacion_Click);
            // 
            // chkFechaActivo
            // 
            this.chkFechaActivo.AutoSize = true;
            this.chkFechaActivo.Location = new System.Drawing.Point(425, 68);
            this.chkFechaActivo.Name = "chkFechaActivo";
            this.chkFechaActivo.Size = new System.Drawing.Size(15, 14);
            this.chkFechaActivo.TabIndex = 8052;
            this.chkFechaActivo.UseVisualStyleBackColor = true;
            // 
            // frmListarCotizaciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(830, 464);
            this.Controls.Add(this.chkFechaActivo);
            this.Controls.Add(this.btnEliminarCotizacion);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.txtVendedor);
            this.Controls.Add(this.lblDecripcion);
            this.Controls.Add(this.lblFecha);
            this.Controls.Add(this.lblVendedor);
            this.Controls.Add(this.lblFiltrar);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.btnBuscarCotización);
            this.Controls.Add(this.btnEditarCotizacion);
            this.Controls.Add(this.dvgCotizaciones);
            this.Name = "frmListarCotizaciones";
            this.Text = "frmListarCotizaciones";
            ((System.ComponentModel.ISupportInitialize)(this.dvgCotizaciones)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dvgCotizaciones;
        private System.Windows.Forms.Button btnEditarCotizacion;
        private System.Windows.Forms.Button btnBuscarCotización;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Label lblFiltrar;
        private System.Windows.Forms.Label lblVendedor;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.Label lblDecripcion;
        private System.Windows.Forms.TextBox txtVendedor;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button btnEliminarCotizacion;
        private System.Windows.Forms.CheckBox chkFechaActivo;
    }
}