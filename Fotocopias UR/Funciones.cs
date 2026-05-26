using System;
using System.Collections.Generic;
using System.Text;

namespace Fotocopias_UR
{
    internal class Funciones
    {
        // Validaciones simples

        public string ValidarTexto(int cantidadMinimaCaracters)
        {
            string textoValido;
            do
            {
                textoValido = Console.ReadLine();
                if (textoValido.Length < cantidadMinimaCaracters)
                {
                    Error();
                }
            } while (textoValido.Length < cantidadMinimaCaracters);
            return textoValido;
        }

        public int ValidarMenu()
        {
            int validarMenu;
            do
            {
                if (!int.TryParse(Console.ReadLine(), out validarMenu) || validarMenu < 0)
                {
                    Error();
                    validarMenu = -1;
                }
            } while (!int.TryParse(validarMenu.ToString(), out int x) || validarMenu < 0);
            return validarMenu;
        }

        public bool SIoNO()
        {
            string SioNo;
            bool SIoNO = false;
            do
            {
                SioNo = Console.ReadLine();
                if (!(string.Equals(SioNo, "si", StringComparison.OrdinalIgnoreCase) || string.Equals(SioNo, "no", StringComparison.OrdinalIgnoreCase)))
                {
                    Error();
                }
                else
                {
                    if (string.Equals(SioNo, "si", StringComparison.OrdinalIgnoreCase))
                        SIoNO = true;
                    else if (string.Equals(SioNo, "no", StringComparison.OrdinalIgnoreCase))
                        SIoNO = false;
                }
            } while (!(string.Equals(SioNo, "si", StringComparison.OrdinalIgnoreCase) || string.Equals(SioNo, "no", StringComparison.OrdinalIgnoreCase)));
            return SIoNO;
        }

        public void ColorComentario(string texto)
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine(texto);
            Console.ResetColor();
        }

        public void OpcionNoExistente()
        {
            Console.WriteLine("Opcion no existente!");
            Thread.Sleep(1000);
        }

        public void Regresar()
        {
            Console.Write("Regresando");
            Thread.Sleep(200);
            Console.Write(".");
            Thread.Sleep(200);
            Console.Write(".");
            Thread.Sleep(200);
            Console.Write(".");
        }

        public void Error()
        {
            Console.Write("Ingreso no valido!");
            Thread.Sleep(500);
            Console.Write("-----> Intente otra ves:");
        }

        public string GeneradorCodigos(int codigoActual)
        {
            string codigoGenerado = "0" + (codigoActual + 1).ToString();
            return codigoGenerado;
        }





        // Opciones de ingreso

        public double Precio()
        {
            double validarPrecio;
            do
            {
                if (!double.TryParse(Console.ReadLine(), out validarPrecio) || validarPrecio != Math.Round(validarPrecio, 2) || validarPrecio < 0)
                    Error();
            } while (!double.TryParse(validarPrecio.ToString(), out double x) || validarPrecio != Math.Round(validarPrecio, 2) || validarPrecio < 0);
            return validarPrecio;
        }

        public DateTime FechaVencimiento()
        {
            DateTime fechaVencimiento;
            do
            {
                if (!DateTime.TryParse(Console.ReadLine(), out fechaVencimiento) || fechaVencimiento.Date < DateTime.Today)
                {
                    Error();
                }
            } while (!DateTime.TryParse(fechaVencimiento.ToString(), out DateTime x) || fechaVencimiento.Date < DateTime.Today);
            return fechaVencimiento;
        }

        public string ValidarNombre()
        {
            string nombreValido;
            bool nombreError;
            do
            {
                string letras = "AaBbCcDdEeFfGgHhIiJjKkLlMmNnÑñOoPpQqRrSsTtUuVvWwXxYyZzÚÓÍÉÁúóíéá ";
                nombreError = false;
                nombreValido = Console.ReadLine();
                foreach (char nv in nombreValido)
                {
                    if (!letras.Contains(nv))
                    {
                        nombreError = true;
                        break;
                    }
                }
                if (nombreValido.Length < 3 || nombreError)
                {
                    Error();
                }
            } while (nombreValido.Length < 3 || nombreError);
            return nombreValido;
        }

        public Libreria IngresoProductos(string asignatura, string estado)
        {
            Inventario f = new Inventario();
            int cantidadProductos = 0;
            if (asignatura == "Libreria")
            {
                cantidadProductos = f.ContarProductosLibreria();
            }
            else if (asignatura == "Tienda")
            {
                cantidadProductos = f.ContarProductosTienda();
            }
            string codigoProducto;
            do
            {
                codigoProducto = GeneradorCodigos(cantidadProductos);
                cantidadProductos++;
            } while ((asignatura == "Libreria" && f.BuscarProductoLibreria(codigoProducto)) || (asignatura == "Tienda" && f.BuscarProductoTienda(codigoProducto)));
            Console.WriteLine($"Codigo: {codigoProducto}");

            ColorComentario("(El nombre del producto tiene que tener 3 o mas caracters)");
            Console.Write("Nombre:");
            string nombreProducto = ValidarNombre();

            ColorComentario("(El precio tiene que ser mayor a 0 y maximo puede tener 2 decimales)");
            Console.Write("Precio:Q");
            double precio = Precio();

            ColorComentario("(La unidades tienen que ser enteros y positivos)");
            Console.Write("Unidades disponibles:");
            int unidadesDisponibles = ValidarMenu();

            ColorComentario("(La marca tiene que tener mas de 2 caracters)");
            Console.Write("Marca:");
            string marca = ValidarNombre();

            ColorComentario("(La descripcion es opcional)");
            Console.Write("Descripcion(Si/No):");
            bool validarDescripcion = SIoNO();
            string descripcion = "";
            if (validarDescripcion)
            {
                ColorComentario("\n(La descripcion tiene que tener mas de 3 caracters)");
                Console.Write("Descripcion:");
                descripcion = ValidarTexto(3);
            }

            if (asignatura == "Tienda")
            {
                ColorComentario("(Ejemplo de ingreso de fecha 1/1/2000)");
                Console.Write("Fecha de vencimiento:");
                DateTime fechaVencimiento = FechaVencimiento();
                return new Tienda(codigoProducto, nombreProducto, precio, unidadesDisponibles, marca, "Tienda", descripcion, estado, fechaVencimiento);
            }
            else
            {
                return new Libreria(codigoProducto, nombreProducto, precio, unidadesDisponibles, marca, "Libreria", descripcion, estado);
            }
        }

    }
}
