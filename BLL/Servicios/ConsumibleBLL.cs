using BE.Modelo;
using Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Servicios
{
    public class ConsumibleBLL
    {
        MPPConsumible mpp = new MPPConsumible();
        public void GuardarConsumible(Consumible consumible)
        {
            mpp.GuardarConsumible(consumible);
        }

        public List<Consumible> ListarConsumibles()
        {
            return mpp.ListarConsumibles();
        }

        public void Consumir(Consumible consumible, int cantidad, string entregadoPor, string recibidoPor)
        {
            if (consumible == null)
                throw new ArgumentNullException(nameof(consumible));

            if (cantidad < 1)
                throw new ArgumentException("La cantidad a consumir debe ser mayor que cero.");

            if (consumible.cantidad < cantidad)
                throw new InvalidOperationException("Stock insuficiente.");

            consumible.cantidad -= cantidad;

            mpp.GuardarConsumible(consumible);

            mpp.RegistrarEntregaConsumible(
                consumible.id,
                cantidad,
                entregadoPor,
                recibidoPor
                );
        }
    }
}
