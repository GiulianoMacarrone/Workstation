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
    public class HerramientaBLL
    {
        MPPHerramienta mpp = new MPPHerramienta();
        public void GuardarHerramienta(HerramientaBE herramienta)
        {
            mpp.GuardarHerramienta(herramienta);
        }

        public List<HerramientaBE> ListarHerramientas()
        {
            return mpp.ListarHerramientas();
        }

    }
}
