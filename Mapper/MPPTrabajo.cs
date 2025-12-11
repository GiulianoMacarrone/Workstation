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
    public class MPPTrabajo
    {
        public void GuardarTrabajo(TrabajoBE trabajo)
        {
            var doc = DatosDAL.GetDocumento();
            var contenedor = DatosDAL.GetOrCreateContenedor(doc, "Trabajos");
            trabajo.id = DatosDAL.GenerarIdUnico(contenedor, "Trabajo");

            var trabajoElem = new XElement("Trabajo",
                new XAttribute("id", trabajo.id),
                new XElement("nroTrabajo", trabajo.nroTrabajo),
                new XElement("titulo", trabajo.titulo),
                new XElement("descripcion", trabajo.descripcion),
                new XElement("intervalo", trabajo.intervalo),
                new XElement("referencias", trabajo.referencias),
                new XElement("nota", trabajo.nota),
                new XElement("ListaTareas",
                    trabajo.listaTareas?.Select(t => new XElement("Tarea",
                        new XAttribute("nroMecanico", t.nroMecanico ?? ""),
                        new XAttribute("nroInspector", t.nroInspector ?? ""),
                        t.descripcion ?? ""
                    ))
                ),
                new XElement("ListaMateriales",
                    trabajo.listaMateriales?.Select(m => new XElement("Item",
                        new XAttribute("PN", m.PN ?? ""),
                        new XAttribute("Descripcion", m.Descripcion ?? ""),
                        new XAttribute("QTY", m.QTY)
                    ))
                ),
                new XElement("ListaHerramientas",
                    trabajo.listaHerramientas?.Select(h => new XElement("Item",
                        new XAttribute("PN", h.PN ?? ""),
                        new XAttribute("Descripcion", h.Descripcion ?? ""),
                        new XAttribute("QTY", h.QTY)
                    ))
                )
            );

            contenedor.Add(trabajoElem);
            DatosDAL.GuardarDocumento(doc);
        }

        public List<TrabajoBE> ListarTrabajos()
        {
            var doc = DatosDAL.GetDocumento();
            var contenedor = DatosDAL.GetOrCreateContenedor(doc, "Trabajos");

            var lista = new List<TrabajoBE>();

            foreach (var nodo in contenedor.Elements("Trabajo"))
            {
                var trabajo = new TrabajoBE
                {
                    id = (int)nodo.Attribute("id"),
                    nroTrabajo = nodo.Element("nroTrabajo")?.Value,
                    titulo = nodo.Element("titulo")?.Value,
                    descripcion = nodo.Element("descripcion")?.Value,
                    intervalo = nodo.Element("intervalo")?.Value,
                    referencias = nodo.Element("referencias")?.Value,
                    nota = nodo.Element("nota")?.Value,

                    listaTareas = nodo.Element("ListaTareas")?
                        .Elements("Tarea").Select(t => new TareaBE
                        {
                            descripcion = t.Value,
                            nroMecanico = t.Attribute("nroMecanico")?.Value,
                            nroInspector = t.Attribute("nroInspector")?.Value
                        }).ToList() ?? new List<TareaBE>(),

                    listaMateriales = nodo.Element("ListaMateriales")?
                        .Elements("Item").Select(x => new ItemOTBE
                        {
                            PN = x.Attribute("PN")?.Value,
                            Descripcion = x.Attribute("Descripcion")?.Value,
                            QTY = int.TryParse(x.Attribute("QTY")?.Value, out var qty) ? qty : 0
                        }).ToList() ?? new List<ItemOTBE>(),
                    listaHerramientas = nodo.Element("ListaHerramientas")?
                        .Elements("Item").Select(x => new ItemOTBE
                        {
                            PN = x.Attribute("PN")?.Value,
                            Descripcion = x.Attribute("Descripcion")?.Value,
                            QTY = int.TryParse(x.Attribute("QTY")?.Value, out var qty) ? qty : 0
                        }).ToList() ?? new List<ItemOTBE>()
                };

                lista.Add(trabajo);
            }

            return lista;
        }

        public void EliminarTrabajo(int idTrabajo)
        {
            var doc = DatosDAL.GetDocumento();
            var contenedor = DatosDAL.GetOrCreateContenedor(doc, "Trabajos");
            var contenedorOTs = DatosDAL.GetOrCreateContenedor(doc, "OrdenesDeTrabajo");

            var nodo = contenedor.Elements("Trabajo").FirstOrDefault(x => (int)x.Attribute("id") == idTrabajo);

            if (nodo != null)
            {
                nodo.Remove();
                DatosDAL.GuardarDocumento(doc);
            }
            else
            {
                throw new InvalidOperationException($"No se encontró el trabajo con id {idTrabajo}.");
            }

            bool trabajoEnUso = contenedorOTs.Elements("OrdenDeTrabajo")
                .Any(ot => (int)ot.Element("trabajo").Attribute("id") == idTrabajo);
            if (trabajoEnUso)
            {
                throw new InvalidOperationException($"No se puede eliminar el trabajo #{idTrabajo} porque está asociado a una orden de trabajo.");
            }

            nodo.Remove();
            DatosDAL.GuardarDocumento(doc);
        }
    }
}
