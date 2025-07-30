using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Modelo
{
    public class TareaBE
    {
        public string descripcion { get; set; } // Descripción de la tarea
        public string nroMecanico { get; set; } // Número de mecánico asignado a la tarea, Null o Empty = SIN FIRMAR
        public string nroInspector { get; set; } // Número de inspector asignado a la tarea, Null o Empty = SIN FIRMAR
    }
}
