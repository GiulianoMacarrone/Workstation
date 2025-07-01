using Abstraccion;
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
            comboBoxRolUsuario.Items.AddRange(new string[] { "Mecanico", "Inspector", "Panolero", "Logistico" });
        }

        private void buttonCrearUser_Click(object sender, EventArgs e)
        {
            string rol = comboBoxRolUsuario.SelectedItem?.ToString();

            UsuarioBE nuevoUsuario;

            if (rol == "Mecanico")
            {
                nuevoUsuario = new MecanicoBE
                {
                    nroMecanico = UsuarioBLL.ObtenerSiguienteCodigo("M") // ej. "M03"
                };
            }
            else if (rol == "Inspector")
            {
                nuevoUsuario = new InspectorBE
                {
                    nroInspector = UsuarioBLL.ObtenerSiguienteCodigo("I")
                };
            }
            else if (rol == "Panolero")
            {
                nuevoUsuario = new PanoleroBE();
            }
            else if (rol == "Logistico")
            {
                nuevoUsuario.;
            }
            else
            {
                MessageBox.Show("Debe seleccionar un rol.");
                return;
            }

            nuevoUsuario.id = textBoxIdUser.Text;
            nuevoUsuario.username = textBoxUserName.Text;
            nuevoUsuario.nombre = textBoxNombre.Text;
            nuevoUsuario.apellido = textBoxApellido.Text;
            nuevoUsuario.password = textBoxPww.Text;

            UsuarioBLL.GuardarUsuario(nuevoUsuario);

            MessageBox.Show("Usuario creado correctamente.");
            this.Close();
        }
    }
}
