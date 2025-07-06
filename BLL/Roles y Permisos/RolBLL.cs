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
        public List<Rol> ListarRoles()
        {
            return DatosDAL.ListarRoles();
        }

        #region ABM Rol
        public void CrearRol(Rol rol)
        {
            var rolesExistentes = DatosDAL.ListarRoles();
            if (rolesExistentes.Any(r => r.designacion.Equals(rol.designacion, StringComparison.OrdinalIgnoreCase)))
            {
                throw new Exception("Ya existe un rol con esa designación.");
            }

            rol.id = rolesExistentes.Select(r => r.id).DefaultIfEmpty(-1).Max() + 1;

            DatosDAL.GuardarRol(rol);
        }

        public void ActualizarRol(Rol rol)
        {
            var existentes = DatosDAL.ListarRoles();
            if (!existentes.Any(r => r.id == rol.id))
            {
                throw new Exception("El rol a actualizar no existe.");
            }

            if (existentes.Any(r => r.designacion.Equals(rol.designacion, StringComparison.OrdinalIgnoreCase) && r.id != rol.id))
            {
                throw new Exception("Ya existe un rol con esa designación.");
            }

            DatosDAL.ActualizarRol(rol);
        }

        public void EliminarRol(int idRol)
        {
            var rol = DatosDAL.ListarRoles(includeInactive: true)
                          .FirstOrDefault(r => r.id == idRol);
            if (rol == null) throw new ArgumentException($"Rol {idRol} no encontrado.");

            var usuarios = DatosDAL.ListarUsuarios();
            if (usuarios.Any(u => u.idRol == idRol && !u.bloqueado))
            {
                throw new InvalidOperationException($"No se puede desactivar el rol porque hay usuarios activos asignados.");
            }

            DatosDAL.DesactivarRol(idRol);
        }

        public void AsociarPermiso(int idRol, int idPermiso)
        {
            throw new NotImplementedException("AsociarPermiso no está implementado en BLLRol");
        }

        public void DesasociarPermiso(int idRol, int idPermiso)
        {
            throw new NotImplementedException("DesasociarPermiso no está implementado en BLLRol");
        }


        public void AsociarSubRol(int idRolPadre, int idRolHijo)
        {
            throw new NotImplementedException();
        }
        public void DesasociarSubRol(int idRolPadre, int idRolHijo)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
