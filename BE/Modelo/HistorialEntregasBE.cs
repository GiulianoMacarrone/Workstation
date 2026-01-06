using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Modelo
{
    public class HistorialEntregasBE
    {
        public string IdElemento { get; set; }
        public string Tipo { get; set; }
        public string Fecha { get; set; }
        public string Cantidad { get; set; } // solo para consumibles
        public string EntregadoPor { get; set; }
        public string RecibidoPor { get; set; }
    }
}
