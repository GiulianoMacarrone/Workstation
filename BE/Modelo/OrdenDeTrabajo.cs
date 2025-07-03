using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Modelo
{
    public class OrdenDeTrabajo
    {
        public string numeroOT { get; set; }
        public string titulo { get; set; }
        public string descripcion { get; set; }
        public string aeronave { get; set; } 
        public string serial { get; set; }
        public string matricula { get; set; }
        public DateTime fechaInicio { get; set; }
        public DateTime fechaCierre { get; set; }
        public string estado { get; set; } // Ejemplo: "Pendiente", "En Progreso", "Completada"
        public TrabajoBE trabajo { get; set; } // Trabajo asociado a la OT
        //registro de firmas
        public string mecanico { get; set; }
        public string inspector { get; set; }

    }
}
