using System;
using System.Collections.Generic;
using System.Text;

namespace Fotocopias_UR.GeneralUR
{
    internal class DatosGlobales
    {
        public string[] asignatura = { "Administrador", "Trabajador" }, producto = { "Libreria", "Tienda" }, estado = { "Activo", "Inactivo" };
        public string[] comentarios = { "Comentario", "Ingreso", "Egreso" }, suministro = { "Toner", "Resma" };
        public static string usuarioActivoCodigo = "", usuarioActivoNombre = "";
    }
}
