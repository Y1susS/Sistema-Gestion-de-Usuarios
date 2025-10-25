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
            this.gpbregcli = new System.Windows.Forms.GroupBox();
            this.lbldtocli = new System.Windows.Forms.Label();
            this.lblpisocli = new System.Windows.Forms.Label();
            this.lblLocalidadcli = new System.Windows.Forms.Label();
            this.btnEliminarcliente = new System.Windows.Forms.Button();
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
            // gpbregcli
            // 
            this.gpbregcli.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(40)))));
            this.gpbregcli.Controls.Add(this.lbldtocli);
            this.gpbregcli.Controls.Add(this.lblpisocli);
            this.gpbregcli.Controls.Add(this.lblLocalidadcli);
            this.gpbregcli.Controls.Add(this.btnEliminarcliente);
            this.gpbregcli.Controls.Add(this.cmbTipoDoc);
            this.gpbregcli.Controls.Add(this.lblPartidocli);
            this.gpbregcli.Controls.Add(this.btnModificarcliente);
            this.gpbregcli.Controls.Add(this.cmbLocalidad);
            this.gpbregcli.Controls.Add(this.btnAgregarnuevocliente);
            this.gpbregcli.Controls.Add(this.lblDepart);
            this.gpbregcli.Controls.Add(this.cmbPartido);
            this.gpbregcli.Controls.Add(this.lblPiso);
            this.gpbregcli.Controls.Add(this.txtderpatamento);
            this.gpbregcli.Controls.Add(this.lblalturacli);
            this.gpbregcli.Controls.Add(this.txtpiso);
            this.gpbregcli.Controls.Add(this.lblCallecli);
            this.gpbregcli.Controls.Add(this.txtnumerocalle);
            this.gpbregcli.Controls.Add(this.lblEmailcli);
            this.gpbregcli.Controls.Add(this.txtemail);
            this.gpbregcli.Controls.Add(this.lblTelefonocli);
            this.gpbregcli.Controls.Add(this.txtnumerodocumento);
            this.gpbregcli.Controls.Add(this.lblNroDoccli);
            this.gpbregcli.Controls.Add(this.txtnombre);
            this.gpbregcli.Controls.Add(this.lblTipoDoccli);
            this.gpbregcli.Controls.Add(this.txtcalle);
            this.gpbregcli.Controls.Add(this.txttelefono);
            this.gpbregcli.Controls.Add(this.txtapellido);
            this.gpbregcli.Controls.Add(this.lblNombrescli);
            this.gpbregcli.Controls.Add(this.lblApellidoscli);
            this.gpbregcli.ForeColor = System.Drawing.Color.White;
            this.gpbregcli.Location = new System.Drawing.Point(15, 15);
            this.gpbregcli.Name = "gpbregcli";
            this.gpbregcli.Size = new System.Drawing.Size(830, 175);
            this.gpbregcli.TabIndex = 4;
            this.gpbregcli.TabStop = false;
            this.gpbregcli.Text = "Registro y Modificación de clientes";
            // 
            // lbldtocli
            // 
            this.lbldtocli.AutoSize = true;
            this.lbldtocli.Location = new System.Drawing.Point(588, 110);
            this.lbldtocli.Name = "lbldtocli";
            this.lbldtocli.Size = new System.Drawing.Size(47, 18);
            this.lbldtocli.TabIndex = 49;
            this.lbldtocli.Text = "Depto";
            // 
            // lblpisocli
            // 
            this.lblpisocli.AutoSize = true;
            this.lblpisocli.Location = new System.Drawing.Point(503, 110);
            this.lblpisocli.Name = "lblpisocli";
            this.lblpisocli.Size = new System.Drawing.Size(37, 18);
            this.lblpisocli.TabIndex = 48;
            this.lblpisocli.Text = "Piso";
            // 
            // lblLocalidadcli
            // 
            this.lblLocalidadcli.AutoSize = true;
            this.lblLocalidadcli.Location = new System.Drawing.Point(347, 138);
            this.lblLocalidadcli.Name = "lblLocalidadcli";
            this.lblLocalidadcli.Size = new System.Drawing.Size(72, 18);
            this.lblLocalidadcli.TabIndex = 47;
            this.lblLocalidadcli.Text = "Localidad";
            // 
            // btnEliminarcliente
            // 
            this.btnEliminarcliente.BackColor = System.Drawing.Color.White;
            this.btnEliminarcliente.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnEliminarcliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminarcliente.ForeColor = System.Drawing.Color.Black;
            this.btnEliminarcliente.Location = new System.Drawing.Point(689, 129);
            this.btnEliminarcliente.Name = "btnEliminarcliente";
            this.btnEliminarcliente.Size = new System.Drawing.Size(130, 30);
            this.btnEliminarcliente.TabIndex = 15;
            this.btnEliminarcliente.Text = "Eliminar cliente";
            this.btnEliminarcliente.UseVisualStyleBackColor = false;
            this.btnEliminarcliente.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // cmbTipoDoc
            // 
            this.cmbTipoDoc.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbTipoDoc.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbTipoDoc.FormattingEnabled = true;
            this.cmbTipoDoc.Location = new System.Drawing.Point(92, 50);
            this.cmbTipoDoc.Name = "cmbTipoDoc";
            this.cmbTipoDoc.Size = new System.Drawing.Size(250, 26);
            this.cmbTipoDoc.TabIndex = 3;
            // 
            // lblPartidocli
            // 
            this.lblPartidocli.AutoSize = true;
            this.lblPartidocli.Location = new System.Drawing.Point(10, 138);
            this.lblPartidocli.Name = "lblPartidocli";
            this.lblPartidocli.Size = new System.Drawing.Size(56, 18);
            this.lblPartidocli.TabIndex = 46;
            this.lblPartidocli.Text = "Partido";
            // 
            // btnModificarcliente
            // 
            this.btnModificarcliente.BackColor = System.Drawing.Color.White;
            this.btnModificarcliente.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnModificarcliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModificarcliente.ForeColor = System.Drawing.Color.Black;
            this.btnModificarcliente.Location = new System.Drawing.Point(689, 76);
            this.btnModificarcliente.Name = "btnModificarcliente";
            this.btnModificarcliente.Size = new System.Drawing.Size(130, 30);
            this.btnModificarcliente.TabIndex = 14;
            this.btnModificarcliente.Text = "Guardar";
            this.btnModificarcliente.UseVisualStyleBackColor = false;
            this.btnModificarcliente.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // cmbLocalidad
            // 
            this.cmbLocalidad.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbLocalidad.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbLocalidad.FormattingEnabled = true;
            this.cmbLocalidad.Location = new System.Drawing.Point(429, 135);
            this.cmbLocalidad.Name = "cmbLocalidad";
            this.cmbLocalidad.Size = new System.Drawing.Size(250, 26);
            this.cmbLocalidad.TabIndex = 12;
            // 
            // btnAgregarnuevocliente
            // 
            this.btnAgregarnuevocliente.BackColor = System.Drawing.Color.White;
            this.btnAgregarnuevocliente.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnAgregarnuevocliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarnuevocliente.ForeColor = System.Drawing.Color.Black;
            this.btnAgregarnuevocliente.Location = new System.Drawing.Point(689, 23);
            this.btnAgregarnuevocliente.Name = "btnAgregarnuevocliente";
            this.btnAgregarnuevocliente.Size = new System.Drawing.Size(130, 30);
            this.btnAgregarnuevocliente.TabIndex = 13;
            this.btnAgregarnuevocliente.Text = "Nuevo cliente";
            this.btnAgregarnuevocliente.UseVisualStyleBackColor = false;
            this.btnAgregarnuevocliente.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // lblDepart
            // 
            this.lblDepart.AutoSize = true;
            this.lblDepart.Location = new System.Drawing.Point(599, 137);
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
            this.cmbPartido.Location = new System.Drawing.Point(92, 135);
            this.cmbPartido.Name = "cmbPartido";
            this.cmbPartido.Size = new System.Drawing.Size(250, 26);
            this.cmbPartido.TabIndex = 11;
            // 
            // lblPiso
            // 
            this.lblPiso.AutoSize = true;
            this.lblPiso.Location = new System.Drawing.Point(514, 137);
            this.lblPiso.Name = "lblPiso";
            this.lblPiso.Size = new System.Drawing.Size(37, 18);
            this.lblPiso.TabIndex = 44;
            this.lblPiso.Text = "Piso";
            // 
            // txtderpatamento
            // 
            this.txtderpatamento.Location = new System.Drawing.Point(639, 107);
            this.txtderpatamento.Name = "txtderpatamento";
            this.txtderpatamento.Size = new System.Drawing.Size(40, 25);
            this.txtderpatamento.TabIndex = 10;
            // 
            // lblalturacli
            // 
            this.lblalturacli.AutoSize = true;
            this.lblalturacli.Location = new System.Drawing.Point(347, 110);
            this.lblalturacli.Name = "lblalturacli";
            this.lblalturacli.Size = new System.Drawing.Size(49, 18);
            this.lblalturacli.TabIndex = 43;
            this.lblalturacli.Text = "Altura";
            // 
            // txtpiso
            // 
            this.txtpiso.Location = new System.Drawing.Point(544, 107);
            this.txtpiso.Name = "txtpiso";
            this.txtpiso.Size = new System.Drawing.Size(40, 25);
            this.txtpiso.TabIndex = 9;
            // 
            // lblCallecli
            // 
            this.lblCallecli.AutoSize = true;
            this.lblCallecli.Location = new System.Drawing.Point(10, 110);
            this.lblCallecli.Name = "lblCallecli";
            this.lblCallecli.Size = new System.Drawing.Size(41, 18);
            this.lblCallecli.TabIndex = 42;
            this.lblCallecli.Text = "Calle";
            // 
            // txtnumerocalle
            // 
            this.txtnumerocalle.Location = new System.Drawing.Point(429, 107);
            this.txtnumerocalle.Name = "txtnumerocalle";
            this.txtnumerocalle.Size = new System.Drawing.Size(70, 25);
            this.txtnumerocalle.TabIndex = 8;
            // 
            // lblEmailcli
            // 
            this.lblEmailcli.AutoSize = true;
            this.lblEmailcli.Location = new System.Drawing.Point(347, 82);
            this.lblEmailcli.Name = "lblEmailcli";
            this.lblEmailcli.Size = new System.Drawing.Size(53, 18);
            this.lblEmailcli.TabIndex = 41;
            this.lblEmailcli.Text = "E-mail";
            // 
            // txtemail
            // 
            this.txtemail.Location = new System.Drawing.Point(429, 78);
            this.txtemail.Name = "txtemail";
            this.txtemail.Size = new System.Drawing.Size(250, 25);
            this.txtemail.TabIndex = 6;
            // 
            // lblTelefonocli
            // 
            this.lblTelefonocli.AutoSize = true;
            this.lblTelefonocli.Location = new System.Drawing.Point(10, 82);
            this.lblTelefonocli.Name = "lblTelefonocli";
            this.lblTelefonocli.Size = new System.Drawing.Size(63, 18);
            this.lblTelefonocli.TabIndex = 40;
            this.lblTelefonocli.Text = "Telefono";
            // 
            // txtnumerodocumento
            // 
            this.txtnumerodocumento.Location = new System.Drawing.Point(429, 50);
            this.txtnumerodocumento.Name = "txtnumerodocumento";
            this.txtnumerodocumento.Size = new System.Drawing.Size(250, 25);
            this.txtnumerodocumento.TabIndex = 4;
            // 
            // lblNroDoccli
            // 
            this.lblNroDoccli.AutoSize = true;
            this.lblNroDoccli.Location = new System.Drawing.Point(347, 53);
            this.lblNroDoccli.Name = "lblNroDoccli";
            this.lblNroDoccli.Size = new System.Drawing.Size(62, 18);
            this.lblNroDoccli.TabIndex = 39;
            this.lblNroDoccli.Text = "Nro Doc";
            // 
            // txtnombre
            // 
            this.txtnombre.Location = new System.Drawing.Point(429, 22);
            this.txtnombre.Name = "txtnombre";
            this.txtnombre.Size = new System.Drawing.Size(250, 25);
            this.txtnombre.TabIndex = 2;
            // 
            // lblTipoDoccli
            // 
            this.lblTipoDoccli.AutoSize = true;
            this.lblTipoDoccli.Location = new System.Drawing.Point(10, 52);
            this.lblTipoDoccli.Name = "lblTipoDoccli";
            this.lblTipoDoccli.Size = new System.Drawing.Size(64, 18);
            this.lblTipoDoccli.TabIndex = 38;
            this.lblTipoDoccli.Text = "Tipo Doc";
            // 
            // txtcalle
            // 
            this.txtcalle.Location = new System.Drawing.Point(92, 107);
            this.txtcalle.Name = "txtcalle";
            this.txtcalle.Size = new System.Drawing.Size(250, 25);
            this.txtcalle.TabIndex = 7;
            // 
            // txttelefono
            // 
            this.txttelefono.Location = new System.Drawing.Point(92, 79);
            this.txttelefono.Name = "txttelefono";
            this.txttelefono.Size = new System.Drawing.Size(250, 25);
            this.txttelefono.TabIndex = 5;
            // 
            // txtapellido
            // 
            this.txtapellido.Location = new System.Drawing.Point(92, 22);
            this.txtapellido.Name = "txtapellido";
            this.txtapellido.Size = new System.Drawing.Size(250, 25);
            this.txtapellido.TabIndex = 1;
            // 
            // lblNombrescli
            // 
            this.lblNombrescli.AutoSize = true;
            this.lblNombrescli.Location = new System.Drawing.Point(347, 25);
            this.lblNombrescli.Name = "lblNombrescli";
            this.lblNombrescli.Size = new System.Drawing.Size(70, 18);
            this.lblNombrescli.TabIndex = 34;
            this.lblNombrescli.Text = "Nombres";
            // 
            // lblApellidoscli
            // 
            this.lblApellidoscli.AutoSize = true;
            this.lblApellidoscli.Location = new System.Drawing.Point(10, 26);
            this.lblApellidoscli.Name = "lblApellidoscli";
            this.lblApellidoscli.Size = new System.Drawing.Size(70, 18);
            this.lblApellidoscli.TabIndex = 35;
            this.lblApellidoscli.Text = "Apellidos";
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
            this.dataGridView1.Size = new System.Drawing.Size(830, 300);
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
            this.pnlBuscar.Size = new System.Drawing.Size(830, 40);
            this.pnlBuscar.TabIndex = 33;
            this.pnlBuscar.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlBuscar_Paint);
            // 
            // txtBuscar
            // 
            this.txtBuscar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBuscar.Font = new System.Drawing.Font("Bahnschrift", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscar.ForeColor = System.Drawing.Color.Black;
            this.txtBuscar.Location = new System.Drawing.Point(290, 6);
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
            this.btnBuscar.Location = new System.Drawing.Point(547, 6);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(28, 28);
            this.btnBuscar.TabIndex = 30;
            this.btnBuscar.UseVisualStyleBackColor = false;
            // 
            // frmRegistroClientes
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImage = global::Vista.Properties.Resources.WoodenPlankCyan;
            this.ClientSize = new System.Drawing.Size(860, 575);
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
        private System.Windows.Forms.Label lblalturacli;
        private System.Windows.Forms.Label lblCallecli;
        private System.Windows.Forms.Label lblEmailcli;
        private System.Windows.Forms.Label lblTelefonocli;
        private System.Windows.Forms.Label lblNroDoccli;
        private System.Windows.Forms.Label lblTipoDoccli;
        private System.Windows.Forms.Label lblNombrescli;
        private System.Windows.Forms.Label lblApellidoscli;
        private System.Windows.Forms.Label lbldtocli;
        private System.Windows.Forms.Label lblpisocli;
        private System.Windows.Forms.Panel pnlBuscar;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Button btnBuscar;
    }
}