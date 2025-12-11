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
        private readonly RotableBLL rotableBLL = new RotableBLL();
        private readonly UsuarioBLL usuarioBLL = new UsuarioBLL();
        private List<ElementoVisualizable> elementos;
        private readonly Dashboard dashboard = new Dashboard();


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

            dashboard.OcultarColumnas(dataGridViewComponentes, "ElementoOriginal");
        }

        private void buttonEntregar_Click(object sender, EventArgs e)
        {
            string receptor;
            int cantidad;
            var emisor = SesionUsuario.Instancia.UsuarioActual.id;
            
            if (dataGridViewComponentes.CurrentRow == null) return;
            var elem = (ElementoVisualizable)dataGridViewComponentes.CurrentRow.DataBoundItem;
            
            if (elem.EstaVencido)
            {
                MessageBox.Show("Este elemento está vencido y no puede ser entregado.",
                                "Elemento vencido",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return;
            }

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

        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            var filtro = txtBusqueda.Text.ToLower();
            var elementosFiltrados = elementos.Where(elem =>
                elem.Id.ToLower().Contains(filtro) ||
                elem.PartNumber.ToLower().Contains(filtro) ||
                elem.Descripcion.ToLower().Contains(filtro) ||
                elem.Tipo.ToLower().Contains(filtro)
            ).ToList();
            dataGridViewComponentes.DataSource = elementosFiltrados;
        }

        private void bttnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dataGridViewComponentes_MarcarVencidos(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            var fila = dataGridViewComponentes.Rows[e.RowIndex];

            if (fila.DataBoundItem is ElementoVisualizable elem)
            {
                if (elem.EstaVencido)
                {
                    fila.DefaultCellStyle.BackColor = Color.LightCoral;
                }
                else
                {
                    fila.DefaultCellStyle.BackColor = Color.White;
                }
            }
        }

    }
}
