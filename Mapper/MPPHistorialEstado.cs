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
    public class MPPHistorialEstado
    {
        public bool Guardar(HistorialEstadoBE historial)
        {
            try
            {
                var doc = DatosDAL.GetDocumento();
                var contenedor = DatosDAL.GetOrCreateContenedor(doc, "HistorialEstados");

                var nodoExistente = contenedor.Elements("Historial")
                    .FirstOrDefault(x => x.Attribute("id")?.Value == historial.id);

                if (nodoExistente != null)
                    nodoExistente.Remove();

                int nuevoId = DatosDAL.GenerarIdUnico(contenedor, "Historial");
                historial.id = nuevoId.ToString();

                var nodo = new XElement("Historial",
                    new XAttribute("id", historial.id),
                    new XElement("aeronaveId", historial.aeronaveId),
                    new XElement("marca", historial.marca),
                    new XElement("modelo", historial.modelo),
                    new XElement("matricula", historial.matricula),
                    new XElement("estadoRegistrado", historial.estadoRegistrado.ToString()),
                    new XElement("fechaEstado", historial.fechaEstado.ToString("yyyy-MM-dd")),
                    new XElement("motivo", historial.motivo ?? ""),
                    new XElement("numeroOT", historial.numeroOT ?? ""),
                    new XElement("registradoPor", historial.registradoPor)
                );

                contenedor.Add(nodo);
                DatosDAL.GuardarDocumento(doc);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<HistorialEstadoBE> GetAll()
        {
            var lista = new List<HistorialEstadoBE>();
            var doc = DatosDAL.GetDocumento();
            var contenedor = DatosDAL.GetOrCreateContenedor(doc, "HistorialEstados");

            foreach (var nodo in contenedor.Elements("Historial"))
            {
                var historial = new HistorialEstadoBE
                {
                    id = nodo.Attribute("id")?.Value,
                    aeronaveId = nodo.Element("aeronaveId")?.Value,
                    marca = nodo.Element("marca")?.Value,
                    modelo = nodo.Element("modelo")?.Value,
                    matricula = nodo.Element("matricula")?.Value,
                    estadoRegistrado = Enum.TryParse<EstadoAeronave>(nodo.Element("estadoRegistrado")?.Value, out var estado) ? estado : EstadoAeronave.FueraDeServicio,
                    fechaEstado = DateTime.TryParse(nodo.Element("fechaEstado")?.Value, out var fecha) ? fecha : DateTime.MinValue,
                    motivo = nodo.Element("motivo")?.Value,
                    numeroOT = nodo.Element("numeroOT")?.Value,
                    registradoPor = nodo.Element("registradoPor")?.Value
                };

                lista.Add(historial);
            }

            return lista;
        }
    }
}
