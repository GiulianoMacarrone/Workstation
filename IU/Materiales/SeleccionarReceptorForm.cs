using BE.Composite;
using BE.Modelo;
using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IU.Materiales
{
    public partial class SeleccionarReceptorForm : Form
    {
        private readonly UsuarioBLL usuarioBLL = new UsuarioBLL();
        private readonly ElementoVisualizable componente;
        public string idUsuarioSeleccionado {  get; private set; }
        public int cantidadSolicitada { get; private set; }
        public SeleccionarReceptorForm(ElementoVisualizable componente)
        {
            if(componente == null)
            {
                throw new ArgumentNullException(nameof(componente), "El componente no puede ser nulo.");
            }
            this.componente = componente;
            InitializeComponent();
            var listaUsuarios = usuarioBLL.ListarUsuarios();
            comboBoxUser.DataSource = listaUsuarios;
            comboBoxUser.DisplayMember = "username";
            comboBoxUser.ValueMember = "id";
            comboBoxUser.SelectedIndex = -1;

            if (componente.Tipo == "Consumible")
            {
                var stock = ((Consumible)componente.ElementoOriginal).cantidad;
                labelCantMax.Text = $"Stock disponible: {stock}";
                textBoxCantidad.Visible = true;
                textBoxCantidad.Enabled = true;
            }
            else
            {
                // Para rotables se permite de a 1
                labelCantMax.Text = $"Cantidad Solicitada: 1";
                textBoxCantidad.Visible = false;
                textBoxCantidad.Enabled = false;
            }

        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        public void buttonAceptar_Click(object sender, EventArgs e)
        {
            if (comboBoxUser.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar un usuario.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (componente.Tipo == "Consumible")
            {
                if (!int.TryParse(textBoxCantidad.Text.Trim(), out int cant))
                {
                    MessageBox.Show("Cantidad inválida.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBoxCantidad.Focus();
                    return;
                }

                var stock = ((Consumible)componente.ElementoOriginal).cantidad;
                if (cant < 1 || cant > stock)
                {
                    MessageBox.Show($"La cantidad debe estar entre 1 y {stock}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBoxCantidad.Focus();
                    return;
                }
                cantidadSolicitada = cant;
            }
            else cantidadSolicitada = 1;

            idUsuarioSeleccionado = comboBoxUser.SelectedValue.ToString();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
