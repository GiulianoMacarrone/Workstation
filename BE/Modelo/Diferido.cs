using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace BE.Modelo
{
    public class Diferido
    {
        public int id { get; set; } // Identificador único del diferido
        public int numero { get; set; } // Número de diferido
        public string aeronave { get; set; } // Aeronave asociada al diferido
        public string descripcion { get; set; } // Descripción del diferido
        public DateTime fechaApertura { get; set; } // Fecha de creación del diferido
        public DateTime fechaCierre { get; set; } // Fecha de cierre del diferido
        public bool estado { get; set; } 
        public string nroItemMEl { get; set; } // Número de ítem MEl asociado al diferido (ejemplo : "MEl-31-52-01.3")
        public string observaciones { get; set; } // Observaciones del diferido
        public int? idNoStock { get; set; } // Id del No Stock asociada al diferido
        
    }
}
