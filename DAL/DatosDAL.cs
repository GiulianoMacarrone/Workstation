using BE;
using BE.Modelo;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DAL
{
    public static class DatosDAL
    {
        private static readonly string xmlPath = "datos.xml";
        private static readonly acceso accesoXml = new acceso(xmlPath);

        #region Metodos Generales
        private static XDocument GetDocumento()
        {
            if (! File.Exists(xmlPath))
            {
                var docNuevo = new XDocument(new XElement("Datos"));
                accesoXml.Save(docNuevo);
            }
            return accesoXml.Load();
        }

        private static void GuardarDocumento(XDocument doc)
        {
            accesoXml.Save(doc);
        }

        private static XElement GetOrCreateContenedor(XDocument doc, string contenedor)
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

        private static int GenerarIdUnico(XElement contenedor, string nombreNodo)
        {
            return contenedor.Elements(nombreNodo)
                .Select(x => (int?)x.Attribute("id") ?? 0)
                .DefaultIfEmpty(0)
                .Max() + 1;
        }
        #endregion

        #region Guardar Datos
        public static void GuardarTrabajo(TrabajoBE trabajo)
        {
            var doc = GetDocumento();
            var contenedor = GetOrCreateContenedor(doc, "Trabajos");
            trabajo.id = GenerarIdUnico(contenedor, "Trabajo");

            var trabajoElem = new XElement("Trabajo",
                new XAttribute("id", trabajo.id),
                new XElement("nroTrabajo", trabajo.nroTrabajo),
                new XElement("titulo", trabajo.titulo),
                new XElement("descripcion", trabajo.descripcion),
                new XElement("intervalo", trabajo.intervalo),
                new XElement("referencias", trabajo.referencias),
                new XElement("nota", trabajo.nota),
                new XElement("ListaTareas",
                    trabajo.listaTareas?.Select(t => new XElement("Tarea", t))
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
            GuardarDocumento(doc);
        }
        public static void GuardarOrdenDeTrabajo(OrdenDeTrabajo ot)
        {
            var doc = GetDocumento();
            var contenedor = GetOrCreateContenedor(doc, "OrdenesDeTrabajo");

            var otElem = new XElement("OrdenDeTrabajo",
                new XElement("numeroOT", ot.numeroOT),
                new XElement("titulo", ot.titulo),
                new XElement("descripcion", ot.descripcion),
                new XElement("fechaInicio", ot.fechaInicio.ToString("yyyy-MM-dd")),
                new XElement("fechaCierre", ot.fechaCierre.ToString("yyyy-MM-dd")),
                new XElement("estado", ot.estado)
            );

            contenedor.Add(otElem);
            GuardarDocumento(doc);
        }
        public static void GuardarUsuario(UsuarioBE usuario)
        {
            var doc = GetDocumento();
            var contenedor = GetOrCreateContenedor(doc, "Usuarios");
            int nuevoId = GenerarIdUnico(contenedor, "Usuario");
            usuario.id = nuevoId.ToString(); 

            var usuarioElem = new XElement("Usuario",
                new XAttribute("id", usuario.id),
                new XElement("username", usuario.username),
                new XElement("password", usuario.password),
                new XElement("nombre", usuario.nombre),
                new XElement("apellido", usuario.apellido),
                new XElement("bloqueado", usuario.bloqueado),
                new XElement("permisosAdicionales",
                    usuario.permisosAdicionales?.Select(p => new XElement("Permiso", p))
                )
            );

            contenedor.Add(usuarioElem);
            GuardarDocumento(doc);
        }
        public static void GuardarAeronave(AeronaveBE aeronave)
        {
            var doc = GetDocumento();
            var contenedor = GetOrCreateContenedor(doc, "Aeronaves");

            int nuevoId = GenerarIdUnico(contenedor, "Aeronave");
            aeronave.id = nuevoId.ToString();

            var elem = new XElement("Aeronave",
                new XAttribute("id", aeronave.id),
                new XElement("marca", aeronave.marca),
                new XElement("modelo", aeronave.modelo),
                new XElement("matricula", aeronave.matricula),
                new XElement("serial", aeronave.serial)
            );

            contenedor.Add(elem);
            GuardarDocumento(doc);
        }
        public static void GuardarNoStock(NoStockBE ns)
        {
            var doc = GetDocumento();
            var contenedor = GetOrCreateContenedor(doc, "NoStocks");

            ns.id = GenerarIdUnico(contenedor, "NoStock");

            var elem = new XElement("NoStock",
                new XAttribute("id", ns.id),
                new XElement("numero", ns.numero),
                new XElement("descripcion", ns.descripcion),
                new XElement("dmiUOt", ns.dmiUOt),
                new XElement("criticidad", ns.criticidad),
                new XElement("aeronave", ns.aeronave),
                new XElement("partNumber", ns.partNumber),
                new XElement("estado", ns.estado)
            );

            contenedor.Add(elem);
            GuardarDocumento(doc);
        }
        public static void GuardarDiferido(Diferido dmi)
        {
            var doc = GetDocumento();
            var contenedor = GetOrCreateContenedor(doc, "Diferidos");

            dmi.id = GenerarIdUnico(contenedor, "Diferido");

            var elem = new XElement("Diferido",
                new XAttribute("id", dmi.id),
                new XElement("numero", dmi.numero),
                new XElement("aeronave", dmi.aeronave),
                new XElement("descripcion", dmi.descripcion),
                new XElement("fechaApertura", dmi.fechaApertura.ToString("yyyy-MM-dd")),
                new XElement("fechaCierre", dmi.fechaCierre.ToString("yyyy-MM-dd")),
                new XElement("estado", dmi.estado),
                new XElement("nroItemMEl", dmi.nroItemMEl ?? ""),
                new XElement("observaciones", dmi.observaciones ?? "")
            );

            // Solo agrega el idNoStock si fue asignado
            if (dmi.idNoStock != null)
                elem.Add(new XElement("idNoStock", dmi.idNoStock.Value));

            contenedor.Add(elem);
            GuardarDocumento(doc);
        }



        #endregion

        #region Listar Datos
        public static List<TrabajoBE> ListarTrabajos()
        {
            var doc = GetDocumento();
            var contenedor = GetOrCreateContenedor(doc, "Trabajos");

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
                        .Elements("Tarea").Select(t => t.Value).ToList() ?? new List<string>(),
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

        public static List<OrdenDeTrabajo> ListarOrdenesDeTrabajo()
        {
            var doc = GetDocumento();
            var contenedor = GetOrCreateContenedor(doc, "OrdenesDeTrabajo");

            var lista = new List<OrdenDeTrabajo>();

            foreach (var nodo in contenedor.Elements("OrdenDeTrabajo"))
            {
                var ot = new OrdenDeTrabajo
                {
                    numeroOT = nodo.Element("numeroOT")?.Value,
                    titulo = nodo.Element("titulo")?.Value,
                    descripcion = nodo.Element("descripcion")?.Value,
                    fechaInicio = DateTime.TryParse(nodo.Element("fechaInicio")?.Value, out var fi) ? fi : DateTime.MinValue,
                    fechaCierre = DateTime.TryParse(nodo.Element("fechaCierre")?.Value, out var fc) ? fc : DateTime.MinValue,
                };

                var estadoNode = nodo.Element("estado")?.Value;
                typeof(OrdenDeTrabajo).GetProperty("estado", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                    ?.SetValue(ot, estadoNode);

                lista.Add(ot);
            }

            return lista;
        }

        public static List<UsuarioBE> ListarUsuarios()
        {
            var doc = GetDocumento();
            var contenedor = GetOrCreateContenedor(doc, "Usuarios");

            var lista = new List<UsuarioBE>();

            foreach (var nodo in contenedor.Elements("Usuario"))
            {
                var usuario = new UsuarioBE
                {
                    id = nodo.Attribute("id")?.Value,
                    username = nodo.Element("username")?.Value,
                    password = nodo.Element("password")?.Value,
                    nombre = nodo.Element("nombre")?.Value,
                    apellido = nodo.Element("apellido")?.Value,
                    bloqueado = bool.TryParse(nodo.Element("bloqueado")?.Value, out var bloq) && bloq,
                    permisosAdicionales = nodo.Element("permisosAdicionales")?
                        .Elements("Permiso").Select(x => x.Value).ToList() ?? new List<string>()
                };

                lista.Add(usuario);
            }

            return lista;
        }

        public static List<AeronaveBE> ListarAeronaves()
        {
            var doc = GetDocumento();
            var contenedor = GetOrCreateContenedor(doc, "Aeronaves");

            return contenedor.Elements("Aeronave")
                .Select(x => new AeronaveBE
                {
                    id = x.Attribute("id")?.Value,
                    marca = x.Element("marca")?.Value,
                    modelo = x.Element("modelo")?.Value,
                    matricula = x.Element("matricula")?.Value,
                    serial = x.Element("serial")?.Value
                }).ToList();
        }

        public static List<NoStockBE> ListarNoStocks()
        {
            var doc = GetDocumento();
            var contenedor = GetOrCreateContenedor(doc, "NoStocks");

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

        public static List<Diferido> ListarDiferidos()
        {
            var doc = GetDocumento();
            var contenedor = GetOrCreateContenedor(doc, "Diferidos");

            return contenedor.Elements("Diferido")
                .Select(x => new Diferido
                {
                    id = int.Parse(x.Attribute("id")?.Value ?? "0"),
                    numero = int.Parse(x.Element("numero")?.Value ?? "0"),
                    aeronave = x.Element("aeronave")?.Value,
                    descripcion = x.Element("descripcion")?.Value,
                    fechaApertura = DateTime.Parse(x.Element("fechaApertura")?.Value ?? DateTime.MinValue.ToString()),
                    fechaCierre = DateTime.Parse(x.Element("fechaCierre")?.Value ?? DateTime.MinValue.ToString()),
                    estado = bool.Parse(x.Element("estado")?.Value ?? "false"),
                    nroItemMEl = x.Element("nroItemMEl")?.Value,
                    observaciones = x.Element("observaciones")?.Value,
                    idNoStock = int.TryParse(x.Element("idNoStock")?.Value, out int idNS) ? idNS : (int?)null
                }).ToList();
        }



        #endregion

        #region Metodos Adicionales
        public static void AsociarNoStockADiferido(int idDiferido, int idNoStock)
        {
            var doc = GetDocumento();
            var contenedor = GetOrCreateContenedor(doc, "Diferidos");

            var dmi = contenedor.Elements("Diferido")
                .FirstOrDefault(x => (int?)x.Attribute("id") == idDiferido);

            if (dmi == null)
                throw new Exception($"No se encontró el DMI con id {idDiferido}");

            // Eliminar si ya existía un idNoStock
            dmi.Element("idNoStock")?.Remove();

            // Agregar nuevo idNoStock
            dmi.Add(new XElement("idNoStock", idNoStock));

            GuardarDocumento(doc);
        }

        #endregion
    }

}
