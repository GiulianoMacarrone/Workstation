using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE.Modelo;
using DocumentFormat.OpenXml;

namespace BLL.Servicios
{
    public class RegistroParser
    {
        public void ParsearRegistro()
        {
            var registro = new RegistroBE();
            //usar la libreria para leer el doc y devolver un obj de registro
        }

        public void EscribirRegistro(RegistroBE registro)
        {
            //usar la libreria para escribir el obj de registro en un doc
        }

    }
}
