using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Modelo
{
    public class ItemOTBE
    {
        public string PN { get; set; } // Número de parte del item
        public string Descripcion { get; set; } // Descripción del item
        public int QTY { get; set; } // Cantidad del item
    }
}
