using BE.Modelo;
using BLL.Servicios;
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
    public partial class VisualizarOT : Form
    {
        private OrdenDeTrabajo ordenSeleccionada;

        public VisualizarOT()
        {
            InitializeComponent();
            CargarOTs();
        }

        private void CargarOTs()
        {
            try
            {
                OrdenDeTrabajoBLL otBll = new OrdenDeTrabajoBLL();
                List<OrdenDeTrabajo> listaOTs = otBll.ListarOrdenes().Where(ot => !string.Equals(ot.estado, "Completada", StringComparison.OrdinalIgnoreCase)).ToList();

                dgvOTs.AutoGenerateColumns = true;
                dgvOTs.DataSource = listaOTs;

                dgvOTs.Columns["trabajo"].Visible = false;

                foreach (DataGridViewColumn col in dgvOTs.Columns)
                {
                    col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las órdenes de trabajo: " + ex.Message);
            }
        }

        private void dgvOTs_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) ordenSeleccionada = (OrdenDeTrabajo)dgvOTs.Rows[e.RowIndex].DataBoundItem;
        }

        private void buttonVisualizarOT_Click(object sender, EventArgs e)
        {
            if (ordenSeleccionada != null)
            {
                Form verOT = new OrdenDeTrabajoForm(ordenSeleccionada); 
                verOT.MdiParent = this.MdiParent;
                verOT.Show();
            }
            else
            {
                MessageBox.Show("Seleccione una orden de trabajo primero.");
            }
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Close();
        }

    }

}
