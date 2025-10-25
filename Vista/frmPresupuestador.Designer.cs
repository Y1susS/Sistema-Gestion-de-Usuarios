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
            this.lbltitulopresupuesto = new System.Windows.Forms.Label();
            this.gbxCliente = new System.Windows.Forms.GroupBox();
            this.txtMailCliente = new System.Windows.Forms.TextBox();
            this.lblemailclientepresupuesto = new System.Windows.Forms.Label();
            this.txtTelefonoCliente = new System.Windows.Forms.TextBox();
            this.txtApellidoCliente = new System.Windows.Forms.TextBox();
            this.lbltelefonoclientepresupuesto = new System.Windows.Forms.Label();
            this.lblapellidoclientepresupuesto = new System.Windows.Forms.Label();
            this.txtNombreCliente = new System.Windows.Forms.TextBox();
            this.lblnombreclientepresupuesto = new System.Windows.Forms.Label();
            this.btnBuscarDni = new System.Windows.Forms.Button();
            this.lbldniclientepresupuesto = new System.Windows.Forms.Label();
            this.txtDni = new System.Windows.Forms.TextBox();
            this.cmbDni = new System.Windows.Forms.ComboBox();
            this.gbxCotizaciones = new System.Windows.Forms.GroupBox();
            this.btnCotizarpresupuesto = new System.Windows.Forms.Button();
            this.btnBuscarCotizacionexist = new System.Windows.Forms.Button();
            this.lblcargarcotexist = new System.Windows.Forms.Label();
            this.btnSubtotalpresupuesto = new System.Windows.Forms.Button();
            this.btnBorrarpresupuesto = new System.Windows.Forms.Button();
            this.btnEditarpresupuesto = new System.Windows.Forms.Button();
            this.dgvPresupuesto = new System.Windows.Forms.DataGridView();
            this.lbldescpresupuesto = new System.Windows.Forms.Label();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.lblsubtotal = new System.Windows.Forms.Label();
            this.lblValorSubtotal = new System.Windows.Forms.Label();
            this.lbldescuentopresupuesto = new System.Windows.Forms.Label();
            this.txtDescuento = new System.Windows.Forms.TextBox();
            this.btnaplicarDescuento = new System.Windows.Forms.Button();
            this.lblValorPresupuesto = new System.Windows.Forms.Label();
            this.lbltotalpresupuesto = new System.Windows.Forms.Label();
            this.btnVenta = new System.Windows.Forms.Button();
            this.btnEnviarxMail = new System.Windows.Forms.Button();
            this.lblfinalizarpresupuesto = new System.Windows.Forms.Label();
            this.lblenviarpresupuestoxmail = new System.Windows.Forms.Label();
            this.lblimprimirpresupuesto = new System.Windows.Forms.Label();
            this.btnImprimirpresupuesto = new System.Windows.Forms.Button();
            this.dtpVigencia = new System.Windows.Forms.DateTimePicker();
            this.lblvigenciapresupuesto = new System.Windows.Forms.Label();
            this.lblnumeropresupuesto = new System.Windows.Forms.Label();
            this.lblestadopresupuesto = new System.Windows.Forms.Label();
            this.btnguardarpresupuesto = new System.Windows.Forms.Button();
            this.btnBuscarPresupuesto = new System.Windows.Forms.Button();
            this.lblcargarpresupuestoexistente = new System.Windows.Forms.Label();
            this.gbxCliente.SuspendLayout();
            this.gbxCotizaciones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPresupuesto)).BeginInit();
            this.SuspendLayout();
            // 
            // lbltitulopresupuesto
            // 
            this.lbltitulopresupuesto.AutoSize = true;
            this.lbltitulopresupuesto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.lbltitulopresupuesto.Location = new System.Drawing.Point(50, 24);
            this.lbltitulopresupuesto.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbltitulopresupuesto.Name = "lbltitulopresupuesto";
            this.lbltitulopresupuesto.Size = new System.Drawing.Size(354, 13);
            this.lbltitulopresupuesto.TabIndex = 16;
            this.lbltitulopresupuesto.Text = "Busque al Cliente para Confirme las cotizaciones y finalizar el Presupuesto";
            // 
            // gbxCliente
            // 
            this.gbxCliente.Controls.Add(this.txtMailCliente);
            this.gbxCliente.Controls.Add(this.lblemailclientepresupuesto);
            this.gbxCliente.Controls.Add(this.txtTelefonoCliente);
            this.gbxCliente.Controls.Add(this.txtApellidoCliente);
            this.gbxCliente.Controls.Add(this.lbltelefonoclientepresupuesto);
            this.gbxCliente.Controls.Add(this.lblapellidoclientepresupuesto);
            this.gbxCliente.Controls.Add(this.txtNombreCliente);
            this.gbxCliente.Controls.Add(this.lblnombreclientepresupuesto);
            this.gbxCliente.Controls.Add(this.btnBuscarDni);
            this.gbxCliente.Controls.Add(this.lbldniclientepresupuesto);
            this.gbxCliente.Controls.Add(this.txtDni);
            this.gbxCliente.Controls.Add(this.cmbDni);
            this.gbxCliente.Location = new System.Drawing.Point(43, 58);
            this.gbxCliente.Margin = new System.Windows.Forms.Padding(2);
            this.gbxCliente.Name = "gbxCliente";
            this.gbxCliente.Padding = new System.Windows.Forms.Padding(2);
            this.gbxCliente.Size = new System.Drawing.Size(652, 81);
            this.gbxCliente.TabIndex = 17;
            this.gbxCliente.TabStop = false;
            this.gbxCliente.Text = "Cliente";
            // 
            // txtMailCliente
            // 
            this.txtMailCliente.Location = new System.Drawing.Point(466, 48);
            this.txtMailCliente.Margin = new System.Windows.Forms.Padding(2);
            this.txtMailCliente.Name = "txtMailCliente";
            this.txtMailCliente.Size = new System.Drawing.Size(111, 20);
            this.txtMailCliente.TabIndex = 24;
            // 
            // lblemailclientepresupuesto
            // 
            this.lblemailclientepresupuesto.AutoSize = true;
            this.lblemailclientepresupuesto.Location = new System.Drawing.Point(425, 50);
            this.lblemailclientepresupuesto.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblemailclientepresupuesto.Name = "lblemailclientepresupuesto";
            this.lblemailclientepresupuesto.Size = new System.Drawing.Size(35, 13);
            this.lblemailclientepresupuesto.TabIndex = 23;
            this.lblemailclientepresupuesto.Text = "E-mail";
            this.lblemailclientepresupuesto.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtTelefonoCliente
            // 
            this.txtTelefonoCliente.Location = new System.Drawing.Point(465, 18);
            this.txtTelefonoCliente.Margin = new System.Windows.Forms.Padding(2);
            this.txtTelefonoCliente.Name = "txtTelefonoCliente";
            this.txtTelefonoCliente.Size = new System.Drawing.Size(111, 20);
            this.txtTelefonoCliente.TabIndex = 22;
            // 
            // txtApellidoCliente
            // 
            this.txtApellidoCliente.Location = new System.Drawing.Point(302, 48);
            this.txtApellidoCliente.Margin = new System.Windows.Forms.Padding(2);
            this.txtApellidoCliente.Name = "txtApellidoCliente";
            this.txtApellidoCliente.Size = new System.Drawing.Size(100, 20);
            this.txtApellidoCliente.TabIndex = 20;
            // 
            // lbltelefonoclientepresupuesto
            // 
            this.lbltelefonoclientepresupuesto.AutoSize = true;
            this.lbltelefonoclientepresupuesto.Location = new System.Drawing.Point(417, 20);
            this.lbltelefonoclientepresupuesto.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbltelefonoclientepresupuesto.Name = "lbltelefonoclientepresupuesto";
            this.lbltelefonoclientepresupuesto.Size = new System.Drawing.Size(49, 13);
            this.lbltelefonoclientepresupuesto.TabIndex = 21;
            this.lbltelefonoclientepresupuesto.Text = "Telefono";
            this.lbltelefonoclientepresupuesto.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblapellidoclientepresupuesto
            // 
            this.lblapellidoclientepresupuesto.AutoSize = true;
            this.lblapellidoclientepresupuesto.Location = new System.Drawing.Point(254, 50);
            this.lblapellidoclientepresupuesto.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblapellidoclientepresupuesto.Name = "lblapellidoclientepresupuesto";
            this.lblapellidoclientepresupuesto.Size = new System.Drawing.Size(44, 13);
            this.lblapellidoclientepresupuesto.TabIndex = 19;
            this.lblapellidoclientepresupuesto.Text = "Apellido";
            this.lblapellidoclientepresupuesto.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtNombreCliente
            // 
            this.txtNombreCliente.Location = new System.Drawing.Point(302, 17);
            this.txtNombreCliente.Margin = new System.Windows.Forms.Padding(2);
            this.txtNombreCliente.Name = "txtNombreCliente";
            this.txtNombreCliente.Size = new System.Drawing.Size(100, 20);
            this.txtNombreCliente.TabIndex = 18;
            // 
            // lblnombreclientepresupuesto
            // 
            this.lblnombreclientepresupuesto.AutoSize = true;
            this.lblnombreclientepresupuesto.Location = new System.Drawing.Point(254, 20);
            this.lblnombreclientepresupuesto.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblnombreclientepresupuesto.Name = "lblnombreclientepresupuesto";
            this.lblnombreclientepresupuesto.Size = new System.Drawing.Size(44, 13);
            this.lblnombreclientepresupuesto.TabIndex = 17;
            this.lblnombreclientepresupuesto.Text = "Nombre";
            this.lblnombreclientepresupuesto.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnBuscarDni
            // 
            this.btnBuscarDni.Location = new System.Drawing.Point(191, 34);
            this.btnBuscarDni.Margin = new System.Windows.Forms.Padding(2);
            this.btnBuscarDni.Name = "btnBuscarDni";
            this.btnBuscarDni.Size = new System.Drawing.Size(56, 19);
            this.btnBuscarDni.TabIndex = 16;
            this.btnBuscarDni.Text = "Buscar";
            this.btnBuscarDni.UseVisualStyleBackColor = true;
            this.btnBuscarDni.Click += new System.EventHandler(this.btnBuscarDni_Click);
            // 
            // lbldniclientepresupuesto
            // 
            this.lbldniclientepresupuesto.AutoSize = true;
            this.lbldniclientepresupuesto.Location = new System.Drawing.Point(8, 37);
            this.lbldniclientepresupuesto.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbldniclientepresupuesto.Name = "lbldniclientepresupuesto";
            this.lbldniclientepresupuesto.Size = new System.Drawing.Size(26, 13);
            this.lbldniclientepresupuesto.TabIndex = 15;
            this.lbldniclientepresupuesto.Text = "DNI";
            this.lbldniclientepresupuesto.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtDni
            // 
            this.txtDni.Location = new System.Drawing.Point(84, 33);
            this.txtDni.Margin = new System.Windows.Forms.Padding(2);
            this.txtDni.Name = "txtDni";
            this.txtDni.Size = new System.Drawing.Size(104, 20);
            this.txtDni.TabIndex = 14;
            this.txtDni.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDni_KeyDown);
            this.txtDni.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDni_Keypress);
            // 
            // cmbDni
            // 
            this.cmbDni.FormattingEnabled = true;
            this.cmbDni.Location = new System.Drawing.Point(34, 32);
            this.cmbDni.Margin = new System.Windows.Forms.Padding(2);
            this.cmbDni.Name = "cmbDni";
            this.cmbDni.Size = new System.Drawing.Size(47, 21);
            this.cmbDni.TabIndex = 13;
            // 
            // gbxCotizaciones
            // 
            this.gbxCotizaciones.Controls.Add(this.btnCotizarpresupuesto);
            this.gbxCotizaciones.Controls.Add(this.btnBuscarCotizacionexist);
            this.gbxCotizaciones.Controls.Add(this.lblcargarcotexist);
            this.gbxCotizaciones.Controls.Add(this.btnSubtotalpresupuesto);
            this.gbxCotizaciones.Controls.Add(this.btnBorrarpresupuesto);
            this.gbxCotizaciones.Controls.Add(this.btnEditarpresupuesto);
            this.gbxCotizaciones.Controls.Add(this.dgvPresupuesto);
            this.gbxCotizaciones.Location = new System.Drawing.Point(38, 226);
            this.gbxCotizaciones.Margin = new System.Windows.Forms.Padding(2);
            this.gbxCotizaciones.Name = "gbxCotizaciones";
            this.gbxCotizaciones.Padding = new System.Windows.Forms.Padding(2);
            this.gbxCotizaciones.Size = new System.Drawing.Size(656, 236);
            this.gbxCotizaciones.TabIndex = 18;
            this.gbxCotizaciones.TabStop = false;
            this.gbxCotizaciones.Text = "Cotizaciones";
            // 
            // btnCotizarpresupuesto
            // 
            this.btnCotizarpresupuesto.Location = new System.Drawing.Point(572, 33);
            this.btnCotizarpresupuesto.Margin = new System.Windows.Forms.Padding(2);
            this.btnCotizarpresupuesto.Name = "btnCotizarpresupuesto";
            this.btnCotizarpresupuesto.Size = new System.Drawing.Size(56, 19);
            this.btnCotizarpresupuesto.TabIndex = 25;
            this.btnCotizarpresupuesto.Text = "Cotizar";
            this.btnCotizarpresupuesto.UseVisualStyleBackColor = true;
            // 
            // btnBuscarCotizacionexist
            // 
            this.btnBuscarCotizacionexist.Location = new System.Drawing.Point(292, 197);
            this.btnBuscarCotizacionexist.Margin = new System.Windows.Forms.Padding(2);
            this.btnBuscarCotizacionexist.Name = "btnBuscarCotizacionexist";
            this.btnBuscarCotizacionexist.Size = new System.Drawing.Size(56, 19);
            this.btnBuscarCotizacionexist.TabIndex = 24;
            this.btnBuscarCotizacionexist.Text = "Buscar";
            this.btnBuscarCotizacionexist.UseVisualStyleBackColor = true;
            // 
            // lblcargarcotexist
            // 
            this.lblcargarcotexist.AutoSize = true;
            this.lblcargarcotexist.Location = new System.Drawing.Point(158, 200);
            this.lblcargarcotexist.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblcargarcotexist.Name = "lblcargarcotexist";
            this.lblcargarcotexist.Size = new System.Drawing.Size(135, 13);
            this.lblcargarcotexist.TabIndex = 23;
            this.lblcargarcotexist.Text = "Cargar Cotizacion existente";
            // 
            // btnSubtotalpresupuesto
            // 
            this.btnSubtotalpresupuesto.Location = new System.Drawing.Point(572, 135);
            this.btnSubtotalpresupuesto.Margin = new System.Windows.Forms.Padding(2);
            this.btnSubtotalpresupuesto.Name = "btnSubtotalpresupuesto";
            this.btnSubtotalpresupuesto.Size = new System.Drawing.Size(56, 19);
            this.btnSubtotalpresupuesto.TabIndex = 22;
            this.btnSubtotalpresupuesto.Text = "Subtotal";
            this.btnSubtotalpresupuesto.UseVisualStyleBackColor = true;
            // 
            // btnBorrarpresupuesto
            // 
            this.btnBorrarpresupuesto.Location = new System.Drawing.Point(572, 101);
            this.btnBorrarpresupuesto.Margin = new System.Windows.Forms.Padding(2);
            this.btnBorrarpresupuesto.Name = "btnBorrarpresupuesto";
            this.btnBorrarpresupuesto.Size = new System.Drawing.Size(56, 19);
            this.btnBorrarpresupuesto.TabIndex = 21;
            this.btnBorrarpresupuesto.Text = "Borrar";
            this.btnBorrarpresupuesto.UseVisualStyleBackColor = true;
            // 
            // btnEditarpresupuesto
            // 
            this.btnEditarpresupuesto.Location = new System.Drawing.Point(572, 67);
            this.btnEditarpresupuesto.Margin = new System.Windows.Forms.Padding(2);
            this.btnEditarpresupuesto.Name = "btnEditarpresupuesto";
            this.btnEditarpresupuesto.Size = new System.Drawing.Size(56, 19);
            this.btnEditarpresupuesto.TabIndex = 20;
            this.btnEditarpresupuesto.Text = "Editar";
            this.btnEditarpresupuesto.UseVisualStyleBackColor = true;
            // 
            // dgvPresupuesto
            // 
            this.dgvPresupuesto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPresupuesto.Location = new System.Drawing.Point(14, 17);
            this.dgvPresupuesto.Margin = new System.Windows.Forms.Padding(2);
            this.dgvPresupuesto.Name = "dgvPresupuesto";
            this.dgvPresupuesto.RowHeadersWidth = 51;
            this.dgvPresupuesto.RowTemplate.Height = 24;
            this.dgvPresupuesto.Size = new System.Drawing.Size(523, 165);
            this.dgvPresupuesto.TabIndex = 16;
            // 
            // lbldescpresupuesto
            // 
            this.lbldescpresupuesto.AutoSize = true;
            this.lbldescpresupuesto.Location = new System.Drawing.Point(40, 178);
            this.lbldescpresupuesto.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbldescpresupuesto.Name = "lbldescpresupuesto";
            this.lbldescpresupuesto.Size = new System.Drawing.Size(125, 13);
            this.lbldescpresupuesto.TabIndex = 19;
            this.lbldescpresupuesto.Text = "Descripcion Presupuesto";
            this.lbldescpresupuesto.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(170, 176);
            this.txtDescripcion.Margin = new System.Windows.Forms.Padding(2);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(279, 20);
            this.txtDescripcion.TabIndex = 20;
            // 
            // lblsubtotal
            // 
            this.lblsubtotal.AutoSize = true;
            this.lblsubtotal.Location = new System.Drawing.Point(57, 495);
            this.lblsubtotal.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblsubtotal.Name = "lblsubtotal";
            this.lblsubtotal.Size = new System.Drawing.Size(46, 13);
            this.lblsubtotal.TabIndex = 21;
            this.lblsubtotal.Text = "Subtotal";
            // 
            // lblValorSubtotal
            // 
            this.lblValorSubtotal.AutoSize = true;
            this.lblValorSubtotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblValorSubtotal.Location = new System.Drawing.Point(134, 495);
            this.lblValorSubtotal.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblValorSubtotal.Name = "lblValorSubtotal";
            this.lblValorSubtotal.Size = new System.Drawing.Size(83, 15);
            this.lblValorSubtotal.TabIndex = 22;
            this.lblValorSubtotal.Tag = "";
            this.lblValorSubtotal.Text = "Valor Subtotal\r\n";
            // 
            // lbldescuentopresupuesto
            // 
            this.lbldescuentopresupuesto.AutoSize = true;
            this.lbldescuentopresupuesto.Location = new System.Drawing.Point(57, 540);
            this.lbldescuentopresupuesto.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbldescuentopresupuesto.Name = "lbldescuentopresupuesto";
            this.lbldescuentopresupuesto.Size = new System.Drawing.Size(70, 13);
            this.lbldescuentopresupuesto.TabIndex = 23;
            this.lbldescuentopresupuesto.Text = "Descuento %";
            // 
            // txtDescuento
            // 
            this.txtDescuento.Location = new System.Drawing.Point(127, 537);
            this.txtDescuento.Margin = new System.Windows.Forms.Padding(2);
            this.txtDescuento.Name = "txtDescuento";
            this.txtDescuento.Size = new System.Drawing.Size(46, 20);
            this.txtDescuento.TabIndex = 24;
            // 
            // btnaplicarDescuento
            // 
            this.btnaplicarDescuento.Location = new System.Drawing.Point(190, 536);
            this.btnaplicarDescuento.Margin = new System.Windows.Forms.Padding(2);
            this.btnaplicarDescuento.Name = "btnaplicarDescuento";
            this.btnaplicarDescuento.Size = new System.Drawing.Size(56, 19);
            this.btnaplicarDescuento.TabIndex = 25;
            this.btnaplicarDescuento.Text = "Aplicar";
            this.btnaplicarDescuento.UseVisualStyleBackColor = true;
            // 
            // lblValorPresupuesto
            // 
            this.lblValorPresupuesto.AutoSize = true;
            this.lblValorPresupuesto.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblValorPresupuesto.Location = new System.Drawing.Point(143, 577);
            this.lblValorPresupuesto.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblValorPresupuesto.Name = "lblValorPresupuesto";
            this.lblValorPresupuesto.Size = new System.Drawing.Size(125, 17);
            this.lblValorPresupuesto.TabIndex = 27;
            this.lblValorPresupuesto.Tag = "";
            this.lblValorPresupuesto.Text = "Valor Presupuesto";
            // 
            // lbltotalpresupuesto
            // 
            this.lbltotalpresupuesto.AutoSize = true;
            this.lbltotalpresupuesto.Location = new System.Drawing.Point(51, 579);
            this.lbltotalpresupuesto.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbltotalpresupuesto.Name = "lbltotalpresupuesto";
            this.lbltotalpresupuesto.Size = new System.Drawing.Size(93, 13);
            this.lbltotalpresupuesto.TabIndex = 26;
            this.lbltotalpresupuesto.Text = "Total Presupuesto";
            // 
            // btnVenta
            // 
            this.btnVenta.Location = new System.Drawing.Point(584, 536);
            this.btnVenta.Margin = new System.Windows.Forms.Padding(2);
            this.btnVenta.Name = "btnVenta";
            this.btnVenta.Size = new System.Drawing.Size(82, 41);
            this.btnVenta.TabIndex = 21;
            this.btnVenta.Text = "Venta";
            this.btnVenta.UseVisualStyleBackColor = true;
            // 
            // btnEnviarxMail
            // 
            this.btnEnviarxMail.Location = new System.Drawing.Point(458, 540);
            this.btnEnviarxMail.Margin = new System.Windows.Forms.Padding(2);
            this.btnEnviarxMail.Name = "btnEnviarxMail";
            this.btnEnviarxMail.Size = new System.Drawing.Size(55, 19);
            this.btnEnviarxMail.TabIndex = 28;
            this.btnEnviarxMail.Text = "Enviar";
            this.btnEnviarxMail.UseVisualStyleBackColor = true;
            // 
            // lblfinalizarpresupuesto
            // 
            this.lblfinalizarpresupuesto.AutoSize = true;
            this.lblfinalizarpresupuesto.Location = new System.Drawing.Point(572, 509);
            this.lblfinalizarpresupuesto.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblfinalizarpresupuesto.Name = "lblfinalizarpresupuesto";
            this.lblfinalizarpresupuesto.Size = new System.Drawing.Size(107, 13);
            this.lblfinalizarpresupuesto.TabIndex = 29;
            this.lblfinalizarpresupuesto.Text = "Finalizar Presupuesto";
            // 
            // lblenviarpresupuestoxmail
            // 
            this.lblenviarpresupuestoxmail.AutoSize = true;
            this.lblenviarpresupuestoxmail.Location = new System.Drawing.Point(343, 542);
            this.lblenviarpresupuestoxmail.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblenviarpresupuestoxmail.Name = "lblenviarpresupuestoxmail";
            this.lblenviarpresupuestoxmail.Size = new System.Drawing.Size(77, 13);
            this.lblenviarpresupuestoxmail.TabIndex = 30;
            this.lblenviarpresupuestoxmail.Text = "Enviar por Mail";
            // 
            // lblimprimirpresupuesto
            // 
            this.lblimprimirpresupuesto.AutoSize = true;
            this.lblimprimirpresupuesto.Location = new System.Drawing.Point(328, 499);
            this.lblimprimirpresupuesto.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblimprimirpresupuesto.Name = "lblimprimirpresupuesto";
            this.lblimprimirpresupuesto.Size = new System.Drawing.Size(104, 13);
            this.lblimprimirpresupuesto.TabIndex = 32;
            this.lblimprimirpresupuesto.Text = "Imprimir Presupuesto";
            // 
            // btnImprimirpresupuesto
            // 
            this.btnImprimirpresupuesto.Location = new System.Drawing.Point(458, 496);
            this.btnImprimirpresupuesto.Margin = new System.Windows.Forms.Padding(2);
            this.btnImprimirpresupuesto.Name = "btnImprimirpresupuesto";
            this.btnImprimirpresupuesto.Size = new System.Drawing.Size(55, 19);
            this.btnImprimirpresupuesto.TabIndex = 31;
            this.btnImprimirpresupuesto.Text = "Imprimir";
            this.btnImprimirpresupuesto.UseVisualStyleBackColor = true;
            // 
            // dtpVigencia
            // 
            this.dtpVigencia.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpVigencia.Location = new System.Drawing.Point(366, 577);
            this.dtpVigencia.Margin = new System.Windows.Forms.Padding(2);
            this.dtpVigencia.Name = "dtpVigencia";
            this.dtpVigencia.Size = new System.Drawing.Size(74, 20);
            this.dtpVigencia.TabIndex = 33;
            // 
            // lblvigenciapresupuesto
            // 
            this.lblvigenciapresupuesto.AutoSize = true;
            this.lblvigenciapresupuesto.Location = new System.Drawing.Point(290, 579);
            this.lblvigenciapresupuesto.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblvigenciapresupuesto.Name = "lblvigenciapresupuesto";
            this.lblvigenciapresupuesto.Size = new System.Drawing.Size(77, 13);
            this.lblvigenciapresupuesto.TabIndex = 34;
            this.lblvigenciapresupuesto.Text = "Vigencia hasta";
            // 
            // lblnumeropresupuesto
            // 
            this.lblnumeropresupuesto.AutoSize = true;
            this.lblnumeropresupuesto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.lblnumeropresupuesto.Location = new System.Drawing.Point(449, 25);
            this.lblnumeropresupuesto.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblnumeropresupuesto.Name = "lblnumeropresupuesto";
            this.lblnumeropresupuesto.Size = new System.Drawing.Size(81, 13);
            this.lblnumeropresupuesto.TabIndex = 35;
            this.lblnumeropresupuesto.Text = "N° Presupuesto";
            // 
            // lblestadopresupuesto
            // 
            this.lblestadopresupuesto.AutoSize = true;
            this.lblestadopresupuesto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.lblestadopresupuesto.Location = new System.Drawing.Point(572, 25);
            this.lblestadopresupuesto.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblestadopresupuesto.Name = "lblestadopresupuesto";
            this.lblestadopresupuesto.Size = new System.Drawing.Size(102, 13);
            this.lblestadopresupuesto.TabIndex = 36;
            this.lblestadopresupuesto.Text = "Estado Presupuesto";
            // 
            // btnguardarpresupuesto
            // 
            this.btnguardarpresupuesto.Location = new System.Drawing.Point(458, 576);
            this.btnguardarpresupuesto.Margin = new System.Windows.Forms.Padding(2);
            this.btnguardarpresupuesto.Name = "btnguardarpresupuesto";
            this.btnguardarpresupuesto.Size = new System.Drawing.Size(55, 19);
            this.btnguardarpresupuesto.TabIndex = 37;
            this.btnguardarpresupuesto.Text = "Guardar";
            this.btnguardarpresupuesto.UseVisualStyleBackColor = true;
            // 
            // btnBuscarPresupuesto
            // 
            this.btnBuscarPresupuesto.Location = new System.Drawing.Point(610, 176);
            this.btnBuscarPresupuesto.Margin = new System.Windows.Forms.Padding(2);
            this.btnBuscarPresupuesto.Name = "btnBuscarPresupuesto";
            this.btnBuscarPresupuesto.Size = new System.Drawing.Size(56, 19);
            this.btnBuscarPresupuesto.TabIndex = 39;
            this.btnBuscarPresupuesto.Text = "Buscar";
            this.btnBuscarPresupuesto.UseVisualStyleBackColor = true;
            this.btnBuscarPresupuesto.Click += new System.EventHandler(this.btnBuscarPresupuesto_Click);
            // 
            // lblcargarpresupuestoexistente
            // 
            this.lblcargarpresupuestoexistente.AutoSize = true;
            this.lblcargarpresupuestoexistente.Location = new System.Drawing.Point(470, 178);
            this.lblcargarpresupuestoexistente.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblcargarpresupuestoexistente.Name = "lblcargarpresupuestoexistente";
            this.lblcargarpresupuestoexistente.Size = new System.Drawing.Size(145, 13);
            this.lblcargarpresupuestoexistente.TabIndex = 38;
            this.lblcargarpresupuestoexistente.Text = "Cargar Presupuesto existente";
            // 
            // frmPresupuestador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(728, 615);
            this.Controls.Add(this.btnBuscarPresupuesto);
            this.Controls.Add(this.lblcargarpresupuestoexistente);
            this.Controls.Add(this.btnguardarpresupuesto);
            this.Controls.Add(this.lblestadopresupuesto);
            this.Controls.Add(this.lblnumeropresupuesto);
            this.Controls.Add(this.lblvigenciapresupuesto);
            this.Controls.Add(this.dtpVigencia);
            this.Controls.Add(this.lblimprimirpresupuesto);
            this.Controls.Add(this.btnImprimirpresupuesto);
            this.Controls.Add(this.lblenviarpresupuestoxmail);
            this.Controls.Add(this.lblfinalizarpresupuesto);
            this.Controls.Add(this.btnEnviarxMail);
            this.Controls.Add(this.lblValorPresupuesto);
            this.Controls.Add(this.btnVenta);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.lbltotalpresupuesto);
            this.Controls.Add(this.lbldescpresupuesto);
            this.Controls.Add(this.gbxCotizaciones);
            this.Controls.Add(this.btnaplicarDescuento);
            this.Controls.Add(this.gbxCliente);
            this.Controls.Add(this.lbltitulopresupuesto);
            this.Controls.Add(this.txtDescuento);
            this.Controls.Add(this.lblsubtotal);
            this.Controls.Add(this.lblValorSubtotal);
            this.Controls.Add(this.lbldescuentopresupuesto);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmPresupuestador";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Presupuestador";
            this.gbxCliente.ResumeLayout(false);
            this.gbxCliente.PerformLayout();
            this.gbxCotizaciones.ResumeLayout(false);
            this.gbxCotizaciones.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPresupuesto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lbltitulopresupuesto;
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
        private System.Windows.Forms.Button btnEnviarxMail;
        private System.Windows.Forms.Label lblfinalizarpresupuesto;
        private System.Windows.Forms.Label lblenviarpresupuestoxmail;
        private System.Windows.Forms.Label lblimprimirpresupuesto;
        private System.Windows.Forms.Button btnImprimirpresupuesto;
        private System.Windows.Forms.Button btnSubtotalpresupuesto;
        private System.Windows.Forms.Button btnBorrarpresupuesto;
        private System.Windows.Forms.Button btnEditarpresupuesto;
        private System.Windows.Forms.DateTimePicker dtpVigencia;
        private System.Windows.Forms.Label lblvigenciapresupuesto;
        private System.Windows.Forms.Label lblnumeropresupuesto;
        private System.Windows.Forms.Label lblestadopresupuesto;
        private System.Windows.Forms.Button btnBuscarCotizacionexist;
        private System.Windows.Forms.Label lblcargarcotexist;
        private System.Windows.Forms.Button btnguardarpresupuesto;
        private System.Windows.Forms.Button btnCotizarpresupuesto;
        private System.Windows.Forms.Button btnBuscarPresupuesto;
        private System.Windows.Forms.Label lblcargarpresupuestoexistente;
    }
}