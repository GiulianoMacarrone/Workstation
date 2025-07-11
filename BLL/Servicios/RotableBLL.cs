using BE.Modelo;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Servicios
{
    public class RotableBLL
    {
        public void GuardarRotable(RotableBE rotable)
        {
            DatosDAL.GuardarRotable(rotable);
        }
        public List<RotableBE> ListarRotables()
        {
            return DatosDAL.ListarRotables();
        }
        public void Entregar(RotableBE rotable, string entregadoPor, string recibidoPor)
        {
            if (rotable == null) throw new ArgumentNullException(nameof(rotable));
            DatosDAL.RegistrarEntregaRotable(rotable.id, entregadoPor, recibidoPor);
            rotable.estado = false;
            DatosDAL.GuardarRotable(rotable);
        }
    }
}
