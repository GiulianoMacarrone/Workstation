using BE.Modelo;
using BLL;
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
    public partial class GenerarNoStockForm : Form
    {

        private readonly NoStockBLL noStockBLL = new NoStockBLL();
        private readonly DiferidoBLL dmiBLL = new DiferidoBLL();      
        private readonly OrdenDeTrabajoBLL otBLL = new OrdenDeTrabajoBLL();     
        private readonly AeronaveBLL aeronaveBLL = new AeronaveBLL(); 

        public event EventHandler NoStockCreado;

        public GenerarNoStockForm()
        {
            InitializeComponent();
            this.Load += CrearNoStockForm_Load;

            radioButtonDmi.CheckedChanged += (s, e) => CargarDmiOt();
            radioButtonOT.CheckedChanged += (s, e) => CargarDmiOt();
        }

        private void CrearNoStockForm_Load(object sender, EventArgs e)
        {
            radioButtonDmi.Checked = true;

            var listaAeros = aeronaveBLL.ListarAeronaves();
            comboBoxAeronave.DataSource = listaAeros;
            comboBoxAeronave.DisplayMember = "matricula";
            comboBoxAeronave.ValueMember = "id";
            comboBoxAeronave.SelectedIndex = -1;

            CargarDmiOt();
        }

        private void CargarDmiOt()
        {
            if (radioButtonDmi.Checked)
            {
                var listaDmi = dmiBLL.ListarDmiAbiertos();
                comboBoxDMIuOT.DataSource = listaDmi;
                comboBoxDMIuOT.DisplayMember = "numero";
                comboBoxDMIuOT.ValueMember = "id";
            }
            else
            {
                var listaOt = otBLL.ListarOtCerradas();
                comboBoxDMIuOT.DataSource = listaOt;
                comboBoxDMIuOT.DisplayMember = "numeroOT";
                comboBoxDMIuOT.ValueMember = "numeroOT";
            }
            comboBoxDMIuOT.SelectedIndex = -1;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            string nroNoStock = txtNumeroNoStock.Text;
            if (!int.TryParse(nroNoStock, out int numero) || numero <= 0)
            {
                MessageBox.Show("Número inválido.", "Error",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(textBoxCriticidad.Text))
            {
                MessageBox.Show("La criticidad es obligatoria.", "Error",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (comboBoxDMIuOT.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar un DMI u OT.", "Error",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (comboBoxAeronave.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar una aeronave.", "Error",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtDescripcion.Text))
            {
                MessageBox.Show("La descripción es obligatoria.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var noStock = new NoStockBE
            {
                numero = numero,
                descripcion = txtDescripcion.Text.Trim(),
                criticidad = textBoxCriticidad.Text.Trim(),
                dmiUOt = $"DMI-{((Diferido)comboBoxDMIuOT.SelectedItem).numero}",
                aeronave = ((AeronaveBE)comboBoxAeronave.SelectedItem).matricula,
                partNumber = textBoxPn.Text.Trim()
            };

            try
            {
                noStockBLL.CrearNoStock(noStock);

                if (radioButtonDmi.Checked)
                {
                    int idDmi = (int)comboBoxDMIuOT.SelectedValue;
                    noStockBLL.AsociarNoStockADiferido(idDmi, noStock.id);
                }

                NoStockCreado?.Invoke(this, EventArgs.Empty);
                MessageBox.Show($"No Stock creado","Éxito", MessageBoxButtons.OK,MessageBoxIcon.Information);
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar No Stock:\n{ex.Message}","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

