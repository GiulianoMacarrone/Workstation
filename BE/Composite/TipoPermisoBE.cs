using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Composite
{
    public enum TipoPermisoBE
    {
        Ninguno,
        Permisos_Panel_Administrador,
        Crear_Trabajo,
        Eliminar_Trabajo,
        Crear_Orden_De_Trabajo,
        Eliminar_OT,
        Visualizar_OT,
        Ejecutar_OT,
        Firmar_OT,
        Consultar_Aeronaves,
        Abrir_Diferido,
        Cerrar_Diferido,
        Cerrar_OT,
        Cargar_Consumible,
        Crear_Herramienta,
        Crear_Rotable,
        Generar_NoStock,
        Visualizar_Elemento,
        Consultar_Solicitudes,
        Ver_Dashboard,
        Firmar_Tarea,
        Certificar_Tarea
    }
}
