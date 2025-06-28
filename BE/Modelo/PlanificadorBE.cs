using Abstraccion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Modelo
{
    public class PlanificadorBE : UsuarioABS
    
    {
        public override List<string> ObtenerPermisosBase() => new List<string>
        {
            "CrearOrdenTrabajo",
            "CrearTrabajo",
            "EliminarOT",
            "VisualizarOT"
        };
        public override string ObtenerRol() => "Planificador";

        

    }
}
