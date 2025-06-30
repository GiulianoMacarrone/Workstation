using Abstraccion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Modelo
{
    public class LogisticoBE : UsuarioABS
    {
        public override List<string> ObtenerPermisosBase() => new List<string>
        {
            "ConsultarSolicitudesPedidos"
        };


        public override string ObtenerRol() => "Logistico";


    }
}
