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

            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReportes));
            this.dgvVentas = new System.Windows.Forms.DataGridView();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.cboUsuarios = new System.Windows.Forms.ComboBox();
            this.cboClientes = new System.Windows.Forms.ComboBox();
            this.btnBuscarfiltro = new System.Windows.Forms.Button();
            this.btnLimpiarfiltros = new System.Windows.Forms.Button();
            this.chkUsarFechas = new System.Windows.Forms.CheckBox();
            this.lblusuarioreportes = new System.Windows.Forms.Label();
            this.lblclientereportes = new System.Windows.Forms.Label();
            this.lbldesdereportes = new System.Windows.Forms.Label();
            this.lblhastareportes = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblPromedio = new System.Windows.Forms.Label();
            this.lblTotalVentas = new System.Windows.Forms.Label();
            this.cboTipoGrafico = new System.Windows.Forms.ComboBox();
            this.chkFiltrarxvendedor = new System.Windows.Forms.CheckBox();
            this.chkFiltrarxCliente = new System.Windows.Forms.CheckBox();
            this.cboEstados = new System.Windows.Forms.ComboBox();
            this.chkFiltrarEstado = new System.Windows.Forms.CheckBox();
            this.pnlFunciones = new System.Windows.Forms.Panel();
            this.lblEstado = new System.Windows.Forms.Label();
            this.pnlGrafico = new System.Windows.Forms.Panel();
            this.chartVentas = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.pnlBorde = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.pctMinimize = new System.Windows.Forms.PictureBox();
            this.pctClose = new System.Windows.Forms.PictureBox();
            this.pnlBordeInferior = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVentas)).BeginInit();
            this.pnlFunciones.SuspendLayout();
            this.pnlGrafico.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartVentas)).BeginInit();
            this.pnlBorde.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctMinimize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctClose)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvVentas
            // 
            this.dgvVentas.BackgroundColor = System.Drawing.Color.White;
            this.dgvVentas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvVentas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVentas.Location = new System.Drawing.Point(10, 325);
            this.dgvVentas.Name = "dgvVentas";
            this.dgvVentas.ReadOnly = true;
            this.dgvVentas.RowHeadersWidth = 51;
            this.dgvVentas.RowTemplate.Height = 24;
            this.dgvVentas.Size = new System.Drawing.Size(630, 230);
            this.dgvVentas.TabIndex = 0;
            // 
            // dtpDesde
            // 
            this.dtpDesde.Font = new System.Drawing.Font("Bahnschrift", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDesde.Location = new System.Drawing.Point(5, 140);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(175, 24);
            this.dtpDesde.TabIndex = 1;
            // 
            // dtpHasta
            // 
            this.dtpHasta.Font = new System.Drawing.Font("Bahnschrift", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpHasta.Location = new System.Drawing.Point(5, 194);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(175, 24);
            this.dtpHasta.TabIndex = 2;
            this.dtpHasta.ValueChanged += new System.EventHandler(this.dtpHasta_ValueChanged);
            // 
            // cboUsuarios
            // 
            this.cboUsuarios.Font = new System.Drawing.Font("Bahnschrift", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboUsuarios.FormattingEnabled = true;
            this.cboUsuarios.Location = new System.Drawing.Point(5, 32);
            this.cboUsuarios.Name = "cboUsuarios";
            this.cboUsuarios.Size = new System.Drawing.Size(150, 24);
            this.cboUsuarios.TabIndex = 3;
            // 
            // cboClientes
            // 
            this.cboClientes.Font = new System.Drawing.Font("Bahnschrift", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboClientes.FormattingEnabled = true;
            this.cboClientes.Location = new System.Drawing.Point(5, 86);
            this.cboClientes.Name = "cboClientes";
            this.cboClientes.Size = new System.Drawing.Size(150, 24);
            this.cboClientes.TabIndex = 4;
            // 

            // btnBuscar
            // 
            this.btnBuscarfiltro.BackColor = System.Drawing.Color.White;
            this.btnBuscarfiltro.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnBuscarfiltro.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscarfiltro.Font = new System.Drawing.Font("Bahnschrift", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscarfiltro.ForeColor = System.Drawing.Color.Black;
            this.btnBuscarfiltro.Location = new System.Drawing.Point(486, 194);
            this.btnBuscarfiltro.Name = "btnBuscar";
            this.btnBuscarfiltro.Size = new System.Drawing.Size(140, 30);
            this.btnBuscarfiltro.TabIndex = 5;
            this.btnBuscarfiltro.Text = "Buscar";
            this.btnBuscarfiltro.UseVisualStyleBackColor = false;
            this.btnBuscarfiltro.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiarfiltros.BackColor = System.Drawing.Color.White;
            this.btnLimpiarfiltros.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnLimpiarfiltros.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiarfiltros.Font = new System.Drawing.Font("Bahnschrift", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiarfiltros.ForeColor = System.Drawing.Color.Black;
            this.btnLimpiarfiltros.Location = new System.Drawing.Point(340, 194);
            this.btnLimpiarfiltros.Name = "btnLimpiar";
            this.btnLimpiarfiltros.Size = new System.Drawing.Size(140, 30);
            this.btnLimpiarfiltros.TabIndex = 6;
            this.btnLimpiarfiltros.Text = "Limpiar";
            this.btnLimpiarfiltros.UseVisualStyleBackColor = false;
            this.btnLimpiarfiltros.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // chkUsarFechas
            // 
            this.chkUsarFechas.Font = new System.Drawing.Font("Bahnschrift", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkUsarFechas.Location = new System.Drawing.Point(182, 140);
            this.chkUsarFechas.Name = "chkUsarFechas";
            this.chkUsarFechas.Size = new System.Drawing.Size(135, 24);
            this.chkUsarFechas.TabIndex = 7;
            this.chkUsarFechas.Text = "Buscar por fecha";
            this.chkUsarFechas.UseVisualStyleBackColor = true;
            this.chkUsarFechas.CheckedChanged += new System.EventHandler(this.chkBuscarPorFecha_CheckedChanged);
            // 
            // lblusuarioreportes
            // 

            this.lblusuarioreportes.Font = new System.Drawing.Font("Bahnschrift", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblusuarioreportes.Location = new System.Drawing.Point(5, 5);
            this.lblusuarioreportes.Name = "label1";
            this.lblusuarioreportes.Size = new System.Drawing.Size(154, 24);
            this.lblusuarioreportes.TabIndex = 8;
            this.lblusuarioreportes.Text = "Usuario";
            this.lblusuarioreportes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblclientereportes
            // 

            this.lblclientereportes.Font = new System.Drawing.Font("Bahnschrift", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblclientereportes.Location = new System.Drawing.Point(5, 59);
            this.lblclientereportes.Name = "label2";
            this.lblclientereportes.Size = new System.Drawing.Size(154, 24);
            this.lblclientereportes.TabIndex = 9;
            this.lblclientereportes.Text = "Cliente";
            this.lblclientereportes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbldesdereportes
            // 

            this.lbldesdereportes.Font = new System.Drawing.Font("Bahnschrift", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbldesdereportes.Location = new System.Drawing.Point(5, 113);
            this.lbldesdereportes.Name = "label3";
            this.lbldesdereportes.Size = new System.Drawing.Size(150, 24);
            this.lbldesdereportes.TabIndex = 10;
            this.lbldesdereportes.Text = "Desde";
            this.lbldesdereportes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblhastareportes
            // 

            this.lblhastareportes.Font = new System.Drawing.Font("Bahnschrift", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblhastareportes.Location = new System.Drawing.Point(5, 167);
            this.lblhastareportes.Name = "label4";
            this.lblhastareportes.Size = new System.Drawing.Size(150, 24);
            this.lblhastareportes.TabIndex = 11;
            this.lblhastareportes.Text = "Hasta";
            this.lblhastareportes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTotal
            // 
            this.lblTotal.Font = new System.Drawing.Font("Bahnschrift", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(340, 110);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(286, 24);
            this.lblTotal.TabIndex = 13;
            this.lblTotal.Text = "Total";
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblPromedio
            // 
            this.lblPromedio.Font = new System.Drawing.Font("Bahnschrift", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPromedio.Location = new System.Drawing.Point(340, 150);
            this.lblPromedio.Name = "lblPromedio";
            this.lblPromedio.Size = new System.Drawing.Size(286, 24);
            this.lblPromedio.TabIndex = 14;
            this.lblPromedio.Text = "Promedio";
            this.lblPromedio.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 

            // lblTotalVentas
            // 
            this.lblTotalVentas.Font = new System.Drawing.Font("Bahnschrift", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalVentas.ForeColor = System.Drawing.Color.White;
            this.lblTotalVentas.Location = new System.Drawing.Point(340, 70);
            this.lblTotalVentas.Name = "lblTotalVentas";
            this.lblTotalVentas.Size = new System.Drawing.Size(286, 24);
            this.lblTotalVentas.TabIndex = 12;
            this.lblTotalVentas.Text = "Total ventas";
            this.lblTotalVentas.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cboTipoGrafico
            // 
            this.cboTipoGrafico.FormattingEnabled = true;
            this.cboTipoGrafico.Location = new System.Drawing.Point(457, 50);
            this.cboTipoGrafico.Name = "cboTipoGrafico";
            this.cboTipoGrafico.Size = new System.Drawing.Size(175, 24);
            this.cboTipoGrafico.TabIndex = 16;
            this.cboTipoGrafico.SelectedIndexChanged += new System.EventHandler(this.cboTipoGrafico_SelectedIndexChanged);
            // 
            // chkFiltrarxvendedor
            // 

            this.chkFiltrarxvendedor.Font = new System.Drawing.Font("Bahnschrift", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkFiltrarxvendedor.Location = new System.Drawing.Point(157, 32);
            this.chkFiltrarxvendedor.Name = "chkFiltrarUsuario";
            this.chkFiltrarxvendedor.Size = new System.Drawing.Size(162, 24);
            this.chkFiltrarxvendedor.TabIndex = 17;
            this.chkFiltrarxvendedor.Text = "Buscar por vendedor";
            this.chkFiltrarxvendedor.UseVisualStyleBackColor = true;
            // 
            // chkFiltrarxCliente
            // 

            this.chkFiltrarxCliente.Font = new System.Drawing.Font("Bahnschrift", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkFiltrarxCliente.Location = new System.Drawing.Point(157, 86);
            this.chkFiltrarxCliente.Name = "chkFiltrarCliente";
            this.chkFiltrarxCliente.Size = new System.Drawing.Size(145, 24);
            this.chkFiltrarxCliente.TabIndex = 18;
            this.chkFiltrarxCliente.Text = "Buscar por cliente";
            this.chkFiltrarxCliente.UseVisualStyleBackColor = true;
            // 
            // cboEstados
            // 
            this.cboEstados.Font = new System.Drawing.Font("Bahnschrift", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboEstados.FormattingEnabled = true;
            this.cboEstados.Location = new System.Drawing.Point(340, 32);
            this.cboEstados.Margin = new System.Windows.Forms.Padding(4);
            this.cboEstados.Name = "cboEstados";
            this.cboEstados.Size = new System.Drawing.Size(140, 24);
            this.cboEstados.TabIndex = 19;
            // 
            // chkFiltrarEstado
            // 
            this.chkFiltrarEstado.Font = new System.Drawing.Font("Bahnschrift", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkFiltrarEstado.Location = new System.Drawing.Point(482, 32);
            this.chkFiltrarEstado.Margin = new System.Windows.Forms.Padding(4);
            this.chkFiltrarEstado.Name = "chkFiltrarEstado";
            this.chkFiltrarEstado.Size = new System.Drawing.Size(144, 24);
            this.chkFiltrarEstado.TabIndex = 20;
            this.chkFiltrarEstado.Text = "Buscar por estado";
            this.chkFiltrarEstado.UseVisualStyleBackColor = true;
            // 
            // pnlFunciones
            // 
            this.pnlFunciones.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(40)))));
            this.pnlFunciones.Controls.Add(this.lblEstado);
            this.pnlFunciones.Controls.Add(this.cboUsuarios);
            this.pnlFunciones.Controls.Add(this.cboClientes);
            this.pnlFunciones.Controls.Add(this.lblusuarioreportes);
            this.pnlFunciones.Controls.Add(this.chkFiltrarEstado);
            this.pnlFunciones.Controls.Add(this.lblTotalVentas);
            this.pnlFunciones.Controls.Add(this.cboEstados);
            this.pnlFunciones.Controls.Add(this.lblclientereportes);
            this.pnlFunciones.Controls.Add(this.lblPromedio);
            this.pnlFunciones.Controls.Add(this.chkFiltrarxvendedor);
            this.pnlFunciones.Controls.Add(this.lblTotal);
            this.pnlFunciones.Controls.Add(this.chkFiltrarxCliente);
            this.pnlFunciones.Controls.Add(this.lblhastareportes);
            this.pnlFunciones.Controls.Add(this.lbldesdereportes);
            this.pnlFunciones.Controls.Add(this.dtpDesde);
            this.pnlFunciones.Controls.Add(this.chkUsarFechas);
            this.pnlFunciones.Controls.Add(this.dtpHasta);
            this.pnlFunciones.Controls.Add(this.btnLimpiarfiltros);
            this.pnlFunciones.Controls.Add(this.btnBuscarfiltro);
            this.pnlFunciones.ForeColor = System.Drawing.Color.White;
            this.pnlFunciones.Location = new System.Drawing.Point(10, 85);
            this.pnlFunciones.Name = "pnlFunciones";
            this.pnlFunciones.Size = new System.Drawing.Size(630, 230);
            this.pnlFunciones.TabIndex = 29;
            this.pnlFunciones.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlFunciones_Paint);
            // 
            // lblEstado
            // 
            this.lblEstado.Font = new System.Drawing.Font("Bahnschrift", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEstado.Location = new System.Drawing.Point(340, 5);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(140, 24);
            this.lblEstado.TabIndex = 21;
            this.lblEstado.Text = "Estado";
            this.lblEstado.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlGrafico
            // 
            this.pnlGrafico.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(40)))));
            this.pnlGrafico.Controls.Add(this.chartVentas);
            this.pnlGrafico.Location = new System.Drawing.Point(650, 85);
            this.pnlGrafico.Name = "pnlGrafico";
            this.pnlGrafico.Size = new System.Drawing.Size(430, 470);
            this.pnlGrafico.TabIndex = 31;
            this.pnlGrafico.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlGrafico_Paint);
            // 
            // chartVentas
            // 
            chartArea1.Name = "ChartArea1";
            this.chartVentas.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartVentas.Legends.Add(legend1);
            this.chartVentas.Location = new System.Drawing.Point(13, 70);
            this.chartVentas.Margin = new System.Windows.Forms.Padding(0);
            this.chartVentas.Name = "chartVentas";
            this.chartVentas.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Excel;
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartVentas.Series.Add(series1);
            this.chartVentas.Size = new System.Drawing.Size(405, 330);
            this.chartVentas.TabIndex = 15;
            this.chartVentas.Text = "chart1";
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
            this.pnlBorde.Size = new System.Drawing.Size(1090, 40);
            this.pnlBorde.TabIndex = 8047;
            // 
            // lblTitulo
            // 
            this.lblTitulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(40)))));
            this.lblTitulo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitulo.Font = new System.Drawing.Font("Bahnschrift", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(40, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(1010, 40);
            this.lblTitulo.TabIndex = 23;
            this.lblTitulo.Text = "Cotizador";
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
            this.pctClose.Location = new System.Drawing.Point(1050, 0);
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
            this.pnlBordeInferior.Location = new System.Drawing.Point(0, 565);
            this.pnlBordeInferior.Name = "pnlBordeInferior";
            this.pnlBordeInferior.Size = new System.Drawing.Size(1090, 20);
            this.pnlBordeInferior.TabIndex = 8046;
            // 
            // frmReportes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackgroundImage = global::Vista.Properties.Resources.WoodenPlankCyan;
            this.ClientSize = new System.Drawing.Size(1090, 585);
            this.Controls.Add(this.pnlFunciones);
            this.Controls.Add(this.pnlBorde);
            this.Controls.Add(this.cboTipoGrafico);
            this.Controls.Add(this.pnlBordeInferior);
            this.Controls.Add(this.pnlGrafico);
            this.Controls.Add(this.dgvVentas);
            this.Font = new System.Drawing.Font("Bahnschrift", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmReportes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmReportes";
            this.Load += new System.EventHandler(this.frmReportes_Load);
            this.Shown += new System.EventHandler(this.frmReportes_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVentas)).EndInit();
            this.pnlFunciones.ResumeLayout(false);
            this.pnlGrafico.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartVentas)).EndInit();
            this.pnlBorde.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pctMinimize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctClose)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvVentas;
        private System.Windows.Forms.DateTimePicker dtpDesde;
        private System.Windows.Forms.DateTimePicker dtpHasta;
        private System.Windows.Forms.ComboBox cboUsuarios;
        private System.Windows.Forms.ComboBox cboClientes;
        private System.Windows.Forms.Button btnBuscarfiltro;
        private System.Windows.Forms.Button btnLimpiarfiltros;
        private System.Windows.Forms.CheckBox chkUsarFechas;
        private System.Windows.Forms.Label lblusuarioreportes;
        private System.Windows.Forms.Label lblclientereportes;
        private System.Windows.Forms.Label lbldesdereportes;
        private System.Windows.Forms.Label lblhastareportes;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblPromedio;
        private System.Windows.Forms.Label lblTotalVentas;
        private System.Windows.Forms.ComboBox cboTipoGrafico;
        private System.Windows.Forms.CheckBox chkFiltrarxvendedor;
        private System.Windows.Forms.CheckBox chkFiltrarxCliente;
        private System.Windows.Forms.ComboBox cboEstados;
        private System.Windows.Forms.CheckBox chkFiltrarEstado;
        private System.Windows.Forms.Panel pnlFunciones;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.Panel pnlGrafico;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartVentas;
        private System.Windows.Forms.Panel pnlBorde;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.PictureBox pctMinimize;
        private System.Windows.Forms.PictureBox pctClose;
        private System.Windows.Forms.Panel pnlBordeInferior;
    }
}