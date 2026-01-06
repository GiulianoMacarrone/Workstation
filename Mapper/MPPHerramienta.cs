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
    public class MPPHerramienta
    {
        public void GuardarHerramienta(HerramientaBE herramienta)
        {
            var doc = DatosDAL.GetDocumento();
            var contenedor = DatosDAL.GetOrCreateContenedor(doc, "Herramientas");

            var nodo = contenedor
                .Elements("Herramienta")
                .FirstOrDefault(x => x.Attribute("id")?.Value == herramienta.id);

            if (nodo == null)
            {
                int nuevoId = DatosDAL.GenerarIdUnico(contenedor, "Herramienta");
                herramienta.id = nuevoId.ToString();

                nodo = new XElement("Herramienta",
                    new XAttribute("id", herramienta.id),
                    new XElement("descripcion", herramienta.descripcion),
                    new XElement("serial", herramienta.serial),
                    new XElement("fechaVtoCalibracion", herramienta.fechaVtoCalibracion.ToString("yyyy-MM-dd")),
                    new XElement("estado", herramienta.estado),
                    new XElement("HistorialEntregas")
                );
                contenedor.Add(nodo);
            }
            else
            {
                nodo.Element("descripcion")?.SetValue(herramienta.descripcion);
                nodo.Element("serial")?.SetValue(herramienta.serial);
                nodo.Element("fechaVtoCalibracion")?
                    .SetValue(herramienta.fechaVtoCalibracion.ToString("yyyy-MM-dd"));
                nodo.Element("estado")?.SetValue(herramienta.estado);
            }

            DatosDAL.GuardarDocumento(doc);
        }

        public List<HerramientaBE> ListarHerramientas()
        {
            var doc = DatosDAL.GetDocumento();
            var cont = DatosDAL.GetOrCreateContenedor(doc, "Herramientas");

            return cont.Elements("Herramienta")
                .Select(x => new HerramientaBE
                {
                    id = x.Attribute("id")?.Value,
                    descripcion = x.Element("descripcion")?.Value,
                    serial = x.Element("serial")?.Value,
                    fechaVtoCalibracion = DateTime.TryParse(
                        x.Element("fechaVtoCalibracion")?.Value,
                        out var fv) ? fv : DateTime.MinValue,
                    estado = bool.TryParse(
                        x.Element("estado")?.Value,
                        out var st) && st
                }
                ).ToList();
        }

        public void RegistrarEntregaHerramienta(string id, string entregadoPor, string recibidoPor)
        {
            var doc = DatosDAL.GetDocumento();
            var nodo = doc.Descendants("Herramienta").First(x => x.Attribute("id")?.Value == id);

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
