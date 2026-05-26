using System;
using System.Collections.Generic;
using System.Text;

namespace Fotocopias_UR
{
    internal class Libreria
    {
        private string codigoProducto;
        private string nombreProducto;
        private double precio;
        private int unidadesDisponibles;
        private string marca;
        private string asignatura;
        private string descripcion;
        private string estado;

        public string CodigoProducto
        {
            get { return codigoProducto; }
            set
            {
                Inventario f = new Inventario();
                if (value.StartsWith("0"))
                    codigoProducto = value;
                else
                    Console.WriteLine("Error codigo de producto no valido!");
            }

        }

        public string NombreProducto
        {
            get { return nombreProducto; }
            set
            {
                bool correcto = true;
                string validar = "AaBbCcDdEeFfGgHhIiJjKkLlMmNnÑñOoPpQqRrSsTtUuVvWwXxYyZzÚÓÍÉÁúóíéá ";
                foreach (char c in value)
                {
                    if (!validar.Contains(c))
                    {
                        correcto = false;
                        break;
                    }
                }
                if (value.Length >= 3 && correcto)
                    nombreProducto = value;
                else
                    Console.WriteLine("Error nombre del producto no Valido!");
            }
        }

        public double Precio
        {
            get { return precio; }
            set
            {
                if (value > 0 && value == Math.Round(value, 2) && double.TryParse(value.ToString(), out double x))
                    precio = value;
                else
                    Console.WriteLine("Precio del producto no valido!");
            }
        }

        public int UnidadesDisponibles
        {
            get { return unidadesDisponibles; }
            set
            {
                if (value >= 0 && int.TryParse(value.ToString(), out int x))
                    unidadesDisponibles = value;
                else
                    Console.WriteLine("Unidades disponibles de producto no valida!");
            }
        }

        public string Marca
        {
            get { return marca; }
            set
            {
                if (value.Length >= 3)
                    marca = value;
                else
                    Console.WriteLine("Marca del producto no valida!");
            }
        }

        public string Asignatura
        {
            get { return asignatura; }
            set
            {
                if (value == "Libreria" || value == "Tienda")
                    asignatura = value;
                else
                    Console.WriteLine("Asignatura del producto no valida!");
            }
        }

        public string Descripcion
        {
            get { return descripcion; }
            set
            {
                if (value.Length > 3 || value == "")
                    descripcion = value;
                else
                    Console.WriteLine("Descripcion del producto no valida!");
            }
        }

        public string Estado
        {
            get { return estado; }
            set
            {
                if (value == "Activo" || value == "Inactivo")
                    estado = value;
                else
                    Console.WriteLine("Estado del producto no valido!");
            }
        }

        public Libreria(string codigoProducto, string nombreProducto, double precio, int unidadesDisponibles, string marca, string asignatura, string descripcion, string estado)
        {
            CodigoProducto = codigoProducto;
            NombreProducto = nombreProducto;
            Precio = precio;
            UnidadesDisponibles = unidadesDisponibles;
            Marca = marca;
            Asignatura = asignatura;
            Descripcion = descripcion;
            Estado = estado;
        }

    }
}
