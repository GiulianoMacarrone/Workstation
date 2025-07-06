using BE.Modelo;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Roles
{
    public class PermisoBLL
    {
        public List<Permiso> ListarPermisos()
        {
            return DatosDAL.ListarPermisos();
        }
    }
}
