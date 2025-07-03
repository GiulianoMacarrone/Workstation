using BE.Modelo;
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
        public PanelAdministrador()
        {
            InitializeComponent();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
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
            AeronaveBE aeronave = new AeronaveBE
            {
                matricula = textBoxMatricula.Text.Trim(),
                marca = textBoxMarca.Text.Trim(),
                modelo = textBoxModelo.Text.Trim(),
                serial = textBoxSerie.Text.Trim()
            };

            AeronaveBLL aeronaveBLL = new AeronaveBLL();
            aeronaveBLL.GuardarAeronave(aeronave);

        }

        private void buttonAsociarRolUser_Click_1(object sender, EventArgs e)
        {
            
        }

        private void buttonCrearUser_Click(object sender, EventArgs e)
        {
            
        }
    }
}
