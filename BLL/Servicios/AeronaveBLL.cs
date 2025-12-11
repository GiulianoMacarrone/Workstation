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
    public class AeronaveBLL
    {
        private readonly MPPAeronave mpp = new MPPAeronave();
        public void GuardarAeronave(AeronaveBE aeronave)
        {
            GenerarIDUnico();
            mpp.GuardarAeronave(aeronave);
        }

        public void ActualizarAeronave(AeronaveBE aeronave)
        {
            mpp.ActualizarAeronave(aeronave);
        }

        private string GenerarIDUnico()
        {
            var aeronaves = ListarAeronaves();
            if (aeronaves != null && aeronaves.Count > 0)
            {
                int maxId = aeronaves
                    .Select(a =>
                    {
                        int idNum;
                        return int.TryParse(a.id, out idNum) ? idNum : 0;
                    })
                    .DefaultIfEmpty(0).Max();
                return (maxId + 1).ToString();
            }
            else
            {
                return "1";
            }
        }

        public List<AeronaveBE> ListarAeronaves()
        {
            return mpp.ListarAeronaves();
        }
    }
}
