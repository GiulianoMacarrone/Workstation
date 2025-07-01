using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BE.Modelo;
using BLL;
using BLL.Roles;

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
        }

        private void buttonCrear_Click(object sender, EventArgs e)
        {
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

            // Crear el objeto Trabajo
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

            // Pasar el objeto a la capa de negocio (BLL)
            try
            {
                var trabajoBll = new TrabajoBLL();
                trabajoBll.CrearTrabajo(nuevoTrabajo);

                MessageBox.Show("Orden de Trabajo creada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al crear la Orden de Trabajo: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // Pseudocódigo detallado:
        // 1. Configurar dos DataGridView: dgvMateriales y dgvHerramientas.
        // 2. Cada DataGridView debe tener columnas: "P/N", "Descripción", "QTY".
        // 3. Permitir edición directa de celdas (propiedad ReadOnly = false).
        // 4. Opcional: Agregar botón para añadir filas vacías.
        // 5. Al crear la OT, recorrer cada DataGridView y obtener los datos en listas de objetos.
        // 6. Modificar la clase OT para que Materiales y Herramientas sean listas de objetos con P/N, Descripción y QTY.

        // 1. Agrega en el diseñador dos DataGridView: dgvMateriales y dgvHerramientas.
        // 2. Configura las columnas en el constructor o en el Load del formulario:

        private void ConfigurarDgvTask()
        {
            dgvTask.Columns.Clear();
            dgvTask.AllowUserToAddRows = false;
            dgvTask.AllowUserToResizeRows = true;
            dgvTask.AllowUserToDeleteRows = true;
            dgvTask.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF2;
            dgvTask.Columns.Add("Tarea", "Tarea");
            dgvTask.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgvTask.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
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

    }
}


/* 5. Al crear la OT, obtén los datos de los DataGridView:
private void (object sender, EventArgs e)
                {
                    string titulo = txtTitulo.Text.Trim();
                    string descripcion = txtDescripcion.Text.Trim();
                    string intervalo = txtIntervalo.Text.Trim();
                    string referencias = txtReferencias.Text.Trim();
                    string nota = txtNota.Text.Trim();

                    List<string> tareas = new List<string>();
                    foreach (DataGridViewRow row in dgvTask.Rows)
                    {
                        if (row.IsNewRow) continue;
                        var cellValue = row.Cells[0].Value;
                        if (cellValue != null)
                            tareas.Add(cellValue.ToString());
                    }

                    List<ItemOT> materiales = new List<ItemOT>();
                    foreach private void buttonCrear_Click_1(object sender, EventArgs e)
        {

        }(DataGridViewRow row in dgvMateriales.Rows)
                    {
                        if (row.IsNewRow) continue;
                        var pn = row.Cells["PN"].Value?.ToString();
                        var desc = row.Cells["Descripcion"].Value?.ToString();
                        int qty = 0;
                        int.TryParse(row.Cells["QTY"].Value?.ToString(), out qty);
                        if (!string.IsNullOrWhiteSpace(pn) || !string.IsNullOrWhiteSpace(desc))
                            materiales.Add(new ItemOT { PN = pn, Descripcion = desc, QTY = qty });
                    }

                    List<ItemOT> herramientas = new List<ItemOT>();
                    foreach (DataGridViewRow row in dgvHerramientas.Rows)
                    {
                        if (row.IsNewRow) continue;
                        var pn = row.Cells["PN"].Value?.ToString();
                        var desc = row.Cells["Descripcion"].Value?.ToString();
                        int qty = 0;
                        int.TryParse(row.Cells["QTY"].Value?.ToString(), out qty);
                        if (!string.IsNullOrWhiteSpace(pn) || !string.IsNullOrWhiteSpace(desc))
                            herramientas.Add(new ItemOT { PN = pn, Descripcion = desc, QTY = qty });
                    }

                    OT nuevaOT = new OT
                    {
                        Titulo = titulo,
                        Descripcion = descripcion,
                        Intervalo = intervalo,
                        Referencias = referencias,
                        Nota = nota,
                        Materiales = materiales,
                        Herramientas = herramientas,
                        Tareas = tareas
                    };

                }

                    // Obtener todas las tareas del DataGridView
                    List<string> tareas = new List<string>();
                    foreach (DataGridViewRow row in dgvTask.Rows)
                    {
                        if (row.IsNewRow) continue;
                        var cellValue = row.Cells[0].Value;
                        if (cellValue != null)
                            tareas.Add(cellValue.ToString());
                    }

                    // Crear el objeto OT (Orden de Trabajo)
                    OT nuevaOT = new OT
                    {
                        Titulo = titulo,
                        Descripcion = descripcion,
                        Intervalo = intervalo,
                        Referencias = referencias,
                        Nota = nota,
                        Materiales = materiales,
                        Herramientas = herramientas,
                        Tareas = tareas
                    };


                    // Aquí puedes guardar la OT, mostrar mensaje, limpiar formulario, etc.
                    MessageBox.Show("Orden de Trabajo creada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Limpiar formulario si lo deseas
                }
        
}
*/