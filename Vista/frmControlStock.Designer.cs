namespace Vista
{
    partial class frmControlStock
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmControlStock));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.cmbTipoMaterial = new System.Windows.Forms.ComboBox();
            this.cmbMaterial = new System.Windows.Forms.ComboBox();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbxActivo = new System.Windows.Forms.CheckBox();
            this.btnNuevoMaterial = new System.Windows.Forms.Button();
            this.btnGestion = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.txtUnidad = new System.Windows.Forms.TextBox();
            this.txtPrecioUnitario = new System.Windows.Forms.TextBox();
            this.txtStockMinimo = new System.Windows.Forms.TextBox();
            this.txtStockActual = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblTipoMaterial = new System.Windows.Forms.Label();
            this.lblMaterial = new System.Windows.Forms.Label();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.lblMensajeBoton = new System.Windows.Forms.Label();
            this.pnlOpciones = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pnlBorde = new System.Windows.Forms.Panel();
            this.pctLogo = new System.Windows.Forms.PictureBox();
            this.pctMinimize = new System.Windows.Forms.PictureBox();
            this.pctClose = new System.Windows.Forms.PictureBox();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.pnlBuscar = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.pnlOpciones.SuspendLayout();
            this.pnlBorde.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctMinimize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctClose)).BeginInit();
            this.pnlBuscar.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(10, 281);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(840, 294);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // cmbTipoMaterial
            // 
            this.cmbTipoMaterial.BackColor = System.Drawing.Color.White;
            this.cmbTipoMaterial.ForeColor = System.Drawing.Color.Black;
            this.cmbTipoMaterial.FormattingEnabled = true;
            this.cmbTipoMaterial.Location = new System.Drawing.Point(125, 40);
            this.cmbTipoMaterial.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.cmbTipoMaterial.Name = "cmbTipoMaterial";
            this.cmbTipoMaterial.Size = new System.Drawing.Size(200, 26);
            this.cmbTipoMaterial.TabIndex = 1;
            this.cmbTipoMaterial.SelectedIndexChanged += new System.EventHandler(this.cmbTipoMaterial_SelectedIndexChanged);
            // 
            // cmbMaterial
            // 
            this.cmbMaterial.BackColor = System.Drawing.Color.White;
            this.cmbMaterial.ForeColor = System.Drawing.Color.Black;
            this.cmbMaterial.FormattingEnabled = true;
            this.cmbMaterial.Location = new System.Drawing.Point(125, 70);
            this.cmbMaterial.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.cmbMaterial.Name = "cmbMaterial";
            this.cmbMaterial.Size = new System.Drawing.Size(200, 26);
            this.cmbMaterial.TabIndex = 2;
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.BackColor = System.Drawing.Color.White;
            this.txtDescripcion.ForeColor = System.Drawing.Color.Black;
            this.txtDescripcion.Location = new System.Drawing.Point(125, 100);
            this.txtDescripcion.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(250, 25);
            this.txtDescripcion.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(10, 130);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 26);
            this.label1.TabIndex = 4;
            this.label1.Text = "Activo";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbxActivo
            // 
            this.cbxActivo.Location = new System.Drawing.Point(125, 138);
            this.cbxActivo.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.cbxActivo.Name = "cbxActivo";
            this.cbxActivo.Size = new System.Drawing.Size(15, 15);
            this.cbxActivo.TabIndex = 5;
            this.cbxActivo.UseVisualStyleBackColor = true;
            // 
            // btnNuevoMaterial
            // 
            this.btnNuevoMaterial.BackColor = System.Drawing.Color.White;
            this.btnNuevoMaterial.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevoMaterial.ForeColor = System.Drawing.Color.Black;
            this.btnNuevoMaterial.Location = new System.Drawing.Point(673, 39);
            this.btnNuevoMaterial.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.btnNuevoMaterial.Name = "btnNuevoMaterial";
            this.btnNuevoMaterial.Size = new System.Drawing.Size(150, 30);
            this.btnNuevoMaterial.TabIndex = 8;
            this.btnNuevoMaterial.Text = "Cargar";
            this.btnNuevoMaterial.UseVisualStyleBackColor = false;
            this.btnNuevoMaterial.Click += new System.EventHandler(this.btnNuevoMaterial_Click);
            // 
            // btnGestion
            // 
            this.btnGestion.BackColor = System.Drawing.Color.White;
            this.btnGestion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGestion.ForeColor = System.Drawing.Color.Black;
            this.btnGestion.Location = new System.Drawing.Point(673, 82);
            this.btnGestion.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.btnGestion.Name = "btnGestion";
            this.btnGestion.Size = new System.Drawing.Size(150, 30);
            this.btnGestion.TabIndex = 9;
            this.btnGestion.Text = "Modificar";
            this.btnGestion.UseVisualStyleBackColor = false;
            this.btnGestion.Click += new System.EventHandler(this.btnGestion_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.White;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.ForeColor = System.Drawing.Color.Black;
            this.btnGuardar.Location = new System.Drawing.Point(673, 126);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(150, 30);
            this.btnGuardar.TabIndex = 10;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // txtUnidad
            // 
            this.txtUnidad.BackColor = System.Drawing.Color.White;
            this.txtUnidad.ForeColor = System.Drawing.Color.Black;
            this.txtUnidad.Location = new System.Drawing.Point(505, 40);
            this.txtUnidad.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.txtUnidad.Name = "txtUnidad";
            this.txtUnidad.Size = new System.Drawing.Size(150, 25);
            this.txtUnidad.TabIndex = 13;
            // 
            // txtPrecioUnitario
            // 
            this.txtPrecioUnitario.BackColor = System.Drawing.Color.White;
            this.txtPrecioUnitario.ForeColor = System.Drawing.Color.Black;
            this.txtPrecioUnitario.Location = new System.Drawing.Point(505, 70);
            this.txtPrecioUnitario.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.txtPrecioUnitario.Name = "txtPrecioUnitario";
            this.txtPrecioUnitario.Size = new System.Drawing.Size(150, 25);
            this.txtPrecioUnitario.TabIndex = 14;
            this.txtPrecioUnitario.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPrecioUnitario_KeyPress);
            // 
            // txtStockMinimo
            // 
            this.txtStockMinimo.BackColor = System.Drawing.Color.White;
            this.txtStockMinimo.ForeColor = System.Drawing.Color.Black;
            this.txtStockMinimo.Location = new System.Drawing.Point(505, 130);
            this.txtStockMinimo.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.txtStockMinimo.Name = "txtStockMinimo";
            this.txtStockMinimo.Size = new System.Drawing.Size(150, 25);
            this.txtStockMinimo.TabIndex = 16;
            this.txtStockMinimo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtStockMinimo_KeyPress);
            // 
            // txtStockActual
            // 
            this.txtStockActual.BackColor = System.Drawing.Color.White;
            this.txtStockActual.ForeColor = System.Drawing.Color.Black;
            this.txtStockActual.Location = new System.Drawing.Point(505, 100);
            this.txtStockActual.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.txtStockActual.Name = "txtStockActual";
            this.txtStockActual.Size = new System.Drawing.Size(150, 25);
            this.txtStockActual.TabIndex = 15;
            this.txtStockActual.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtStockActual_KeyPress);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(390, 40);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 26);
            this.label3.TabIndex = 17;
            this.label3.Text = "Unidad";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(390, 70);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 26);
            this.label4.TabIndex = 18;
            this.label4.Text = "Precio unitario";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(390, 130);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(107, 26);
            this.label5.TabIndex = 20;
            this.label5.Text = "Stock mínimo";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(390, 100);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(107, 26);
            this.label6.TabIndex = 19;
            this.label6.Text = "Stock actual";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTipoMaterial
            // 
            this.lblTipoMaterial.Location = new System.Drawing.Point(10, 40);
            this.lblTipoMaterial.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTipoMaterial.Name = "lblTipoMaterial";
            this.lblTipoMaterial.Size = new System.Drawing.Size(107, 26);
            this.lblTipoMaterial.TabIndex = 21;
            this.lblTipoMaterial.Text = "Tipo material";
            this.lblTipoMaterial.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblMaterial
            // 
            this.lblMaterial.Location = new System.Drawing.Point(10, 70);
            this.lblMaterial.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMaterial.Name = "lblMaterial";
            this.lblMaterial.Size = new System.Drawing.Size(107, 26);
            this.lblMaterial.TabIndex = 22;
            this.lblMaterial.Text = "Material";
            this.lblMaterial.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.Location = new System.Drawing.Point(10, 100);
            this.lblDescripcion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(107, 26);
            this.lblDescripcion.TabIndex = 23;
            this.lblDescripcion.Text = "Descripcion";
            this.lblDescripcion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblMensajeBoton
            // 
            this.lblMensajeBoton.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblMensajeBoton.Location = new System.Drawing.Point(0, 0);
            this.lblMensajeBoton.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMensajeBoton.Name = "lblMensajeBoton";
            this.lblMensajeBoton.Size = new System.Drawing.Size(840, 26);
            this.lblMensajeBoton.TabIndex = 24;
            this.lblMensajeBoton.Text = "Bienvenido al control de stock, presione los botones correspondientes para empeza" +
    "r a modificar";
            this.lblMensajeBoton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblMensajeBoton.Paint += new System.Windows.Forms.PaintEventHandler(this.lblMensajeBoton_Paint);
            // 
            // pnlOpciones
            // 
            this.pnlOpciones.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(40)))));
            this.pnlOpciones.Controls.Add(this.btnGestion);
            this.pnlOpciones.Controls.Add(this.btnNuevoMaterial);
            this.pnlOpciones.Controls.Add(this.btnGuardar);
            this.pnlOpciones.Controls.Add(this.lblMensajeBoton);
            this.pnlOpciones.Controls.Add(this.label6);
            this.pnlOpciones.Controls.Add(this.lblDescripcion);
            this.pnlOpciones.Controls.Add(this.cmbTipoMaterial);
            this.pnlOpciones.Controls.Add(this.lblMaterial);
            this.pnlOpciones.Controls.Add(this.cmbMaterial);
            this.pnlOpciones.Controls.Add(this.lblTipoMaterial);
            this.pnlOpciones.Controls.Add(this.txtDescripcion);
            this.pnlOpciones.Controls.Add(this.label5);
            this.pnlOpciones.Controls.Add(this.label1);
            this.pnlOpciones.Controls.Add(this.cbxActivo);
            this.pnlOpciones.Controls.Add(this.label4);
            this.pnlOpciones.Controls.Add(this.label3);
            this.pnlOpciones.Controls.Add(this.txtStockMinimo);
            this.pnlOpciones.Controls.Add(this.txtUnidad);
            this.pnlOpciones.Controls.Add(this.txtStockActual);
            this.pnlOpciones.Controls.Add(this.txtPrecioUnitario);
            this.pnlOpciones.ForeColor = System.Drawing.Color.White;
            this.pnlOpciones.Location = new System.Drawing.Point(10, 50);
            this.pnlOpciones.Name = "pnlOpciones";
            this.pnlOpciones.Size = new System.Drawing.Size(840, 170);
            this.pnlOpciones.TabIndex = 25;
            this.pnlOpciones.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlOpciones_Paint);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(40)))));
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 585);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(860, 20);
            this.panel2.TabIndex = 27;
            // 
            // pnlBorde
            // 
            this.pnlBorde.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(40)))));
            this.pnlBorde.Controls.Add(this.pctLogo);
            this.pnlBorde.Controls.Add(this.pctMinimize);
            this.pnlBorde.Controls.Add(this.pctClose);
            this.pnlBorde.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBorde.Location = new System.Drawing.Point(0, 0);
            this.pnlBorde.Name = "pnlBorde";
            this.pnlBorde.Size = new System.Drawing.Size(860, 40);
            this.pnlBorde.TabIndex = 26;
            // 
            // pctLogo
            // 
            this.pctLogo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pctLogo.BackgroundImage")));
            this.pctLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pctLogo.Location = new System.Drawing.Point(8, 8);
            this.pctLogo.Name = "pctLogo";
            this.pctLogo.Size = new System.Drawing.Size(45, 25);
            this.pctLogo.TabIndex = 8025;
            this.pctLogo.TabStop = false;
            // 
            // pctMinimize
            // 
            this.pctMinimize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(40)))));
            this.pctMinimize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pctMinimize.Dock = System.Windows.Forms.DockStyle.Right;
            this.pctMinimize.Image = ((System.Drawing.Image)(resources.GetObject("pctMinimize.Image")));
            this.pctMinimize.Location = new System.Drawing.Point(780, 0);
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
            this.pctClose.Location = new System.Drawing.Point(820, 0);
            this.pctClose.Name = "pctClose";
            this.pctClose.Size = new System.Drawing.Size(40, 40);
            this.pctClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pctClose.TabIndex = 20;
            this.pctClose.TabStop = false;
            this.pctClose.Click += new System.EventHandler(this.pctClose_Click);
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
            // pnlBuscar
            // 
            this.pnlBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(40)))));
            this.pnlBuscar.Controls.Add(this.txtBuscar);
            this.pnlBuscar.Controls.Add(this.btnBuscar);
            this.pnlBuscar.Font = new System.Drawing.Font("Bahnschrift", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlBuscar.ForeColor = System.Drawing.Color.White;
            this.pnlBuscar.Location = new System.Drawing.Point(10, 230);
            this.pnlBuscar.Name = "pnlBuscar";
            this.pnlBuscar.Size = new System.Drawing.Size(840, 40);
            this.pnlBuscar.TabIndex = 31;
            this.pnlBuscar.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlBuscar_Paint);
            // 
            // frmControlStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(860, 605);
            this.Controls.Add(this.pnlBuscar);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pnlBorde);
            this.Controls.Add(this.pnlOpciones);
            this.Controls.Add(this.dataGridView1);
            this.Font = new System.Drawing.Font("Bahnschrift", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.Name = "frmControlStock";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.pnlOpciones.ResumeLayout(false);
            this.pnlOpciones.PerformLayout();
            this.pnlBorde.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pctLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctMinimize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctClose)).EndInit();
            this.pnlBuscar.ResumeLayout(false);
            this.pnlBuscar.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox cmbTipoMaterial;
        private System.Windows.Forms.ComboBox cmbMaterial;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox cbxActivo;
        private System.Windows.Forms.Button btnNuevoMaterial;
        private System.Windows.Forms.Button btnGestion;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.TextBox txtUnidad;
        private System.Windows.Forms.TextBox txtPrecioUnitario;
        private System.Windows.Forms.TextBox txtStockMinimo;
        private System.Windows.Forms.TextBox txtStockActual;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblTipoMaterial;
        private System.Windows.Forms.Label lblMaterial;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.Label lblMensajeBoton;
        private System.Windows.Forms.Panel pnlOpciones;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel pnlBorde;
        private System.Windows.Forms.PictureBox pctMinimize;
        private System.Windows.Forms.PictureBox pctClose;
        private System.Windows.Forms.PictureBox pctLogo;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Panel pnlBuscar;
    }
}