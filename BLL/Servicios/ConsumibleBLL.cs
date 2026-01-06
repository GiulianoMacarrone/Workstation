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

        public List<HistorialEntregasBE> ListarEntregas()
        {
            var lista = new List<HistorialEntregasBE>();
            var doc = DatosDAL.GetDocumento();

            var nodos = doc.Descendants("Consumible");

            foreach (var nodo in nodos)
            {
                var id = nodo.Attribute("id")?.Value;
                var hist = nodo.Element("HistorialEntregas");
                if (hist == null) continue;

                foreach (var entrega in hist.Elements("Entrega"))
                {
                    lista.Add(new HistorialEntregasBE
                    {
                        IdElemento = id,
                        Tipo = "Consumible",
                        Fecha = entrega.Element("fecha")?.Value,
                        Cantidad = entrega.Element("cantidad")?.Value,
                        EntregadoPor = entrega.Element("entregadoPor")?.Value,
                        RecibidoPor = entrega.Element("recibidoPor")?.Value
                    });
                }
            }

            return lista;
        }
    }
}
