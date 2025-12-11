using BE.Composite;
using BE.Modelo;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Roles
{
    public class RolBLL
    {
        public List<RolComposite> ListarRoles()
        {
            return DatosDAL.ListarRoles();
        }

        #region ABM Rol
        public void CrearRol(RolComposite nuevoRol)
        {
            var rolesExistentes = ListarRoles();
            if (rolesExistentes.Any(r => r.designacion.Equals(nuevoRol.designacion, StringComparison.OrdinalIgnoreCase)))
            {
                throw new InvalidOperationException($"Ya existe un rol con la designación “{nuevoRol.designacion}”.");
            }
            
            DatosDAL.GuardarRol(nuevoRol);
        }

        public void ActualizarRol(RolComposite rol)
        {
            var existentes = ListarRoles();
            if (!existentes.Any(r => r.id == rol.id))
            {
                throw new ArgumentException($"El rol {rol.id} no existe.");
            }

            if (existentes.Any(r => r.id != rol.id && r.designacion.Equals(rol.designacion, StringComparison.OrdinalIgnoreCase)))
            {
                throw new InvalidOperationException(
                    $"Ya existe otro rol con la designación “{rol.designacion}”.");
            }

            DatosDAL.GuardarRol(rol);
        }

        public void EliminarRol(int rolId)
        {
            var rol = DatosDAL.ListarRoles().FirstOrDefault(r => r.id == rolId);
            if (rol == null)
            {
                throw new ArgumentException($"Rol {rolId} no encontrado.");
            }

            var usuarios = DatosDAL.ListarUsuarios();
            if (usuarios.Any(u => u.rolesAsignados.Contains(rolId) && !u.bloqueado)) //verificacion usuarios con ese rol
            {
                throw new InvalidOperationException($"No se puede desactivar el rol {rol.designacion} porque hay usuarios activos asignados.");
            }

            DatosDAL.EliminarRol(rolId);
        }
        #endregion

        #region Permisos y SubRoles 
        public void AsociarPermiso(RolComposite rol, PermisoLeaf permiso)
        {
            bool yaExiste = rol.hijos().OfType<PermisoLeaf>().Any(p => p.id == permiso.id);

            if (yaExiste)
            {
                throw new InvalidOperationException($"El rol {rol.designacion} ya tiene el permiso {permiso.designacion}.");
            }

            rol.AgregarHijo(permiso);
            DatosDAL.GuardarRol(rol);
        }

        public void DesasociarPermiso(RolComposite rol, PermisoLeaf permiso)
        {
            var hijo = rol.hijos().FirstOrDefault(c => c is PermisoLeaf pl && pl.id == permiso.id);

            if (hijo == null)
            {
                throw new InvalidOperationException($"El rol {rol.designacion} no tiene asignado el permiso {permiso.designacion}.");
            }

            rol.VaciarHijos(hijo);
            DatosDAL.GuardarRol(rol);
        }

        public void AsociarSubRol(RolComposite padre, RolComposite hijo)
        {
            if (ContieneDescendiente(hijo, padre.id))
                throw new InvalidOperationException($"Asociación inválida: {hijo.designacion} ya contiene a {padre.designacion}.");


            if (padre.id == hijo.id)
            {
                throw new InvalidOperationException("Un rol no puede asociarse a sí mismo.");
            }

            bool yaTiene = padre.Hijos().OfType<RolComposite>().Any(r => r.id == hijo.id);

            if (yaTiene)
            {
                throw new InvalidOperationException($"El rol {padre.designacion} ya incluye al sub-rol {hijo.designacion}.");
            }

            padre.AgregarHijo(hijo);
            DatosDAL.GuardarRol(padre);
        }

        public void DesasociarSubRol(RolComposite padre, RolComposite hijo)
        {
            var nodo = padre.Hijos().FirstOrDefault(c => c is RolComposite rc && rc.id == hijo.id);

            if (nodo == null)
            {
                throw new InvalidOperationException($"El rol {padre.designacion} no tiene asociado el sub-rol {hijo.designacion}.");
            }
                   
            padre.VaciarHijos(nodo);
            DatosDAL.GuardarRol(padre);
        }
        #endregion

        bool ContieneDescendiente(RolComposite raiz, int idBuscado)
        {
            if (raiz.id == idBuscado) return true;
            return raiz.hijos.OfType<RolComposite>().Any(sub => ContieneDescendiente(sub, idBuscado));
        }

    }
}
