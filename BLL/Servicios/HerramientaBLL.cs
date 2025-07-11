using BE.Modelo;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Servicios
{
    public class HerramientaBLL
    {
        public void GuardarHerramienta(HerramientaBE herramienta)
        {
            DatosDAL.GuardarHerramienta(herramienta);
        }
        public List<HerramientaBE> ListarHerramientas()
        {
            return DatosDAL.ListarHerramientas();
        }

    }
}
