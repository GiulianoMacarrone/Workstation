using BE.Modelo;
using BLL.Servicios;
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

namespace IU
{
    public partial class CargarConsumibleForm : Form
    {
        private readonly ConsumibleBLL consumibleBLL = new ConsumibleBLL();

        public CargarConsumibleForm()
        {
            InitializeComponent();
            this.Load += CargarConsumibleForm_Load;
        }

        public event EventHandler ConsumibleCreado;

        private void CargarConsumibleForm_Load(object sender, EventArgs e)
        {
            dateTimePickerFechaVto.MinDate = DateTime.Today;
        }

        private void buttonAceptar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDescripcion.Text))
            {
                MessageBox.Show("La descripción es obligatoria.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDescripcion.Focus();
                return;
            }

            if (!int.TryParse(txtCantidad.Text.Trim(), out int cantidad) || cantidad < 1)
            {
                MessageBox.Show("Cantidad inválida. Debe ser un entero positivo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCantidad.Focus();
                return;
            }

            var consumible = new Consumible
            {
                descripcion = txtDescripcion.Text.Trim(),
                partNumber = txtNumeroParte.Text.Trim(),
                lot = txtLote.Text.Trim(),
                estado = true, // disponible
                cantidad = cantidad,
                fechaVto = dateTimePickerFechaVto.Value.Date
            };

            try
            {
                consumibleBLL.GuardarConsumible(consumible);  
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ConsumibleCreado?.Invoke(this, EventArgs.Empty);
            MessageBox.Show("Consumible cargado correctamente.", "Éxito",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
