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
    public class MPPDiferido
    {
        public void GuardarDiferido(Diferido dmi)
        {
            var doc = DatosDAL.GetDocumento();
            var contenedor = DatosDAL.GetOrCreateContenedor(doc, "Diferidos");

            dmi.id = DatosDAL.GenerarIdUnico(contenedor, "Diferido");

            var elem = new XElement("Diferido",
                new XAttribute("id", dmi.id),
                new XElement("numero", dmi.numero),
                new XElement("aeronave", dmi.aeronave),
                new XElement("descripcion", dmi.descripcion),
                new XElement("fechaApertura", dmi.fechaApertura.ToString("yyyy-MM-dd")),
                new XElement("estado", dmi.estado),
                new XElement("nroItemMEl", dmi.nroItemMEl ?? ""),
                new XElement("observaciones", dmi.observaciones ?? "")
            );

            // Solo agrega el idNoStock si fue asignado
            if (dmi.idNoStock != null)
                elem.Add(new XElement("idNoStock", dmi.idNoStock.Value));

            contenedor.Add(elem);
            DatosDAL.GuardarDocumento(doc);
        }

        public List<Diferido> ListarDiferidos()
        {
            var doc = DatosDAL.GetDocumento();
            var contenedor = DatosDAL.GetOrCreateContenedor(doc, "Diferidos");

            return contenedor.Elements("Diferido").Select(x => new Diferido
            {
                id = int.Parse(x.Attribute("id")?.Value ?? "0"),
                numero = int.Parse(x.Element("numero")?.Value ?? "0"),
                aeronave = x.Element("aeronave")?.Value,
                descripcion = x.Element("descripcion")?.Value,
                fechaApertura = DateTime.Parse(x.Element("fechaApertura")?.Value ?? DateTime.MinValue.ToString()),
                fechaCierre = DateTime.Parse(x.Element("fechaCierre")?.Value ?? DateTime.MinValue.ToString()),
                estado = bool.Parse(x.Element("estado")?.Value ?? "false"),
                nroItemMEl = x.Element("nroItemMEl")?.Value,
                observaciones = x.Element("observaciones")?.Value,
                idNoStock = int.TryParse(x.Element("idNoStock")?.Value, out int idNS) ? idNS : (int?)null
            }).ToList();
        }
        public void ActualizarDiferido(Diferido dmi)
        {
            var doc = DatosDAL.GetDocumento();
            var contenedor = DatosDAL.GetOrCreateContenedor(doc, "Diferidos");

            var nodo = contenedor.Elements("Diferido")
                .FirstOrDefault(x => (int)x.Attribute("id") == dmi.id);
            if (nodo == null) throw new InvalidOperationException($"No se encontró el diferido {dmi.id} para actualizar.");

            nodo.Element("estado")?.SetValue(dmi.estado);
            nodo.Element("fechaCierre")?.SetValue(dmi.fechaCierre.ToString("yyyy-MM-dd"));

            DatosDAL.GuardarDocumento(doc);
        }
    }
}
