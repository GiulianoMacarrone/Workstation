using BE.Composite;
using BE.Modelo;
using DAL;
using Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Roles
{
    public class TrabajoBLL
    {
        private readonly MPPTrabajo _mppTrabajo = new MPPTrabajo();
        private readonly MPPOrdenDeTrabajo _mppOrdenDeTrabajo = new MPPOrdenDeTrabajo();

        public void CrearTrabajo(TrabajoBE nuevoTrabajo)
        {

            if (nuevoTrabajo == null)
            {
                throw new ArgumentNullException(nameof(nuevoTrabajo), "El trabajo no puede ser nulo.");
            }

            if (string.IsNullOrWhiteSpace(nuevoTrabajo.titulo))
            {
                throw new ArgumentException("El título del trabajo es obligatorio.", nameof(nuevoTrabajo.titulo));
            }

            if (string.IsNullOrWhiteSpace(nuevoTrabajo.descripcion))
            {
                throw new ArgumentException("La descripción del trabajo es obligatoria.", nameof(nuevoTrabajo.descripcion));
            }

            int nuevoNroTr = ListarTrabajos().Select(t => int.TryParse(t.nroTrabajo?.Replace("TR-", ""), out var m) ? m : 0).DefaultIfEmpty().Max() + 1;
            string nroTrabajo = "TR-" + nuevoNroTr.ToString("D4");
            nuevoTrabajo.nroTrabajo = nroTrabajo;

            _mppTrabajo.GuardarTrabajo(nuevoTrabajo);
        }

        public void EliminarTrabajo(int idTrabajo)
        {
            var listaTrabajos = _mppTrabajo.ListarTrabajos();
            if (!listaTrabajos.Any(t => t.id == idTrabajo))
            {
                throw new InvalidOperationException($"Trabajo #{idTrabajo} no encontrado.");
            }

            var listaOTs = _mppOrdenDeTrabajo.ListarOrdenesDeTrabajo();
            bool trabajoEnUso = listaOTs.Any(ot => ot.trabajo != null && ot.trabajo.id == idTrabajo);

            if (trabajoEnUso)
            {
                throw new InvalidOperationException($"No se puede eliminar el trabajo #{idTrabajo} porque está asociado a una orden de trabajo.");
            }

            _mppTrabajo.EliminarTrabajo(idTrabajo);
        }

        public List<TrabajoBE> ListarTrabajos()
        {
            return _mppTrabajo.ListarTrabajos();
        }
    }
}
