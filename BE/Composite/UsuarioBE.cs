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
        public List<int> rolesAsignados { get; set; } = new List<int>(); // Lista de roles asignados al usuario (lo manejo con las IDs)
        public List<int> permisosAdicionales { get; set; } = new List<int>(); // Lista de permisos adicionales asignados al usuario (lo manejo con las IDs)
        public bool bloqueado { get; set; } // Indica si el usuario está bloqueado del sistema (no se eliminan del xml)
       
        //solo para roles especificos
        public string nroMecanico { get; set; } // Número de mecánico asignado al usuario (para mecánicos)
        public string nroInspector { get; set; } // Número de inspector asignado al usuario (para inspectores)
    }
}
