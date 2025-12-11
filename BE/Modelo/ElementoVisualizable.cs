using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Modelo
{
    public class ElementoVisualizable
    {
        public string Id { get; set; }
        public string PartNumber { get; set; }
        public int Cantidad { get; set; }
        public string Tipo { get; set; }
        public string Descripcion { get; set; }
        public object ElementoOriginal { get; set; }
        public DateTime? FechaVencimiento { get; set; }
        public bool EstaVencido => 
            FechaVencimiento.HasValue && 
            FechaVencimiento.Value.Date < DateTime.Today;


        public ElementoVisualizable(Consumible c, string tipo)
        {
            Id = c.id;
            PartNumber = c.partNumber;
            Cantidad = c.cantidad;
            Tipo = tipo;
            Descripcion = c.descripcion;
            ElementoOriginal = c;
            FechaVencimiento = c.fechaVto; 
        }

        public ElementoVisualizable(HerramientaBE h, string tipo)
        {
            Id = h.id;
            PartNumber = h.serial;
            Cantidad = 1;
            Tipo = tipo;
            Descripcion = h.descripcion;
            ElementoOriginal = h;
            FechaVencimiento = h.fechaVtoCalibracion;
        }

        public ElementoVisualizable(RotableBE r, string tipo)
        {
            Id = r.id;
            PartNumber = r.partNumber;
            Cantidad = 1;
            Tipo = tipo;
            Descripcion = r.descripcion;
            ElementoOriginal = r;
            FechaVencimiento = null;
        }
    }
}

