namespace Vista
{
    partial class frmAdminUserABM
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAdminUserABM));
            this.btnNuevoUsuario = new System.Windows.Forms.Button();
            this.btnGuardarUusario = new System.Windows.Forms.Button();
            this.gpbAbmUsuarios = new System.Windows.Forms.GroupBox();
            this.cmbLocalidad = new System.Windows.Forms.ComboBox();
            this.cmbPartido = new System.Windows.Forms.ComboBox();
            this.cmbTipoDoc = new System.Windows.Forms.ComboBox();
            this.btnEliminarUsuario = new System.Windows.Forms.Button();
            this.cmbRol = new System.Windows.Forms.ComboBox();
            this.lblLocalidad = new System.Windows.Forms.Label();
            this.lblPartido = new System.Windows.Forms.Label();
            this.lblDepart = new System.Windows.Forms.Label();
            this.lblPiso = new System.Windows.Forms.Label();
            this.lblAltura = new System.Windows.Forms.Label();
            this.lblCalle = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblTelefono = new System.Windows.Forms.Label();
            this.lblNroDoc = new System.Windows.Forms.Label();
            this.lblTipoDoc = new System.Windows.Forms.Label();
            this.lblRol = new System.Windows.Forms.Label();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.lblNombres = new System.Windows.Forms.Label();
            this.lblApellidos = new System.Windows.Forms.Label();
            this.txtDepart = new System.Windows.Forms.TextBox();
            this.txtPiso = new System.Windows.Forms.TextBox();
            this.txtNroCalle = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtNroDoc = new System.Windows.Forms.TextBox();
            this.txtNombres = new System.Windows.Forms.TextBox();
            this.txtCalle = new System.Windows.Forms.TextBox();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.txtApellidos = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.pnlBuscar = new System.Windows.Forms.Panel();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.gpbAbmUsuarios.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.pnlBuscar.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnNuevoUsuario
            // 
            this.btnNuevoUsuario.AutoSize = true;
            this.btnNuevoUsuario.BackColor = System.Drawing.Color.White;
            this.btnNuevoUsuario.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnNuevoUsuario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevoUsuario.ForeColor = System.Drawing.Color.Black;
            this.btnNuevoUsuario.Location = new System.Drawing.Point(700, 25);
            this.btnNuevoUsuario.Name = "btnNuevoUsuario";
            this.btnNuevoUsuario.Size = new System.Drawing.Size(153, 35);
            this.btnNuevoUsuario.TabIndex = 15;
            this.btnNuevoUsuario.Text = "Nuevo usuario";
            this.btnNuevoUsuario.UseVisualStyleBackColor = false;
            this.btnNuevoUsuario.Click += new System.EventHandler(this.btnAgregarNuevo_Click);
            // 
            // btnGuardarUusario
            // 
            this.btnGuardarUusario.BackColor = System.Drawing.Color.White;
            this.btnGuardarUusario.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnGuardarUusario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardarUusario.ForeColor = System.Drawing.Color.Black;
            this.btnGuardarUusario.Location = new System.Drawing.Point(700, 91);
            this.btnGuardarUusario.Name = "btnGuardarUusario";
            this.btnGuardarUusario.Size = new System.Drawing.Size(153, 35);
            this.btnGuardarUusario.TabIndex = 16;
            this.btnGuardarUusario.Text = "Guardar";
            this.btnGuardarUusario.UseVisualStyleBackColor = false;
            this.btnGuardarUusario.Click += new System.EventHandler(this.button2_Click);
            // 
            // gpbAbmUsuarios
            // 
            this.gpbAbmUsuarios.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(40)))));
            this.gpbAbmUsuarios.Controls.Add(this.cmbLocalidad);
            this.gpbAbmUsuarios.Controls.Add(this.cmbPartido);
            this.gpbAbmUsuarios.Controls.Add(this.cmbTipoDoc);
            this.gpbAbmUsuarios.Controls.Add(this.btnEliminarUsuario);
            this.gpbAbmUsuarios.Controls.Add(this.cmbRol);
            this.gpbAbmUsuarios.Controls.Add(this.lblLocalidad);
            this.gpbAbmUsuarios.Controls.Add(this.lblPartido);
            this.gpbAbmUsuarios.Controls.Add(this.btnGuardarUusario);
            this.gpbAbmUsuarios.Controls.Add(this.lblDepart);
            this.gpbAbmUsuarios.Controls.Add(this.btnNuevoUsuario);
            this.gpbAbmUsuarios.Controls.Add(this.lblPiso);
            this.gpbAbmUsuarios.Controls.Add(this.lblAltura);
            this.gpbAbmUsuarios.Controls.Add(this.lblCalle);
            this.gpbAbmUsuarios.Controls.Add(this.lblEmail);
            this.gpbAbmUsuarios.Controls.Add(this.lblTelefono);
            this.gpbAbmUsuarios.Controls.Add(this.lblNroDoc);
            this.gpbAbmUsuarios.Controls.Add(this.lblTipoDoc);
            this.gpbAbmUsuarios.Controls.Add(this.lblRol);
            this.gpbAbmUsuarios.Controls.Add(this.lblUsuario);
            this.gpbAbmUsuarios.Controls.Add(this.txtUsuario);
            this.gpbAbmUsuarios.Controls.Add(this.lblNombres);
            this.gpbAbmUsuarios.Controls.Add(this.lblApellidos);
            this.gpbAbmUsuarios.Controls.Add(this.txtDepart);
            this.gpbAbmUsuarios.Controls.Add(this.txtPiso);
            this.gpbAbmUsuarios.Controls.Add(this.txtNroCalle);
            this.gpbAbmUsuarios.Controls.Add(this.txtEmail);
            this.gpbAbmUsuarios.Controls.Add(this.txtNroDoc);
            this.gpbAbmUsuarios.Controls.Add(this.txtNombres);
            this.gpbAbmUsuarios.Controls.Add(this.txtCalle);
            this.gpbAbmUsuarios.Controls.Add(this.txtTelefono);
            this.gpbAbmUsuarios.Controls.Add(this.txtApellidos);
            this.gpbAbmUsuarios.ForeColor = System.Drawing.Color.White;
            this.gpbAbmUsuarios.Location = new System.Drawing.Point(15, 15);
            this.gpbAbmUsuarios.Name = "gpbAbmUsuarios";
            this.gpbAbmUsuarios.Size = new System.Drawing.Size(870, 205);
            this.gpbAbmUsuarios.TabIndex = 3;
            this.gpbAbmUsuarios.TabStop = false;
            this.gpbAbmUsuarios.Text = "Alta y modificación de usuarios";
            // 
            // cmbLocalidad
            // 
            this.cmbLocalidad.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbLocalidad.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbLocalidad.FormattingEnabled = true;
            this.cmbLocalidad.Location = new System.Drawing.Point(433, 165);
            this.cmbLocalidad.Name = "cmbLocalidad";
            this.cmbLocalidad.Size = new System.Drawing.Size(250, 26);
            this.cmbLocalidad.TabIndex = 14;
            // 
            // cmbPartido
            // 
            this.cmbPartido.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbPartido.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbPartido.FormattingEnabled = true;
            this.cmbPartido.Location = new System.Drawing.Point(92, 166);
            this.cmbPartido.Name = "cmbPartido";
            this.cmbPartido.Size = new System.Drawing.Size(250, 26);
            this.cmbPartido.TabIndex = 13;
            this.cmbPartido.SelectedIndexChanged += new System.EventHandler(this.cmbPartido_SelectedIndexChanged);
            // 
            // cmbTipoDoc
            // 
            this.cmbTipoDoc.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbTipoDoc.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbTipoDoc.FormattingEnabled = true;
            this.cmbTipoDoc.Location = new System.Drawing.Point(92, 81);
            this.cmbTipoDoc.Name = "cmbTipoDoc";
            this.cmbTipoDoc.Size = new System.Drawing.Size(250, 26);
            this.cmbTipoDoc.TabIndex = 5;
            // 
            // btnEliminarUsuario
            // 
            this.btnEliminarUsuario.BackColor = System.Drawing.Color.White;
            this.btnEliminarUsuario.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnEliminarUsuario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminarUsuario.ForeColor = System.Drawing.Color.Black;
            this.btnEliminarUsuario.Location = new System.Drawing.Point(700, 156);
            this.btnEliminarUsuario.Name = "btnEliminarUsuario";
            this.btnEliminarUsuario.Size = new System.Drawing.Size(153, 35);
            this.btnEliminarUsuario.TabIndex = 17;
            this.btnEliminarUsuario.Text = "Eliminar usuario";
            this.btnEliminarUsuario.UseVisualStyleBackColor = false;
            this.btnEliminarUsuario.Click += new System.EventHandler(this.btneliminar_Click);
            // 
            // cmbRol
            // 
            this.cmbRol.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbRol.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbRol.FormattingEnabled = true;
            this.cmbRol.Location = new System.Drawing.Point(433, 52);
            this.cmbRol.Name = "cmbRol";
            this.cmbRol.Size = new System.Drawing.Size(250, 26);
            this.cmbRol.TabIndex = 4;
            // 
            // lblLocalidad
            // 
            this.lblLocalidad.Location = new System.Drawing.Point(355, 165);
            this.lblLocalidad.Name = "lblLocalidad";
            this.lblLocalidad.Size = new System.Drawing.Size(72, 25);
            this.lblLocalidad.TabIndex = 33;
            this.lblLocalidad.Text = "Localidad";
            this.lblLocalidad.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblPartido
            // 
            this.lblPartido.Location = new System.Drawing.Point(15, 166);
            this.lblPartido.Name = "lblPartido";
            this.lblPartido.Size = new System.Drawing.Size(72, 25);
            this.lblPartido.TabIndex = 32;
            this.lblPartido.Text = "Partido";
            this.lblPartido.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblDepart
            // 
            this.lblDepart.AutoSize = true;
            this.lblDepart.Location = new System.Drawing.Point(592, 140);
            this.lblDepart.Name = "lblDepart";
            this.lblDepart.Size = new System.Drawing.Size(47, 18);
            this.lblDepart.TabIndex = 31;
            this.lblDepart.Text = "Depto";
            this.lblDepart.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPiso
            // 
            this.lblPiso.AutoSize = true;
            this.lblPiso.Location = new System.Drawing.Point(507, 141);
            this.lblPiso.Name = "lblPiso";
            this.lblPiso.Size = new System.Drawing.Size(37, 18);
            this.lblPiso.TabIndex = 30;
            this.lblPiso.Text = "Piso";
            this.lblPiso.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAltura
            // 
            this.lblAltura.Location = new System.Drawing.Point(355, 137);
            this.lblAltura.Name = "lblAltura";
            this.lblAltura.Size = new System.Drawing.Size(72, 25);
            this.lblAltura.TabIndex = 29;
            this.lblAltura.Text = "Altura";
            this.lblAltura.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblCalle
            // 
            this.lblCalle.Location = new System.Drawing.Point(15, 138);
            this.lblCalle.Name = "lblCalle";
            this.lblCalle.Size = new System.Drawing.Size(72, 25);
            this.lblCalle.TabIndex = 28;
            this.lblCalle.Text = "Calle";
            this.lblCalle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblEmail
            // 
            this.lblEmail.Location = new System.Drawing.Point(355, 109);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(72, 25);
            this.lblEmail.TabIndex = 27;
            this.lblEmail.Text = "E-mail";
            this.lblEmail.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTelefono
            // 
            this.lblTelefono.Location = new System.Drawing.Point(15, 110);
            this.lblTelefono.Name = "lblTelefono";
            this.lblTelefono.Size = new System.Drawing.Size(72, 25);
            this.lblTelefono.TabIndex = 26;
            this.lblTelefono.Text = "Teléfono";
            this.lblTelefono.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblNroDoc
            // 
            this.lblNroDoc.Location = new System.Drawing.Point(355, 81);
            this.lblNroDoc.Name = "lblNroDoc";
            this.lblNroDoc.Size = new System.Drawing.Size(72, 25);
            this.lblNroDoc.TabIndex = 25;
            this.lblNroDoc.Text = "Nro Doc";
            this.lblNroDoc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTipoDoc
            // 
            this.lblTipoDoc.Location = new System.Drawing.Point(15, 81);
            this.lblTipoDoc.Name = "lblTipoDoc";
            this.lblTipoDoc.Size = new System.Drawing.Size(72, 25);
            this.lblTipoDoc.TabIndex = 24;
            this.lblTipoDoc.Text = "Tipo Doc";
            this.lblTipoDoc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblRol
            // 
            this.lblRol.Location = new System.Drawing.Point(355, 52);
            this.lblRol.Name = "lblRol";
            this.lblRol.Size = new System.Drawing.Size(72, 25);
            this.lblRol.TabIndex = 23;
            this.lblRol.Text = "Rol";
            this.lblRol.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblUsuario
            // 
            this.lblUsuario.Location = new System.Drawing.Point(15, 53);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(72, 25);
            this.lblUsuario.TabIndex = 22;
            this.lblUsuario.Text = "Usuario";
            this.lblUsuario.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtUsuario
            // 
            this.txtUsuario.Location = new System.Drawing.Point(92, 53);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(250, 25);
            this.txtUsuario.TabIndex = 3;
            // 
            // lblNombres
            // 
            this.lblNombres.Location = new System.Drawing.Point(355, 25);
            this.lblNombres.Name = "lblNombres";
            this.lblNombres.Size = new System.Drawing.Size(72, 25);
            this.lblNombres.TabIndex = 19;
            this.lblNombres.Text = "Nombres";
            this.lblNombres.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblApellidos
            // 
            this.lblApellidos.Location = new System.Drawing.Point(15, 25);
            this.lblApellidos.Name = "lblApellidos";
            this.lblApellidos.Size = new System.Drawing.Size(72, 25);
            this.lblApellidos.TabIndex = 19;
            this.lblApellidos.Text = "Apellidos";
            this.lblApellidos.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDepart
            // 
            this.txtDepart.Location = new System.Drawing.Point(643, 137);
            this.txtDepart.Name = "txtDepart";
            this.txtDepart.Size = new System.Drawing.Size(40, 25);
            this.txtDepart.TabIndex = 12;
            // 
            // txtPiso
            // 
            this.txtPiso.Location = new System.Drawing.Point(548, 137);
            this.txtPiso.Name = "txtPiso";
            this.txtPiso.Size = new System.Drawing.Size(40, 25);
            this.txtPiso.TabIndex = 11;
            // 
            // txtNroCalle
            // 
            this.txtNroCalle.Location = new System.Drawing.Point(433, 137);
            this.txtNroCalle.Name = "txtNroCalle";
            this.txtNroCalle.Size = new System.Drawing.Size(70, 25);
            this.txtNroCalle.TabIndex = 10;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(433, 109);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(250, 25);
            this.txtEmail.TabIndex = 8;
            // 
            // txtNroDoc
            // 
            this.txtNroDoc.Location = new System.Drawing.Point(433, 81);
            this.txtNroDoc.Name = "txtNroDoc";
            this.txtNroDoc.Size = new System.Drawing.Size(250, 25);
            this.txtNroDoc.TabIndex = 6;
            // 
            // txtNombres
            // 
            this.txtNombres.Location = new System.Drawing.Point(433, 25);
            this.txtNombres.Name = "txtNombres";
            this.txtNombres.Size = new System.Drawing.Size(250, 25);
            this.txtNombres.TabIndex = 2;
            // 
            // txtCalle
            // 
            this.txtCalle.Location = new System.Drawing.Point(92, 138);
            this.txtCalle.Name = "txtCalle";
            this.txtCalle.Size = new System.Drawing.Size(250, 25);
            this.txtCalle.TabIndex = 9;
            // 
            // txtTelefono
            // 
            this.txtTelefono.Location = new System.Drawing.Point(92, 110);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(250, 25);
            this.txtTelefono.TabIndex = 7;
            // 
            // txtApellidos
            // 
            this.txtApellidos.Location = new System.Drawing.Point(92, 25);
            this.txtApellidos.Name = "txtApellidos";
            this.txtApellidos.Size = new System.Drawing.Size(250, 25);
            this.txtApellidos.TabIndex = 1;
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(15, 290);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(870, 295);
            this.dataGridView1.TabIndex = 6;
            // 
            // pnlBuscar
            // 
            this.pnlBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(40)))));
            this.pnlBuscar.Controls.Add(this.txtBuscar);
            this.pnlBuscar.Controls.Add(this.btnBuscar);
            this.pnlBuscar.Font = new System.Drawing.Font("Bahnschrift", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlBuscar.ForeColor = System.Drawing.Color.White;
            this.pnlBuscar.Location = new System.Drawing.Point(15, 235);
            this.pnlBuscar.Name = "pnlBuscar";
            this.pnlBuscar.Size = new System.Drawing.Size(870, 40);
            this.pnlBuscar.TabIndex = 32;
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
            // frmAdminUserABM
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(900, 600);
            this.Controls.Add(this.pnlBuscar);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.gpbAbmUsuarios);
            this.Font = new System.Drawing.Font("Bahnschrift", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmAdminUserABM";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmAdministrador";
            this.Load += new System.EventHandler(this.frmAdministrador_Load);
            this.Shown += new System.EventHandler(this.frmAdminUserABM_Shown);
            this.gpbAbmUsuarios.ResumeLayout(false);
            this.gpbAbmUsuarios.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.pnlBuscar.ResumeLayout(false);
            this.pnlBuscar.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnNuevoUsuario;
        private System.Windows.Forms.Button btnGuardarUusario;
        private System.Windows.Forms.GroupBox gpbAbmUsuarios;
        private System.Windows.Forms.TextBox txtNroCalle;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtNroDoc;
        private System.Windows.Forms.TextBox txtNombres;
        private System.Windows.Forms.TextBox txtCalle;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.TextBox txtApellidos;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox txtDepart;
        private System.Windows.Forms.TextBox txtPiso;
        private System.Windows.Forms.Button btnEliminarUsuario;
        private System.Windows.Forms.Label lblNombres;
        private System.Windows.Forms.Label lblApellidos;
        private System.Windows.Forms.Label lblLocalidad;
        private System.Windows.Forms.Label lblPartido;
        private System.Windows.Forms.Label lblDepart;
        private System.Windows.Forms.Label lblPiso;
        private System.Windows.Forms.Label lblAltura;
        private System.Windows.Forms.Label lblCalle;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblTelefono;
        private System.Windows.Forms.Label lblNroDoc;
        private System.Windows.Forms.Label lblTipoDoc;
        private System.Windows.Forms.Label lblRol;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.ComboBox cmbPartido;
        private System.Windows.Forms.ComboBox cmbTipoDoc;
        private System.Windows.Forms.ComboBox cmbRol;
        private System.Windows.Forms.ComboBox cmbLocalidad;
        private System.Windows.Forms.Panel pnlBuscar;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Button btnBuscar;
    }
}