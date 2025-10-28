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
            this.lblstockactivo = new System.Windows.Forms.Label();
            this.cbxActivo = new System.Windows.Forms.CheckBox();
            this.btnNuevoMaterial = new System.Windows.Forms.Button();
            this.btnGestionarstock = new System.Windows.Forms.Button();
            this.btnGuardarstock = new System.Windows.Forms.Button();
            this.txtUnidad = new System.Windows.Forms.TextBox();
            this.txtPrecioUnitario = new System.Windows.Forms.TextBox();
            this.txtStockMinimo = new System.Windows.Forms.TextBox();
            this.txtStockActual = new System.Windows.Forms.TextBox();
            this.lblstockunidad = new System.Windows.Forms.Label();
            this.lblstockpreciou = new System.Windows.Forms.Label();
            this.lblstockminimo = new System.Windows.Forms.Label();
            this.lblstockactual = new System.Windows.Forms.Label();
            this.lblTipoMaterial = new System.Windows.Forms.Label();
            this.lblMaterial = new System.Windows.Forms.Label();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.pnlBuscar = new System.Windows.Forms.Panel();
            this.grpStock = new System.Windows.Forms.GroupBox();
            this.btnEliminarstock = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.pnlBuscar.SuspendLayout();
            this.grpStock.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(15, 245);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(870, 340);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // cmbTipoMaterial
            // 
            this.cmbTipoMaterial.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmbTipoMaterial.BackColor = System.Drawing.Color.White;
            this.cmbTipoMaterial.ForeColor = System.Drawing.Color.Black;
            this.cmbTipoMaterial.FormattingEnabled = true;
            this.cmbTipoMaterial.Location = new System.Drawing.Point(118, 30);
            this.cmbTipoMaterial.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.cmbTipoMaterial.Name = "cmbTipoMaterial";
            this.cmbTipoMaterial.Size = new System.Drawing.Size(200, 26);
            this.cmbTipoMaterial.TabIndex = 1;
            this.cmbTipoMaterial.SelectedIndexChanged += new System.EventHandler(this.cmbTipoMaterial_SelectedIndexChanged);
            // 
            // cmbMaterial
            // 
            this.cmbMaterial.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmbMaterial.BackColor = System.Drawing.Color.White;
            this.cmbMaterial.ForeColor = System.Drawing.Color.Black;
            this.cmbMaterial.FormattingEnabled = true;
            this.cmbMaterial.Location = new System.Drawing.Point(118, 60);
            this.cmbMaterial.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.cmbMaterial.Name = "cmbMaterial";
            this.cmbMaterial.Size = new System.Drawing.Size(200, 26);
            this.cmbMaterial.TabIndex = 2;
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtDescripcion.BackColor = System.Drawing.Color.White;
            this.txtDescripcion.ForeColor = System.Drawing.Color.Black;
            this.txtDescripcion.Location = new System.Drawing.Point(118, 90);
            this.txtDescripcion.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(250, 25);
            this.txtDescripcion.TabIndex = 3;
            // 
            // lblstockactivo
            // 

            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.Location = new System.Drawing.Point(15, 120);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 25);
            this.label1.TabIndex = 4;
            this.label1.Text = "Activo";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbxActivo
            // 
            this.cbxActivo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cbxActivo.Location = new System.Drawing.Point(118, 127);
            this.cbxActivo.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.cbxActivo.Name = "cbxActivo";
            this.cbxActivo.Size = new System.Drawing.Size(15, 15);
            this.cbxActivo.TabIndex = 5;
            this.cbxActivo.UseVisualStyleBackColor = true;
            // 
            // btnNuevoMaterial
            // 
            this.btnNuevoMaterial.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnNuevoMaterial.BackColor = System.Drawing.Color.White;
            this.btnNuevoMaterial.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnNuevoMaterial.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevoMaterial.ForeColor = System.Drawing.Color.Black;
            this.btnNuevoMaterial.Location = new System.Drawing.Point(705, 21);
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
            this.btnGestion.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnGestion.BackColor = System.Drawing.Color.White;
            this.btnGestion.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnGestion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGestion.ForeColor = System.Drawing.Color.Black;
            this.btnGestion.Location = new System.Drawing.Point(705, 53);
            this.btnGestion.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.btnGestion.Name = "btnGestion";
            this.btnGestion.Size = new System.Drawing.Size(150, 30);
            this.btnGestion.TabIndex = 9;
            this.btnGestion.Text = "Gestionar";
            this.btnGestion.UseVisualStyleBackColor = false;
            this.btnGestion.Click += new System.EventHandler(this.btnGestion_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnGuardar.BackColor = System.Drawing.Color.White;
            this.btnGuardar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.ForeColor = System.Drawing.Color.Black;
            this.btnGuardar.Location = new System.Drawing.Point(705, 85);
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
            this.txtUnidad.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtUnidad.BackColor = System.Drawing.Color.White;
            this.txtUnidad.ForeColor = System.Drawing.Color.Black;
            this.txtUnidad.Location = new System.Drawing.Point(518, 30);
            this.txtUnidad.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.txtUnidad.Name = "txtUnidad";
            this.txtUnidad.Size = new System.Drawing.Size(150, 25);
            this.txtUnidad.TabIndex = 13;
            // 
            // txtPrecioUnitario
            // 
            this.txtPrecioUnitario.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtPrecioUnitario.BackColor = System.Drawing.Color.White;
            this.txtPrecioUnitario.ForeColor = System.Drawing.Color.Black;
            this.txtPrecioUnitario.Location = new System.Drawing.Point(518, 58);
            this.txtPrecioUnitario.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.txtPrecioUnitario.Name = "txtPrecioUnitario";
            this.txtPrecioUnitario.Size = new System.Drawing.Size(150, 25);
            this.txtPrecioUnitario.TabIndex = 14;
            this.txtPrecioUnitario.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPrecioUnitario_KeyPress);
            // 
            // txtStockMinimo
            // 
            this.txtStockMinimo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtStockMinimo.BackColor = System.Drawing.Color.White;
            this.txtStockMinimo.ForeColor = System.Drawing.Color.Black;
            this.txtStockMinimo.Location = new System.Drawing.Point(518, 114);
            this.txtStockMinimo.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.txtStockMinimo.Name = "txtStockMinimo";
            this.txtStockMinimo.Size = new System.Drawing.Size(150, 25);
            this.txtStockMinimo.TabIndex = 16;
            this.txtStockMinimo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtStockMinimo_KeyPress);
            // 
            // txtStockActual
            // 
            this.txtStockActual.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtStockActual.BackColor = System.Drawing.Color.White;
            this.txtStockActual.ForeColor = System.Drawing.Color.Black;
            this.txtStockActual.Location = new System.Drawing.Point(518, 86);
            this.txtStockActual.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.txtStockActual.Name = "txtStockActual";
            this.txtStockActual.Size = new System.Drawing.Size(150, 25);
            this.txtStockActual.TabIndex = 15;
            this.txtStockActual.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtStockActual_KeyPress);
            // 

            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.Location = new System.Drawing.Point(405, 30);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 25);
            this.label3.TabIndex = 17;
            this.label3.Text = "Unidad";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.Location = new System.Drawing.Point(405, 58);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 25);
            this.label4.TabIndex = 18;
            this.label4.Text = "Precio unitario";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.Location = new System.Drawing.Point(405, 114);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(105, 25);
            this.label5.TabIndex = 20;
            this.label5.Text = "Stock mínimo";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label6.Location = new System.Drawing.Point(405, 86);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(105, 25);
            this.label6.TabIndex = 19;
            this.label6.Text = "Stock actual";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTipoMaterial
            // 
            this.lblTipoMaterial.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblTipoMaterial.Location = new System.Drawing.Point(15, 30);
            this.lblTipoMaterial.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTipoMaterial.Name = "lblTipoMaterial";
            this.lblTipoMaterial.Size = new System.Drawing.Size(95, 25);
            this.lblTipoMaterial.TabIndex = 21;
            this.lblTipoMaterial.Text = "Tipo material";
            this.lblTipoMaterial.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblMaterial
            // 
            this.lblMaterial.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblMaterial.Location = new System.Drawing.Point(15, 60);
            this.lblMaterial.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMaterial.Name = "lblMaterial";
            this.lblMaterial.Size = new System.Drawing.Size(95, 25);
            this.lblMaterial.TabIndex = 22;
            this.lblMaterial.Text = "Material";
            this.lblMaterial.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblDescripcion.Location = new System.Drawing.Point(15, 90);
            this.lblDescripcion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(95, 25);
            this.lblDescripcion.TabIndex = 23;
            this.lblDescripcion.Text = "Descripcion";
            this.lblDescripcion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // pnlBuscar
            // 
            this.pnlBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(40)))));
            this.pnlBuscar.Controls.Add(this.txtBuscar);
            this.pnlBuscar.Controls.Add(this.btnBuscar);
            this.pnlBuscar.Font = new System.Drawing.Font("Bahnschrift", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlBuscar.ForeColor = System.Drawing.Color.White;
            this.pnlBuscar.Location = new System.Drawing.Point(15, 190);
            this.pnlBuscar.Name = "pnlBuscar";
            this.pnlBuscar.Size = new System.Drawing.Size(870, 40);
            this.pnlBuscar.TabIndex = 31;
            this.pnlBuscar.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlBuscar_Paint);
            // 
            // grpStock
            // 
            this.grpStock.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(40)))));
            this.grpStock.Controls.Add(this.btnEliminarstock);
            this.grpStock.Controls.Add(this.btnGestionarstock);
            this.grpStock.Controls.Add(this.btnGuardarstock);
            this.grpStock.Controls.Add(this.cbxActivo);
            this.grpStock.Controls.Add(this.lblstockpreciou);
            this.grpStock.Controls.Add(this.btnNuevoMaterial);
            this.grpStock.Controls.Add(this.lblstockactivo);
            this.grpStock.Controls.Add(this.lblstockunidad);
            this.grpStock.Controls.Add(this.lblstockminimo);
            this.grpStock.Controls.Add(this.lblstockactual);
            this.grpStock.Controls.Add(this.txtStockMinimo);
            this.grpStock.Controls.Add(this.txtDescripcion);
            this.grpStock.Controls.Add(this.lblDescripcion);
            this.grpStock.Controls.Add(this.txtUnidad);
            this.grpStock.Controls.Add(this.cmbTipoMaterial);
            this.grpStock.Controls.Add(this.lblTipoMaterial);
            this.grpStock.Controls.Add(this.lblMaterial);
            this.grpStock.Controls.Add(this.txtStockActual);
            this.grpStock.Controls.Add(this.txtPrecioUnitario);
            this.grpStock.Controls.Add(this.cmbMaterial);
            this.grpStock.ForeColor = System.Drawing.Color.White;
            this.grpStock.Location = new System.Drawing.Point(15, 15);
            this.grpStock.Name = "grpStock";
            this.grpStock.Size = new System.Drawing.Size(870, 160);
            this.grpStock.TabIndex = 32;
            this.grpStock.TabStop = false;
            this.grpStock.Text = "Stock";

            // 
            // btnEliminar
            // 
            this.btnEliminar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnEliminar.BackColor = System.Drawing.Color.White;
            this.btnEliminar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.ForeColor = System.Drawing.Color.Black;
            this.btnEliminar.Location = new System.Drawing.Point(705, 117);
            this.btnEliminar.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(150, 30);
            this.btnEliminar.TabIndex = 24;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // frmControlStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Vista.Properties.Resources.WoodenPlankCyan;
            this.ClientSize = new System.Drawing.Size(900, 600);
            this.Controls.Add(this.grpStock);
            this.Controls.Add(this.pnlBuscar);
            this.Controls.Add(this.dataGridView1);
            this.Font = new System.Drawing.Font("Bahnschrift", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.Name = "frmControlStock";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.frmControlStock_Load);
            this.Shown += new System.EventHandler(this.frmControlStock_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.pnlBuscar.ResumeLayout(false);
            this.pnlBuscar.PerformLayout();
            this.grpStock.ResumeLayout(false);
            this.grpStock.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox cmbTipoMaterial;
        private System.Windows.Forms.ComboBox cmbMaterial;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Label lblstockactivo;
        private System.Windows.Forms.CheckBox cbxActivo;
        private System.Windows.Forms.Button btnNuevoMaterial;
        private System.Windows.Forms.Button btnGestionarstock;
        private System.Windows.Forms.Button btnGuardarstock;
        private System.Windows.Forms.TextBox txtUnidad;
        private System.Windows.Forms.TextBox txtPrecioUnitario;
        private System.Windows.Forms.TextBox txtStockMinimo;
        private System.Windows.Forms.TextBox txtStockActual;
        private System.Windows.Forms.Label lblstockunidad;
        private System.Windows.Forms.Label lblstockpreciou;
        private System.Windows.Forms.Label lblstockminimo;
        private System.Windows.Forms.Label lblstockactual;
        private System.Windows.Forms.Label lblTipoMaterial;
        private System.Windows.Forms.Label lblMaterial;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Panel pnlBuscar;
        private System.Windows.Forms.GroupBox grpStock;
        private System.Windows.Forms.Button btnEliminarstock;
    }
}