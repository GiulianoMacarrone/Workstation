using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Modelo
{
    public class Consumible
    {
        public string id { get; set; } // Identificador único del consumible
        public string descripcion { get; set; } // Descripción del consumible
        public string partNumber { get; set; } // Número de parte del consumible
        public string lot { get; set; } // Número de lote del consumible
        public bool estado { get; set; } // Estado del consumible (TRUE = DISPONBIBLE, FALSE = NO DISPONIBLE)
        public int cantidad { get; set; } // Cantidad disponible del consumible
        public DateTime fechaVto { get; set; } // Fecha de vencimiento del consumible
    }
}
