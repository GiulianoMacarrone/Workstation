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
        private List<Rol> listaRoles = new List<Rol>();
        private List<Permiso> listaPermisos = new List<Permiso>();
        private List<AeronaveBE> listaAeronaves = new List<AeronaveBE>();

        private UsuarioBE usuarioSeleccionado;
        private Rol rolSeleccionado;
        private Permiso permisoSeleccionado;
        private AeronaveBE aeronaveSeleccionada;



        public PanelAdministrador()
        {
            InitializeComponent();
            Load += PanelAdministrador_Load;
        }

        private void PanelAdministrador_Load(object sender, EventArgs e)
        {
            CargarTreeViews();

            comboBoxRoles.DataSource = listaRoles;
            comboBoxRoles.DisplayMember = "designacion";
            comboBoxRoles.ValueMember = "id";

            comboBoxPermisos.DataSource = listaPermisos;
            comboBoxPermisos.DisplayMember = "nombre";
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
                var n = new TreeNode($"{p.nombre} (ID:{p.id})") { Tag = p };
                treeViewPermisos.Nodes.Add(n);
            }

            dataGridViewAeronaves.DataSource = listaAeronaves;
        
        }

        private void treeViewUsuarios_AfterSelect(object sender, TreeViewEventArgs e)
        {
            usuarioSeleccionado = e.Node.Tag as UsuarioBE;
            treeViewRolesyPermisosDelUsuario.Nodes.Clear();

            if (usuarioSeleccionado == null) return;

            var rol = listaRoles.FirstOrDefault(r => r.id == usuarioSeleccionado.idRol);
            if (rol != null)
            {
                var nodoRol = new TreeNode($"Rol: {rol.designacion}") { Tag = rol };
                foreach (var idPerm in rol.idsPermisos)
                {
                    var p = listaPermisos.FirstOrDefault(x => x.id == idPerm);
                    if (p != null)
                    {
                        nodoRol.Nodes.Add(new TreeNode($"Permiso: {p.nombre}") { Tag = p });
                    }
                }
                treeViewRolesyPermisosDelUsuario.Nodes.Add(nodoRol);
            }

            if (usuarioSeleccionado.permisosAdicionales.Any())
            {
                var extras = new TreeNode("Permisos adicionales");
                foreach (var idPerm in usuarioSeleccionado.permisosAdicionales)
                {
                    var p = listaPermisos.FirstOrDefault(x => x.id == idPerm);
                    if (p != null)
                    {
                        extras.Nodes.Add(new TreeNode(p.nombre) { Tag = p });
                    }
                }
                treeViewRolesyPermisosDelUsuario.Nodes.Add(extras);
            }

            textBoxIdUser.Text = usuarioSeleccionado.id;
            textBoxUserName.Text = usuarioSeleccionado.username;
            textBoxNombre.Text = usuarioSeleccionado.nombre;
            textBoxApellido.Text = usuarioSeleccionado.apellido;
            textBoxPww.Text = usuarioSeleccionado.password;
            checkBoxBlock.Checked = usuarioSeleccionado.bloqueado;

            comboBoxRolUsuario.DataSource = null;
            comboBoxRolUsuario.DataSource = listaRoles;
            comboBoxRolUsuario.DisplayMember = "designacion";
            comboBoxRolUsuario.ValueMember = "id";
            comboBoxRolUsuario.SelectedIndex = listaRoles.FindIndex(r => r.id == usuarioSeleccionado.idRol);

            comboBoxPermisos.DataSource = null;
            comboBoxPermisos.DataSource = listaPermisos;
            comboBoxPermisos.DisplayMember = "nombre";
            comboBoxPermisos.ValueMember = "id";

            treeViewRolesyPermisosDelUsuario.ExpandAll();
        }
        private void treeViewRoles_AfterSelect(object sender, TreeViewEventArgs e)
        {
            rolSeleccionado = e.Node.Tag as Rol;
            treeViewPermisosXRol.Nodes.Clear();
            if (rolSeleccionado == null) return;

            var nodoRol = new TreeNode($"Rol: {rolSeleccionado.designacion}");
            foreach (var idPerm in rolSeleccionado.idsPermisos)
            {
                var p = listaPermisos.FirstOrDefault(x => x.id == idPerm);
                if (p != null)
                {
                    nodoRol.Nodes.Add(new TreeNode($"{p.nombre} (ID:{p.id})") { Tag = p });
                }
            }
            treeViewPermisosXRol.Nodes.Add(nodoRol);

            textBoxIDRol.Text = rolSeleccionado.id.ToString();
            textBoxDesignacionRol.Text = rolSeleccionado.designacion;

            comboPermisos.DataSource = null;
            comboPermisos.DataSource = listaPermisos;
            comboPermisos.DisplayMember = "nombre";
            comboPermisos.ValueMember = "id";

            treeViewPermisosXRol.ExpandAll();
        }

        private void treeViewPermisos_AfterSelect(object sender, TreeViewEventArgs e)
        {
            permisoSeleccionado = e.Node.Tag as Permiso;
            if (permisoSeleccionado == null) return;

            textBoxIdPermiso.Text = permisoSeleccionado.id.ToString();
            textBoxNombrePermiso.Text = permisoSeleccionado.nombre;
            
        }

        private void treeViewRolesyPermisosDelUsuario_AfterSelect(object sender, TreeViewEventArgs e)
        {
            var permiso = e.Node.Tag as Permiso;
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
                var nuevoRol = new Rol { designacion = design };
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

            var nuevaDesign = textBoxDesignacionRol.Text.Trim();
            if (string.IsNullOrEmpty(nuevaDesign))
            {
                MessageBox.Show("La designación no puede quedar vacía.", "Error",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var rol = new Rol
                {
                    id = idRol,
                    designacion = nuevaDesign
                };

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

        private void bttnEliminarRol_Click(object sender, EventArgs e) //desactivamos el rol, no lo eliminamos de la base de datos
        {
            if (!int.TryParse(textBoxIDRol.Text, out var idRol) || idRol < 0)
            {
                MessageBox.Show("ID de rol inválido.", "Error",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirm = MessageBox.Show($"¿Seguro que desea eliminar el rol {textBoxDesignacionRol.Text}?","Confirmar desactivación",MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes) return;

            try
            {
                rolBLL.EliminarRol(idRol);
                MessageBox.Show("Rol desactivado correctamente.","Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarTreeViews();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Error al desactivar rol",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Roles/Permisos Usuario:

        #region Roles a usuario:
        private void buttonAsociarRolUser_Click(object sender, EventArgs e)
        {
            
        }

        private void buttonQuitarRolUser_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #region Permisos a usuario:
        private void buttonAsociarPermisoAUser_Click(object sender, EventArgs e)
        {

        }

        private void buttonQuitarPermisoAUser_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #endregion

        #region Rol para Asociar/Desasociar a otro Rol:
        private void buttonAsociarRolaRol_Click(object sender, EventArgs e)
        {

        }

        private void buttonDesasociarRolaRol_Click(object sender, EventArgs e)
        {

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

        }

        #region Permisos a Rol:
        private void buttonAsociarPermiso_Click(object sender, EventArgs e)
        {
            int idPermisoSeleccionado = Int32.Parse(textBoxIdPermiso.Text);
            if (textBoxIdPermiso.Text == null || idPermisoSeleccionado <= 0) MessageBox.Show("Debe seleccionar un permiso válido."); 
            
            int idRolSeleccionado = Int32.Parse(textBoxIDRol.Text);
            if (textBoxIDRol.Text == null || idRolSeleccionado <= 0) MessageBox.Show("Debe seleccionar un rol válido.");

            MessageBox.Show("Permiso asociado exitosamente al rol.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

            CargarTreeViews();
        }

        private void buttonQuitarPermiso_Click(object sender, EventArgs e)
        {

        }
        #endregion

        private void buttonAsociarPermisoUser_Click(object sender, EventArgs e)
        {

        }

        private void buttonQuitarPermisoUser_Click(object sender, EventArgs e)
        {

        }

        private void buttonAsociarPermisoARol_Click(object sender, EventArgs e)
        {

        }

        private void buttonQuitarPermisoARol_Click(object sender, EventArgs e)
        {

        }

        private void checkBoxMostrarContraseña_CheckedChanged(object sender, EventArgs e)
        {
            textBoxPww.UseSystemPasswordChar = !checkBoxMostrarContraseña.Checked;
        }

        private void treeViewPermisosXRol_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }
        private void LimpiarCampos()
        {
            // TextBoxes
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

            // CheckBoxes
            checkBoxMostrarContraseña.Checked = false;
            checkBoxBlock.Checked = false;
            checkBoxActive.Checked = false;

            // ComboBoxes (sin selección)
            comboBoxRoles.SelectedIndex = -1;
            comboBoxRolUsuario.SelectedIndex = -1;
            comboBoxPermisos.SelectedIndex = -1;
            comboPermisos.SelectedIndex = -1;

            // Deseleccionar TreeViews
            treeViewUsuarios.SelectedNode = null;
            treeViewRoles.SelectedNode = null;
            treeViewPermisos.SelectedNode = null;
            treeViewPermisosXRol.SelectedNode = null;
            treeViewRolesyPermisosDelUsuario.SelectedNode = null;
        }
    }
}
