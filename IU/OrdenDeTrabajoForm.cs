using BE.Modelo;
using BLL;
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

namespace IU
{
    public partial class OrdenDeTrabajoForm : Form
    {
        public OrdenDeTrabajoForm(OrdenDeTrabajo ot)
        {
            InitializeComponent();

            LlenarOT(ot);
        }

        private void LlenarOT(OrdenDeTrabajo ot)
        {

            if (ot != null && ot.trabajo != null)
            {
                txtNumeroOT.Text = ot.numeroOT?.ToString() ?? string.Empty;
                txtTituloOT.Text = ot.titulo ?? string.Empty;
                txtSerial.Text = ot.serial ?? string.Empty;
                txtMatricula.Text = ot.matricula ?? string.Empty;
                txtAeronave.Text = ot.aeronave ?? string.Empty;
                txtFecha.Text = ot.fechaInicio.ToString("dd/MM/yyyy");
                txtIntervalo.Text = ot.trabajo.intervalo ?? string.Empty;
                lblReferencia.Text = ot.trabajo.referencias ?? string.Empty;
                txtNota.Text = ot.trabajo.nota ?? string.Empty;
                lblFechaConformance.Text = DateTime.Now.ToString("dd/MM/yyyy");

                dataGridViewMateriales.DataSource = ot.trabajo.listaMateriales;
                dataGridViewMateriales.Columns["Descripcion"].Width = 200;
                dataGridViewMateriales.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                dataGridViewMateriales.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                dataGridViewHerramientas.DataSource = ot.trabajo.listaHerramientas;
                dataGridViewHerramientas.Columns["Descripcion"].Width = 200;
                dataGridViewHerramientas.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                dataGridViewHerramientas.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

                if (ot.trabajo.listaTareas != null)
                {
                    var tareasDataSource = ot.trabajo.listaTareas
                        .Select(t => new { Tareas = t })
                        .ToList();
                    
                    dataGridViewTareas.DataSource = tareasDataSource;
                    dataGridViewTareas.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                    dataGridViewTareas.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                    dataGridViewTareas.Columns["Tareas"].Width = 540;
                }
                else
                {
                    dataGridViewTareas.DataSource = null;
                }
                //mecanico
                if (!dataGridViewTareas.Columns.Contains("btnFirmar"))
                {
                    var buttonColumn = new DataGridViewButtonColumn();
                    buttonColumn.Name = "btnFirmar";
                    buttonColumn.HeaderText = "Firma";
                    buttonColumn.Text = "Mecanico";
                    buttonColumn.UseColumnTextForButtonValue = true;
                    dataGridViewTareas.Columns.Add(buttonColumn);
                }
                //inspector
                if (!dataGridViewTareas.Columns.Contains("btnCertificar"))
                {
                    var buttonColumn = new DataGridViewButtonColumn();
                    buttonColumn.Name = "btnCertificar";
                    buttonColumn.HeaderText = "Certifica";
                    buttonColumn.Text = "Inspector";
                    buttonColumn.UseColumnTextForButtonValue = true;
                    dataGridViewTareas.Columns.Add(buttonColumn);
                }

            }
        }


        //EDITAR
        private void dataGridViewTareas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                var grid = (DataGridView)sender;

                if (grid.Columns[e.ColumnIndex].Name == "btnFirmar") //podemos hacer OTRO pero para Inspectores? o que firme en el mmismo boton?
                {
                    // Validar si es mecánico
                    var usuario = SesionUsuario.Instancia.UsuarioActual;
                    var permisos = UsuarioBLL.ObtenerPermisosEfectivos(usuario.id);

                    if (permisos.Any(p => p.nombre == "Firmar Tarea")) // o si  rol == "Mecánico"
                    {
                        var tareaNombre = grid.Rows[e.RowIndex].Cells["Tarea"].Value?.ToString();
                        //Actualizar la firma de la tarea. Reemplazar boton.
                        //AÑADIR NUMERO DE MECANICO (ROL = MECANICO = GENERA UN NRO DE MECANICO AL USUARIO)
                        //grid.Rows[e.RowIndex].Cells["btnFirmar"].Value = $"{SesionUsuario.Instancia.UsuarioActual.nroMecanico}";
                    }
                    else
                    {
                        MessageBox.Show("No tenés permisos para firmar esta tarea.");
                    }
                }
            }
        }


        private void buttonFirmaMecanico_Click(object sender, EventArgs e)
        {
             
        }

        private void buttonFirmaInspector_Click(object sender, EventArgs e)
        {

        }

        private void bttnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /*        public void CerrarOT(string numeroOT, string idMecanico, string idInspector)
       {
           var lista = ListarOrdenes();

           var ot = lista.FirstOrDefault(o => o.numeroOT == numeroOT);
           if (ot == null) throw new Exception("OT no encontrada");

           ot.estado = "Completa";
           ot.fechaCierre = DateTime.Now;
           ot.mecanico = idMecanico;
           ot.inspector = idInspector;

           OrdenDeTrabajoBLL otBLL = new OrdenDeTrabajoBLL();
           otBLL.ActualizarOT(ot);
       }

       */
    }
}
