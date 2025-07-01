using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE.Modelo;

namespace BLL
{
    public class DiferidoBLL
    {
        public string GetNombreDMI(Diferido dmi)
        {
            return $"DMI-{dmi.aeronave}-{dmi.numero}"; // Formato de nombre del DMI: "DMI-MAT-401"
        }

        public string GetNombreDMI(int numero, string aeronave)
        {
            return $"DMI-{aeronave}-{numero}"; // Formato de nombre del DMI: "DMI-MAT-401"
        }
    }
}
