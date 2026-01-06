using BE.Composite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Modelo
{
    public class HistorialEstadoBE
    {
        public string id { get; set; } = Guid.NewGuid().ToString();
        public string aeronaveId { get; set; }
        public string marca { get; set; }
        public string modelo { get; set; }
        public string matricula { get; set; }
        public EstadoAeronave estadoRegistrado { get; set; } 
        public DateTime fechaEstado { get; set; }
        public string motivo { get; set; } 
        public string numeroOT { get; set; } 
        public string registradoPor { get; set; } 
    }
}
