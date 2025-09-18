using Datos;
using Entidades;
using Entidades.DTOs;
using Logica;
using Sistema_Gestion_De_Usuarios;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;


namespace Vista
{
    public partial class frmPanelUsuarios : Form
    {
        private ClsArrastrarFormularios moverFormulario;
        private CL_Usuarios logicaUsuario = new CL_Usuarios();
        public frmPanelUsuarios()
        {
            InitializeComponent();

            this.Load += frmPanelUsuarios_Load;

            moverFormulario = new ClsArrastrarFormularios(this);
            moverFormulario.HabilitarMovimiento(pctBorde);
            moverFormulario.HabilitarMovimiento(lbltitulo);

            ClsFondoTransparente.Aplicar(
            pctFondo,
            btnGestionUsuarios,
            btnGestionPermisos,
            btnGestionValidaciones,
            btnRegistroClientes,
            btnCambiarContrasena,
            btnPreguntas,
            pctLogo,
            lblDiasRestantesContrasena);
        }

        private void frmPanelUsuarios_Load(object sender, EventArgs e)
        {
            this.BeginInvoke(new Action(() => this.ActiveControl = null));

            int diasRestantes = logicaUsuario.ObtenerDiasRestantesCambioContrasena(ClsSesionActual.Usuario.Id_user);

            // Si devuelve -1, significa que no aplica vencimiento (CambiaCada = 0)
            if (diasRestantes == -1)
            {
                lblDiasRestantesContrasena.Visible = false;
            }
            else if (diasRestantes > 0)
            {
                lblDiasRestantesContrasena.Text = $"Faltan {diasRestantes} días para cambiar su contraseña.";
                lblDiasRestantesContrasena.ForeColor = Color.White;
                lblDiasRestantesContrasena.Visible = true;
            }
            else // 0 o menos → vencida
            {
                lblDiasRestantesContrasena.Text = "Su contraseña ha expirado o debe cambiarla. ¡ACTUALICE AHORA!";
                lblDiasRestantesContrasena.ForeColor = Color.Red;
                lblDiasRestantesContrasena.Visible = true;
            }
            AjustarInterfazPorPermisos();
        }

        private void btnGestionUsuarios_Click(object sender, EventArgs e)
        {
            if (ClsSesionActual.Usuario.Permisos.Contains("Gestión de Usuarios"))
            {
                frmAdminUserABM frmalta = new frmAdminUserABM();
                frmalta.Show();
                this.Close();
            }
        }

        private void btnGestionPermisos_Click(object sender, EventArgs e)
        {
            if (ClsSesionActual.Usuario.Permisos.Contains("Gestión de Permisos"))
            {
                // Pasa 'this' (la instancia actual de frmPanelUsuarios) al constructor de frmPermisos
                frmPermisos mifrmPermisos = new frmPermisos(this); // <-- ¡Cambio clave aquí!
                mifrmPermisos.Show();
                this.Hide();
            }
        }

        private void btnGestionContraseñas_Click(object sender, EventArgs e)
        {
            if (ClsSesionActual.Usuario.Permisos.Contains("Gestión de Validaciones")) // El nombre del permiso es "Gestión de Validaciones"
            {
                frmSegContraseña frmSegContraseña = new frmSegContraseña();
                frmSegContraseña.Show();
                this.Hide();
            }
        }

        private void btnRegistroClientes_Click(object sender, EventArgs e)
        {
            if (ClsSesionActual.Usuario.Permisos.Contains("Registro de Clientes"))
            {
                frmRegistroClientes frmRegistro = new frmRegistroClientes();
                frmRegistro.Show();
                this.Hide();
            }
        }

        private void btnPreguntas_Click(object sender, EventArgs e)
        {
            if (ClsSesionActual.Usuario.Permisos.Contains("PreguntasSeguridad"))
            {
                frmPreguntas frmPreg = new frmPreguntas(this);
                frmPreg.Show();
                this.Hide();
            }
        }

        private void btnCambiarContrasena_Click(object sender, EventArgs e)
        {
            if (ClsSesionActual.Usuario.Permisos.Contains("Cambiar contraseña"))
            {
                string usuario = ClsSesionActual.Usuario.User;
                frmCambioPass frmCambio = new frmCambioPass(usuario, this, true);
                frmCambio.Show();
                this.Hide(); // Oculta el panel mientras se cambia la contraseña
            }
        }

        private void pctClose_Click(object sender, EventArgs e)
        {
            this.Close();
            FrmLoguin FrmLoguin = new FrmLoguin();
            FrmLoguin.Show();
        }

        private void pctMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void AjustarInterfazPorPermisos()
        {
            // Obtenemos el objeto del usuario de la sesión actual
            DtoUsuario usuarioActual = ClsSesionActual.ObtenerUsuario();

            // Verificamos si el objeto del usuario no es nulo
            if (usuarioActual != null && usuarioActual.Permisos != null)
            {
                // obtenemos la lista de permisos
                List<string> permisos = usuarioActual.Permisos;

                // Ocultamos todos los botones por defecto
                btnGestionUsuarios.Visible = false;
                btnGestionPermisos.Visible = false;
                btnGestionValidaciones.Visible = false;
                btnRegistroClientes.Visible = false;
                btnCambiarContrasena.Visible = false;
                btnPreguntas.Visible = false;
                btngestionstock.Visible = false;
                btnbackup.Visible = false;
                btnbitacora.Visible = false;
                btnmetricas.Visible = false;
                btncotizador.Visible = false;

                // Hacemos visibles solo los botones para los permisos que el usuario tiene
                if (permisos.Contains("Gestión de Usuarios"))
                {
                    btnGestionUsuarios.Visible = true;
                }
                if (permisos.Contains("Gestión de Permisos"))
                {
                    btnGestionPermisos.Visible = true;
                }
                if (permisos.Contains("Gestión de Validaciones"))
                {
                    btnGestionValidaciones.Visible = true;
                }
                if (permisos.Contains("Registro de Clientes"))
                {
                    btnRegistroClientes.Visible = true;
                }
                if (permisos.Contains("Cambiar contraseña"))
                {
                    btnCambiarContrasena.Visible = true;
                }
                if (permisos.Contains("PreguntasSeguridad"))
                {
                    btnPreguntas.Visible = true;
                }
                if (permisos.Contains("Gestion de stock y materiales"))
                {
                    btngestionstock.Visible = true;
                }
                if (permisos.Contains("Realizar BackUp"))
                {
                    btnbackup.Visible = true;
                }
                if (permisos.Contains("Bitacora"))
                {
                    btnbitacora.Visible = true;
                }
                if (permisos.Contains("Metricas"))
                {
                    btnmetricas.Visible = true;
                }
                if (permisos.Contains("Cotizador"))
                {
                    btncotizador.Visible = true;
                }
                // Instancia o accede a la clase de la capa Lógica (ajusta según tu arquitectura)
                // Suponiendo que la clase se llama "UsuarioBLL"
                CL_Usuarios logicaUsuario = new CL_Usuarios();

                // Obtenemos el Id_Rol desde la capa Lógica
                int idRol = logicaUsuario.ObtenerIdRolUsuario();

                // Ahora, en la capa de la vista, decidimos qué hacer con el valor del Id_Rol
                switch (idRol)
                {
                    case 1:
                        lbltitulo.Text = "Menu Administrador";
                        break;
                    case 2:
                        lbltitulo.Text = "Menu Vendedor";
                        break;
                    default:
                        // Para cualquier otro rol o en caso de error
                        lbltitulo.Text = "Menú Principal";
                        break;
                }
            }
        }



        private void btncotizador_Click(object sender, EventArgs e)
        {
            frmCotizador frmCotizador = new frmCotizador();
            frmCotizador.Show();
            this.Hide();
        }

        private void btngestionstock_Click(object sender, EventArgs e)
        {
            frmControlStock frm = new frmControlStock();
            this.Hide();
            frm.ShowDialog();
            this.Show();
        }

        private void btnmetricas_Click(object sender, EventArgs e)
        {
            frmReportes frmReportes = new frmReportes();
            frmReportes.Show();
            this.Hide();
        }
    }
}
