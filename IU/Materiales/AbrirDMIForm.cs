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
    public partial class AbrirDMIForm : Form
    {
        private readonly DiferidoBLL diferidoBLL = new DiferidoBLL();
        private readonly AeronaveBLL aeronaveBLL = new AeronaveBLL();

        private List<AeronaveBE> listaAeronaves;

        public AbrirDMIForm()
        {
            InitializeComponent();

            listaAeronaves = aeronaveBLL.ListarAeronaves();
            comboBoxMatriculaAeronave.DataSource = listaAeronaves;
            comboBoxMatriculaAeronave.DisplayMember = "matricula";
            comboBoxMatriculaAeronave.ValueMember = "matricula";
            comboBoxMatriculaAeronave.SelectedIndex = -1;
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonAbrirDMI_Click(object sender, EventArgs e)
        {
            if (comboBoxMatriculaAeronave.SelectedItem == null)
            {
                MessageBox.Show("Seleccione una aeronave.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!int.TryParse(txtNroDMI.Text.Trim(), out var nro))
            {
                MessageBox.Show("Ingrese un número válido de DMI.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var nuevo = new Diferido
            {
                numero = nro,
                aeronave = comboBoxMatriculaAeronave.SelectedValue.ToString(),
                descripcion = txtDescripcion.Text.Trim(),
                fechaApertura = dateTimePickerFechaApertura.Value,
                estado = false,
                nroItemMEl = txtMEL.Text.Trim(),
                observaciones = txtObservaciones.Text.Trim(),
                idNoStock = string.IsNullOrWhiteSpace(txtNoStock.Text) ? (int?)null : int.Parse(txtNoStock.Text.Trim())
            };

            try
            {
                diferidoBLL.AbrirDiferido(nuevo);
                MessageBox.Show("Diferido abierto correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al abrir Diferido", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
