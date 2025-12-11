using BE.Modelo;
using DAL;
using Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Servicios
{
    public class OrdenDeTrabajoBLL
    {
        private readonly MPPOrdenDeTrabajo mpp;

        public OrdenDeTrabajoBLL()
        {
            mpp = new MPPOrdenDeTrabajo();
        }

        public List<OrdenDeTrabajo> ListarOrdenes()
        {
            return mpp.ListarOrdenesDeTrabajo();
        }

        public void GenerarNuevaOT(OrdenDeTrabajo ot)
        {
            if(ot == null)
                throw new ArgumentNullException(nameof(ot), "La orden de trabajo no puede ser nula.");

            if (ot.aeronave == null)
                throw new ArgumentNullException(nameof(ot.aeronave), "Debe seleccionar una aeronave");

            if (ot.trabajo == null)
                throw new ArgumentNullException(nameof(ot.trabajo), "Debe seleccionar un trabajo");

            if (string.IsNullOrWhiteSpace(ot.titulo))
                throw new ArgumentException("El título de la OT es obligatorio.", nameof(ot.titulo));

            mpp.GuardarOrdenDeTrabajo(ot);
        }

        public OrdenDeTrabajo ObtenerPorNumero(string numeroOT)
        {
            return ListarOrdenes().FirstOrDefault(o => o.numeroOT == numeroOT);
        }

        public void ActualizarOT(OrdenDeTrabajo ot)
        {
            mpp.ActualizarOrdenDeTrabajo(ot);
        }

        public void EliminarOT(OrdenDeTrabajo ot)
        {
            if (ot == null) throw new ArgumentNullException(nameof(ot));

            var todas = ListarOrdenes();
            if (!todas.Any(o => o.numeroOT == ot.numeroOT))
                throw new InvalidOperationException($"No existe ninguna OT con número '{ot.numeroOT}'.");

            mpp.EliminarOrdenDeTrabajo(ot.numeroOT);
        }

        public List<OrdenDeTrabajo> ListarOtCerradas()
        {
            return ListarOrdenes()
                .Where(o => string.Equals(o.estado, "Completada", StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        public List<OrdenDeTrabajo> ListarPorPeriodo(DateTime desde, DateTime hasta)
        {
            return mpp.ListarPorPeriodo(desde, hasta);
        }
    }
}
