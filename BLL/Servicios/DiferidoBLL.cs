using BE.Modelo;
using BLL.Servicios;
using DAL;
using Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class DiferidoBLL
    {
        private readonly MPPDiferido mpp = new MPPDiferido();
        private readonly MPPNoStock _mppNoStock = new MPPNoStock();

        public List<Diferido> ListarDiferidosPorMatricula(string matricula)
        {
            if (string.IsNullOrWhiteSpace(matricula))return new List<Diferido>();

            return mpp.ListarDiferidos().Where(d => d.aeronave.Equals(matricula, StringComparison.OrdinalIgnoreCase) && d.estado == false).ToList(); //false = abierto
        }

        public void CerrarDiferido(int idDiferido)
        {
            var dmi = mpp.ListarDiferidos().FirstOrDefault(d => d.id == idDiferido);
            if (dmi == null) throw new InvalidOperationException($"No existe el diferido {idDiferido}.");

            dmi.estado = true;
            dmi.fechaCierre = DateTime.Now;

            mpp.ActualizarDiferido(dmi);
        }

        public void AbrirDiferido(Diferido dmi)
        {
            mpp.GuardarDiferido(dmi);
        }

        public object ListarDmiAbiertos()
        {
            return mpp.ListarDiferidos().Where(d => !d.estado).ToList();
        }

        public NoStockBE ListarNoStocks(int id)
        {
            return _mppNoStock.ListarNoStocks().FirstOrDefault(ns => ns.id == id);
        }
    }
}
