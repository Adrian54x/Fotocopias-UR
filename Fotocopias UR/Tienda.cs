using System;
using System.Collections.Generic;
using System.Text;

namespace Fotocopias_UR
{
    internal class Tienda : Libreria
    {
        private DateTime fechaVencimiento;

        public DateTime FechaVencimiento
        {
            get { return fechaVencimiento; }
            set
            {
                if (value.Date > DateTime.Today && DateTime.TryParse(value.ToString(), out DateTime x))
                    fechaVencimiento = value;
                else
                    Console.WriteLine("Fecha de vencimiento no valida!");
            }
        }

        public Tienda(string codigoProducto, string nombreProducto, double precio, int unidadesDisponibles, string marca, string asignatura, string descripcion, string estado, DateTime fechaVencimiento)
            : base(codigoProducto, nombreProducto, precio, unidadesDisponibles, marca, asignatura, descripcion, estado)
        {
            FechaVencimiento = fechaVencimiento;
        }


    }
}
