using System;
using System.Collections.Generic;
using System.Text;

namespace Fotocopias_UR
{
    internal class Menus
    {
        public void MenuAdmin()
        {
            Console.Clear();
            Console.WriteLine("=== Fotocopias UR ===");
            Console.WriteLine("1. Productos");
            Console.WriteLine("2. Usuario");
            Console.WriteLine("3. Ingresos y Egresos");
            Console.WriteLine("4. Fotocopiadora");
            Console.WriteLine("5. Comentarios");
            Console.WriteLine("6. Herramientas disponibles");
            Console.WriteLine("0. Salir.");
            Console.Write("Elija una opcion:");
        }
    }
}
