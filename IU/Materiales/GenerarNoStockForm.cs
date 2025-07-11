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

            btnAceptar.Click += btnAceptar_Click;
            btnCancel.Click += (_, __) => Close();
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
                comboBoxDMIuOT.DisplayMember = "numero";
                comboBoxDMIuOT.ValueMember = "id";
            }
            comboBoxDMIuOT.SelectedIndex = -1;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtNumeroNoStock.Text.Trim(), out int numero))
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
                dmiUOt = comboBoxDMIuOT.SelectedValue.ToString(),
                aeronave = comboBoxAeronave.SelectedValue.ToString(),
                partNumber = textBoxPn.Text.Trim()
            };
            if (radioButtonDmi.Checked)
            {
                int idDmi = (int)comboBoxDMIuOT.SelectedValue;
                noStockBLL.AsociarNoStockADiferido(idDmi, noStock.id);
            }

            try
            {
                noStockBLL.CrearNoStock(noStock);
                NoStockCreado?.Invoke(this, EventArgs.Empty);
                MessageBox.Show($"No Stock creado con ID {noStock.id}","Éxito", MessageBoxButtons.OK,MessageBoxIcon.Information);
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

