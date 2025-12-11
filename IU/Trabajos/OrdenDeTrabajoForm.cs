using BE.Composite;
using BE.Modelo;
using BLL;
using BLL.Roles;
using BLL.Servicios;
using DocumentFormat.OpenXml.EMMA;
using DocumentFormat.OpenXml.Office2010.Excel;
using DocumentFormat.OpenXml.Presentation;
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
using System.Windows.Forms.DataVisualization.Charting;
using System.Xml.Schema;

namespace IU
{
    public partial class OrdenDeTrabajoForm : Form
    {
        public OrdenDeTrabajo ordenActual = new OrdenDeTrabajo(); 
        public OrdenDeTrabajoForm(OrdenDeTrabajo ot)
        {
            InitializeComponent();
            MessageBox.Show(ordenActual.mecanico); 
            var usuario = SesionUsuario.Instancia.UsuarioActual;
            var permisos = usuario.permisos;
            LlenarOT(ot);
            ordenActual = ot;
        }

        private void LlenarOT(OrdenDeTrabajo ot)
        {
            var usuario = SesionUsuario.Instancia.UsuarioActual;
            bool requiereFirmaMecanico = ot.trabajo.listaTareas.Any(t => string.IsNullOrEmpty(t.nroMecanico));
            bool requiereFirmaInspector = ot.trabajo.listaTareas.Any(t => string.IsNullOrEmpty(t.nroInspector));

            txtNumeroOT.Text = ot.numeroOT?.ToString() ?? string.Empty;
            txtTituloOT.Text = ot.titulo ?? string.Empty;
            txtSerial.Text = ot.serial ?? string.Empty;
            txtMatricula.Text = ot.matricula ?? string.Empty;
            txtAeronave.Text = ot.aeronave ?? string.Empty;
            txtFecha.Text = ot.fechaInicio.ToString("dd/MM/yyyy");
            txtIntervalo.Text = ot.trabajo.intervalo ?? string.Empty;
            lblReferencia.Text = ot.trabajo.referencias ?? string.Empty;
            txtNota.Text = ot.trabajo.nota ?? string.Empty;
            lblFechaConformance.Text = ot.fechaCierre != DateTime.MinValue ? ot.fechaCierre.ToString("dd/MM/yyyy"): "_";

            buttonFirmaMecanico.Text = ot.mecanico ?? string.Empty;
            buttonFirmaInspector.Text = ot.inspector ?? string.Empty;


            dataGridViewMateriales.DataSource = ot.trabajo.listaMateriales;
            if (dataGridViewMateriales.Columns.Contains("Descripcion"))
                dataGridViewMateriales.Columns["Descripcion"].Width = 200;
            dataGridViewMateriales.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dataGridViewMateriales.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            dataGridViewHerramientas.DataSource = ot.trabajo.listaHerramientas;
            if (dataGridViewHerramientas.Columns.Contains("Descripcion"))
                dataGridViewHerramientas.Columns["Descripcion"].Width = 200;
            dataGridViewHerramientas.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dataGridViewHerramientas.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            dataGridViewTareas.AutoGenerateColumns = false;
            dataGridViewTareas.Columns.Clear();

            dataGridViewTareas.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "descripcion",
                Name = "Tarea",
                HeaderText = "Tarea",
                Width = 540,
            });

            dataGridViewTareas.Columns.Add(new DataGridViewButtonColumn
            {
                DataPropertyName = "nroMecanico",
                Name = "nroMecanico",
                HeaderText = "Mecánico",
                Width = 100,
                Text = "Firmar",
                UseColumnTextForButtonValue = false 
            });

            dataGridViewTareas.Columns.Add(new DataGridViewButtonColumn
            {
                DataPropertyName = "nroInspector",
                Name = "nroInspector",
                HeaderText = "Inspector",
                Width = 100,
                Text = "Firmar",
                UseColumnTextForButtonValue = false
            });

            dataGridViewTareas.DataSource = ot.listaTareasOT;

            foreach (DataGridViewRow row in dataGridViewTareas.Rows)
            {
                var tarea = row.DataBoundItem as TareaBE;
                if (tarea == null) continue;

                if (requiereFirmaMecanico && string.IsNullOrEmpty(tarea.nroMecanico))
                {
                    row.Cells["nroMecanico"].Value = "Firmar";
                }
                else
                {
                    row.Cells["nroMecanico"].Value = string.IsNullOrEmpty(tarea.nroMecanico) ? "Firmar" : tarea.nroMecanico;
                }

                if (requiereFirmaInspector && string.IsNullOrEmpty(tarea.nroInspector))
                {
                    row.Cells["nroInspector"].Value = "Firmar";
                }
                else 
                {
                    row.Cells["nroInspector"].Value = tarea.nroInspector ?? "Firmar"; 
                }
            }
            
        }

        private void buttonFirmaMecanico_Click(object sender, EventArgs e)
        {
            var usuario = SesionUsuario.Instancia.UsuarioActual;
            var permisos = usuario.permisos;
            var permisosTotales = usuario.permisos
            .SelectMany(UsuarioBLL.AplanarPermisos)
            .ToList();

            if (!permisosTotales.Contains(TipoPermisoBE.Firmar_Tarea))
            {
                MessageBox.Show("No tenés permiso de mecánico.", "Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(ordenActual.mecanico))
            {
                ordenActual.mecanico = usuario.nroMecanico;
                buttonFirmaMecanico.Text = $"[{usuario.nroMecanico}]";
                buttonFirmaMecanico.Enabled = false;
            }
            else
            {
                MessageBox.Show("La orden ya fue firmada por el mecánico.");
            }
        }
        private void buttonFirmaInspector_Click(object sender, EventArgs e)
        {
            var usuario = SesionUsuario.Instancia.UsuarioActual;
            var permisos = usuario.permisos;
            var permisosTotales = usuario.permisos
            .SelectMany(UsuarioBLL.AplanarPermisos)
            .ToList();

            if (ordenActual.mecanico == null || ordenActual.mecanico == "")
            {
                MessageBox.Show("La orden debe ser firmada por el mecánico antes de ser certificada por el inspector.","Acción no permitida",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }

            if (!permisosTotales.Contains(TipoPermisoBE.Certificar_Tarea))
            {
                MessageBox.Show("No tenés permiso de inspector.", "Acceso denegado",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(ordenActual.inspector))
            {
                ordenActual.inspector = usuario.nroInspector;
                ordenActual.estado = "Completada";
                ordenActual.fechaCierre = DateTime.Now;

                new OrdenDeTrabajoBLL().ActualizarOT(ordenActual);

                buttonFirmaInspector.Text = $"[{usuario.nroInspector}]";
                buttonFirmaInspector.Enabled = false;

                MessageBox.Show("La orden ha sido certificada por el inspector.","Cierre exitoso",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("La orden ya fue certificada.");
            }
        }

        private void bttnCerrar_Click(object sender, EventArgs e)
        {
            var otBLL = new OrdenDeTrabajoBLL();
            otBLL.ActualizarOT(ordenActual);

            this.Close();
        }

        private void dataGridViewTareas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            UsuarioBLL oBLLUser = new UsuarioBLL();
            var grid = (DataGridView)sender;
            var colName = grid.Columns[e.ColumnIndex].Name;
            var tarea = grid.Rows[e.RowIndex].DataBoundItem as TareaBE;
            var usuario = SesionUsuario.Instancia.UsuarioActual;
            var permisos = usuario.permisos;

            var permisosTotales = usuario.permisos
                    .SelectMany(UsuarioBLL.AplanarPermisos)
                    .ToList();

            if (colName == "nroMecanico")
            {
                if (!permisosTotales.Contains(TipoPermisoBE.Firmar_Tarea))
                {
                    MessageBox.Show("No tenés permiso para firmar.", "Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                tarea.nroMecanico = usuario.nroMecanico;

                grid.Rows[e.RowIndex].Cells["nroMecanico"] = new DataGridViewTextBoxCell
                {
                    Value = tarea.nroMecanico
                };

                new OrdenDeTrabajoBLL().ActualizarOT(ordenActual);
            }
            else if (colName == "nroInspector")
            {
                if (!permisosTotales.Contains(TipoPermisoBE.Certificar_Tarea))
                {
                    MessageBox.Show("No tenés permiso para certificar.", "Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                tarea.nroInspector = usuario.nroInspector;
                grid.Rows[e.RowIndex].Cells["nroInspector"] = new DataGridViewTextBoxCell
                {
                    Value = tarea.nroInspector
                };

                new OrdenDeTrabajoBLL().ActualizarOT(ordenActual);
            }
        }
    }
}
