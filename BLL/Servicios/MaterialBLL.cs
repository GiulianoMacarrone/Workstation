using BE.Modelo;
using DAL;
using DocumentFormat.OpenXml.Office2016.Drawing.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Servicios
{
    public class MaterialBLL
    {
        private readonly ConsumibleBLL consumibleBLL = new ConsumibleBLL();
        private readonly HerramientaBLL herramientaBLL = new HerramientaBLL();
        private readonly RotableBLL rotableBLL = new RotableBLL();

        public void EntregarElemento(ElementoVisualizable elemento,int cantidad,string idEmisor,string idReceptor)
        {
            if (elemento == null)
                throw new ArgumentNullException(nameof(elemento));

            if (cantidad < 1) throw new ArgumentException("La cantidad debe ser al menos 1.", nameof(cantidad));

            if (string.IsNullOrWhiteSpace(idEmisor))
                throw new ArgumentException("Emisor inválido.", nameof(idEmisor));

            if (string.IsNullOrWhiteSpace(idReceptor))
                throw new ArgumentException("Receptor inválido.", nameof(idReceptor));

            if (elemento.Tipo == "Consumible")
            {
                var c = (Consumible)elemento.ElementoOriginal;
                if (!c.estado) throw new InvalidOperationException("El consumible no está disponible.");

                if (c.cantidad < cantidad) throw new InvalidOperationException("Stock insuficiente para el consumible.");
            }
            switch (elemento.Tipo)
            {
                case "Consumible":
                    consumibleBLL.Consumir(
                        (Consumible)elemento.ElementoOriginal,
                        cantidad,
                        idEmisor,
                        idReceptor);
                    break;

                case "Rotable":
                    rotableBLL.Entregar(
                        (RotableBE)elemento.ElementoOriginal,
                        idEmisor,
                        idReceptor);
                    break;

                case "Herramienta":
                    throw new InvalidOperationException($"Error, seleccionó una herramienta. Intente con un consumible o rotable.");

                default:
                    throw new InvalidOperationException($"Tipo desconocido: {elemento.Tipo}");
            }
        }
    }
}
