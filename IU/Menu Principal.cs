using BLL;
using BLL.Servicios;
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
        public Menu()
        {
            InitializeComponent();
            AplicarPermisosAlMenu();
        }

        private void AplicarPermisosAlMenu()
        {
            var usuarioActual = SesionUsuario.Instancia.UsuarioActual;
            var permisos = UsuarioBLL.ObtenerPermisosEfectivos(usuarioActual)
                .Select (p => p.designacion)
                .ToList();

            dashboardToolStripMenuItem.Visible = permisos.Contains("Ver_Dashboard");

            trabajosToolStripMenuItem.Visible = permisos.Contains("Crear_Trabajo") || permisos.Contains("Eliminar_Trabajo");
            crearTrabajoToolStripMenuItem.Visible = permisos.Contains("Crear_Trabajo");
            eliminarTrToolStripMenuItem.Visible = permisos.Contains("Eliminar_Trabajo"); 

            ordenesDeTrabajoToolStripMenuItem.Visible = permisos.Contains("Crear_Orden_De_Trabajo")
                || permisos.Contains("Visualizar_OT") || permisos.Contains("Eliminar_OT") || permisos.Contains("Ejecutar_OT");

            crearOrdenDeTrabajoToolStripMenuItem.Visible = permisos.Contains("Crear_Orden_De_Trabajo");
            visualizarOrdenDeTrabajoToolStripMenuItem.Visible = permisos.Contains("Visualizar_OT");
            eliminarOrdenDeTrabajoToolStripMenuItem.Visible = permisos.Contains("Eliminar_OT");

            panelDeAdministraciónToolStripMenuItem.Visible = permisos.Contains("Permisos_Panel_Administrador");

            aeronavesToolStripMenuItem.Visible = permisos.Contains("Consultar_Aeronaves");
            consultarAToolStripMenuItem.Visible = permisos.Contains("Consultar_Aeronaves");

            abrirDiferidoToolStripMenuItem.Visible = permisos.Contains("Abrir_Diferido");

            pañolToolStripMenuItem.Visible = permisos.Contains("Crear_Herramienta") || permisos.Contains("Crear_Rotable") || permisos.Contains("Cargar_Consumible");
            crearHerramientaToolStripMenuItem.Visible = permisos.Contains("Crear_Herramienta");
            crearRotableToolStripMenuItem.Visible = permisos.Contains("Crear_Rotable");
            cargarConsumibleToolStripMenuItem.Visible = permisos.Contains("Cargar_Consumible");

            generarNOSTOCKToolStripMenuItem.Visible = permisos.Contains("Generar_NoStock");
            visualizarToolStripMenuItem.Visible = permisos.Contains("Visualizar_Elemento");

            logisticaToolStripMenuItem.Visible = permisos.Contains("Generar_NoStock") || permisos.Contains("Consultar_Solicitudes");
            consultarSolicitudesToolStripMenuItem.Visible = permisos.Contains("Consultar_Solicitudes");

        }

        private void dashboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form dashboard = new Dashboard();
            dashboard.MdiParent = this;
            dashboard.Show();
        }

        private void panelDeAdministraciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form paneladmin = new PanelAdministrador();
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
    }
}
