using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE.Modelo;
using DAL;

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

        public List<Diferido> ListarDiferidosPorMatricula(string matricula)
        {
            if (string.IsNullOrWhiteSpace(matricula))return new List<Diferido>();

            return DatosDAL.ListarDiferidos().Where(d => d.aeronave.Equals(matricula, StringComparison.OrdinalIgnoreCase) && d.estado == false).ToList(); //false = abierto
        }

        public void CerrarDiferido(int idDiferido)
        {
            var dmi = DatosDAL.ListarDiferidos().FirstOrDefault(d => d.id == idDiferido);
            if (dmi == null) throw new InvalidOperationException($"No existe el diferido {idDiferido}.");

            dmi.estado = true;
            dmi.fechaCierre = DateTime.Now;

            DatosDAL.ActualizarDiferido(dmi);
        }

        public void AbrirDiferido(Diferido dmi)
        {
            DatosDAL.GuardarDiferido(dmi);
        }

        public object ListarDmiAbiertos()
        {
            return DatosDAL.ListarDiferidos().Where(d => !d.estado).ToList();
        }
    }
}
