using BE.Modelo;
using DAL;
using Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Servicios
{
    public class RotableBLL
    {
        MPPRotable mpp = new MPPRotable();
        public void GuardarRotable(RotableBE rotable)
        {
            mpp.GuardarRotable(rotable);
        }
        public List<RotableBE> ListarRotables()
        {
            return mpp.ListarRotables();
        }
        public void Entregar(RotableBE rotable, string entregadoPor, string recibidoPor)
        {
            if (rotable == null) throw new ArgumentNullException(nameof(rotable));
            mpp.RegistrarEntregaRotable(rotable.id, entregadoPor, recibidoPor);
            rotable.estado = false;
            mpp.GuardarRotable(rotable);
        }
    }
}
