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
    public partial class SolicitudesForm : Form
    {
        private readonly NoStockBLL _noStockBLL = new NoStockBLL();
        private List<NoStockBE> _listaNoStocks;

        public SolicitudesForm()
        {
            InitializeComponent();

            this.Load += SolicitudesForm_Load;
            btnCerrar.Click += bttnCerrar_Click;
        }

        private void SolicitudesForm_Load(object sender, EventArgs e)
        {
            CargarNoStocks();
        }

        private void CargarNoStocks()
        {
            _listaNoStocks = _noStockBLL.ListarNoStocks();

            dataGridViewNoStock.AutoGenerateColumns = false;
            dataGridViewNoStock.Columns.Clear();

            dataGridViewNoStock.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "numero",
                HeaderText = "N° Pedido"
            });

            dataGridViewNoStock.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "descripcion",
                HeaderText = "Descripción"
            });

            dataGridViewNoStock.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "dmiUOt",
                HeaderText = "DMI/OT"
            });

            dataGridViewNoStock.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "criticidad",
                HeaderText = "Criticidad"
            });

            dataGridViewNoStock.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "aeronave",
                HeaderText = "Aeronave"
            });

            dataGridViewNoStock.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "partNumber",
                HeaderText = "Part Number"
            });

            dataGridViewNoStock.Columns.Add(new DataGridViewCheckBoxColumn
            {
                DataPropertyName = "estado",
                HeaderText = "Completado"
            });

            dataGridViewNoStock.DataSource = _listaNoStocks;
            dataGridViewNoStock.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void bttnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
