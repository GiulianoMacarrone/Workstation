using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using BE.Modelo;

namespace BLL
{
    public class UsuarioBLL
    {
        public void ChangePassword(UsuarioBE user, string nuevaPassword)
        {
            if (string.IsNullOrEmpty(nuevaPassword))
            {
                throw new ArgumentException("La nueva contraseña no puede ser nula o vacía.");
            }
            user.password = nuevaPassword;

            //guardar en la DAL
        }

        public void ObtenerRol()
        {
            // Implementación de la obtención del rol del usuario
            // Esto podría ser una llamada a una base de datos o un servicio externo
        }
    }
}
