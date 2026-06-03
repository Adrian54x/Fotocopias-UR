using System;
using System.Collections.Generic;
using System.Text;

namespace Fotocopias_UR
{
    internal class Comentarios
    {
        private DateTime fecha;
        private string movito;
        private string autor;

        public DateTime Fecha
        {
            get { return fecha; }
            set
            {
                if(DateTime.TryParse(value.ToString(), out DateTime x) && value.Date <= DateTime.Today && value.Year > 2022)
                    fecha = value;
                else
                    Console.WriteLine("Fecha no valida!");
            }
        }

        public string Movito
        {
            get { return movito; }
            set { movito = value; }
        }

        public string Autor
        {
            get { return autor; }
            set {  autor = value; }
        }

        public Comentarios(DateTime fecha, string movito, string autor)
        {
            Fecha = fecha;
            Movito = movito;
            Autor = autor;
        }
    }

    internal class IngresoEgreso : Comentarios
    {
        private double cantidad;

        public double Cantidad
        {
            get { return cantidad; } 
            set { cantidad = value; }
        }

        public IngresoEgreso(DateTime fecha, string movito, string autor, double cantida) : base(fecha, movito, autor)
        {
            Cantidad = cantida;
        }
    }
}
