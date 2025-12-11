using BE.Composite;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Mapper
{
    public class MPPUsuario
    {
        public List<UsuarioBE> GetAll()
        {
            List<UsuarioBE> listaUsuarios = new List<UsuarioBE>();
            var doc = DatosDAL.GetDocumento();
            var contenedorUsuarios = DatosDAL.GetOrCreateContenedor(doc, "Usuarios");
            var nodoUsuario = contenedorUsuarios.Elements("Usuario");

            var listaComponentes = new MPPPermiso().GetAll();

            foreach (var nodo in contenedorUsuarios.Elements("Usuario"))
            {
                UsuarioBE usuario = new UsuarioBE
                {
                    id = nodo.Attribute("id").Value,
                    username = nodo.Element("Username").Value,
                    password = nodo.Element("Password").Value,
                    nombre = nodo.Element("Nombre").Value,
                    apellido = nodo.Element("Apellido").Value,
                    bloqueado = bool.Parse(nodo.Element("Bloqueado").Value),
                    nroMecanico = nodo.Element("NroMecanico")?.Value,
                    nroInspector = nodo.Element("NroInspector")?.Value
                };
                var contPermisos = nodo.Element("Permisos");
                if (contPermisos != null)
                {
                    foreach (var idElem in contPermisos.Elements("IdComponente"))
                    {
                        if (int.TryParse(idElem.Value, out var idComp))
                        {
                            var comp = listaComponentes.FirstOrDefault(c => c.id == idComp);
                            if (comp != null)
                                usuario.permisos.Add(comp);
                        }
                    }
                }

                listaUsuarios.Add(usuario);
            }

            return listaUsuarios;
        }


        public bool GuardarPermisos(UsuarioBE usuario)
        {
            try
            {
                var doc = DatosDAL.GetDocumento();
                var contenedorUsuarios = DatosDAL.GetOrCreateContenedor(doc, "Usuarios");

                var nodoUsuario = contenedorUsuarios.Elements("Usuario")
                                          .FirstOrDefault(x => x.Attribute("id").Value == usuario.id.ToString());

                if (nodoUsuario == null) return false;

                nodoUsuario.Elements("Permisos")?.Remove();

                var contenedorPermisos = new XElement("Permisos");
                foreach (var permiso in usuario.permisos)
                {
                    contenedorPermisos.Add(new XElement("IdComponente", permiso.id));
                }
                nodoUsuario.Add(contenedorPermisos);
                DatosDAL.GuardarDocumento(doc);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool GuardarUsuario(UsuarioBE usuario)
        {
            try
            {
                var doc = DatosDAL.GetDocumento();
                var contenedorUsuarios = DatosDAL.GetOrCreateContenedor(doc, "Usuarios");

                var nodoExistente = contenedorUsuarios.Elements("Usuario")
                    .FirstOrDefault(x => x.Attribute("id").Value == usuario.id.ToString());

                if (nodoExistente != null)
                    nodoExistente.Remove();

                var nodoUsuario = new XElement("Usuario",
                    new XAttribute("id", usuario.id),
                    new XElement("Username", usuario.username),
                    new XElement("Password", usuario.password),
                    new XElement("Nombre", usuario.nombre),
                    new XElement("Apellido", usuario.apellido),
                    new XElement("Bloqueado", usuario.bloqueado.ToString()),
                    new XElement("NroMecanico", usuario.nroMecanico ?? string.Empty),
                    new XElement("NroInspector", usuario.nroInspector ?? string.Empty)
                );
                var contenedorPermisos = new XElement("Permisos");
                foreach (var permiso in usuario.permisos)
                {
                    contenedorPermisos.Add(new XElement("IdComponente", permiso.id));
                }
                nodoUsuario.Add(contenedorPermisos);
                contenedorUsuarios.Add(nodoUsuario);
                DatosDAL.GuardarDocumento(doc);
                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}
