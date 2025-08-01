using System;
using System.Windows.Forms;
using BLL.Servicios;
using BE.Backup;

namespace IU
{
    public partial class BackupForm : Form
    {
        private readonly BackupBLL backupBll = new BackupBLL();

        public BackupForm()
        {
            InitializeComponent();
        }

        private void BackupForm_Load(object sender, EventArgs e)
        {
            CargarEventos();
        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
            try
            {
                backupBll.RealizarBackup();
                MessageBox.Show("Backup completado", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarEventos();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error en backup: {ex.Message}", "Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            var fila = dgvEventos.CurrentRow;
            if (fila == null) return;

            var ev = (Backup)fila.DataBoundItem;

            //evito que se pueda restaurar un restore
            if (ev.Operacion.Equals("Restore", StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("Este evento ya es resultado de una restauración previa.\nRestaurá un Backup original para mantener la trazabilidad del sistema.","Restore no permitido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirmar = MessageBox.Show($"¿Restaurar desde: {ev.ArchivoPath}?","Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmar != DialogResult.Yes) return;

            try
            {
                backupBll.RestaurarBackup(ev.ArchivoPath);
                MessageBox.Show("Restore completado", "Éxito",MessageBoxButtons.OK, MessageBoxIcon.Information);
                Application.Restart(); //reinicio la aplicación para aplicar los cambios
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error en restore: {ex.Message}", "Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarEventos()
        {
            var lista = backupBll.ListarEventos();
            dgvEventos.AutoGenerateColumns = false;
            dgvEventos.Columns.Clear();

            dgvEventos.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Id",
                HeaderText = "ID"
            });
            dgvEventos.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Fecha",
                HeaderText = "Fecha"
            });
            dgvEventos.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Operacion",
                HeaderText = "Operación"
            });
            dgvEventos.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Usuario",
                HeaderText = "Usuario"
            });
            dgvEventos.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "ArchivoPath",
                HeaderText = "Archivo .ZIP",
                Width = 300
            });

            dgvEventos.DataSource = lista;
            dgvEventos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
    }
}