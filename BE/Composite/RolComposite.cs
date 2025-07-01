using BE.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Composite
{
    public class RolComposite : PermisoComponent
    {
        private List<PermisoComponent> children = new List<PermisoComponent>();

        public override void Add(PermisoComponent c)
        {
            children.Add(c);
        }

        public override void Remove(PermisoComponent c)
        {
            children.Remove(c);
        }

        public override PermisoComponent GetChild(int index)
        {
            return children[index];
        }

        public override void Operation()
        {
            foreach (var child in children)
            {
                child.Operation();
            }
        }

        public override List<Permiso> ObtenerPermisos()
        {
            return children.SelectMany(c => c.ObtenerPermisos()).ToList();
        }
    }
}
