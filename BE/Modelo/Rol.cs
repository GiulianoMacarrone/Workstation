using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abstraccion;

namespace BE.Modelo
{
    public class Rol
    {
        public int id { get; set; }
        public string designacion { get; set; }
        public List<int> idsPermisos { get; set; } = new List<int>();
    }
}

/* Roles
 * id = 0 - designacion = "Administrador"
 * listaPermisos(0,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18)
 * 
 * id=1 - designacion = "Planificador"
 * listaPermisos(1,2,3,4,5,8,16,17,18)
 * 
 * id=2 - designacion = "Mecanico"
 * listaPermisos(5,6,7,8,18)
 * 
 * id=3 - designacion = "Inspector"
 * listaPermisos(5,7,8,9,10,11,18)
 * 
 * id=4 - designacion = "Pañolero"
 * listaPermisos(12,13,14,15,16,17,18)
 * 
 * id=5 - designacion = "logistico"
 * listaPermisos(16,17)
 * 
 * Lista total de permisos:
 * id     nombre
            0     Permisos_Panel_Administrador
            1     Crear_Trabajo
            2     Eliminar_Trabajo
            3     Crear_Orden_De_Trabajo
            4     Eliminar_OT
            5     Visualizar_OT
            6     Ejecutar_OT
            7     Firmar_OT
            8     Consultar_Aeronaves
            9     Abrir_Diferido
            10    Cerrar_Diferido
            11    Cerrar_OT
            12    Cargar_Consumible
            13    Crear_Herramienta
            14    Crear_Rotable
            15    Generar_NoStock
            16    Visualizar_Elemento
            17    Consultar_Solicitudes
            18    Ver_Dashboard
*/