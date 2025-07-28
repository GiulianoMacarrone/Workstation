using BE.Modelo;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Composite
{
    public class PermisoLeaf : Componente
    {
        public override void AgregarHijo(Componente component)
        {
            throw new Exception("Un permiso no puede contener hijos");
        }

        public override void EliminarHijo(Componente component)
        {
            throw new Exception("Un permiso no puede contener hijos");
        }

        public override bool TieneHijos()
        {
            return false;
        }

        public override IList<Componente> ObtenerHijos()
        {
            return new List<Componente>(); // Un permiso no tiene hijos, retornamos una lista vacía por las dudas.
        }
    }
}
