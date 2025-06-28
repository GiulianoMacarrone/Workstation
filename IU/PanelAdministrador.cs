using Abstraccion;
using BE.Modelo;
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
        public PanelAdministrador()
        {
            InitializeComponent();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {

        }

        private void buttonLimpiarCampos_Click(object sender, EventArgs e)
        {

        }

        #region PERMISO:
        private void buttonEliminarPermiso_Click(object sender, EventArgs e)
        {

        }

        private void buttonAltaPermiso_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #region ROL:
        private void bttnEliminarRol_Click(object sender, EventArgs e)
        {

        }

        private void bttnModificarRol_Click(object sender, EventArgs e)
        {

        }

        private void bttnAltaRol_Click(object sender, EventArgs e)
        {

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
        private void buttonAsociarRolesUser2_Click(object sender, EventArgs e)
        {

        }

        private void buttonDesasociarRolesUser2_Click(object sender, EventArgs e)
        {

        }
        #endregion

        private void buttonCrearAeronave_Click(object sender, EventArgs e)
        {

        }

        private void buttonAsociarRolUser_Click_1(object sender, EventArgs e)
        {
            if(comboBoxRolUsuario.Text == "Mecánico")
            {
                MecanicoBE mecanico = new MecanicoBE() //con el ID buscamos el usuario y le asignamos el ROL de mecánico
                {
                    //hay q asignar un nro de mecánico único, por ejemplo M01, M02, etc. Asi que hay q buscar el nro de mecanico que SIGUE
                    nroMecanico = "M"+
                };
            }
        }

        private void buttonCrearUser_Click(object sender, EventArgs e)
        {
            
        }
    }
}
