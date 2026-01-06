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

        public List<HistorialEntregasBE> ListarEntregas()
        {
            var lista = new List<HistorialEntregasBE>();
            var doc = DatosDAL.GetDocumento();

            var nodos = doc.Descendants("Rotable");

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
                        Tipo = "Rotable",
                        Fecha = entrega.Element("fecha")?.Value,
                        Cantidad = "1", // siempre es 1 para rotable
                        EntregadoPor = entrega.Element("entregadoPor")?.Value,
                        RecibidoPor = entrega.Element("recibidoPor")?.Value
                    });
                }
            }

            return lista;
        }

    }
}
