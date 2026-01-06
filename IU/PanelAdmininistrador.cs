using BE.Composite;
using BE.Modelo;
using BLL;
using BLL.Roles;
using BLL.Servicios;
using DocumentFormat.OpenXml.Spreadsheet;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace IU.ALTERNATIVO
{
    public partial class PanelAdmininistrador : Form
    {
        PermisoBLL oBLLPermiso;
        RolComposite oBERol;
        UsuarioBLL oBLLUser;
        UsuarioBE tmp;
        UsuarioBE usuarioSeleccionado;
        PermisoLeaf permisoSeleccionado;
        RolComposite rolSeleccionado;
        private readonly AeronaveBLL aeronaveBLL = new AeronaveBLL();
        private List<AeronaveBE> listaAeronaves = new List<AeronaveBE>();
        private IList<Componente> listaComponentes = new List<Componente>();

        public PanelAdmininistrador()
        {
            InitializeComponent();
            oBLLUser = new UsuarioBLL();
            oBLLPermiso = new PermisoBLL();
        }

        private void PanelAdmininistradorForm_Load(object sender, EventArgs e)
        {
            LlenarPermisosRol();
            CargarTreeView();
        }

        private void CargarTreeView()
        {
            listaAeronaves = aeronaveBLL.ListarAeronaves();
            this.treeViewUsuarios.Nodes.Clear();
            dataGridViewAeronaves.DataSource = listaAeronaves;
            List<UsuarioBE> usuarios = oBLLUser.ListarTodo();
            foreach (var item in usuarios)
            {
                TreeNode nodo = new TreeNode(item.username);
                nodo.Tag = item;
                this.treeViewUsuarios.Nodes.Add(nodo);
            }

            this.treeViewRoles.Nodes.Clear();
            var listaRoles = oBLLPermiso.GetAllRoles();
            foreach (var item in listaRoles)
            {
                TreeNode nodo = new TreeNode(item.designacion);
                nodo.Tag = item;
                this.treeViewRoles.Nodes.Add(nodo);
            }

            this.treeViewPermisos.Nodes.Clear();
            var listaPermisos = oBLLPermiso.GetAllPermisos();
            foreach (var item in listaPermisos)
            {
                TreeNode nodo = new TreeNode(item.designacion);
                nodo.Tag = item;
                this.treeViewPermisos.Nodes.Add(nodo);
            }
            if (usuarioSeleccionado != null) MostrarPermisos(usuarioSeleccionado);

        }

        private void buttonCrearUser_Click(object sender, EventArgs e)
        {
            using (var newUserForm = new NuevoUsuario())
            {
                var result = newUserForm.ShowDialog();
                if (result == DialogResult.OK)
                {
                    CargarTreeView();
                }
            }
        }

        private void buttonAsociarRolUser_Click(object sender, EventArgs e)
        {
            tmp = treeViewUsuarios.SelectedNode?.Tag as UsuarioBE;
            if (tmp != null)
            {
                var rolSeleccionado = comboBoxRolUsuario.SelectedItem as RolComposite;
                if (rolSeleccionado != null)
                {
                    var existe = false;
                    foreach (var item in tmp.permisos)
                    {
                        if (oBLLPermiso.Existe(item, rolSeleccionado.id))
                        {
                            existe = true;
                        }
                    }

                    if (existe)
                    {
                        MessageBox.Show($"El usuario {tmp.username} ya tiene el rol {rolSeleccionado.designacion} asignado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    else
                    {
                        oBLLPermiso.FillRolComponents(rolSeleccionado);
                        tmp.permisos.Add(rolSeleccionado);
                        MostrarPermisos(tmp);
                        tmp.password = Encriptacion.DesencriptarPassword(tmp.password);
                        oBLLUser.AsignarNroMecanicoInspector(tmp);
                        oBLLUser.GuardarUsuario(tmp);
                    }
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar un usuario primero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MostrarPermisos(UsuarioBE u)
        {
            this.treeViewRolesyPermisosDelUsuario.Nodes.Clear();
            TreeNode root = new TreeNode(u.username);

            foreach (var item in u.permisos)
            {
                LlenarTreeView(root, item);
            }

            this.treeViewRolesyPermisosDelUsuario.Nodes.Add(root);
            this.treeViewRolesyPermisosDelUsuario.ExpandAll();
        }

        private void LlenarTreeView(TreeNode padre, Componente c)
        {
            TreeNode hijo = new TreeNode(c.designacion);
            hijo.Tag = c;
            padre.Nodes.Add(hijo);
            foreach (var item in c.hijos)
            {
                LlenarTreeView(hijo, item);
            }
        }

        private void buttonQuitarRolUser_Click(object sender, EventArgs e)
        {
            usuarioSeleccionado = treeViewUsuarios.SelectedNode?.Tag as UsuarioBE;
            rolSeleccionado = comboBoxRolUsuario.SelectedItem as RolComposite;

            if (usuarioSeleccionado == null)
            {
                MessageBox.Show("Debe seleccionar un usuario primero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (rolSeleccionado == null)
            {
                MessageBox.Show("Debe seleccionar un rol primero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var rolEnUser = usuarioSeleccionado.permisos.FirstOrDefault(r => r.id == rolSeleccionado.id);
            if (rolEnUser == null)
            {
                MessageBox.Show($"El usuario {usuarioSeleccionado.username} no tiene el rol {rolSeleccionado.designacion} asignado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            usuarioSeleccionado.permisos.Remove(rolEnUser);
            MostrarPermisos(usuarioSeleccionado);
            usuarioSeleccionado.password = Encriptacion.DesencriptarPassword(usuarioSeleccionado.password);
            oBLLUser.GuardarUsuario(usuarioSeleccionado);
        }

        private void buttonAsociarPermisoUser_Click(object sender, EventArgs e)
        {
            usuarioSeleccionado = treeViewUsuarios.SelectedNode?.Tag as UsuarioBE;
            if (usuarioSeleccionado == null)
            {
                MessageBox.Show("Debe seleccionar un usuario primero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var permisoSeleccionado = comboBoxPermisos.SelectedItem as PermisoLeaf;
            if (permisoSeleccionado == null)
            {
                MessageBox.Show("Debe seleccionar un permiso primero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            bool existe = false;

            foreach (var componente in usuarioSeleccionado.permisos)
            {
                if (oBLLPermiso.Existe(componente, permisoSeleccionado.id))
                {
                    existe = true;
                }
            }

            if (existe)
            {
                MessageBox.Show($"El usuario {usuarioSeleccionado.username} ya tiene el permiso {permisoSeleccionado.designacion} asignado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            usuarioSeleccionado.permisos.Add(permisoSeleccionado);
            usuarioSeleccionado.password = Encriptacion.DesencriptarPassword(usuarioSeleccionado.password);
            oBLLUser.GuardarUsuario(usuarioSeleccionado);
            MostrarPermisos(usuarioSeleccionado);
        }

        private void buttonQuitarPermisoUser_Click(object sender, EventArgs e)
        {
            usuarioSeleccionado = treeViewUsuarios.SelectedNode?.Tag as UsuarioBE;
            permisoSeleccionado = comboBoxPermisos.SelectedItem as PermisoLeaf;

            if (usuarioSeleccionado == null)
            {
                MessageBox.Show("Debe seleccionar un usuario primero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (permisoSeleccionado == null)
            {
                MessageBox.Show("Debe seleccionar un permiso primero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var permisoEnUser = usuarioSeleccionado.permisos.FirstOrDefault(r => r.id == permisoSeleccionado.id);
            if (permisoEnUser == null)
            {
                MessageBox.Show($"El usuario {usuarioSeleccionado.username} no tiene el permiso {permisoSeleccionado.designacion} asignado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            usuarioSeleccionado.permisos.Remove(permisoEnUser);
            MostrarPermisos(usuarioSeleccionado);
            usuarioSeleccionado.password = Encriptacion.DesencriptarPassword(usuarioSeleccionado.password);
            oBLLUser.GuardarUsuario(usuarioSeleccionado);
        }

        private void buttonModificarUsuario_Click(object sender, EventArgs e)
        {
            usuarioSeleccionado = treeViewUsuarios.SelectedNode?.Tag as UsuarioBE;
            if (usuarioSeleccionado == null)
            {
                MessageBox.Show("Debe seleccionar un usuario", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            usuarioSeleccionado.bloqueado = checkBoxBloqueado.Checked;
            usuarioSeleccionado.username = textBoxUserName.Text.Trim();
            usuarioSeleccionado.nombre = textBoxNombre.Text.Trim();
            usuarioSeleccionado.apellido = textBoxApellido.Text.Trim();
            usuarioSeleccionado.password = textBoxPww.Text;

            oBLLUser.GuardarUsuario(usuarioSeleccionado);

        }

        private void bttnAltaRol_Click(object sender, EventArgs e)
        {
            RolComposite oBERol = new RolComposite()
            {
                designacion = textBoxDesignacionRol.Text
            };

            oBLLPermiso.GuardarComponente(oBERol, true);

            LlenarPermisosRol();

            MessageBox.Show("Rol creado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

            var nodo = treeViewRoles.SelectedNode;
            treeViewRoles.SelectedNode = null;
            treeViewRoles.SelectedNode = nodo;
            CargarTreeView();
        }

        private void LlenarPermisosRol()
        {
            var roles = oBLLPermiso.GetAllRoles();
            foreach (var r in roles) oBLLPermiso.FillRolComponents(r);

            var permisos = oBLLPermiso.GetAllPermisos();

            comboBoxRolUsuario.DisplayMember = "designacion";
            comboBoxRolUsuario.ValueMember = "id";
            comboBoxRolUsuario.DataSource = roles;

            comboBoxPermisos.DisplayMember = "designacion";
            comboBoxPermisos.ValueMember = "id";
            comboBoxPermisos.DataSource = permisos;

            comboBoxRoles.DisplayMember = "designacion";
            comboBoxRoles.ValueMember = "id";
            comboBoxRoles.DataSource = roles;

            comboPermisos.DisplayMember = "designacion";
            comboPermisos.ValueMember = "id";
            comboPermisos.DataSource = permisos;
        }

        private void bttnModificarRol_Click(object sender, EventArgs e)
        {
            RolComposite oBERol = treeViewRoles.SelectedNode?.Tag as RolComposite;
            if (oBERol != null)
            {
                oBERol.designacion = textBoxDesignacionRol.Text;
                oBLLPermiso.GuardarComponente(oBERol, true);
                LlenarPermisosRol();
                MessageBox.Show("Rol modificado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Debe seleccionar un rol primero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            CargarTreeView();

        }

        private void bttnEliminarRol_Click(object sender, EventArgs e)
        {
            if (treeViewRoles.SelectedNode != null)
            {
                var rolSeleccionado = treeViewRoles.SelectedNode.Tag as RolComposite;
                if (rolSeleccionado != null)
                {
                    oBLLPermiso.EliminarComponente(rolSeleccionado);
                    LlenarPermisosRol();
                    MessageBox.Show("Rol eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Debe seleccionar un rol primero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar un rol primero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            CargarTreeView();

        }

        private void buttonAsociarRolARol_Click(object sender, EventArgs e)
        {
            var rolSeleccionado = treeViewRoles.SelectedNode?.Tag as RolComposite;
            var rolAsociar = comboBoxRoles.SelectedItem as RolComposite;

            if (rolSeleccionado == null)
            {
                MessageBox.Show("Debe seleccionar un rol primero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (rolAsociar == null)
            {
                MessageBox.Show("Debe seleccionar un rol a asociar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (ContieneId(rolSeleccionado, rolAsociar.id))
            {
                MessageBox.Show("El rol ya está contenido en la jerarquía del rol seleccionado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (ContieneId(rolAsociar, rolSeleccionado.id))
            {
                MessageBox.Show("No se puede asociar porque generaría una referencia circular.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            rolSeleccionado.AgregarHijo(rolAsociar);

            oBLLPermiso.GuardarComponente(rolSeleccionado, esRol: true);
            listaComponentes = oBLLPermiso.GetAll();

            var nodo = treeViewRoles.SelectedNode;
            treeViewRoles.SelectedNode = null;
            treeViewRoles.SelectedNode = nodo;
            if (usuarioSeleccionado != null) MostrarPermisos(usuarioSeleccionado);

        }

        private bool ContieneId(Componente nodo, int idBuscado, HashSet<int> visitados = null)
        {
            visitados = new HashSet<int>();

            if (!visitados.Add(nodo.id)) return false; 

            if (nodo.id == idBuscado)
                return true;

            if (nodo is RolComposite composite)
            {
                foreach (var hijo in composite.hijos)
                {
                    if (ContieneId(hijo, idBuscado, visitados))
                        return true;
                }
            }

            return false;
        }


        private void buttonDesasociarRolARol_Click(object sender, EventArgs e)
        {
            var rolSeleccionado = treeViewRoles.SelectedNode?.Tag as RolComposite;
            var rolDesasociar = comboBoxRoles.SelectedItem as RolComposite;
            if (rolSeleccionado == null)
            {
                MessageBox.Show("Debe seleccionar un rol primero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (rolDesasociar == null)
            {
                MessageBox.Show("Debe seleccionar un rol a desasociar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!rolSeleccionado.hijos.Any(c => c.id == rolDesasociar.id))
            {
                MessageBox.Show($"El rol {rolSeleccionado.designacion} no tiene el rol {rolDesasociar.designacion} asignado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            rolSeleccionado.EliminarHijo(rolDesasociar);
            oBLLPermiso.GuardarComponente(rolSeleccionado, true);

            var nodo = treeViewRoles.SelectedNode;
            treeViewRoles.SelectedNode = null;
            treeViewRoles.SelectedNode = nodo;
            if (usuarioSeleccionado != null) MostrarPermisos(usuarioSeleccionado);

        }

        private void AsociarPermisoARol_Click(object sender, EventArgs e)
        {
            var permiso = comboPermisos.SelectedItem as PermisoLeaf;
            var nodoSeleccionado = treeViewRoles.SelectedNode;
            var rol = nodoSeleccionado?.Tag as RolComposite;

            if (permiso == null || rol == null)
            {
                MessageBox.Show("Debes seleccionar un rol y un permiso.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool existe = oBLLPermiso.Existe(rol, permiso.id);
            if (existe)
            {
                MessageBox.Show($"El permiso {permiso.designacion} ya está asignado al rol {rol.designacion}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            rol.AgregarHijo(permiso);
            oBLLPermiso.GuardarComponente(rol, esRol: true);

            var nodo = treeViewRoles.SelectedNode;
            treeViewRoles.SelectedNode = null;
            treeViewRoles.SelectedNode = nodo;
            if (usuarioSeleccionado != null) MostrarPermisos(usuarioSeleccionado);
        }

        private void buttonQuitarPermisoARol_Click(object sender, EventArgs e)
        {
            var rolSeleccionado = treeViewRoles.SelectedNode?.Tag as RolComposite;
            var permisoSeleccionado = comboPermisos.SelectedItem as PermisoLeaf;

            if (rolSeleccionado == null)
            {
                MessageBox.Show("Debe seleccionar un rol primero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (permisoSeleccionado == null)
            {
                MessageBox.Show("Debe seleccionar un permiso primero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!rolSeleccionado.hijos.Any(c => c.id == permisoSeleccionado.id))
            {
                MessageBox.Show($"El rol {rolSeleccionado.designacion} no tiene el permiso {permisoSeleccionado.designacion} asignado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            rolSeleccionado.EliminarHijo(permisoSeleccionado);
            oBLLPermiso.GuardarComponente(rolSeleccionado, true);

            var nodo = treeViewRoles.SelectedNode;
            treeViewRoles.SelectedNode = null;
            treeViewRoles.SelectedNode = nodo;
        }

        private void buttonLimpiarCampos_Click(object sender, EventArgs e)
        {
            textBoxIdUser.Clear();
            textBoxUserName.Clear();
            textBoxNombre.Clear();
            textBoxApellido.Clear();
            textBoxPww.Clear();

            textBoxIDRol.Clear();
            textBoxDesignacionRol.Clear();

            textBoxIdPermiso.Clear();
            textBoxNombrePermiso.Clear();

            textBoxIDRolParaAsociarRol.Clear();
            textBoxNombreRolParaAsociarRol.Clear();

            textBoxMatricula.Clear();
            textBoxMarca.Clear();
            textBoxModelo.Clear();
            textBoxSerie.Clear();

            checkBoxMostrarContraseña.Checked = false;
            checkBoxBloqueado.Checked = false;

            comboBoxRoles.SelectedIndex = -1;
            comboBoxRolUsuario.SelectedIndex = -1;
            comboBoxPermisos.SelectedIndex = -1;
            comboPermisos.SelectedIndex = -1;

            treeViewUsuarios.SelectedNode = null;
            treeViewRoles.SelectedNode = null;
            treeViewPermisos.SelectedNode = null;
            treeViewPermisosXRol.SelectedNode = null;
            treeViewRolesyPermisosDelUsuario.SelectedNode = null;
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
            BackupForm bForm = new BackupForm();
            bForm.Show();
        }

        private void buttonCrearAeronave_Click(object sender, EventArgs e)
        {
            AeronaveBLL aeronaveBLL = new AeronaveBLL();

            if (string.IsNullOrWhiteSpace(textBoxMatricula.Text) ||
                string.IsNullOrWhiteSpace(textBoxMarca.Text) ||
                string.IsNullOrWhiteSpace(textBoxModelo.Text) ||
                string.IsNullOrWhiteSpace(textBoxSerie.Text))
            {
                MessageBox.Show("Todos los campos son obligatorios.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (aeronaveBLL.ListarAeronaves().Any(a => a.matricula.Equals(textBoxMatricula.Text.Trim(), StringComparison.OrdinalIgnoreCase)))
            {
                MessageBox.Show("Ya existe una aeronave con la misma matrícula.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            AeronaveBE aeronave = new AeronaveBE
            {
                matricula = textBoxMatricula.Text.Trim(),
                marca = textBoxMarca.Text.Trim(),
                modelo = textBoxModelo.Text.Trim(),
                serial = textBoxSerie.Text.Trim(),
                estadoActual = EstadoAeronave.Serviciable
            };

            aeronaveBLL.GuardarAeronave(aeronave);
            MessageBox.Show($"Aeronave {aeronave.matricula} creada exitosamente!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

            CargarTreeView();
        }

        private void treeViewUsuarios_AfterSelect(object sender, TreeViewEventArgs e)
        {
            usuarioSeleccionado = e.Node.Tag as UsuarioBE;
            treeViewRolesyPermisosDelUsuario.Nodes.Clear();

            if (usuarioSeleccionado == null)
            {
                return;
            }

            textBoxIdUser.Text = usuarioSeleccionado.id;
            textBoxUserName.Text = usuarioSeleccionado.username;
            textBoxNombre.Text = usuarioSeleccionado.nombre;
            textBoxApellido.Text = usuarioSeleccionado.apellido;
            checkBoxBloqueado.Checked = usuarioSeleccionado.bloqueado;

            var originalPassword = Encriptacion.DesencriptarPassword(usuarioSeleccionado.password);
            textBoxPww.UseSystemPasswordChar = true;
            textBoxPww.Text = originalPassword;
            checkBoxMostrarContraseña.Checked = false;

            MostrarPermisos(usuarioSeleccionado);
        }
        private void checkBoxMostrarContraseña_CheckedChanged(object sender, EventArgs e)
        {
            textBoxPww.UseSystemPasswordChar = !checkBoxMostrarContraseña.Checked;
        }

        private void treeViewRoles_AfterSelect(object sender, TreeViewEventArgs e)
        {
            oBERol = e.Node.Tag as RolComposite;
            if (oBERol == null) return;
            oBLLPermiso.FillRolComponents(oBERol);

            textBoxIDRolParaAsociarRol.Text = oBERol.id.ToString();
            textBoxNombreRolParaAsociarRol.Text = oBERol.designacion;

            textBoxIDRol.Text = oBERol.id.ToString();
            textBoxDesignacionRol.Text = oBERol.designacion;

            treeViewPermisosXRol.Nodes.Clear();

            TreeNode nodoRaiz = new TreeNode(oBERol.designacion) { Tag = oBERol };
            treeViewPermisosXRol.Nodes.Add(nodoRaiz);

            foreach (var item in oBERol.hijos)
            {
                LlenarTreeView(nodoRaiz, item);
            }

            treeViewPermisosXRol.ExpandAll();
        }

        private void treeViewPermisos_AfterSelect(object sender, TreeViewEventArgs e)
        {
            permisoSeleccionado = e.Node.Tag as PermisoLeaf;

            if (permisoSeleccionado == null)
            {
                return;
            }
            textBoxIdPermiso.Text = permisoSeleccionado.id.ToString();
            textBoxNombrePermiso.Text = permisoSeleccionado.designacion;
            comboPermisos.SelectedIndex = permisoSeleccionado.id - 1;
        }
    }
}
