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
            this.cmbTipoDoc = new System.Windows.Forms.ComboBox();
            this.cmbLocalidad = new System.Windows.Forms.ComboBox();
            this.cmbPartido = new System.Windows.Forms.ComboBox();
            this.txtderpatamento = new System.Windows.Forms.TextBox();
            this.txtpiso = new System.Windows.Forms.TextBox();
            this.txtnumerocalle = new System.Windows.Forms.TextBox();
            this.txtemail = new System.Windows.Forms.TextBox();
            this.txtnumerodocumento = new System.Windows.Forms.TextBox();
            this.txtnombre = new System.Windows.Forms.TextBox();
            this.txtcalle = new System.Windows.Forms.TextBox();
            this.txttelefono = new System.Windows.Forms.TextBox();
            this.txtapellido = new System.Windows.Forms.TextBox();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.pnlBorde = new System.Windows.Forms.Panel();
            this.pctMinimize = new System.Windows.Forms.PictureBox();
            this.pctClose = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
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
            this.lblNombres = new System.Windows.Forms.Label();
            this.lblApellidos = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.pnlBorde.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctMinimize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctClose)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(40)))));
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.lblLocalidad);
            this.groupBox1.Controls.Add(this.cmbTipoDoc);
            this.groupBox1.Controls.Add(this.lblPartido);
            this.groupBox1.Controls.Add(this.cmbLocalidad);
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
            this.groupBox1.Location = new System.Drawing.Point(25, 50);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(700, 175);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Registro y Modificación de clientes";
            // 
            // cmbTipoDoc
            // 
            this.cmbTipoDoc.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbTipoDoc.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbTipoDoc.FormattingEnabled = true;
            this.cmbTipoDoc.Location = new System.Drawing.Point(97, 50);
            this.cmbTipoDoc.Name = "cmbTipoDoc";
            this.cmbTipoDoc.Size = new System.Drawing.Size(250, 26);
            this.cmbTipoDoc.TabIndex = 16;
            // 
            // cmbLocalidad
            // 
            this.cmbLocalidad.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbLocalidad.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbLocalidad.FormattingEnabled = true;
            this.cmbLocalidad.Location = new System.Drawing.Point(434, 135);
            this.cmbLocalidad.Name = "cmbLocalidad";
            this.cmbLocalidad.Size = new System.Drawing.Size(250, 26);
            this.cmbLocalidad.TabIndex = 15;
            // 
            // cmbPartido
            // 
            this.cmbPartido.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbPartido.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbPartido.FormattingEnabled = true;
            this.cmbPartido.Location = new System.Drawing.Point(97, 135);
            this.cmbPartido.Name = "cmbPartido";
            this.cmbPartido.Size = new System.Drawing.Size(250, 26);
            this.cmbPartido.TabIndex = 14;
            // 
            // txtderpatamento
            // 
            this.txtderpatamento.Location = new System.Drawing.Point(644, 107);
            this.txtderpatamento.Name = "txtderpatamento";
            this.txtderpatamento.Size = new System.Drawing.Size(40, 25);
            this.txtderpatamento.TabIndex = 10;
            // 
            // txtpiso
            // 
            this.txtpiso.Location = new System.Drawing.Point(549, 107);
            this.txtpiso.Name = "txtpiso";
            this.txtpiso.Size = new System.Drawing.Size(40, 25);
            this.txtpiso.TabIndex = 9;
            // 
            // txtnumerocalle
            // 
            this.txtnumerocalle.Location = new System.Drawing.Point(434, 107);
            this.txtnumerocalle.Name = "txtnumerocalle";
            this.txtnumerocalle.Size = new System.Drawing.Size(70, 25);
            this.txtnumerocalle.TabIndex = 8;
            // 
            // txtemail
            // 
            this.txtemail.Location = new System.Drawing.Point(434, 78);
            this.txtemail.Name = "txtemail";
            this.txtemail.Size = new System.Drawing.Size(250, 25);
            this.txtemail.TabIndex = 6;
            // 
            // txtnumerodocumento
            // 
            this.txtnumerodocumento.Location = new System.Drawing.Point(434, 50);
            this.txtnumerodocumento.Name = "txtnumerodocumento";
            this.txtnumerodocumento.Size = new System.Drawing.Size(250, 25);
            this.txtnumerodocumento.TabIndex = 4;
            // 
            // txtnombre
            // 
            this.txtnombre.Location = new System.Drawing.Point(434, 22);
            this.txtnombre.Name = "txtnombre";
            this.txtnombre.Size = new System.Drawing.Size(250, 25);
            this.txtnombre.TabIndex = 2;
            // 
            // txtcalle
            // 
            this.txtcalle.Location = new System.Drawing.Point(97, 107);
            this.txtcalle.Name = "txtcalle";
            this.txtcalle.Size = new System.Drawing.Size(250, 25);
            this.txtcalle.TabIndex = 7;
            // 
            // txttelefono
            // 
            this.txttelefono.Location = new System.Drawing.Point(97, 79);
            this.txttelefono.Name = "txttelefono";
            this.txttelefono.Size = new System.Drawing.Size(250, 25);
            this.txttelefono.TabIndex = 5;
            // 
            // txtapellido
            // 
            this.txtapellido.Location = new System.Drawing.Point(97, 22);
            this.txtapellido.Name = "txtapellido";
            this.txtapellido.Size = new System.Drawing.Size(250, 25);
            this.txtapellido.TabIndex = 1;
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new System.Drawing.Point(305, 228);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(150, 28);
            this.btnModificar.TabIndex = 14;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(25, 228);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(150, 28);
            this.btnAgregar.TabIndex = 13;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(25, 260);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(700, 250);
            this.dataGridView1.TabIndex = 12;
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(575, 228);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(150, 28);
            this.btnEliminar.TabIndex = 25;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // pnlBorde
            // 
            this.pnlBorde.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(40)))));
            this.pnlBorde.Controls.Add(this.pctMinimize);
            this.pnlBorde.Controls.Add(this.pctClose);
            this.pnlBorde.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBorde.Location = new System.Drawing.Point(0, 0);
            this.pnlBorde.Name = "pnlBorde";
            this.pnlBorde.Size = new System.Drawing.Size(750, 40);
            this.pnlBorde.TabIndex = 26;
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
            this.pctMinimize.Click += new System.EventHandler(this.pctMinimize_Click_1);
            // 
            // pctClose
            // 
            this.pctClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(40)))));
            this.pctClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pctClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.pctClose.Image = ((System.Drawing.Image)(resources.GetObject("pctClose.Image")));
            this.pctClose.Location = new System.Drawing.Point(710, 0);
            this.pctClose.Name = "pctClose";
            this.pctClose.Size = new System.Drawing.Size(40, 40);
            this.pctClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pctClose.TabIndex = 20;
            this.pctClose.TabStop = false;
            this.pctClose.Click += new System.EventHandler(this.pctClose_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(40)))));
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 519);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(750, 20);
            this.panel2.TabIndex = 27;
            // 
            // lblLocalidad
            // 
            this.lblLocalidad.AutoSize = true;
            this.lblLocalidad.Location = new System.Drawing.Point(352, 138);
            this.lblLocalidad.Name = "lblLocalidad";
            this.lblLocalidad.Size = new System.Drawing.Size(72, 18);
            this.lblLocalidad.TabIndex = 47;
            this.lblLocalidad.Text = "Localidad";
            // 
            // lblPartido
            // 
            this.lblPartido.AutoSize = true;
            this.lblPartido.Location = new System.Drawing.Point(15, 138);
            this.lblPartido.Name = "lblPartido";
            this.lblPartido.Size = new System.Drawing.Size(56, 18);
            this.lblPartido.TabIndex = 46;
            this.lblPartido.Text = "Partido";
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
            // lblPiso
            // 
            this.lblPiso.AutoSize = true;
            this.lblPiso.Location = new System.Drawing.Point(514, 137);
            this.lblPiso.Name = "lblPiso";
            this.lblPiso.Size = new System.Drawing.Size(37, 18);
            this.lblPiso.TabIndex = 44;
            this.lblPiso.Text = "Piso";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(352, 110);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(49, 18);
            this.label10.TabIndex = 43;
            this.label10.Text = "Altura";
            // 
            // lblCalle
            // 
            this.lblCalle.AutoSize = true;
            this.lblCalle.Location = new System.Drawing.Point(15, 110);
            this.lblCalle.Name = "lblCalle";
            this.lblCalle.Size = new System.Drawing.Size(41, 18);
            this.lblCalle.TabIndex = 42;
            this.lblCalle.Text = "Calle";
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(352, 82);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(53, 18);
            this.lblEmail.TabIndex = 41;
            this.lblEmail.Text = "E-mail";
            // 
            // lblTelefono
            // 
            this.lblTelefono.AutoSize = true;
            this.lblTelefono.Location = new System.Drawing.Point(15, 82);
            this.lblTelefono.Name = "lblTelefono";
            this.lblTelefono.Size = new System.Drawing.Size(63, 18);
            this.lblTelefono.TabIndex = 40;
            this.lblTelefono.Text = "Telefono";
            // 
            // lblNroDoc
            // 
            this.lblNroDoc.AutoSize = true;
            this.lblNroDoc.Location = new System.Drawing.Point(352, 53);
            this.lblNroDoc.Name = "lblNroDoc";
            this.lblNroDoc.Size = new System.Drawing.Size(62, 18);
            this.lblNroDoc.TabIndex = 39;
            this.lblNroDoc.Text = "Nro Doc";
            // 
            // lblTipoDoc
            // 
            this.lblTipoDoc.AutoSize = true;
            this.lblTipoDoc.Location = new System.Drawing.Point(15, 52);
            this.lblTipoDoc.Name = "lblTipoDoc";
            this.lblTipoDoc.Size = new System.Drawing.Size(64, 18);
            this.lblTipoDoc.TabIndex = 38;
            this.lblTipoDoc.Text = "Tipo Doc";
            // 
            // lblNombres
            // 
            this.lblNombres.AutoSize = true;
            this.lblNombres.Location = new System.Drawing.Point(352, 25);
            this.lblNombres.Name = "lblNombres";
            this.lblNombres.Size = new System.Drawing.Size(70, 18);
            this.lblNombres.TabIndex = 34;
            this.lblNombres.Text = "Nombres";
            // 
            // lblApellidos
            // 
            this.lblApellidos.AutoSize = true;
            this.lblApellidos.Location = new System.Drawing.Point(15, 26);
            this.lblApellidos.Name = "lblApellidos";
            this.lblApellidos.Size = new System.Drawing.Size(70, 18);
            this.lblApellidos.TabIndex = 35;
            this.lblApellidos.Text = "Apellidos";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(593, 110);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 18);
            this.label1.TabIndex = 49;
            this.label1.Text = "Depto";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(508, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 18);
            this.label2.TabIndex = 48;
            this.label2.Text = "Piso";
            // 
            // frmRegistroClientes
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImage = global::Vista.Properties.Resources.WoodenPlankCyan;
            this.ClientSize = new System.Drawing.Size(750, 539);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pnlBorde);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnAgregar);
            this.Font = new System.Drawing.Font("Bahnschrift", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmRegistroClientes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.frmRegistroClientes_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.pnlBorde.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pctMinimize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctClose)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtderpatamento;
        private System.Windows.Forms.TextBox txtpiso;
        private System.Windows.Forms.TextBox txtnumerocalle;
        private System.Windows.Forms.TextBox txtemail;
        private System.Windows.Forms.TextBox txtnumerodocumento;
        private System.Windows.Forms.TextBox txtnombre;
        private System.Windows.Forms.TextBox txtcalle;
        private System.Windows.Forms.TextBox txttelefono;
        private System.Windows.Forms.TextBox txtapellido;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.ComboBox cmbPartido;
        private System.Windows.Forms.ComboBox cmbLocalidad;
        private System.Windows.Forms.ComboBox cmbTipoDoc;
        private System.Windows.Forms.Panel pnlBorde;
        private System.Windows.Forms.PictureBox pctMinimize;
        private System.Windows.Forms.PictureBox pctClose;
        private System.Windows.Forms.Panel panel2;
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
        private System.Windows.Forms.Label lblNombres;
        private System.Windows.Forms.Label lblApellidos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}