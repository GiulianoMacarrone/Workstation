using BE;
using BE.Composite;
using BE.Modelo;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DAL
{
    public static class DatosDAL
    {
        private static readonly string xmlPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "datos.xml");
        private static readonly Acceso accesoXml = new Acceso(xmlPath);

        #region Metodos Generales
        public static XDocument GetDocumento()
        {
            if (!File.Exists(xmlPath))
            {
                var docNuevo = new XDocument(new XElement("Datos"));
                accesoXml.Save(docNuevo);
            }
            return accesoXml.Load();
        }

        public static void GuardarDocumento(XDocument doc)
        {
            accesoXml.Save(doc);
        }

        public static XElement GetOrCreateContenedor(XDocument doc, string contenedor)
        {
            var root = doc.Root;
            var nodo = root.Element(contenedor);
            if (nodo == null)
            {
                nodo = new XElement(contenedor);
                root.Add(nodo);
            }
            return nodo;
        }

        public static int GenerarIdUnico(XElement contenedor, string nombreNodo)
        {
            return contenedor.Elements(nombreNodo)
                .Select(x => (int?)x.Attribute("id") ?? 0)
                .DefaultIfEmpty(0)
                .Max() + 1;
        }
        #endregion
    }

}
