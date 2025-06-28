using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Modelo
{
    public class HerramientaBE
    {
        public string id { get; set; }
        public string descripcion { get; set; }
        public string serial { get; set; }
        public DateTime fechaVtoCalibracion { get; set; }
        public bool estado { get; set; } // Indica si la herramienta está disponible para uso TRUE = DISPONIBLE, FALSE = NO DISPONIBLE
    }
}
