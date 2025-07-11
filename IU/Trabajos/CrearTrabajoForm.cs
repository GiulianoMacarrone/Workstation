using BE.Modelo;
using BLL;
using BLL.Roles;
using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion_IU
{
    public partial class CrearTrabajoForm : Form
    {
        public CrearTrabajoForm()
        {
            InitializeComponent();
        }
        private void CrearTrabajoForm_Load(object sender, EventArgs e)
        {

            ConfigurarDgvMateriales();
            ConfigurarDgvHerramientas();
        }

        private void buttonAddTask_Click(object sender, EventArgs e)
        {
            string tarea = richTextBoxTasks.Text.Trim();
            if (!string.IsNullOrEmpty(tarea))
            {
                dgvTask.Rows.Add(tarea);
                richTextBoxTasks.Clear();
            }
            foreach (DataGridViewColumn column in dgvTask.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
        }

        private void buttonCrear_Click(object sender, EventArgs e)
        {
            //asignar Nro de trabajo automaticamente
            string titulo = txtTitulo.Text.Trim();
            string descripcion = txtDescripcion.Text.Trim();
            string intervalo = txtIntervalo.Text.Trim();
            string referencias = txtReferencias.Text.Trim();
            string nota = txtNota.Text.Trim();

            List<ItemOTBE> listaMaterialOT = new List<ItemOTBE>();
            foreach (DataGridViewRow row in dgvMateriales.Rows)
            {
                if (row.IsNewRow) continue;
                var pn = row.Cells["PN"].Value?.ToString();
                var desc = row.Cells["Descripcion"].Value?.ToString();
                int qty = 0;
                int.TryParse(row.Cells["QTY"].Value?.ToString(), out qty);
                if (!string.IsNullOrWhiteSpace(pn) || !string.IsNullOrWhiteSpace(desc))
                    listaMaterialOT.Add(new ItemOTBE { PN = pn, Descripcion = desc, QTY = qty });

            }

            List<ItemOTBE> listaHerramientaOT = new List<ItemOTBE>();
            foreach (DataGridViewRow row in dgvHerramientas.Rows)
            {
                if (row.IsNewRow) continue;
                var pn = row.Cells["PN"].Value?.ToString();
                var desc = row.Cells["Descripcion"].Value?.ToString();
                int qty = 0;
                int.TryParse(row.Cells["QTY"].Value?.ToString(), out qty);
                if (!string.IsNullOrWhiteSpace(pn) || !string.IsNullOrWhiteSpace(desc))
                    listaHerramientaOT.Add(new ItemOTBE { PN = pn, Descripcion = desc, QTY = qty });

            }

            List<string> tareas = new List<string>();
            foreach (DataGridViewRow row in dgvTask.Rows)
            {
                if (row.IsNewRow) continue;
                var cellValue = row.Cells[0].Value;
                if (cellValue != null)
                    tareas.Add(cellValue.ToString());
                
            }
            

            TrabajoBE nuevoTrabajo = new TrabajoBE
            {
                titulo = titulo,
                descripcion = descripcion,
                intervalo = intervalo,
                referencias = referencias,
                nota = nota,
                listaMateriales = listaMaterialOT,
                listaHerramientas = listaHerramientaOT,
                listaTareas = tareas
            };

            try
            {
                var trabajoBll = new TrabajoBLL();
                trabajoBll.CrearTrabajo(nuevoTrabajo);

                MessageBox.Show("Trabajo creado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al crear Trabajo: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigurarDgvMateriales()
        {
            dgvMateriales.Columns.Clear();
            dgvMateriales.AllowUserToAddRows = true;
            dgvMateriales.AllowUserToDeleteRows = true;
            dgvMateriales.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF2;
            dgvMateriales.Columns.Add("PN", "P/N");
            dgvMateriales.Columns.Add("Descripcion", "Descripción");
            dgvMateriales.Columns.Add("QTY", "QTY");
            dgvMateriales.Columns["QTY"].ValueType = typeof(int);
        }

        private void ConfigurarDgvHerramientas()
        {
            dgvHerramientas.Columns.Clear();
            dgvHerramientas.AllowUserToAddRows = true;
            dgvHerramientas.AllowUserToDeleteRows = true;
            dgvHerramientas.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF2;
            dgvHerramientas.Columns.Add("PN", "P/N");
            dgvHerramientas.Columns.Add("Descripcion", "Descripción");
            dgvHerramientas.Columns.Add("QTY", "QTY");
            dgvHerramientas.Columns["QTY"].ValueType = typeof(int);
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

