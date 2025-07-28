using BE.Composite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Servicios
{
    public class SesionUsuario
    {
        private static SesionUsuario instancia;

        public UsuarioBE UsuarioActual { get; private set; }

        private SesionUsuario(UsuarioBE usuario)
        {
            UsuarioActual = usuario;
        }

        public static void IniciarSesion(UsuarioBE usuario)
        {
            if (instancia == null)
            {
                instancia = new SesionUsuario(usuario);
            }
        }

        public static SesionUsuario Instancia => instancia;

        public static void CerrarSesion()
        {
            instancia = null;
        }
    }

}
