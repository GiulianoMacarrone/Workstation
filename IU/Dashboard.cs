using BE.Composite;
using BE.Modelo;
using BLL.Exportador;
using BLL.Servicios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace IU
{
    public partial class Dashboard : Form
    {
        private readonly OrdenDeTrabajoBLL _otBll = new OrdenDeTrabajoBLL();
        private readonly UsuarioBE usuarioActual = SesionUsuario.Instancia.UsuarioActual;
        public Dashboard()
        {
            InitializeComponent();
            lblUsername.Text = usuarioActual.username;
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            chart.Series.Clear();
            chart.ChartAreas.Clear();

            var area = new ChartArea("MainArea");
            chart.ChartAreas.Add(area);

            var seriesCreadas = new Series("Creadas")
            {
                ChartType = SeriesChartType.Column,
                ChartArea = "MainArea",
                XValueType = ChartValueType.String
            };
            chart.Series.Add(seriesCreadas);

            var seriesCompletadas = new Series("Completadas")
            {
                ChartType = SeriesChartType.Column,
                ChartArea = "MainArea",
                XValueType = ChartValueType.String
            };
            chart.Series.Add(seriesCompletadas);

            var desde = dtpDesde.Value.Date;
            var hasta = dtpHasta.Value.Date.AddDays(1).AddTicks(-1);
            dgvRealizadas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRealizadas.MultiSelect = false;
            CargarDashboard(desde, hasta);
        }

        private void CargarDashboard(DateTime desde, DateTime hasta)
        {
            var all = _otBll.ListarOrdenes();
            var periodo = all.Where(o => o.fechaInicio >= desde && o.fechaInicio <= hasta).ToList();

            bool esInspector = !string.IsNullOrWhiteSpace(usuarioActual.nroInspector);
            bool esMecanico = !string.IsNullOrWhiteSpace(usuarioActual.nroMecanico);

            if (esInspector)
            {
                dgvDisponibles.DataSource = periodo.Where(o => string.IsNullOrWhiteSpace(o.inspector)).ToList();
                dgvRealizadas.DataSource = periodo.Where(o => !string.IsNullOrWhiteSpace(o.inspector) && o.inspector == usuarioActual.nroInspector).ToList();
            }
            else if (esMecanico)
            {
                dgvDisponibles.DataSource = periodo.Where(o => string.IsNullOrWhiteSpace(o.mecanico)).ToList();
                dgvRealizadas.DataSource = periodo.Where(o => !string.IsNullOrWhiteSpace(o.mecanico) && o.mecanico == usuarioActual.nroMecanico).ToList();
            }

            txtTotalOTs.Text = periodo.Count.ToString();
            txtTotalPendientes.Text = dgvDisponibles.Rows.Count.ToString();
            txtTotalRealizadas.Text = dgvRealizadas.Rows.Count.ToString();

            if (dgvRealizadas.Rows.Count > 0)
            {
                var realizadas = ((System.Collections.IEnumerable)dgvRealizadas.DataSource).Cast<OrdenDeTrabajo>().ToList();

                double promTareas = realizadas.Average(o => o.trabajo.listaTareas.Count);
                txtPromedioTareas.Text = $"{promTareas:F1}";
            }
            else
            {
                txtPromedioTareas.Text = "0";
            }

            FillChart(periodo, desde, hasta);
            FillPieChart(periodo, desde, hasta);
            FillBubbleChart(periodo, desde, hasta);
            FillChartCierrePromedio(periodo, desde, hasta);
        }

        private void buttonCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        #region Filtrar Fechas
        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            var desde = dtpDesde.Value.Date;
            var hasta = dtpHasta.Value.Date.AddDays(1).AddTicks(-1);
            CargarDashboard(desde, hasta);
        }
        private void buttonHoy_Click(object sender, EventArgs e)
        {
            var hoy = DateTime.Today;
            dtpDesde.Value = hoy;
            dtpHasta.Value = hoy;
            CargarDashboard(hoy, hoy.AddDays(1).AddTicks(-1));
        }

        private void button30dias_Click(object sender, EventArgs e)
        {
            var hasta = DateTime.Today;
            var desde = hasta.AddDays(-29);
            dtpDesde.Value = desde;
            dtpHasta.Value = hasta;
            CargarDashboard(desde, hasta.AddDays(1).AddTicks(-1));
        }

        private void button7dias_Click(object sender, EventArgs e)
        {
            var hasta = DateTime.Today;
            var desde = hasta.AddDays(-6);
            dtpDesde.Value = desde;
            dtpHasta.Value = hasta;
            CargarDashboard(desde, hasta.AddDays(1).AddTicks(-1));
        }
        #endregion

        #region constructor chart
        private void FillChart(List<OrdenDeTrabajo> lista, DateTime desde, DateTime hasta)
        {
            var dias = Enumerable.Range(0, (hasta.Date - desde.Date).Days + 1).Select(i => desde.Date.AddDays(i)).ToList();

            var seriesCreadas = chart.Series["Creadas"];
            var seriesCompletadas = chart.Series["Completadas"];
            seriesCreadas.Points.Clear();
            seriesCompletadas.Points.Clear();

            foreach (var d in dias)
            {
                int creadas = lista.Count(o => o.fechaInicio.Date == d);
                int cerradas = lista.Count(o => o.fechaCierre.Date == d);
                seriesCreadas.Points.AddXY(d.ToString("dd/MM"), creadas);
                seriesCompletadas.Points.AddXY(d.ToString("dd/MM"), cerradas);
            }

            chart.ChartAreas[0].AxisX.Interval = 1;
            chart.ChartAreas[0].AxisX.LabelStyle.Angle = -45;
        }

        private void dgvDisponibles_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var ot = (OrdenDeTrabajo)dgvDisponibles.Rows[e.RowIndex].DataBoundItem;

            var verOT = new OrdenDeTrabajoForm(ot)
            {
                MdiParent = this.MdiParent
            };
            verOT.Show();
        }

        private void printButton_Click(object sender, EventArgs e)
        {
            var exportador = new ExportadorPDF();

            var ot = (OrdenDeTrabajo)dgvRealizadas.SelectedRows[0].DataBoundItem;

            if (dgvRealizadas.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccioná una orden realizada para imprimir.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (var dialog = new SaveFileDialog())
            {
                dialog.Title = "Guardar Orden de Trabajo";
                dialog.Filter = "Archivo PDF (*.pdf)|*.pdf";
                dialog.FileName = $"Orden_{ot.numeroOT}.pdf";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        exportador.ImprimirOrdenDeTrabajo(ot, dialog.FileName);
                        MessageBox.Show("Orden exportada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        System.Diagnostics.Process.Start(dialog.FileName);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al exportar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void FillPieChart(List<OrdenDeTrabajo> periodo, DateTime desde, DateTime hasta)
        {
            chartCumplimiento.Series.Clear();
            chartCumplimiento.ChartAreas.Clear();
            chartCumplimiento.Legends.Clear();

            var area = new ChartArea("Area");
            chartCumplimiento.ChartAreas.Add(area);
            chartCumplimiento.Legends.Add(new Legend("Leyenda")
            {
                Docking = Docking.Right,
                LegendStyle = LegendStyle.Table
            });

            int totalCreadas = periodo.Count;
            int totalCompletadas = periodo.Count(o => o.fechaCierre >= desde && o.fechaCierre <= hasta);
            int totalPendientes = totalCreadas - totalCompletadas;

            var serie = new Series("Cumplimiento")
            {
                ChartType = SeriesChartType.Pie,
                ChartArea = "Area",
                Label = "#PERCENT{P1}",
                LegendText = "#VALX",
                Font = new Font("Segoe UI", 9f)
            };

            serie.Points.AddXY("Completadas", totalCompletadas);
            serie.Points.AddXY("Pendientes", totalPendientes);

            serie.Points[0].Color = Color.SeaGreen;
            serie.Points[1].Color = Color.LightGray;
            serie.Points[0]["Exploded"] = "true";

            chartCumplimiento.Series.Add(serie);
            chartCumplimiento.Invalidate();
        }

        private void FillBubbleChart(List<OrdenDeTrabajo> periodo, DateTime desde, DateTime hasta)
        {
            chartHeatMap.Series.Clear();
            chartHeatMap.ChartAreas.Clear();

            var area = new ChartArea("Heat")
            {
                AxisX = { Minimum = 0, Maximum = 23, Interval = 1, Title = "Hora del día" },
                AxisY = { Minimum = 0, Maximum = 6, Interval = 1, Title = "Día de la semana" }
            };
            string[] dias = { "Dom", "Lun", "Mar", "Mié", "Jue", "Vie", "Sáb" };
            for (int i = 0; i < 7; i++)
            {
                area.AxisY.CustomLabels.Add(new CustomLabel(i - .5, i + .5, dias[i], 0, LabelMarkStyle.None));
            }
                
            chartHeatMap.ChartAreas.Add(area);

            var s = new Series("Carga")
            {
                ChartType = SeriesChartType.Bubble,
                ChartArea = "Heat",
                XValueType = ChartValueType.Int32,
                YValueType = ChartValueType.Int32,
                MarkerStyle = MarkerStyle.Circle,
                IsValueShownAsLabel = false
            };
            chartHeatMap.Series.Add(s);

            var datos = periodo.Where(o => o.fechaInicio >= desde && o.fechaInicio <= hasta).GroupBy(o => new { Day = (int)o.fechaInicio.DayOfWeek, Hour = o.fechaInicio.Hour }).Select(g => new { g.Key.Day, g.Key.Hour, Count = g.Count() }).ToList();

            int max = datos.Any() ? datos.Max(d => d.Count) : 1;

            foreach (var cell in datos)
            {
                int idx = s.Points.AddXY(cell.Hour, cell.Day, cell.Count);
                int intensity = (int)(255 * cell.Count / (double)max);
                s.Points[idx].Color = Color.FromArgb(255, 255 - intensity, 255 - intensity);
            }
        }

        private void FillChartCierrePromedio(List<OrdenDeTrabajo> periodo, DateTime desde, DateTime hasta)
        {
            chartPromedioCierreTareas.Series.Clear();
            chartPromedioCierreTareas.ChartAreas.Clear();

            var area = new ChartArea("Area Principal");
            area.AxisX.LabelStyle.Format = "dd/MM";
            area.AxisX.Interval = 1;
            area.AxisX.LabelStyle.Angle = -45;
            area.AxisY.Title = "Horas promedio";
            chartPromedioCierreTareas.ChartAreas.Add(area);

            var serie = new Series("CierrePromedio")
            {
                ChartType = SeriesChartType.Spline,
                ChartArea = "Area Principal",
                XValueType = ChartValueType.DateTime,
                BorderWidth = 3,
                MarkerStyle = MarkerStyle.Circle,
                MarkerSize = 5,
                ToolTip = "#VALY{N1}h"
            };
            chartPromedioCierreTareas.Series.Add(serie);

            var dias = Enumerable.Range(0, (hasta.Date - desde.Date).Days + 1).Select(i => desde.Date.AddDays(i));
            foreach (var dia in dias)
            {
                var cerradas = periodo.Where(o => o.fechaCierre.Date == dia);
                if (!cerradas.Any()) continue;
                double promedio = cerradas.Average(o => (o.fechaCierre - o.fechaInicio).TotalHours);
                serie.Points.AddXY(dia, promedio);
            }
        }
        #endregion
    }
}

