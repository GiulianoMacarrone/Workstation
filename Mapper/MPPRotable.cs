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
    public class MPPRotable
    {
        public void GuardarRotable(RotableBE rotable)
        {
            var doc = DatosDAL.GetDocumento();
            var contenedor = DatosDAL.GetOrCreateContenedor(doc, "Rotables");

            var nodo = contenedor
                .Elements("Rotable")
                .FirstOrDefault(x => x.Attribute("id")?.Value == rotable.id);

            if (nodo == null)
            {
                int nuevoId = DatosDAL.GenerarIdUnico(contenedor, "Rotable");
                rotable.id = nuevoId.ToString();

                nodo = new XElement("Rotable",
                    new XAttribute("id", rotable.id),
                    new XElement("descripcion", rotable.descripcion),
                    new XElement("partNumber", rotable.partNumber),
                    new XElement("serialNumber", rotable.serialNumber),
                    new XElement("estado", rotable.estado)
                );
                contenedor.Add(nodo);
            }
            else
            {
                nodo.Element("descripcion")?.SetValue(rotable.descripcion);
                nodo.Element("partNumber")?.SetValue(rotable.partNumber);
                nodo.Element("serialNumber")?.SetValue(rotable.serialNumber);
                nodo.Element("estado")?.SetValue(rotable.estado);
            }

            DatosDAL.GuardarDocumento(doc);
        }
        public List<RotableBE> ListarRotables()
        {
            var doc = DatosDAL.GetDocumento();
            var contenedor = DatosDAL.GetOrCreateContenedor(doc, "Rotables");

            return contenedor.Elements("Rotable")
                .Select(x => new RotableBE
                {
                    id = x.Attribute("id")?.Value,
                    descripcion = x.Element("descripcion")?.Value,
                    partNumber = x.Element("partNumber")?.Value,
                    serialNumber = x.Element("serialNumber")?.Value,
                    estado = bool.TryParse(x.Element("estado")?.Value, out var st) && st
                }).ToList();
        }
        public void RegistrarEntregaRotable(string id, string entregadoPor, string recibidoPor)
        {
            var doc = DatosDAL.GetDocumento();
            var nodo = doc.Descendants("Rotable").First(x => x.Attribute("id")?.Value == id);

            var hist = nodo.Element("HistorialEntregas");
            if (hist == null)
            {
                hist = new XElement("HistorialEntregas");
                nodo.Add(hist);
            }

            hist.Add(new XElement("Entrega",
                new XElement("fecha", DateTime.Now),
                new XElement("entregadoPor", entregadoPor),
                new XElement("recibidoPor", recibidoPor)
            ));
            DatosDAL.GuardarDocumento(doc);
        }
    }
}
