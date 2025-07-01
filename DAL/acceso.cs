using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DAL
{
    public class acceso
    {
        private readonly string _filePath;
        public acceso(string filePath)
        {
            _filePath = filePath;
        }
        public XDocument Load()
        {
            try
            {
                if (!File.Exists(_filePath))
                    throw new FileNotFoundException($"Archivo XML no encontrado: {_filePath}");
                return XDocument.Load(_filePath);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Error al cargar documento XML: {ex.Message}", ex);
            }
        }
        public void Save(XDocument doc)
        {
            try
            {
                if (doc == null)
                    throw new ArgumentNullException(nameof(doc), "El documento XML no puede ser null.");
                var dir = Path.GetDirectoryName(_filePath);
                if (!string.IsNullOrEmpty(dir) && !Directory.Exists(dir))
                    Directory.CreateDirectory(dir);
                doc.Save(_filePath);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Error al guardar documento XML: {ex.Message}", ex);
            }
        }
    }

}
