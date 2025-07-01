using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstraccion.Abstraccion
{
    public abstract class PermisoComponent
    {
        public abstract List<PermisoComponent> ObtenerHijos();
        public abstract string Nombre { get; }
        public abstract int Id { get; }
    }
}
