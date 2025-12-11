using BE;
using BE.Composite;
using BE.Modelo;
using BLL.Servicios;
using DAL;
using Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class UsuarioBLL
    {
        MPPUsuario oMPPUser;

        public UsuarioBLL()
        {
            oMPPUser = new MPPUsuario();
        }
        public static UsuarioBE Login(object userInput, object passInput)
        {
            string username = userInput.ToString().Trim();
            string password = passInput.ToString().Trim();

            string passwordEncriptada = Encriptacion.EncriptarPassword(password);

            var UsuariosBLL = new UsuarioBLL();
            var usuarios = UsuariosBLL.ListarTodo();
            var usuario = usuarios.FirstOrDefault(u =>
                u.username.Equals(username, StringComparison.OrdinalIgnoreCase) &&
                u.password == passwordEncriptada); 

            return usuario;
        }

        public List<UsuarioBE> ListarTodo()
        {
            return oMPPUser.GetAll();
        }

        public bool GuardarPermisos(UsuarioBE usuario)
        {
            return oMPPUser.GuardarPermisos(usuario);
        }

        public bool GuardarUsuario(UsuarioBE nuevoUsuario)
        {
            nuevoUsuario.username = nuevoUsuario.username?.Trim();
            nuevoUsuario.nombre = nuevoUsuario.nombre?.Trim();
            nuevoUsuario.apellido = nuevoUsuario.apellido?.Trim();
            var passPlano = nuevoUsuario.password; 

            if (string.IsNullOrWhiteSpace(passPlano))
                throw new ArgumentException("La contraseña no puede estar vacía ni ser solo espacios.");

            if (passPlano.Length < 4)
                throw new ArgumentException("La contraseña debe tener al menos 4 caracteres.");

            var usuarios = ListarTodo();

            if (string.IsNullOrEmpty(nuevoUsuario.id))
            {
                int nuevoIdNumerico = usuarios
                    .Select(u => int.TryParse(u.id?.Replace("U", ""), out var n) ? n : 0)
                    .DefaultIfEmpty()
                    .Max() + 1;

                nuevoUsuario.id = "U" + nuevoIdNumerico.ToString("D4"); // U0001, U0002...
            }

            if (string.IsNullOrWhiteSpace(nuevoUsuario.username))
            {
                throw new ArgumentException("El nombre de usuario no puede estar vacío.");
            }
            if (usuarios.Any
                (u => u.username.Equals(nuevoUsuario.username, StringComparison.OrdinalIgnoreCase) && u.id != nuevoUsuario.id)) 
            {
                throw new ArgumentException("El nombre de usuario ya existe."); 
            }

            nuevoUsuario.password = Encriptacion.EncriptarPassword(passPlano);

            return oMPPUser.GuardarUsuario(nuevoUsuario);
        }

        public void AsignarNroMecanicoInspector(UsuarioBE usuario)
        {
            var todosLosPermisos = usuario.permisos
                .SelectMany(comp => AplanarPermisos(comp)).Distinct().ToList();

            bool esMecanico = todosLosPermisos.Any(p => _permisosMecanico.Contains(p));
            bool esInspector = todosLosPermisos.Any(p => _permisosInspector.Contains(p));

            var usuarios = ListarTodo();

            if (esMecanico && string.IsNullOrEmpty(usuario.nroMecanico))
            {
                int nuevoNroMec = usuarios
                    .Select(u => int.TryParse(u.nroMecanico?.Replace("M", ""), out var m) ? m : 0)
                    .DefaultIfEmpty()
                    .Max() + 1;

                usuario.nroMecanico = "M" + nuevoNroMec.ToString("D2");
            }

            if (esInspector && string.IsNullOrEmpty(usuario.nroInspector))
            {
                int nuevoNroIns = usuarios
                    .Select(u => int.TryParse(u.nroInspector?.Replace("I", ""), out var i) ? i : 0)
                    .DefaultIfEmpty()
                    .Max() + 1;

                usuario.nroInspector = "I" + nuevoNroIns.ToString("D2");
            }
        }


        public static List<TipoPermisoBE> AplanarPermisos(Componente comp)
        {
            var permisos = new List<TipoPermisoBE>();

            if (comp is PermisoLeaf leaf)
            {
                permisos.Add(leaf.permiso);
            }
            else
            {
                foreach (var hijo in comp.hijos)
                {
                    permisos.AddRange(AplanarPermisos(hijo));
                }
            }

            return permisos;
        }

        public bool ExisteUsuario(string username, List<UsuarioBE> listaUsuariosActuales)
        {
            return listaUsuariosActuales.Any(u => u.username.Equals(username, StringComparison.OrdinalIgnoreCase));
        }

        //dado que los mecánicos e inspectores tienen permisos especiales, se crean métodos para obtener los permisos específicos de cada uno, sin depender directamente de un permiso "mecánico" o "inspector"
        //es mas que nada por si alguien setea alguno de estos permisos directamente al usuario en vez de a un rol. Sino crashearia a la hora de firmar (lo cual no tiene sentido porque se le dio el permiso de FIRMAR)
        private static readonly HashSet<TipoPermisoBE> _permisosMecanico = new HashSet<TipoPermisoBE> //TipoPermisoBE UNICOS DE MECANICO
        {
            TipoPermisoBE.Ejecutar_OT,
            TipoPermisoBE.Firmar_OT,
            TipoPermisoBE.Consultar_Aeronaves,
            TipoPermisoBE.Firmar_Tarea
        };

        private static readonly HashSet<TipoPermisoBE> _permisosInspector = new HashSet<TipoPermisoBE> //TipoPermisoBE UNICOS DE INSPECTOR
        {
            TipoPermisoBE.Abrir_Diferido,
            TipoPermisoBE.Cerrar_Diferido,
            TipoPermisoBE.Cerrar_OT,
            TipoPermisoBE.Certificar_Tarea
        };
    }
}
