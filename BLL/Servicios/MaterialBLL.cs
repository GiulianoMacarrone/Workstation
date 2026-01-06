using BE.Modelo;
using DAL;
using DocumentFormat.OpenXml.Bibliography;
using Mapper;
using Org.BouncyCastle.Crypto.Agreement.Kdf;
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

        public void EntregarElemento(ElementoVisualizable elemento,int cantidad,string userEmisor,string userReceptor)
        {
            if (elemento == null)
                throw new ArgumentNullException(nameof(elemento));

            if (cantidad < 1) throw new ArgumentException("La cantidad debe ser al menos 1.", nameof(cantidad));

            if (string.IsNullOrWhiteSpace(userEmisor))
                throw new ArgumentException("Emisor inválido.", nameof(userEmisor));

            if (string.IsNullOrWhiteSpace(userReceptor))
                throw new ArgumentException("Receptor inválido.", nameof(userReceptor));

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
                        userEmisor,
                        userReceptor);
                    break;

                case "Rotable":
                    rotableBLL.Entregar(
                        (RotableBE)elemento.ElementoOriginal,
                        userEmisor,
                        userReceptor);
                    break;

                case "Herramienta":
                    herramientaBLL.Entregar(
                        (HerramientaBE)elemento.ElementoOriginal,
                        userEmisor,
                        userReceptor);
                    break;

                default:
                    throw new InvalidOperationException($"Tipo desconocido: {elemento.Tipo}");
            }
        }
        public void ActualizarDisponibilidadPorVencimiento()
        {
            var listaConsumibles = consumibleBLL.ListarConsumibles();
            var listaHerramientas = herramientaBLL.ListarHerramientas();

            foreach (var m in listaConsumibles)
            {
                if (m.fechaVto != null && m.fechaVto.Date < DateTime.Today)
                {
                    if (m.estado == true)
                    {
                        m.estado = false;
                        consumibleBLL.GuardarConsumible(m);
                    }
                }
            }

            foreach (var m in listaHerramientas)
            {
                if (m.fechaVtoCalibracion != null && m.fechaVtoCalibracion.Date < DateTime.Today)
                {
                    if (m.estado == true)
                    {
                        m.estado = false;
                        herramientaBLL.GuardarHerramienta(m);
                    }
                }
            }
        }

        public List<HistorialEntregasBE> MostrarEntregas()
        {
            var lista = new List<HistorialEntregasBE>();
            lista.AddRange(consumibleBLL.ListarEntregas());
            lista.AddRange(herramientaBLL.ListarEntregas());
            lista.AddRange(rotableBLL.ListarEntregas());

            return lista.OrderByDescending(x => x.Fecha).ToList();
        }

    }
}
