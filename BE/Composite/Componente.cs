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
        public abstract IList<Componente> hijos { get; }
        public abstract void AgregarHijo(Componente component); 
        public abstract void EliminarHijo(Componente component);
        public abstract void VaciarHijos(); 
        public TipoPermisoBE permiso { get; set; }

        public override string ToString()
        {
            return designacion;
        }

    }

}
