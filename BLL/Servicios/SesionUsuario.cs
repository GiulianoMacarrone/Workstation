using BE.Composite;
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


            if (c.permiso.Equals(permiso)) //primera vuelta = ver dashboard, segunda vuelta Crear Trabajo 
            {
                Console.WriteLine(c.permiso);
                existe = true; 
            }
            else
            {
                foreach (var item in c.hijos) //no tiene hijos asi que salio directo
                {
                    existe = isInRole(item, permiso, existe);
                    if (existe) return true;
                }
            }

            return existe;
        }

        public bool IsInRole(TipoPermisoBE permiso)
        {
            bool existe = false;
            foreach (var item in UsuarioActual.permisos)
            {
                if (item.permiso.Equals(permiso))
                    return true; //aca retorno TRUE 
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

