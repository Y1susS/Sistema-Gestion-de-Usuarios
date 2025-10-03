namespace Vista
{
    partial class frmReportes
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.dgvVentas = new System.Windows.Forms.DataGridView();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.cboUsuarios = new System.Windows.Forms.ComboBox();
            this.cboClientes = new System.Windows.Forms.ComboBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.chkUsarFechas = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblPromedio = new System.Windows.Forms.Label();
            this.chartVentas = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.lblTotalVentas = new System.Windows.Forms.Label();
            this.cboTipoGrafico = new System.Windows.Forms.ComboBox();
            this.chkFiltrarUsuario = new System.Windows.Forms.CheckBox();
            this.chkFiltrarCliente = new System.Windows.Forms.CheckBox();
            this.cboEstados = new System.Windows.Forms.ComboBox();
            this.chkFiltrarEstado = new System.Windows.Forms.CheckBox();
            this.btnVolver = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVentas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartVentas)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvVentas
            // 
            this.dgvVentas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVentas.Location = new System.Drawing.Point(11, 235);
            this.dgvVentas.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgvVentas.Name = "dgvVentas";
            this.dgvVentas.ReadOnly = true;
            this.dgvVentas.RowHeadersWidth = 51;
            this.dgvVentas.RowTemplate.Height = 24;
            this.dgvVentas.Size = new System.Drawing.Size(554, 148);
            this.dgvVentas.TabIndex = 0;
            // 
            // dtpDesde
            // 
            this.dtpDesde.Location = new System.Drawing.Point(8, 138);
            this.dtpDesde.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(151, 20);
            this.dtpDesde.TabIndex = 1;
            // 
            // dtpHasta
            // 
            this.dtpHasta.Location = new System.Drawing.Point(8, 190);
            this.dtpHasta.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(151, 20);
            this.dtpHasta.TabIndex = 2;
            this.dtpHasta.ValueChanged += new System.EventHandler(this.dtpHasta_ValueChanged);
            // 
            // cboUsuarios
            // 
            this.cboUsuarios.FormattingEnabled = true;
            this.cboUsuarios.Location = new System.Drawing.Point(8, 34);
            this.cboUsuarios.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cboUsuarios.Name = "cboUsuarios";
            this.cboUsuarios.Size = new System.Drawing.Size(92, 21);
            this.cboUsuarios.TabIndex = 3;
            // 
            // cboClientes
            // 
            this.cboClientes.FormattingEnabled = true;
            this.cboClientes.Location = new System.Drawing.Point(8, 77);
            this.cboClientes.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cboClientes.Name = "cboClientes";
            this.cboClientes.Size = new System.Drawing.Size(92, 21);
            this.cboClientes.TabIndex = 4;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(308, 171);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(56, 19);
            this.btnBuscar.TabIndex = 5;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(308, 205);
            this.btnLimpiar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(56, 19);
            this.btnLimpiar.TabIndex = 6;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // chkUsarFechas
            // 
            this.chkUsarFechas.AutoSize = true;
            this.chkUsarFechas.Location = new System.Drawing.Point(173, 138);
            this.chkUsarFechas.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.chkUsarFechas.Name = "chkUsarFechas";
            this.chkUsarFechas.Size = new System.Drawing.Size(107, 17);
            this.chkUsarFechas.TabIndex = 7;
            this.chkUsarFechas.Text = "Buscar por fecha";
            this.chkUsarFechas.UseVisualStyleBackColor = true;
            this.chkUsarFechas.CheckedChanged += new System.EventHandler(this.chkBuscarPorFecha_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 16);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Usuario";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 59);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Cliente";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 114);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Desde";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 167);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Hasta";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(416, 177);
            this.lblTotal.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(35, 13);
            this.lblTotal.TabIndex = 13;
            this.lblTotal.Text = "label5";
            // 
            // lblPromedio
            // 
            this.lblPromedio.AutoSize = true;
            this.lblPromedio.Location = new System.Drawing.Point(416, 207);
            this.lblPromedio.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPromedio.Name = "lblPromedio";
            this.lblPromedio.Size = new System.Drawing.Size(35, 13);
            this.lblPromedio.TabIndex = 14;
            this.lblPromedio.Text = "label5";
            // 
            // chartVentas
            // 
            chartArea2.Name = "ChartArea1";
            this.chartVentas.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chartVentas.Legends.Add(legend2);
            this.chartVentas.Location = new System.Drawing.Point(604, 49);
            this.chartVentas.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.chartVentas.Name = "chartVentas";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chartVentas.Series.Add(series2);
            this.chartVentas.Size = new System.Drawing.Size(416, 346);
            this.chartVentas.TabIndex = 15;
            this.chartVentas.Text = "chart1";
            // 
            // lblTotalVentas
            // 
            this.lblTotalVentas.AutoSize = true;
            this.lblTotalVentas.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalVentas.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblTotalVentas.Location = new System.Drawing.Point(416, 149);
            this.lblTotalVentas.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTotalVentas.Name = "lblTotalVentas";
            this.lblTotalVentas.Size = new System.Drawing.Size(35, 13);
            this.lblTotalVentas.TabIndex = 12;
            this.lblTotalVentas.Text = "label5";
            // 
            // cboTipoGrafico
            // 
            this.cboTipoGrafico.FormattingEnabled = true;
            this.cboTipoGrafico.Location = new System.Drawing.Point(437, 16);
            this.cboTipoGrafico.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cboTipoGrafico.Name = "cboTipoGrafico";
            this.cboTipoGrafico.Size = new System.Drawing.Size(154, 21);
            this.cboTipoGrafico.TabIndex = 16;
            this.cboTipoGrafico.SelectedIndexChanged += new System.EventHandler(this.cboTipoGrafico_SelectedIndexChanged);
            // 
            // chkFiltrarUsuario
            // 
            this.chkFiltrarUsuario.AutoSize = true;
            this.chkFiltrarUsuario.Location = new System.Drawing.Point(112, 37);
            this.chkFiltrarUsuario.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.chkFiltrarUsuario.Name = "chkFiltrarUsuario";
            this.chkFiltrarUsuario.Size = new System.Drawing.Size(125, 17);
            this.chkFiltrarUsuario.TabIndex = 17;
            this.chkFiltrarUsuario.Text = "Buscar por vendedor";
            this.chkFiltrarUsuario.UseVisualStyleBackColor = true;
            // 
            // chkFiltrarCliente
            // 
            this.chkFiltrarCliente.AutoSize = true;
            this.chkFiltrarCliente.Location = new System.Drawing.Point(112, 80);
            this.chkFiltrarCliente.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.chkFiltrarCliente.Name = "chkFiltrarCliente";
            this.chkFiltrarCliente.Size = new System.Drawing.Size(111, 17);
            this.chkFiltrarCliente.TabIndex = 18;
            this.chkFiltrarCliente.Text = "Buscar por cliente";
            this.chkFiltrarCliente.UseVisualStyleBackColor = true;
            // 
            // cboEstados
            // 
            this.cboEstados.FormattingEnabled = true;
            this.cboEstados.Location = new System.Drawing.Point(281, 76);
            this.cboEstados.Name = "cboEstados";
            this.cboEstados.Size = new System.Drawing.Size(121, 21);
            this.cboEstados.TabIndex = 19;
            // 
            // chkFiltrarEstado
            // 
            this.chkFiltrarEstado.AutoSize = true;
            this.chkFiltrarEstado.Location = new System.Drawing.Point(419, 80);
            this.chkFiltrarEstado.Name = "chkFiltrarEstado";
            this.chkFiltrarEstado.Size = new System.Drawing.Size(112, 17);
            this.chkFiltrarEstado.TabIndex = 20;
            this.chkFiltrarEstado.Text = "Buscar por estado";
            this.chkFiltrarEstado.UseVisualStyleBackColor = true;
            // 
            // btnVolver
            // 
            this.btnVolver.Location = new System.Drawing.Point(945, 14);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(75, 23);
            this.btnVolver.TabIndex = 21;
            this.btnVolver.Text = "VOLVER";
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // frmReportes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1030, 405);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.chkFiltrarEstado);
            this.Controls.Add(this.cboEstados);
            this.Controls.Add(this.chkFiltrarCliente);
            this.Controls.Add(this.chkFiltrarUsuario);
            this.Controls.Add(this.cboTipoGrafico);
            this.Controls.Add(this.lblTotalVentas);
            this.Controls.Add(this.chartVentas);
            this.Controls.Add(this.lblPromedio);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chkUsarFechas);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.cboClientes);
            this.Controls.Add(this.cboUsuarios);
            this.Controls.Add(this.dtpHasta);
            this.Controls.Add(this.dtpDesde);
            this.Controls.Add(this.dgvVentas);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "frmReportes";
            this.Text = "frmReportes";
            this.Load += new System.EventHandler(this.frmReportes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVentas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartVentas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvVentas;
        private System.Windows.Forms.DateTimePicker dtpDesde;
        private System.Windows.Forms.DateTimePicker dtpHasta;
        private System.Windows.Forms.ComboBox cboUsuarios;
        private System.Windows.Forms.ComboBox cboClientes;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.CheckBox chkUsarFechas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblPromedio;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartVentas;
        private System.Windows.Forms.Label lblTotalVentas;
        private System.Windows.Forms.ComboBox cboTipoGrafico;
        private System.Windows.Forms.CheckBox chkFiltrarUsuario;
        private System.Windows.Forms.CheckBox chkFiltrarCliente;
        private System.Windows.Forms.ComboBox cboEstados;
        private System.Windows.Forms.CheckBox chkFiltrarEstado;
        private System.Windows.Forms.Button btnVolver;
    }
}