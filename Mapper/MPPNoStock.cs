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
    public class MPPNoStock
    {
        public void GuardarNoStock(NoStockBE noStock)
        {
            var doc = DatosDAL.GetDocumento();
            var contenedor = DatosDAL.GetOrCreateContenedor(doc, "NoStocks");

            noStock.id = DatosDAL.GenerarIdUnico(contenedor, "NoStock");

            var elem = new XElement("NoStock",
                new XAttribute("id", noStock.id),
                new XElement("numero", noStock.numero),
                new XElement("descripcion", noStock.descripcion),
                new XElement("dmiUOt", noStock.dmiUOt),
                new XElement("criticidad", noStock.criticidad),
                new XElement("aeronave", noStock.aeronave),
                new XElement("partNumber", noStock.partNumber),
                new XElement("estado", noStock.estado)
            );

            contenedor.Add(elem);
            DatosDAL.GuardarDocumento(doc);
        }

        public List<NoStockBE> ListarNoStocks() //cuando guarde en la mapper ListarNoStockPorId
        {
            var doc = DatosDAL.GetDocumento();
            var contenedor = DatosDAL.GetOrCreateContenedor(doc, "NoStocks");

            return contenedor.Elements("NoStock")
                .Select(x => new NoStockBE
                {
                    id = int.Parse(x.Attribute("id")?.Value ?? "0"),
                    numero = int.Parse(x.Element("numero")?.Value ?? "0"),
                    descripcion = x.Element("descripcion")?.Value,
                    dmiUOt = x.Element("dmiUOt")?.Value,
                    criticidad = x.Element("criticidad")?.Value,
                    aeronave = x.Element("aeronave")?.Value,
                    partNumber = x.Element("partNumber")?.Value,
                    estado = bool.Parse(x.Element("estado")?.Value ?? "false")
                }).ToList();
        }

        public void AsociarNoStockADiferido(int idDiferido, int idNoStock)
        {
            var doc = DatosDAL.GetDocumento();
            var contenedor = DatosDAL.GetOrCreateContenedor(doc, "Diferidos");

            var dmi = contenedor.Elements("Diferido")
                .FirstOrDefault(x => (int?)x.Attribute("id") == idDiferido);

            if (dmi == null)
                throw new Exception($"No se encontró el DMI con id {idDiferido}");

            dmi.Element("idNoStock")?.Remove();

            dmi.Add(new XElement("idNoStock", idNoStock));

            DatosDAL.GuardarDocumento(doc);
        }

        public void ActualizarNoStock(NoStockBE noStock)
        {
            var doc = DatosDAL.GetDocumento();
            var contenedor = DatosDAL.GetOrCreateContenedor(doc, "NoStocks");

            var nodo = contenedor.Elements("NoStock")
                .FirstOrDefault(e => (string)e.Element("numero") == noStock.numero.ToString());

            if (nodo == null)
                throw new Exception($"No se encontró el pedido con número {noStock.numero}");

            nodo.Element("estado")?.SetValue(noStock.estado);

            DatosDAL.GuardarDocumento(doc);
        }
    }
}
