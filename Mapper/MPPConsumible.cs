using BE.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using DAL;

namespace Mapper
{
    public class MPPConsumible
    {
        public void GuardarConsumible(Consumible consumible)
        {
            var doc = DatosDAL.GetDocumento();
            var contenedor = DatosDAL.GetOrCreateContenedor(doc, "Consumibles");

            var nodo = contenedor.Elements("Consumible").FirstOrDefault(x => x.Attribute("id")?.Value == consumible.id);


            if (nodo == null)
            {
                int nuevoId = DatosDAL.GenerarIdUnico(contenedor, "Consumible");
                consumible.id = nuevoId.ToString();

                nodo = new XElement("Consumible",
                    new XAttribute("id", consumible.id),
                    new XElement("descripcion", consumible.descripcion),
                    new XElement("partNumber", consumible.partNumber),
                    new XElement("lot", consumible.lot),
                    new XElement("estado", consumible.estado),
                    new XElement("cantidad", consumible.cantidad),
                    new XElement("fechaVto", consumible.fechaVto.ToString("yyyy-MM-dd")),
                    new XElement("HistorialEntregas")
                );
                contenedor.Add(nodo);
            }
            else
            {
                nodo.Element("descripcion")?.SetValue(consumible.descripcion);
                nodo.Element("partNumber")?.SetValue(consumible.partNumber);
                nodo.Element("lot")?.SetValue(consumible.lot);
                nodo.Element("estado")?.SetValue(consumible.estado);
                nodo.Element("cantidad")?.SetValue(consumible.cantidad);
                nodo.Element("fechaVto")?.SetValue(consumible.fechaVto.ToString("yyyy-MM-dd"));
            }

            DatosDAL.GuardarDocumento(doc);
        }

        public List<Consumible> ListarConsumibles()
        {
            var doc = DatosDAL.GetDocumento();
            var cont = DatosDAL.GetOrCreateContenedor(doc, "Consumibles");

            return cont.Elements("Consumible")
                .Select(x => new Consumible
                {
                    id = x.Attribute("id")?.Value,
                    descripcion = x.Element("descripcion")?.Value,
                    partNumber = x.Element("partNumber")?.Value,
                    lot = x.Element("lot")?.Value,
                    estado = bool.TryParse(x.Element("estado")?.Value, out var st) && st,
                    cantidad = int.TryParse(x.Element("cantidad")?.Value, out var ct) ? ct : 0,
                    fechaVto = DateTime.TryParse(x.Element("fechaVto")?.Value, out var fv) ? fv : DateTime.MinValue
                }).ToList();
        }

        public void RegistrarEntregaConsumible(string id, int cantidad, string emisor, string receptor)
        {
            var doc = DatosDAL.GetDocumento();
            var nodo = doc.Descendants("Consumible").First(x => x.Attribute("id")?.Value == id);

            var hist = nodo.Element("HistorialEntregas");
            if (hist == null)
            {
                hist = new XElement("HistorialEntregas");
                nodo.Add(hist);
            }

            hist.Add(new XElement("Entrega",
                        new XElement("fecha", DateTime.Now),
                        new XElement("cantidad", cantidad),
                        new XElement("entregadoPor", emisor),
                        new XElement("recibidoPor", receptor)
                        )
                );

            DatosDAL.GuardarDocumento(doc);
        }
    }
}
