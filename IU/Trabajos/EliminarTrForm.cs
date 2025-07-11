using BE.Modelo;
using BLL.Roles;
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
    public partial class EliminarTrForm : Form
    {
        private readonly TrabajoBLL trabajoBLL = new TrabajoBLL();
        private List<TrabajoBE> listaTrabajos;
        public EliminarTrForm()
        {
            InitializeComponent();
            Load += EliminarTrForm_Load;
        }
        private void EliminarTrForm_Load(object sender, EventArgs e)
        {
            CargarTrabajos();
        }

        private void CargarTrabajos()
        {
            listaTrabajos = trabajoBLL.ListarTrabajos();
            dgvTrabajos.DataSource = null;
            dgvTrabajos .DataSource = listaTrabajos;

            if (dgvTrabajos.Columns["Id"] != null) dgvTrabajos.Columns["Id"].Visible = false;

            if (dgvTrabajos.Columns["nroTrabajo"] != null)dgvTrabajos.Columns["nroTrabajo"].Visible = false;

        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonEliminar_Click(object sender, EventArgs e)
        {
            if (dgvTrabajos.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un trabajo para eliminar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var trabajo = (TrabajoBE)dgvTrabajos.CurrentRow.DataBoundItem;
            var resp = MessageBox.Show($"¿Confirma eliminar el trabajo #{trabajo.id}?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resp != DialogResult.Yes) return;

            try
            {
                trabajoBLL.EliminarTrabajo(trabajo.id);
                MessageBox.Show("Trabajo eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                CargarTrabajos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al eliminar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
