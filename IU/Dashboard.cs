using BE.Composite;
using BE.Modelo;
using BLL.Servicios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

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
            chart1.Series.Clear();
            chart1.ChartAreas.Clear();

            var area = new ChartArea("MainArea");
            chart1.ChartAreas.Add(area);

            var seriesCreadas = new Series("Creadas")
            {
                ChartType = SeriesChartType.Column,
                ChartArea = "MainArea",
                XValueType = ChartValueType.String
            };
            chart1.Series.Add(seriesCreadas);

            var seriesCompletadas = new Series("Completadas")
            {
                ChartType = SeriesChartType.Column,
                ChartArea = "MainArea",
                XValueType = ChartValueType.String
            };
            chart1.Series.Add(seriesCompletadas);

            var desde = dtpDesde.Value.Date;
            var hasta = dtpHasta.Value.Date.AddDays(1).AddTicks(-1);
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
        private void FillChart(System.Collections.Generic.List<OrdenDeTrabajo> lista, DateTime desde, DateTime hasta)
        {
            var dias = Enumerable.Range(0, (hasta.Date - desde.Date).Days + 1)
                .Select(i => desde.Date.AddDays(i)).ToList();

            var sCreadas = chart1.Series["Creadas"];
            var sCompletadas = chart1.Series["Completadas"];
            sCreadas.Points.Clear();
            sCompletadas.Points.Clear();

            foreach (var d in dias)
            {
                int creadas = lista.Count(o => o.fechaInicio.Date == d);
                int cerradas = lista.Count(o => o.fechaCierre.Date == d);
                sCreadas.Points.AddXY(d.ToString("dd/MM"), creadas);
                sCompletadas.Points.AddXY(d.ToString("dd/MM"), cerradas);
            }

            chart1.ChartAreas[0].AxisX.Interval = 1;
            chart1.ChartAreas[0].AxisX.LabelStyle.Angle = -45;
        }
        #endregion

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
    }
}

