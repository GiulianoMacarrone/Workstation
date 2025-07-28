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
        private readonly List<Componente> hijo = new List<Componente>();

        public override void AgregarHijo(Componente component)
        {
            try
            {
                hijo.Add(component);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al agregar hijo al rol", ex);
            }
        }

        public override void EliminarHijo(Componente component)
        {
            try
            {
                hijo.Remove(component);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar hijo del rol", ex);
            }
        }
        public override bool TieneHijos() //no se refiere a si el rol tiene hijos, sino a si el componente puede tener hijos. Rol = si. Permiso = no.
        {
            //if (hijo.Count == 0) return true; //Podriamos agregar una validacion si se quiere q corrobora que tiene hijos o no.
            return true; 
        }
        public override IList<Componente> ObtenerHijos()
        {
            try 
            {
                return hijo;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener hijos del rol", ex);
            }
        }
    }
}