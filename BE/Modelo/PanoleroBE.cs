using Abstraccion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Modelo
{
    public class PanoleroBE : UsuarioABS
    {
        public override List<string> ObtenerPermisosBase() => new List<string>
        {
            "CargarConsumible",
            "CrearHerramienta",
            "CrearRotable",
            "GenerarNoStock",
            "VisualizarElemento",
            "ConsultarSolicitudesPedidos"
        };


        public override string ObtenerRol() => "Pañolero";


    }
}
