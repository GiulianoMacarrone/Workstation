using BE.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Composite
{
    public abstract class PermisoComponent
    {
        public abstract void Operation();
        public virtual void Add(PermisoComponent c) { }
        public virtual void Remove(PermisoComponent c) { }
        public virtual PermisoComponent GetChild(int index) => null;
        public virtual List<Permiso> ObtenerPermisos() => new List<Permiso>();
    }
}
