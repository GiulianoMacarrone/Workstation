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

        List<Componente> _permisos; 
        public bool bloqueado { get; set; } // Indica si el usuario está bloqueado del sistema (no se eliminan del xml)
       
        //solo para roles especificos
        public string nroMecanico { get; set; } // Número de mecánico asignado al usuario (para mecánicos)
        public string nroInspector { get; set; } // Número de inspector asignado al usuario (para inspectores)
        
        public List<Componente> permisos
        {
            get { return _permisos; }
        }

        public UsuarioBE()
        {
            _permisos= new List<Componente>();
        }

        public override string ToString()
        {
            return username;
        }

    }
}
