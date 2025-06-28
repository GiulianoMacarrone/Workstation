using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstraccion
{
    public abstract class UsuarioABS
    {
        public string id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public List<string> permisosAdicionales { get; set; }

        public UsuarioABS() //iniciador de la clase Usuario para los permisos adicionales
        {
            permisosAdicionales = new List<string>();
        }

        public void ChangePassword(string nuevaPassword)
        {
            if (string.IsNullOrEmpty(nuevaPassword))
            {
                throw new ArgumentException("La nueva contraseña no puede ser nula o vacía.");
            }
            password = nuevaPassword;
        }



        public abstract List<string> ObtenerPermisosBase();

        public bool TienePermiso(string permiso)
        {
            return ObtenerPermisosBase().Contains(permiso) || permisosAdicionales.Contains(permiso);
        }

        public abstract string ObtenerRol();
    }
}
