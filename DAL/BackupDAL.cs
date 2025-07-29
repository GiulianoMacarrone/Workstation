using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using BE.Backup;
using BE.Modelo;

namespace DAL
{
    public static class BackupDAL
    {
        private const string RootName = "Backups";
        private const string EventoName = "Evento";
        private const string FileName = "BitacoraBackups.xml";

        private static XDocument GetDoc()
        {
            if (!System.IO.File.Exists(FileName))
            {
                new XDocument(new XElement(RootName)).Save(FileName);
            }

            return XDocument.Load(FileName);
        }

        private static void SaveDoc(XDocument doc) => doc.Save(FileName);

        private static int NextId(XElement root) => root.Elements(EventoName).Select(x => (int)x.Attribute("id")).DefaultIfEmpty(0).Max() + 1;

        public static void GuardarEvento(Backup ev)
        {
            var doc = GetDoc();
            var root = doc.Root;
            var id = NextId(root);

            ev.Id = id;
            root.Add(new XElement(EventoName,
                       new XAttribute("id", id),
                       new XElement("fecha", ev.Fecha.ToString("o")),
                       new XElement("operacion", ev.Operacion),
                       new XElement("usuario", ev.Usuario),
                       new XElement("archivoPath", ev.ArchivoPath)
                   ));
            SaveDoc(doc);
        }

        public static List<Backup> ListarEventos()
        {
            var doc = GetDoc();
            return doc.Root.Elements(EventoName)
                .Select(x => new Backup
                {
                    Id = (int)x.Attribute("id"),
                    Fecha = DateTime.Parse(x.Element("fecha")?.Value),
                    Operacion = x.Element("operacion")?.Value,
                    Usuario = x.Element("usuario")?.Value,
                    ArchivoPath = x.Element("archivoPath")?.Value
                })
                .OrderByDescending(e => e.Fecha).ToList();
        }
    }
}