using BE.Modelo;
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
    public partial class VisualizarAeronavesFormcs : Form
    {
        public VisualizarAeronavesFormcs()
        {
            InitializeComponent();
        }

        private void buttonCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridViewDiferidos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Diferido dmiseleccionado = (Diferido)dataGridViewDiferidos.CurrentRow.DataBoundItem;
            if (dmiseleccionado.estado) { txtEstado.Text = "Abierto"; } else { txtEstado.Text = "Cerrado"; }
            
        }
    }
}
