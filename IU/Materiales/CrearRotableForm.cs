using BE.Modelo;
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
    public partial class CrearRotableForm : Form
    {
        private readonly RotableBLL rotableBLL = new RotableBLL();

        public CrearRotableForm()
        {
            InitializeComponent();
        }

        private void buttonAceptar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxDescripcion.Text))
            {
                MessageBox.Show("La descripción es obligatoria.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxDescripcion.Focus();
                return;
            }

            var rotable = new RotableBE
            {
                descripcion = textBoxDescripcion.Text.Trim(),
                partNumber = textNroParte.Text.Trim(),
                serialNumber = textBoxSerie.Text.Trim(),
                estado = true  // Siempre disponible al crear
            };

            try
            {
                rotableBLL.GuardarRotable(rotable);
                
                MessageBox.Show($"Rotable creado con ID {rotable.id}","Éxito",MessageBoxButtons.OK,MessageBoxIcon.Information);

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar el rotable: {ex.Message}", "Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
        }


        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
