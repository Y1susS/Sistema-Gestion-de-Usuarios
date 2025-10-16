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
            this.label6 = new System.Windows.Forms.Label();
            this.gbxCliente = new System.Windows.Forms.GroupBox();
            this.txtMailCliente = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTelefonoCliente = new System.Windows.Forms.TextBox();
            this.txtApellidoCliente = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNombreCliente = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnBuscarDni = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDni = new System.Windows.Forms.TextBox();
            this.cmbDni = new System.Windows.Forms.ComboBox();
            this.gbxCotizaciones = new System.Windows.Forms.GroupBox();
            this.btnCotizar = new System.Windows.Forms.Button();
            this.btnBuscarCotizacion = new System.Windows.Forms.Button();
            this.label18 = new System.Windows.Forms.Label();
            this.btnSubtotal = new System.Windows.Forms.Button();
            this.btnBorrarCotizacion = new System.Windows.Forms.Button();
            this.btnEditarCotizacion = new System.Windows.Forms.Button();
            this.dgvPresupuesto = new System.Windows.Forms.DataGridView();
            this.label7 = new System.Windows.Forms.Label();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.lblValorSubtotal = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtDescuento = new System.Windows.Forms.TextBox();
            this.btnDescuento = new System.Windows.Forms.Button();
            this.lvlValorPresupuesto = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.btnVenta = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.dtpVigencia = new System.Windows.Forms.DateTimePicker();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.btnBuscarPresupuesto = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.gbxCliente.SuspendLayout();
            this.gbxCotizaciones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPresupuesto)).BeginInit();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.label6.Location = new System.Drawing.Point(67, 30);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(478, 17);
            this.label6.TabIndex = 16;
            this.label6.Text = "Busque al Cliente para Confirme las cotizaciones y finalizar el Presupuesto";
            // 
            // gbxCliente
            // 
            this.gbxCliente.Controls.Add(this.txtMailCliente);
            this.gbxCliente.Controls.Add(this.label4);
            this.gbxCliente.Controls.Add(this.txtTelefonoCliente);
            this.gbxCliente.Controls.Add(this.txtApellidoCliente);
            this.gbxCliente.Controls.Add(this.label5);
            this.gbxCliente.Controls.Add(this.label3);
            this.gbxCliente.Controls.Add(this.txtNombreCliente);
            this.gbxCliente.Controls.Add(this.label2);
            this.gbxCliente.Controls.Add(this.btnBuscarDni);
            this.gbxCliente.Controls.Add(this.label1);
            this.gbxCliente.Controls.Add(this.txtDni);
            this.gbxCliente.Controls.Add(this.cmbDni);
            this.gbxCliente.Location = new System.Drawing.Point(57, 72);
            this.gbxCliente.Name = "gbxCliente";
            this.gbxCliente.Size = new System.Drawing.Size(869, 100);
            this.gbxCliente.TabIndex = 17;
            this.gbxCliente.TabStop = false;
            this.gbxCliente.Text = "Cliente";
            // 
            // txtMailCliente
            // 
            this.txtMailCliente.Location = new System.Drawing.Point(621, 59);
            this.txtMailCliente.Name = "txtMailCliente";
            this.txtMailCliente.Size = new System.Drawing.Size(147, 22);
            this.txtMailCliente.TabIndex = 24;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(567, 62);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 16);
            this.label4.TabIndex = 23;
            this.label4.Text = "Mail";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtTelefonoCliente
            // 
            this.txtTelefonoCliente.Location = new System.Drawing.Point(620, 22);
            this.txtTelefonoCliente.Name = "txtTelefonoCliente";
            this.txtTelefonoCliente.Size = new System.Drawing.Size(147, 22);
            this.txtTelefonoCliente.TabIndex = 22;
            // 
            // txtApellidoCliente
            // 
            this.txtApellidoCliente.Location = new System.Drawing.Point(403, 59);
            this.txtApellidoCliente.Name = "txtApellidoCliente";
            this.txtApellidoCliente.Size = new System.Drawing.Size(132, 22);
            this.txtApellidoCliente.TabIndex = 20;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(556, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 16);
            this.label5.TabIndex = 21;
            this.label5.Text = "Telefono";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(339, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 16);
            this.label3.TabIndex = 19;
            this.label3.Text = "Apellido";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtNombreCliente
            // 
            this.txtNombreCliente.Location = new System.Drawing.Point(403, 21);
            this.txtNombreCliente.Name = "txtNombreCliente";
            this.txtNombreCliente.Size = new System.Drawing.Size(132, 22);
            this.txtNombreCliente.TabIndex = 18;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(339, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 16);
            this.label2.TabIndex = 17;
            this.label2.Text = "Nombre";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnBuscarDni
            // 
            this.btnBuscarDni.Location = new System.Drawing.Point(255, 42);
            this.btnBuscarDni.Name = "btnBuscarDni";
            this.btnBuscarDni.Size = new System.Drawing.Size(75, 23);
            this.btnBuscarDni.TabIndex = 16;
            this.btnBuscarDni.Text = "Buscar";
            this.btnBuscarDni.UseVisualStyleBackColor = true;
            this.btnBuscarDni.Click += new System.EventHandler(this.btnBuscarDni_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 16);
            this.label1.TabIndex = 15;
            this.label1.Text = "DNI";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtDni
            // 
            this.txtDni.Location = new System.Drawing.Point(112, 41);
            this.txtDni.Name = "txtDni";
            this.txtDni.Size = new System.Drawing.Size(137, 22);
            this.txtDni.TabIndex = 14;
            this.txtDni.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDni_KeyDown);
            this.txtDni.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDni_Keypress);
            // 
            // cmbDni
            // 
            this.cmbDni.FormattingEnabled = true;
            this.cmbDni.Location = new System.Drawing.Point(45, 40);
            this.cmbDni.Name = "cmbDni";
            this.cmbDni.Size = new System.Drawing.Size(61, 24);
            this.cmbDni.TabIndex = 13;
            // 
            // gbxCotizaciones
            // 
            this.gbxCotizaciones.Controls.Add(this.btnCotizar);
            this.gbxCotizaciones.Controls.Add(this.btnBuscarCotizacion);
            this.gbxCotizaciones.Controls.Add(this.label18);
            this.gbxCotizaciones.Controls.Add(this.btnSubtotal);
            this.gbxCotizaciones.Controls.Add(this.btnBorrarCotizacion);
            this.gbxCotizaciones.Controls.Add(this.btnEditarCotizacion);
            this.gbxCotizaciones.Controls.Add(this.dgvPresupuesto);
            this.gbxCotizaciones.Location = new System.Drawing.Point(51, 278);
            this.gbxCotizaciones.Name = "gbxCotizaciones";
            this.gbxCotizaciones.Size = new System.Drawing.Size(875, 291);
            this.gbxCotizaciones.TabIndex = 18;
            this.gbxCotizaciones.TabStop = false;
            this.gbxCotizaciones.Text = "Cotizaciones";
            // 
            // btnCotizar
            // 
            this.btnCotizar.Location = new System.Drawing.Point(762, 41);
            this.btnCotizar.Name = "btnCotizar";
            this.btnCotizar.Size = new System.Drawing.Size(75, 23);
            this.btnCotizar.TabIndex = 25;
            this.btnCotizar.Text = "Cotizar";
            this.btnCotizar.UseVisualStyleBackColor = true;
            // 
            // btnBuscarCotizacion
            // 
            this.btnBuscarCotizacion.Location = new System.Drawing.Point(389, 243);
            this.btnBuscarCotizacion.Name = "btnBuscarCotizacion";
            this.btnBuscarCotizacion.Size = new System.Drawing.Size(75, 23);
            this.btnBuscarCotizacion.TabIndex = 24;
            this.btnBuscarCotizacion.Text = "Buscar";
            this.btnBuscarCotizacion.UseVisualStyleBackColor = true;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(211, 246);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(169, 16);
            this.label18.TabIndex = 23;
            this.label18.Text = "Cargar Cotizacion existente";
            // 
            // btnSubtotal
            // 
            this.btnSubtotal.Location = new System.Drawing.Point(762, 166);
            this.btnSubtotal.Name = "btnSubtotal";
            this.btnSubtotal.Size = new System.Drawing.Size(75, 23);
            this.btnSubtotal.TabIndex = 22;
            this.btnSubtotal.Text = "Subtotal";
            this.btnSubtotal.UseVisualStyleBackColor = true;
            this.btnSubtotal.Click += new System.EventHandler(this.btnSubtotal_Click);
            // 
            // btnBorrarCotizacion
            // 
            this.btnBorrarCotizacion.Location = new System.Drawing.Point(762, 124);
            this.btnBorrarCotizacion.Name = "btnBorrarCotizacion";
            this.btnBorrarCotizacion.Size = new System.Drawing.Size(75, 23);
            this.btnBorrarCotizacion.TabIndex = 21;
            this.btnBorrarCotizacion.Text = "Borrar";
            this.btnBorrarCotizacion.UseVisualStyleBackColor = true;
            this.btnBorrarCotizacion.Click += new System.EventHandler(this.btnBorrarCotizacion_Click);
            // 
            // btnEditarCotizacion
            // 
            this.btnEditarCotizacion.Location = new System.Drawing.Point(762, 83);
            this.btnEditarCotizacion.Name = "btnEditarCotizacion";
            this.btnEditarCotizacion.Size = new System.Drawing.Size(75, 23);
            this.btnEditarCotizacion.TabIndex = 20;
            this.btnEditarCotizacion.Text = "Editar";
            this.btnEditarCotizacion.UseVisualStyleBackColor = true;
            // 
            // dgvPresupuesto
            // 
            this.dgvPresupuesto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPresupuesto.Location = new System.Drawing.Point(19, 21);
            this.dgvPresupuesto.Name = "dgvPresupuesto";
            this.dgvPresupuesto.RowHeadersWidth = 51;
            this.dgvPresupuesto.RowTemplate.Height = 24;
            this.dgvPresupuesto.Size = new System.Drawing.Size(697, 203);
            this.dgvPresupuesto.TabIndex = 16;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(54, 219);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(158, 16);
            this.label7.TabIndex = 19;
            this.label7.Text = "Descripcion Presupuesto";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(227, 216);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(371, 22);
            this.txtDescripcion.TabIndex = 20;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(76, 609);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 16);
            this.label8.TabIndex = 21;
            this.label8.Text = "Subtotal";
            // 
            // lblValorSubtotal
            // 
            this.lblValorSubtotal.AutoSize = true;
            this.lblValorSubtotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblValorSubtotal.Location = new System.Drawing.Point(179, 609);
            this.lblValorSubtotal.Name = "lblValorSubtotal";
            this.lblValorSubtotal.Size = new System.Drawing.Size(100, 18);
            this.lblValorSubtotal.TabIndex = 22;
            this.lblValorSubtotal.Tag = "";
            this.lblValorSubtotal.Text = "Valor Subtotal\r\n";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(76, 664);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(87, 16);
            this.label9.TabIndex = 23;
            this.label9.Text = "Descuento %";
            // 
            // txtDescuento
            // 
            this.txtDescuento.Location = new System.Drawing.Point(169, 661);
            this.txtDescuento.Name = "txtDescuento";
            this.txtDescuento.Size = new System.Drawing.Size(60, 22);
            this.txtDescuento.TabIndex = 24;
            // 
            // btnDescuento
            // 
            this.btnDescuento.Location = new System.Drawing.Point(253, 660);
            this.btnDescuento.Name = "btnDescuento";
            this.btnDescuento.Size = new System.Drawing.Size(75, 23);
            this.btnDescuento.TabIndex = 25;
            this.btnDescuento.Text = "Aplicar";
            this.btnDescuento.UseVisualStyleBackColor = true;
            this.btnDescuento.Click += new System.EventHandler(this.btnDescuento_Click);
            // 
            // lvlValorPresupuesto
            // 
            this.lvlValorPresupuesto.AutoSize = true;
            this.lvlValorPresupuesto.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lvlValorPresupuesto.Location = new System.Drawing.Point(191, 710);
            this.lvlValorPresupuesto.Name = "lvlValorPresupuesto";
            this.lvlValorPresupuesto.Size = new System.Drawing.Size(147, 20);
            this.lvlValorPresupuesto.TabIndex = 27;
            this.lvlValorPresupuesto.Tag = "";
            this.lvlValorPresupuesto.Text = "Valor Presupuesto";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(68, 713);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(117, 16);
            this.label11.TabIndex = 26;
            this.label11.Text = "Total Presupuesto";
            // 
            // btnVenta
            // 
            this.btnVenta.Location = new System.Drawing.Point(779, 678);
            this.btnVenta.Name = "btnVenta";
            this.btnVenta.Size = new System.Drawing.Size(109, 51);
            this.btnVenta.TabIndex = 21;
            this.btnVenta.Text = "Venta";
            this.btnVenta.UseVisualStyleBackColor = true;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(763, 580);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(136, 16);
            this.label12.TabIndex = 29;
            this.label12.Text = "Finalizar Presupuesto";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(442, 626);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(133, 16);
            this.label14.TabIndex = 32;
            this.label14.Text = "Imprimir Presupuesto";
            // 
            // btnImprimir
            // 
            this.btnImprimir.Location = new System.Drawing.Point(616, 623);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(73, 23);
            this.btnImprimir.TabIndex = 31;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.UseVisualStyleBackColor = true;
            // 
            // dtpVigencia
            // 
            this.dtpVigencia.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpVigencia.Location = new System.Drawing.Point(602, 690);
            this.dtpVigencia.Name = "dtpVigencia";
            this.dtpVigencia.Size = new System.Drawing.Size(98, 22);
            this.dtpVigencia.TabIndex = 33;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(456, 693);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(96, 16);
            this.label15.TabIndex = 34;
            this.label15.Text = "Vigencia hasta";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.label16.Location = new System.Drawing.Point(599, 31);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(108, 17);
            this.label16.TabIndex = 35;
            this.label16.Text = "N° Presupuesto";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.label17.Location = new System.Drawing.Point(762, 31);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(136, 17);
            this.label17.TabIndex = 36;
            this.label17.Text = "Estado Presupuesto";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(779, 609);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(109, 51);
            this.button1.TabIndex = 37;
            this.button1.Text = "Guardar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnBuscarPresupuesto
            // 
            this.btnBuscarPresupuesto.Location = new System.Drawing.Point(813, 216);
            this.btnBuscarPresupuesto.Name = "btnBuscarPresupuesto";
            this.btnBuscarPresupuesto.Size = new System.Drawing.Size(75, 23);
            this.btnBuscarPresupuesto.TabIndex = 39;
            this.btnBuscarPresupuesto.Text = "Buscar";
            this.btnBuscarPresupuesto.UseVisualStyleBackColor = true;
            this.btnBuscarPresupuesto.Click += new System.EventHandler(this.btnBuscarPresupuesto_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(627, 219);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(183, 16);
            this.label10.TabIndex = 38;
            this.label10.Text = "Cargar Presupuesto existente";
            // 
            // frmPresupuestador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(971, 757);
            this.Controls.Add(this.btnBuscarPresupuesto);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.dtpVigencia);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.lvlValorPresupuesto);
            this.Controls.Add(this.btnVenta);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.gbxCotizaciones);
            this.Controls.Add(this.btnDescuento);
            this.Controls.Add(this.gbxCliente);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtDescuento);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lblValorSubtotal);
            this.Controls.Add(this.label9);
            this.Name = "frmPresupuestador";
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
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox gbxCliente;
        private System.Windows.Forms.TextBox txtMailCliente;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTelefonoCliente;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtApellidoCliente;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNombreCliente;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnBuscarDni;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDni;
        private System.Windows.Forms.ComboBox cmbDni;
        private System.Windows.Forms.GroupBox gbxCotizaciones;
        private System.Windows.Forms.DataGridView dgvPresupuesto;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblValorSubtotal;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtDescuento;
        private System.Windows.Forms.Button btnDescuento;
        private System.Windows.Forms.Label lvlValorPresupuesto;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnVenta;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.Button btnSubtotal;
        private System.Windows.Forms.Button btnBorrarCotizacion;
        private System.Windows.Forms.Button btnEditarCotizacion;
        private System.Windows.Forms.DateTimePicker dtpVigencia;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Button btnBuscarCotizacion;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnCotizar;
        private System.Windows.Forms.Button btnBuscarPresupuesto;
        private System.Windows.Forms.Label label10;
    }
}