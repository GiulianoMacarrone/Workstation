using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Modelo
{
    public class BaseBE
    {
        //Añadi esta clase para representar una base de operaciones, que puede ser un taller, un hangar o cualquier lugar donde se realicen trabajos. La idea es sumar escalabilidad al proyecto
        public int id { get; set; } // Identificador único del registro
        public string nombre { get; set; } // Nombre o CODIGO de la base
        public string ubicacion { get; set; } // Ubicación de la base

        //LAS BASES SIRVEN DE LUGAR DE ALMACENAMIENTO DE LOS CONSUMIBLES, HERRAMIENTAS Y ROTABLES ya que son lugar de TRABAJO
        public List<string> consumibles { get; set; } // Lista de consumibles disponibles en la base
        public List<string> herramientas { get; set; } // Lista de trabajos realizados en la base
        public List<string> rotables { get; set; } // Lista de tareas asociadas a los trabajos en la base 

    }
}
