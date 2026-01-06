using BE.Composite;
using DocumentFormat.OpenXml.Office2016.Drawing.Command;
using Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Servicios
{
    public class SesionUsuario
    {
        private static SesionUsuario instancia;

        public UsuarioBE UsuarioActual { get; private set; }

        public SesionUsuario()
        {
        }
        private SesionUsuario(UsuarioBE usuario)
        {
            UsuarioActual = usuario;
        }

        public static void IniciarSesion(UsuarioBE usuario)
        {
            if (instancia == null)
            {
                instancia = new SesionUsuario(usuario);
            }
        }

        public static SesionUsuario Instancia => instancia;

        public static void CerrarSesion()
        {
            instancia = null;
        }

        bool isInRole(Componente c, TipoPermisoBE permiso, bool existe)
        {
            if (c.permiso.Equals(permiso)) 
            {
                Console.WriteLine(c.permiso);
                existe = true; 
            }
            else
            {
                foreach (var item in c.hijos) 
                {
                    existe = isInRole(item, permiso, existe);
                    if (existe) return true;
                }
            }

            return existe;
        }

        public bool IsInRole(TipoPermisoBE permiso)
        {
            if (UsuarioActual == null) return false;

            bool existe = false;
            foreach (var item in UsuarioActual.permisos)
            {
                if (item.permiso.Equals(permiso))
                    return true;
                else
                {
                    existe = isInRole(item, permiso, existe);
                    if (existe) return true;
                }
            }

            return existe;
        }

    }

}

