using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Composite
{
    public class UsuarioBE
    {
        public string id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public int idRol { get; set; } // ID del rol asignado al usuario
        public List<int> permisosAdicionales { get; set; } = new List<int>(); // Lista de permisos adicionales asignados al usuario (lo manejo con las IDs)
        public bool bloqueado { get; set; } // Indica si el usuario está bloqueado del sistema (no se eliminan del xml)
        
    }
}
