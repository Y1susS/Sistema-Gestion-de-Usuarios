using Datos;  
using Sesion;
using Entidades.DTOs; 
using Logica;   
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq; 
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vista;
using Sistema_Gestion_de_Usuarios.Vista;
using Vista.Lenguajes;


namespace Sistema_Gestion_De_Usuarios
{
    public partial class frmPermisos : Form
    {
        private ClsArrastrarFormularios moverFormulario;

        private frmPanelUsuarios _frmPanelUsuariosPadre;

        private CL_Permisos _logicaPermisos = new CL_Permisos();

        private int _idUsuarioSeleccionado = 0; 

        public frmPermisos()
        {
            InitializeComponent();
            Idioma.CargarIdiomaGuardado();
            Idioma.AplicarTraduccion(this);
        }

        public frmPermisos(frmPanelUsuarios panelUsuariosPadre)
        {
            InitializeComponent();
            this.AcceptButton = btnguardarpermiso;
            moverFormulario = new ClsArrastrarFormularios(this);

            _frmPanelUsuariosPadre = panelUsuariosPadre; // Guarda la referencia al formulario padre

            // Inmediatamente después de inicializar, configuro mi DataGridView para que muestre los permisos correctamente.
            ConfigurarDataGridView();
        }

        // Este método se ejecuta cuando el formulario se carga.
        private void frmPermisos_Load(object sender, EventArgs e)
        {
            // Cargo los usuarios en el ComboBox cuando el formulario está listo.
            CargarUsuarios();
        }

        // Este método me ayuda a configurar las columnas de mi DataGridView.
        private void ConfigurarDataGridView()
        {
            dgvPermisos.Columns.Clear(); // Primero limpio cualquier columna existente.
            dgvPermisos.AutoGenerateColumns = false; // Yo controlo las columnas, no dejo que se generen automáticamente.

            // Columna ID Permiso (oculta, la voy a usar internamente para identificar el permiso)
            dgvPermisos.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "colIdPermiso", // ¡Importante: usa el prefijo "col" y el nombre de la propiedad!
                HeaderText = "ID",
                DataPropertyName = "IdPermiso",
                Visible = false // La mantengo oculta para el usuario.
            });

            // Columna Nombre de la Funcionalidad (lo que el usuario ve)
            dgvPermisos.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "colFuncionalidad", // ¡Importante: usa el prefijo "col"!
                HeaderText = "Funcionalidad",
                DataPropertyName = "Nombre",
                ReadOnly = true, // El usuario no puede editar el nombre directamente.
            });

            // Columna Descripción (más detalles sobre la funcionalidad)
            dgvPermisos.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "colDescripcion", // ¡Importante: usa el prefijo "col"!
                HeaderText = "Descripción",
                DataPropertyName = "Descripcion",
                ReadOnly = true, // El usuario no puede editar la descripción.
            });

            // Columna Habilitado (un Checkbox para que el usuario active o desactive el permiso)
            dgvPermisos.Columns.Add(new DataGridViewCheckBoxColumn()
            {
                Name = "colHabilitado", // ¡Importante: usa el prefijo "col"!
                HeaderText = "Habilitado",
                DataPropertyName = "Habilitado",
                Width = 70, // Le doy un ancho fijo al checkbox.
                MinimumWidth = 70,
                // Resizable = DataGridViewTriState.False, // Esto no es necesario si AutoSizeColumnsMode.Fill está abajo
                ThreeState = false // Asegura que el checkbox solo tenga dos estados: marcado o desmarcado
            });

            // Columna HabilitadoPorRol (oculta, me sirve solo para mi lógica interna, para saber si el permiso viene del rol).
            // Para este formulario específico, no lo usaremos activamente, pero lo dejamos por si la ViewModel lo requiere.
            dgvPermisos.Columns.Add(new DataGridViewCheckBoxColumn()
            {
                Name = "colHabilitadoPorRol", // ¡Importante: usa el prefijo "col"!
                HeaderText = "HabilitadoPorRol",
                DataPropertyName = "HabilitadoPorRol",
                Visible = false // La mantengo oculta.
            });

            // Configuración general del DataGridView
            dgvPermisos.AllowUserToAddRows = false;    // Deshabilitar la fila para añadir nuevos registros
            dgvPermisos.AllowUserToDeleteRows = false; // Deshabilitar la eliminación de filas
            //dgvPermisos.SelectionMode = DataGridViewSelectionMode.FullRowSelect; // Seleccionar fila completa
            //dgvPermisos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; // Las columnas se ajustan al ancho

            dgvPermisos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvPermisos.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvPermisos.Refresh();

        }

        // Este método se encarga de cargar los usuarios en el ComboBox de usuarios.
        private void CargarUsuarios()
        {
            try
            {
                List<CD_UsuarioGestion> usuarios = _logicaPermisos.ObtenerUsuariosParaGestionar();
                List<CD_UsuarioGestion> usuariosParaComboBox = new List<CD_UsuarioGestion>();
                usuariosParaComboBox.Add(new CD_UsuarioGestion() { IdUsuario = 0, NombreUsuario = "-- Seleccione un Usuario --", IdRol = 0 });
                usuariosParaComboBox.AddRange(usuarios);

                cmbUsuarios.DataSource = usuariosParaComboBox;
                cmbUsuarios.DisplayMember = "NombreUsuario";
                cmbUsuarios.ValueMember = "IdUsuario";
                cmbUsuarios.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar usuarios: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbUsuarios.SelectedItem == null || (cmbUsuarios.SelectedItem is CD_UsuarioGestion selectedUser && selectedUser.IdUsuario == 0))
            {
                _idUsuarioSeleccionado = 0;
                dgvPermisos.DataSource = null; 
                return;
            }

            CD_UsuarioGestion usuarioSeleccionado = (CD_UsuarioGestion)cmbUsuarios.SelectedItem;
            _idUsuarioSeleccionado = usuarioSeleccionado.IdUsuario;

            try
            {
                List<DtoPermisoUsuario> permisos = _logicaPermisos.CargarPermisosDeUsuario(_idUsuarioSeleccionado);

                dgvPermisos.DataSource = permisos;

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar permisos del usuario: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dgvPermisos.DataSource = null;
            }
        }

        private void dgvpermisos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvPermisos.Columns["colHabilitado"].Index && e.RowIndex >= 0)
            {
                dgvPermisos.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (_idUsuarioSeleccionado == 0)
            {
                MessageBox.Show("Por favor, seleccione un usuario para guardar los permisos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {

                List<DtoPermisoUsuario> permisosACambiar = dgvPermisos.DataSource as List<DtoPermisoUsuario>;

                if (permisosACambiar == null || !permisosACambiar.Any())
                {
                    MessageBox.Show("No hay permisos para guardar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Llamamos al nuevo método de la capa lógica que maneja la actualización en lote para el usuario.
                // Asegúrate que tu _logicaPermisos.GuardarPermisosDeUsuario acepte List<CD_PermisoFuncionalidad>
                bool guardadoExitoso = _logicaPermisos.GuardarPermisosDeUsuario(_idUsuarioSeleccionado, permisosACambiar);

                if (guardadoExitoso)
                {
                    MessageBox.Show("Permisos del usuario guardados exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    // Recarga los permisos para reflejar cualquier cambio (aunque ya estén en la lista)
                    List<DtoPermisoUsuario> permisosRecargados = _logicaPermisos.CargarPermisosDeUsuario(_idUsuarioSeleccionado);
                    dgvPermisos.DataSource = permisosRecargados;
                }
                else
                {
                    MessageBox.Show("No se realizaron cambios en los permisos o ya estaban actualizados.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                if (_idUsuarioSeleccionado == ClsSesionActual.Usuario.Id_user)
                {
                    var dao = new CD_DaoUsuario();
                    ClsSesionActual.Usuario.Permisos = dao.ObtenerPermisosPorUsuario(_idUsuarioSeleccionado) ?? new List<string>();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al intentar guardar los permisos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void IdUsuario(object sender, EventArgs e)
        {

        }

        private void NombreUsuario(object sender, EventArgs e)
        {

        }

        private void frmPermisos_Shown(object sender, EventArgs e)
        {
            this.AcceptButton = btnguardarpermiso;
            this.ActiveControl = null;
        }

        private void pnlEscogerUsuario_Paint(object sender, PaintEventArgs e)
        {
            ClsDibujarBordes.DibujarRectangulo(sender as Control, e, Color.White, 1f);
        }
    }
}