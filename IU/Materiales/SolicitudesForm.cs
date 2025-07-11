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
        private readonly NoStockBLL noStockBLL = new NoStockBLL();
        private List<NoStockBE> listaNoStocks;

        public SolicitudesForm()
        {
            InitializeComponent();
        }

        private void SolicitudesForm_Load(object sender, EventArgs e)
        {
            CargarNoStocks();
        }

        private void CargarNoStocks()
        {
            listaNoStocks = noStockBLL.ListarNoStocks();

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

            dataGridViewNoStock.DataSource = listaNoStocks;
            dataGridViewNoStock.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void bttnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridViewNoStock_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dataGridViewNoStock.IsCurrentCellDirty)
            {
                dataGridViewNoStock.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void dataGridViewNoStock_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            var grid = (DataGridView)sender;
            var colName = grid.Columns[e.ColumnIndex].DataPropertyName;

            if (colName == "estado")
            {
                var pedido = (NoStockBE)grid.Rows[e.RowIndex].DataBoundItem;
                if (pedido != null)
                {
                    try
                    {
                        noStockBLL.ActualizarEstado(pedido);
                        MessageBox.Show("Estado actualizado correctamente.", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al guardar el estado: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
