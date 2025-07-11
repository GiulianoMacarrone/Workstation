using BE.Modelo;
using BLL.Roles;
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
    public partial class EliminarOT : Form
    {
        private readonly OrdenDeTrabajoBLL otBLL = new OrdenDeTrabajoBLL();
        private List<OrdenDeTrabajo> listaOT;
        public EliminarOT()
        {
            InitializeComponent();
            Load += EliminarOT_Load;
        }

        private void buttonEliminar_Click(object sender, EventArgs e)
        {
            if (dgvOTsinRealizar.CurrentRow == null)
            {
                MessageBox.Show("Seleccione una orden de trabajo para eliminar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var ot = (OrdenDeTrabajo)dgvOTsinRealizar.CurrentRow.DataBoundItem;

            var resp = MessageBox.Show($"¿Confirma eliminar la OT #({ot.numeroOT})?", "Confirmar eliminación", MessageBoxButtons.YesNo,MessageBoxIcon.Question);

            if (resp != DialogResult.Yes)
                return;

            try
            {
                otBLL.EliminarOT(ot);

                MessageBox.Show("Orden de trabajo eliminada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                CargarOTs();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al eliminar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void EliminarOT_Load(object sender, EventArgs e)
        {
            CargarOTs();
        }

        private void CargarOTs()
        {
            listaOT = otBLL.ListarOrdenes().Where(o => o.estado == "Pendiente").ToList();

            dgvOTsinRealizar.DataSource = null;
            dgvOTsinRealizar.DataSource = listaOT;
        }


    }
}
