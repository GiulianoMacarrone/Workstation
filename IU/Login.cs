using BE.Composite;
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
    public partial class Login : Form
    {
        private UsuarioBE user = new UsuarioBE();
        private readonly PermisoBLL permisoBLL = new PermisoBLL();
        public Login()
        {
            InitializeComponent();
        }

        private void buttonIniciar_Click(object sender, EventArgs e)
        {
            var username = textBoxUser.Text.Trim();
            var password = textBoxPww.Text.Trim();

            user = UsuarioBLL.Login(username, password);

            if (user != null && !user.bloqueado)
            {
                SesionUsuario.IniciarSesion(user);
                this.Hide();
                var menu = new Menu();
                menu.Show();
                
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos.");
            }
        }
    }
}
