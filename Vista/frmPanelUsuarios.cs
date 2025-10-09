using Datos;
using Entidades;
using Entidades.DTOs;
using Logica;
using Sistema_Gestion_De_Usuarios;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;



namespace Vista
{
    public partial class frmPanelUsuarios : Form
    {
        private ClsArrastrarFormularios moverFormulario;
        private CL_Usuarios logicaUsuario = new CL_Usuarios();
        public frmPanelUsuarios()
        {
            InitializeComponent();

            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.UpdateStyles();

            moverFormulario = new ClsArrastrarFormularios(this);
            moverFormulario.HabilitarMovimiento(pnlBorde);
            moverFormulario.HabilitarMovimiento(lbltitulo);
        }
        private void AjustarTamañoFormulario()
        {
            int cantBotonesVisibles = flwBotones.Controls.Cast<Control>()
                                  .Count(c => c.Visible);

            switch (cantBotonesVisibles)
            {
                case 0:
                case 1:
                    this.Height = 275;
                    break;
                case 2:
                    this.Height = 325;
                    break;
                case 3:
                    this.Height = 375;
                    break;
                case 4:
                    this.Height = 425;
                    break;
                case 5:
                    this.Height = 475;
                    break;
                case 6:
                    this.Height = 525;
                    break;
                case 7:
                    this.Height = 415;
                    break;
                case 8:
                    this.Height = 415;
                    break;
                case 9:
                    this.Height = 465;
                    break;
                case 10:
                    this.Height = 465;
                    break;
                default:
                    break;
            }

            if (cantBotonesVisibles <= 6)
            {
                flwBotones.Width = 185;
                flwBotones.Height = 285;
                flwBotones.Location = new Point(105, 175);
            }
        }

        private void AjustarUltimoBoton()
        {
            int cantBotonesVisibles = flwBotones.Controls.Cast<Control>().Count(c => c.Visible);

            if (cantBotonesVisibles > 6)
            {
                int columnas = 2;
                int botonesUltimaFila = cantBotonesVisibles % columnas;
                if (botonesUltimaFila == 1)
                {
                    var btnUltimo = flwBotones.Controls
                                      .OfType<Button>()
                                      .Where(b => b.Visible)
                                      .Last();

                    btnUltimo.Width = 362;
                    btnUltimo.Height = 35;
                }
            }
        }

        private void frmPanelUsuarios_Load(object sender, EventArgs e)
        {
            this.BeginInvoke(new Action(() => this.ActiveControl = null));

            int diasRestantes = logicaUsuario.ObtenerDiasRestantesCambioContrasena(ClsSesionActual.Usuario.Id_user);

            if (diasRestantes == -1)
            {
                lblDiasRestantesContrasena.Visible = false;
            }
            else if (diasRestantes > 0)
            {
                lblDiasRestantesContrasena.Text = $"Faltan {diasRestantes} días para cambiar su contraseña";
                lblDiasRestantesContrasena.ForeColor = Color.White;
                lblDiasRestantesContrasena.Visible = true;
            }
            else 
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
                this.Close();
                frmAdminUserABM frmAdminUserABM = new frmAdminUserABM();
                frmAdminUserABM.Show();
            }
        }

        private void btnGestionPermisos_Click(object sender, EventArgs e)
        {
            if (ClsSesionActual.Usuario.Permisos.Contains("Gestión de Permisos"))
            {
                this.Close();
                frmPermisos frmPermisos = new frmPermisos(this); 
                frmPermisos.Show();
            }
        }

        private void btnGestionContraseñas_Click(object sender, EventArgs e)
        {
            if (ClsSesionActual.Usuario.Permisos.Contains("Gestión de Validaciones")) 
            {
                this.Close();
                frmSegContraseña frmSegContraseña = new frmSegContraseña();
                frmSegContraseña.Show();
            }
        }

        private void btnRegistroClientes_Click(object sender, EventArgs e)
        {
            if (ClsSesionActual.Usuario.Permisos.Contains("Registro de Clientes"))
            {
                this.Close();
                frmRegistroClientes frmRegistroClientes = new frmRegistroClientes();
                frmRegistroClientes.Show();
            }
        }

        private void btnPreguntas_Click(object sender, EventArgs e)
        {
            if (ClsSesionActual.Usuario.Permisos.Contains("PreguntasSeguridad"))
            {
                this.Close();
                frmPreguntas frmPreguntas = new frmPreguntas(this);
                frmPreguntas.Show();
            }
        }

        private void btnCambiarContrasena_Click(object sender, EventArgs e)
        {
            if (ClsSesionActual.Usuario.Permisos.Contains("Cambiar contraseña"))
            {
                this.Close();
                string usuario = ClsSesionActual.Usuario.User;
                frmCambioPass frmCambioPass = new frmCambioPass(usuario, this, true);
                frmCambioPass.Show();
            }
        }

        private void AjustarInterfazPorPermisos()
        {
            DtoUsuario usuarioActual = ClsSesionActual.ObtenerUsuario();

            if (usuarioActual != null && usuarioActual.Permisos != null)
            {
                List<string> permisos = usuarioActual.Permisos;

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
                btnPresupuestador.Visible = false;


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
                if (permisos.Contains("Presupuestador")) 
                {
                    btnPresupuestador.Visible = true;
                }

                CL_Usuarios logicaUsuario = new CL_Usuarios();

                int idRol = logicaUsuario.ObtenerIdRolUsuario();

                switch (idRol)
                {
                    case 1:
                        lbltitulo.Text = "Menu Administrador";
                        break;
                    case 2:
                        lbltitulo.Text = "Menu Vendedor";
                        break;
                    default:
                        lbltitulo.Text = "Menú Principal";
                        break;
                }
            }
            AjustarTamañoFormulario();
            AjustarUltimoBoton();
            this.flwBotones.PerformLayout();

        }


        private void btncotizador_Click(object sender, EventArgs e)
        {
            this.Close();
            frmCotizador frmCotizador = new frmCotizador();
            frmCotizador.Show();
        }

        private void btngestionstock_Click(object sender, EventArgs e)
        {
            this.Close();
            frmControlStock frmControlStock = new frmControlStock();
            frmControlStock.Show();
        }

        private void btnmetricas_Click(object sender, EventArgs e)
        {
            this.Close();
            frmReportes frmReportes = new frmReportes();
            frmReportes.Show();
        }

        private void btnbackup_Click(object sender, EventArgs e)
        {
            this.Close();
            frmBackUp frmBackUp = new frmBackUp();
            frmBackUp.Show();
        }

        private void btnEstadoVentas_Click(object sender, EventArgs e)
        {
            this.Close();
            frmEstadosVentas frmEstadosVentas = new frmEstadosVentas();
            frmEstadosVentas.Show();
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

        private void btnPresupuestador_Click(object sender, EventArgs e)
        {
            if (ClsSesionActual.Usuario.Permisos.Contains("Presupuestador")) 
            {
                this.Close();
                frmPresupuestador frmPresupuestador = new frmPresupuestador();
                frmPresupuestador.Show();
            }
        }

        private void frmPanelUsuarios_Shown(object sender, EventArgs e)
        {
            this.ActiveControl = null;
        }
    }
}
