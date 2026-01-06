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
    public class HerramientaBLL
    {
        MPPHerramienta mpp = new MPPHerramienta();
        public void GuardarHerramienta(HerramientaBE herramienta)
        {
            mpp.GuardarHerramienta(herramienta);
        }

        public List<HerramientaBE> ListarHerramientas()
        {
            return mpp.ListarHerramientas();
        }

        public void Entregar(HerramientaBE h, string entregadoPor, string recibidoPor)
        {
            mpp.RegistrarEntregaHerramienta(h.id, entregadoPor, recibidoPor);
            h.estado = false;
            mpp.GuardarHerramienta(h);
        }

        public List<HistorialEntregasBE> ListarEntregas()
        {
            var lista = new List<HistorialEntregasBE>();
            var doc = DatosDAL.GetDocumento();

            var nodos = doc.Descendants("Herramienta");

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
                        Tipo = "Herramienta",
                        Fecha = entrega.Element("fecha")?.Value,
                        Cantidad = "", // no aplica
                        EntregadoPor = entrega.Element("entregadoPor")?.Value,
                        RecibidoPor = entrega.Element("recibidoPor")?.Value
                    });
                }
            }

            return lista;
        }

    }
}
