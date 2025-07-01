using BE.Modelo;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Roles
{
    public class TrabajoBLL
    {
        public void CrearTrabajo(TrabajoBE nuevoTrabajo)
        {
            if (nuevoTrabajo == null)
                throw new ArgumentNullException(nameof(nuevoTrabajo), "El trabajo no puede ser nulo.");

            if (string.IsNullOrWhiteSpace(nuevoTrabajo.titulo))
                throw new ArgumentException("El título del trabajo es obligatorio.", nameof(nuevoTrabajo.titulo));

            if (string.IsNullOrWhiteSpace(nuevoTrabajo.descripcion))
                throw new ArgumentException("La descripción del trabajo es obligatoria.", nameof(nuevoTrabajo.descripcion));

            DatosDAL.GuardarTrabajo(nuevoTrabajo);

        }
    }
}
