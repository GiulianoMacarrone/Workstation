using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BE.Modelo.OrdenDeTrabajo;
using BE.Modelo;

namespace BE.Modelo
{
    public class TrabajoBE
    {
        public int id { get; set; } // Identificador único del trabajo
        public int nroTrabajo { get; set; } // Número asociado trabajo TR-XXXXXX
        public string descripcion { get; set; } // Descripción del trabajo  
        public string titulo{ get; set; } // Título del trabajo
        public string intervalo { get; set; } // Intervalo de tiempo para el trabajo (ej. "Mensual", "Anual")
        public string referencias { get; set; } // Referencias a documentacion para el trabajo
        public string nota { get; set; } // Nota adicional para el trabajo
        public List<string> listaTareas { get; set; } // Lista de tareas asociadas al trabajo
        public List<ItemOTBE> listaMateriales { get; set; } // Lista de materiales necesarios para la OT
        public List<ItemOTBE> listaHerramientas { get; set; } // Lista de herramientas necesarias para la OT

        //se creo una clase auxiliar llamada ItemOTBE para representar los materiales y herramientas de la OT. Distinta a las herramientas o materiales de pañol
    }
}
