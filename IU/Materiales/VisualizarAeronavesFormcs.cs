using BE.Modelo;
using BLL;
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
    public partial class VisualizarAeronavesFormcs : Form
    {
        private readonly AeronaveBLL aeronaveBLL = new AeronaveBLL();
        private readonly DiferidoBLL diferidoBLL = new DiferidoBLL();

        private List<AeronaveBE> listaAeronaves;
        private List<Diferido> listaDiferidos;
        private string matriculaSeleccionada;

        public VisualizarAeronavesFormcs()
        {
            InitializeComponent();
            Load += VisualizarAeronavesFormcs_Load;

            var usuario = SesionUsuario.Instancia.UsuarioActual;
            var permisos = UsuarioBLL.ObtenerPermisosEfectivos(usuario);
            bool puedeCerrar = permisos.Any(p => p.nombre.Equals("Cerrar_Diferido", StringComparison.OrdinalIgnoreCase));
            if (puedeCerrar) 
            {
                buttonCerrarDMI.Visible = true; 
                buttonCerrarDMI.Enabled = true; 
            }
 
            txtFechaCierre.Text = DateTime.Now.ToShortDateString();
            comboBoxMatriculaAeronave.SelectedIndexChanged += comboBoxMatriculaAeronave_SelectedIndexChanged;
            dataGridViewDiferidos.CellClick += dataGridViewDiferidos_CellClick;
        }

        private void buttonCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }


        private void VisualizarAeronavesFormcs_Load(object sender, EventArgs e)
        {
            listaAeronaves = aeronaveBLL.ListarAeronaves();
            comboBoxMatriculaAeronave.DataSource = listaAeronaves;
            comboBoxMatriculaAeronave.DisplayMember = "matricula";
            comboBoxMatriculaAeronave.ValueMember = "matricula";
            comboBoxMatriculaAeronave.SelectedIndex = -1;
        }

        private void comboBoxMatriculaAeronave_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxMatriculaAeronave.SelectedItem == null)
            {
                dataGridViewDiferidos.DataSource = null;
                LimpiarCampos();
                buttonCerrarDMI.Enabled = false; //prueba

                return;
            }

            matriculaSeleccionada = comboBoxMatriculaAeronave.SelectedValue.ToString();
            CargarDiferidos(matriculaSeleccionada);
        }


        private void CargarDiferidos(string matricula)
        {
            listaDiferidos = diferidoBLL.ListarDiferidosPorMatricula(matricula);

            dataGridViewDiferidos.DataSource = null;
            dataGridViewDiferidos.DataSource = listaDiferidos;

            foreach (DataGridViewColumn col in dataGridViewDiferidos.Columns)
            {
                col.Visible = col.Name == "numero" || col.Name == "descripcion";
                
            }

            dataGridViewDiferidos.Columns["numero"].HeaderText = "Numero DMI";
            dataGridViewDiferidos.Columns["descripcion"].HeaderText = "Descripción";
            dataGridViewDiferidos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            LimpiarCampos();
            buttonCerrarDMI.Enabled = false; //prueba
        }

        private void dataGridViewDiferidos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var dif = (Diferido)dataGridViewDiferidos.Rows[e.RowIndex].DataBoundItem;

            txtFechaApertura.Text = dif.fechaApertura.ToString("g");

            txtNroDMI.Text = dif.numero.ToString();
            txtDescripcion.Text = dif.descripcion;
            txtMEL.Text = dif.nroItemMEl;
            txtEstado.Text = dif.estado ? "Cerrado" : "Abierto";
            txtObservaciones.Text = dif.observaciones;

            txtNoStock.Text = dif.idNoStock?.ToString() ?? "";

            buttonCerrarDMI.Enabled = !dif.estado;

        }
        private void LimpiarCampos()
        {
            txtFechaApertura.Clear();
            txtFechaCierre.Text = DateTime.Now.ToShortDateString();
            txtNroDMI.Clear();
            txtDescripcion.Clear();
            txtMEL.Clear();
            txtEstado.Clear();
            txtObservaciones.Clear();
            txtNoStock.Clear();
        }

        private void buttonCerrarDMI_Click(object sender, EventArgs e)
        {
            if (dataGridViewDiferidos.CurrentRow == null) return;
            var dif = (Diferido)dataGridViewDiferidos.CurrentRow.DataBoundItem;

            if (dif.estado)
            {
                MessageBox.Show("Este DMI ya está cerrado.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                diferidoBLL.CerrarDiferido(dif.id);
                MessageBox.Show("DMI cerrado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                CargarDiferidos(matriculaSeleccionada);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al cerrar DMI", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
