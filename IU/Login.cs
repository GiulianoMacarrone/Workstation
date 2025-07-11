using BE.Composite;
using BLL;
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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void buttonIniciar_Click(object sender, EventArgs e)
        {
            var username = textBoxUser.Text.Trim();
            var password = textBoxPww.Text.Trim();

            UsuarioBE user = UsuarioBLL.Login(username, password);

            if (user != null && !user.bloqueado)
            {
                SesionUsuario.IniciarSesion(user);
                this.Hide();
                new Menu().Show();
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos.");
            }
        }
    }
}
