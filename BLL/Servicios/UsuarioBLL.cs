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

        public static List<PermisoLeaf> ObtenerPermisosEfectivos(UsuarioBE usuario)
        {
            if (usuario == null)
            {
                throw new ArgumentNullException(nameof(usuario));
            }

            var rolesIds = new HashSet<int>(usuario.rolesAsignados);

            var roles = DatosDAL.ListarRoles().Where(r => rolesIds.Contains(r.id)).ToList();

            var permisosRol = roles.SelectMany(r => r.ObtenerHijos().OfType<PermisoLeaf>()).GroupBy(p => p.id).Select(g => g.First()).ToList();

            var adicionales = DatosDAL.ListarPermisos().Where(p => usuario.permisosAdicionales.Contains(p.id)).ToList();

            return permisosRol.Concat(adicionales).GroupBy(p => p.id).Select(g => g.First()).ToList();
        }

        public void GuardarUsuario(UsuarioBE nuevoUsuario)
        {
            var usuarios = DatosDAL.ListarUsuarios();

            if (string.IsNullOrEmpty(nuevoUsuario.id))
            {
                int nuevoIdNumerico = usuarios.Select(u => int.TryParse(u.id?.Replace("U", ""), out var n) ? n : 0).DefaultIfEmpty().Max() + 1;
                nuevoUsuario.id = "U" + nuevoIdNumerico.ToString("D4"); // Formato U0001, U0002, etc.

                var rolesIds = new HashSet<int>(nuevoUsuario.rolesAsignados);
                var roles = DatosDAL.ListarRoles().Where(r => rolesIds.Contains(r.id)).ToList();

                if (roles.Any(rol => rol.designacion.Equals("mecanico", StringComparison.OrdinalIgnoreCase)))
                {
                    int nuevoNroMec = usuarios.Select(u=> int.TryParse(u.nroMecanico?.Replace("M", ""), out var m) ? m : 0).DefaultIfEmpty().Max() + 1; //formato M01, M02, etc.
                    nuevoUsuario.nroMecanico = "M" + nuevoNroMec.ToString("D2"); // Formato M01, M02, etc.
                }

                if (roles.Any(rol => rol.designacion.Equals("inspector", StringComparison.OrdinalIgnoreCase)))
                {
                    int nuevoNroIns = usuarios.Select(u => int.TryParse(u.nroInspector?.Replace("I", ""), out var i) ? i : 0).DefaultIfEmpty().Max() + 1; //formato I01, I02, etc.  
                    nuevoUsuario.nroInspector = "I" + nuevoNroIns.ToString("D2"); // Formato I01, I02, etc.
                }
            }

            nuevoUsuario.password = Encriptacion.EncriptarPassword(nuevoUsuario.password); 
            DatosDAL.GuardarUsuario(nuevoUsuario);
        }

        public List<UsuarioBE> ListarUsuarios()
        {
            return DatosDAL.ListarUsuarios();
        }
        public void AsignarPermisoAdicional(UsuarioBE usuario, int idPermiso)
        {
            // Obtener permisos efectivos del rol (Composite)
            var permisosEfectivos = ObtenerPermisosEfectivos(usuario).Select(p => p.id).ToHashSet(); 

            if (permisosEfectivos.Contains(idPermiso))
            {
                throw new InvalidOperationException("El usuario ya posee este permiso.");
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

            var permisosDelRol = ObtenerPermisosEfectivos(usuario).Where(p => !usuario.permisosAdicionales.Contains(p.id)).Select(p => p.id).ToHashSet();

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
