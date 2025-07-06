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
        /*public void ChangePassword(UsuarioBE user, string nuevaPassword)
        {
            if (string.IsNullOrEmpty(nuevaPassword))
            {
                throw new ArgumentException("La nueva contraseña no puede ser nula o vacía.");
            }
            user.password = nuevaPassword;

            //validar contraseña actual
            //guardar en la DAL una vez validada
        }*/

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
            var listaPermisos = DatosDAL.ListarPermisos();
            var listaRoles = DatosDAL.ListarRoles();

            var permisoDict = listaPermisos.ToDictionary(p => p.id);
            var composite = new RolComposite();
            var listaTodosLosRoles = listaRoles.ToList();

            Rol rol = listaRoles.FirstOrDefault(r => r.id == usuario.idRol);
            if (rol != null)
            {
                foreach (var idPerm in rol.idsPermisos)
                    if (permisoDict.ContainsKey(idPerm))
                        composite.Add(new PermisoLeaf(permisoDict[idPerm]));
            }

            foreach (var idPerm in usuario.permisosAdicionales)
                if (permisoDict.TryGetValue(idPerm, out var perm))
                    composite.Add(new PermisoLeaf(perm));

            return composite.ObtenerPermisos() //para evitar duplicados agrupamos y seleccionamos
                .GroupBy(p => p.id)
                .Select(g => g.First())
                .ToList();
        }

        //Crear ROL HIJO
        private static PermisoComponent ConstruirRolComposite(int rolId, Dictionary<int, Permiso> permisoDict, List<Rol> todosLosRoles)
        {
            var rol = todosLosRoles.First(r => r.id == rolId);
            var composite = new RolComposite();

            foreach (var idPermiso in rol.idsPermisos)
            {
                if (permisoDict.TryGetValue(idPermiso, out var permiso))
                {
                    composite.Add(new PermisoLeaf(permiso));

                }
            }

            foreach (var hijo in rol.idsRolesHijos ?? Enumerable.Empty<int>())
            {
                var subComposite = ConstruirRolComposite(hijo, permisoDict, todosLosRoles);
                composite.Add(subComposite);
            }

            return composite;
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

        public void GuardarUsuario(UsuarioBE nuevoUsuario)
        {
            var usuarios = DatosDAL.ListarUsuarios();
            int nuevoIdNumerico = usuarios.Select(u => int.TryParse(u.id?.Replace("U", ""), out var n) ? n : 0).DefaultIfEmpty().Max() + 1;
            nuevoUsuario.id = "U" + nuevoIdNumerico.ToString("D4"); // Formato U0001, U0002, etc.

            var rol = DatosDAL.ListarRoles().FirstOrDefault(r => r.id == nuevoUsuario.idRol);
            if (rol != null)
            {
                string designacion = rol.designacion.ToLower();
                if (designacion == "mecanico")
                {
                    int nuevoNroMec = usuarios.Select(u => int.TryParse(u.nroMecanico?.Replace("M", ""), out var m) ? m : 0).DefaultIfEmpty().Max() + 1; //formato M01, M02, etc.
                    nuevoUsuario.nroMecanico = $"M{nuevoNroMec:D2}"; //FORMATO M01, M02, etc.
                }
                else if (designacion == "inspector")
                {
                    int nuevoNroIns = usuarios.Select(u => int.TryParse(u.nroInspector?.Replace("I", ""), out var i) ? i : 0).DefaultIfEmpty().Max() + 1; //formato I01, I02, etc.
                    nuevoUsuario.nroInspector = $"I{nuevoNroIns:D2}"; //FORMATO I01, I02, etc.
                }
                
            }
            DatosDAL.GuardarUsuario(nuevoUsuario);
        }

        public List<UsuarioBE> ListarUsuarios()
        {
            return DatosDAL.ListarUsuarios();
        }
        
    }
}
