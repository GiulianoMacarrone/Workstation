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
    }

}
