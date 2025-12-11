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
    public class HistorialEstadoBLL
    {
        private readonly MPPHistorialEstado mpp = new MPPHistorialEstado();
        private readonly MPPAeronave _mppAeronave = new MPPAeronave();
        public List<HistorialEstadoBE> ListarHistorial()
        {
            return mpp.GetAll();
        }

        public List<HistorialEstadoBE> ListarPorAeronave(string aeronaveId)
        {
            return mpp.GetAll().Where(h => h.aeronaveId == aeronaveId).ToList();
        }

        public List<HistorialEstadoBE> FiltrarHistorialPorFechas(DateTime desde, DateTime hasta)
        {
            var lista = ListarHistorial();

            return lista
                .Where(h => h.fechaEstado >= desde && h.fechaEstado <= hasta)
                .OrderBy(h => h.fechaEstado)
                .ToList();
        }

        public bool RegistrarCambioEstado(AeronaveBE aeronave, EstadoAeronave nuevoEstado, DateTime fechaEstado, string motivo, string numeroOT, string usuario)
        {
            if (nuevoEstado == EstadoAeronave.FueraDeServicio && string.IsNullOrWhiteSpace(motivo))
                throw new Exception("Debe indicar un motivo para pasar la aeronave a Fuera de Servicio.");

            if (nuevoEstado == EstadoAeronave.Serviciable && string.IsNullOrWhiteSpace(numeroOT))
                throw new Exception("Debe seleccionar una OT para justificar el cambio a Serviciable.");

            var historial = new HistorialEstadoBE
            {
                aeronaveId = aeronave.id,
                marca = aeronave.marca,
                modelo = aeronave.modelo,
                matricula = aeronave.matricula,
                estadoRegistrado = nuevoEstado,
                fechaEstado = fechaEstado,
                motivo = nuevoEstado == EstadoAeronave.FueraDeServicio ? motivo : null,
                numeroOT = nuevoEstado == EstadoAeronave.Serviciable ? numeroOT : null,
                registradoPor = usuario
            };

            var resultado = mpp.Guardar(historial);

            aeronave.estadoActual = nuevoEstado;
            _mppAeronave.ActualizarAeronave(aeronave);

            return resultado;
        }
    }
}
