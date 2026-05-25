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
    }
}
