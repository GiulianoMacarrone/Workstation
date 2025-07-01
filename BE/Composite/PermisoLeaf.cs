using BE.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Composite
{
    public class PermisoLeaf : PermisoComponent
    {
        private Permiso permiso;

        public PermisoLeaf(Permiso permiso)
        {
            this.permiso = permiso;
        }

        public override void Operation()
        {
            Console.WriteLine($"Permiso: {permiso.nombre}");
        }

        public override List<Permiso> ObtenerPermisos()
        {
            return new List<Permiso> { permiso };
        }
    }
}
