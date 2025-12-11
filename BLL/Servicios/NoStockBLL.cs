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
    public class NoStockBLL
    {
        private readonly MPPNoStock mpp = new MPPNoStock();
        public void ActualizarEstado(NoStockBE pedido)
        {
            mpp.ActualizarNoStock(pedido);
        }

        public void AsociarNoStockADiferido(int idDiferido, int idNoStock)
        {
            mpp.AsociarNoStockADiferido(idDiferido, idNoStock);
        }

        public void CrearNoStock(NoStockBE noStock)
        {
            if (noStock == null)
                throw new ArgumentNullException(nameof(noStock));

            if (noStock.numero <= 0)
                throw new ArgumentException(
                    "El número de NoStock debe ser mayor que cero.",
                    nameof(noStock.numero));

            if (string.IsNullOrWhiteSpace(noStock.descripcion))
                throw new ArgumentException(
                    "La descripción es obligatoria.",
                    nameof(noStock.descripcion));

            if (string.IsNullOrWhiteSpace(noStock.dmiUOt))
                throw new ArgumentException(
                    "Debe indicar el DMI u OT asociado.",
                    nameof(noStock.dmiUOt));

            if (string.IsNullOrWhiteSpace(noStock.criticidad))
                throw new ArgumentException(
                    "La criticidad es obligatoria.",
                    nameof(noStock.criticidad));

            if (string.IsNullOrWhiteSpace(noStock.aeronave))
                throw new ArgumentException(
                    "Debe indicar la aeronave.",
                    nameof(noStock.aeronave));

            if (string.IsNullOrWhiteSpace(noStock.partNumber))
                throw new ArgumentException(
                    "El Part Number es obligatorio.",
                    nameof(noStock.partNumber));

            noStock.estado = false;

            mpp.GuardarNoStock(noStock);
        }

        public List<NoStockBE> ListarNoStocks()
        {
            return mpp.ListarNoStocks();
        }


    }
}
