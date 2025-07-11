using BE.Composite;
using BE.Modelo;
using BLL;
using BLL.Servicios;
using IU.Materiales;
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
    public partial class VisualizarPanolForm : Form
    {
        private readonly MaterialBLL materialBLL = new MaterialBLL();
        private readonly ConsumibleBLL consumibleBLL = new ConsumibleBLL();
        private readonly HerramientaBLL herramientaBLL = new HerramientaBLL();
        private readonly RotableBLL rotableBLL = new BLL.Servicios.RotableBLL();
        private readonly UsuarioBLL usuarioBLL = new UsuarioBLL();
        private List<ElementoVisualizable> elementos;

        public VisualizarPanolForm()
        {
            InitializeComponent();
        }

        private void VisualizarPanolForm_Load(object sender, EventArgs e)
        {
            CargarElementos();
        }

        private void CargarElementos()
        {
            var listaConsumibles = consumibleBLL.ListarConsumibles();
            var listaHerramientas = herramientaBLL.ListarHerramientas();
            var listaRotables = rotableBLL.ListarRotables();

            elementos = new List<ElementoVisualizable>();
            elementos.AddRange(listaConsumibles.Select(c => new ElementoVisualizable(c, "Consumible")));
            elementos.AddRange(listaHerramientas.Select(h => new ElementoVisualizable(h, "Herramienta")));
            elementos.AddRange(listaRotables.Select(r => new ElementoVisualizable(r, "Rotable")));

            dataGridViewComponentes.DataSource = elementos;
            dataGridViewComponentes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }


        private void buttonEntregar_Click(object sender, EventArgs e)
        {
            if (dataGridViewComponentes.CurrentRow == null) return;
            var elem = (ElementoVisualizable)dataGridViewComponentes.CurrentRow.DataBoundItem;

            string receptor;
            int cantidad;
            var emisor = SesionUsuario.Instancia.UsuarioActual.id;

            using (var dlg = new SeleccionarReceptorForm(elem))
            {
                if (dlg.ShowDialog(this) != DialogResult.OK) return;
                receptor = dlg.idUsuarioSeleccionado;
                cantidad = dlg.cantidadSolicitada;
            }

            try
            {
                materialBLL.EntregarElemento(elem, cantidad, emisor, receptor);
                MessageBox.Show("Elemento entregado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarElementos();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al entregar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bttnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}
