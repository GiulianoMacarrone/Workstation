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

namespace IU.Materiales
{
    public partial class ActualizarEstadoForm : Form
    {
        public event EventHandler EstadoActualizado;
        private readonly AeronaveBE aeronave;
        private readonly HistorialEstadoBLL historialEstado = new HistorialEstadoBLL();
        private readonly OrdenDeTrabajoBLL ordenDeTrabajoBLL = new OrdenDeTrabajoBLL();

        public ActualizarEstadoForm(AeronaveBE aeronaveSeleccionada)
        {
            InitializeComponent();
            aeronave = aeronaveSeleccionada;
            this.Text = $"Actualizar Estado de Aeronave - {aeronave.matricula}";
            InicializarForm();
        }

        private void InicializarForm()
        {
            textBoxEstadoActual.Text = aeronave.estadoActual.ToString();

            txtNuevoEstado.Items.Clear();
            txtNuevoEstado.Items.AddRange(Enum.GetNames(typeof(EstadoAeronave)));
            txtNuevoEstado.SelectedIndex = -1;

            dateTimePickerEstadoFecha.Value = DateTime.Now;

            var usuario = SesionUsuario.Instancia.UsuarioActual;
            labelUsuario.Text = $"Usuario Registrado: {usuario.username}";

            txtNuevoEstado.SelectedIndexChanged += cmbNuevoEstado_SelectedIndexChanged;

            txtMotivo.Visible = false;
            comboBoxOT.Visible = false;
        }

        private void cmbNuevoEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            string estado = txtNuevoEstado.SelectedItem?.ToString();

            if (estado == "FueraDeServicio")
            {
                txtMotivo.Visible = true;
                comboBoxOT.Visible = false;
            }
            else if (estado == "Serviciable")
            {
                txtMotivo.Visible = false;
                comboBoxOT.Visible = true;

                var ots = ordenDeTrabajoBLL.ListarOrdenes()
                    .Where(o => o.matricula == aeronave.matricula && !string.IsNullOrWhiteSpace(o.numeroOT))
                    .ToList();

                comboBoxOT.DataSource = ots;
                comboBoxOT.DisplayMember = "numeroOT";
                comboBoxOT.ValueMember = "numeroOT"; 
                comboBoxOT.SelectedIndex = -1;
            }

            else if (estado == "EnMantenimiento")
            {
                txtMotivo.Visible = true;
                comboBoxOT.Visible = true;
            }

            else
            {
                txtMotivo.Visible = false;
                comboBoxOT.Visible = false;
            }

        }

        private void buttonAceptarCambioEstado_Click(object sender, EventArgs e)
        {
            try
            {
                string nuevoEstado = txtNuevoEstado.SelectedItem?.ToString();
                DateTime fechaCambio = dateTimePickerEstadoFecha.Value;
                string motivo = txtMotivo.Text.Trim();
                string numeroOT = comboBoxOT.SelectedItem is OrdenDeTrabajo ot ? ot.numeroOT : "";

                if (string.IsNullOrWhiteSpace(nuevoEstado))
                    throw new Exception("Debe seleccionar un nuevo estado.");

                if (nuevoEstado == "FueraDeServicio" && string.IsNullOrWhiteSpace(motivo))
                    throw new Exception("Debe ingresar un motivo para Fuera de Servicio.");

                if (nuevoEstado == "Serviciable" && string.IsNullOrWhiteSpace(numeroOT))
                    throw new Exception("Debe seleccionar una Orden de Trabajo para Serviciable.");

                EstadoAeronave estadoEnum = (EstadoAeronave)Enum.Parse(typeof(EstadoAeronave), nuevoEstado);

                var usuario = SesionUsuario.Instancia.UsuarioActual;

                historialEstado.RegistrarCambioEstado(
                    aeronave,
                    estadoEnum,
                    fechaCambio,
                    motivo,
                    numeroOT,
                    usuario.username
                );

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
