using BE.Composite;
using BE.Modelo;
using BLL;
using BLL.Roles;
using BLL.Servicios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IU
{
    public partial class PanelAdministrador : Form
    {
        private readonly UsuarioBLL usuarioBLL = new UsuarioBLL();
        private readonly RolBLL rolBLL = new RolBLL();
        private readonly PermisoBLL permisoBLL = new PermisoBLL();
        private readonly AeronaveBLL aeronaveBLL = new AeronaveBLL();

        private List<UsuarioBE> listaUsuarios = new List<UsuarioBE>();
        private List<RolComposite> listaRoles = new List<RolComposite>();
        private List<PermisoLeaf> listaPermisos = new List<PermisoLeaf>();
        private List<AeronaveBE> listaAeronaves = new List<AeronaveBE>();

        private UsuarioBE usuarioSeleccionado;
        private RolComposite rolSeleccionado;
        private PermisoLeaf permisoSeleccionado;

        public PanelAdministrador()
        {
            InitializeComponent();
        }

        private void PanelAdministrador_Load(object sender, EventArgs e)
        {
            CargarTreeViews();

            comboBoxRoles.DataSource = listaRoles;
            if(rolSeleccionado != null) comboBoxRoles.DataSource = listaRoles.Where(r => r.id != rolSeleccionado.id).ToList(); //no repito el rol seleccionado a la hora de hacer ROL A ROL
            comboBoxRoles.DisplayMember = "designacion";
            comboBoxRoles.ValueMember = "id";

            comboBoxPermisos.DataSource = listaPermisos;
            comboBoxPermisos.DisplayMember = "designacion";
            comboBoxPermisos.ValueMember = "id";

        }

        #region TreeView Events
        private void CargarTreeViews()
        {
            listaUsuarios = usuarioBLL.ListarUsuarios();
            listaRoles = rolBLL.ListarRoles();
            listaPermisos = permisoBLL.ListarPermisos();
            listaAeronaves = aeronaveBLL.ListarAeronaves();

            treeViewUsuarios.Nodes.Clear();
            foreach (var u in listaUsuarios)
            {
                var n = new TreeNode($"{u.nombre} {u.apellido} ({u.username})") { Tag = u };
                treeViewUsuarios.Nodes.Add(n);
            }

            treeViewRoles.Nodes.Clear();
            foreach (var r in listaRoles)
            {
                var n = new TreeNode($"{r.designacion} (ID:{r.id})") { Tag = r };
                treeViewRoles.Nodes.Add(n);
            }

            treeViewPermisos.Nodes.Clear();
            foreach (var p in listaPermisos)
            {
                var n = new TreeNode($"{p.designacion} (ID:{p.id})") { Tag = p };
                treeViewPermisos.Nodes.Add(n);
            }

            treeViewPermisosXRol.Nodes.Clear();
            foreach (var r in listaRoles)
            {
                var nodo = new TreeNode($"Rol: {r.designacion} (ID:{r.id})") { Tag = r };
                AgregarNodosPermisosYRoles(r, nodo);
                treeViewPermisosXRol.Nodes.Add(nodo);
            }

            dataGridViewAeronaves.DataSource = listaAeronaves;

            comboBoxRoles.DataSource = null;
            comboBoxRoles.DataSource = listaRoles;
            comboBoxRoles.DisplayMember = "designacion";
            comboBoxRoles.ValueMember = "id";
            comboBoxPermisos.DataSource = null;
            comboBoxPermisos.DataSource = listaPermisos;
            comboBoxPermisos.DisplayMember = "designacion";
            comboBoxPermisos.ValueMember = "id";
            comboPermisos.DataSource = null;
            comboPermisos.DataSource = listaPermisos;
            comboPermisos.DisplayMember = "designacion";
            comboPermisos.ValueMember = "id";

        }
        private void treeViewUsuarios_AfterSelect(object sender, TreeViewEventArgs e)
        {
            usuarioSeleccionado = e.Node.Tag as UsuarioBE;
            treeViewRolesyPermisosDelUsuario.Nodes.Clear();

            if (usuarioSeleccionado == null)
            {
                return;
            }

            var nodoRoles = new TreeNode("Roles asignados");
            var rolesSet = new HashSet<int>(usuarioSeleccionado.rolesAsignados);

            foreach (var rolId in rolesSet)
            {
                var compRol = listaRoles.FirstOrDefault(r => r.id == rolId);
                if (compRol != null)
                {
                    var nodoRol = new TreeNode($"Rol: {compRol.designacion} (ID:{compRol.id})")
                    {
                        Tag = compRol
                    };
                    AgregarNodosPermisosYRoles(compRol, nodoRol);
                    nodoRoles.Nodes.Add(nodoRol);
                }
                else
                {
                    nodoRoles.Nodes.Add(
                        new TreeNode($"Rol no encontrado (ID:{rolId})")
                    );
                }
            }

            if (nodoRoles.Nodes.Count == 0) nodoRoles.Text = "Roles asignados: (ninguno)";

            treeViewRolesyPermisosDelUsuario.Nodes.Add(nodoRoles);

            if (usuarioSeleccionado.permisosAdicionales.Any())
            {
                var nodoPermisosAd = new TreeNode("Permisos adicionales");
                foreach (var idPerm in usuarioSeleccionado.permisosAdicionales)
                {
                    var permisoLeaf = listaPermisos.FirstOrDefault(p => p.id == idPerm);
                    if (permisoLeaf != null)
                    {
                        nodoPermisosAd.Nodes.Add(new TreeNode($"Permiso: {permisoLeaf.designacion} (ID:{permisoLeaf.id})")
                        {
                            Tag = permisoLeaf
                        });
                    }
                }
                treeViewRolesyPermisosDelUsuario.Nodes.Add(nodoPermisosAd);
            }

            checkBoxMostrarContraseña.Checked = false;
            textBoxIdUser.Text = usuarioSeleccionado.id;
            textBoxUserName.Text = usuarioSeleccionado.username;
            textBoxNombre.Text = usuarioSeleccionado.nombre;
            textBoxApellido.Text = usuarioSeleccionado.apellido;

            var originalPassword = Encriptacion.DesencriptarPassword(usuarioSeleccionado.password);
            textBoxPww.Text = originalPassword;
            textBoxPww.UseSystemPasswordChar = true;
            checkBoxBloqueado.Checked = usuarioSeleccionado.bloqueado;

            comboBoxRolUsuario.DataSource = null;
            comboBoxRolUsuario.DataSource = listaRoles;
            comboBoxRolUsuario.DisplayMember = "designacion";
            comboBoxRolUsuario.ValueMember = "id";

            comboBoxPermisos.DataSource = null;
            comboBoxPermisos.DataSource = listaPermisos;
            comboBoxPermisos.DisplayMember = "designacion";
            comboBoxPermisos.ValueMember = "id";

            treeViewRolesyPermisosDelUsuario.ExpandAll();
        }
        private void treeViewRoles_AfterSelect(object sender, TreeViewEventArgs e)
        {
            rolSeleccionado = e.Node.Tag as RolComposite;
            treeViewPermisosXRol.Nodes.Clear();
            if (rolSeleccionado == null) return;

            var nodo = new TreeNode($"Rol: {rolSeleccionado.designacion} (ID:{rolSeleccionado.id})") { Tag = rolSeleccionado};

            AgregarNodosPermisosYRoles(rolSeleccionado, nodo);
            treeViewPermisosXRol.Nodes.Add(nodo);
            nodo.ExpandAll();

            textBoxIDRol.Text = rolSeleccionado.id.ToString();
            textBoxDesignacionRol.Text = rolSeleccionado.designacion;
            textBoxNombreRolParaAsociarRol.Text = rolSeleccionado.designacion;
            textBoxIDRolParaAsociarRol.Text = rolSeleccionado.id.ToString();

            comboPermisos.DataSource = null;
            comboPermisos.DataSource = listaPermisos;
            comboPermisos.DisplayMember = "designacion";
            comboPermisos.ValueMember = "id";
        }
        private void AgregarNodosPermisosYRoles(RolComposite rol, TreeNode padre)
        {
            foreach (var permiso in rol.ObtenerHijos().OfType<PermisoLeaf>())
            {
                var nodoPerm = new TreeNode($"Permiso: {permiso.designacion} (ID:{permiso.id})") { Tag = permiso };
                padre.Nodes.Add(nodoPerm);
            }

            foreach (var subRol in rol.ObtenerHijos().OfType<RolComposite>())
            {
                var nodoSubRol = new TreeNode($"Rol: {subRol.designacion} (ID:{subRol.id})") { Tag = subRol };
                padre.Nodes.Add(nodoSubRol);
                AgregarNodosPermisosYRoles(subRol, nodoSubRol);
            }
        }
        private void treeViewPermisos_AfterSelect(object sender, TreeViewEventArgs e)
        {
            permisoSeleccionado = e.Node.Tag as PermisoLeaf;
            if (permisoSeleccionado == null) return;

            textBoxIdPermiso.Text = permisoSeleccionado.id.ToString();
            textBoxNombrePermiso.Text = permisoSeleccionado.designacion;

            if (comboPermisos.DataSource != null)
            {
                comboPermisos.SelectedValue = permisoSeleccionado.id;
            }
        }

        private void treeViewRolesyPermisosDelUsuario_AfterSelect(object sender, TreeViewEventArgs e)
        {
            var permiso = e.Node.Tag as PermisoLeaf;
            if (permiso == null) return;
            comboBoxPermisos.SelectedValue = permiso.id;
        }
        #endregion
        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonLimpiarCampos_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        #region ROL:
        private void bttnAltaRol_Click(object sender, EventArgs e)
        {
            var design = textBoxDesignacionRol.Text.Trim();
            if (string.IsNullOrEmpty(design)) { MessageBox.Show("La designación no puede estar vacía.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            try
            {
                var nuevoRol = new RolComposite { designacion = design };
                rolBLL.CrearRol(nuevoRol);

                MessageBox.Show(
                  $"Rol: {nuevoRol.designacion} creado exitosamente", "Rol", MessageBoxButtons.OK, MessageBoxIcon.Information);

                CargarTreeViews();
                textBoxIDRol.Clear();
                textBoxDesignacionRol.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Error al crear rol",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void bttnModificarRol_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(textBoxIDRol.Text, out var idRol) || idRol < 0)
            {
                MessageBox.Show("ID de rol inválido.", "Error",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var nuevaDesignacion = textBoxDesignacionRol.Text.Trim();
            if (string.IsNullOrEmpty(nuevaDesignacion))
            {
                MessageBox.Show("La designación no puede quedar vacía.", "Error",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var rol = listaRoles.FirstOrDefault(r => r.id == idRol);
                if (rol == null)
                {
                    MessageBox.Show("El rol seleccionado no está en la lista.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                rol.designacion = nuevaDesignacion;

                rolBLL.ActualizarRol(rol);

                MessageBox.Show($"Rol ID {rol.id} modificado a '{rol.designacion}'","Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                CargarTreeViews();
                
                var idx = listaRoles.FindIndex(r => r.id == rol.id);
                
                if (idx >= 0)
                {
                    treeViewRoles.SelectedNode = treeViewRoles.Nodes[idx];
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al modificar rol",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bttnEliminarRol_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(textBoxIDRol.Text, out var idRol) || idRol < 0)
            {
                MessageBox.Show("ID de rol inválido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirm = MessageBox.Show($"¿Seguro que desea eliminar el rol '{textBoxDesignacionRol.Text}'?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes) return;

            try
            {
                var rol = listaRoles.FirstOrDefault(r => r.id == idRol);
                if (rol == null)
                {
                    MessageBox.Show("El rol no existe en la memoria.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var padre = CompositeHelper.EncontrarPadre(listaRoles, rol);
                if (padre != null)
                {
                    padre.EliminarHijo(rol);
                }

                rolBLL.EliminarRol(idRol);
                listaRoles.Remove(rol);

                MessageBox.Show("Rol eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarTreeViews();
                textBoxIDRol.Clear();
                textBoxDesignacionRol.Clear();
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "No se puede eliminar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al eliminar rol", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Roles/Permisos Usuario:

        #region Roles a usuario:
        private void buttonAsociarRolUser_Click(object sender, EventArgs e)
        {
            if (usuarioSeleccionado == null)
            {
                MessageBox.Show("Primero seleccioná un usuario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (comboBoxRolUsuario.SelectedItem == null)
            {
                MessageBox.Show("Seleccioná un rol para asignar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var usuarioNuevoRol = listaUsuarios.First(u => u.id == usuarioSeleccionado.id);
            usuarioNuevoRol.rolesAsignados.Add((int)comboBoxRolUsuario.SelectedValue);

            try
            {
                var originalPww = Encriptacion.DesencriptarPassword(usuarioNuevoRol.password);
                usuarioNuevoRol.password = originalPww;
                usuarioBLL.GuardarUsuario(usuarioNuevoRol);
                MessageBox.Show("Rol asignado correctamente al usuario.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarTreeViews();
                var nodo = treeViewUsuarios.Nodes.Cast<TreeNode>().FirstOrDefault(n => ((UsuarioBE)n.Tag).id == usuarioNuevoRol.id);

                if (nodo != null)
                { 
                    treeViewUsuarios.SelectedNode = nodo;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al asignar rol", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonQuitarRolUser_Click(object sender, EventArgs e)
        {
            if (usuarioSeleccionado == null)
            {
                MessageBox.Show("Primero seleccioná un usuario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (comboBoxRolUsuario.SelectedItem == null)
            {
                MessageBox.Show("Seleccioná un rol para quitar.", "Error",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }

            var usuarioSacarRol = listaUsuarios.First(u => u.id == usuarioSeleccionado.id);

            int idRol = (int)comboBoxRolUsuario.SelectedValue;
            usuarioSacarRol.rolesAsignados.Remove(idRol);
            usuarioSacarRol.rolesAsignados = usuarioSacarRol.rolesAsignados.Where(id => id > 0).Distinct().ToList();

            try
            {
                var originalPww = Encriptacion.DesencriptarPassword(usuarioSacarRol.password);
                usuarioSacarRol.password = originalPww;
                usuarioBLL.GuardarUsuario(usuarioSacarRol);

                MessageBox.Show("Rol quitado correctamente del usuario.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarTreeViews();
                var nodo = treeViewUsuarios.Nodes.Cast<TreeNode>().FirstOrDefault(n => ((UsuarioBE)n.Tag).id == usuarioSacarRol.id);

                if (nodo != null)
                {
                    treeViewUsuarios.SelectedNode = nodo;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al quitar rol",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        #endregion
        #region Permisos a usuario:
        private void buttonAsociarPermisoUser_Click(object sender, EventArgs e)
        {
            if (usuarioSeleccionado == null)
            {
                MessageBox.Show("Primero seleccioná un usuario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            permisoSeleccionado = comboBoxPermisos.SelectedItem as PermisoLeaf;

            if (permisoSeleccionado == null)
            {
                MessageBox.Show("Seleccioná un permiso para asignar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var usuarioNuevoPermiso = listaUsuarios.FirstOrDefault(u => u.id == usuarioSeleccionado.id);

            try
            {
                var originalPww = Encriptacion.DesencriptarPassword(usuarioNuevoPermiso.password);
                usuarioNuevoPermiso.password = originalPww;
                usuarioBLL.AsignarPermisoAdicional (usuarioNuevoPermiso, permisoSeleccionado.id);
                MessageBox.Show("permiso asignado correctamente al usuario.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarTreeViews();
                var nodo = treeViewUsuarios.Nodes.Cast<TreeNode>().FirstOrDefault(n => ((UsuarioBE)n.Tag).id == usuarioNuevoPermiso.id);

                if (nodo != null)
                {
                    treeViewUsuarios.SelectedNode = nodo;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al asignar permiso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonQuitarPermisoUser_Click(object sender, EventArgs e)
        {
            if (usuarioSeleccionado == null)
            {
                MessageBox.Show("Primero seleccioná un usuario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            permisoSeleccionado = comboBoxPermisos.SelectedItem as PermisoLeaf;

            if (permisoSeleccionado == null)
            {
                MessageBox.Show("Seleccioná un permiso para quitar (debe ser un permiso adicional).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var usuarioSacarPermiso = listaUsuarios.FirstOrDefault(u => u.id == this.usuarioSeleccionado.id);

            try
            {
                var originalPww = Encriptacion.DesencriptarPassword(usuarioSacarPermiso.password);
                usuarioSacarPermiso.password = originalPww;
                usuarioBLL.QuitarPermisoAdicional(usuarioSacarPermiso, permisoSeleccionado.id);
                MessageBox.Show("permiso removido de forma exitosa al usuario.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarTreeViews();
                var nodo = treeViewUsuarios.Nodes.Cast<TreeNode>().FirstOrDefault(n => ((UsuarioBE)n.Tag).id == usuarioSacarPermiso.id);

                if (nodo != null)
                {

                    treeViewUsuarios.SelectedNode = nodo;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al quitar permiso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #endregion

        #region Rol para Asociar/Desasociar a otro Rol:
        private void buttonAsociarRolaRol_Click(object sender, EventArgs e)
        {
            var rolPadre = rolSeleccionado;
            var rolHijo = comboBoxRoles.SelectedItem as RolComposite;

            if (rolPadre == null || rolHijo == null)
            {
                MessageBox.Show("Seleccioná un rol padre y un rol hijo para asociar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                rolBLL.AsociarSubRol(rolPadre, rolHijo);
                MessageBox.Show("Rol asociado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarTreeViews();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al asociar rol", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void buttonDesasociarRolaRol_Click(object sender, EventArgs e)
        {
            var rolPadre = rolSeleccionado;
            var rolHijo = comboBoxRoles.SelectedItem as RolComposite; 

            if (rolPadre == null || rolHijo == null)
            {
                MessageBox.Show("Seleccioná un rol padre y un rol hijo para desasociar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                rolBLL.DesasociarSubRol(rolPadre, rolHijo);
                MessageBox.Show("Rol desasociado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarTreeViews();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al desasociar rol", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
        #endregion

        private void buttonCrearAeronave_Click(object sender, EventArgs e)
        {
            AeronaveBE aeronave = new AeronaveBE
            {
                matricula = textBoxMatricula.Text.Trim(),
                marca = textBoxMarca.Text.Trim(),
                modelo = textBoxModelo.Text.Trim(),
                serial = textBoxSerie.Text.Trim()
            };

            AeronaveBLL aeronaveBLL = new AeronaveBLL();
            aeronaveBLL.GuardarAeronave(aeronave);

            MessageBox.Show($"Aeronave {aeronave.matricula} creada exitosamente!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void buttonCrearUser_Click(object sender, EventArgs e)
        {
            Form newUserForm = new NuevoUsuario();
            newUserForm.ShowDialog();
            CargarTreeViews(); 
        }
        private void buttonModificarUsuario_Click(object sender, EventArgs e)
        {
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

            try
            {
                usuarioBLL.GuardarUsuario(usuarioSeleccionado);

                MessageBox.Show("Usuario modificado correctamente.", "Éxito",MessageBoxButtons.OK, MessageBoxIcon.Information);

                CargarTreeViews();
                var nodo = treeViewUsuarios.Nodes.Cast<TreeNode>().FirstOrDefault(n => ((UsuarioBE)n.Tag).id == usuarioSeleccionado.id);
                if (nodo != null) treeViewUsuarios.SelectedNode = nodo;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al modificar usuario", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #region Permisos a Rol:
        private void buttonAsociarPermisoRol_Click(object sender, EventArgs e)
        {
            if (rolSeleccionado == null) 
            {
                MessageBox.Show("Debe seleccionar un rol", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (comboPermisos.SelectedItem == null) 
            {
                MessageBox.Show("Debe seleccionar un permiso para asociar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var permisoAsociar = comboPermisos.SelectedItem as PermisoLeaf;

            try
            {
                rolBLL.AsociarPermiso(rolSeleccionado, permisoAsociar);

                MessageBox.Show("Permiso asociado exitosamente al rol.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                CargarTreeViews();
                var nodo = treeViewRoles.Nodes.Cast<TreeNode>().FirstOrDefault(n => ((RolComposite)n.Tag).id == rolSeleccionado.id);
                if (nodo != null) treeViewRoles.SelectedNode = nodo;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al asociar permiso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void buttonQuitarPermisoRol_Click(object sender, EventArgs e)
        {
            if (rolSeleccionado == null)
            {
                MessageBox.Show("Debe seleccionar un rol.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var permiso = comboPermisos.SelectedItem as PermisoLeaf;
            permisoSeleccionado = permiso;

            if (permiso == null)
            {
                MessageBox.Show("Debe seleccionar un permiso.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                rolBLL.DesasociarPermiso(rolSeleccionado, permisoSeleccionado);

                MessageBox.Show("Permiso removido exitosamente del rol.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                CargarTreeViews();
                var nodo = treeViewRoles.Nodes.Cast<TreeNode>().FirstOrDefault(n => ((RolComposite)n.Tag).id == rolSeleccionado.id);
                if (nodo != null) treeViewRoles.SelectedNode = nodo;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al quitar permiso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        private void checkBoxMostrarContraseña_CheckedChanged(object sender, EventArgs e)
        {
            textBoxPww.UseSystemPasswordChar = !checkBoxMostrarContraseña.Checked;
        }

        private void LimpiarCampos()
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

            textBoxIdAeronave.Clear();
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

        private void btnBackup_Click(object sender, EventArgs e)
        {
            BackupForm bForm = new BackupForm();
            bForm.Show();
        }
    }
}
