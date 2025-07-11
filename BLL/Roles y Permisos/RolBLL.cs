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

        //en usuarioBLL se usa GuardarUsuario y se reescribe el usuario. Aca se usa ActualizarRol. Metodo para probar distinto enfoque
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

        public void AsociarPermiso(Rol rol, int idPermiso)
        {
            if (rol.idsPermisos.Contains(idPermiso)) { throw new InvalidOperationException("El rol ya tiene este permiso"); }
            
            rol.idsPermisos.Add(idPermiso);
            DatosDAL.GuardarRol(rol);
        }

        public void DesasociarPermiso(Rol rol, int idPermiso)
        {
            if (!rol.idsPermisos.Contains(idPermiso)) { throw new InvalidOperationException("El rol no tiene asigando este permiso"); }
            rol.idsPermisos.Remove(idPermiso);
            DatosDAL.GuardarRol(rol);
        }


        public void AsociarSubRol(Rol rolPadre, Rol rolHijo)
        {
            if (rolPadre == null || rolHijo == null)
                throw new ArgumentNullException("Ambos roles deben estar definidos.");

            if (rolPadre.id == rolHijo.id)
                throw new InvalidOperationException("Un rol no puede asociarse a sí mismo.");

            if (rolPadre.idRolesHijos.Contains(rolHijo.id))
                throw new InvalidOperationException("El rol ya está asociado como hijo.");

            rolPadre.idRolesHijos.Add(rolHijo.id);
            DatosDAL.GuardarRol(rolPadre); 

        }
        public void DesasociarSubRol(Rol rolPadre, Rol rolHijo)
        {
            if (rolPadre == null || rolHijo == null)
                throw new ArgumentNullException("Ambos roles deben estar definidos.");

            if (!rolPadre.idRolesHijos.Contains(rolHijo.id))
                throw new InvalidOperationException("Este rol no está asociado como hijo.");

            rolPadre.idRolesHijos.Remove(rolHijo.id);
            DatosDAL.GuardarRol(rolPadre);
        }
        #endregion

    }
}
