using BE.Modelo;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Mapper
{
    public class MPPAeronave
    {
        public void ActualizarAeronave(AeronaveBE aeronave)
        {
            var doc = DatosDAL.GetDocumento();
            var contenedor = DatosDAL.GetOrCreateContenedor(doc, "Aeronaves");

            var nodo = contenedor.Elements("Aeronave")
                .FirstOrDefault(x => x.Attribute("id")?.Value == aeronave.id);

            if (nodo == null)
                throw new Exception("La aeronave no existe para ser actualizada.");

            nodo.SetElementValue("marca", aeronave.marca);
            nodo.SetElementValue("modelo", aeronave.modelo);
            nodo.SetElementValue("matricula", aeronave.matricula);
            nodo.SetElementValue("serial", aeronave.serial);
            nodo.SetElementValue("EstadoActual", aeronave.estadoActual.ToString());

            DatosDAL.GuardarDocumento(doc);
        }

        public void GuardarAeronave(AeronaveBE aeronave)
        {
            var doc = DatosDAL.GetDocumento();
            var contenedor = DatosDAL.GetOrCreateContenedor(doc, "Aeronaves");

            int nuevoId = DatosDAL.GenerarIdUnico(contenedor, "Aeronave");
            aeronave.id = nuevoId.ToString();

            var elem = new XElement("Aeronave",
                new XAttribute("id", aeronave.id),
                new XElement("marca", aeronave.marca),
                new XElement("modelo", aeronave.modelo),
                new XElement("matricula", aeronave.matricula),
                new XElement("serial", aeronave.serial),
                new XElement("EstadoActual", aeronave.estadoActual.ToString())
            );

            contenedor.Add(elem);
            DatosDAL.GuardarDocumento(doc);
        }

        public List<AeronaveBE> ListarAeronaves()
        {
            var doc = DatosDAL.GetDocumento();  
            var contenedor = DatosDAL.GetOrCreateContenedor(doc, "Aeronaves");

            return contenedor.Elements("Aeronave")
                .Select(x => new AeronaveBE
                {
                    id = x.Attribute("id")?.Value,
                    marca = x.Element("marca")?.Value,
                    modelo = x.Element("modelo")?.Value,
                    matricula = x.Element("matricula")?.Value,
                    serial = x.Element("serial")?.Value,
                    estadoActual = Enum.TryParse<EstadoAeronave>(x.Element("EstadoActual")?.Value, out var estado) ? estado : EstadoAeronave.FueraDeServicio
                }).ToList();
        }


    }
}
