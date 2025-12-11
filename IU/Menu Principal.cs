using BE.Composite;
using BLL;
using BLL.Roles;
using BLL.Servicios;
using IU.ALTERNATIVO;
using Presentacion_IU;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IU
{
    public partial class Menu : Form
    {
        private readonly MaterialBLL materialBLL = new MaterialBLL();

        public Menu()
        {
            InitializeComponent();
            AplicarPermisosAlMenu();
        }
        private void AplicarPermisosAlMenu()
        {
            var usuarioActual = SesionUsuario.Instancia.UsuarioActual;
            
            panelDeAdministraciónToolStripMenuItem.Enabled = SesionUsuario.Instancia.IsInRole(TipoPermisoBE.Permisos_Panel_Administrador);

            dashboardToolStripMenuItem.Enabled = SesionUsuario.Instancia.IsInRole(TipoPermisoBE.Ver_Dashboard);

            trabajosToolStripMenuItem.Enabled = SesionUsuario.Instancia.IsInRole(TipoPermisoBE.Crear_Trabajo) || SesionUsuario.Instancia.IsInRole(TipoPermisoBE.Eliminar_Trabajo);
            crearTrabajoToolStripMenuItem.Enabled = SesionUsuario.Instancia.IsInRole(TipoPermisoBE.Crear_Trabajo);
            eliminarTrToolStripMenuItem.Enabled = SesionUsuario.Instancia.IsInRole(TipoPermisoBE.Eliminar_Trabajo);

            ordenesDeTrabajoToolStripMenuItem.Enabled = SesionUsuario.Instancia.IsInRole(TipoPermisoBE.Crear_Orden_De_Trabajo)
                || SesionUsuario.Instancia.IsInRole(TipoPermisoBE.Visualizar_OT) || SesionUsuario.Instancia.IsInRole(TipoPermisoBE.Eliminar_OT) || SesionUsuario.Instancia.IsInRole(TipoPermisoBE.Ejecutar_OT);

            crearOrdenDeTrabajoToolStripMenuItem.Enabled = SesionUsuario.Instancia.IsInRole(TipoPermisoBE.Crear_Orden_De_Trabajo);
            visualizarOrdenDeTrabajoToolStripMenuItem.Enabled = SesionUsuario.Instancia.IsInRole(TipoPermisoBE.Visualizar_OT);
            eliminarOrdenDeTrabajoToolStripMenuItem.Enabled = SesionUsuario.Instancia.IsInRole(TipoPermisoBE.Eliminar_OT);


            aeronavesToolStripMenuItem.Enabled = SesionUsuario.Instancia.IsInRole(TipoPermisoBE.Consultar_Aeronaves);
            consultarAToolStripMenuItem.Enabled = SesionUsuario.Instancia.IsInRole(TipoPermisoBE.Consultar_Aeronaves);

            abrirDiferidoToolStripMenuItem.Enabled = SesionUsuario.Instancia.IsInRole(TipoPermisoBE.Abrir_Diferido);

            pañolToolStripMenuItem.Enabled = SesionUsuario.Instancia.IsInRole(TipoPermisoBE.Crear_Herramienta) || SesionUsuario.Instancia.IsInRole(TipoPermisoBE.Crear_Rotable) || SesionUsuario.Instancia.IsInRole(TipoPermisoBE.Cargar_Consumible);
            crearHerramientaToolStripMenuItem.Enabled = SesionUsuario.Instancia.IsInRole(TipoPermisoBE.Crear_Herramienta);
            crearRotableToolStripMenuItem.Enabled = SesionUsuario.Instancia.IsInRole(TipoPermisoBE.Crear_Rotable);
            cargarConsumibleToolStripMenuItem.Enabled = SesionUsuario.Instancia.IsInRole(TipoPermisoBE.Cargar_Consumible);

            generarNOSTOCKToolStripMenuItem.Enabled = SesionUsuario.Instancia.IsInRole(TipoPermisoBE.Generar_NoStock);
            visualizarToolStripMenuItem.Enabled = SesionUsuario.Instancia.IsInRole(TipoPermisoBE.Visualizar_Elemento);

            logisticaToolStripMenuItem.Enabled = SesionUsuario.Instancia.IsInRole(TipoPermisoBE.Generar_NoStock) || SesionUsuario.Instancia.IsInRole(TipoPermisoBE.Consultar_Solicitudes);
            consultarSolicitudesToolStripMenuItem.Enabled = SesionUsuario.Instancia.IsInRole(TipoPermisoBE.Consultar_Solicitudes);
        }
        private void dashboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form dashboard = new Dashboard();
            dashboard.MdiParent = this;
            dashboard.Show();
        }

        private void panelDeAdministraciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form paneladmin = new PanelAdmininistrador();
            paneladmin.MdiParent = this;
            paneladmin.Show();
        }

        private void crearTrabajoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form creartrform = new CrearTrabajoForm();
            creartrform.MdiParent = this;
            creartrform.Show();
        }


        private void crearOrdenDeTrabajoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form crearOTform = new CrearOTForm();
            crearOTform.MdiParent = this;
            crearOTform.Show();
        }

        private void visualizarOrdenDeTrabajoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form visualizarform = new VisualizarOT();
            visualizarform.MdiParent = this;
            visualizarform.Show();
        }

        private void consultarAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form visualizarAeronaves = new VisualizarAeronavesFormcs();
            visualizarAeronaves.MdiParent = this;
            visualizarAeronaves.Show();
        }

        private void eliminarOrdenDeTrabajoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form eliminarOTform = new EliminarOT();
            eliminarOTform.MdiParent = this;
            eliminarOTform.Show();
        }

        private void eliminarTrToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form eliminarTr = new EliminarTrForm();
            eliminarTr.MdiParent = this;
            eliminarTr.Show();
        }

        private void abrirDiferidoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form abrirDMIForm = new AbrirDMIForm();
            abrirDMIForm.MdiParent = this;
            abrirDMIForm.Show();    
        }

        private void cargarConsumibleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form cargarConsumible = new CargarConsumibleForm();
            cargarConsumible.MdiParent = this;
            cargarConsumible.Show();
        }

        private void crearRotableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CrearRotableForm crearRotableForm = new CrearRotableForm();
            crearRotableForm.MdiParent = this;
            crearRotableForm.Show();
        }

        private void crearHerramientaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CrearHerramienta crearHerramienta = new CrearHerramienta();
            crearHerramienta.MdiParent= this;
            crearHerramienta.Show();
        }

        private void generarNOSTOCKToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GenerarNoStockForm generarNoStockForm = new GenerarNoStockForm();
            generarNoStockForm.MdiParent = this;
            generarNoStockForm.Show();
        }

        private void visualizarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VisualizarPanolForm visualizarPanolForm = new VisualizarPanolForm();
            visualizarPanolForm.MdiParent = this;
            visualizarPanolForm.Show();
        }

        private void consultarSolicitudesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SolicitudesForm solicitudesForm = new SolicitudesForm();
            solicitudesForm.MdiParent = this;   
            solicitudesForm.Show();
        }

        private void cerrarSesionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var confirmar = MessageBox.Show("¿Está seguro que desea cerrar sesión?", "Confirmar salida",MessageBoxButtons.YesNo,MessageBoxIcon.Question);

            if (confirmar != DialogResult.Yes) return;

            SesionUsuario.CerrarSesion();

            var loginForm = new Login();
            loginForm.Show();

            this.Close();
        }

        private void pañolToolStripMenuItem_Click(object sender, EventArgs e)
        {
            materialBLL.ActualizarDisponibilidadPorVencimiento();
        }
    }
}
