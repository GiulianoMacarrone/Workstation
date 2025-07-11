using BE.Modelo;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Servicios
{
    public class OrdenDeTrabajoBLL
    {
        public List<OrdenDeTrabajo> ListarOrdenes()
        {
            return DatosDAL.ListarOrdenesDeTrabajo(); 
        }

        public void GenerarNuevaOT(OrdenDeTrabajo ot)
        {
            DatosDAL.GuardarOrdenDeTrabajo(ot);
        }

        public OrdenDeTrabajo ObtenerPorNumero(string numeroOT)
        {
            return ListarOrdenes().FirstOrDefault(o => o.numeroOT == numeroOT);
        }

        public void ActualizarOT(OrdenDeTrabajo ot)
        {
            DatosDAL.ActualizarOrdenDeTrabajo(ot);
        }

        public void EliminarOT(OrdenDeTrabajo ot)
        {
            if (ot == null) throw new ArgumentNullException(nameof(ot));

            var todas = ListarOrdenes();
            if (!todas.Any(o => o.numeroOT == ot.numeroOT)) throw new InvalidOperationException($"No existe ninguna OT con número '{ot.numeroOT}'.");

            DatosDAL.EliminarOrdenDeTrabajo(ot.numeroOT);
        }

        public List<OrdenDeTrabajo> ListarOtCerradas()
        {
            return ListarOrdenes().Where(o =>string.Equals(o.estado, "Completada", StringComparison.OrdinalIgnoreCase)).ToList();
        }

    }

}
