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

        }

        private void panelDeAdministraciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new PanelAdministrador();
            form.MdiParent = this;
            form.Show();
        }
    }
}
