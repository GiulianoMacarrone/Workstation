using BE;
using BE.Composite;
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
                new XElement("aeronave", ot.aeronave),
                new XElement("serial", ot.serial),
                new XElement("matricula", ot.matricula),
                new XElement("fechaInicio", ot.fechaInicio.ToString("yyyy-MM-dd")),
                new XElement("fechaCierre", ot.fechaCierre.ToString("yyyy-MM-dd")),
                new XElement("estado", ot.estado),
                new XElement("trabajo",
                    new XAttribute("id", ot.trabajo.id)
                )
            );

            contenedor.Add(otElem);
            GuardarDocumento(doc);
        }
        public static void GuardarUsuario(UsuarioBE usuario)
        {
            var doc = GetDocumento();
            var contenedor = GetOrCreateContenedor(doc, "Usuarios");

            //se agregio para guardar usuario en general. Si ya existe lo reemplaza, si no existe creamos uno nuevo. De esta forma lo actualizo.
            var nodoExistente = contenedor.Elements("Usuario").FirstOrDefault(x => (string)x.Attribute("id") == usuario.id);
            if (nodoExistente != null)
            {
                nodoExistente.Remove();
            }

            var usuarioElem = new XElement("Usuario",
                new XAttribute("id", usuario.id), //el id lo generamos en la BLL con formato U0001
                new XElement("username", usuario.username),
                new XElement("password", usuario.password),
                new XElement("nombre", usuario.nombre),
                new XElement("apellido", usuario.apellido),
                new XElement("bloqueado", usuario.bloqueado.ToString().ToLower()),
                new XElement("idRol", usuario.idRol),
                new XElement("permisosAdicionales",usuario.permisosAdicionales?.Select(p => new XElement("Permiso", p))
                )
            );
            if(!string.IsNullOrEmpty(usuario.nroMecanico))
            {
                usuarioElem.Add(new XElement("nroMecanico", usuario.nroMecanico));
            }
            if(!string.IsNullOrEmpty(usuario.nroInspector))
            {
                usuarioElem.Add(new XElement("nroInspector", usuario.nroInspector));
            }

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
        public static void GuardarPermiso(Permiso permiso)
        {
            var doc = GetDocumento();
            var contenedor = GetOrCreateContenedor(doc, "Permisos");

            permiso.id = GenerarIdUnico(contenedor, "Permiso");

            var elem = new XElement("Permiso",
                new XAttribute("id", permiso.id),
                new XElement("nombre", permiso.nombre)
            );

            contenedor.Add(elem);
            GuardarDocumento(doc);
        }
        public static void GuardarRol(Rol rol)
        {
            var doc = GetDocumento();
            var contenedor = GetOrCreateContenedor(doc, "Roles");


            if (rol.id == 0) 
            {
                rol.id = GenerarIdUnico(contenedor, "Rol");
            }
            
            //se borra el nodo actual y se crea uno nuevo. ActualizarRol() podría eliminarse como se hizo con GuardarUsuario()
            var nodoExistente = contenedor.Elements("Rol").FirstOrDefault(r => (int)r.Attribute("id") == rol.id);
            if (nodoExistente != null) nodoExistente.Remove();

            var newRol = new XElement("Rol",
                new XAttribute("id", rol.id),
                new XElement("designacion", rol.designacion),
                new XElement("Permisos", rol.idsPermisos.Select(id => new XElement("idPermiso", id))),
                new XElement("RolesHijos", rol.idRolesHijos.Select(id => new XElement("idRol", id)))
            );

            contenedor.Add(newRol);
            GuardarDocumento(doc);
        }
        public static void GuardarConsumible(Consumible consumible)
        {
            var doc = GetDocumento();
            var contenedor = GetOrCreateContenedor(doc, "Consumibles");

            var nodo = contenedor.Elements("Consumible").FirstOrDefault(x => x.Attribute("id")?.Value == consumible.id);
            

            if (nodo == null)
            {
                int nuevoId = GenerarIdUnico(contenedor, "Consumible");
                consumible.id = nuevoId.ToString();

                nodo = new XElement("Consumible",
                    new XAttribute("id", consumible.id),
                    new XElement("descripcion", consumible.descripcion),
                    new XElement("partNumber", consumible.partNumber),
                    new XElement("lot", consumible.lot),
                    new XElement("estado", consumible.estado),
                    new XElement("cantidad", consumible.cantidad),
                    new XElement("fechaVto", consumible.fechaVto.ToString("yyyy-MM-dd")),
                    new XElement("HistorialEntregas")
                );
                contenedor.Add(nodo);
            }
            else
            {
                nodo.Element("descripcion")?.SetValue(consumible.descripcion);
                nodo.Element("partNumber")?.SetValue(consumible.partNumber);
                nodo.Element("lot")?.SetValue(consumible.lot);
                nodo.Element("estado")?.SetValue(consumible.estado);
                nodo.Element("cantidad")?.SetValue(consumible.cantidad);
                nodo.Element("fechaVto")?.SetValue(consumible.fechaVto.ToString("yyyy-MM-dd"));
            }

            GuardarDocumento(doc);
        }
        public static void GuardarRotable(RotableBE rotable)
        {
            var doc = GetDocumento();
            var contenedor = GetOrCreateContenedor(doc, "Rotables");

            var nodo = contenedor
                .Elements("Rotable")
                .FirstOrDefault(x => x.Attribute("id")?.Value == rotable.id);

            if (nodo == null)
            {
                int nuevoId = GenerarIdUnico(contenedor, "Rotable");
                rotable.id = nuevoId.ToString();

                nodo = new XElement("Rotable",
                    new XAttribute("id", rotable.id),
                    new XElement("descripcion", rotable.descripcion),
                    new XElement("partNumber", rotable.partNumber),
                    new XElement("serialNumber", rotable.serialNumber),
                    new XElement("estado", rotable.estado)
                );
                contenedor.Add(nodo);
            }
            else
            {
                nodo.Element("descripcion")?.SetValue(rotable.descripcion);
                nodo.Element("partNumber")?.SetValue(rotable.partNumber);
                nodo.Element("serialNumber")?.SetValue(rotable.serialNumber);
                nodo.Element("estado")?.SetValue(rotable.estado);
            }

            GuardarDocumento(doc);
        }
        public static void GuardarHerramienta(HerramientaBE herramienta)
        {
            var doc = GetDocumento();
            var contenedor = GetOrCreateContenedor(doc, "Herramientas");

            var nodo = contenedor
                .Elements("Herramienta")
                .FirstOrDefault(x => x.Attribute("id")?.Value == herramienta.id);

            if (nodo == null)
            {
                int nuevoId = GenerarIdUnico(contenedor, "Herramienta");
                herramienta.id = nuevoId.ToString();

                nodo = new XElement("Herramienta",
                    new XAttribute("id", herramienta.id),
                    new XElement("descripcion", herramienta.descripcion),
                    new XElement("serial", herramienta.serial),
                    new XElement("fechaVtoCalibracion", herramienta.fechaVtoCalibracion.ToString("yyyy-MM-dd")),
                    new XElement("estado", herramienta.estado),
                    new XElement("HistorialEntregas")
                );
                contenedor.Add(nodo);
            }
            else
            {
                nodo.Element("descripcion")?.SetValue(herramienta.descripcion);
                nodo.Element("serial")?.SetValue(herramienta.serial);
                nodo.Element("fechaVtoCalibracion")?
                    .SetValue(herramienta.fechaVtoCalibracion.ToString("yyyy-MM-dd"));
                nodo.Element("estado")?.SetValue(herramienta.estado);
            }

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
                int idTrabajo = (int)nodo.Element("trabajo")?.Attribute("id"); //id del trabajo 
                var trabajoCompleto = ListarTrabajos().FirstOrDefault(t => t.id == idTrabajo); // lo busco
                var ot = new OrdenDeTrabajo
                {
                    numeroOT = nodo.Element("numeroOT")?.Value,
                    titulo = nodo.Element("titulo")?.Value,
                    descripcion = nodo.Element("descripcion")?.Value,
                    aeronave = nodo.Element("aeronave")?.Value,
                    serial = nodo.Element("serial")?.Value,
                    matricula = nodo.Element("matricula")?.Value,
                    estado = nodo.Element("estado")?.Value,
                    trabajo = trabajoCompleto, //lo pego
                    fechaInicio = DateTime.TryParse(nodo.Element("fechaInicio")?.Value, out var fi) ? fi : DateTime.MinValue,
                    fechaCierre = DateTime.TryParse(nodo.Element("fechaCierre")?.Value, out var fc) ? fc : DateTime.MinValue,
                    mecanico = nodo.Element("mecanico")?.Value,
                    inspector = nodo.Element("inspector")?.Value
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
                    idRol = int.TryParse(nodo.Element("idRol")?.Value, out var idRol) ? idRol : 0,
                    bloqueado = bool.TryParse(nodo.Element("bloqueado")?.Value, out var bloq) && bloq,
                    permisosAdicionales = nodo.Element("permisosAdicionales")?
                        .Elements("Permiso").Select(x => int.Parse(x.Value)).ToList() ?? new List<int>(),
                    nroMecanico = nodo.Element("nroMecanico")?.Value,
                    nroInspector = nodo.Element("nroInspector")?.Value
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

            return contenedor.Elements("Diferido").Select(x => new Diferido
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
        public static List<Permiso> ListarPermisos()
        {
            var doc = GetDocumento();
            var contenedor = GetOrCreateContenedor(doc, "Permisos");

            return contenedor.Elements("Permiso").Select(x => new Permiso
                {
                    id = int.Parse(x.Attribute("id")?.Value ?? "0"),
                    nombre = x.Element("nombre")?.Value
                }).ToList();
        }
        public static List<Rol> ListarRoles(bool includeInactive = false)
        {
            var roles = GetOrCreateContenedor(GetDocumento(), "Roles").Elements("Rol")
                .Select(x => new Rol
                {
                    id = (int)x.Attribute("id"),
                    designacion = (string)x.Element("designacion"),
                    idsPermisos = x.Element("Permisos")
                                      ?.Elements("idPermiso")
                                      .Select(y => (int)y).ToList() ?? new List<int>(),
                    inactivo = (bool?)x.Element("inactivo") ?? false,
                    idsRolesHijos = x.Element("RolesHijos") //no funcionaba por una S...
                                      ?.Elements("idRol")
                                      .Select(y => (int)y).ToList() ?? new List<int>()
                });

            return roles.Where(r => r.id != 0 && (includeInactive || !r.inactivo)).ToList();
        }
        public static List<Consumible> ListarConsumibles()
        {
            var doc = GetDocumento();
            var cont = GetOrCreateContenedor(doc, "Consumibles");

            return cont.Elements("Consumible")
                .Select(x => new Consumible
                {
                    id = x.Attribute("id")?.Value,
                    descripcion = x.Element("descripcion")?.Value,
                    partNumber = x.Element("partNumber")?.Value,
                    lot = x.Element("lot")?.Value,
                    estado = bool.TryParse(x.Element("estado")?.Value, out var st) && st,
                    cantidad = int.TryParse(x.Element("cantidad")?.Value, out var ct) ? ct : 0,
                    fechaVto = DateTime.TryParse(x.Element("fechaVto")?.Value, out var fv) ? fv : DateTime.MinValue
                }).ToList();
        }
        public static List<RotableBE> ListarRotables()
        {
            var doc = GetDocumento();
            var contenedor = GetOrCreateContenedor(doc, "Rotables");

            return contenedor.Elements("Rotable")
                .Select(x => new RotableBE
                {
                    id = x.Attribute("id")?.Value,
                    descripcion = x.Element("descripcion")?.Value,
                    partNumber = x.Element("partNumber")?.Value,
                    serialNumber = x.Element("serialNumber")?.Value,
                    estado = bool.TryParse(x.Element("estado")?.Value, out var st) && st
                }).ToList();
        }
        public static List<HerramientaBE> ListarHerramientas()
        {
            var doc = GetDocumento();
            var cont = GetOrCreateContenedor(doc, "Herramientas");

            return cont.Elements("Herramienta")
                .Select(x => new HerramientaBE
                {
                    id = x.Attribute("id")?.Value,
                    descripcion = x.Element("descripcion")?.Value,
                    serial = x.Element("serial")?.Value,
                    fechaVtoCalibracion = DateTime.TryParse(
                        x.Element("fechaVtoCalibracion")?.Value,
                        out var fv) ? fv : DateTime.MinValue,
                    estado = bool.TryParse(
                        x.Element("estado")?.Value,
                        out var st) && st
                }
                ).ToList();
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

            dmi.Element("idNoStock")?.Remove();

            dmi.Add(new XElement("idNoStock", idNoStock));

            GuardarDocumento(doc);
        }

        public static void ActualizarOrdenDeTrabajo(OrdenDeTrabajo ot)
        {
            var doc = GetDocumento();
            var contenedor = GetOrCreateContenedor(doc, "OrdenesDeTrabajo");

            var nodo = contenedor.Elements("OrdenDeTrabajo").FirstOrDefault(x => x.Element("numeroOT")?.Value == ot.numeroOT);

            if (nodo == null) throw new Exception("No se encontró la OT para actualizar.");

            var tareasElem = nodo.Element("ListaTareas");
            tareasElem?.Remove();

            var nuevaLista = new XElement("ListaTareas",ot.trabajo.listaTareas.Select(t => new XElement("Tarea", t)));
            nodo.Add(nuevaLista);

            nodo.Element("estado")?.SetValue(ot.estado);
            nodo.Element("fechaCierre")?.SetValue(ot.fechaCierre.ToString("yyyy-MM-dd"));

            if (!string.IsNullOrEmpty(ot.mecanico))
            {
                var mecanicoElem = nodo.Element("mecanico");
                if (mecanicoElem != null) mecanicoElem.SetValue(ot.mecanico);
                else nodo.Add(new XElement("mecanico", ot.mecanico));
            }
            else nodo.Add(new XElement("mecanico", ot.mecanico));

            if (!string.IsNullOrEmpty(ot.inspector))
            {
                var inspectorElem = nodo.Element("inspector");
                if (inspectorElem != null) inspectorElem.SetValue(ot.inspector);
                else nodo.Add(new XElement("inspector", ot.inspector));
            }


            GuardarDocumento(doc);
        }
        public static void ActualizarRol(Rol rol)
        {
            var doc = GetDocumento();
            var contenedor = GetOrCreateContenedor(doc, "Roles");

            var nodoRol = contenedor.Elements("Rol").FirstOrDefault(x => (int?)x.Attribute("id") == rol.id);
            if(nodoRol == null) throw new Exception($"No se encontró el rol con id {rol.id}");

            var permisosElem = nodoRol.Element("Permisos");
            permisosElem.Remove();
            foreach(var idPermiso in rol.idsPermisos)
            {
                permisosElem.Add(new XElement("idPermiso", idPermiso));
            }
            
            nodoRol.Element("designacion")?.SetValue(rol.designacion);

            GuardarDocumento(doc);

        }
        public static void ActualizarDiferido(Diferido dmi)
        {
            var doc = GetDocumento();
            var contenedor = GetOrCreateContenedor(doc, "Diferidos");

            var nodo = contenedor.Elements("Diferido")
                .FirstOrDefault(x => (int)x.Attribute("id") == dmi.id);
            if (nodo == null) throw new InvalidOperationException($"No se encontró el diferido {dmi.id} para actualizar.");

            nodo.Element("estado")?.SetValue(dmi.estado);
            nodo.Element("fechaCierre")?.SetValue(dmi.fechaCierre.ToString("yyyy-MM-dd"));

            GuardarDocumento(doc);
        }
        public static void RegistrarEntregaConsumible(string id, int cantidad, string emisor, string receptor)
        {
            var doc = GetDocumento();
            var nodo = doc.Descendants("Consumible").First(x => x.Attribute("id")?.Value == id);

            var hist = nodo.Element("HistorialEntregas");
            if (hist == null)
            {
                hist = new XElement("HistorialEntregas");
                nodo.Add(hist);
            }

            hist.Add(new XElement("Entrega",
                        new XElement("fecha", DateTime.Now),
                        new XElement("cantidad", cantidad),
                        new XElement("entregadoPor", emisor),
                        new XElement("recibidoPor", receptor)
                        )
                );

            GuardarDocumento(doc);
        }
        public static void RegistrarEntregaRotable(string id, string entregadoPor, string recibidoPor)
        {
            var doc = GetDocumento();
            var nodo = doc.Descendants("Rotable").First(x => x.Attribute("id")?.Value == id);

            var hist = nodo.Element("HistorialEntregas");
            if (hist == null)
            {
                hist = new XElement("HistorialEntregas");
                nodo.Add(hist);
            }

            hist.Add(new XElement("Entrega",
                new XElement("fecha", DateTime.Now),
                new XElement("entregadoPor", entregadoPor),
                new XElement("recibidoPor", recibidoPor)
            ));
            GuardarDocumento(doc);
        }

        #region Borrar / Desactivar Datos
        public static void DesactivarRol(int idRol)
        {
            var doc = GetDocumento();
            var contenedor = GetOrCreateContenedor(doc, "Roles");
            var nodo = contenedor.Elements("Rol").FirstOrDefault(x => (int?)x.Attribute("id") == idRol);

            if (nodo == null)throw new Exception($"No existe el rol con ID {idRol}");

            var elem = nodo.Element("inactivo"); //como esto lo agregue mas tarde, puede que haya roles que no lo tengan
            if (elem == null)
            {
                nodo.Add(new XElement("inactivo", true));
            }
            else
            {
                elem.SetValue(true);
            }

            GuardarDocumento(doc);
        }

        public static void EliminarTrabajo(int idTrabajo)
        {
            var doc = GetDocumento();
            var contenedor = GetOrCreateContenedor(doc, "Trabajos");

            var nodo = contenedor.Elements("Trabajo").FirstOrDefault(x => (int)x.Attribute("id") == idTrabajo);

            if (nodo != null)
            {
                nodo.Remove();
                GuardarDocumento(doc);
            }
            else
            {
                throw new InvalidOperationException($"No se encontró el trabajo con id {idTrabajo}.");
            }
        }
        public static void EliminarOrdenDeTrabajo(string numeroOT)
        {
            var doc = GetDocumento();
            var cont = GetOrCreateContenedor(doc, "OrdenesTrabajo");

            var nodo = cont.Elements("OrdenDeTrabajo")
                .FirstOrDefault(x =>(string)x.Element("numeroOT") == numeroOT);

            if (nodo == null) throw new InvalidOperationException($"No se encontró la OT con número '{numeroOT}'.");

            nodo.Remove();
            GuardarDocumento(doc);
        }

        #endregion

        #endregion
    }

}
