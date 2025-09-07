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
            this.txtderpatamento = new System.Windows.Forms.TextBox();
            this.txtpiso = new System.Windows.Forms.TextBox();
            this.txtlocalidad = new System.Windows.Forms.TextBox();
            this.txtpartido = new System.Windows.Forms.TextBox();
            this.txtnumerocalle = new System.Windows.Forms.TextBox();
            this.txtemail = new System.Windows.Forms.TextBox();
            this.txtnumerodocumento = new System.Windows.Forms.TextBox();
            this.txtnombre = new System.Windows.Forms.TextBox();
            this.txtcalle = new System.Windows.Forms.TextBox();
            this.txttelefono = new System.Windows.Forms.TextBox();
            this.txttipodocumento = new System.Windows.Forms.TextBox();
            this.txtapellido = new System.Windows.Forms.TextBox();
            this.btnVolverRegCliente = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.pctClose = new System.Windows.Forms.PictureBox();
            this.pctMinimize = new System.Windows.Forms.PictureBox();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.pctBorde = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctMinimize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctBorde)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtderpatamento);
            this.groupBox1.Controls.Add(this.txtpiso);
            this.groupBox1.Controls.Add(this.txtlocalidad);
            this.groupBox1.Controls.Add(this.txtpartido);
            this.groupBox1.Controls.Add(this.txtnumerocalle);
            this.groupBox1.Controls.Add(this.txtemail);
            this.groupBox1.Controls.Add(this.txtnumerodocumento);
            this.groupBox1.Controls.Add(this.txtnombre);
            this.groupBox1.Controls.Add(this.txtcalle);
            this.groupBox1.Controls.Add(this.txttelefono);
            this.groupBox1.Controls.Add(this.txttipodocumento);
            this.groupBox1.Controls.Add(this.txtapellido);
            this.groupBox1.Location = new System.Drawing.Point(42, 61);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(655, 173);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Registro y Modificación de clientes";
            // 
            // txtderpatamento
            // 
            this.txtderpatamento.Location = new System.Drawing.Point(579, 105);
            this.txtderpatamento.Name = "txtderpatamento";
            this.txtderpatamento.Size = new System.Drawing.Size(57, 20);
            this.txtderpatamento.TabIndex = 10;
            this.txtderpatamento.Enter += new System.EventHandler(this.txtdepartamento_Enter);
            this.txtderpatamento.Leave += new System.EventHandler(this.txtdepartamento_Leave);
            // 
            // txtpiso
            // 
            this.txtpiso.Location = new System.Drawing.Point(482, 105);
            this.txtpiso.Name = "txtpiso";
            this.txtpiso.Size = new System.Drawing.Size(57, 20);
            this.txtpiso.TabIndex = 9;
            this.txtpiso.Enter += new System.EventHandler(this.txtpiso_Enter);
            this.txtpiso.Leave += new System.EventHandler(this.txtpiso_Leave);
            // 
            // txtlocalidad
            // 
            this.txtlocalidad.Location = new System.Drawing.Point(385, 133);
            this.txtlocalidad.Name = "txtlocalidad";
            this.txtlocalidad.Size = new System.Drawing.Size(251, 20);
            this.txtlocalidad.TabIndex = 12;
            this.txtlocalidad.Enter += new System.EventHandler(this.txtlocalidad_Enter);
            this.txtlocalidad.Leave += new System.EventHandler(this.txtlocalidad_Leave);
            // 
            // txtpartido
            // 
            this.txtpartido.Location = new System.Drawing.Point(6, 133);
            this.txtpartido.Name = "txtpartido";
            this.txtpartido.Size = new System.Drawing.Size(251, 20);
            this.txtpartido.TabIndex = 11;
            this.txtpartido.Enter += new System.EventHandler(this.txtpartido_Enter);
            this.txtpartido.Leave += new System.EventHandler(this.txtpartido_Leave);
            // 
            // txtnumerocalle
            // 
            this.txtnumerocalle.Location = new System.Drawing.Point(385, 105);
            this.txtnumerocalle.Name = "txtnumerocalle";
            this.txtnumerocalle.Size = new System.Drawing.Size(57, 20);
            this.txtnumerocalle.TabIndex = 8;
            this.txtnumerocalle.Enter += new System.EventHandler(this.txtnumerocalle_Enter);
            this.txtnumerocalle.Leave += new System.EventHandler(this.txtnumerocalle_Leave);
            // 
            // txtemail
            // 
            this.txtemail.Location = new System.Drawing.Point(385, 77);
            this.txtemail.Name = "txtemail";
            this.txtemail.Size = new System.Drawing.Size(251, 20);
            this.txtemail.TabIndex = 6;
            this.txtemail.Enter += new System.EventHandler(this.txtemail_Enter);
            this.txtemail.Leave += new System.EventHandler(this.txtemail_Leave);
            // 
            // txtnumerodocumento
            // 
            this.txtnumerodocumento.Location = new System.Drawing.Point(385, 49);
            this.txtnumerodocumento.Name = "txtnumerodocumento";
            this.txtnumerodocumento.Size = new System.Drawing.Size(251, 20);
            this.txtnumerodocumento.TabIndex = 4;
            this.txtnumerodocumento.Enter += new System.EventHandler(this.txttipodocumento_Enter);
            this.txtnumerodocumento.Leave += new System.EventHandler(this.txtnumerodocumento_Leave);
            // 
            // txtnombre
            // 
            this.txtnombre.Location = new System.Drawing.Point(385, 21);
            this.txtnombre.Name = "txtnombre";
            this.txtnombre.Size = new System.Drawing.Size(251, 20);
            this.txtnombre.TabIndex = 2;
            this.txtnombre.Enter += new System.EventHandler(this.txtnombre_Enter);
            this.txtnombre.Leave += new System.EventHandler(this.txtnombre_Leave);
            // 
            // txtcalle
            // 
            this.txtcalle.Location = new System.Drawing.Point(6, 105);
            this.txtcalle.Name = "txtcalle";
            this.txtcalle.Size = new System.Drawing.Size(251, 20);
            this.txtcalle.TabIndex = 7;
            this.txtcalle.Enter += new System.EventHandler(this.txtcalle_Enter);
            this.txtcalle.Leave += new System.EventHandler(this.txtcalle_Leave);
            // 
            // txttelefono
            // 
            this.txttelefono.Location = new System.Drawing.Point(6, 77);
            this.txttelefono.Name = "txttelefono";
            this.txttelefono.Size = new System.Drawing.Size(251, 20);
            this.txttelefono.TabIndex = 5;
            this.txttelefono.Enter += new System.EventHandler(this.txttelefono_Enter);
            this.txttelefono.Leave += new System.EventHandler(this.txttelefono_Leave);
            // 
            // txttipodocumento
            // 
            this.txttipodocumento.Location = new System.Drawing.Point(6, 49);
            this.txttipodocumento.Name = "txttipodocumento";
            this.txttipodocumento.Size = new System.Drawing.Size(251, 20);
            this.txttipodocumento.TabIndex = 3;
            this.txttipodocumento.Enter += new System.EventHandler(this.txttipodocumento_Enter);
            this.txttipodocumento.Leave += new System.EventHandler(this.txttipodocumento_Enter);
            // 
            // txtapellido
            // 
            this.txtapellido.Location = new System.Drawing.Point(6, 21);
            this.txtapellido.Name = "txtapellido";
            this.txtapellido.Size = new System.Drawing.Size(251, 20);
            this.txtapellido.TabIndex = 1;
            this.txtapellido.Enter += new System.EventHandler(this.txtapellido_Enter);
            this.txtapellido.Leave += new System.EventHandler(this.txtapellido_Leave);
            // 
            // btnVolverRegCliente
            // 
            this.btnVolverRegCliente.Location = new System.Drawing.Point(750, 164);
            this.btnVolverRegCliente.Name = "btnVolverRegCliente";
            this.btnVolverRegCliente.Size = new System.Drawing.Size(75, 24);
            this.btnVolverRegCliente.TabIndex = 15;
            this.btnVolverRegCliente.Text = "Volver";
            this.btnVolverRegCliente.UseVisualStyleBackColor = true;
            this.btnVolverRegCliente.Click += new System.EventHandler(this.btnVolverRegCliente_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(750, 108);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 14;
            this.button2.Text = "Modificar";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(750, 79);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 13;
            this.button4.Text = "Agregar";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(42, 267);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(655, 211);
            this.dataGridView1.TabIndex = 12;
            // 
            // pctClose
            // 
            this.pctClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(40)))));
            this.pctClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pctClose.Image = ((System.Drawing.Image)(resources.GetObject("pctClose.Image")));
            this.pctClose.Location = new System.Drawing.Point(812, 2);
            this.pctClose.Name = "pctClose";
            this.pctClose.Size = new System.Drawing.Size(40, 40);
            this.pctClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pctClose.TabIndex = 22;
            this.pctClose.TabStop = false;
            this.pctClose.Click += new System.EventHandler(this.pctClose_Click);
            // 
            // pctMinimize
            // 
            this.pctMinimize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(40)))));
            this.pctMinimize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pctMinimize.Image = ((System.Drawing.Image)(resources.GetObject("pctMinimize.Image")));
            this.pctMinimize.Location = new System.Drawing.Point(2, 2);
            this.pctMinimize.Name = "pctMinimize";
            this.pctMinimize.Size = new System.Drawing.Size(40, 40);
            this.pctMinimize.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pctMinimize.TabIndex = 24;
            this.pctMinimize.TabStop = false;
            this.pctMinimize.Click += new System.EventHandler(this.pctMinimize_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(750, 135);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(75, 23);
            this.btnEliminar.TabIndex = 25;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            // 
            // pctBorde
            // 
            this.pctBorde.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(40)))));
            this.pctBorde.Location = new System.Drawing.Point(-7, -2);
            this.pctBorde.Name = "pctBorde";
            this.pctBorde.Size = new System.Drawing.Size(869, 44);
            this.pctBorde.TabIndex = 26;
            this.pctBorde.TabStop = false;
            // 
            // frmRegistroClientes
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(853, 490);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.pctMinimize);
            this.Controls.Add(this.pctClose);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnVolverRegCliente);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pctBorde);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmRegistroClientes";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.frmRegistroClientes_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctMinimize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctBorde)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtderpatamento;
        private System.Windows.Forms.TextBox txtpiso;
        private System.Windows.Forms.TextBox txtlocalidad;
        private System.Windows.Forms.TextBox txtpartido;
        private System.Windows.Forms.TextBox txtnumerocalle;
        private System.Windows.Forms.TextBox txtemail;
        private System.Windows.Forms.TextBox txtnumerodocumento;
        private System.Windows.Forms.TextBox txtnombre;
        private System.Windows.Forms.TextBox txtcalle;
        private System.Windows.Forms.TextBox txttelefono;
        private System.Windows.Forms.TextBox txttipodocumento;
        private System.Windows.Forms.TextBox txtapellido;
        private System.Windows.Forms.Button btnVolverRegCliente;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.PictureBox pctClose;
        private System.Windows.Forms.PictureBox pctMinimize;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.PictureBox pctBorde;
    }
}