﻿namespace Sistema_Gestion_De_Usuarios
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
            this.cmbUsuarios = new System.Windows.Forms.ComboBox();
            this.dgvPermisos = new System.Windows.Forms.DataGridView();
            this.colIdPermiso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFuncionalidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHabilitado = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.btnguardarpermiso = new System.Windows.Forms.Button();
            this.lblUsuariospermiso = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPermisos)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbUsuarios
            // 
            this.cmbUsuarios.FormattingEnabled = true;
            this.cmbUsuarios.Location = new System.Drawing.Point(289, 40);
            this.cmbUsuarios.Name = "cmbUsuarios";
            this.cmbUsuarios.Size = new System.Drawing.Size(200, 26);
            this.cmbUsuarios.TabIndex = 4;
            this.cmbUsuarios.SelectedIndexChanged += new System.EventHandler(this.cmbUsuarios_SelectedIndexChanged);
            this.cmbUsuarios.DisplayMemberChanged += new System.EventHandler(this.NombreUsuario);
            this.cmbUsuarios.ValueMemberChanged += new System.EventHandler(this.IdUsuario);
            // 
            // dgvPermisos
            // 
            this.dgvPermisos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvPermisos.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvPermisos.BackgroundColor = System.Drawing.Color.White;
            this.dgvPermisos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPermisos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIdPermiso,
            this.colFuncionalidad,
            this.colDescripcion,
            this.colHabilitado});
            this.dgvPermisos.Location = new System.Drawing.Point(15, 84);
            this.dgvPermisos.Name = "dgvPermisos";
            this.dgvPermisos.Size = new System.Drawing.Size(750, 310);
            this.dgvPermisos.TabIndex = 5;
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
            this.colFuncionalidad.Width = 124;
            // 
            // colDescripcion
            // 
            this.colDescripcion.DataPropertyName = "Descripcion";
            this.colDescripcion.HeaderText = "Descripcion";
            this.colDescripcion.Name = "colDescripcion";
            this.colDescripcion.ReadOnly = true;
            this.colDescripcion.Width = 111;
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
            // btnguardarpermiso
            // 
            this.btnguardarpermiso.Location = new System.Drawing.Point(289, 412);
            this.btnguardarpermiso.Name = "btnguardarpermiso";
            this.btnguardarpermiso.Size = new System.Drawing.Size(200, 30);
            this.btnguardarpermiso.TabIndex = 6;
            this.btnguardarpermiso.Text = "Guardar";
            this.btnguardarpermiso.UseVisualStyleBackColor = true;
            this.btnguardarpermiso.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // lblUsuariospermiso
            // 
            this.lblUsuariospermiso.BackColor = System.Drawing.Color.Transparent;
            this.lblUsuariospermiso.ForeColor = System.Drawing.Color.White;
            this.lblUsuariospermiso.Location = new System.Drawing.Point(0, 15);
            this.lblUsuariospermiso.Name = "lblUsuariospermiso";
            this.lblUsuariospermiso.Size = new System.Drawing.Size(775, 20);
            this.lblUsuariospermiso.TabIndex = 24;
            this.lblUsuariospermiso.Text = "Usuarios";
            this.lblUsuariospermiso.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmPermisos
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImage = global::Vista.Properties.Resources.WoodenPlankCyan;
            this.ClientSize = new System.Drawing.Size(780, 459);
            this.Controls.Add(this.dgvPermisos);
            this.Controls.Add(this.lblUsuariospermiso);
            this.Controls.Add(this.btnguardarpermiso);
            this.Controls.Add(this.cmbUsuarios);
            this.Font = new System.Drawing.Font("Bahnschrift", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmPermisos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.frmPermisos_Load);
            this.Shown += new System.EventHandler(this.frmPermisos_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPermisos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ComboBox cmbUsuarios;
        private System.Windows.Forms.DataGridView dgvPermisos;
        private System.Windows.Forms.Button btnguardarpermiso;
        private System.Windows.Forms.Label lblUsuariospermiso;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdPermiso;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFuncionalidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescripcion;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colHabilitado;
    }
}