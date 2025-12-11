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
        public override IList<Componente> hijos
        {
            get
            {
                return new List<Componente>();
            }
        }
        public override void AgregarHijo(Componente component)
        {
        }

        public override void EliminarHijo(Componente component)
        {
        }
        public override void VaciarHijos()
        {
        }
    }
}
