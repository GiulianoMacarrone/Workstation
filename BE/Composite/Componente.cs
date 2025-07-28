using BE.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Composite
{
    public abstract class Componente
    {
        public int id { get; set; }
        public string designacion { get; set; }

        public abstract void AgregarHijo(Componente component); 
        public abstract void EliminarHijo(Componente component); 
        public abstract bool TieneHijos(); //false = no es hoja y puede tener hijos, true = es hoja y no puede tener hijos
        public abstract IList<Componente> ObtenerHijos();
    }

}
