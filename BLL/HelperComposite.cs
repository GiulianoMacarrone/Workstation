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
                if (rol.ObtenerHijos().Contains(objetivo))
                    return rol;

                var padreEncontrado = EncontrarPadre(
                    rol.ObtenerHijos().OfType<RolComposite>(),
                    objetivo);

                if (padreEncontrado != null)
                    return padreEncontrado;
            }
            return null;
        }

 
    }
}
