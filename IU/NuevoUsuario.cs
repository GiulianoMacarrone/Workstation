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
using static BLL.Roles.RolBLL;

namespace IU
{
    public partial class NuevoUsuario : Form
    {
        public BLL.Roles.RolBLL rolBLL { get; private set; } = new BLL.Roles.RolBLL();
        public UsuarioBE nuevoUsuario { get; private set; } = new UsuarioBE(); 
        public UsuarioBLL usuarioBLL { get; private set; } = new UsuarioBLL(); 


        public NuevoUsuario()
        {
            InitializeComponent();
            rolBLL = new BLL.Roles.RolBLL();
            comboBoxRolUsuario.DataSource = rolBLL.ListarRoles();
            comboBoxRolUsuario.DisplayMember = "designacion";
            comboBoxRolUsuario.ValueMember = "id"; 
        }
        private void NuevoUsuario_Load(object sender, EventArgs e)
        {
            comboBoxRolUsuario.DataSource = rolBLL.ListarRoles();
        }

        private void buttonCrearUser_Click(object sender, EventArgs e)
        {
            string rol = comboBoxRolUsuario.SelectedItem?.ToString();

            nuevoUsuario.username = textBoxUserName.Text;
            nuevoUsuario.nombre = textBoxNombre.Text;
            nuevoUsuario.apellido = textBoxApellido.Text;
            nuevoUsuario.password = textBoxPww.Text;
            nuevoUsuario.bloqueado = false; //por defecto no bloqueado
            int idRol = (int)comboBoxRolUsuario.SelectedValue;
            nuevoUsuario.rolesAsignados.Add(idRol); // Agregar el rol seleccionado a la lista de roles asignados

            usuarioBLL.GuardarUsuario(nuevoUsuario);

            MessageBox.Show("Usuario creado correctamente.");
            this.Close();
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
