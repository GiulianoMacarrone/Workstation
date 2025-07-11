using BE.Composite;
using BE.Modelo;
using BLL;
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
            var usuario = SesionUsuario.Instancia.UsuarioActual;
            var permisos = UsuarioBLL.ObtenerPermisosEfectivos(usuario);
            LlenarOT(ot);
            ordenActual = ot;
        }

        private void LlenarOT(OrdenDeTrabajo ot)
        {
            var usuario = SesionUsuario.Instancia.UsuarioActual;
            bool requiereFirmaMecanico = ot.trabajo.listaTareas?.Any(t => !t.Contains("Mec:")) ?? false;
            bool requiereFirmaInspector = ot.trabajo.listaTareas?.Any(t => !t.Contains("Ins:")) ?? false;

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

            if (ot.trabajo.listaTareas != null)
            {
                var tareasDataSource = ot.trabajo.listaTareas.Select(t => new { Tareas = t }).ToList();
                dataGridViewTareas.DataSource = tareasDataSource;

                if (dataGridViewTareas.Columns["Tareas"] != null)
                    dataGridViewTareas.Columns["Tareas"].HeaderText = "Tarea";

                dataGridViewTareas.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                dataGridViewTareas.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                dataGridViewTareas.Columns["Tareas"].Width = 540;
            }
            else
            {
                dataGridViewTareas.DataSource = null;
            }

            if (!dataGridViewTareas.Columns.Contains("btnFirmar") && requiereFirmaMecanico)
            {
                var btnMec = new DataGridViewButtonColumn
                {
                    Name = "btnFirmar",
                    HeaderText = "Firma",
                    Text = "Mecánico",
                    UseColumnTextForButtonValue = true
                };
                dataGridViewTareas.Columns.Add(btnMec);
            }

            if (!dataGridViewTareas.Columns.Contains("btnCertificar") && requiereFirmaInspector)
            {
                var btnIns = new DataGridViewButtonColumn
                {
                    Name = "btnCertificar",
                    HeaderText = "Certifica",
                    Text = "Inspector",
                    UseColumnTextForButtonValue = true
                };
                dataGridViewTareas.Columns.Add(btnIns);
            }

            foreach (DataGridViewRow row in dataGridViewTareas.Rows)
            {
                string tareaStr = row.Cells["Tareas"].Value?.ToString() ?? "";

                if (tareaStr.Contains("Mec:") && dataGridViewTareas.Columns.Contains("btnFirmar"))
                {
                    var nro = tareaStr.Split(new[] { "Mec:" }, StringSplitOptions.None).Skip(1).FirstOrDefault()?.Split('|')[0]?.Trim();
                    if (!string.IsNullOrEmpty(nro))
                    {
                        row.Cells["btnFirmar"] = new DataGridViewTextBoxCell { Value = $"[{nro}]" };
                        row.Cells["btnFirmar"].ReadOnly = true;
                    }
                }

                if (tareaStr.Contains("Ins:") && dataGridViewTareas.Columns.Contains("btnCertificar"))
                {
                    var nro = tareaStr.Split(new[] { "Ins:" }, StringSplitOptions.None).Skip(1).FirstOrDefault()?.Split('|')[0]?.Trim();
                    row.Cells["btnCertificar"] = new DataGridViewTextBoxCell { Value = $"[{nro}]" };
                    row.Cells["btnCertificar"].ReadOnly = true;
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
                    var permisos = UsuarioBLL.ObtenerPermisosEfectivos(usuario);

                    if (permisos.Any(p => p.nombre == "Firmar Tarea")) // o si  rol == "Mecánico"
                    {
                        var tareaNombre = grid.Rows[e.RowIndex].Cells["Tarea"].Value?.ToString();
                        //Actualizar la firma de la tarea. Reemplazar boton.
                        //AÑADIR NUMERO DE MECANICO (ROL = MECANICO = GENERA UN NRO DE MECANICO AL USUARIO)
                        grid.Rows[e.RowIndex].Cells["btnFirmar"].Value = $"{SesionUsuario.Instancia.UsuarioActual.nroMecanico}";
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
            var usuario = SesionUsuario.Instancia.UsuarioActual;
            var permisos = UsuarioBLL.ObtenerPermisosEfectivos(usuario);

            if (!permisos.Any(p =>
                p.nombre.Equals("Firmar_OT", StringComparison.OrdinalIgnoreCase)))
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
            var permisos = UsuarioBLL.ObtenerPermisosEfectivos(usuario);

            if (!permisos.Any(p =>
                p.nombre.Equals("Cerrar_OT", StringComparison.OrdinalIgnoreCase)))
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
        private void buttonCerrarOT_Click(object sender, EventArgs e)
        {
            if (ordenActual.trabajo.listaTareas.Any(t =>!t.Contains("Mec:") || !t.Contains("Ins:")))
            {
                MessageBox.Show("Faltan firmas en alguna tarea.","Atención", MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }

            // cierro la OT a nivel global
            CerrarOT(
                numeroOT: ordenActual.numeroOT,
                idMecanico: ordenActual.mecanico,
                idInspector: ordenActual.inspector
            );

            MessageBox.Show("Orden de trabajo completada.","Éxito", MessageBoxButtons.OK,MessageBoxIcon.Information);
            this.Close();
        }


        public void CerrarOT(string numeroOT, string idMecanico, string idInspector)
        {
            ordenActual.estado = "Completa";
            ordenActual.fechaCierre = DateTime.Now;
            ordenActual.mecanico = idMecanico;
            ordenActual.inspector = idInspector;

            var otBLL = new OrdenDeTrabajoBLL();
            otBLL.ActualizarOT(ordenActual); 
        }

        private void dataGridViewTareas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var grid = (DataGridView)sender;
            var colName = grid.Columns[e.ColumnIndex].Name;
            var usuario = SesionUsuario.Instancia.UsuarioActual;
            var permisos = UsuarioBLL.ObtenerPermisosEfectivos(usuario);

            var listaTareas = ordenActual.trabajo.listaTareas;

            int idx = e.RowIndex;
            string original = listaTareas[idx];

            if (colName == "btnFirmar")
            {
                if (!permisos.Any(p => p.nombre.Equals("Firmar_OT", StringComparison.OrdinalIgnoreCase)))
                {
                    MessageBox.Show("No tenés permiso de mecánico para firmar.","Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string tagMec = $"Mec:{usuario.nroMecanico}";
                if (!original.Contains(tagMec))
                {
                    original += $" | {tagMec}";
                    listaTareas[idx] = original;
                    grid.Rows[idx].Cells["Tareas"].Value = original;

                    grid.Rows[idx].Cells["btnFirmar"] = new DataGridViewTextBoxCell
                    {
                        Value = $"[{usuario.nroMecanico}]"
                    };
                }
            }
            else if (colName == "btnCertificar")
            {
                if (!permisos.Any(p => p.nombre.Equals("Cerrar_OT", StringComparison.OrdinalIgnoreCase)))
                {
                    MessageBox.Show("No tenés permiso de inspector para certificar.","Acceso denegado", MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    return;
                }

                string tagIns = $"Ins:{usuario.nroInspector}";
                if (!original.Contains(tagIns))
                {
                    original += $" | {tagIns}";
                    listaTareas[idx] = original;
                    grid.Rows[idx].Cells["Tareas"].Value = original;

                    grid.Rows[idx].Cells["btnCertificar"] = new DataGridViewTextBoxCell
                    {
                        Value = $"[{usuario.nroInspector}]"
                    };
                }
            }
            else return;

            listaTareas[idx] = original;

            grid.Rows[idx].Cells["Tareas"].Value = original;
        }
    }
}
