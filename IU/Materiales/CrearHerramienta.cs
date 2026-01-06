using BE.Modelo;
using BLL.Servicios;
using DocumentFormat.OpenXml.Office.PowerPoint.Y2021.M06.Main;
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
    public partial class CrearHerramienta : Form
    {
        private readonly HerramientaBLL herramientaBLL = new HerramientaBLL();

        public CrearHerramienta()
        {
            InitializeComponent();
            this.Load += CrearHerramienta_Load;
        }
        private void CrearHerramienta_Load(object sender, EventArgs e)
        {
            dateTimePickerFechaVto.MinDate = DateTime.Today;
        }

        private void buttonAceptar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxDescripcion.Text) || string.IsNullOrWhiteSpace(textBoxSerial.Text))
            {
                MessageBox.Show("La descripción y el serial son obligatorios.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxDescripcion.Focus();
                return;
            }
            
            var herramienta = new HerramientaBE
            {
                descripcion = textBoxDescripcion.Text.Trim(),
                serial = textBoxSerial.Text.Trim(),
                fechaVtoCalibracion = dateTimePickerFechaVto.Value.Date,
                estado = (dateTimePickerFechaVto.Value.Date >= DateTime.Today)
            };

            try
            {
                herramientaBLL.GuardarHerramienta(herramienta);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("Herramienta creada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
        
        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
