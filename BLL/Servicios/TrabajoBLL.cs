using BE.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Roles
{
    public class TrabajoBLL
    {
        // Pseudocódigo:
        // 1. Validar que el objeto nuevoTrabajo no sea nulo.
        // 2. Validar campos obligatorios (ej: titulo, descripcion, nroTrabajo).
        // 3. (Opcional) Validar unicidad de nroTrabajo si corresponde.
        // 4. Llamar a la capa DAL para persistir el objeto (no implementado aquí).
        // 5. Lanzar excepciones o retornar según resultado.

        public void CrearTrabajo(TrabajoBE nuevoTrabajo)
        {
            if (nuevoTrabajo == null)
                throw new ArgumentNullException(nameof(nuevoTrabajo), "El trabajo no puede ser nulo.");

            if (string.IsNullOrWhiteSpace(nuevoTrabajo.titulo))
                throw new ArgumentException("El título del trabajo es obligatorio.", nameof(nuevoTrabajo.titulo));

            if (string.IsNullOrWhiteSpace(nuevoTrabajo.descripcion))
                throw new ArgumentException("La descripción del trabajo es obligatoria.", nameof(nuevoTrabajo.descripcion));

            if (nuevoTrabajo.nroTrabajo <= 0)
                throw new ArgumentException("El número de trabajo debe ser mayor a cero.", nameof(nuevoTrabajo.nroTrabajo));

            // Aquí iría la lógica para verificar unicidad de nroTrabajo, si aplica.
            // Ejemplo: if (TrabajoDAL.ExisteNroTrabajo(nuevoTrabajo.nroTrabajo)) throw new Exception(...);

            // Aquí se llamaría a la capa DAL para guardar el trabajo.
            // Ejemplo: TrabajoDAL.CrearTrabajo(nuevoTrabajo);
            // Como no hay DAL implementado, se deja como comentario.

            // throw new NotImplementedException("Persistencia no implementada.");
        }
    }
}
