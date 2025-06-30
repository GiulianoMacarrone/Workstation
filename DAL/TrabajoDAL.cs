using BE.Modelo;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace DAL
{
    public static class TrabajoDAL
    {
        private static readonly string xmlPath = "datos.xml";

        public static void CrearTrabajo(TrabajoBE nuevoTrabajo)
        {
            if (!File.Exists(xmlPath))
            {
                // Crear estructura inicial si no existe
                var root = new XElement("Datos",
                    new XElement("Trabajos")
                );
                root.Save(xmlPath);
            }

            var doc = XDocument.Load(xmlPath);
            var trabajosElem = doc.Root.Element("Trabajos");
            if (trabajosElem == null)
            {
                trabajosElem = new XElement("Trabajos");
                doc.Root.Add(trabajosElem);
            }

            // Generar ID único (buscar el mayor y sumar 1)
            int nuevoId = 1;
            if (trabajosElem.Elements("Trabajo").Any())
            {
                nuevoId = trabajosElem.Elements("Trabajo")
                    .Max(x => (int?)x.Attribute("id") ?? 0) + 1;
            }
            nuevoTrabajo.id = nuevoId;

            // Serializar listas de ItemOTBE
            XElement ListaMaterialesToXml(List<ItemOTBE> lista, string nombre)
            {
                return new XElement(nombre,
                    lista?.Select(item => new XElement("Item",
                        new XAttribute("PN", item.PN ?? ""),
                        new XAttribute("Descripcion", item.Descripcion ?? ""),
                        new XAttribute("QTY", item.QTY)
                    )) ?? new List<XElement>()
                );
            }

            XElement ListaTareasToXml(List<string> lista)
            {
                return new XElement("ListaTareas",
                    lista?.Select(t => new XElement("Tarea", t)) ?? new List<XElement>()
                );
            }

            var trabajoElem = new XElement("Trabajo",
                new XAttribute("id", nuevoTrabajo.id),
                new XElement("nroTrabajo", nuevoTrabajo.nroTrabajo),
                new XElement("titulo", nuevoTrabajo.titulo ?? ""),
                new XElement("descripcion", nuevoTrabajo.descripcion ?? ""),
                new XElement("intervalo", nuevoTrabajo.intervalo ?? ""),
                new XElement("referencias", nuevoTrabajo.referencias ?? ""),
                new XElement("nota", nuevoTrabajo.nota ?? ""),
                ListaTareasToXml(nuevoTrabajo.listaTareas),
                ListaMaterialesToXml(nuevoTrabajo.listaMateriales, "ListaMateriales"),
                ListaMaterialesToXml(nuevoTrabajo.listaHerramientas, "ListaHerramientas")
            );

            trabajosElem.Add(trabajoElem);
            doc.Save(xmlPath);
        }

        public static bool ExisteNroTrabajo(int nroTrabajo)
        {
            if (!File.Exists(xmlPath)) return false;
            var doc = XDocument.Load(xmlPath);
            var trabajosElem = doc.Root.Element("Trabajos");
            if (trabajosElem == null) return false;
            return trabajosElem.Elements("Trabajo")
                .Any(x => (int?)x.Element("nroTrabajo") == nroTrabajo);
        }
    }
}
