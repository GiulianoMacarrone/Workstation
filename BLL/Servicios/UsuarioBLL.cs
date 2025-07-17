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

        public static UsuarioBE ObtenerUsuarioPorId(string id)
        {
            var lista = DatosDAL.ListarUsuarios();
            return lista.FirstOrDefault(u => u.id == id);
        }


        #region Composite
        public static List<Permiso> ObtenerPermisosEfectivos(UsuarioBE usuario)
        {
            if (usuario == null)
            {
                throw new ArgumentNullException(nameof(usuario));
            }

            var listaPermisos = DatosDAL.ListarPermisos();
            var listaRoles = DatosDAL.ListarRoles();

            var permisoDict = listaPermisos.ToDictionary(p => p.id);
            var composite = ConstruirRolComposite(usuario.idRol, permisoDict, listaRoles, new HashSet<int>());

            foreach (var idPerm in usuario.permisosAdicionales)
                if (permisoDict.TryGetValue(idPerm, out var perm))
                {
                    composite.Add(new PermisoLeaf(perm));
                }

            return composite.ObtenerPermisos().GroupBy(p => p.id).Select(g => g.First()).ToList();
        }

        //Crear ROL HIJO
        public static PermisoComponent ConstruirRolComposite(int rolId, Dictionary<int, Permiso> permisoDict, List<Rol> todosLosRoles, HashSet<int> visitados)
        {
            
            if (!visitados.Add(rolId))
            {
                return new RolComposite();
            }

            var rol = todosLosRoles.FirstOrDefault(r => r.id == rolId);
            if (rol == null) { return new RolComposite(); }

            var composite = new RolComposite();

            foreach (var idPermiso in rol.idsPermisos ?? new List<int>())
            {
                Permiso permiso;
                if (permisoDict.TryGetValue(idPermiso, out permiso)) { composite.Add(new PermisoLeaf(permiso)); }
            }

            foreach (var hijoId in rol.idsRolesHijos ?? new List<int>())
            {
                var subComp = ConstruirRolComposite(
                    hijoId,
                    permisoDict,
                    todosLosRoles,
                    visitados);
                composite.Add(subComp);
            }

            return composite;
        }

        #endregion
        public static UsuarioBE Login(object userInput, object passInput)
        {
            string username = userInput.ToString().Trim();
            string password = passInput.ToString().Trim();

            string passwordEncriptada = Encriptacion.EncriptarPassword(password);

            var usuarios = DatosDAL.ListarUsuarios();
            var usuario = usuarios.FirstOrDefault(u =>
                u.username.Equals(username, StringComparison.OrdinalIgnoreCase) &&
                u.password == passwordEncriptada); 

            return usuario;
        }

        public static bool TienePermiso(UsuarioBE usuario, string nombrePermiso)
        {
            if (usuario == null || string.IsNullOrWhiteSpace(nombrePermiso))
                return false;

            var permisos = ObtenerPermisosEfectivos(usuario);
            return permisos.Any(p => p.nombre.Equals(nombrePermiso, StringComparison.OrdinalIgnoreCase));
        }

        public void GuardarUsuario(UsuarioBE nuevoUsuario)
        {
            var usuarios = DatosDAL.ListarUsuarios();

            if (string.IsNullOrEmpty(nuevoUsuario.id))
            {
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
            }

            nuevoUsuario.password = Encriptacion.EncriptarPassword(nuevoUsuario.password); 
            DatosDAL.GuardarUsuario(nuevoUsuario);
        }

        public List<UsuarioBE> ListarUsuarios()
        {
            return DatosDAL.ListarUsuarios();
        }

        public void AsignarRol(string id, int idRol)
        {
            var usuarios = DatosDAL.ListarUsuarios();
            var usuario = usuarios.FirstOrDefault(u => u.id == id);

            if (usuario == null)
                throw new Exception($"No se encontró el usuario con ID {id}");

            usuario.idRol = idRol;

            // Guardamos el usuario actualizado
            DatosDAL.GuardarUsuario(usuario);
        }

        public void AsignarPermisoAdicional(UsuarioBE usuario, int idPermiso)
        {
            // Obtener permisos efectivos del rol (Composite)
            var permisosEfectivos = ObtenerPermisosEfectivos(usuario)
                .Select(p => p.id).ToList();

            if (permisosEfectivos.Contains(idPermiso))
            {
                throw new InvalidOperationException("Este permiso ya está incluido en el rol asignado al usuario.");

            }

            if (usuario.permisosAdicionales.Contains(idPermiso))
            {
                throw new InvalidOperationException("El usuario ya tiene este permiso adicional.");
            }

            usuario.permisosAdicionales.Add(idPermiso);
            GuardarUsuario(usuario);
        }

        public void QuitarPermisoAdicional(UsuarioBE usuario, int idPermiso) //Logica para sacar permisos SOLO ADICIONALES. Otros permisos provenientes del ROL no.
        {
            if (usuario == null)
            {
                throw new ArgumentNullException(nameof(usuario));
            }

            var permisosDelRol = ObtenerPermisosEfectivos(usuario).Where(p => !usuario.permisosAdicionales.Contains(p.id))
                .Select(p => p.id).ToList();

            if (permisosDelRol.Contains(idPermiso))
            {
                throw new InvalidOperationException("Este permiso proviene del rol asignado y no puede quitarse directamente.");
            }

            if (!usuario.permisosAdicionales.Contains(idPermiso)) { 
                throw new InvalidOperationException("El usuario no tiene este permiso adicional asignado.");
            }

            usuario.permisosAdicionales.Remove(idPermiso);
            GuardarUsuario(usuario);
        }
    }
}
