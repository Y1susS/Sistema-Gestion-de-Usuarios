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
            this.lblFiltrarcot = new System.Windows.Forms.Label();
            this.lblVendedor = new System.Windows.Forms.Label();

            this.lblDecripcion = new System.Windows.Forms.Label();
            this.txtVendedor = new System.Windows.Forms.TextBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.btnEliminarCotizacion = new System.Windows.Forms.Button();
            this.chkFechaActivo = new System.Windows.Forms.CheckBox();
            this.pnlOpciones = new System.Windows.Forms.Panel();
            this.pnlFiltrarCotizaciones = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dvgCotizaciones)).BeginInit();
            this.pnlOpciones.SuspendLayout();
            this.pnlFiltrarCotizaciones.SuspendLayout();
            this.SuspendLayout();
            // 
            // dvgCotizaciones
            // 
            this.dvgCotizaciones.BackgroundColor = System.Drawing.Color.White;
            this.dvgCotizaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dvgCotizaciones.Location = new System.Drawing.Point(10, 220);
            this.dvgCotizaciones.Margin = new System.Windows.Forms.Padding(4);
            this.dvgCotizaciones.Name = "dvgCotizaciones";
            this.dvgCotizaciones.Size = new System.Drawing.Size(880, 370);
            this.dvgCotizaciones.TabIndex = 8039;
            // 
            // btnEditarCotizacion
            // 
            this.btnEditarCotizacion.BackColor = System.Drawing.Color.White;
            this.btnEditarCotizacion.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnEditarCotizacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditarCotizacion.Font = new System.Drawing.Font("Bahnschrift", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditarCotizacion.ForeColor = System.Drawing.Color.Black;
            this.btnEditarCotizacion.Location = new System.Drawing.Point(558, 59);
            this.btnEditarCotizacion.Margin = new System.Windows.Forms.Padding(4);
            this.btnEditarCotizacion.Name = "btnEditarCotizacion";
            this.btnEditarCotizacion.Size = new System.Drawing.Size(158, 33);
            this.btnEditarCotizacion.TabIndex = 8040;
            this.btnEditarCotizacion.Text = "Editar cotizacion";
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
            this.btnBuscarCotización.Location = new System.Drawing.Point(558, 21);
            this.btnBuscarCotización.Margin = new System.Windows.Forms.Padding(4);
            this.btnBuscarCotización.Name = "btnBuscarCotización";
            this.btnBuscarCotización.Size = new System.Drawing.Size(158, 33);
            this.btnBuscarCotización.TabIndex = 8042;
            this.btnBuscarCotización.Text = "Buscar cotización";
            this.btnBuscarCotización.UseVisualStyleBackColor = false;
            this.btnBuscarCotización.Click += new System.EventHandler(this.btnBuscarCotización_Click);
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescripcion.Font = new System.Drawing.Font("Bahnschrift", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescripcion.ForeColor = System.Drawing.Color.Black;
            this.txtDescripcion.Location = new System.Drawing.Point(185, 30);
            this.txtDescripcion.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(355, 25);
            this.txtDescripcion.TabIndex = 8043;
            this.txtDescripcion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblFiltrarcot
            // 

            this.lblFiltrar.Font = new System.Drawing.Font("Bahnschrift", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFiltrar.ForeColor = System.Drawing.Color.White;
            this.lblFiltrar.Location = new System.Drawing.Point(1, 7);
            this.lblFiltrar.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFiltrar.Name = "lblFiltrar";
            this.lblFiltrar.Size = new System.Drawing.Size(733, 25);
            this.lblFiltrar.TabIndex = 8044;
            this.lblFiltrar.Text = "Filtrar cotizaciones por :";
            this.lblFiltrar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblVendedor
            // 
            this.lblVendedor.Font = new System.Drawing.Font("Bahnschrift", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVendedor.ForeColor = System.Drawing.Color.White;
            this.lblVendedor.Location = new System.Drawing.Point(106, 100);
            this.lblVendedor.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblVendedor.Name = "lblVendedor";
            this.lblVendedor.Size = new System.Drawing.Size(70, 25);
            this.lblVendedor.TabIndex = 8045;
            this.lblVendedor.Text = "Vendedor";

            this.lblVendedor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDecripcionmueble
            // 

            this.lblDecripcion.Font = new System.Drawing.Font("Bahnschrift", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDecripcion.ForeColor = System.Drawing.Color.White;
            this.lblDecripcion.Location = new System.Drawing.Point(15, 30);
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
            this.txtVendedor.Location = new System.Drawing.Point(185, 100);
            this.txtVendedor.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.txtVendedor.Name = "txtVendedor";
            this.txtVendedor.Size = new System.Drawing.Size(355, 25);
            this.txtVendedor.TabIndex = 8049;
            this.txtVendedor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Font = new System.Drawing.Font("Bahnschrift", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Location = new System.Drawing.Point(185, 65);
            this.dateTimePicker1.Margin = new System.Windows.Forms.Padding(4);
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
            this.btnEliminarCotizacion.Location = new System.Drawing.Point(558, 100);
            this.btnEliminarCotizacion.Margin = new System.Windows.Forms.Padding(4);
            this.btnEliminarCotizacion.Name = "btnEliminarCotizacion";
            this.btnEliminarCotizacion.Size = new System.Drawing.Size(158, 33);
            this.btnEliminarCotizacion.TabIndex = 8051;
            this.btnEliminarCotizacion.Text = "Eliminar cotización";
            this.btnEliminarCotizacion.UseVisualStyleBackColor = false;
            this.btnEliminarCotizacion.Click += new System.EventHandler(this.btnEliminarCotizacion_Click);
            // 
            // chkFechaActivo
            // 
            this.chkFechaActivo.Font = new System.Drawing.Font("Bahnschrift", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkFechaActivo.ForeColor = System.Drawing.Color.White;
            this.chkFechaActivo.Location = new System.Drawing.Point(111, 65);
            this.chkFechaActivo.Margin = new System.Windows.Forms.Padding(4);
            this.chkFechaActivo.Name = "chkFechaActivo";
            this.chkFechaActivo.Size = new System.Drawing.Size(66, 25);
            this.chkFechaActivo.TabIndex = 8052;
            this.chkFechaActivo.Text = "Fecha";
            this.chkFechaActivo.UseVisualStyleBackColor = true;
            // 
            // pnlOpciones
            // 
            this.pnlOpciones.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(40)))));
            this.pnlOpciones.Controls.Add(this.btnEliminarCotizacion);
            this.pnlOpciones.Controls.Add(this.btnEditarCotizacion);
            this.pnlOpciones.Controls.Add(this.btnBuscarCotización);
            this.pnlOpciones.Controls.Add(this.chkFechaActivo);
            this.pnlOpciones.Controls.Add(this.txtDescripcion);
            this.pnlOpciones.Controls.Add(this.dateTimePicker1);
            this.pnlOpciones.Controls.Add(this.lblVendedor);
            this.pnlOpciones.Controls.Add(this.txtVendedor);
            this.pnlOpciones.Controls.Add(this.lblDecripcion);
            this.pnlOpciones.Location = new System.Drawing.Point(82, 60);
            this.pnlOpciones.Name = "pnlOpciones";
            this.pnlOpciones.Size = new System.Drawing.Size(735, 150);
            this.pnlOpciones.TabIndex = 8055;
            this.pnlOpciones.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlOpciones_Paint);
            // 
            // pnlFiltrarCotizaciones
            // 
            this.pnlFiltrarCotizaciones.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(40)))));
            this.pnlFiltrarCotizaciones.Controls.Add(this.lblFiltrar);
            this.pnlFiltrarCotizaciones.Location = new System.Drawing.Point(82, 10);
            this.pnlFiltrarCotizaciones.Name = "pnlFiltrarCotizaciones";
            this.pnlFiltrarCotizaciones.Size = new System.Drawing.Size(735, 40);
            this.pnlFiltrarCotizaciones.TabIndex = 8056;
            this.pnlFiltrarCotizaciones.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlFiltrarCotizaciones_Paint);
            // 
            // frmListarCotizaciones
            // 

            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackgroundImage = global::Vista.Properties.Resources.WoodenPlankCyan;
            this.ClientSize = new System.Drawing.Size(900, 600);
            this.Controls.Add(this.pnlFiltrarCotizaciones);
            this.Controls.Add(this.pnlOpciones);
            this.Controls.Add(this.dvgCotizaciones);
            this.Font = new System.Drawing.Font("Bahnschrift", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmListarCotizaciones";

            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmListarCotizaciones";
            this.Load += new System.EventHandler(this.frmListarCotizaciones_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.dvgCotizaciones)).EndInit();
            this.pnlOpciones.ResumeLayout(false);
            this.pnlOpciones.PerformLayout();
            this.pnlFiltrarCotizaciones.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dvgCotizaciones;
        private System.Windows.Forms.Button btnEditarCotizacion;
        private System.Windows.Forms.Button btnBuscarCotización;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Label lblFiltrarcot;
        private System.Windows.Forms.Label lblVendedor;

        private System.Windows.Forms.Label lblDecripcion;
        private System.Windows.Forms.TextBox txtVendedor;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button btnEliminarCotizacion;
        private System.Windows.Forms.CheckBox chkFechaActivo;
        private System.Windows.Forms.Panel pnlOpciones;
        private System.Windows.Forms.Panel pnlFiltrarCotizaciones;
    }
}