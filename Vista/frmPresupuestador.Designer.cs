namespace Vista
{
    partial class frmPresupuestador
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

            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPresupuestador));
            this.gbxCliente = new System.Windows.Forms.GroupBox();
            this.txtMailCliente = new System.Windows.Forms.TextBox();
            this.lblemailclientepresupuesto = new System.Windows.Forms.Label();
            this.txtTelefonoCliente = new System.Windows.Forms.TextBox();
            this.txtApellidoCliente = new System.Windows.Forms.TextBox();

            this.lbltelefonoclientepresupuesto = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.lblapellidoclientepresupuesto = new System.Windows.Forms.Label();
            this.txtNombreCliente = new System.Windows.Forms.TextBox();
            this.lblnombreclientepresupuesto = new System.Windows.Forms.Label();
            this.btnBuscarDni = new System.Windows.Forms.Button();
            this.lbldniclientepresupuesto = new System.Windows.Forms.Label();
            this.txtDni = new System.Windows.Forms.TextBox();
            this.cmbDni = new System.Windows.Forms.ComboBox();
            this.gbxCotizaciones = new System.Windows.Forms.GroupBox();

            this.btnCotizar = new System.Windows.Forms.Button();
            this.btnBuscarCotizacion = new System.Windows.Forms.Button();
            this.btnSubtotal = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnBorrarCotizacion = new System.Windows.Forms.Button();
            this.btnEditarCotizacion = new System.Windows.Forms.Button();
            this.dgvPresupuesto = new System.Windows.Forms.DataGridView();
            this.btnVenta = new System.Windows.Forms.Button();
            this.lbldescpresupuesto = new System.Windows.Forms.Label();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.lblsubtotal = new System.Windows.Forms.Label();
            this.lblValorSubtotal = new System.Windows.Forms.Label();
            this.lbldescuentopresupuesto = new System.Windows.Forms.Label();
            this.txtDescuento = new System.Windows.Forms.TextBox();

            this.btnaplicarDescuento = new System.Windows.Forms.Button();
            this.lblValorPresupuesto = new System.Windows.Forms.Label();
            this.lbltotalpresupuesto = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.btnExportar = new System.Windows.Forms.Button();
            this.dtpVigencia = new System.Windows.Forms.DateTimePicker();
            this.label15 = new System.Windows.Forms.Label();
            this.btnBuscarPresupuesto = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.pnlBorde = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.pctMinimize = new System.Windows.Forms.PictureBox();
            this.pctClose = new System.Windows.Forms.PictureBox();
            this.pnlBordeInferior = new System.Windows.Forms.Panel();
            this.pnlPresupuesto = new System.Windows.Forms.Panel();
            this.pnlTotales = new System.Windows.Forms.Panel();
            this.pnlVigencia = new System.Windows.Forms.Panel();
            this.gbxCliente.SuspendLayout();
            this.gbxCotizaciones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPresupuesto)).BeginInit();
            this.pnlBorde.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctMinimize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctClose)).BeginInit();
            this.pnlPresupuesto.SuspendLayout();
            this.pnlTotales.SuspendLayout();
            this.pnlVigencia.SuspendLayout();
            this.SuspendLayout();
            // 

            // gbxCliente
            // 
            this.gbxCliente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(40)))));
            this.gbxCliente.Controls.Add(this.txtMailCliente);
            this.gbxCliente.Controls.Add(this.lblemailclientepresupuesto);
            this.gbxCliente.Controls.Add(this.txtTelefonoCliente);
            this.gbxCliente.Controls.Add(this.txtApellidoCliente);

            this.gbxCliente.Controls.Add(this.lbltelefonoclientepresupuesto);
            this.gbxCliente.Controls.Add(this.label17);
            this.gbxCliente.Controls.Add(this.label16);
            this.gbxCliente.Controls.Add(this.lblapellidoclientepresupuesto);
            this.gbxCliente.Controls.Add(this.txtNombreCliente);
            this.gbxCliente.Controls.Add(this.lblnombreclientepresupuesto);
            this.gbxCliente.Controls.Add(this.btnBuscarDni);
            this.gbxCliente.Controls.Add(this.lbldniclientepresupuesto);
            this.gbxCliente.Controls.Add(this.txtDni);
            this.gbxCliente.Controls.Add(this.cmbDni);

            this.gbxCliente.Font = new System.Drawing.Font("Bahnschrift", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxCliente.ForeColor = System.Drawing.Color.White;
            this.gbxCliente.Location = new System.Drawing.Point(10, 50);
            this.gbxCliente.Margin = new System.Windows.Forms.Padding(2);
            this.gbxCliente.Name = "gbxCliente";
            this.gbxCliente.Padding = new System.Windows.Forms.Padding(2);
            this.gbxCliente.Size = new System.Drawing.Size(630, 150);
            this.gbxCliente.TabIndex = 17;
            this.gbxCliente.TabStop = false;
            this.gbxCliente.Text = "Cliente";
            // 
            // txtMailCliente
            // 

            this.txtMailCliente.Font = new System.Drawing.Font("Bahnschrift", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMailCliente.ForeColor = System.Drawing.Color.Black;
            this.txtMailCliente.Location = new System.Drawing.Point(140, 110);
            this.txtMailCliente.Margin = new System.Windows.Forms.Padding(2);
            this.txtMailCliente.Name = "txtMailCliente";
            this.txtMailCliente.Size = new System.Drawing.Size(475, 25);
            this.txtMailCliente.TabIndex = 24;
            // 
            // lblemailclientepresupuesto
            // 

            this.lblemailclientepresupuesto.Font = new System.Drawing.Font("Bahnschrift", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblemailclientepresupuesto.Location = new System.Drawing.Point(10, 110);
            this.lblemailclientepresupuesto.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblemailclientepresupuesto.Name = "label4";
            this.lblemailclientepresupuesto.Size = new System.Drawing.Size(130, 25);
            this.lblemailclientepresupuesto.TabIndex = 23;
            this.lblemailclientepresupuesto.Text = "Correo electrónico";
            this.lblemailclientepresupuesto.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtTelefonoCliente
            // 
            this.txtTelefonoCliente.Font = new System.Drawing.Font("Bahnschrift", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTelefonoCliente.ForeColor = System.Drawing.Color.Black;
            this.txtTelefonoCliente.Location = new System.Drawing.Point(515, 80);
            this.txtTelefonoCliente.Margin = new System.Windows.Forms.Padding(2);
            this.txtTelefonoCliente.Name = "txtTelefonoCliente";
            this.txtTelefonoCliente.Size = new System.Drawing.Size(100, 25);
            this.txtTelefonoCliente.TabIndex = 22;
            // 
            // txtApellidoCliente
            // 

            this.txtApellidoCliente.Font = new System.Drawing.Font("Bahnschrift", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtApellidoCliente.ForeColor = System.Drawing.Color.Black;
            this.txtApellidoCliente.Location = new System.Drawing.Point(295, 80);
            this.txtApellidoCliente.Margin = new System.Windows.Forms.Padding(2);
            this.txtApellidoCliente.Name = "txtApellidoCliente";
            this.txtApellidoCliente.Size = new System.Drawing.Size(150, 25);
            this.txtApellidoCliente.TabIndex = 20;
            // 
            // lbltelefonoclientepresupuesto
            // 

            this.lbltelefonoclientepresupuesto.Font = new System.Drawing.Font("Bahnschrift", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltelefonoclientepresupuesto.Location = new System.Drawing.Point(448, 80);
            this.lbltelefonoclientepresupuesto.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbltelefonoclientepresupuesto.Name = "label5";
            this.lbltelefonoclientepresupuesto.Size = new System.Drawing.Size(65, 25);
            this.lbltelefonoclientepresupuesto.TabIndex = 21;
            this.lbltelefonoclientepresupuesto.Text = "Teléfono";
            this.lbltelefonoclientepresupuesto.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label17
            // 
            this.label17.Font = new System.Drawing.Font("Bahnschrift", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(295, 45);
            this.label17.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(320, 25);
            this.label17.TabIndex = 36;
            this.label17.Text = "Estado Presupuesto:";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label16
            // 
            this.label16.Font = new System.Drawing.Font("Bahnschrift", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(295, 20);
            this.label16.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(320, 25);
            this.label16.TabIndex = 35;
            this.label16.Text = "N° Presupuesto:";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.lblapellidoclientepresupuesto.Font = new System.Drawing.Font("Bahnschrift", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblapellidoclientepresupuesto.Location = new System.Drawing.Point(228, 80);
            this.lblapellidoclientepresupuesto.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblapellidoclientepresupuesto.Name = "label3";
            this.lblapellidoclientepresupuesto.Size = new System.Drawing.Size(65, 25);
            this.lblapellidoclientepresupuesto.TabIndex = 19;
            this.lblapellidoclientepresupuesto.Text = "Apellido";
            this.lblapellidoclientepresupuesto.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtNombreCliente
            // 
            this.txtNombreCliente.Font = new System.Drawing.Font("Bahnschrift", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombreCliente.ForeColor = System.Drawing.Color.Black;
            this.txtNombreCliente.Location = new System.Drawing.Point(75, 80);
            this.txtNombreCliente.Margin = new System.Windows.Forms.Padding(2);
            this.txtNombreCliente.Name = "txtNombreCliente";
            this.txtNombreCliente.Size = new System.Drawing.Size(150, 25);
            this.txtNombreCliente.TabIndex = 18;
            // 
            // lblnombreclientepresupuesto
            // 

            this.lblnombreclientepresupuesto.Font = new System.Drawing.Font("Bahnschrift", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblnombreclientepresupuesto.Location = new System.Drawing.Point(10, 80);
            this.lblnombreclientepresupuesto.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblnombreclientepresupuesto.Name = "label2";
            this.lblnombreclientepresupuesto.Size = new System.Drawing.Size(65, 25);
            this.lblnombreclientepresupuesto.TabIndex = 17;
            this.lblnombreclientepresupuesto.Text = "Nombre";
            this.lblnombreclientepresupuesto.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnBuscarDni
            // 
            this.btnBuscarDni.BackColor = System.Drawing.Color.White;
            this.btnBuscarDni.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnBuscarDni.Font = new System.Drawing.Font("Bahnschrift", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscarDni.ForeColor = System.Drawing.Color.Black;
            this.btnBuscarDni.Location = new System.Drawing.Point(208, 25);
            this.btnBuscarDni.Margin = new System.Windows.Forms.Padding(2);
            this.btnBuscarDni.Name = "btnBuscarDni";
            this.btnBuscarDni.Size = new System.Drawing.Size(65, 30);
            this.btnBuscarDni.TabIndex = 16;
            this.btnBuscarDni.Text = "Buscar";
            this.btnBuscarDni.UseVisualStyleBackColor = false;
            this.btnBuscarDni.Click += new System.EventHandler(this.btnBuscarDni_Click);
            // 
            // lbldniclientepresupuesto
            // 

            this.lbldniclientepresupuesto.Font = new System.Drawing.Font("Bahnschrift", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbldniclientepresupuesto.Location = new System.Drawing.Point(10, 27);
            this.lbldniclientepresupuesto.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbldniclientepresupuesto.Name = "label1";
            this.lbldniclientepresupuesto.Size = new System.Drawing.Size(35, 25);
            this.lbldniclientepresupuesto.TabIndex = 15;
            this.lbldniclientepresupuesto.Text = "DNI";
            this.lbldniclientepresupuesto.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtDni
            // 
            this.txtDni.Font = new System.Drawing.Font("Bahnschrift", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDni.ForeColor = System.Drawing.Color.Black;
            this.txtDni.Location = new System.Drawing.Point(104, 28);
            this.txtDni.Margin = new System.Windows.Forms.Padding(2);
            this.txtDni.Name = "txtDni";
            this.txtDni.Size = new System.Drawing.Size(100, 25);
            this.txtDni.TabIndex = 14;
            this.txtDni.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDni_KeyDown);
            this.txtDni.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDni_Keypress);
            // 
            // cmbDni
            // 
            this.cmbDni.Font = new System.Drawing.Font("Bahnschrift", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDni.ForeColor = System.Drawing.Color.Black;
            this.cmbDni.FormattingEnabled = true;

            this.cmbDni.Location = new System.Drawing.Point(46, 27);
            this.cmbDni.Margin = new System.Windows.Forms.Padding(2);
            this.cmbDni.Name = "cmbDni";
            this.cmbDni.Size = new System.Drawing.Size(54, 26);
            this.cmbDni.TabIndex = 13;
            // 
            // gbxCotizaciones
            // 

            this.gbxCotizaciones.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(40)))));
            this.gbxCotizaciones.Controls.Add(this.btnCotizar);
            this.gbxCotizaciones.Controls.Add(this.btnBuscarCotizacion);
            this.gbxCotizaciones.Controls.Add(this.btnSubtotal);
            this.gbxCotizaciones.Controls.Add(this.button1);
            this.gbxCotizaciones.Controls.Add(this.btnBorrarCotizacion);
            this.gbxCotizaciones.Controls.Add(this.btnEditarCotizacion);
            this.gbxCotizaciones.Controls.Add(this.dgvPresupuesto);
            this.gbxCotizaciones.Controls.Add(this.btnVenta);
            this.gbxCotizaciones.Font = new System.Drawing.Font("Bahnschrift", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxCotizaciones.ForeColor = System.Drawing.Color.White;
            this.gbxCotizaciones.Location = new System.Drawing.Point(10, 300);
            this.gbxCotizaciones.Margin = new System.Windows.Forms.Padding(2);
            this.gbxCotizaciones.Name = "gbxCotizaciones";
            this.gbxCotizaciones.Padding = new System.Windows.Forms.Padding(2);
            this.gbxCotizaciones.Size = new System.Drawing.Size(1005, 290);
            this.gbxCotizaciones.TabIndex = 18;
            this.gbxCotizaciones.TabStop = false;
            this.gbxCotizaciones.Text = "Cotizaciones";
            // 

            // btnCotizar
            // 
            this.btnCotizar.BackColor = System.Drawing.Color.White;
            this.btnCotizar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnCotizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCotizar.ForeColor = System.Drawing.Color.Black;
            this.btnCotizar.Location = new System.Drawing.Point(295, 251);
            this.btnCotizar.Margin = new System.Windows.Forms.Padding(2);
            this.btnCotizar.Name = "btnCotizar";
            this.btnCotizar.Size = new System.Drawing.Size(100, 30);
            this.btnCotizar.TabIndex = 25;
            this.btnCotizar.Text = "Cotizar";
            this.btnCotizar.UseVisualStyleBackColor = false;
            // 
            // btnBuscarCotizacion
            // 
            this.btnBuscarCotizacion.ForeColor = System.Drawing.Color.Black;
            this.btnBuscarCotizacion.Location = new System.Drawing.Point(10, 251);
            this.btnBuscarCotizacion.Margin = new System.Windows.Forms.Padding(2);
            this.btnBuscarCotizacion.Name = "btnBuscarCotizacion";
            this.btnBuscarCotizacion.Size = new System.Drawing.Size(250, 30);
            this.btnBuscarCotizacion.TabIndex = 24;
            this.btnBuscarCotizacion.Text = "Buscar cotización existente";
            this.btnBuscarCotizacion.UseVisualStyleBackColor = true;
            // 
            // btnSubtotal
            // 
            this.btnSubtotal.BackColor = System.Drawing.Color.White;
            this.btnSubtotal.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnSubtotal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSubtotal.ForeColor = System.Drawing.Color.Black;
            this.btnSubtotal.Location = new System.Drawing.Point(610, 251);
            this.btnSubtotal.Margin = new System.Windows.Forms.Padding(2);
            this.btnSubtotal.Name = "btnSubtotal";
            this.btnSubtotal.Size = new System.Drawing.Size(100, 30);
            this.btnSubtotal.TabIndex = 22;
            this.btnSubtotal.Text = "Subtotal";
            this.btnSubtotal.UseVisualStyleBackColor = false;
            this.btnSubtotal.Click += new System.EventHandler(this.btnSubtotal_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Bahnschrift", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Location = new System.Drawing.Point(845, 251);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(150, 30);
            this.button1.TabIndex = 37;
            this.button1.Text = "Guardar cotización";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnBorrarCotizacion
            // 
            this.btnBorrarCotizacion.BackColor = System.Drawing.Color.White;
            this.btnBorrarCotizacion.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnBorrarCotizacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBorrarCotizacion.ForeColor = System.Drawing.Color.Black;
            this.btnBorrarCotizacion.Location = new System.Drawing.Point(505, 251);
            this.btnBorrarCotizacion.Margin = new System.Windows.Forms.Padding(2);
            this.btnBorrarCotizacion.Name = "btnBorrarCotizacion";
            this.btnBorrarCotizacion.Size = new System.Drawing.Size(100, 30);
            this.btnBorrarCotizacion.TabIndex = 21;
            this.btnBorrarCotizacion.Text = "Borrar";
            this.btnBorrarCotizacion.UseVisualStyleBackColor = false;
            this.btnBorrarCotizacion.Click += new System.EventHandler(this.btnBorrarCotizacion_Click);
            // 
            // btnEditarCotizacion
            // 
            this.btnEditarCotizacion.BackColor = System.Drawing.Color.White;
            this.btnEditarCotizacion.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnEditarCotizacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditarCotizacion.ForeColor = System.Drawing.Color.Black;
            this.btnEditarCotizacion.Location = new System.Drawing.Point(400, 251);
            this.btnEditarCotizacion.Margin = new System.Windows.Forms.Padding(2);
            this.btnEditarCotizacion.Name = "btnEditarCotizacion";
            this.btnEditarCotizacion.Size = new System.Drawing.Size(100, 30);
            this.btnEditarCotizacion.TabIndex = 20;
            this.btnEditarCotizacion.Text = "Editar";
            this.btnEditarCotizacion.UseVisualStyleBackColor = false;
            // 
            // dgvPresupuesto
            // 
            this.dgvPresupuesto.BackgroundColor = System.Drawing.Color.White;
            this.dgvPresupuesto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;

            this.dgvPresupuesto.Location = new System.Drawing.Point(10, 20);
            this.dgvPresupuesto.Margin = new System.Windows.Forms.Padding(2);
            this.dgvPresupuesto.Name = "dgvPresupuesto";
            this.dgvPresupuesto.RowHeadersWidth = 51;
            this.dgvPresupuesto.RowTemplate.Height = 24;
            this.dgvPresupuesto.Size = new System.Drawing.Size(985, 225);
            this.dgvPresupuesto.TabIndex = 16;
            // 

            // btnVenta
            // 
            this.btnVenta.Font = new System.Drawing.Font("Bahnschrift", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVenta.ForeColor = System.Drawing.Color.Black;
            this.btnVenta.Location = new System.Drawing.Point(740, 251);
            this.btnVenta.Margin = new System.Windows.Forms.Padding(2);
            this.btnVenta.Name = "btnVenta";
            this.btnVenta.Size = new System.Drawing.Size(100, 30);
            this.btnVenta.TabIndex = 21;
            this.btnVenta.Text = "Venta";
            this.btnVenta.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.lblapellidoclientepresupuesto.Font = new System.Drawing.Font("Bahnschrift", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblapellidoclientepresupuesto.Location = new System.Drawing.Point(10, 10);
            this.lblapellidoclientepresupuesto.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblapellidoclientepresupuesto.Name = "label7";
            this.lblapellidoclientepresupuesto.Size = new System.Drawing.Size(175, 25);
            this.lblapellidoclientepresupuesto.TabIndex = 19;
            this.lblapellidoclientepresupuesto.Text = "Descripción presupuesto";
            this.lblapellidoclientepresupuesto.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Font = new System.Drawing.Font("Bahnschrift", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescripcion.ForeColor = System.Drawing.Color.Black;
            this.txtDescripcion.Location = new System.Drawing.Point(190, 10);
            this.txtDescripcion.Margin = new System.Windows.Forms.Padding(2);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(425, 25);
            this.txtDescripcion.TabIndex = 20;
            // 
            // lblsubtotal
            // 

            this.lblsubtotal.Font = new System.Drawing.Font("Bahnschrift", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblsubtotal.Location = new System.Drawing.Point(10, 10);
            this.lblsubtotal.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblsubtotal.Name = "label8";
            this.lblsubtotal.Size = new System.Drawing.Size(70, 25);
            this.lblsubtotal.TabIndex = 21;
            this.lblsubtotal.Text = "Subtotal:";
            this.lblsubtotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblValorSubtotal
            // 
            this.lblValorSubtotal.Font = new System.Drawing.Font("Bahnschrift", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValorSubtotal.Location = new System.Drawing.Point(85, 10);
            this.lblValorSubtotal.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblValorSubtotal.Name = "lblValorSubtotal";
            this.lblValorSubtotal.Size = new System.Drawing.Size(270, 25);
            this.lblValorSubtotal.TabIndex = 22;
            this.lblValorSubtotal.Tag = "";
            this.lblValorSubtotal.Text = "Valor subtotal";
            this.lblValorSubtotal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbldescuentopresupuesto
            // 

            this.lbldescuentopresupuesto.Font = new System.Drawing.Font("Bahnschrift", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbldescuentopresupuesto.Location = new System.Drawing.Point(10, 45);
            this.lbldescuentopresupuesto.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbldescuentopresupuesto.Name = "label9";
            this.lbldescuentopresupuesto.Size = new System.Drawing.Size(95, 25);
            this.lbldescuentopresupuesto.TabIndex = 23;
            this.lbldescuentopresupuesto.Text = "Descuento %";
            this.lbldescuentopresupuesto.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtDescuento
            // 
            this.txtDescuento.Font = new System.Drawing.Font("Bahnschrift", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescuento.ForeColor = System.Drawing.Color.Black;
            this.txtDescuento.Location = new System.Drawing.Point(105, 45);
            this.txtDescuento.Margin = new System.Windows.Forms.Padding(2);
            this.txtDescuento.Name = "txtDescuento";
            this.txtDescuento.Size = new System.Drawing.Size(120, 25);
            this.txtDescuento.TabIndex = 24;
            // 

            // btnDescuento
            // 
            this.btnaplicarDescuento.Font = new System.Drawing.Font("Bahnschrift", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnaplicarDescuento.ForeColor = System.Drawing.Color.Black;
            this.btnaplicarDescuento.Location = new System.Drawing.Point(235, 42);
            this.btnaplicarDescuento.Margin = new System.Windows.Forms.Padding(2);
            this.btnaplicarDescuento.Name = "btnDescuento";
            this.btnaplicarDescuento.Size = new System.Drawing.Size(120, 30);
            this.btnaplicarDescuento.TabIndex = 25;
            this.btnaplicarDescuento.Text = "Aplicar";
            this.btnaplicarDescuento.UseVisualStyleBackColor = true;
            this.btnaplicarDescuento.Click += new System.EventHandler(this.btnDescuento_Click);
            // 
            // lvlValorPresupuesto
            // 
            this.lblValorPresupuesto.Font = new System.Drawing.Font("Bahnschrift", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValorPresupuesto.Location = new System.Drawing.Point(145, 80);
            this.lblValorPresupuesto.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblValorPresupuesto.Name = "lvlValorPresupuesto";
            this.lblValorPresupuesto.Size = new System.Drawing.Size(210, 25);
            this.lblValorPresupuesto.TabIndex = 27;
            this.lblValorPresupuesto.Tag = "";
            this.lblValorPresupuesto.Text = "Valor presupuesto";
            this.lblValorPresupuesto.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label11
            // 
            this.lbltotalpresupuesto.Font = new System.Drawing.Font("Bahnschrift", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltotalpresupuesto.Location = new System.Drawing.Point(10, 80);
            this.lbltotalpresupuesto.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbltotalpresupuesto.Name = "label11";
            this.lbltotalpresupuesto.Size = new System.Drawing.Size(130, 25);
            this.lbltotalpresupuesto.TabIndex = 26;
            this.lbltotalpresupuesto.Text = "Total presupuesto:";
            this.lbltotalpresupuesto.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label14
            // 
            this.label14.Font = new System.Drawing.Font("Bahnschrift", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(10, 115);
            this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(155, 25);
            this.label14.TabIndex = 32;
            this.label14.Text = "Exportar presupuesto";
            // 
            // btnExportar
            // 
            this.btnExportar.Font = new System.Drawing.Font("Bahnschrift", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportar.ForeColor = System.Drawing.Color.Black;
            this.btnExportar.Location = new System.Drawing.Point(170, 110);
            this.btnExportar.Margin = new System.Windows.Forms.Padding(2);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(185, 30);
            this.btnExportar.TabIndex = 31;
            this.btnExportar.Text = "Exportar";
            this.btnExportar.UseVisualStyleBackColor = true;
            // 
            // dtpVigencia
            // 
            this.dtpVigencia.Font = new System.Drawing.Font("Bahnschrift", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpVigencia.Location = new System.Drawing.Point(33, 39);
            this.dtpVigencia.Margin = new System.Windows.Forms.Padding(2);
            this.dtpVigencia.Name = "dtpVigencia";
            this.dtpVigencia.Size = new System.Drawing.Size(300, 25);
            this.dtpVigencia.TabIndex = 33;
            // 

            // label15
            // 
            this.label15.Font = new System.Drawing.Font("Bahnschrift", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(133, 12);
            this.label15.Margin = new System.Windows.Forms.Padding(0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(105, 25);
            this.label15.TabIndex = 34;
            this.label15.Text = "Vigencia hasta";
            // 
            // btnBuscarPresupuesto
            // 
            this.btnBuscarPresupuesto.BackColor = System.Drawing.Color.White;
            this.btnBuscarPresupuesto.Font = new System.Drawing.Font("Bahnschrift", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscarPresupuesto.ForeColor = System.Drawing.Color.Black;
            this.btnBuscarPresupuesto.Location = new System.Drawing.Point(350, 42);
            this.btnBuscarPresupuesto.Margin = new System.Windows.Forms.Padding(2);
            this.btnBuscarPresupuesto.Name = "btnBuscarPresupuesto";
            this.btnBuscarPresupuesto.Size = new System.Drawing.Size(65, 30);
            this.btnBuscarPresupuesto.TabIndex = 39;
            this.btnBuscarPresupuesto.Text = "Cargar";
            this.btnBuscarPresupuesto.UseVisualStyleBackColor = false;
            this.btnBuscarPresupuesto.Click += new System.EventHandler(this.btnBuscarPresupuesto_Click);
            // 
            // lblcargarpresupuestoexistente
            // 

            this.label10.Font = new System.Drawing.Font("Bahnschrift", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(185, 45);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(160, 25);
            this.label10.TabIndex = 38;
            this.label10.Text = "Presupuesto existente";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.pnlBorde.Size = new System.Drawing.Size(1025, 40);
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
            this.lblTitulo.Size = new System.Drawing.Size(945, 40);
            this.lblTitulo.TabIndex = 23;
            this.lblTitulo.Text = "Presupuestador";
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
            this.pctClose.Location = new System.Drawing.Point(985, 0);
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
            this.pnlBordeInferior.Font = new System.Drawing.Font("Bahnschrift", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlBordeInferior.Location = new System.Drawing.Point(0, 600);
            this.pnlBordeInferior.Name = "pnlBordeInferior";
            this.pnlBordeInferior.Size = new System.Drawing.Size(1025, 20);
            this.pnlBordeInferior.TabIndex = 8047;
            // 
            // pnlPresupuesto
            // 
            this.pnlPresupuesto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(40)))));
            this.pnlPresupuesto.Controls.Add(this.btnBuscarPresupuesto);
            this.pnlPresupuesto.Controls.Add(this.lbldescpresupuesto);
            this.pnlPresupuesto.Controls.Add(this.txtDescripcion);
            this.pnlPresupuesto.Controls.Add(this.label10);
            this.pnlPresupuesto.ForeColor = System.Drawing.Color.White;
            this.pnlPresupuesto.Location = new System.Drawing.Point(10, 210);
            this.pnlPresupuesto.Name = "pnlPresupuesto";
            this.pnlPresupuesto.Size = new System.Drawing.Size(630, 80);
            this.pnlPresupuesto.TabIndex = 8048;
            this.pnlPresupuesto.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlPresupuesto_Paint);
            // 
            // pnlTotales
            // 
            this.pnlTotales.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(40)))));
            this.pnlTotales.Controls.Add(this.lbldescuentopresupuesto);
            this.pnlTotales.Controls.Add(this.lblValorSubtotal);
            this.pnlTotales.Controls.Add(this.lblsubtotal);
            this.pnlTotales.Controls.Add(this.txtDescuento);
            this.pnlTotales.Controls.Add(this.btnaplicarDescuento);
            this.pnlTotales.Controls.Add(this.lbltotalpresupuesto);
            this.pnlTotales.Controls.Add(this.lblValorPresupuesto);
            this.pnlTotales.Controls.Add(this.label14);
            this.pnlTotales.Controls.Add(this.btnExportar);
            this.pnlTotales.ForeColor = System.Drawing.Color.White;
            this.pnlTotales.Location = new System.Drawing.Point(650, 50);
            this.pnlTotales.Name = "pnlTotales";
            this.pnlTotales.Size = new System.Drawing.Size(365, 150);
            this.pnlTotales.TabIndex = 8049;
            this.pnlTotales.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlTotales_Paint);
            // 
            // pnlVigencia
            // 
            this.pnlVigencia.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(40)))));
            this.pnlVigencia.Controls.Add(this.label15);
            this.pnlVigencia.Controls.Add(this.dtpVigencia);
            this.pnlVigencia.ForeColor = System.Drawing.Color.White;
            this.pnlVigencia.Location = new System.Drawing.Point(650, 210);
            this.pnlVigencia.Name = "pnlVigencia";
            this.pnlVigencia.Size = new System.Drawing.Size(365, 80);
            this.pnlVigencia.TabIndex = 8050;
            this.pnlVigencia.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlVigencia_Paint);
            // 
            // frmPresupuestador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;

            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::Vista.Properties.Resources.WoodenPlankCyan;
            this.ClientSize = new System.Drawing.Size(1025, 620);
            this.Controls.Add(this.pnlVigencia);
            this.Controls.Add(this.pnlTotales);
            this.Controls.Add(this.pnlPresupuesto);
            this.Controls.Add(this.pnlBordeInferior);
            this.Controls.Add(this.pnlBorde);
            this.Controls.Add(this.gbxCotizaciones);
            this.Controls.Add(this.gbxCliente);
            this.Font = new System.Drawing.Font("Bahnschrift", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmPresupuestador";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Presupuestador";
            this.Load += new System.EventHandler(this.frmPresupuestador_Load);
            this.gbxCliente.ResumeLayout(false);
            this.gbxCliente.PerformLayout();
            this.gbxCotizaciones.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPresupuesto)).EndInit();
            this.pnlBorde.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pctMinimize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctClose)).EndInit();
            this.pnlPresupuesto.ResumeLayout(false);
            this.pnlPresupuesto.PerformLayout();
            this.pnlTotales.ResumeLayout(false);
            this.pnlTotales.PerformLayout();
            this.pnlVigencia.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbxCliente;
        private System.Windows.Forms.TextBox txtMailCliente;
        private System.Windows.Forms.Label lblemailclientepresupuesto;
        private System.Windows.Forms.TextBox txtTelefonoCliente;
        private System.Windows.Forms.Label lbltelefonoclientepresupuesto;
        private System.Windows.Forms.TextBox txtApellidoCliente;
        private System.Windows.Forms.Label lblapellidoclientepresupuesto;
        private System.Windows.Forms.TextBox txtNombreCliente;
        private System.Windows.Forms.Label lblnombreclientepresupuesto;
        private System.Windows.Forms.Button btnBuscarDni;
        private System.Windows.Forms.Label lbldniclientepresupuesto;
        private System.Windows.Forms.TextBox txtDni;
        private System.Windows.Forms.ComboBox cmbDni;
        private System.Windows.Forms.GroupBox gbxCotizaciones;
        private System.Windows.Forms.DataGridView dgvPresupuesto;
        private System.Windows.Forms.Label lbldescpresupuesto;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Label lblsubtotal;
        private System.Windows.Forms.Label lblValorSubtotal;
        private System.Windows.Forms.Label lbldescuentopresupuesto;
        private System.Windows.Forms.TextBox txtDescuento;
        private System.Windows.Forms.Button btnaplicarDescuento;
        private System.Windows.Forms.Label lblValorPresupuesto;
        private System.Windows.Forms.Label lbltotalpresupuesto;
        private System.Windows.Forms.Button btnVenta;

        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button btnExportar;
        private System.Windows.Forms.Button btnSubtotal;
        private System.Windows.Forms.Button btnBorrarCotizacion;
        private System.Windows.Forms.Button btnEditarCotizacion;
        private System.Windows.Forms.DateTimePicker dtpVigencia;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Button btnBuscarCotizacion;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnCotizar;
        private System.Windows.Forms.Button btnBuscarPresupuesto;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel pnlBorde;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.PictureBox pctMinimize;
        private System.Windows.Forms.PictureBox pctClose;
        private System.Windows.Forms.Panel pnlBordeInferior;
        private System.Windows.Forms.Panel pnlPresupuesto;
        private System.Windows.Forms.Panel pnlTotales;
        private System.Windows.Forms.Panel pnlVigencia;
    }
}