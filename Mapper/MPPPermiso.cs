using BE;
using BE.Composite;
using DAL;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Runtime.Remoting;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.XPath;

namespace Mapper
{
    public class MPPPermiso
    {
        public Array GetAllTypePermission()
        {
            return Enum.GetValues(typeof(TipoPermisoBE));
        }

        public Componente GuardarComponente(Componente oComp, bool esRol) 
        {
            var doc = DatosDAL.GetDocumento();
            var contenedor = DatosDAL.GetOrCreateContenedor(doc, "Componentes");

            contenedor.Elements("Componente").FirstOrDefault(c => (int)c.Attribute("id") == oComp.id) 
                ?.Remove();

            if (oComp.id == 0)
            {
                oComp.id = DatosDAL.GenerarIdUnico(contenedor, "Componente");
            }

            var nodo = new XElement("Componente",
                new XAttribute("id", oComp.id),
                new XAttribute("designacion", oComp.designacion),
                new XAttribute("tipo", esRol ? "Rol" : "Permiso")
            );

            if (esRol && oComp is RolComposite rol)
            {
                foreach (var hijo in rol.hijos)
                {
                    nodo.Add(new XElement("Hijo", new XAttribute("ref", hijo.id)));
                }
            }
            else
            {
                nodo.Add(new XAttribute("permiso", oComp.permiso.ToString()));
            }

            contenedor.Add(nodo);
            DatosDAL.GuardarDocumento(doc);

            return oComp;
        }

        public IList<Componente> GetAll()
        {
            var doc = DatosDAL.GetDocumento();
            var contenedor = DatosDAL.GetOrCreateContenedor(doc, "Componentes");

            var componentes = new Dictionary<int, Componente>();

            foreach (var nodo in contenedor.Elements("Componente"))
            {
                int id = (int)nodo.Attribute("id");
                string designacion = (string)nodo.Attribute("designacion");
                string tipo = (string)nodo.Attribute("tipo");

                Componente componente;

                if (tipo == "Rol")
                {
                    componente = new RolComposite
                    {
                        id = id,
                        designacion = designacion
                    };
                }
                else if (tipo == "Permiso")
                {
                    var permisoAttr = (string)nodo.Attribute("permiso");
                    if (!Enum.TryParse<TipoPermisoBE>(permisoAttr, out var permisoEnum))
                        throw new InvalidOperationException($"Valor de permiso inválido en componente id={id}: '{permisoAttr}'");

                    componente = new PermisoLeaf
                    {
                        id = id,
                        designacion = designacion,
                        permiso = permisoEnum
                    };
                }
                else
                {
                    throw new Exception($"Tipo desconocido en componente id={id}: {tipo}");
                }

                componentes[id] = componente;
            }

            foreach (var nodo in contenedor.Elements("Componente"))
            {
                int id = (int)nodo.Attribute("id");
                var comp = componentes[id];

                foreach (var hijoRef in nodo.Elements("Hijo"))
                {
                    int refId = (int)hijoRef.Attribute("ref");
                    var padre = componentes[id];
                    if (componentes.TryGetValue(refId, out var hijo))
                        padre.AgregarHijo(hijo);
                }

            }
                return componentes.Values.ToList();

        }
        public IList<PermisoLeaf> GetAllPermisos()
        { 
            return GetAll().OfType<PermisoLeaf>().ToList();
        }
        public List<RolComposite> GetAllRoles()
        {
            return GetAll().OfType<RolComposite>().ToList();
        }


        private Componente GetComponent(int id, IList<Componente> lista)
        {
            if (lista == null) return null;

            foreach (var componente in lista)
            {
                if (componente.id == id)
                    return componente;

                var encontrado = GetComponent(id, componente.hijos);
                if (encontrado != null)
                    return encontrado;
            }

            return null;
        }

        public void FillUserComponents(UsuarioBE usuario)
        {
            var doc = DatosDAL.GetDocumento();
            var contenedorComponentes = DatosDAL.GetOrCreateContenedor(doc, "Componentes");
            var contenedorUsuarios = DatosDAL.GetOrCreateContenedor(doc, "Usuarios");
            var nodoUsuario = contenedorUsuarios.Elements("Usuario")
                                         .FirstOrDefault(x => x.Attribute("id").Value == usuario.id.ToString());

            usuario.permisos.Clear();

            if (nodoUsuario != null)
            {
                var todos = GetAll();

                foreach (var permisoRef in nodoUsuario.Elements("Permiso"))
                {
                    string idPermisoString = permisoRef.Attribute("ref").Value;

                    if (int.TryParse(idPermisoString, out int idPermiso))
                    {
                        var componente = GetComponent(idPermiso, todos);
                        if (componente != null)
                        {
                            usuario.permisos.Add(componente);
                        }
                    }
                }
            }
        }

        public void FillRolComponents(RolComposite rol)
        {
            rol.VaciarHijos();

            var todos = GetAll();

            var rolOrigen = todos.OfType<RolComposite>().FirstOrDefault(r => r.id == rol.id);

            if (rolOrigen != null)
            {
                foreach (var hijo in rolOrigen.hijos)
                    rol.AgregarHijo(hijo);
            }

        }

        public void BorrarComponente(Componente componente)
        {
            var doc = DatosDAL.GetDocumento();
            var contenedor = DatosDAL.GetOrCreateContenedor(doc, "Componentes");
            var nodo = contenedor.Elements("Componente")
                .FirstOrDefault(c => (int)c.Attribute("id") == componente.id);

            nodo.Remove();
            DatosDAL.GuardarDocumento(doc);
        }
    }
}
