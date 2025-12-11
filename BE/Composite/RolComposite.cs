using BE.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Composite
{
    public class RolComposite : Componente
    {
        private IList<Componente> _hijos;

        public RolComposite()
        {
            _hijos = new List<Componente>();
        }
        public override IList<Componente> hijos
        {
            get 
            {
                return _hijos;
            }
        }

        public override void AgregarHijo(Componente component)
        {
            _hijos.Add(component);
        }

        public override void EliminarHijo(Componente component)
        {
            var hijo = _hijos.FirstOrDefault(h => h.id == component.id);
            if (hijo != null)
            {
                _hijos.Remove(hijo);
            }
        }

        public override void VaciarHijos()
        {
            _hijos = new List<Componente>();
        }

    }
}