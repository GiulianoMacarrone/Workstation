using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Backup
{
    public class Backup
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string Operacion { get; set; }  // backup o restaurar
        public string ArchivoPath { get; set; }   
        public string Usuario { get; set; }  // usuario que realizó la operación
    }
}
