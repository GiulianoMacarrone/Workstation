using BE.Modelo;
using BLL.Roles;
using BLL.Servicios;
using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;
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
    public partial class CrearOTForm : Form 
    {
        private List<TrabajoBE> listaTrabajos = new List<TrabajoBE>();
        private TrabajoBE trabajoSeleccionado = null;
        private AeronaveBE aeronaveSeleccionada = null;
        public CrearOTForm()
        {
            InitializeComponent();
            CargarTrabajos();
            textBoxNroOT.Text = GenerarNroOT();
            CargarAeronaves();
            comboBoxAeronaves_SelectedIndexChanged(null, null);
            dateTimePickerFecha.Value = DateTime.Now; 
        }


        private string GenerarNroOT() 
        {
            OrdenDeTrabajoBLL otBLL = new OrdenDeTrabajoBLL();
            List<OrdenDeTrabajo> listaOTs = otBLL.ListarOrdenes();
            int maxNumero = 0;

            foreach (var ot in listaOTs) 
            {
                if (!string.IsNullOrEmpty(ot.numeroOT) && ot.numeroOT.StartsWith("OT-"))
                {
                    string numStr = ot.numeroOT.Substring(3); 
                    if (int.TryParse(numStr, out int num))
                    {
                        if (num > maxNumero)
                            maxNumero = num;
                    }
                }
            }

            int siguienteNumero = maxNumero + 1;
            return $"OT-{siguienteNumero.ToString("D6")}";
        }

        private void CargarAeronaves()
        {
            AeronaveBLL aeronaveBLL = new AeronaveBLL();
            List<AeronaveBE> listaAeronaves = aeronaveBLL.ListarAeronaves();

            comboBoxAeronaves.DataSource = listaAeronaves;

            comboBoxAeronaves.DisplayMember = "matricula";

            textBoxSerialNumber.Text = "serial";

        }

        private void CargarTrabajos()
        {
            dgvTrabajos.Columns.Clear();
            TrabajoBLL trabajoBLL = new TrabajoBLL();
            listaTrabajos = trabajoBLL.ListarTrabajos();

            dgvTrabajos.AutoGenerateColumns = false;

            if (dgvTrabajos.Columns.Count == 0)
            {
                dgvTrabajos.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "nroTrabajo",
                    HeaderText = "Nro Trabajo",
                    Name = "nroTrabajo"
                });
                dgvTrabajos.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "titulo",
                    HeaderText = "Título",
                    Name = "titulo"
                });
                dgvTrabajos.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "descripcion",
                    HeaderText = "Descripción",
                    Name = "descripcion"
                });
                dgvTrabajos.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "intervalo",
                    HeaderText = "Intervalo",
                    Name = "intervalo"
                });
            }

            dgvTrabajos.DataSource = listaTrabajos;

            foreach (DataGridViewColumn column in dgvTrabajos.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }

        }

        private void buttonGenerarOT_Click(object sender, EventArgs e)
        {
            OrdenDeTrabajo nuevaOrden = new OrdenDeTrabajo
            {
                numeroOT = textBoxNroOT.Text,
                titulo = textBoxTituloOT.Text.Trim(),
                descripcion = trabajoSeleccionado.descripcion,
                aeronave = aeronaveSeleccionada.marca + " " + aeronaveSeleccionada.modelo,
                serial = aeronaveSeleccionada.serial,
                matricula = aeronaveSeleccionada.matricula,

                fechaInicio = dateTimePickerFecha.Value,

                estado = "Pendiente",

                trabajo = trabajoSeleccionado
            };

            try
            {
                var ordenBll = new OrdenDeTrabajoBLL();
                ordenBll.GenerarNuevaOT(nuevaOrden);
                MessageBox.Show("Orden de trabajo generada exitosamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al crear la Orden de Trabajo: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvTrabajos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                trabajoSeleccionado = (TrabajoBE)dgvTrabajos.Rows[e.RowIndex].DataBoundItem;
                CargarTareas(trabajoSeleccionado);
            }
        }


        private void CargarTareas(TrabajoBE trabajo)
        {
            if (trabajo == null || trabajo.listaTareas == null) return;

            dataGridViewTareas.Columns.Clear();

            dataGridViewTareas.AutoGenerateColumns = false;

            dataGridViewTareas.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Tarea",
                HeaderText = "Tareas",
                Name = "tarea"
            });

            var tareasData = trabajo.listaTareas.Select(t => new { Tarea = t }).ToList();

            dataGridViewTareas.DataSource = tareasData;

            foreach (DataGridViewColumn column in dataGridViewTareas.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
        }

        private void comboBoxAeronaves_SelectedIndexChanged(object sender, EventArgs e)
        {
            aeronaveSeleccionada = (AeronaveBE)comboBoxAeronaves.SelectedItem;
            if (aeronaveSeleccionada != null)
            {
                textBoxSerialNumber.Text = aeronaveSeleccionada.serial;
            }
            else
            {
                textBoxSerialNumber.Text = string.Empty;
            }
        }
    }
}
