using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Modelo
{
    public class NoStockBE
    {
        public int id { get; set; } // Identificador único del No Stock
        public int numero { get; set; } // Número de No Stock
        public string descripcion { get; set; } // Descripción del No Stock
        public string dmiUOt { get; set; } // Número de DMI u Orden de trabajo a la que esta asociado
        public string criticidad { get; set; } // criticidad del No Stock (ejemplo: "ALTA", "MEDIA", "BAJA")
        public string aeronave { get; set; } // Aeronave asociada al No Stock
        public string partNumber { get; set; } // Número de parte del No Stock
        public bool estado { get; set; } // Estado del No Stock (TRUE = completado, FALSE = abierto)

    }
}
