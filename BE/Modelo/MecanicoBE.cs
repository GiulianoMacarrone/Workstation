using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abstraccion;

namespace BE.Modelo
{
    public class MecanicoBE : UsuarioABS
    {
        public string nroMecanico { get; set; } //M01 por ejemplo, número de mecánico único
        public override List<string> ObtenerPermisosBase() => new List<string>
        {
            "EjecutarOT",
            "FirmarOT",
            "VisualizarOT",
            "ConsultarAeronaves",
            "SeleccionarOT",
            
        };


        public override string ObtenerRol() => "Mecanico";
    }
}
