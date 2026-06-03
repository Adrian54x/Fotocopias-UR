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
                if (string.Equals(SioNo, "si", StringComparison.OrdinalIgnoreCase))
                    SIoNO = true;
                else if (string.Equals(SioNo, "no", StringComparison.OrdinalIgnoreCase))
                    SIoNO = false;
                else
                    Error();
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

        public int CalcularEdad(string fecha)
        {
            DateTime fechaNacimento = DateTime.Parse(fecha);
            int edad = DateTime.Today.Year - fechaNacimento.Year;
            if (DateTime.Today.Day < fechaNacimento.Day && DateTime.Today.Month <= fechaNacimento.Month)
            {
                edad--;
            }
            return edad;
        }




        // Opciones de ingreso

        public double CantidadIngresoEgreso()
        {
            double aprovado;
            string cantidad, nums = "0.123456789";
            int cont;
            bool valCantidad, punto;
            do
            {
                cont = 0;
                punto = false;
                valCantidad = true;
                cantidad = Console.ReadLine();
                foreach(char c in cantidad)
                {
                    if(!nums.Contains(c))
                    {
                        valCantidad = false;
                        break;
                    }
                    if(c == '.')
                    {
                        punto = true;
                    }
                    if (punto)
                    {
                        cont++;
                    }
                }
                if(!double.TryParse(cantidad, out aprovado) || !valCantidad || cont > 3)
                    Error();
            } while (!double.TryParse(cantidad, out aprovado) || !valCantidad || cont > 3);
            return aprovado;
        }


        public DateTime FechaArgumento()
        {
            DateTime fechaArgumento;
            do
            {
                if (!DateTime.TryParse(Console.ReadLine(), out fechaArgumento) || fechaArgumento.Date > DateTime.Today || fechaArgumento.Year <= 2022)
                {
                    Error();
                }
            } while (!DateTime.TryParse(fechaArgumento.ToString(), out DateTime x) || fechaArgumento.Date > DateTime.Today || fechaArgumento.Year <= 2022);
            return fechaArgumento;
        }

        public string NumeroTelefono()
        {
            string telefono, validarNumero = "0123456987";
            bool validarTelefono;
            do
            {
                validarTelefono = false;
                telefono = Console.ReadLine();
                foreach (char tv in telefono)
                {
                    if (!validarNumero.Contains(tv))
                    {
                        validarTelefono = true;
                        break;
                    }
                }
                if (validarTelefono || telefono.Length < 8)
                {
                    Error();
                }
            } while (validarTelefono || telefono.Length < 8);
            return telefono;
        }

        public DateTime FechaNacimiento()
        {
            DateTime fechaEdad;
            do
            {

                if (!DateTime.TryParse(Console.ReadLine(), out fechaEdad) || (DateTime.Today.Year - fechaEdad.Year) < 14 || fechaEdad.Year < 1925)
                {
                    Error();
                }
            } while (!DateTime.TryParse(fechaEdad.ToString(), out DateTime x) || (DateTime.Today.Year - fechaEdad.Year) < 14 || fechaEdad.Year < 1925);
            return fechaEdad;
        }

        public string PassWord()
        {
            string passValida, validMayusculas = "ABCDEFGHIJKLMNÑOPQRSTUVWXYZÚÓÍÉÁ", vlidarNumeros = "1234567890";
            int passNumeros, passMayusculas;
            do
            {
                passNumeros = 0;
                passMayusculas = 0;
                passValida = Console.ReadLine();
                if (passValida.Length >= 8 && passValida.Length <= 15)
                {
                    foreach (char v in passValida)
                    {
                        if (validMayusculas.Contains(v))
                        {
                            passMayusculas++;
                        }
                        if (vlidarNumeros.Contains(v))
                        {
                            passNumeros++;
                        }
                    }
                }
                if (passValida.Length < 8 || passValida.Length > 15 || passNumeros == 0 || passMayusculas == 0)
                {
                    Error();
                }
            } while (passValida.Length < 8 || passValida.Length > 15 || passNumeros == 0 || passMayusculas == 0);
            return passValida;
        }

        public double Precio()
        {
            bool valPrecio, val;
            int cont;
            string precio, nums = "0.123456789";
            double validarPrecio;
            do
            {
                val = false;
                valPrecio = true;
                cont = 0;
                precio = Console.ReadLine();
                foreach(char p in precio)
                {
                    if(!nums.Contains(p))
                    {
                        valPrecio = false;
                        break;
                    }
                    if(p == '.')
                    {
                        val = true;
                    }
                    if(val)
                    {
                        cont++;
                    }
                }
                if (!double.TryParse(precio, out validarPrecio) || !valPrecio || cont > 3)
                    Error();
            } while (!double.TryParse(precio, out validarPrecio) || !valPrecio || cont > 3);
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

        public Administrador IngresoUsuarios(string asignadoA)
        {
            Usuario f = new Usuario();
            int cantidadUsuarios = 0;
            if(asignadoA == "Administrador")
            {
                cantidadUsuarios = f.ContarAdministradores();
            }
            else if (asignadoA == "Trabajador")
            {
                cantidadUsuarios = f.ContarTrabajadores();
            }
            string codigo;
            do
            {
                codigo = "UR" + GeneradorCodigos(cantidadUsuarios);
                cantidadUsuarios++;
            } while ((asignadoA == "Administrador" && f.BuscarAdministrador(codigo)) || (asignadoA == "Trabajador" && f.BuscarTrabajador(codigo)));
            Console.WriteLine($"Codigo:{codigo}");

            ColorComentario($"(El {asignadoA} tiene que tener 3 o mas caracteres y solo contener letras )");
            Console.Write("Usuario:");
            string usuario = ValidarNombre();

            ColorComentario("(La contraseña debe tener al menos 1 Mayuscula, 1 Numero y 8 a 15 Caracteres)");
            Console.Write("Contraseña:");
            string pass = PassWord();

            ColorComentario("(Ejemplo de ingreso de fecha 1/1/2000)");
            Console.Write("Fecha de nacimiento:");
            DateTime fecha = FechaNacimiento();

            if (asignadoA == "Administrador")
            {
                return new Administrador(codigo, usuario, pass, fecha, asignadoA);
            }
            else
            {
                ColorComentario("(el numero de telefono tiene que estar junto y teiene que tener 8 numeros minimo)");
                Console.Write("Numero telefonico:");
                string numeroTelefono = NumeroTelefono();
                return new Trabajador(codigo, usuario, pass, fecha, asignadoA, numeroTelefono);
            }
        }

        public Comentarios IngresosEgresosYComentario(string tipo)
        {
            DatosGlobales glo = new DatosGlobales();
            DateTime fecha = DateTime.Now;
            string echoPor = DatosGlobales.usuarioActivoNombre;
            Console.WriteLine($"Realizado por:{echoPor}");
            if (tipo == glo.comentarios[0])
            {
                fecha = DateTime.Today;
                Console.WriteLine($"Fecha:{fecha}");
            }
            if (tipo == glo.comentarios[1] || tipo == glo.comentarios[2])
            {
                ColorComentario("(ejemplo de fecha 2/2/2000)");
                Console.Write("Fecha:");
                fecha = FechaArgumento();
            }
            double cantidad = 0;
            if (tipo == glo.comentarios[1] || tipo == glo.comentarios[2])
            {
                ColorComentario("(La cantidad tiene que ser mayor a 0 y maximo 2 decimales )");
                Console.Write("Cantidad:Q");
                cantidad = CantidadIngresoEgreso();
            }
            ColorComentario("(La descripcion tiene que tener mas de 5 letras)");
            Console.Write("Descripcion:");
            string movito = ValidarTexto(5);
            if (tipo == glo.comentarios[0])
                return new Comentarios(fecha,movito,echoPor);
            else
                return new IngresoEgreso(fecha, movito, echoPor,cantidad);
        }

    }
}
