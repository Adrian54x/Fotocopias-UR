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

        public void MenuProductos()
        {
            Console.Clear();
            Console.WriteLine("--- Productos ---");
            Console.WriteLine("1. Agregar producto");
            Console.WriteLine("2. Ver todos los productos");
            Console.WriteLine("3. Buscar Productos");
            Console.WriteLine("4. Eliminar Productos");
            Console.WriteLine("0. Regresar.");
            Console.Write("Elija una opcion:");
        }
    }
}
