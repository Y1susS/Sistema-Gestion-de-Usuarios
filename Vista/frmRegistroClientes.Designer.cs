namespace Vista
{
    partial class frmRegistroClientes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRegistroClientes));

            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblLocalidad = new System.Windows.Forms.Label();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.cmbTipoDoc = new System.Windows.Forms.ComboBox();
            this.lblPartidocli = new System.Windows.Forms.Label();
            this.btnModificarcliente = new System.Windows.Forms.Button();
            this.cmbLocalidad = new System.Windows.Forms.ComboBox();
            this.btnAgregarnuevocliente = new System.Windows.Forms.Button();
            this.lblDepart = new System.Windows.Forms.Label();
            this.cmbPartido = new System.Windows.Forms.ComboBox();
            this.lblPiso = new System.Windows.Forms.Label();
            this.txtderpatamento = new System.Windows.Forms.TextBox();
            this.lblalturacli = new System.Windows.Forms.Label();
            this.txtpiso = new System.Windows.Forms.TextBox();
            this.lblCallecli = new System.Windows.Forms.Label();
            this.txtnumerocalle = new System.Windows.Forms.TextBox();
            this.lblEmailcli = new System.Windows.Forms.Label();
            this.txtemail = new System.Windows.Forms.TextBox();
            this.lblTelefonocli = new System.Windows.Forms.Label();
            this.txtnumerodocumento = new System.Windows.Forms.TextBox();
            this.lblNroDoccli = new System.Windows.Forms.Label();
            this.txtnombre = new System.Windows.Forms.TextBox();
            this.lblTipoDoccli = new System.Windows.Forms.Label();
            this.txtcalle = new System.Windows.Forms.TextBox();
            this.txttelefono = new System.Windows.Forms.TextBox();
            this.txtapellido = new System.Windows.Forms.TextBox();
            this.lblNombrescli = new System.Windows.Forms.Label();
            this.lblApellidoscli = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.pnlBuscar = new System.Windows.Forms.Panel();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.gpbregcli.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.pnlBuscar.SuspendLayout();
            this.SuspendLayout();
            // 

            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(40)))));
            this.groupBox1.Controls.Add(this.lblLocalidad);
            this.groupBox1.Controls.Add(this.btnEliminar);
            this.groupBox1.Controls.Add(this.cmbLocalidad);
            this.groupBox1.Controls.Add(this.cmbTipoDoc);
            this.groupBox1.Controls.Add(this.lblPartido);
            this.groupBox1.Controls.Add(this.btnModificar);
            this.groupBox1.Controls.Add(this.btnAgregar);
            this.groupBox1.Controls.Add(this.lblDepart);
            this.groupBox1.Controls.Add(this.cmbPartido);
            this.groupBox1.Controls.Add(this.lblPiso);
            this.groupBox1.Controls.Add(this.txtderpatamento);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.txtpiso);
            this.groupBox1.Controls.Add(this.lblCalle);
            this.groupBox1.Controls.Add(this.txtnumerocalle);
            this.groupBox1.Controls.Add(this.lblEmail);
            this.groupBox1.Controls.Add(this.txtemail);
            this.groupBox1.Controls.Add(this.lblTelefono);
            this.groupBox1.Controls.Add(this.txtnumerodocumento);
            this.groupBox1.Controls.Add(this.lblNroDoc);
            this.groupBox1.Controls.Add(this.txtnombre);
            this.groupBox1.Controls.Add(this.lblTipoDoc);
            this.groupBox1.Controls.Add(this.txtcalle);
            this.groupBox1.Controls.Add(this.txttelefono);
            this.groupBox1.Controls.Add(this.txtapellido);
            this.groupBox1.Controls.Add(this.lblNombres);
            this.groupBox1.Controls.Add(this.lblApellidos);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(15, 15);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(870, 175);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Registro y Modificación de clientes";
            // 
            // lblLocalidad
            // 
            this.lblLocalidad.Location = new System.Drawing.Point(355, 142);
            this.lblLocalidad.Name = "lblLocalidad";
            this.lblLocalidad.Size = new System.Drawing.Size(72, 25);
            this.lblLocalidad.TabIndex = 47;
            this.lblLocalidad.Text = "Localidad";
            this.lblLocalidad.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.White;
            this.btnEliminar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.ForeColor = System.Drawing.Color.Black;
            this.btnEliminar.Location = new System.Drawing.Point(700, 129);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(153, 35);
            this.btnEliminar.TabIndex = 15;
            this.btnEliminar.Text = "Eliminar cliente";
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // cmbTipoDoc
            // 
            this.cmbTipoDoc.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbTipoDoc.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbTipoDoc.FormattingEnabled = true;
            this.cmbTipoDoc.Location = new System.Drawing.Point(93, 54);
            this.cmbTipoDoc.Name = "cmbTipoDoc";
            this.cmbTipoDoc.Size = new System.Drawing.Size(250, 26);
            this.cmbTipoDoc.TabIndex = 3;
            // 

            // lblPartido
            // 
            this.lblPartido.Location = new System.Drawing.Point(15, 139);
            this.lblPartido.Name = "lblPartido";
            this.lblPartido.Size = new System.Drawing.Size(72, 25);
            this.lblPartido.TabIndex = 46;
            this.lblPartido.Text = "Partido";
            this.lblPartido.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnModificar
            // 
            this.btnModificar.BackColor = System.Drawing.Color.White;
            this.btnModificar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnModificar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModificar.ForeColor = System.Drawing.Color.Black;
            this.btnModificar.Location = new System.Drawing.Point(700, 78);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(153, 35);
            this.btnModificar.TabIndex = 14;
            this.btnModificar.Text = "Guardar";
            this.btnModificar.UseVisualStyleBackColor = false;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // cmbLocalidad
            // 
            this.cmbLocalidad.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbLocalidad.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbLocalidad.FormattingEnabled = true;
            this.cmbLocalidad.Location = new System.Drawing.Point(433, 138);
            this.cmbLocalidad.Name = "cmbLocalidad";
            this.cmbLocalidad.Size = new System.Drawing.Size(250, 26);
            this.cmbLocalidad.TabIndex = 12;
            // 
            // btnAgregarnuevocliente
            // 

            this.btnAgregar.BackColor = System.Drawing.Color.White;
            this.btnAgregar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregar.ForeColor = System.Drawing.Color.Black;
            this.btnAgregar.Location = new System.Drawing.Point(700, 26);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(153, 35);
            this.btnAgregar.TabIndex = 13;
            this.btnAgregar.Text = "Nuevo cliente";
            this.btnAgregar.UseVisualStyleBackColor = false;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // lblDepart
            // 
            this.lblDepart.AutoSize = true;
            this.lblDepart.Location = new System.Drawing.Point(592, 114);
            this.lblDepart.Name = "lblDepart";
            this.lblDepart.Size = new System.Drawing.Size(47, 18);
            this.lblDepart.TabIndex = 45;
            this.lblDepart.Text = "Depto";
            // 
            // cmbPartido
            // 
            this.cmbPartido.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbPartido.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbPartido.FormattingEnabled = true;
            this.cmbPartido.Location = new System.Drawing.Point(93, 139);
            this.cmbPartido.Name = "cmbPartido";
            this.cmbPartido.Size = new System.Drawing.Size(250, 26);
            this.cmbPartido.TabIndex = 11;
            // 
            // lblPiso
            // 
            this.lblPiso.AutoSize = true;
            this.lblPiso.Location = new System.Drawing.Point(507, 114);
            this.lblPiso.Name = "lblPiso";
            this.lblPiso.Size = new System.Drawing.Size(37, 18);
            this.lblPiso.TabIndex = 44;
            this.lblPiso.Text = "Piso";
            // 
            // txtderpatamento
            // 
            this.txtderpatamento.Location = new System.Drawing.Point(643, 110);
            this.txtderpatamento.Name = "txtderpatamento";
            this.txtderpatamento.Size = new System.Drawing.Size(40, 25);
            this.txtderpatamento.TabIndex = 10;
            // 
            // lblalturacli
            // 

            this.label10.Location = new System.Drawing.Point(355, 111);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(72, 25);
            this.label10.TabIndex = 43;
            this.label10.Text = "Altura";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtpiso
            // 
            this.txtpiso.Location = new System.Drawing.Point(548, 110);
            this.txtpiso.Name = "txtpiso";
            this.txtpiso.Size = new System.Drawing.Size(40, 25);
            this.txtpiso.TabIndex = 9;
            // 
            // lblCallecli
            // 

            this.lblCalle.Location = new System.Drawing.Point(15, 111);
            this.lblCalle.Name = "lblCalle";
            this.lblCalle.Size = new System.Drawing.Size(72, 25);
            this.lblCalle.TabIndex = 42;
            this.lblCalle.Text = "Calle";
            this.lblCalle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtnumerocalle
            // 
            this.txtnumerocalle.Location = new System.Drawing.Point(433, 110);
            this.txtnumerocalle.Name = "txtnumerocalle";
            this.txtnumerocalle.Size = new System.Drawing.Size(70, 25);
            this.txtnumerocalle.TabIndex = 8;
            // 
            // lblEmailcli
            // 

            this.lblEmail.Location = new System.Drawing.Point(355, 84);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(72, 25);
            this.lblEmail.TabIndex = 41;
            this.lblEmail.Text = "E-mail";
            this.lblEmail.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtemail
            // 
            this.txtemail.Location = new System.Drawing.Point(433, 82);
            this.txtemail.Name = "txtemail";
            this.txtemail.Size = new System.Drawing.Size(250, 25);
            this.txtemail.TabIndex = 6;
            // 
            // lblTelefonocli
            // 

            this.lblTelefono.Location = new System.Drawing.Point(15, 83);
            this.lblTelefono.Name = "lblTelefono";
            this.lblTelefono.Size = new System.Drawing.Size(72, 25);
            this.lblTelefono.TabIndex = 40;
            this.lblTelefono.Text = "Telefono";
            this.lblTelefono.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtnumerodocumento
            // 
            this.txtnumerodocumento.Location = new System.Drawing.Point(433, 54);
            this.txtnumerodocumento.Name = "txtnumerodocumento";
            this.txtnumerodocumento.Size = new System.Drawing.Size(250, 25);
            this.txtnumerodocumento.TabIndex = 4;
            // 
            // lblNroDoccli
            // 

            this.lblNroDoc.Location = new System.Drawing.Point(355, 54);
            this.lblNroDoc.Name = "lblNroDoc";
            this.lblNroDoc.Size = new System.Drawing.Size(72, 25);
            this.lblNroDoc.TabIndex = 39;
            this.lblNroDoc.Text = "Nro Doc";
            this.lblNroDoc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtnombre
            // 
            this.txtnombre.Location = new System.Drawing.Point(433, 26);
            this.txtnombre.Name = "txtnombre";
            this.txtnombre.Size = new System.Drawing.Size(250, 25);
            this.txtnombre.TabIndex = 2;
            // 
            // lblTipoDoccli
            // 

            this.lblTipoDoc.Location = new System.Drawing.Point(15, 54);
            this.lblTipoDoc.Name = "lblTipoDoc";
            this.lblTipoDoc.Size = new System.Drawing.Size(72, 25);
            this.lblTipoDoc.TabIndex = 38;
            this.lblTipoDoc.Text = "Tipo Doc";
            this.lblTipoDoc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtcalle
            // 
            this.txtcalle.Location = new System.Drawing.Point(93, 111);
            this.txtcalle.Name = "txtcalle";
            this.txtcalle.Size = new System.Drawing.Size(250, 25);
            this.txtcalle.TabIndex = 7;
            // 
            // txttelefono
            // 
            this.txttelefono.Location = new System.Drawing.Point(93, 83);
            this.txttelefono.Name = "txttelefono";
            this.txttelefono.Size = new System.Drawing.Size(250, 25);
            this.txttelefono.TabIndex = 5;
            // 
            // txtapellido
            // 
            this.txtapellido.Location = new System.Drawing.Point(93, 26);
            this.txtapellido.Name = "txtapellido";
            this.txtapellido.Size = new System.Drawing.Size(250, 25);
            this.txtapellido.TabIndex = 1;
            // 
            // lblNombrescli
            // 

            this.lblNombres.Location = new System.Drawing.Point(355, 26);
            this.lblNombres.Name = "lblNombres";
            this.lblNombres.Size = new System.Drawing.Size(72, 25);
            this.lblNombres.TabIndex = 34;
            this.lblNombres.Text = "Nombres";
            this.lblNombres.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblApellidoscli
            // 

            this.lblApellidos.Location = new System.Drawing.Point(15, 26);
            this.lblApellidos.Name = "lblApellidos";
            this.lblApellidos.Size = new System.Drawing.Size(72, 25);
            this.lblApellidos.TabIndex = 35;
            this.lblApellidos.Text = "Apellidos";
            this.lblApellidos.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView1.Location = new System.Drawing.Point(15, 260);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(870, 325);
            this.dataGridView1.TabIndex = 12;
            // 
            // pnlBuscar
            // 
            this.pnlBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(40)))));
            this.pnlBuscar.Controls.Add(this.txtBuscar);
            this.pnlBuscar.Controls.Add(this.btnBuscar);
            this.pnlBuscar.Font = new System.Drawing.Font("Bahnschrift", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlBuscar.ForeColor = System.Drawing.Color.White;
            this.pnlBuscar.Location = new System.Drawing.Point(15, 205);
            this.pnlBuscar.Name = "pnlBuscar";
            this.pnlBuscar.Size = new System.Drawing.Size(870, 40);
            this.pnlBuscar.TabIndex = 33;
            this.pnlBuscar.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlBuscar_Paint);
            // 
            // txtBuscar
            // 
            this.txtBuscar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBuscar.Font = new System.Drawing.Font("Bahnschrift", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscar.ForeColor = System.Drawing.Color.Black;
            this.txtBuscar.Location = new System.Drawing.Point(310, 6);
            this.txtBuscar.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(250, 28);
            this.txtBuscar.TabIndex = 29;
            this.txtBuscar.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.Color.White;
            this.btnBuscar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBuscar.BackgroundImage")));
            this.btnBuscar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBuscar.FlatAppearance.BorderSize = 0;
            this.btnBuscar.Font = new System.Drawing.Font("Bahnschrift", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.ForeColor = System.Drawing.Color.Transparent;
            this.btnBuscar.Location = new System.Drawing.Point(567, 6);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(28, 28);
            this.btnBuscar.TabIndex = 30;
            this.btnBuscar.UseVisualStyleBackColor = false;
            // 
            // frmRegistroClientes
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImage = global::Vista.Properties.Resources.WoodenPlankCyan;
            this.ClientSize = new System.Drawing.Size(900, 600);
            this.Controls.Add(this.pnlBuscar);
            this.Controls.Add(this.gpbregcli);
            this.Controls.Add(this.dataGridView1);
            this.Font = new System.Drawing.Font("Bahnschrift", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmRegistroClientes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.frmRegistroClientes_Load);
            this.Shown += new System.EventHandler(this.frmRegistroClientes_Shown);
            this.gpbregcli.ResumeLayout(false);
            this.gpbregcli.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.pnlBuscar.ResumeLayout(false);
            this.pnlBuscar.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox gpbregcli;
        private System.Windows.Forms.TextBox txtderpatamento;
        private System.Windows.Forms.TextBox txtpiso;
        private System.Windows.Forms.TextBox txtnumerocalle;
        private System.Windows.Forms.TextBox txtemail;
        private System.Windows.Forms.TextBox txtnumerodocumento;
        private System.Windows.Forms.TextBox txtnombre;
        private System.Windows.Forms.TextBox txtcalle;
        private System.Windows.Forms.TextBox txttelefono;
        private System.Windows.Forms.TextBox txtapellido;
        private System.Windows.Forms.Button btnModificarcliente;
        private System.Windows.Forms.Button btnAgregarnuevocliente;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnEliminarcliente;
        private System.Windows.Forms.ComboBox cmbPartido;
        private System.Windows.Forms.ComboBox cmbLocalidad;
        private System.Windows.Forms.ComboBox cmbTipoDoc;
        private System.Windows.Forms.Label lblLocalidadcli;
        private System.Windows.Forms.Label lblPartidocli;
        private System.Windows.Forms.Label lblDepart;
        private System.Windows.Forms.Label lblPiso;

        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblCalle;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblTelefono;
        private System.Windows.Forms.Label lblNroDoc;
        private System.Windows.Forms.Label lblTipoDoc;
        private System.Windows.Forms.Label lblNombres;
        private System.Windows.Forms.Label lblApellidos;
        private System.Windows.Forms.Panel pnlBuscar;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Button btnBuscar;
    }
}