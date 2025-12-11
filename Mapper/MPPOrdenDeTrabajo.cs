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
    public class MPPOrdenDeTrabajo
    {
        private readonly MPPTrabajo _mppTrabajo = new MPPTrabajo();
        public void GuardarOrdenDeTrabajo(OrdenDeTrabajo ot)
        {
            var doc = DatosDAL.GetDocumento();
            var contenedor = DatosDAL.GetOrCreateContenedor(doc, "OrdenesDeTrabajo");

            var id = DatosDAL.GenerarIdUnico(contenedor, "OrdenDeTrabajo");
            var otElem = new XElement("OrdenDeTrabajo",
                new XAttribute("id", id),
                new XElement("numeroOT", ot.numeroOT),
                new XElement("titulo", ot.titulo),
                new XElement("descripcion", ot.descripcion),
                new XElement("aeronave", ot.aeronave),
                new XElement("serial", ot.serial),
                new XElement("matricula", ot.matricula),
                new XElement("fechaInicio", ot.fechaInicio.ToString("yyyy-MM-dd")),
                new XElement("fechaCierre", ot.fechaCierre.ToString("yyyy-MM-dd")),
                new XElement("estado", ot.estado),
                new XElement("trabajo", new XAttribute("id", ot.trabajo.id)),
                new XElement("mecanico", ot.mecanico ?? ""),
                new XElement("inspector", ot.inspector ?? ""),
                new XElement("ListaTareas", ot.listaTareasOT.Select(t =>
                    new XElement("Tarea",
                        new XAttribute("nroMecanico", t.nroMecanico ?? ""),
                        new XAttribute("nroInspector", t.nroInspector ?? ""),
                        t.descripcion?.Trim() ?? ""
                    )
            ))
            );

            contenedor.Add(otElem);
            DatosDAL.GuardarDocumento(doc);
        }
        public List<OrdenDeTrabajo> ListarOrdenesDeTrabajo()
        {
            var doc = DatosDAL.GetDocumento();
            var contenedor = DatosDAL.GetOrCreateContenedor(doc, "OrdenesDeTrabajo");

            var lista = new List<OrdenDeTrabajo>();

            foreach (var nodo in contenedor.Elements("OrdenDeTrabajo"))
            {
                int idTrabajo = (int)nodo.Element("trabajo")?.Attribute("id"); 
                var trabajoCompleto = _mppTrabajo.ListarTrabajos().FirstOrDefault(t => t.id == idTrabajo); // lo busco

                var listaTareasOT = nodo.Element("ListaTareas")?
                    .Elements("Tarea").Select(t => new TareaBE
                    {
                        descripcion = t.Value,
                        nroMecanico = t.Attribute("nroMecanico")?.Value ?? "",
                        nroInspector = t.Attribute("nroInspector")?.Value ?? ""
                    }).ToList() ?? new List<TareaBE>();


                var ot = new OrdenDeTrabajo
                {
                    numeroOT = nodo.Element("numeroOT")?.Value,
                    titulo = nodo.Element("titulo")?.Value,
                    descripcion = nodo.Element("descripcion")?.Value,
                    aeronave = nodo.Element("aeronave")?.Value,
                    serial = nodo.Element("serial")?.Value,
                    matricula = nodo.Element("matricula")?.Value,
                    estado = nodo.Element("estado")?.Value,
                    trabajo = trabajoCompleto, 
                    fechaInicio = DateTime.TryParse(nodo.Element("fechaInicio")?.Value, out var fi) ? fi : DateTime.MinValue,
                    fechaCierre = DateTime.TryParse(nodo.Element("fechaCierre")?.Value, out var fc) ? fc : DateTime.MinValue,
                    mecanico = nodo.Element("mecanico")?.Value,
                    inspector = nodo.Element("inspector")?.Value,
                    listaTareasOT = listaTareasOT
                };

                var estadoNode = nodo.Element("estado")?.Value;
                typeof(OrdenDeTrabajo).GetProperty("estado", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                    ?.SetValue(ot, estadoNode);

                lista.Add(ot);
            }

            return lista;
        }
        public void ActualizarOrdenDeTrabajo(OrdenDeTrabajo ot)
        {
            var doc = DatosDAL.GetDocumento();
            var contenedor = DatosDAL.GetOrCreateContenedor(doc, "OrdenesDeTrabajo");

            var nodo = contenedor.Elements("OrdenDeTrabajo").FirstOrDefault(x => x.Element("numeroOT")?.Value == ot.numeroOT);

            if (nodo == null) throw new Exception("No se encontró la OT para actualizar.");

            nodo.Element("ListaTareas")?.Remove();

            var nuevaLista = new XElement("ListaTareas", ot.listaTareasOT.Select(t =>
            {
                var tareaElem = new XElement("Tarea", t.descripcion.Trim());
                if (!string.IsNullOrWhiteSpace(t.nroMecanico))
                    tareaElem.Add(new XAttribute("nroMecanico", t.nroMecanico));

                if (!string.IsNullOrWhiteSpace(t.nroInspector))
                    tareaElem.Add(new XAttribute("nroInspector", t.nroInspector));

                return tareaElem;
            })
            );

            nodo.Add(nuevaLista);

            if (!string.IsNullOrWhiteSpace(ot.estado))
                nodo.Element("estado")?.SetValue(ot.estado);

            if (ot.fechaCierre != DateTime.MinValue)
                nodo.Element("fechaCierre")?.SetValue(ot.fechaCierre.ToString("yyyy-MM-dd"));

            nodo.SetElementValue("mecanico", ot.mecanico ?? string.Empty);
            nodo.SetElementValue("inspector", ot.inspector ?? string.Empty);

            DatosDAL.GuardarDocumento(doc);
        }

        public void EliminarOrdenDeTrabajo(string numeroOT)
        {
            var doc = DatosDAL.GetDocumento();
            var cont = DatosDAL.GetOrCreateContenedor(doc, "OrdenesDeTrabajo");

            var nodo = cont.Elements("OrdenDeTrabajo").FirstOrDefault(x => (string)x.Element("numeroOT") == numeroOT);

            if (nodo == null) throw new InvalidOperationException($"No se encontró la OT con número '{numeroOT}'.");

            nodo.Remove();
            DatosDAL.GuardarDocumento(doc);
        }

        public List<OrdenDeTrabajo> ListarPorPeriodo(DateTime desde, DateTime hasta)
        {
            return ListarOrdenesDeTrabajo()
                .Where(o => 
                o.fechaInicio.Date >= desde.Date && 
                o.fechaInicio.Date <= hasta.Date)
                .ToList();
        }
    }
}
