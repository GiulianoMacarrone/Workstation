using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Modelo
{
    public class TrabajoBE
    {
        public int id { get; set; } // Identificador único del trabajo
        public string descripcion { get; set; } // Descripción del trabajo  
        public int nroTask { get; set; } // Número de tarea asociado al trabajo

    }
}
