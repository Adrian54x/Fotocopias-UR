using System;
using System.Collections.Generic;
using System.Text;

namespace Fotocopias_UR.ArgumentosUR
{
    internal class IngresoEgreso : Comentarios
    {
        private double cantidad;

        public double Cantidad
        {
            get { return cantidad; }
            set 
            { 
                if(double.TryParse(value.ToString(), out double x)) 
                    cantidad = value; 
                else
                    Console.WriteLine("Cantidad no valida!");
            }
        }

        public IngresoEgreso(DateTime fecha, string movito, string autor, double cantida) : base(fecha, movito, autor)
        {
            Cantidad = cantida;
        }
    }
}
