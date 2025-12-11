using BE.Modelo;
using BLL.Roles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Servicios
{
    public class DashboardBLL
    {
        private readonly OrdenDeTrabajoBLL _otBll;
        private readonly HistorialEstadoBLL _historialBll;
        private readonly TrabajoBLL _trabajoBll;

        public DashboardBLL()
        {
            _otBll = new OrdenDeTrabajoBLL();
            _historialBll = new HistorialEstadoBLL();
            _trabajoBll = new TrabajoBLL();
        }

        public Dictionary<DateTime, int> ObtenerOtsCreadasPorDia(DateTime desde, DateTime hasta)
        {
            var ots = _otBll.ListarPorPeriodo(desde, hasta);
            return CalcularCreadasPorDia(ots, desde, hasta);
        }

        public Dictionary<DateTime, int> ObtenerOtsCerradasPorDia(DateTime desde, DateTime hasta)
        {
            var ots = _otBll.ListarPorPeriodo(desde, hasta);
            return CalcularCerradasPorDia(ots, desde, hasta);
        }

        private Dictionary<DateTime, int> CalcularCreadasPorDia(List<OrdenDeTrabajo> ots, DateTime desde, DateTime hasta)
        {
            var resultado = new Dictionary<DateTime, int>();

            for (var fecha = desde.Date; fecha <= hasta.Date; fecha = fecha.AddDays(1))
                resultado[fecha] = 0;

            foreach (var ot in ots)
            {
                var f = ot.fechaInicio.Date;
                if (resultado.ContainsKey(f))
                    resultado[f]++;
            }

            return resultado;
        }

        private Dictionary<DateTime, int> CalcularCerradasPorDia(List<OrdenDeTrabajo> ots, DateTime desde, DateTime hasta)
        {
            var resultado = new Dictionary<DateTime, int>();

            for (var fecha = desde.Date; fecha <= hasta.Date; fecha = fecha.AddDays(1))
                resultado[fecha] = 0;

            foreach (var ot in ots)
            {
                if (ot.fechaCierre == null) continue;

                var f = ot.fechaCierre.Date;
                if (resultado.ContainsKey(f))
                    resultado[f]++;
            }

            return resultado;
        }

        private double CalcularPromedioTareas(List<OrdenDeTrabajo> ots)
        {
            if (ots.Count == 0)
                return 0;

            double totalTareas = ots.Sum(o => o.listaTareasOT.Count);
            return totalTareas / ots.Count;
        }
    }
}
