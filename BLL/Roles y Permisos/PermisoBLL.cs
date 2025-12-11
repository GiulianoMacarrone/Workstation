using BE.Composite;
using BE.Modelo;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using Mapper;

namespace BLL.Roles
{
    public class PermisoBLL
    {
        MPPPermiso oMPPPermiso;

        public PermisoBLL()
        {
            oMPPPermiso = new MPPPermiso();
        }

        public bool Existe(Componente c, int id)
        {
            bool existe = false;
            if (c.id.Equals(id)) existe = true;
            else
            {
                foreach (var item in c.hijos)
                {
                    existe = Existe(item, id);
                    if (existe) return true;
                }
            }
            return existe;
        }

        public Array GetAllPermission()
        {
            return oMPPPermiso.GetAllTypePermission();
        }

        public Componente GuardarComponente(Componente p, bool esRol)
        {
            return oMPPPermiso.GuardarComponente(p, esRol);
        }

        public void GuardarRol(RolComposite r)
        {
            oMPPPermiso.GuardarComponente(r, true);
        }

        public IList<PermisoLeaf> GetAllPermisos()
        {
            return oMPPPermiso.GetAllPermisos();
        }

        public IList<RolComposite> GetAllRoles()
        {
            return oMPPPermiso.GetAllRoles();
        }

        public IList<Componente> GetAll()
        {
            return oMPPPermiso.GetAll();
        }

        public void FillUserComponents(UsuarioBE u)
        {
            oMPPPermiso.FillUserComponents(u);
        }

        public void FillRolComponents(RolComposite rol)
        {
            oMPPPermiso.FillRolComponents(rol);
        }

        public void EliminarComponente(Componente componente)
        {
            oMPPPermiso.BorrarComponente(componente);
        }
    } 
}

