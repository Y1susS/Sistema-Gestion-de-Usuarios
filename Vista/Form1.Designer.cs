//namespace CalculoPiesMuebles
//{
//    partial class Form1
//    {
//        /// <summary>
//        /// Variable del diseñador necesaria.
//        /// </summary>
//        private System.ComponentModel.IContainer components = null;

//        /// <summary>
//        /// Limpiar los recursos que se estén usando.
//        /// </summary>
//        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
//        protected override void Dispose(bool disposing)
//        {
//            if (disposing && (components != null))
//            {
//                components.Dispose();
//            }
//            base.Dispose(disposing);
//        }

//        #region Código generado por el Diseñador de Windows Forms

//        /// <summary>
//        /// Método necesario para admitir el Diseñador. No se puede modificar
//        /// el contenido de este método con el editor de código.
//        /// </summary>
//        private void InitializeComponent()
//        {
//            this.components = new System.ComponentModel.Container();
//            this.label1 = new System.Windows.Forms.Label();
//            this.label2 = new System.Windows.Forms.Label();
//            this.label3 = new System.Windows.Forms.Label();
//            this.lbltitulo = new System.Windows.Forms.Label();
//            this.txtespesorm1 = new System.Windows.Forms.TextBox();
//            this.txtanchom1 = new System.Windows.Forms.TextBox();
//            this.txtlargom1 = new System.Windows.Forms.TextBox();
//            this.btncalcularpies = new System.Windows.Forms.Button();
//            this.lblpies1 = new System.Windows.Forms.Label();
//            this.btnlimpiarmedidas = new System.Windows.Forms.Button();
//            this.lblcalculopies = new System.Windows.Forms.Label();
//            this.lblseleccionmaderas = new System.Windows.Forms.Label();
//            this.label5 = new System.Windows.Forms.Label();
//            this.lblpresupuesto = new System.Windows.Forms.Label();
//            this.pcbimagenmaderareciclada = new System.Windows.Forms.PictureBox();
//            this.btnguardarpresupuesto = new System.Windows.Forms.Button();
//            this.cmbmaderas = new System.Windows.Forms.ComboBox();
//            this.lblpies = new System.Windows.Forms.Label();
//            this.lblvalorpies = new System.Windows.Forms.Label();
//            this.calculopiesDataSet = new CalculoPiesMuebles.CalculopiesDataSet();
//            this.maderasBindingSource = new System.Windows.Forms.BindingSource(this.components);
//            this.maderasTableAdapter = new CalculoPiesMuebles.CalculopiesDataSetTableAdapters.MaderasTableAdapter();
//            this.dgvmaderas = new System.Windows.Forms.DataGridView();
//            this.btnmostrartodas = new System.Windows.Forms.Button();
//            this.btncerrar = new System.Windows.Forms.Button();
//            this.lblcantidad = new System.Windows.Forms.Label();
//            this.txtcantidad1 = new System.Windows.Forms.TextBox();
//            this.lblmadera = new System.Windows.Forms.Label();
//            this.label4 = new System.Windows.Forms.Label();
//            this.label8 = new System.Windows.Forms.Label();
//            this.label9 = new System.Windows.Forms.Label();
//            this.label10 = new System.Windows.Forms.Label();
//            this.label11 = new System.Windows.Forms.Label();
//            this.label12 = new System.Windows.Forms.Label();
//            this.txtcantidad2 = new System.Windows.Forms.TextBox();
//            this.txtlargom2 = new System.Windows.Forms.TextBox();
//            this.txtanchom2 = new System.Windows.Forms.TextBox();
//            this.txtespesorm2 = new System.Windows.Forms.TextBox();
//            this.txtcantidad3 = new System.Windows.Forms.TextBox();
//            this.txtlargom3 = new System.Windows.Forms.TextBox();
//            this.txtanchom3 = new System.Windows.Forms.TextBox();
//            this.txtespesorm3 = new System.Windows.Forms.TextBox();
//            this.txtcantidad4 = new System.Windows.Forms.TextBox();
//            this.txtlargom4 = new System.Windows.Forms.TextBox();
//            this.txtanchom4 = new System.Windows.Forms.TextBox();
//            this.txtespesorm4 = new System.Windows.Forms.TextBox();
//            this.txtcantidad5 = new System.Windows.Forms.TextBox();
//            this.txtlargom5 = new System.Windows.Forms.TextBox();
//            this.txtanchom5 = new System.Windows.Forms.TextBox();
//            this.txtespesorm5 = new System.Windows.Forms.TextBox();
//            this.txtcantidad6 = new System.Windows.Forms.TextBox();
//            this.txtlargom6 = new System.Windows.Forms.TextBox();
//            this.txtanchom6 = new System.Windows.Forms.TextBox();
//            this.txtespesorm6 = new System.Windows.Forms.TextBox();
//            this.lblpie = new System.Windows.Forms.Label();
//            this.lblpie1 = new System.Windows.Forms.Label();
//            this.lblpie2 = new System.Windows.Forms.Label();
//            this.lblpie3 = new System.Windows.Forms.Label();
//            this.lblpie4 = new System.Windows.Forms.Label();
//            this.lblpie5 = new System.Windows.Forms.Label();
//            this.lblpie6 = new System.Windows.Forms.Label();
//            this.chk1 = new System.Windows.Forms.CheckBox();
//            this.chk2 = new System.Windows.Forms.CheckBox();
//            this.chk3 = new System.Windows.Forms.CheckBox();
//            this.chk6 = new System.Windows.Forms.CheckBox();
//            this.chk5 = new System.Windows.Forms.CheckBox();
//            this.chk4 = new System.Windows.Forms.CheckBox();
//            this.chkguias1 = new System.Windows.Forms.CheckBox();
//            this.lblguias1 = new System.Windows.Forms.Label();
//            this.txtguias1 = new System.Windows.Forms.TextBox();
//            this.cmbguias1 = new System.Windows.Forms.ComboBox();
//            this.label13 = new System.Windows.Forms.Label();
//            this.lbltitulovalorguias = new System.Windows.Forms.Label();
//            this.lblvalorguias1 = new System.Windows.Forms.Label();
//            this.lbltitulototal = new System.Windows.Forms.Label();
//            this.lbltotalguias1 = new System.Windows.Forms.Label();
//            this.btncalcularpresupuesto = new System.Windows.Forms.Button();
//            this.lbltotalguias2 = new System.Windows.Forms.Label();
//            this.lblvalorguias2 = new System.Windows.Forms.Label();
//            this.cmbguias2 = new System.Windows.Forms.ComboBox();
//            this.txtguias2 = new System.Windows.Forms.TextBox();
//            this.lblguias2 = new System.Windows.Forms.Label();
//            this.chkguias2 = new System.Windows.Forms.CheckBox();
//            this.lbltotalgastosvarios = new System.Windows.Forms.Label();
//            this.txtgastosvarios = new System.Windows.Forms.TextBox();
//            this.label16 = new System.Windows.Forms.Label();
//            this.chkgastosvarios = new System.Windows.Forms.CheckBox();
//            this.lbltotalgastosadicionales = new System.Windows.Forms.Label();
//            this.txtmateriales = new System.Windows.Forms.TextBox();
//            this.label19 = new System.Windows.Forms.Label();
//            this.chkotrosmateriales = new System.Windows.Forms.CheckBox();
//            this.txtdescmad6 = new System.Windows.Forms.TextBox();
//            this.txtdescmad5 = new System.Windows.Forms.TextBox();
//            this.txtdescmad4 = new System.Windows.Forms.TextBox();
//            this.txtdescmad3 = new System.Windows.Forms.TextBox();
//            this.txtdescmad2 = new System.Windows.Forms.TextBox();
//            this.txtdescmad1 = new System.Windows.Forms.TextBox();
//            this.label20 = new System.Windows.Forms.Label();
//            this.lblotrosmateriales = new System.Windows.Forms.Label();
//            this.label14 = new System.Windows.Forms.Label();
//            this.lbldesperdicio = new System.Windows.Forms.Label();
//            this.lblganancia = new System.Windows.Forms.Label();
//            this.txtganancia = new System.Windows.Forms.TextBox();
//            this.txtdesperdicio = new System.Windows.Forms.TextBox();
//            this.chkvidrio1 = new System.Windows.Forms.CheckBox();
//            this.label15 = new System.Windows.Forms.Label();
//            this.txtvidriolargo1 = new System.Windows.Forms.TextBox();
//            this.txtvidrioancho1 = new System.Windows.Forms.TextBox();
//            this.txtvidriocant1 = new System.Windows.Forms.TextBox();
//            this.txtvidriocant2 = new System.Windows.Forms.TextBox();
//            this.txtvidrioancho2 = new System.Windows.Forms.TextBox();
//            this.txtvidriolargo2 = new System.Windows.Forms.TextBox();
//            this.label17 = new System.Windows.Forms.Label();
//            this.chkvidrio2 = new System.Windows.Forms.CheckBox();
//            this.txtvidriocant3 = new System.Windows.Forms.TextBox();
//            this.txtvidrioancho3 = new System.Windows.Forms.TextBox();
//            this.txtvidriolargo3 = new System.Windows.Forms.TextBox();
//            this.label18 = new System.Windows.Forms.Label();
//            this.chkvidrio3 = new System.Windows.Forms.CheckBox();
//            this.label21 = new System.Windows.Forms.Label();
//            this.label22 = new System.Windows.Forms.Label();
//            this.label23 = new System.Windows.Forms.Label();
//            this.label24 = new System.Windows.Forms.Label();
//            this.label25 = new System.Windows.Forms.Label();
//            this.lblvidriototal2 = new System.Windows.Forms.Label();
//            this.lblvidriounidad2 = new System.Windows.Forms.Label();
//            this.lblvidriototal1 = new System.Windows.Forms.Label();
//            this.lblvidriounidad1 = new System.Windows.Forms.Label();
//            this.lblvidriototal3 = new System.Windows.Forms.Label();
//            this.lblvidriounidad3 = new System.Windows.Forms.Label();
//            this.label26 = new System.Windows.Forms.Label();
//            this.lbltotalvidrios = new System.Windows.Forms.Label();
//            this.cmbvidrios1 = new System.Windows.Forms.ComboBox();
//            this.cmbvidrios2 = new System.Windows.Forms.ComboBox();
//            this.cmbvidrios3 = new System.Windows.Forms.ComboBox();
//            this.lblmaderas = new System.Windows.Forms.Label();
//            this.lblvidrios = new System.Windows.Forms.Label();
//            this.lbltitulomateriales = new System.Windows.Forms.Label();
//            this.lblvalorxmetro23 = new System.Windows.Forms.Label();
//            this.lblvalorxmetro22 = new System.Windows.Forms.Label();
//            this.lblvalorxmetro21 = new System.Windows.Forms.Label();
//            this.lblmetros2 = new System.Windows.Forms.Label();
//            this.cmbbisagras1 = new System.Windows.Forms.ComboBox();
//            this.lbltotalbisagras = new System.Windows.Forms.Label();
//            this.lblbisagrasunidad1 = new System.Windows.Forms.Label();
//            this.txtbisagrascantidad = new System.Windows.Forms.TextBox();
//            this.chkbisagras1 = new System.Windows.Forms.CheckBox();
//            this.lblbisagras = new System.Windows.Forms.Label();
//            this.label27 = new System.Windows.Forms.Label();
//            this.label30 = new System.Windows.Forms.Label();
//            this.label32 = new System.Windows.Forms.Label();
//            ((System.ComponentModel.ISupportInitialize)(this.pcbimagenmaderareciclada)).BeginInit();
//            ((System.ComponentModel.ISupportInitialize)(this.calculopiesDataSet)).BeginInit();
//            ((System.ComponentModel.ISupportInitialize)(this.maderasBindingSource)).BeginInit();
//            ((System.ComponentModel.ISupportInitialize)(this.dgvmaderas)).BeginInit();
//            this.SuspendLayout();
//            // 
//            // label1
//            // 
//            this.label1.AutoSize = true;
//            this.label1.Location = new System.Drawing.Point(246, 73);
//            this.label1.Name = "label1";
//            this.label1.Size = new System.Drawing.Size(68, 13);
//            this.label1.TabIndex = 0;
//            this.label1.Text = "Espesor (cm)";
//            // 
//            // label2
//            // 
//            this.label2.AutoSize = true;
//            this.label2.Location = new System.Drawing.Point(333, 73);
//            this.label2.Name = "label2";
//            this.label2.Size = new System.Drawing.Size(61, 13);
//            this.label2.TabIndex = 1;
//            this.label2.Text = "Ancho (cm)";
//            // 
//            // label3
//            // 
//            this.label3.AutoSize = true;
//            this.label3.Location = new System.Drawing.Point(415, 73);
//            this.label3.Name = "label3";
//            this.label3.Size = new System.Drawing.Size(59, 13);
//            this.label3.TabIndex = 2;
//            this.label3.Text = "Largo (mts)";
//            // 
//            // lbltitulo
//            // 
//            this.lbltitulo.AutoSize = true;
//            this.lbltitulo.Location = new System.Drawing.Point(12, 9);
//            this.lbltitulo.Name = "lbltitulo";
//            this.lbltitulo.Size = new System.Drawing.Size(529, 13);
//            this.lbltitulo.TabIndex = 3;
//            this.lbltitulo.Text = "Introduzca las medidas de cada tabla para calcular los pies cubicos y Utilice la " +
//    "coma \",\" para indicar decimales";
//            // 
//            // txtespesorm1
//            // 
//            this.txtespesorm1.Location = new System.Drawing.Point(243, 92);
//            this.txtespesorm1.Name = "txtespesorm1";
//            this.txtespesorm1.Size = new System.Drawing.Size(74, 20);
//            this.txtespesorm1.TabIndex = 2;
//            this.txtespesorm1.TextChanged += new System.EventHandler(this.txtespesor_TextChanged);
//            // 
//            // txtanchom1
//            // 
//            this.txtanchom1.Location = new System.Drawing.Point(323, 92);
//            this.txtanchom1.Name = "txtanchom1";
//            this.txtanchom1.Size = new System.Drawing.Size(74, 20);
//            this.txtanchom1.TabIndex = 3;
//            // 
//            // txtlargom1
//            // 
//            this.txtlargom1.Location = new System.Drawing.Point(403, 92);
//            this.txtlargom1.Name = "txtlargom1";
//            this.txtlargom1.Size = new System.Drawing.Size(74, 20);
//            this.txtlargom1.TabIndex = 4;
//            this.txtlargom1.TextChanged += new System.EventHandler(this.txtlargom1_TextChanged);
//            // 
//            // btncalcularpies
//            // 
//            this.btncalcularpies.Location = new System.Drawing.Point(336, 230);
//            this.btncalcularpies.Name = "btncalcularpies";
//            this.btncalcularpies.Size = new System.Drawing.Size(183, 25);
//            this.btncalcularpies.TabIndex = 36;
//            this.btncalcularpies.Text = "Calcular pies";
//            this.btncalcularpies.UseVisualStyleBackColor = true;
//            this.btncalcularpies.Click += new System.EventHandler(this.btncalcularpies_Click);
//            // 
//            // lblpies1
//            // 
//            this.lblpies1.AutoSize = true;
//            this.lblpies1.Location = new System.Drawing.Point(333, 259);
//            this.lblpies1.Name = "lblpies1";
//            this.lblpies1.Size = new System.Drawing.Size(53, 13);
//            this.lblpies1.TabIndex = 8;
//            this.lblpies1.Text = "Total pies";
//            // 
//            // btnlimpiarmedidas
//            // 
//            this.btnlimpiarmedidas.Location = new System.Drawing.Point(625, 384);
//            this.btnlimpiarmedidas.Name = "btnlimpiarmedidas";
//            this.btnlimpiarmedidas.Size = new System.Drawing.Size(89, 41);
//            this.btnlimpiarmedidas.TabIndex = 49;
//            this.btnlimpiarmedidas.Text = "Limpiar medidas";
//            this.btnlimpiarmedidas.UseVisualStyleBackColor = true;
//            this.btnlimpiarmedidas.Click += new System.EventHandler(this.btnlimpiarmedidas_Click);
//            // 
//            // lblcalculopies
//            // 
//            this.lblcalculopies.AutoSize = true;
//            this.lblcalculopies.Location = new System.Drawing.Point(416, 259);
//            this.lblcalculopies.Name = "lblcalculopies";
//            this.lblcalculopies.Size = new System.Drawing.Size(0, 13);
//            this.lblcalculopies.TabIndex = 11;
//            this.lblcalculopies.Visible = false;
//            // 
//            // lblseleccionmaderas
//            // 
//            this.lblseleccionmaderas.AutoSize = true;
//            this.lblseleccionmaderas.Location = new System.Drawing.Point(637, 115);
//            this.lblseleccionmaderas.Name = "lblseleccionmaderas";
//            this.lblseleccionmaderas.Size = new System.Drawing.Size(112, 13);
//            this.lblseleccionmaderas.TabIndex = 12;
//            this.lblseleccionmaderas.Text = "Seleccion de maderas";
//            this.lblseleccionmaderas.Click += new System.EventHandler(this.lblmaderas_Click);
//            // 
//            // label5
//            // 
//            this.label5.AutoSize = true;
//            this.label5.Location = new System.Drawing.Point(637, 326);
//            this.label5.Name = "label5";
//            this.label5.Size = new System.Drawing.Size(66, 13);
//            this.label5.TabIndex = 14;
//            this.label5.Text = "Presupuesto";
//            this.label5.Click += new System.EventHandler(this.label5_Click);
//            // 
//            // lblpresupuesto
//            // 
//            this.lblpresupuesto.AutoSize = true;
//            this.lblpresupuesto.Location = new System.Drawing.Point(720, 326);
//            this.lblpresupuesto.Name = "lblpresupuesto";
//            this.lblpresupuesto.Size = new System.Drawing.Size(0, 13);
//            this.lblpresupuesto.TabIndex = 15;
//            this.lblpresupuesto.Visible = false;
//            // 
//            // pcbimagenmaderareciclada
//            // 
//            this.pcbimagenmaderareciclada.Location = new System.Drawing.Point(662, 42);
//            this.pcbimagenmaderareciclada.Name = "pcbimagenmaderareciclada";
//            this.pcbimagenmaderareciclada.Size = new System.Drawing.Size(161, 67);
//            this.pcbimagenmaderareciclada.TabIndex = 19;
//            this.pcbimagenmaderareciclada.TabStop = false;
//            // 
//            // btnguardarpresupuesto
//            // 
//            this.btnguardarpresupuesto.Location = new System.Drawing.Point(530, 439);
//            this.btnguardarpresupuesto.Name = "btnguardarpresupuesto";
//            this.btnguardarpresupuesto.Size = new System.Drawing.Size(89, 41);
//            this.btnguardarpresupuesto.TabIndex = 50;
//            this.btnguardarpresupuesto.Text = "Guardar presupuesto";
//            this.btnguardarpresupuesto.UseVisualStyleBackColor = true;
//            this.btnguardarpresupuesto.Click += new System.EventHandler(this.btnguardarpresupuesto_Click);
//            // 
//            // cmbmaderas
//            // 
//            this.cmbmaderas.FormattingEnabled = true;
//            this.cmbmaderas.Location = new System.Drawing.Point(638, 136);
//            this.cmbmaderas.Name = "cmbmaderas";
//            this.cmbmaderas.Size = new System.Drawing.Size(174, 21);
//            this.cmbmaderas.TabIndex = 37;
//            this.cmbmaderas.SelectedIndexChanged += new System.EventHandler(this.cmbmaderas_SelectedIndexChanged);
//            // 
//            // lblpies
//            // 
//            this.lblpies.AutoSize = true;
//            this.lblpies.Location = new System.Drawing.Point(637, 163);
//            this.lblpies.Name = "lblpies";
//            this.lblpies.Size = new System.Drawing.Size(66, 13);
//            this.lblpies.TabIndex = 22;
//            this.lblpies.Text = "Valor por pie";
//            // 
//            // lblvalorpies
//            // 
//            this.lblvalorpies.AutoSize = true;
//            this.lblvalorpies.Location = new System.Drawing.Point(720, 163);
//            this.lblvalorpies.Name = "lblvalorpies";
//            this.lblvalorpies.Size = new System.Drawing.Size(0, 13);
//            this.lblvalorpies.TabIndex = 23;
//            this.lblvalorpies.Visible = false;
//            // 
//            // calculopiesDataSet
//            // 
//            this.calculopiesDataSet.DataSetName = "CalculopiesDataSet";
//            this.calculopiesDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
//            // 
//            // maderasBindingSource
//            // 
//            this.maderasBindingSource.DataMember = "Maderas";
//            this.maderasBindingSource.DataSource = this.calculopiesDataSet;
//            // 
//            // maderasTableAdapter
//            // 
//            this.maderasTableAdapter.ClearBeforeFill = true;
//            // 
//            // dgvmaderas
//            // 
//            this.dgvmaderas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
//            this.dgvmaderas.Location = new System.Drawing.Point(640, 233);
//            this.dgvmaderas.Name = "dgvmaderas";
//            this.dgvmaderas.Size = new System.Drawing.Size(172, 78);
//            this.dgvmaderas.TabIndex = 24;
//            this.dgvmaderas.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvmaderas_CellContentClick);
//            // 
//            // btnmostrartodas
//            // 
//            this.btnmostrartodas.Location = new System.Drawing.Point(638, 185);
//            this.btnmostrartodas.Name = "btnmostrartodas";
//            this.btnmostrartodas.Size = new System.Drawing.Size(174, 39);
//            this.btnmostrartodas.TabIndex = 25;
//            this.btnmostrartodas.Text = "Mostrar todas las maderas";
//            this.btnmostrartodas.UseVisualStyleBackColor = true;
//            this.btnmostrartodas.Click += new System.EventHandler(this.btnmostrartodas_Click);
//            // 
//            // btncerrar
//            // 
//            this.btncerrar.Location = new System.Drawing.Point(625, 439);
//            this.btncerrar.Name = "btncerrar";
//            this.btncerrar.Size = new System.Drawing.Size(89, 41);
//            this.btncerrar.TabIndex = 51;
//            this.btncerrar.Text = "Cerrar";
//            this.btncerrar.UseVisualStyleBackColor = true;
//            this.btncerrar.Click += new System.EventHandler(this.btncerrar_Click);
//            // 
//            // lblcantidad
//            // 
//            this.lblcantidad.AutoSize = true;
//            this.lblcantidad.Location = new System.Drawing.Point(494, 73);
//            this.lblcantidad.Name = "lblcantidad";
//            this.lblcantidad.Size = new System.Drawing.Size(49, 13);
//            this.lblcantidad.TabIndex = 27;
//            this.lblcantidad.Text = "Cantidad";
//            // 
//            // txtcantidad1
//            // 
//            this.txtcantidad1.Location = new System.Drawing.Point(483, 92);
//            this.txtcantidad1.Name = "txtcantidad1";
//            this.txtcantidad1.Size = new System.Drawing.Size(74, 20);
//            this.txtcantidad1.TabIndex = 5;
//            // 
//            // lblmadera
//            // 
//            this.lblmadera.AutoSize = true;
//            this.lblmadera.Location = new System.Drawing.Point(40, 73);
//            this.lblmadera.Name = "lblmadera";
//            this.lblmadera.Size = new System.Drawing.Size(48, 13);
//            this.lblmadera.TabIndex = 29;
//            this.lblmadera.Text = "Maderas";
//            // 
//            // label4
//            // 
//            this.label4.AutoSize = true;
//            this.label4.Location = new System.Drawing.Point(43, 95);
//            this.label4.Name = "label4";
//            this.label4.Size = new System.Drawing.Size(52, 13);
//            this.label4.TabIndex = 30;
//            this.label4.Text = "Madera 1";
//            // 
//            // label8
//            // 
//            this.label8.AutoSize = true;
//            this.label8.Location = new System.Drawing.Point(43, 118);
//            this.label8.Name = "label8";
//            this.label8.Size = new System.Drawing.Size(52, 13);
//            this.label8.TabIndex = 31;
//            this.label8.Text = "Madera 2";
//            // 
//            // label9
//            // 
//            this.label9.AutoSize = true;
//            this.label9.Location = new System.Drawing.Point(43, 140);
//            this.label9.Name = "label9";
//            this.label9.Size = new System.Drawing.Size(52, 13);
//            this.label9.TabIndex = 32;
//            this.label9.Text = "Madera 3";
//            // 
//            // label10
//            // 
//            this.label10.AutoSize = true;
//            this.label10.Location = new System.Drawing.Point(43, 163);
//            this.label10.Name = "label10";
//            this.label10.Size = new System.Drawing.Size(52, 13);
//            this.label10.TabIndex = 33;
//            this.label10.Text = "Madera 4";
//            // 
//            // label11
//            // 
//            this.label11.AutoSize = true;
//            this.label11.Location = new System.Drawing.Point(43, 185);
//            this.label11.Name = "label11";
//            this.label11.Size = new System.Drawing.Size(52, 13);
//            this.label11.TabIndex = 34;
//            this.label11.Text = "Madera 5";
//            // 
//            // label12
//            // 
//            this.label12.AutoSize = true;
//            this.label12.Location = new System.Drawing.Point(43, 207);
//            this.label12.Name = "label12";
//            this.label12.Size = new System.Drawing.Size(52, 13);
//            this.label12.TabIndex = 35;
//            this.label12.Text = "Madera 6";
//            // 
//            // txtcantidad2
//            // 
//            this.txtcantidad2.Location = new System.Drawing.Point(483, 115);
//            this.txtcantidad2.Name = "txtcantidad2";
//            this.txtcantidad2.Size = new System.Drawing.Size(74, 20);
//            this.txtcantidad2.TabIndex = 11;
//            // 
//            // txtlargom2
//            // 
//            this.txtlargom2.Location = new System.Drawing.Point(403, 115);
//            this.txtlargom2.Name = "txtlargom2";
//            this.txtlargom2.Size = new System.Drawing.Size(74, 20);
//            this.txtlargom2.TabIndex = 10;
//            // 
//            // txtanchom2
//            // 
//            this.txtanchom2.Location = new System.Drawing.Point(323, 115);
//            this.txtanchom2.Name = "txtanchom2";
//            this.txtanchom2.Size = new System.Drawing.Size(74, 20);
//            this.txtanchom2.TabIndex = 9;
//            // 
//            // txtespesorm2
//            // 
//            this.txtespesorm2.Location = new System.Drawing.Point(243, 115);
//            this.txtespesorm2.Name = "txtespesorm2";
//            this.txtespesorm2.Size = new System.Drawing.Size(74, 20);
//            this.txtespesorm2.TabIndex = 8;
//            // 
//            // txtcantidad3
//            // 
//            this.txtcantidad3.Location = new System.Drawing.Point(483, 137);
//            this.txtcantidad3.Name = "txtcantidad3";
//            this.txtcantidad3.Size = new System.Drawing.Size(74, 20);
//            this.txtcantidad3.TabIndex = 17;
//            // 
//            // txtlargom3
//            // 
//            this.txtlargom3.Location = new System.Drawing.Point(403, 137);
//            this.txtlargom3.Name = "txtlargom3";
//            this.txtlargom3.Size = new System.Drawing.Size(74, 20);
//            this.txtlargom3.TabIndex = 16;
//            // 
//            // txtanchom3
//            // 
//            this.txtanchom3.Location = new System.Drawing.Point(323, 137);
//            this.txtanchom3.Name = "txtanchom3";
//            this.txtanchom3.Size = new System.Drawing.Size(74, 20);
//            this.txtanchom3.TabIndex = 15;
//            // 
//            // txtespesorm3
//            // 
//            this.txtespesorm3.Location = new System.Drawing.Point(243, 137);
//            this.txtespesorm3.Name = "txtespesorm3";
//            this.txtespesorm3.Size = new System.Drawing.Size(74, 20);
//            this.txtespesorm3.TabIndex = 14;
//            // 
//            // txtcantidad4
//            // 
//            this.txtcantidad4.Location = new System.Drawing.Point(483, 160);
//            this.txtcantidad4.Name = "txtcantidad4";
//            this.txtcantidad4.Size = new System.Drawing.Size(74, 20);
//            this.txtcantidad4.TabIndex = 23;
//            // 
//            // txtlargom4
//            // 
//            this.txtlargom4.Location = new System.Drawing.Point(403, 160);
//            this.txtlargom4.Name = "txtlargom4";
//            this.txtlargom4.Size = new System.Drawing.Size(74, 20);
//            this.txtlargom4.TabIndex = 22;
//            // 
//            // txtanchom4
//            // 
//            this.txtanchom4.Location = new System.Drawing.Point(323, 160);
//            this.txtanchom4.Name = "txtanchom4";
//            this.txtanchom4.Size = new System.Drawing.Size(74, 20);
//            this.txtanchom4.TabIndex = 21;
//            // 
//            // txtespesorm4
//            // 
//            this.txtespesorm4.Location = new System.Drawing.Point(243, 160);
//            this.txtespesorm4.Name = "txtespesorm4";
//            this.txtespesorm4.Size = new System.Drawing.Size(74, 20);
//            this.txtespesorm4.TabIndex = 20;
//            // 
//            // txtcantidad5
//            // 
//            this.txtcantidad5.Location = new System.Drawing.Point(483, 182);
//            this.txtcantidad5.Name = "txtcantidad5";
//            this.txtcantidad5.Size = new System.Drawing.Size(74, 20);
//            this.txtcantidad5.TabIndex = 29;
//            // 
//            // txtlargom5
//            // 
//            this.txtlargom5.Location = new System.Drawing.Point(403, 182);
//            this.txtlargom5.Name = "txtlargom5";
//            this.txtlargom5.Size = new System.Drawing.Size(74, 20);
//            this.txtlargom5.TabIndex = 28;
//            // 
//            // txtanchom5
//            // 
//            this.txtanchom5.Location = new System.Drawing.Point(323, 182);
//            this.txtanchom5.Name = "txtanchom5";
//            this.txtanchom5.Size = new System.Drawing.Size(74, 20);
//            this.txtanchom5.TabIndex = 27;
//            this.txtanchom5.TextChanged += new System.EventHandler(this.textBox16_TextChanged);
//            // 
//            // txtespesorm5
//            // 
//            this.txtespesorm5.Location = new System.Drawing.Point(243, 182);
//            this.txtespesorm5.Name = "txtespesorm5";
//            this.txtespesorm5.Size = new System.Drawing.Size(74, 20);
//            this.txtespesorm5.TabIndex = 26;
//            this.txtespesorm5.TextChanged += new System.EventHandler(this.txtespesorm5_TextChanged);
//            // 
//            // txtcantidad6
//            // 
//            this.txtcantidad6.Location = new System.Drawing.Point(483, 204);
//            this.txtcantidad6.Name = "txtcantidad6";
//            this.txtcantidad6.Size = new System.Drawing.Size(74, 20);
//            this.txtcantidad6.TabIndex = 35;
//            // 
//            // txtlargom6
//            // 
//            this.txtlargom6.Location = new System.Drawing.Point(403, 204);
//            this.txtlargom6.Name = "txtlargom6";
//            this.txtlargom6.Size = new System.Drawing.Size(74, 20);
//            this.txtlargom6.TabIndex = 34;
//            // 
//            // txtanchom6
//            // 
//            this.txtanchom6.Location = new System.Drawing.Point(323, 204);
//            this.txtanchom6.Name = "txtanchom6";
//            this.txtanchom6.Size = new System.Drawing.Size(74, 20);
//            this.txtanchom6.TabIndex = 33;
//            // 
//            // txtespesorm6
//            // 
//            this.txtespesorm6.Location = new System.Drawing.Point(243, 204);
//            this.txtespesorm6.Name = "txtespesorm6";
//            this.txtespesorm6.Size = new System.Drawing.Size(74, 20);
//            this.txtespesorm6.TabIndex = 32;
//            // 
//            // lblpie
//            // 
//            this.lblpie.AutoSize = true;
//            this.lblpie.Location = new System.Drawing.Point(574, 73);
//            this.lblpie.Name = "lblpie";
//            this.lblpie.Size = new System.Drawing.Size(27, 13);
//            this.lblpie.TabIndex = 56;
//            this.lblpie.Text = "Pies";
//            // 
//            // lblpie1
//            // 
//            this.lblpie1.AutoSize = true;
//            this.lblpie1.Location = new System.Drawing.Point(574, 95);
//            this.lblpie1.Name = "lblpie1";
//            this.lblpie1.Size = new System.Drawing.Size(13, 13);
//            this.lblpie1.TabIndex = 57;
//            this.lblpie1.Text = "1";
//            this.lblpie1.Visible = false;
//            // 
//            // lblpie2
//            // 
//            this.lblpie2.AutoSize = true;
//            this.lblpie2.Location = new System.Drawing.Point(574, 118);
//            this.lblpie2.Name = "lblpie2";
//            this.lblpie2.Size = new System.Drawing.Size(13, 13);
//            this.lblpie2.TabIndex = 58;
//            this.lblpie2.Text = "2";
//            this.lblpie2.Visible = false;
//            // 
//            // lblpie3
//            // 
//            this.lblpie3.AutoSize = true;
//            this.lblpie3.Location = new System.Drawing.Point(574, 140);
//            this.lblpie3.Name = "lblpie3";
//            this.lblpie3.Size = new System.Drawing.Size(13, 13);
//            this.lblpie3.TabIndex = 59;
//            this.lblpie3.Text = "3";
//            this.lblpie3.Visible = false;
//            // 
//            // lblpie4
//            // 
//            this.lblpie4.AutoSize = true;
//            this.lblpie4.Location = new System.Drawing.Point(574, 163);
//            this.lblpie4.Name = "lblpie4";
//            this.lblpie4.Size = new System.Drawing.Size(13, 13);
//            this.lblpie4.TabIndex = 60;
//            this.lblpie4.Text = "4";
//            this.lblpie4.Visible = false;
//            // 
//            // lblpie5
//            // 
//            this.lblpie5.AutoSize = true;
//            this.lblpie5.Location = new System.Drawing.Point(574, 185);
//            this.lblpie5.Name = "lblpie5";
//            this.lblpie5.Size = new System.Drawing.Size(13, 13);
//            this.lblpie5.TabIndex = 61;
//            this.lblpie5.Text = "5";
//            this.lblpie5.Visible = false;
//            this.lblpie5.Click += new System.EventHandler(this.lblpie5_Click);
//            // 
//            // lblpie6
//            // 
//            this.lblpie6.AutoSize = true;
//            this.lblpie6.Location = new System.Drawing.Point(574, 206);
//            this.lblpie6.Name = "lblpie6";
//            this.lblpie6.Size = new System.Drawing.Size(13, 13);
//            this.lblpie6.TabIndex = 62;
//            this.lblpie6.Text = "6";
//            this.lblpie6.Visible = false;
//            // 
//            // chk1
//            // 
//            this.chk1.AutoSize = true;
//            this.chk1.Location = new System.Drawing.Point(12, 95);
//            this.chk1.Name = "chk1";
//            this.chk1.Size = new System.Drawing.Size(15, 14);
//            this.chk1.TabIndex = 0;
//            this.chk1.UseVisualStyleBackColor = true;
//            // 
//            // chk2
//            // 
//            this.chk2.AutoSize = true;
//            this.chk2.Location = new System.Drawing.Point(12, 118);
//            this.chk2.Name = "chk2";
//            this.chk2.Size = new System.Drawing.Size(15, 14);
//            this.chk2.TabIndex = 6;
//            this.chk2.UseVisualStyleBackColor = true;
//            // 
//            // chk3
//            // 
//            this.chk3.AutoSize = true;
//            this.chk3.Location = new System.Drawing.Point(12, 139);
//            this.chk3.Name = "chk3";
//            this.chk3.Size = new System.Drawing.Size(15, 14);
//            this.chk3.TabIndex = 12;
//            this.chk3.UseVisualStyleBackColor = true;
//            // 
//            // chk6
//            // 
//            this.chk6.AutoSize = true;
//            this.chk6.Location = new System.Drawing.Point(12, 205);
//            this.chk6.Name = "chk6";
//            this.chk6.Size = new System.Drawing.Size(15, 14);
//            this.chk6.TabIndex = 30;
//            this.chk6.UseVisualStyleBackColor = true;
//            // 
//            // chk5
//            // 
//            this.chk5.AutoSize = true;
//            this.chk5.Location = new System.Drawing.Point(12, 184);
//            this.chk5.Name = "chk5";
//            this.chk5.Size = new System.Drawing.Size(15, 14);
//            this.chk5.TabIndex = 24;
//            this.chk5.UseVisualStyleBackColor = true;
//            // 
//            // chk4
//            // 
//            this.chk4.AutoSize = true;
//            this.chk4.Location = new System.Drawing.Point(12, 161);
//            this.chk4.Name = "chk4";
//            this.chk4.Size = new System.Drawing.Size(15, 14);
//            this.chk4.TabIndex = 18;
//            this.chk4.UseVisualStyleBackColor = true;
//            // 
//            // chkguias1
//            // 
//            this.chkguias1.AutoSize = true;
//            this.chkguias1.Location = new System.Drawing.Point(12, 563);
//            this.chkguias1.Name = "chkguias1";
//            this.chkguias1.Size = new System.Drawing.Size(15, 14);
//            this.chkguias1.TabIndex = 38;
//            this.chkguias1.UseVisualStyleBackColor = true;
//            this.chkguias1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
//            // 
//            // lblguias1
//            // 
//            this.lblguias1.AutoSize = true;
//            this.lblguias1.Location = new System.Drawing.Point(40, 564);
//            this.lblguias1.Name = "lblguias1";
//            this.lblguias1.Size = new System.Drawing.Size(99, 13);
//            this.lblguias1.TabIndex = 76;
//            this.lblguias1.Text = "Cajones con Guias ";
//            // 
//            // txtguias1
//            // 
//            this.txtguias1.Location = new System.Drawing.Point(145, 557);
//            this.txtguias1.Name = "txtguias1";
//            this.txtguias1.Size = new System.Drawing.Size(30, 20);
//            this.txtguias1.TabIndex = 39;
//            // 
//            // cmbguias1
//            // 
//            this.cmbguias1.FormattingEnabled = true;
//            this.cmbguias1.Location = new System.Drawing.Point(181, 557);
//            this.cmbguias1.Name = "cmbguias1";
//            this.cmbguias1.Size = new System.Drawing.Size(79, 21);
//            this.cmbguias1.TabIndex = 7840;
//            this.cmbguias1.SelectedIndexChanged += new System.EventHandler(this.cmbguias_SelectedIndexChanged);
//            // 
//            // label13
//            // 
//            this.label13.AutoSize = true;
//            this.label13.Location = new System.Drawing.Point(12, 530);
//            this.label13.Name = "label13";
//            this.label13.Size = new System.Drawing.Size(219, 13);
//            this.label13.TabIndex = 79;
//            this.label13.Text = "Seleccione la cantidad y el largo de las guias";
//            // 
//            // lbltitulovalorguias
//            // 
//            this.lbltitulovalorguias.AutoSize = true;
//            this.lbltitulovalorguias.Location = new System.Drawing.Point(273, 530);
//            this.lbltitulovalorguias.Name = "lbltitulovalorguias";
//            this.lbltitulovalorguias.Size = new System.Drawing.Size(41, 13);
//            this.lbltitulovalorguias.TabIndex = 80;
//            this.lbltitulovalorguias.Text = "Unidad";
//            // 
//            // lblvalorguias1
//            // 
//            this.lblvalorguias1.AutoSize = true;
//            this.lblvalorguias1.Location = new System.Drawing.Point(273, 563);
//            this.lblvalorguias1.Name = "lblvalorguias1";
//            this.lblvalorguias1.Size = new System.Drawing.Size(13, 13);
//            this.lblvalorguias1.TabIndex = 81;
//            this.lblvalorguias1.Text = "$";
//            // 
//            // lbltitulototal
//            // 
//            this.lbltitulototal.AutoSize = true;
//            this.lbltitulototal.Location = new System.Drawing.Point(324, 530);
//            this.lbltitulototal.Name = "lbltitulototal";
//            this.lbltitulototal.Size = new System.Drawing.Size(31, 13);
//            this.lbltitulototal.TabIndex = 82;
//            this.lbltitulototal.Text = "Total";
//            // 
//            // lbltotalguias1
//            // 
//            this.lbltotalguias1.AutoSize = true;
//            this.lbltotalguias1.Location = new System.Drawing.Point(324, 563);
//            this.lbltotalguias1.Name = "lbltotalguias1";
//            this.lbltotalguias1.Size = new System.Drawing.Size(13, 13);
//            this.lbltotalguias1.TabIndex = 83;
//            this.lbltotalguias1.Text = "$";
//            // 
//            // btncalcularpresupuesto
//            // 
//            this.btncalcularpresupuesto.Location = new System.Drawing.Point(530, 384);
//            this.btncalcularpresupuesto.Name = "btncalcularpresupuesto";
//            this.btncalcularpresupuesto.Size = new System.Drawing.Size(89, 41);
//            this.btncalcularpresupuesto.TabIndex = 48;
//            this.btncalcularpresupuesto.Text = "Calcular presupuesto";
//            this.btncalcularpresupuesto.UseVisualStyleBackColor = true;
//            this.btncalcularpresupuesto.Click += new System.EventHandler(this.btncalcularpresupuesto_Click);
//            // 
//            // lbltotalguias2
//            // 
//            this.lbltotalguias2.AutoSize = true;
//            this.lbltotalguias2.Location = new System.Drawing.Point(324, 590);
//            this.lbltotalguias2.Name = "lbltotalguias2";
//            this.lbltotalguias2.Size = new System.Drawing.Size(13, 13);
//            this.lbltotalguias2.TabIndex = 90;
//            this.lbltotalguias2.Text = "$";
//            // 
//            // lblvalorguias2
//            // 
//            this.lblvalorguias2.AutoSize = true;
//            this.lblvalorguias2.Location = new System.Drawing.Point(273, 590);
//            this.lblvalorguias2.Name = "lblvalorguias2";
//            this.lblvalorguias2.Size = new System.Drawing.Size(13, 13);
//            this.lblvalorguias2.TabIndex = 89;
//            this.lblvalorguias2.Text = "$";
//            // 
//            // cmbguias2
//            // 
//            this.cmbguias2.FormattingEnabled = true;
//            this.cmbguias2.Location = new System.Drawing.Point(181, 584);
//            this.cmbguias2.Name = "cmbguias2";
//            this.cmbguias2.Size = new System.Drawing.Size(79, 21);
//            this.cmbguias2.TabIndex = 43;
//            this.cmbguias2.SelectedIndexChanged += new System.EventHandler(this.cmbguias2_SelectedIndexChanged);
//            // 
//            // txtguias2
//            // 
//            this.txtguias2.Location = new System.Drawing.Point(145, 584);
//            this.txtguias2.Name = "txtguias2";
//            this.txtguias2.Size = new System.Drawing.Size(30, 20);
//            this.txtguias2.TabIndex = 42;
//            // 
//            // lblguias2
//            // 
//            this.lblguias2.AutoSize = true;
//            this.lblguias2.Location = new System.Drawing.Point(40, 591);
//            this.lblguias2.Name = "lblguias2";
//            this.lblguias2.Size = new System.Drawing.Size(99, 13);
//            this.lblguias2.TabIndex = 86;
//            this.lblguias2.Text = "Cajones con Guias ";
//            // 
//            // chkguias2
//            // 
//            this.chkguias2.AutoSize = true;
//            this.chkguias2.Location = new System.Drawing.Point(12, 590);
//            this.chkguias2.Name = "chkguias2";
//            this.chkguias2.Size = new System.Drawing.Size(15, 14);
//            this.chkguias2.TabIndex = 41;
//            this.chkguias2.UseVisualStyleBackColor = true;
//            this.chkguias2.CheckedChanged += new System.EventHandler(this.chkguias2_CheckedChanged);
//            // 
//            // lbltotalgastosvarios
//            // 
//            this.lbltotalgastosvarios.AutoSize = true;
//            this.lbltotalgastosvarios.Location = new System.Drawing.Point(324, 647);
//            this.lbltotalgastosvarios.Name = "lbltotalgastosvarios";
//            this.lbltotalgastosvarios.Size = new System.Drawing.Size(13, 13);
//            this.lbltotalgastosvarios.TabIndex = 102;
//            this.lbltotalgastosvarios.Text = "$";
//            // 
//            // txtgastosvarios
//            // 
//            this.txtgastosvarios.Location = new System.Drawing.Point(145, 641);
//            this.txtgastosvarios.Name = "txtgastosvarios";
//            this.txtgastosvarios.Size = new System.Drawing.Size(30, 20);
//            this.txtgastosvarios.TabIndex = 47;
//            // 
//            // label16
//            // 
//            this.label16.AutoSize = true;
//            this.label16.Location = new System.Drawing.Point(40, 648);
//            this.label16.Name = "label16";
//            this.label16.Size = new System.Drawing.Size(71, 13);
//            this.label16.TabIndex = 98;
//            this.label16.Text = "Gastos varios";
//            // 
//            // chkgastosvarios
//            // 
//            this.chkgastosvarios.AutoSize = true;
//            this.chkgastosvarios.Location = new System.Drawing.Point(12, 647);
//            this.chkgastosvarios.Name = "chkgastosvarios";
//            this.chkgastosvarios.Size = new System.Drawing.Size(15, 14);
//            this.chkgastosvarios.TabIndex = 46;
//            this.chkgastosvarios.UseVisualStyleBackColor = true;
//            // 
//            // lbltotalgastosadicionales
//            // 
//            this.lbltotalgastosadicionales.AutoSize = true;
//            this.lbltotalgastosadicionales.Location = new System.Drawing.Point(324, 674);
//            this.lbltotalgastosadicionales.Name = "lbltotalgastosadicionales";
//            this.lbltotalgastosadicionales.Size = new System.Drawing.Size(13, 13);
//            this.lbltotalgastosadicionales.TabIndex = 96;
//            this.lbltotalgastosadicionales.Text = "$";
//            // 
//            // txtmateriales
//            // 
//            this.txtmateriales.Location = new System.Drawing.Point(145, 614);
//            this.txtmateriales.Name = "txtmateriales";
//            this.txtmateriales.Size = new System.Drawing.Size(30, 20);
//            this.txtmateriales.TabIndex = 45;
//            // 
//            // label19
//            // 
//            this.label19.AutoSize = true;
//            this.label19.Location = new System.Drawing.Point(40, 621);
//            this.label19.Name = "label19";
//            this.label19.Size = new System.Drawing.Size(82, 13);
//            this.label19.TabIndex = 92;
//            this.label19.Text = "Otros materiales";
//            // 
//            // chkotrosmateriales
//            // 
//            this.chkotrosmateriales.AutoSize = true;
//            this.chkotrosmateriales.Location = new System.Drawing.Point(12, 620);
//            this.chkotrosmateriales.Name = "chkotrosmateriales";
//            this.chkotrosmateriales.Size = new System.Drawing.Size(15, 14);
//            this.chkotrosmateriales.TabIndex = 44;
//            this.chkotrosmateriales.UseVisualStyleBackColor = true;
//            // 
//            // txtdescmad6
//            // 
//            this.txtdescmad6.Location = new System.Drawing.Point(101, 205);
//            this.txtdescmad6.Name = "txtdescmad6";
//            this.txtdescmad6.Size = new System.Drawing.Size(136, 20);
//            this.txtdescmad6.TabIndex = 31;
//            // 
//            // txtdescmad5
//            // 
//            this.txtdescmad5.Location = new System.Drawing.Point(101, 183);
//            this.txtdescmad5.Name = "txtdescmad5";
//            this.txtdescmad5.Size = new System.Drawing.Size(136, 20);
//            this.txtdescmad5.TabIndex = 25;
//            // 
//            // txtdescmad4
//            // 
//            this.txtdescmad4.Location = new System.Drawing.Point(101, 161);
//            this.txtdescmad4.Name = "txtdescmad4";
//            this.txtdescmad4.Size = new System.Drawing.Size(136, 20);
//            this.txtdescmad4.TabIndex = 19;
//            // 
//            // txtdescmad3
//            // 
//            this.txtdescmad3.Location = new System.Drawing.Point(101, 138);
//            this.txtdescmad3.Name = "txtdescmad3";
//            this.txtdescmad3.Size = new System.Drawing.Size(136, 20);
//            this.txtdescmad3.TabIndex = 13;
//            // 
//            // txtdescmad2
//            // 
//            this.txtdescmad2.Location = new System.Drawing.Point(101, 116);
//            this.txtdescmad2.Name = "txtdescmad2";
//            this.txtdescmad2.Size = new System.Drawing.Size(136, 20);
//            this.txtdescmad2.TabIndex = 7;
//            // 
//            // txtdescmad1
//            // 
//            this.txtdescmad1.Location = new System.Drawing.Point(101, 93);
//            this.txtdescmad1.Name = "txtdescmad1";
//            this.txtdescmad1.Size = new System.Drawing.Size(136, 20);
//            this.txtdescmad1.TabIndex = 1;
//            // 
//            // label20
//            // 
//            this.label20.AutoSize = true;
//            this.label20.Location = new System.Drawing.Point(107, 73);
//            this.label20.Name = "label20";
//            this.label20.Size = new System.Drawing.Size(101, 13);
//            this.label20.TabIndex = 109;
//            this.label20.Text = "Descripcion madera";
//            // 
//            // lblotrosmateriales
//            // 
//            this.lblotrosmateriales.AutoSize = true;
//            this.lblotrosmateriales.Location = new System.Drawing.Point(324, 621);
//            this.lblotrosmateriales.Name = "lblotrosmateriales";
//            this.lblotrosmateriales.Size = new System.Drawing.Size(13, 13);
//            this.lblotrosmateriales.TabIndex = 110;
//            this.lblotrosmateriales.Text = "$";
//            // 
//            // label14
//            // 
//            this.label14.AutoSize = true;
//            this.label14.Location = new System.Drawing.Point(40, 674);
//            this.label14.Name = "label14";
//            this.label14.Size = new System.Drawing.Size(122, 13);
//            this.label14.TabIndex = 111;
//            this.label14.Text = "Total gastos Adicionales";
//            // 
//            // lbldesperdicio
//            // 
//            this.lbldesperdicio.AutoSize = true;
//            this.lbldesperdicio.Location = new System.Drawing.Point(9, 230);
//            this.lbldesperdicio.Name = "lbldesperdicio";
//            this.lbldesperdicio.Size = new System.Drawing.Size(74, 13);
//            this.lbldesperdicio.TabIndex = 7841;
//            this.lbldesperdicio.Text = "Desperdicio %";
//            // 
//            // lblganancia
//            // 
//            this.lblganancia.AutoSize = true;
//            this.lblganancia.Location = new System.Drawing.Point(9, 254);
//            this.lblganancia.Name = "lblganancia";
//            this.lblganancia.Size = new System.Drawing.Size(64, 13);
//            this.lblganancia.TabIndex = 7843;
//            this.lblganancia.Text = "Ganancia %";
//            // 
//            // txtganancia
//            // 
//            this.txtganancia.Location = new System.Drawing.Point(101, 252);
//            this.txtganancia.Name = "txtganancia";
//            this.txtganancia.Size = new System.Drawing.Size(177, 20);
//            this.txtganancia.TabIndex = 7845;
//            // 
//            // txtdesperdicio
//            // 
//            this.txtdesperdicio.Location = new System.Drawing.Point(101, 230);
//            this.txtdesperdicio.Name = "txtdesperdicio";
//            this.txtdesperdicio.Size = new System.Drawing.Size(177, 20);
//            this.txtdesperdicio.TabIndex = 7844;
//            // 
//            // chkvidrio1
//            // 
//            this.chkvidrio1.AutoSize = true;
//            this.chkvidrio1.Location = new System.Drawing.Point(12, 326);
//            this.chkvidrio1.Name = "chkvidrio1";
//            this.chkvidrio1.Size = new System.Drawing.Size(15, 14);
//            this.chkvidrio1.TabIndex = 7846;
//            this.chkvidrio1.UseVisualStyleBackColor = true;
//            // 
//            // label15
//            // 
//            this.label15.AutoSize = true;
//            this.label15.Location = new System.Drawing.Point(43, 327);
//            this.label15.Name = "label15";
//            this.label15.Size = new System.Drawing.Size(39, 13);
//            this.label15.TabIndex = 7847;
//            this.label15.Text = "Vidrio1";
//            // 
//            // txtvidriolargo1
//            // 
//            this.txtvidriolargo1.Location = new System.Drawing.Point(199, 319);
//            this.txtvidriolargo1.Name = "txtvidriolargo1";
//            this.txtvidriolargo1.Size = new System.Drawing.Size(56, 20);
//            this.txtvidriolargo1.TabIndex = 7848;
//            this.txtvidriolargo1.TextChanged += new System.EventHandler(this.txtvidriolargo1_TextChanged);
//            // 
//            // txtvidrioancho1
//            // 
//            this.txtvidrioancho1.Location = new System.Drawing.Point(261, 319);
//            this.txtvidrioancho1.Name = "txtvidrioancho1";
//            this.txtvidrioancho1.Size = new System.Drawing.Size(60, 20);
//            this.txtvidrioancho1.TabIndex = 7849;
//            this.txtvidrioancho1.TextChanged += new System.EventHandler(this.txtvidrioancho1_TextChanged);
//            // 
//            // txtvidriocant1
//            // 
//            this.txtvidriocant1.Location = new System.Drawing.Point(327, 319);
//            this.txtvidriocant1.Name = "txtvidriocant1";
//            this.txtvidriocant1.Size = new System.Drawing.Size(60, 20);
//            this.txtvidriocant1.TabIndex = 7850;
//            // 
//            // txtvidriocant2
//            // 
//            this.txtvidriocant2.Location = new System.Drawing.Point(327, 346);
//            this.txtvidriocant2.Name = "txtvidriocant2";
//            this.txtvidriocant2.Size = new System.Drawing.Size(60, 20);
//            this.txtvidriocant2.TabIndex = 7855;
//            // 
//            // txtvidrioancho2
//            // 
//            this.txtvidrioancho2.Location = new System.Drawing.Point(261, 345);
//            this.txtvidrioancho2.Name = "txtvidrioancho2";
//            this.txtvidrioancho2.Size = new System.Drawing.Size(60, 20);
//            this.txtvidrioancho2.TabIndex = 7854;
//            this.txtvidrioancho2.TextChanged += new System.EventHandler(this.txtvidrioancho2_TextChanged);
//            // 
//            // txtvidriolargo2
//            // 
//            this.txtvidriolargo2.Location = new System.Drawing.Point(199, 345);
//            this.txtvidriolargo2.Name = "txtvidriolargo2";
//            this.txtvidriolargo2.Size = new System.Drawing.Size(56, 20);
//            this.txtvidriolargo2.TabIndex = 7853;
//            this.txtvidriolargo2.TextChanged += new System.EventHandler(this.txtvidriolargo2_TextChanged);
//            // 
//            // label17
//            // 
//            this.label17.AutoSize = true;
//            this.label17.Location = new System.Drawing.Point(43, 353);
//            this.label17.Name = "label17";
//            this.label17.Size = new System.Drawing.Size(39, 13);
//            this.label17.TabIndex = 7852;
//            this.label17.Text = "Vidrio2";
//            // 
//            // chkvidrio2
//            // 
//            this.chkvidrio2.AutoSize = true;
//            this.chkvidrio2.Location = new System.Drawing.Point(12, 352);
//            this.chkvidrio2.Name = "chkvidrio2";
//            this.chkvidrio2.Size = new System.Drawing.Size(15, 14);
//            this.chkvidrio2.TabIndex = 7851;
//            this.chkvidrio2.UseVisualStyleBackColor = true;
//            // 
//            // txtvidriocant3
//            // 
//            this.txtvidriocant3.Location = new System.Drawing.Point(327, 371);
//            this.txtvidriocant3.Name = "txtvidriocant3";
//            this.txtvidriocant3.Size = new System.Drawing.Size(60, 20);
//            this.txtvidriocant3.TabIndex = 7860;
//            // 
//            // txtvidrioancho3
//            // 
//            this.txtvidrioancho3.Location = new System.Drawing.Point(261, 371);
//            this.txtvidrioancho3.Name = "txtvidrioancho3";
//            this.txtvidrioancho3.Size = new System.Drawing.Size(60, 20);
//            this.txtvidrioancho3.TabIndex = 7859;
//            this.txtvidrioancho3.TextChanged += new System.EventHandler(this.txtvidrioancho3_TextChanged);
//            // 
//            // txtvidriolargo3
//            // 
//            this.txtvidriolargo3.Location = new System.Drawing.Point(199, 371);
//            this.txtvidriolargo3.Name = "txtvidriolargo3";
//            this.txtvidriolargo3.Size = new System.Drawing.Size(56, 20);
//            this.txtvidriolargo3.TabIndex = 7858;
//            this.txtvidriolargo3.TextChanged += new System.EventHandler(this.txtvidriolargo3_TextChanged);
//            // 
//            // label18
//            // 
//            this.label18.AutoSize = true;
//            this.label18.Location = new System.Drawing.Point(43, 379);
//            this.label18.Name = "label18";
//            this.label18.Size = new System.Drawing.Size(39, 13);
//            this.label18.TabIndex = 7857;
//            this.label18.Text = "Vidrio3";
//            // 
//            // chkvidrio3
//            // 
//            this.chkvidrio3.AutoSize = true;
//            this.chkvidrio3.Location = new System.Drawing.Point(12, 378);
//            this.chkvidrio3.Name = "chkvidrio3";
//            this.chkvidrio3.Size = new System.Drawing.Size(15, 14);
//            this.chkvidrio3.TabIndex = 7856;
//            this.chkvidrio3.UseVisualStyleBackColor = true;
//            // 
//            // label21
//            // 
//            this.label21.AutoSize = true;
//            this.label21.Location = new System.Drawing.Point(196, 297);
//            this.label21.Name = "label21";
//            this.label21.Size = new System.Drawing.Size(59, 13);
//            this.label21.TabIndex = 7861;
//            this.label21.Text = "Largo (mts)";
//            // 
//            // label22
//            // 
//            this.label22.AutoSize = true;
//            this.label22.Location = new System.Drawing.Point(260, 298);
//            this.label22.Name = "label22";
//            this.label22.Size = new System.Drawing.Size(61, 13);
//            this.label22.TabIndex = 7862;
//            this.label22.Text = "Ancho (cm)";
//            // 
//            // label23
//            // 
//            this.label23.AutoSize = true;
//            this.label23.Location = new System.Drawing.Point(333, 298);
//            this.label23.Name = "label23";
//            this.label23.Size = new System.Drawing.Size(49, 13);
//            this.label23.TabIndex = 7863;
//            this.label23.Text = "Cantidad";
//            // 
//            // label24
//            // 
//            this.label24.AutoSize = true;
//            this.label24.Location = new System.Drawing.Point(451, 297);
//            this.label24.Name = "label24";
//            this.label24.Size = new System.Drawing.Size(31, 13);
//            this.label24.TabIndex = 7865;
//            this.label24.Text = "Total";
//            // 
//            // label25
//            // 
//            this.label25.AutoSize = true;
//            this.label25.Location = new System.Drawing.Point(400, 297);
//            this.label25.Name = "label25";
//            this.label25.Size = new System.Drawing.Size(41, 13);
//            this.label25.TabIndex = 7864;
//            this.label25.Text = "Unidad";
//            // 
//            // lblvidriototal2
//            // 
//            this.lblvidriototal2.AutoSize = true;
//            this.lblvidriototal2.Location = new System.Drawing.Point(450, 349);
//            this.lblvidriototal2.Name = "lblvidriototal2";
//            this.lblvidriototal2.Size = new System.Drawing.Size(13, 13);
//            this.lblvidriototal2.TabIndex = 7869;
//            this.lblvidriototal2.Text = "$";
//            // 
//            // lblvidriounidad2
//            // 
//            this.lblvidriounidad2.AutoSize = true;
//            this.lblvidriounidad2.Location = new System.Drawing.Point(400, 349);
//            this.lblvidriounidad2.Name = "lblvidriounidad2";
//            this.lblvidriounidad2.Size = new System.Drawing.Size(13, 13);
//            this.lblvidriounidad2.TabIndex = 7868;
//            this.lblvidriounidad2.Text = "$";
//            // 
//            // lblvidriototal1
//            // 
//            this.lblvidriototal1.AutoSize = true;
//            this.lblvidriototal1.Location = new System.Drawing.Point(451, 322);
//            this.lblvidriototal1.Name = "lblvidriototal1";
//            this.lblvidriototal1.Size = new System.Drawing.Size(13, 13);
//            this.lblvidriototal1.TabIndex = 7867;
//            this.lblvidriototal1.Text = "$";
//            // 
//            // lblvidriounidad1
//            // 
//            this.lblvidriounidad1.AutoSize = true;
//            this.lblvidriounidad1.Location = new System.Drawing.Point(400, 322);
//            this.lblvidriounidad1.Name = "lblvidriounidad1";
//            this.lblvidriounidad1.Size = new System.Drawing.Size(13, 13);
//            this.lblvidriounidad1.TabIndex = 7866;
//            this.lblvidriounidad1.Text = "$";
//            // 
//            // lblvidriototal3
//            // 
//            this.lblvidriototal3.AutoSize = true;
//            this.lblvidriototal3.Location = new System.Drawing.Point(451, 374);
//            this.lblvidriototal3.Name = "lblvidriototal3";
//            this.lblvidriototal3.Size = new System.Drawing.Size(13, 13);
//            this.lblvidriototal3.TabIndex = 7871;
//            this.lblvidriototal3.Text = "$";
//            // 
//            // lblvidriounidad3
//            // 
//            this.lblvidriounidad3.AutoSize = true;
//            this.lblvidriounidad3.Location = new System.Drawing.Point(400, 374);
//            this.lblvidriounidad3.Name = "lblvidriounidad3";
//            this.lblvidriounidad3.Size = new System.Drawing.Size(13, 13);
//            this.lblvidriounidad3.TabIndex = 7870;
//            this.lblvidriounidad3.Text = "$";
//            // 
//            // label26
//            // 
//            this.label26.AutoSize = true;
//            this.label26.Location = new System.Drawing.Point(141, 400);
//            this.label26.Name = "label26";
//            this.label26.Size = new System.Drawing.Size(64, 13);
//            this.label26.TabIndex = 7873;
//            this.label26.Text = "Total vidrios";
//            // 
//            // lbltotalvidrios
//            // 
//            this.lbltotalvidrios.AutoSize = true;
//            this.lbltotalvidrios.Location = new System.Drawing.Point(451, 399);
//            this.lbltotalvidrios.Name = "lbltotalvidrios";
//            this.lbltotalvidrios.Size = new System.Drawing.Size(13, 13);
//            this.lbltotalvidrios.TabIndex = 7872;
//            this.lbltotalvidrios.Text = "$";
//            // 
//            // cmbvidrios1
//            // 
//            this.cmbvidrios1.FormattingEnabled = true;
//            this.cmbvidrios1.Location = new System.Drawing.Point(88, 320);
//            this.cmbvidrios1.Name = "cmbvidrios1";
//            this.cmbvidrios1.Size = new System.Drawing.Size(105, 21);
//            this.cmbvidrios1.TabIndex = 7874;
//            this.cmbvidrios1.SelectedIndexChanged += new System.EventHandler(this.cmbvidrios1_SelectedIndexChanged);
//            // 
//            // cmbvidrios2
//            // 
//            this.cmbvidrios2.FormattingEnabled = true;
//            this.cmbvidrios2.Location = new System.Drawing.Point(88, 345);
//            this.cmbvidrios2.Name = "cmbvidrios2";
//            this.cmbvidrios2.Size = new System.Drawing.Size(105, 21);
//            this.cmbvidrios2.TabIndex = 7875;
//            this.cmbvidrios2.SelectedIndexChanged += new System.EventHandler(this.cmbvidrios2_SelectedIndexChanged_1);
//            // 
//            // cmbvidrios3
//            // 
//            this.cmbvidrios3.FormattingEnabled = true;
//            this.cmbvidrios3.Location = new System.Drawing.Point(88, 372);
//            this.cmbvidrios3.Name = "cmbvidrios3";
//            this.cmbvidrios3.Size = new System.Drawing.Size(105, 21);
//            this.cmbvidrios3.TabIndex = 7876;
//            this.cmbvidrios3.SelectedIndexChanged += new System.EventHandler(this.cmbvidrios3_SelectedIndexChanged);
//            // 
//            // lblmaderas
//            // 
//            this.lblmaderas.AutoSize = true;
//            this.lblmaderas.Location = new System.Drawing.Point(9, 42);
//            this.lblmaderas.Name = "lblmaderas";
//            this.lblmaderas.Size = new System.Drawing.Size(60, 13);
//            this.lblmaderas.TabIndex = 7877;
//            this.lblmaderas.Text = "MADERAS";
//            // 
//            // lblvidrios
//            // 
//            this.lblvidrios.AutoSize = true;
//            this.lblvidrios.Location = new System.Drawing.Point(12, 297);
//            this.lblvidrios.Name = "lblvidrios";
//            this.lblvidrios.Size = new System.Drawing.Size(51, 13);
//            this.lblvidrios.TabIndex = 7878;
//            this.lblvidrios.Text = "VIDRIOS";
//            // 
//            // lbltitulomateriales
//            // 
//            this.lbltitulomateriales.AutoSize = true;
//            this.lbltitulomateriales.Location = new System.Drawing.Point(12, 508);
//            this.lbltitulomateriales.Name = "lbltitulomateriales";
//            this.lbltitulomateriales.Size = new System.Drawing.Size(116, 13);
//            this.lbltitulomateriales.TabIndex = 7879;
//            this.lbltitulomateriales.Text = "OTROS MATERIALES";
//            // 
//            // lblvalorxmetro23
//            // 
//            this.lblvalorxmetro23.AutoSize = true;
//            this.lblvalorxmetro23.Location = new System.Drawing.Point(504, 374);
//            this.lblvalorxmetro23.Name = "lblvalorxmetro23";
//            this.lblvalorxmetro23.Size = new System.Drawing.Size(13, 13);
//            this.lblvalorxmetro23.TabIndex = 7883;
//            this.lblvalorxmetro23.Text = "$";
//            // 
//            // lblvalorxmetro22
//            // 
//            this.lblvalorxmetro22.AutoSize = true;
//            this.lblvalorxmetro22.Location = new System.Drawing.Point(504, 349);
//            this.lblvalorxmetro22.Name = "lblvalorxmetro22";
//            this.lblvalorxmetro22.Size = new System.Drawing.Size(13, 13);
//            this.lblvalorxmetro22.TabIndex = 7882;
//            this.lblvalorxmetro22.Text = "$";
//            // 
//            // lblvalorxmetro21
//            // 
//            this.lblvalorxmetro21.AutoSize = true;
//            this.lblvalorxmetro21.Location = new System.Drawing.Point(504, 322);
//            this.lblvalorxmetro21.Name = "lblvalorxmetro21";
//            this.lblvalorxmetro21.Size = new System.Drawing.Size(13, 13);
//            this.lblvalorxmetro21.TabIndex = 7881;
//            this.lblvalorxmetro21.Text = "$";
//            // 
//            // lblmetros2
//            // 
//            this.lblmetros2.AutoSize = true;
//            this.lblmetros2.Location = new System.Drawing.Point(504, 297);
//            this.lblmetros2.Name = "lblmetros2";
//            this.lblmetros2.Size = new System.Drawing.Size(74, 13);
//            this.lblmetros2.TabIndex = 7880;
//            this.lblmetros2.Text = "Valor x metro2";
//            // 
//            // cmbbisagras1
//            // 
//            this.cmbbisagras1.FormattingEnabled = true;
//            this.cmbbisagras1.Location = new System.Drawing.Point(43, 463);
//            this.cmbbisagras1.Name = "cmbbisagras1";
//            this.cmbbisagras1.Size = new System.Drawing.Size(105, 21);
//            this.cmbbisagras1.TabIndex = 7891;
//            this.cmbbisagras1.SelectedIndexChanged += new System.EventHandler(this.cmbbisagras1_SelectedIndexChanged);
//            // 
//            // lbltotalbisagras
//            // 
//            this.lbltotalbisagras.AutoSize = true;
//            this.lbltotalbisagras.Location = new System.Drawing.Point(275, 466);
//            this.lbltotalbisagras.Name = "lbltotalbisagras";
//            this.lbltotalbisagras.Size = new System.Drawing.Size(13, 13);
//            this.lbltotalbisagras.TabIndex = 7890;
//            this.lbltotalbisagras.Text = "$";
//            // 
//            // lblbisagrasunidad1
//            // 
//            this.lblbisagrasunidad1.AutoSize = true;
//            this.lblbisagrasunidad1.Location = new System.Drawing.Point(224, 466);
//            this.lblbisagrasunidad1.Name = "lblbisagrasunidad1";
//            this.lblbisagrasunidad1.Size = new System.Drawing.Size(13, 13);
//            this.lblbisagrasunidad1.TabIndex = 7889;
//            this.lblbisagrasunidad1.Text = "$";
//            // 
//            // txtbisagrascantidad
//            // 
//            this.txtbisagrascantidad.Location = new System.Drawing.Point(154, 463);
//            this.txtbisagrascantidad.Name = "txtbisagrascantidad";
//            this.txtbisagrascantidad.Size = new System.Drawing.Size(49, 20);
//            this.txtbisagrascantidad.TabIndex = 7886;
//            // 
//            // chkbisagras1
//            // 
//            this.chkbisagras1.AutoSize = true;
//            this.chkbisagras1.Location = new System.Drawing.Point(12, 466);
//            this.chkbisagras1.Name = "chkbisagras1";
//            this.chkbisagras1.Size = new System.Drawing.Size(15, 14);
//            this.chkbisagras1.TabIndex = 7884;
//            this.chkbisagras1.UseVisualStyleBackColor = true;
//            // 
//            // lblbisagras
//            // 
//            this.lblbisagras.AutoSize = true;
//            this.lblbisagras.Location = new System.Drawing.Point(12, 439);
//            this.lblbisagras.Name = "lblbisagras";
//            this.lblbisagras.Size = new System.Drawing.Size(61, 13);
//            this.lblbisagras.TabIndex = 7900;
//            this.lblbisagras.Text = "BISAGRAS";
//            // 
//            // label27
//            // 
//            this.label27.AutoSize = true;
//            this.label27.Location = new System.Drawing.Point(154, 439);
//            this.label27.Name = "label27";
//            this.label27.Size = new System.Drawing.Size(49, 13);
//            this.label27.TabIndex = 7901;
//            this.label27.Text = "Cantidad";
//            // 
//            // label30
//            // 
//            this.label30.AutoSize = true;
//            this.label30.Location = new System.Drawing.Point(275, 439);
//            this.label30.Name = "label30";
//            this.label30.Size = new System.Drawing.Size(31, 13);
//            this.label30.TabIndex = 7903;
//            this.label30.Text = "Total";
//            // 
//            // label32
//            // 
//            this.label32.AutoSize = true;
//            this.label32.Location = new System.Drawing.Point(224, 439);
//            this.label32.Name = "label32";
//            this.label32.Size = new System.Drawing.Size(41, 13);
//            this.label32.TabIndex = 7902;
//            this.label32.Text = "Unidad";
//            // 
//            // Form1
//            // 
//            this.AcceptButton = this.btnlimpiarmedidas;
//            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
//            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
//            this.ClientSize = new System.Drawing.Size(861, 733);
//            this.Controls.Add(this.label30);
//            this.Controls.Add(this.label32);
//            this.Controls.Add(this.label27);
//            this.Controls.Add(this.lblbisagras);
//            this.Controls.Add(this.cmbbisagras1);
//            this.Controls.Add(this.lbltotalbisagras);
//            this.Controls.Add(this.lblbisagrasunidad1);
//            this.Controls.Add(this.txtbisagrascantidad);
//            this.Controls.Add(this.chkbisagras1);
//            this.Controls.Add(this.lblvalorxmetro23);
//            this.Controls.Add(this.lblvalorxmetro22);
//            this.Controls.Add(this.lblvalorxmetro21);
//            this.Controls.Add(this.lblmetros2);
//            this.Controls.Add(this.lbltitulomateriales);
//            this.Controls.Add(this.lblvidrios);
//            this.Controls.Add(this.lblmaderas);
//            this.Controls.Add(this.cmbvidrios3);
//            this.Controls.Add(this.cmbvidrios2);
//            this.Controls.Add(this.cmbvidrios1);
//            this.Controls.Add(this.label26);
//            this.Controls.Add(this.lbltotalvidrios);
//            this.Controls.Add(this.lblvidriototal3);
//            this.Controls.Add(this.lblvidriounidad3);
//            this.Controls.Add(this.lblvidriototal2);
//            this.Controls.Add(this.lblvidriounidad2);
//            this.Controls.Add(this.lblvidriototal1);
//            this.Controls.Add(this.lblvidriounidad1);
//            this.Controls.Add(this.label24);
//            this.Controls.Add(this.label25);
//            this.Controls.Add(this.label23);
//            this.Controls.Add(this.label22);
//            this.Controls.Add(this.label21);
//            this.Controls.Add(this.txtvidriocant3);
//            this.Controls.Add(this.txtvidrioancho3);
//            this.Controls.Add(this.txtvidriolargo3);
//            this.Controls.Add(this.label18);
//            this.Controls.Add(this.chkvidrio3);
//            this.Controls.Add(this.txtvidriocant2);
//            this.Controls.Add(this.txtvidrioancho2);
//            this.Controls.Add(this.txtvidriolargo2);
//            this.Controls.Add(this.label17);
//            this.Controls.Add(this.chkvidrio2);
//            this.Controls.Add(this.txtvidriocant1);
//            this.Controls.Add(this.txtvidrioancho1);
//            this.Controls.Add(this.txtvidriolargo1);
//            this.Controls.Add(this.label15);
//            this.Controls.Add(this.chkvidrio1);
//            this.Controls.Add(this.txtganancia);
//            this.Controls.Add(this.txtdesperdicio);
//            this.Controls.Add(this.lblganancia);
//            this.Controls.Add(this.lbldesperdicio);
//            this.Controls.Add(this.label14);
//            this.Controls.Add(this.lblotrosmateriales);
//            this.Controls.Add(this.label20);
//            this.Controls.Add(this.txtdescmad6);
//            this.Controls.Add(this.txtdescmad5);
//            this.Controls.Add(this.txtdescmad4);
//            this.Controls.Add(this.txtdescmad3);
//            this.Controls.Add(this.txtdescmad2);
//            this.Controls.Add(this.txtdescmad1);
//            this.Controls.Add(this.lbltotalgastosvarios);
//            this.Controls.Add(this.txtgastosvarios);
//            this.Controls.Add(this.label16);
//            this.Controls.Add(this.chkgastosvarios);
//            this.Controls.Add(this.lbltotalgastosadicionales);
//            this.Controls.Add(this.txtmateriales);
//            this.Controls.Add(this.label19);
//            this.Controls.Add(this.chkotrosmateriales);
//            this.Controls.Add(this.lbltotalguias2);
//            this.Controls.Add(this.lblvalorguias2);
//            this.Controls.Add(this.cmbguias2);
//            this.Controls.Add(this.txtguias2);
//            this.Controls.Add(this.lblguias2);
//            this.Controls.Add(this.chkguias2);
//            this.Controls.Add(this.btncalcularpresupuesto);
//            this.Controls.Add(this.lbltotalguias1);
//            this.Controls.Add(this.lbltitulototal);
//            this.Controls.Add(this.lblvalorguias1);
//            this.Controls.Add(this.lbltitulovalorguias);
//            this.Controls.Add(this.label13);
//            this.Controls.Add(this.cmbguias1);
//            this.Controls.Add(this.txtguias1);
//            this.Controls.Add(this.lblguias1);
//            this.Controls.Add(this.chkguias1);
//            this.Controls.Add(this.chk6);
//            this.Controls.Add(this.chk5);
//            this.Controls.Add(this.chk4);
//            this.Controls.Add(this.chk3);
//            this.Controls.Add(this.chk2);
//            this.Controls.Add(this.chk1);
//            this.Controls.Add(this.lblpie6);
//            this.Controls.Add(this.lblpie5);
//            this.Controls.Add(this.lblpie4);
//            this.Controls.Add(this.lblpie3);
//            this.Controls.Add(this.lblpie2);
//            this.Controls.Add(this.lblpie1);
//            this.Controls.Add(this.lblpie);
//            this.Controls.Add(this.txtcantidad6);
//            this.Controls.Add(this.txtlargom6);
//            this.Controls.Add(this.txtanchom6);
//            this.Controls.Add(this.txtespesorm6);
//            this.Controls.Add(this.txtcantidad5);
//            this.Controls.Add(this.txtlargom5);
//            this.Controls.Add(this.txtanchom5);
//            this.Controls.Add(this.txtespesorm5);
//            this.Controls.Add(this.txtcantidad4);
//            this.Controls.Add(this.txtlargom4);
//            this.Controls.Add(this.txtanchom4);
//            this.Controls.Add(this.txtespesorm4);
//            this.Controls.Add(this.txtcantidad3);
//            this.Controls.Add(this.txtlargom3);
//            this.Controls.Add(this.txtanchom3);
//            this.Controls.Add(this.txtespesorm3);
//            this.Controls.Add(this.txtcantidad2);
//            this.Controls.Add(this.txtlargom2);
//            this.Controls.Add(this.txtanchom2);
//            this.Controls.Add(this.txtespesorm2);
//            this.Controls.Add(this.label12);
//            this.Controls.Add(this.label11);
//            this.Controls.Add(this.label10);
//            this.Controls.Add(this.label9);
//            this.Controls.Add(this.label8);
//            this.Controls.Add(this.label4);
//            this.Controls.Add(this.lblmadera);
//            this.Controls.Add(this.txtcantidad1);
//            this.Controls.Add(this.lblcantidad);
//            this.Controls.Add(this.btncerrar);
//            this.Controls.Add(this.btnmostrartodas);
//            this.Controls.Add(this.dgvmaderas);
//            this.Controls.Add(this.lblvalorpies);
//            this.Controls.Add(this.lblpies);
//            this.Controls.Add(this.cmbmaderas);
//            this.Controls.Add(this.btnguardarpresupuesto);
//            this.Controls.Add(this.pcbimagenmaderareciclada);
//            this.Controls.Add(this.lblpresupuesto);
//            this.Controls.Add(this.label5);
//            this.Controls.Add(this.lblseleccionmaderas);
//            this.Controls.Add(this.lblcalculopies);
//            this.Controls.Add(this.btnlimpiarmedidas);
//            this.Controls.Add(this.lblpies1);
//            this.Controls.Add(this.btncalcularpies);
//            this.Controls.Add(this.txtlargom1);
//            this.Controls.Add(this.txtanchom1);
//            this.Controls.Add(this.txtespesorm1);
//            this.Controls.Add(this.lbltitulo);
//            this.Controls.Add(this.label3);
//            this.Controls.Add(this.label2);
//            this.Controls.Add(this.label1);
//            this.Name = "Form1";
//            this.Text = "Calculo presupuesto tablas segun medida y tipo de madera";
//            this.Load += new System.EventHandler(this.Form1_Load);
//            ((System.ComponentModel.ISupportInitialize)(this.pcbimagenmaderareciclada)).EndInit();
//            ((System.ComponentModel.ISupportInitialize)(this.calculopiesDataSet)).EndInit();
//            ((System.ComponentModel.ISupportInitialize)(this.maderasBindingSource)).EndInit();
//            ((System.ComponentModel.ISupportInitialize)(this.dgvmaderas)).EndInit();
//            this.ResumeLayout(false);
//            this.PerformLayout();

//        }

//        #endregion

//        private System.Windows.Forms.Label label1;
//        private System.Windows.Forms.Label label2;
//        private System.Windows.Forms.Label label3;
//        private System.Windows.Forms.Label lbltitulo;
//        private System.Windows.Forms.TextBox txtespesorm1;
//        private System.Windows.Forms.TextBox txtanchom1;
//        private System.Windows.Forms.TextBox txtlargom1;
//        private System.Windows.Forms.Button btncalcularpies;
//        private System.Windows.Forms.Label lblpies1;
//        private System.Windows.Forms.Button btnlimpiarmedidas;
//        private System.Windows.Forms.Label lblcalculopies;
//        private System.Windows.Forms.Label lblseleccionmaderas;
//        private System.Windows.Forms.Label label5;
//        private System.Windows.Forms.Label lblpresupuesto;
//        private System.Windows.Forms.PictureBox pcbimagenmaderareciclada;
//        private System.Windows.Forms.Button btnguardarpresupuesto;
//        private System.Windows.Forms.ComboBox cmbmaderas;
//        private System.Windows.Forms.Label lblpies;
//        private System.Windows.Forms.Label lblvalorpies;
//        private CalculopiesDataSet calculopiesDataSet;
//        private System.Windows.Forms.BindingSource maderasBindingSource;
//        private CalculopiesDataSetTableAdapters.MaderasTableAdapter maderasTableAdapter;
//        private System.Windows.Forms.DataGridView dgvmaderas;
//        private System.Windows.Forms.Button btnmostrartodas;
//        private System.Windows.Forms.Button btncerrar;
//        private System.Windows.Forms.Label lblcantidad;
//        private System.Windows.Forms.TextBox txtcantidad1;
//        private System.Windows.Forms.Label lblmadera;
//        private System.Windows.Forms.Label label4;
//        private System.Windows.Forms.Label label8;
//        private System.Windows.Forms.Label label9;
//        private System.Windows.Forms.Label label10;
//        private System.Windows.Forms.Label label11;
//        private System.Windows.Forms.Label label12;
//        private System.Windows.Forms.TextBox txtcantidad2;
//        private System.Windows.Forms.TextBox txtlargom2;
//        private System.Windows.Forms.TextBox txtanchom2;
//        private System.Windows.Forms.TextBox txtespesorm2;
//        private System.Windows.Forms.TextBox txtcantidad3;
//        private System.Windows.Forms.TextBox txtlargom3;
//        private System.Windows.Forms.TextBox txtanchom3;
//        private System.Windows.Forms.TextBox txtespesorm3;
//        private System.Windows.Forms.TextBox txtcantidad4;
//        private System.Windows.Forms.TextBox txtlargom4;
//        private System.Windows.Forms.TextBox txtanchom4;
//        private System.Windows.Forms.TextBox txtespesorm4;
//        private System.Windows.Forms.TextBox txtcantidad5;
//        private System.Windows.Forms.TextBox txtlargom5;
//        private System.Windows.Forms.TextBox txtanchom5;
//        private System.Windows.Forms.TextBox txtespesorm5;
//        private System.Windows.Forms.TextBox txtcantidad6;
//        private System.Windows.Forms.TextBox txtlargom6;
//        private System.Windows.Forms.TextBox txtanchom6;
//        private System.Windows.Forms.TextBox txtespesorm6;
//        private System.Windows.Forms.Label lblpie;
//        private System.Windows.Forms.Label lblpie1;
//        private System.Windows.Forms.Label lblpie2;
//        private System.Windows.Forms.Label lblpie3;
//        private System.Windows.Forms.Label lblpie4;
//        private System.Windows.Forms.Label lblpie5;
//        private System.Windows.Forms.Label lblpie6;
//        private System.Windows.Forms.CheckBox chk1;
//        private System.Windows.Forms.CheckBox chk2;
//        private System.Windows.Forms.CheckBox chk3;
//        private System.Windows.Forms.CheckBox chk6;
//        private System.Windows.Forms.CheckBox chk5;
//        private System.Windows.Forms.CheckBox chk4;
//        private System.Windows.Forms.CheckBox chkguias1;
//        private System.Windows.Forms.Label lblguias1;
//        private System.Windows.Forms.TextBox txtguias1;
//        private System.Windows.Forms.ComboBox cmbguias1;
//        private System.Windows.Forms.Label label13;
//        private System.Windows.Forms.Label lbltitulovalorguias;
//        private System.Windows.Forms.Label lblvalorguias1;
//        private System.Windows.Forms.Label lbltitulototal;
//        private System.Windows.Forms.Label lbltotalguias1;
//        private System.Windows.Forms.Button btncalcularpresupuesto;
//        private System.Windows.Forms.Label lbltotalguias2;
//        private System.Windows.Forms.Label lblvalorguias2;
//        private System.Windows.Forms.ComboBox cmbguias2;
//        private System.Windows.Forms.TextBox txtguias2;
//        private System.Windows.Forms.Label lblguias2;
//        private System.Windows.Forms.CheckBox chkguias2;
//        private System.Windows.Forms.Label lbltotalgastosvarios;
//        private System.Windows.Forms.TextBox txtgastosvarios;
//        private System.Windows.Forms.Label label16;
//        private System.Windows.Forms.CheckBox chkgastosvarios;
//        private System.Windows.Forms.Label lbltotalgastosadicionales;
//        private System.Windows.Forms.TextBox txtmateriales;
//        private System.Windows.Forms.Label label19;
//        private System.Windows.Forms.CheckBox chkotrosmateriales;
//        private System.Windows.Forms.TextBox txtdescmad6;
//        private System.Windows.Forms.TextBox txtdescmad5;
//        private System.Windows.Forms.TextBox txtdescmad4;
//        private System.Windows.Forms.TextBox txtdescmad3;
//        private System.Windows.Forms.TextBox txtdescmad2;
//        private System.Windows.Forms.TextBox txtdescmad1;
//        private System.Windows.Forms.Label label20;
//        private System.Windows.Forms.Label lblotrosmateriales;
//        private System.Windows.Forms.Label label14;
//        private System.Windows.Forms.Label lbldesperdicio;
//        private System.Windows.Forms.Label lblganancia;
//        private System.Windows.Forms.TextBox txtganancia;
//        private System.Windows.Forms.TextBox txtdesperdicio;
//        private System.Windows.Forms.CheckBox chkvidrio1;
//        private System.Windows.Forms.Label label15;
//        private System.Windows.Forms.TextBox txtvidriolargo1;
//        private System.Windows.Forms.TextBox txtvidrioancho1;
//        private System.Windows.Forms.TextBox txtvidriocant1;
//        private System.Windows.Forms.TextBox txtvidriocant2;
//        private System.Windows.Forms.TextBox txtvidrioancho2;
//        private System.Windows.Forms.TextBox txtvidriolargo2;
//        private System.Windows.Forms.Label label17;
//        private System.Windows.Forms.CheckBox chkvidrio2;
//        private System.Windows.Forms.TextBox txtvidriocant3;
//        private System.Windows.Forms.TextBox txtvidrioancho3;
//        private System.Windows.Forms.TextBox txtvidriolargo3;
//        private System.Windows.Forms.Label label18;
//        private System.Windows.Forms.CheckBox chkvidrio3;
//        private System.Windows.Forms.Label label21;
//        private System.Windows.Forms.Label label22;
//        private System.Windows.Forms.Label label23;
//        private System.Windows.Forms.Label label24;
//        private System.Windows.Forms.Label label25;
//        private System.Windows.Forms.Label lblvidriototal2;
//        private System.Windows.Forms.Label lblvidriounidad2;
//        private System.Windows.Forms.Label lblvidriototal1;
//        private System.Windows.Forms.Label lblvidriounidad1;
//        private System.Windows.Forms.Label lblvidriototal3;
//        private System.Windows.Forms.Label lblvidriounidad3;
//        private System.Windows.Forms.Label label26;
//        private System.Windows.Forms.Label lbltotalvidrios;
//        private System.Windows.Forms.ComboBox cmbvidrios1;
//        private System.Windows.Forms.ComboBox cmbvidrios2;
//        private System.Windows.Forms.ComboBox cmbvidrios3;
//        private System.Windows.Forms.Label lblmaderas;
//        private System.Windows.Forms.Label lblvidrios;
//        private System.Windows.Forms.Label lbltitulomateriales;
//        private System.Windows.Forms.Label lblvalorxmetro23;
//        private System.Windows.Forms.Label lblvalorxmetro22;
//        private System.Windows.Forms.Label lblvalorxmetro21;
//        private System.Windows.Forms.Label lblmetros2;
//        private System.Windows.Forms.ComboBox cmbbisagras1;
//        private System.Windows.Forms.Label lbltotalbisagras;
//        private System.Windows.Forms.Label lblbisagrasunidad1;
//        private System.Windows.Forms.TextBox txtbisagrascantidad;
//        private System.Windows.Forms.CheckBox chkbisagras1;
//        private System.Windows.Forms.Label lblbisagras;
//        private System.Windows.Forms.Label label27;
//        private System.Windows.Forms.Label label30;
//        private System.Windows.Forms.Label label32;
//    }
//}

