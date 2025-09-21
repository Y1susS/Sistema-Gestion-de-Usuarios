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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.cmbTipoMaterial = new System.Windows.Forms.ComboBox();
            this.cmbMaterial = new System.Windows.Forms.ComboBox();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbxActivo = new System.Windows.Forms.CheckBox();
            this.btnNuevoMaterial = new System.Windows.Forms.Button();
            this.btnGestion = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
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
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 313);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1124, 295);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // cmbTipoMaterial
            // 
            this.cmbTipoMaterial.FormattingEnabled = true;
            this.cmbTipoMaterial.Location = new System.Drawing.Point(182, 104);
            this.cmbTipoMaterial.Name = "cmbTipoMaterial";
            this.cmbTipoMaterial.Size = new System.Drawing.Size(210, 24);
            this.cmbTipoMaterial.TabIndex = 1;
            this.cmbTipoMaterial.SelectedIndexChanged += new System.EventHandler(this.cmbTipoMaterial_SelectedIndexChanged);
            // 
            // cmbMaterial
            // 
            this.cmbMaterial.FormattingEnabled = true;
            this.cmbMaterial.Location = new System.Drawing.Point(182, 155);
            this.cmbMaterial.Name = "cmbMaterial";
            this.cmbMaterial.Size = new System.Drawing.Size(210, 24);
            this.cmbMaterial.TabIndex = 2;
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(182, 209);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(295, 22);
            this.txtDescripcion.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(80, 258);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "Activo";
            // 
            // cbxActivo
            // 
            this.cbxActivo.AutoSize = true;
            this.cbxActivo.Location = new System.Drawing.Point(182, 258);
            this.cbxActivo.Name = "cbxActivo";
            this.cbxActivo.Size = new System.Drawing.Size(18, 17);
            this.cbxActivo.TabIndex = 5;
            this.cbxActivo.UseVisualStyleBackColor = true;
            // 
            // btnNuevoMaterial
            // 
            this.btnNuevoMaterial.Location = new System.Drawing.Point(83, 12);
            this.btnNuevoMaterial.Name = "btnNuevoMaterial";
            this.btnNuevoMaterial.Size = new System.Drawing.Size(150, 24);
            this.btnNuevoMaterial.TabIndex = 8;
            this.btnNuevoMaterial.Text = "CARGAR NUEVO";
            this.btnNuevoMaterial.UseVisualStyleBackColor = true;
            this.btnNuevoMaterial.Click += new System.EventHandler(this.btnNuevoMaterial_Click);
            // 
            // btnGestion
            // 
            this.btnGestion.Location = new System.Drawing.Point(279, 12);
            this.btnGestion.Name = "btnGestion";
            this.btnGestion.Size = new System.Drawing.Size(150, 24);
            this.btnGestion.TabIndex = 9;
            this.btnGestion.Text = "GESTION MATERIAL";
            this.btnGestion.UseVisualStyleBackColor = true;
            this.btnGestion.Click += new System.EventHandler(this.btnGestion_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(957, 132);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(150, 24);
            this.btnGuardar.TabIndex = 10;
            this.btnGuardar.Text = "GURDAR";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Location = new System.Drawing.Point(957, 191);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(150, 24);
            this.btnCerrar.TabIndex = 12;
            this.btnCerrar.Text = "CERRAR";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // txtUnidad
            // 
            this.txtUnidad.Location = new System.Drawing.Point(704, 94);
            this.txtUnidad.Name = "txtUnidad";
            this.txtUnidad.Size = new System.Drawing.Size(96, 22);
            this.txtUnidad.TabIndex = 13;
            // 
            // txtPrecioUnitario
            // 
            this.txtPrecioUnitario.Location = new System.Drawing.Point(704, 140);
            this.txtPrecioUnitario.Name = "txtPrecioUnitario";
            this.txtPrecioUnitario.Size = new System.Drawing.Size(96, 22);
            this.txtPrecioUnitario.TabIndex = 14;
            this.txtPrecioUnitario.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPrecioUnitario_KeyPress);
            // 
            // txtStockMinimo
            // 
            this.txtStockMinimo.Location = new System.Drawing.Point(704, 225);
            this.txtStockMinimo.Name = "txtStockMinimo";
            this.txtStockMinimo.Size = new System.Drawing.Size(96, 22);
            this.txtStockMinimo.TabIndex = 16;
            this.txtStockMinimo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtStockMinimo_KeyPress);
            // 
            // txtStockActual
            // 
            this.txtStockActual.Location = new System.Drawing.Point(704, 181);
            this.txtStockActual.Name = "txtStockActual";
            this.txtStockActual.Size = new System.Drawing.Size(96, 22);
            this.txtStockActual.TabIndex = 15;
            this.txtStockActual.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtStockActual_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(586, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 16);
            this.label3.TabIndex = 17;
            this.label3.Text = "Unidad";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(586, 140);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 16);
            this.label4.TabIndex = 18;
            this.label4.Text = "Precio Unitario";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(586, 231);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 16);
            this.label5.TabIndex = 20;
            this.label5.Text = "Stock Minimo";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(586, 187);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(81, 16);
            this.label6.TabIndex = 19;
            this.label6.Text = "Stock Actual";
            // 
            // lblTipoMaterial
            // 
            this.lblTipoMaterial.AutoSize = true;
            this.lblTipoMaterial.Location = new System.Drawing.Point(69, 104);
            this.lblTipoMaterial.Name = "lblTipoMaterial";
            this.lblTipoMaterial.Size = new System.Drawing.Size(86, 16);
            this.lblTipoMaterial.TabIndex = 21;
            this.lblTipoMaterial.Text = "Tipo Material";
            // 
            // lblMaterial
            // 
            this.lblMaterial.AutoSize = true;
            this.lblMaterial.Location = new System.Drawing.Point(80, 158);
            this.lblMaterial.Name = "lblMaterial";
            this.lblMaterial.Size = new System.Drawing.Size(55, 16);
            this.lblMaterial.TabIndex = 22;
            this.lblMaterial.Text = "Material";
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.Location = new System.Drawing.Point(69, 215);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(79, 16);
            this.lblDescripcion.TabIndex = 23;
            this.lblDescripcion.Text = "Descripcion";
            // 
            // lblMensajeBoton
            // 
            this.lblMensajeBoton.AutoSize = true;
            this.lblMensajeBoton.Location = new System.Drawing.Point(69, 62);
            this.lblMensajeBoton.Name = "lblMensajeBoton";
            this.lblMensajeBoton.Size = new System.Drawing.Size(10, 16);
            this.lblMensajeBoton.TabIndex = 24;
            this.lblMensajeBoton.Text = " ";
            // 
            // frmControlStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1148, 620);
            this.Controls.Add(this.lblMensajeBoton);
            this.Controls.Add(this.lblDescripcion);
            this.Controls.Add(this.lblMaterial);
            this.Controls.Add(this.lblTipoMaterial);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtStockMinimo);
            this.Controls.Add(this.txtStockActual);
            this.Controls.Add(this.txtPrecioUnitario);
            this.Controls.Add(this.txtUnidad);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnGestion);
            this.Controls.Add(this.btnNuevoMaterial);
            this.Controls.Add(this.cbxActivo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.cmbMaterial);
            this.Controls.Add(this.cmbTipoMaterial);
            this.Controls.Add(this.dataGridView1);
            this.Name = "frmControlStock";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.Button btnCerrar;
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
    }
}