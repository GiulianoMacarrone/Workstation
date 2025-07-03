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
    }
}
