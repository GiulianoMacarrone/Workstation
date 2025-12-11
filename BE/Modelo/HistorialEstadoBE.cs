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
        public EstadoAeronave estadoRegistrado { get; set; } // Copia de EstadoActual
        public DateTime fechaEstado { get; set; } // Fecha escrita por el usuario. Generalmente el registro en el sistema se puede realizar antes o despues del cambio de estado.
        public string motivo { get; set; } // libre si es F/S
        public string numeroOT { get; set; } // obligatorio si es SVC
        public string registradoPor { get; set; } // usuario que hizo el registro
    }
}
