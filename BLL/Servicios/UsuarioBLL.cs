using BE;
using BE.Composite;
using BE.Modelo;
using BLL.Servicios;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class UsuarioBLL
    {
        public void ChangePassword(UsuarioBE user, string nuevaPassword)
        {
            if (string.IsNullOrEmpty(nuevaPassword))
            {
                throw new ArgumentException("La nueva contraseña no puede ser nula o vacía.");
            }
            user.password = nuevaPassword;

            //validar contraseña actual
            //guardar en la DAL una vez validada
        }

        public static List<Permiso> ObtenerPermisos(string usuarioId)
        {
            var usuario = ObtenerUsuarioPorId(usuarioId); 
            if (usuario == null)
                throw new Exception("Usuario no encontrado");

            var rol = DatosDAL.ListarRoles().FirstOrDefault(r => r.id == usuario.idRol);
            if (rol == null)
                throw new Exception("Rol no encontrado");

            var listaPermisos = DatosDAL.ListarPermisos();

            var permisosRol = rol.idsPermisos
                .Select(id => listaPermisos.FirstOrDefault(p => p.id == id))
                .Where(p => p != null)
                .ToList();

            var permisosAdicionales = usuario.permisosAdicionales
                .Select(id => listaPermisos.FirstOrDefault(p => p.id == id))
                .Where(p => p != null)
                .ToList();

            return permisosRol
                .Concat(permisosAdicionales)
                .GroupBy(p => p.id)
                .Select(g => g.First())
                .ToList();
        }


        public static bool TienePermiso(string nombrePermiso)
        {
            var permisos = ObtenerPermisosEfectivos(SesionUsuario.Instancia.UsuarioActual.id);
            return permisos.Any(p => p.nombre.Equals(nombrePermiso, StringComparison.OrdinalIgnoreCase));
        }

        public static UsuarioBE ObtenerUsuarioPorId(string id)
        {
            var lista = DatosDAL.ListarUsuarios();
            return lista.FirstOrDefault(u => u.id == id);
        }


        #region Composite
        public static List<Permiso> ObtenerPermisosEfectivos(string idUsuario)
        {
            var usuario = SesionUsuario.Instancia.UsuarioActual;
            var todosPermisos = DatosDAL.ListarPermisos();
            var todosRoles = DatosDAL.ListarRoles();

            var permisoDict = todosPermisos.ToDictionary(p => p.id);
            var composite = new RolComposite();

            Rol rol = todosRoles.FirstOrDefault(r => r.id == usuario.idRol);
            if (rol != null)
            {
                foreach (var idPerm in rol.idsPermisos)
                    if (permisoDict.ContainsKey(idPerm))
                        composite.Add(new PermisoLeaf(permisoDict[idPerm]));
            }

            foreach (var idPerm in usuario.permisosAdicionales)
                if (permisoDict.ContainsKey(idPerm))
                    composite.Add(new PermisoLeaf(permisoDict[idPerm]));

            return composite.ObtenerPermisos();
        }

        #endregion
        public static UsuarioBE Login(object userInput, object passInput)
        {
            string username = userInput.ToString().Trim();
            string password = passInput.ToString().Trim();

            var usuarios = DatosDAL.ListarUsuarios();
            var usuario = usuarios.FirstOrDefault(u =>
                u.username.Equals(username, StringComparison.OrdinalIgnoreCase) &&
                u.password == password);

            return usuario;
        }


    }
}
