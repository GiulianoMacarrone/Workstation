using Abstraccion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class UsuarioBE
    {
        public string id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public List<string> permisosAdicionales { get; set; }
        public bool bloqueado { get; set; } // Indica si el usuario está bloqueado del sistema (no se eliminan del xml)

        public UsuarioBE() //iniciador de la clase Usuario para los permisos adicionales
        {
            permisosAdicionales = new List<string>();
        }

        
    }
}
