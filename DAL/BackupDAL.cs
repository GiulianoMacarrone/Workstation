using BE.Backup;
using BE.Modelo;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace DAL
{
    public static class BackupDAL
    {
        private const string RootName = "Backups";
        private const string EventoName = "Evento";
        public static readonly string CarpetaDatos = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data");
        public static readonly string BitacoraPath = Path.Combine(CarpetaDatos, "BitacoraBackups.xml");



        private static XDocument GetDoc()
        {
            Directory.CreateDirectory(CarpetaDatos);
            if (!File.Exists(BitacoraPath))
                new XDocument(new XElement(RootName)).Save(BitacoraPath);

            return XDocument.Load(BitacoraPath);
        }

        private static void SaveDoc(XDocument doc) => doc.Save(BitacoraPath);

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