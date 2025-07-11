using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Modelo
{
    public class ElementoVisualizable
    {
        public string id { get; }

        public string tipo { get; }

        public string descripcion { get; }

        public object elementoOriginal { get; }

        public ElementoVisualizable(object elemento, string tipo)
        {
            elementoOriginal = elemento;
            this.tipo = tipo;

            switch (tipo)
            {
                case "Consumible":
                    var consumible = (Consumible)elemento;
                    id = consumible.id;
                    descripcion = consumible.descripcion;
                    break;

                case "Herramienta":
                    var herramienta = (HerramientaBE)elemento;
                    id = herramienta.id;
                    descripcion = herramienta.descripcion;
                    break;

                case "Rotable":
                    var rotable = (RotableBE)elemento;
                    id = rotable.id;
                    descripcion = rotable.descripcion;
                    break;

                default:
                    throw new ArgumentException($"Tipo desconocido: {tipo}");
            }
        }
    }
}

