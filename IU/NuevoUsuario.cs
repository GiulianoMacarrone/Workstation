using BE.Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using BE;
using BE.Composite;

namespace IU
{
    public partial class NuevoUsuario : Form
    {
        public NuevoUsuario()
        {
            InitializeComponent();
        }
        private void NuevoUsuario_Load(object sender, EventArgs e)
        {
            
        }

        private void buttonCrearUser_Click(object sender, EventArgs e)
        {
            string rol = comboBoxRolUsuario.SelectedItem?.ToString();

            UsuarioBE nuevoUsuario = new UsuarioBE();

            nuevoUsuario.id = textBoxIdUser.Text;
            nuevoUsuario.username = textBoxUserName.Text;
            nuevoUsuario.nombre = textBoxNombre.Text;
            nuevoUsuario.apellido = textBoxApellido.Text;
            nuevoUsuario.password = textBoxPww.Text;

            //UsuarioBLL.GuardarUsuario(nuevoUsuario);

            MessageBox.Show("Usuario creado correctamente.");
            this.Close();
        }
    }
}
