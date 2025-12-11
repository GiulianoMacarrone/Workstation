using BE;
using BE.Composite;
using BE.Modelo;
using BLL;
using BLL.Roles;
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
    public partial class NuevoUsuario : Form
    {
        public UsuarioBE nuevoUsuario { get; private set; } = new UsuarioBE(); 
        public UsuarioBLL usuarioBLL { get; private set; } = new UsuarioBLL(); 

        public NuevoUsuario()
        {
            InitializeComponent();
        }

        private void buttonCrearUser_Click(object sender, EventArgs e)
        {
            try
            {
                nuevoUsuario.username = textBoxUserName.Text.Trim();
                nuevoUsuario.nombre = textBoxNombre.Text.Trim();
                nuevoUsuario.apellido = textBoxApellido.Text.Trim();
                nuevoUsuario.password = textBoxPww.Text;
                nuevoUsuario.bloqueado = false;

                usuarioBLL.GuardarUsuario(nuevoUsuario);

                MessageBox.Show("Usuario creado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al crear usuario: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bttnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void checkBoxMostrarContraseña_CheckedChanged(object sender, EventArgs e)
        {
            textBoxPww.UseSystemPasswordChar = !checkBoxMostrarContraseña.Checked;
        }
    }
}
