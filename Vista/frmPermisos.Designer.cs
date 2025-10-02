namespace Sistema_Gestion_De_Usuarios
{
    partial class frmPermisos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPermisos));
            this.lblpermisos = new System.Windows.Forms.Label();
            this.btnvolver = new System.Windows.Forms.Button();
            this.cmbUsuarios = new System.Windows.Forms.ComboBox();
            this.dgvPermisos = new System.Windows.Forms.DataGridView();
            this.btnguardar = new System.Windows.Forms.Button();
            this.lblUsuarios = new System.Windows.Forms.Label();
            this.pnlBorde = new System.Windows.Forms.Panel();
            this.pctMinimize = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.colIdPermiso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFuncionalidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHabilitado = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPermisos)).BeginInit();
            this.pnlBorde.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctMinimize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctClose)).BeginInit();
            this.SuspendLayout();
            // 
            // lblpermisos
            // 
            this.lblpermisos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblpermisos.Font = new System.Drawing.Font("Bahnschrift", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblpermisos.ForeColor = System.Drawing.Color.White;
            this.lblpermisos.Location = new System.Drawing.Point(40, 0);
            this.lblpermisos.Name = "lblpermisos";
            this.lblpermisos.Size = new System.Drawing.Size(695, 40);
            this.lblpermisos.TabIndex = 0;
            this.lblpermisos.Text = "Gestión de permisos";
            this.lblpermisos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnvolver
            // 
            this.btnvolver.Location = new System.Drawing.Point(450, 440);
            this.btnvolver.Name = "btnvolver";
            this.btnvolver.Size = new System.Drawing.Size(200, 29);
            this.btnvolver.TabIndex = 1;
            this.btnvolver.Text = "Volver";
            this.btnvolver.UseVisualStyleBackColor = true;
            this.btnvolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // cmbUsuarios
            // 
            this.cmbUsuarios.FormattingEnabled = true;
            this.cmbUsuarios.Location = new System.Drawing.Point(285, 80);
            this.cmbUsuarios.Name = "cmbUsuarios";
            this.cmbUsuarios.Size = new System.Drawing.Size(200, 26);
            this.cmbUsuarios.TabIndex = 4;
            this.cmbUsuarios.SelectedIndexChanged += new System.EventHandler(this.cmbUsuarios_SelectedIndexChanged);
            this.cmbUsuarios.DisplayMemberChanged += new System.EventHandler(this.NombreUsuario);
            this.cmbUsuarios.ValueMemberChanged += new System.EventHandler(this.IdUsuario);
            // 
            // dgvPermisos
            // 
            this.dgvPermisos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvPermisos.BackgroundColor = System.Drawing.Color.White;
            this.dgvPermisos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPermisos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIdPermiso,
            this.colFuncionalidad,
            this.colDescripcion,
            this.colHabilitado});
            this.dgvPermisos.Location = new System.Drawing.Point(13, 120);
            this.dgvPermisos.Name = "dgvPermisos";
            this.dgvPermisos.Size = new System.Drawing.Size(750, 310);
            this.dgvPermisos.TabIndex = 5;
            // 
            // btnguardar
            // 
            this.btnguardar.Location = new System.Drawing.Point(125, 440);
            this.btnguardar.Name = "btnguardar";
            this.btnguardar.Size = new System.Drawing.Size(200, 29);
            this.btnguardar.TabIndex = 6;
            this.btnguardar.Text = "Guardar";
            this.btnguardar.UseVisualStyleBackColor = true;
            this.btnguardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // lblUsuarios
            // 
            this.lblUsuarios.BackColor = System.Drawing.Color.Transparent;
            this.lblUsuarios.ForeColor = System.Drawing.Color.White;
            this.lblUsuarios.Location = new System.Drawing.Point(0, 55);
            this.lblUsuarios.Name = "lblUsuarios";
            this.lblUsuarios.Size = new System.Drawing.Size(775, 20);
            this.lblUsuarios.TabIndex = 24;
            this.lblUsuarios.Text = "Usuarios";
            this.lblUsuarios.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlBorde
            // 
            this.pnlBorde.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(40)))));
            this.pnlBorde.Controls.Add(this.lblpermisos);
            this.pnlBorde.Controls.Add(this.pctMinimize);
            this.pnlBorde.Controls.Add(this.pctClose);
            this.pnlBorde.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBorde.Location = new System.Drawing.Point(0, 0);
            this.pnlBorde.Name = "pnlBorde";
            this.pnlBorde.Size = new System.Drawing.Size(775, 40);
            this.pnlBorde.TabIndex = 27;
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
            this.pctMinimize.Click += new System.EventHandler(this.pctMinimize_Click);
            // 
            // pctClose
            // 
            this.pctClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(40)))));
            this.pctClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pctClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.pctClose.Image = ((System.Drawing.Image)(resources.GetObject("pctClose.Image")));
            this.pctClose.Location = new System.Drawing.Point(735, 0);
            this.pctClose.Name = "pctClose";
            this.pctClose.Size = new System.Drawing.Size(40, 40);
            this.pctClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pctClose.TabIndex = 20;
            this.pctClose.TabStop = false;
            this.pctClose.Click += new System.EventHandler(this.pctClose_Click);
            // 
            // pnlBordeInferior
            // 
            this.pnlBordeInferior.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(40)))));
            this.pnlBordeInferior.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBordeInferior.Location = new System.Drawing.Point(0, 480);
            this.pnlBordeInferior.Name = "pnlBordeInferior";
            this.pnlBordeInferior.Size = new System.Drawing.Size(775, 20);
            this.pnlBordeInferior.TabIndex = 28;
            // 
            // colIdPermiso
            // 
            this.colIdPermiso.DataPropertyName = "IdPermiso";
            this.colIdPermiso.HeaderText = "Id permiso";
            this.colIdPermiso.Name = "colIdPermiso";
            this.colIdPermiso.ReadOnly = true;
            this.colIdPermiso.Visible = false;
            // 
            // colFuncionalidad
            // 
            this.colFuncionalidad.DataPropertyName = "Nombre";
            this.colFuncionalidad.HeaderText = "Funcionalidad";
            this.colFuncionalidad.Name = "colFuncionalidad";
            this.colFuncionalidad.ReadOnly = true;
            // 
            // colDescripcion
            // 
            this.colDescripcion.DataPropertyName = "Descripcion";
            this.colDescripcion.HeaderText = "Descripcion";
            this.colDescripcion.Name = "colDescripcion";
            this.colDescripcion.ReadOnly = true;
            // 
            // colHabilitado
            // 
            this.colHabilitado.DataPropertyName = "Habilitado";
            this.colHabilitado.FalseValue = "False";
            this.colHabilitado.HeaderText = "Habilitado";
            this.colHabilitado.Name = "colHabilitado";
            this.colHabilitado.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colHabilitado.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colHabilitado.TrueValue = "True";
            // 
            // frmPermisos
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImage = global::Vista.Properties.Resources.WoodenPlankCyan;
            this.ClientSize = new System.Drawing.Size(775, 500);
            this.Controls.Add(this.dgvPermisos);
            this.Controls.Add(this.lblUsuarios);
            this.Controls.Add(this.pnlBordeInferior);
            this.Controls.Add(this.pnlBorde);
            this.Controls.Add(this.btnguardar);
            this.Controls.Add(this.cmbUsuarios);
            this.Controls.Add(this.btnvolver);
            this.Font = new System.Drawing.Font("Bahnschrift", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmPermisos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.frmPermisos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPermisos)).EndInit();
            this.pnlBorde.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pctMinimize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctClose)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblpermisos;
        private System.Windows.Forms.Button btnvolver;
        private System.Windows.Forms.ComboBox cmbUsuarios;
        private System.Windows.Forms.DataGridView dgvPermisos;
        private System.Windows.Forms.Button btnguardar;
        private System.Windows.Forms.Label lblUsuarios;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdPermiso;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFuncionalidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescripcion;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colHabilitado;
        private System.Windows.Forms.Panel pnlBorde;
        private System.Windows.Forms.PictureBox pctMinimize;
        private System.Windows.Forms.PictureBox pctClose;
        private System.Windows.Forms.Panel pnlBordeInferior;
    }
}