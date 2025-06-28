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
        public DateTime fechaInicio { get; set; }
        public DateTime fechaCierre { get; set; }
        protected string estado { get; set; } // Ejemplo: "Pendiente", "En Progreso", "Completada"
        public List<string> listaTrabajos { get; set; } // Lista de IDs de trabajos asociados a esta orden
        public OrdenDeTrabajo()
        {
            listaTrabajos = new List<string>();
        }
    }
}
