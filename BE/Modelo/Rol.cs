using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abstraccion;

namespace BE.Modelo
{
    public class Rol
    {
        public int id { get; set;}
        public string designacion { get; set; } 
        public string permiso {get; set;}
      
        public List<string> ListaPermisos() => new List<string;

      

    }
}
