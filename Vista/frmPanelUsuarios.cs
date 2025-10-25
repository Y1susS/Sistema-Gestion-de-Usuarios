﻿using Datos;
using Entidades;
using Entidades.DTOs;
using Logica;
using Sistema_Gestion_de_Usuarios.Vista;
using Sistema_Gestion_De_Usuarios;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Vista.Lenguajes;



namespace Vista
{
    public partial class frmPanelUsuarios : Form
    {
        private FlowLayoutPanel subMenuPendiente = null;
        private Timer animacionTimer = new Timer();
        private FlowLayoutPanel subMenuAnimado = null;
        private int alturaObjetivo = 0;
        private bool expandiendo = false;
        private bool animando = false;

        private Button botonActivo = null;
        private Button botonPadreActivo = null;
        private Button botonHijoActivo = null;
        private FlowLayoutPanel subMenuAbierto = null;

        private Form formularioActual = null;

        private ClsArrastrarFormularios moverFormulario;

        private CL_Usuarios logicaUsuario = new CL_Usuarios();
        public frmPanelUsuarios()
        {
            InitializeComponent();
            Idioma.CargarIdiomaGuardado();
            Idioma.AplicarTraduccion(this);

            animacionTimer.Interval = 15; // velocidad de refresco (ms)
            animacionTimer.Tick += AnimacionTimer_Tick;

            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.UpdateStyles();

            moverFormulario = new ClsArrastrarFormularios(this);
            moverFormulario.HabilitarMovimiento(pnlBorde);
            moverFormulario.HabilitarMovimiento(lblmenuadmin);
        }

        private void SeleccionarBoton(Button boton)
        {
            if (boton == null)
                return;

            if (botonActivo != null && botonActivo != boton)
            {
                botonActivo.BackColor = Color.FromArgb(60, 60, 75);
                botonActivo.ForeColor = Color.White;
            }

            botonActivo = boton;
            botonActivo.BackColor = Color.FromArgb(0, 122, 204);
            botonActivo.ForeColor = Color.White;

            botonActivo.Refresh();
            Application.DoEvents();
        }

        private void OcultarTodosLosSubMenus()
        {
            flwGestionComercial.Visible = false;
            flwGestionSistema.Visible = false;
            flwInformes.Visible = false;
            flwSeguridad.Visible = false;
            subMenuAbierto = null;
        }

        private void AlternarSubMenu(FlowLayoutPanel subMenu)
        {
            if (subMenu == null) return;

            if (animando)
            {
                subMenuPendiente = subMenu;
                return;
            }

            // Si el submenú ya está abierto → cerrarlo
            if (subMenuAbierto == subMenu)
            {
                expandiendo = false;
                subMenuAnimado = subMenu;
                animando = true;
                animacionTimer.Start();
                return;
            }

            // Si hay otro submenú abierto → cerrarlo primero
            if (subMenuAbierto != null)
            {
                subMenuPendiente = subMenu;
                expandiendo = false;
                subMenuAnimado = subMenuAbierto;
                animando = true;
                animacionTimer.Start();
                return;
            }

            // Primer apertura: forzar altura inicial 0
            subMenu.Height = 0;               // <--- línea clave
            subMenu.Visible = true;
            alturaObjetivo = CalcularAlturaSubMenu(subMenu);
            subMenuAnimado = subMenu;
            expandiendo = true;
            animando = true;
            animacionTimer.Start();
        }

        private int CalcularAlturaSubMenu(FlowLayoutPanel subMenu)
        {
            int altura = 0;
            foreach (Control ctrl in subMenu.Controls)
            {
                altura += ctrl.Height; // solo la altura de los botones, sin márgenes
            }
            return altura;
        }

        private void AnimacionTimer_Tick(object sender, EventArgs e)
        {
            if (subMenuAnimado == null) return;

            int paso = 14;

            if (expandiendo)
            {
                subMenuAnimado.Height += paso;
                if (subMenuAnimado.Height >= alturaObjetivo)
                {
                    subMenuAnimado.Height = alturaObjetivo;
                    animacionTimer.Stop();
                    animando = false;
                    subMenuAbierto = subMenuAnimado;

                    // Si hay un submenú pendiente, abrirlo
                    if (subMenuPendiente != null && subMenuPendiente != subMenuAbierto)
                    {
                        FlowLayoutPanel pendiente = subMenuPendiente;
                        subMenuPendiente = null;
                        AlternarSubMenu(pendiente);
                    }
                }
            }
            else
            {
                subMenuAnimado.Height -= paso;
                if (subMenuAnimado.Height <= 0)
                {
                    subMenuAnimado.Height = 0;
                    subMenuAnimado.Visible = false;
                    animacionTimer.Stop();
                    animando = false;
                    subMenuAbierto = null;

                    // Si hay un submenú pendiente, abrirlo
                    if (subMenuPendiente != null)
                    {
                        FlowLayoutPanel pendiente = subMenuPendiente;
                        subMenuPendiente = null;
                        AlternarSubMenu(pendiente);
                    }
                }
            }
        }

        private void AbrirFormHijo(object formhijo)
        {
            // Cerrar y liberar el formulario anterior, si existe
            if (this.pnlContenedor.Controls.Count > 0)
            {
                Form formAnterior = this.pnlContenedor.Controls[0] as Form;
                if (formAnterior != null)
                {
                    formAnterior.Close();
                    formAnterior.Dispose();
                }

                // Verificar nuevamente antes de eliminar (por si el Close() ya lo quitó)
                if (this.pnlContenedor.Controls.Count > 0)
                {
                    this.pnlContenedor.Controls.RemoveAt(0);
                }
            }

            // Convertir el parámetro en formulario hijo
            Form fh = formhijo as Form;
            fh.TopLevel = false;
            fh.FormBorderStyle = FormBorderStyle.None;
            fh.Dock = DockStyle.Fill;

            // Agregar el formulario al contenedor
            this.pnlContenedor.Controls.Add(fh);
            this.pnlContenedor.Tag = fh;

            // Medidas de los paneles existentes
            int panelLateralAncho = pnlMenu?.Width ?? 0;
            int panelSuperiorAlto = pnlBorde?.Height ?? 0;
            int panelInferiorAlto = pnlBordeInferior?.Height ?? 0;

            // Tamaños del borde del formulario padre
            int bordeAncho = this.Width - this.ClientSize.Width;
            int bordeAlto = this.Height - this.ClientSize.Height;

            // Ajustar el tamaño del panel contenedor para que encaje con el hijo
            this.pnlContenedor.Width = fh.Width;
            this.pnlContenedor.Height = fh.Height;

            // Ajustar el tamaño del formulario padre tomando en cuenta todo
            this.Width = fh.Width + panelLateralAncho + bordeAncho;
            this.Height = fh.Height + panelSuperiorAlto + panelInferiorAlto + bordeAlto;

            // Posicionar el formulario hijo dentro del panel
            fh.Location = new Point(0, 0);
            fh.Show();

            this.pnlBorde.Invalidate();
            this.pnlBorde.Update();
            this.pctClose.Refresh();
        }

        private void frmPanelUsuarios_Load(object sender, EventArgs e)
        {
            OcultarTodosLosSubMenus();
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
                SeleccionarBoton((Button)sender);
                AbrirFormHijo(new frmAdminUserABM());
            }
        }

        private void btnGestionPermisos_Click(object sender, EventArgs e)
        {
            if (ClsSesionActual.Usuario.Permisos.Contains("Gestión de Permisos"))
            {
                SeleccionarBoton((Button)sender);
                AbrirFormHijo(new frmPermisos());
            }
        }

        private void btnGestionContraseñas_Click(object sender, EventArgs e)
        {
            if (ClsSesionActual.Usuario.Permisos.Contains("Gestión de Validaciones")) 
            {
                SeleccionarBoton((Button)sender);
                AbrirFormHijo(new frmSegContraseña());
            }
        }

        private void btnRegistroClientes_Click(object sender, EventArgs e)
        {
            if (ClsSesionActual.Usuario.Permisos.Contains("Registro de Clientes"))
            {
                SeleccionarBoton((Button)sender);
                AbrirFormHijo(new frmRegistroClientes());
            }
        }

        private void btnPreguntas_Click(object sender, EventArgs e)
        {
            if (ClsSesionActual.Usuario.Permisos.Contains("PreguntasSeguridad"))
            {
                SeleccionarBoton((Button)sender);
                AbrirFormHijo(new frmPreguntas());
            }
        }

        private void btnCambiarContrasena_Click(object sender, EventArgs e)
        {
            if (ClsSesionActual.Usuario.Permisos.Contains("Cambiar contraseña"))
            {
                SeleccionarBoton((Button)sender);
                AbrirFormHijo(new frmCambioPass());
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
                        lblmenuadmin.Text = "Menu Administrador";
                        break;
                    case 2:
                        lblmenuadmin.Text = "Menu Vendedor";
                        break;
                    default:
                        lblmenuadmin.Text = "Menú Principal";
                        break;
                }
            }
            //AjustarTamañoFormulario();
            //AjustarUltimoBoton();
            this.flwSeguridad.PerformLayout();

        }


        private void btncotizador_Click(object sender, EventArgs e)
        {
            SeleccionarBoton((Button)sender);
            AbrirFormHijo(new frmCotizador());
        }

        private void btngestionstock_Click(object sender, EventArgs e)
        {
            SeleccionarBoton((Button)sender);
            AbrirFormHijo(new frmControlStock());
        }

        private void btnmetricas_Click(object sender, EventArgs e)
        {
            SeleccionarBoton((Button)sender);
            AbrirFormHijo(new frmReportes());
        }

        private void btnbackup_Click(object sender, EventArgs e)
        {
            SeleccionarBoton((Button)sender);
            AbrirFormHijo(new frmBackUp());
        }

        private void btnEstadoVentas_Click(object sender, EventArgs e)
        {
            SeleccionarBoton((Button)sender);
            AbrirFormHijo(new frmEstadosVentas());
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
                SeleccionarBoton((Button)sender);
                AbrirFormHijo(new frmPresupuestador());
            }
        }

        private void frmPanelUsuarios_Shown(object sender, EventArgs e)
        {
            this.ActiveControl = null;
        }

        private void lblTitulo_Paint(object sender, PaintEventArgs e)
        {
            ClsDibujarBordes.DibujarLinea(sender as Control, e, ClsDibujarBordes.Lado.Inferior, Color.White, 1f);
        }

        private void pctMinimize_Paint(object sender, PaintEventArgs e)
        {
            ClsDibujarBordes.DibujarLinea(sender as Control, e, ClsDibujarBordes.Lado.Inferior, Color.White, 1f);
        }

        private void pctClose_Paint(object sender, PaintEventArgs e)
        {
            ClsDibujarBordes.DibujarLinea(sender as Control, e, ClsDibujarBordes.Lado.Inferior, Color.White, 1f);
        }

        private void pnlBordeInferior_Paint(object sender, PaintEventArgs e)
        {
            ClsDibujarBordes.DibujarLinea(sender as Control, e, ClsDibujarBordes.Lado.Superior, Color.White, 1f);
        }

        private void lblDiasRestantesContrasena_Paint(object sender, PaintEventArgs e)
        {
            ClsDibujarBordes.DibujarLinea(sender as Control, e, ClsDibujarBordes.Lado.Superior, Color.White, 1f);
            ClsDibujarBordes.DibujarLinea(sender as Control, e, ClsDibujarBordes.Lado.Derecho, Color.White, 1f);
        }

        private void pnlMenu_Paint(object sender, PaintEventArgs e)
        {
            ClsDibujarBordes.DibujarLinea(sender as Control, e, ClsDibujarBordes.Lado.Inferior, Color.White, 1f);
            ClsDibujarBordes.DibujarLinea(sender as Control, e, ClsDibujarBordes.Lado.Derecho, Color.White, 1f);
        }

        private void flwSeguridad_Paint(object sender, PaintEventArgs e)
        {
            ClsDibujarBordes.DibujarLinea(sender as Control, e, ClsDibujarBordes.Lado.Derecho, Color.White, 1f);
        }

        private void flwInformes_Paint(object sender, PaintEventArgs e)
        {
            ClsDibujarBordes.DibujarLinea(sender as Control, e, ClsDibujarBordes.Lado.Derecho, Color.White, 1f);
        }

        private void flwGestionSistema_Paint(object sender, PaintEventArgs e)
        {
            ClsDibujarBordes.DibujarLinea(sender as Control, e, ClsDibujarBordes.Lado.Derecho, Color.White, 1f);
        }

        private void flwGestionComercial_Paint(object sender, PaintEventArgs e)
        {
            ClsDibujarBordes.DibujarLinea(sender as Control, e, ClsDibujarBordes.Lado.Derecho, Color.White, 1f);
        }

        private void pnlLogo_Paint(object sender, PaintEventArgs e)
        {
            ClsDibujarBordes.DibujarLinea(sender as Control, e, ClsDibujarBordes.Lado.Derecho, Color.White, 1f);

        }

        private void btnGestionComercial_Click(object sender, EventArgs e)
        {
            AlternarSubMenu(flwGestionComercial);
        }

        private void btnGestionSistema_Click(object sender, EventArgs e)
        {
            AlternarSubMenu(flwGestionSistema);
        }

        private void btnInformes_Click(object sender, EventArgs e)
        {
            AlternarSubMenu(flwInformes);
        }

        private void btnSeguridad_Click(object sender, EventArgs e)
        {
            AlternarSubMenu(flwSeguridad);
        }

        private void btnSeguridad_Paint(object sender, PaintEventArgs e)
        {
            ClsDibujarBordes.DibujarLinea(sender as Control, e, ClsDibujarBordes.Lado.Derecho, Color.White, 1f);
        }

        private void btnGestionComercial_Paint(object sender, PaintEventArgs e)
        {
            ClsDibujarBordes.DibujarLinea(sender as Control, e, ClsDibujarBordes.Lado.Derecho, Color.White, 1f);
        }

        private void btnGestionSistema_Paint(object sender, PaintEventArgs e)
        {
            ClsDibujarBordes.DibujarLinea(sender as Control, e, ClsDibujarBordes.Lado.Derecho, Color.White, 1f);
        }

        private void btnInformes_Paint(object sender, PaintEventArgs e)
        {
            ClsDibujarBordes.DibujarLinea(sender as Control, e, ClsDibujarBordes.Lado.Derecho, Color.White, 1f);
        }

        private void btnbitacora_Click(object sender, EventArgs e)
        {
            SeleccionarBoton((Button)sender);
        }

        private void btnCotizaciones_Click(object sender, EventArgs e)
        {
            SeleccionarBoton((Button)sender);
        }
    }
}
