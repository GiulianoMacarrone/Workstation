using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abstraccion;

namespace BE.Modelo
{
    public class InspectorBE : UsuarioABS
    {
        public string nroInspector { get; set; } //I01 por ejemplo, número de inspector único
        public override List<string> ObtenerPermisosBase() => new List<string>
        {
            "FirmarOT",
            "VisualizarOT",
            "ConsultarAeronaves",
            "SeleccionarOT",
            "AbrirDiferido",
            "CerrarDiferido",
            "CerrarOT",

        };


        public override string ObtenerRol() => "Inspector";

        
    }
}
