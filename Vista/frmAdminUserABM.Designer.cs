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
            this.btnAgregarNuevo = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbLocalidad = new System.Windows.Forms.ComboBox();
            this.cmbPartido = new System.Windows.Forms.ComboBox();
            this.cmbTipoDoc = new System.Windows.Forms.ComboBox();
            this.btneliminar = new System.Windows.Forms.Button();
            this.cmbRol = new System.Windows.Forms.ComboBox();
            this.lblLocalidad = new System.Windows.Forms.Label();
            this.lblPartido = new System.Windows.Forms.Label();
            this.lblDepart = new System.Windows.Forms.Label();
            this.lblPiso = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
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
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.pnlBuscar.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAgregarNuevo
            // 
            this.btnAgregarNuevo.AutoSize = true;
            this.btnAgregarNuevo.BackColor = System.Drawing.Color.White;
            this.btnAgregarNuevo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnAgregarNuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarNuevo.ForeColor = System.Drawing.Color.Black;
            this.btnAgregarNuevo.Location = new System.Drawing.Point(689, 23);
            this.btnAgregarNuevo.Name = "btnAgregarNuevo";
            this.btnAgregarNuevo.Size = new System.Drawing.Size(130, 35);
            this.btnAgregarNuevo.TabIndex = 15;
            this.btnAgregarNuevo.Text = "Nuevo usuario";
            this.btnAgregarNuevo.UseVisualStyleBackColor = false;
            this.btnAgregarNuevo.Click += new System.EventHandler(this.btnAgregarNuevo_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.White;
            this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.ForeColor = System.Drawing.Color.Black;
            this.button2.Location = new System.Drawing.Point(689, 88);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(130, 35);
            this.button2.TabIndex = 16;
            this.button2.Text = "Guardar";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(40)))));
            this.groupBox1.Controls.Add(this.cmbLocalidad);
            this.groupBox1.Controls.Add(this.cmbPartido);
            this.groupBox1.Controls.Add(this.cmbTipoDoc);
            this.groupBox1.Controls.Add(this.btneliminar);
            this.groupBox1.Controls.Add(this.cmbRol);
            this.groupBox1.Controls.Add(this.lblLocalidad);
            this.groupBox1.Controls.Add(this.lblPartido);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.lblDepart);
            this.groupBox1.Controls.Add(this.btnAgregarNuevo);
            this.groupBox1.Controls.Add(this.lblPiso);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.lblCalle);
            this.groupBox1.Controls.Add(this.lblEmail);
            this.groupBox1.Controls.Add(this.lblTelefono);
            this.groupBox1.Controls.Add(this.lblNroDoc);
            this.groupBox1.Controls.Add(this.lblTipoDoc);
            this.groupBox1.Controls.Add(this.lblRol);
            this.groupBox1.Controls.Add(this.lblUsuario);
            this.groupBox1.Controls.Add(this.txtUsuario);
            this.groupBox1.Controls.Add(this.lblNombres);
            this.groupBox1.Controls.Add(this.lblApellidos);
            this.groupBox1.Controls.Add(this.txtDepart);
            this.groupBox1.Controls.Add(this.txtPiso);
            this.groupBox1.Controls.Add(this.txtNroCalle);
            this.groupBox1.Controls.Add(this.txtEmail);
            this.groupBox1.Controls.Add(this.txtNroDoc);
            this.groupBox1.Controls.Add(this.txtNombres);
            this.groupBox1.Controls.Add(this.txtCalle);
            this.groupBox1.Controls.Add(this.txtTelefono);
            this.groupBox1.Controls.Add(this.txtApellidos);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(15, 15);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(830, 200);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Alta y modificación de usuarios";
            // 
            // cmbLocalidad
            // 
            this.cmbLocalidad.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbLocalidad.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbLocalidad.FormattingEnabled = true;
            this.cmbLocalidad.Location = new System.Drawing.Point(429, 162);
            this.cmbLocalidad.Name = "cmbLocalidad";
            this.cmbLocalidad.Size = new System.Drawing.Size(250, 26);
            this.cmbLocalidad.TabIndex = 14;
            // 
            // cmbPartido
            // 
            this.cmbPartido.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbPartido.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbPartido.FormattingEnabled = true;
            this.cmbPartido.Location = new System.Drawing.Point(92, 162);
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
            this.cmbTipoDoc.Location = new System.Drawing.Point(92, 78);
            this.cmbTipoDoc.Name = "cmbTipoDoc";
            this.cmbTipoDoc.Size = new System.Drawing.Size(250, 26);
            this.cmbTipoDoc.TabIndex = 5;
            // 
            // btneliminar
            // 
            this.btneliminar.BackColor = System.Drawing.Color.White;
            this.btneliminar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btneliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btneliminar.ForeColor = System.Drawing.Color.Black;
            this.btneliminar.Location = new System.Drawing.Point(689, 153);
            this.btneliminar.Name = "btneliminar";
            this.btneliminar.Size = new System.Drawing.Size(130, 35);
            this.btneliminar.TabIndex = 17;
            this.btneliminar.Text = "Eliminar usuario";
            this.btneliminar.UseVisualStyleBackColor = false;
            this.btneliminar.Click += new System.EventHandler(this.btneliminar_Click);
            // 
            // cmbRol
            // 
            this.cmbRol.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbRol.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbRol.FormattingEnabled = true;
            this.cmbRol.Location = new System.Drawing.Point(429, 50);
            this.cmbRol.Name = "cmbRol";
            this.cmbRol.Size = new System.Drawing.Size(250, 26);
            this.cmbRol.TabIndex = 4;
            // 
            // lblLocalidad
            // 
            this.lblLocalidad.AutoSize = true;
            this.lblLocalidad.Location = new System.Drawing.Point(347, 166);
            this.lblLocalidad.Name = "lblLocalidad";
            this.lblLocalidad.Size = new System.Drawing.Size(72, 18);
            this.lblLocalidad.TabIndex = 33;
            this.lblLocalidad.Text = "Localidad";
            // 
            // lblPartido
            // 
            this.lblPartido.AutoSize = true;
            this.lblPartido.Location = new System.Drawing.Point(10, 166);
            this.lblPartido.Name = "lblPartido";
            this.lblPartido.Size = new System.Drawing.Size(56, 18);
            this.lblPartido.TabIndex = 32;
            this.lblPartido.Text = "Partido";
            // 
            // lblDepart
            // 
            this.lblDepart.AutoSize = true;
            this.lblDepart.Location = new System.Drawing.Point(588, 138);
            this.lblDepart.Name = "lblDepart";
            this.lblDepart.Size = new System.Drawing.Size(47, 18);
            this.lblDepart.TabIndex = 31;
            this.lblDepart.Text = "Depto";
            // 
            // lblPiso
            // 
            this.lblPiso.AutoSize = true;
            this.lblPiso.Location = new System.Drawing.Point(503, 138);
            this.lblPiso.Name = "lblPiso";
            this.lblPiso.Size = new System.Drawing.Size(37, 18);
            this.lblPiso.TabIndex = 30;
            this.lblPiso.Text = "Piso";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(347, 138);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(49, 18);
            this.label10.TabIndex = 29;
            this.label10.Text = "Altura";
            // 
            // lblCalle
            // 
            this.lblCalle.AutoSize = true;
            this.lblCalle.Location = new System.Drawing.Point(10, 138);
            this.lblCalle.Name = "lblCalle";
            this.lblCalle.Size = new System.Drawing.Size(41, 18);
            this.lblCalle.TabIndex = 28;
            this.lblCalle.Text = "Calle";
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(347, 110);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(53, 18);
            this.lblEmail.TabIndex = 27;
            this.lblEmail.Text = "E-mail";
            // 
            // lblTelefono
            // 
            this.lblTelefono.AutoSize = true;
            this.lblTelefono.Location = new System.Drawing.Point(10, 110);
            this.lblTelefono.Name = "lblTelefono";
            this.lblTelefono.Size = new System.Drawing.Size(63, 18);
            this.lblTelefono.TabIndex = 26;
            this.lblTelefono.Text = "Telefono";
            // 
            // lblNroDoc
            // 
            this.lblNroDoc.AutoSize = true;
            this.lblNroDoc.Location = new System.Drawing.Point(347, 82);
            this.lblNroDoc.Name = "lblNroDoc";
            this.lblNroDoc.Size = new System.Drawing.Size(62, 18);
            this.lblNroDoc.TabIndex = 25;
            this.lblNroDoc.Text = "Nro Doc";
            // 
            // lblTipoDoc
            // 
            this.lblTipoDoc.AutoSize = true;
            this.lblTipoDoc.Location = new System.Drawing.Point(10, 82);
            this.lblTipoDoc.Name = "lblTipoDoc";
            this.lblTipoDoc.Size = new System.Drawing.Size(64, 18);
            this.lblTipoDoc.TabIndex = 24;
            this.lblTipoDoc.Text = "Tipo Doc";
            // 
            // lblRol
            // 
            this.lblRol.AutoSize = true;
            this.lblRol.Location = new System.Drawing.Point(347, 53);
            this.lblRol.Name = "lblRol";
            this.lblRol.Size = new System.Drawing.Size(30, 18);
            this.lblRol.TabIndex = 23;
            this.lblRol.Text = "Rol";
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Location = new System.Drawing.Point(10, 52);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(60, 18);
            this.lblUsuario.TabIndex = 22;
            this.lblUsuario.Text = "Usuario";
            // 
            // txtUsuario
            // 
            this.txtUsuario.Location = new System.Drawing.Point(92, 50);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(250, 25);
            this.txtUsuario.TabIndex = 3;
            // 
            // lblNombres
            // 
            this.lblNombres.AutoSize = true;
            this.lblNombres.Location = new System.Drawing.Point(347, 25);
            this.lblNombres.Name = "lblNombres";
            this.lblNombres.Size = new System.Drawing.Size(70, 18);
            this.lblNombres.TabIndex = 19;
            this.lblNombres.Text = "Nombres";
            // 
            // lblApellidos
            // 
            this.lblApellidos.AutoSize = true;
            this.lblApellidos.Location = new System.Drawing.Point(10, 26);
            this.lblApellidos.Name = "lblApellidos";
            this.lblApellidos.Size = new System.Drawing.Size(70, 18);
            this.lblApellidos.TabIndex = 19;
            this.lblApellidos.Text = "Apellidos";
            // 
            // txtDepart
            // 
            this.txtDepart.Location = new System.Drawing.Point(639, 135);
            this.txtDepart.Name = "txtDepart";
            this.txtDepart.Size = new System.Drawing.Size(40, 25);
            this.txtDepart.TabIndex = 12;
            // 
            // txtPiso
            // 
            this.txtPiso.Location = new System.Drawing.Point(544, 135);
            this.txtPiso.Name = "txtPiso";
            this.txtPiso.Size = new System.Drawing.Size(40, 25);
            this.txtPiso.TabIndex = 11;
            // 
            // txtNroCalle
            // 
            this.txtNroCalle.Location = new System.Drawing.Point(429, 135);
            this.txtNroCalle.Name = "txtNroCalle";
            this.txtNroCalle.Size = new System.Drawing.Size(70, 25);
            this.txtNroCalle.TabIndex = 10;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(429, 107);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(250, 25);
            this.txtEmail.TabIndex = 8;
            // 
            // txtNroDoc
            // 
            this.txtNroDoc.Location = new System.Drawing.Point(429, 79);
            this.txtNroDoc.Name = "txtNroDoc";
            this.txtNroDoc.Size = new System.Drawing.Size(250, 25);
            this.txtNroDoc.TabIndex = 6;
            // 
            // txtNombres
            // 
            this.txtNombres.Location = new System.Drawing.Point(429, 22);
            this.txtNombres.Name = "txtNombres";
            this.txtNombres.Size = new System.Drawing.Size(250, 25);
            this.txtNombres.TabIndex = 2;
            // 
            // txtCalle
            // 
            this.txtCalle.Location = new System.Drawing.Point(92, 135);
            this.txtCalle.Name = "txtCalle";
            this.txtCalle.Size = new System.Drawing.Size(250, 25);
            this.txtCalle.TabIndex = 9;
            // 
            // txtTelefono
            // 
            this.txtTelefono.Location = new System.Drawing.Point(92, 107);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(250, 25);
            this.txtTelefono.TabIndex = 7;
            // 
            // txtApellidos
            // 
            this.txtApellidos.Location = new System.Drawing.Point(92, 22);
            this.txtApellidos.Name = "txtApellidos";
            this.txtApellidos.Size = new System.Drawing.Size(250, 25);
            this.txtApellidos.TabIndex = 1;
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(15, 285);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(830, 300);
            this.dataGridView1.TabIndex = 6;
            // 
            // pnlBuscar
            // 
            this.pnlBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(40)))));
            this.pnlBuscar.Controls.Add(this.txtBuscar);
            this.pnlBuscar.Controls.Add(this.btnBuscar);
            this.pnlBuscar.Font = new System.Drawing.Font("Bahnschrift", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlBuscar.ForeColor = System.Drawing.Color.White;
            this.pnlBuscar.Location = new System.Drawing.Point(15, 230);
            this.pnlBuscar.Name = "pnlBuscar";
            this.pnlBuscar.Size = new System.Drawing.Size(830, 40);
            this.pnlBuscar.TabIndex = 32;
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
            // frmAdminUserABM
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(860, 600);
            this.Controls.Add(this.pnlBuscar);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Bahnschrift", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmAdminUserABM";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmAdministrador";
            this.Load += new System.EventHandler(this.frmAdministrador_Load);
            this.Shown += new System.EventHandler(this.frmAdminUserABM_Shown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.pnlBuscar.ResumeLayout(false);
            this.pnlBuscar.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAgregarNuevo;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox1;
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
        private System.Windows.Forms.Button btneliminar;
        private System.Windows.Forms.Label lblNombres;
        private System.Windows.Forms.Label lblApellidos;
        private System.Windows.Forms.Label lblLocalidad;
        private System.Windows.Forms.Label lblPartido;
        private System.Windows.Forms.Label lblDepart;
        private System.Windows.Forms.Label lblPiso;
        private System.Windows.Forms.Label label10;
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