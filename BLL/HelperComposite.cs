using BE.Composite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public static class CompositeHelper
    {
        public static RolComposite EncontrarPadre(IEnumerable<RolComposite> roles,Componente objetivo)
        {
            foreach (var rol in roles)
            {
                if (rol.Hijos().Contains(objetivo))
                    return rol;

                var padreEncontrado = EncontrarPadre(
                    rol.Hijos().OfType<RolComposite>(),
                    objetivo);

                if (padreEncontrado != null)
                    return padreEncontrado;
            }
            return null;
        }

 
    }
}
