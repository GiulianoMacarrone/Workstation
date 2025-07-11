using BE.Modelo;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Servicios
{
    public class AeronaveBLL
    {
        public void GuardarAeronave(AeronaveBE aeronave)
        {
            GenerarIDUnico();
            DatosDAL.GuardarAeronave(aeronave);
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
            return DatosDAL.ListarAeronaves();
        }
    }
}
