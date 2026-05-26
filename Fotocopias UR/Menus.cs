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

        public void OpcionProductos()
        {
            Console.WriteLine("1. Libreria");
            Console.WriteLine("2. Tienda");
            Console.WriteLine("0. regresar");
            Console.Write("Elija una opcion:");
        }

        public void MenuUsuario()
        {
            Console.Clear();
            Console.WriteLine("--- Usuario ---");
            Console.WriteLine("1. Agregar Usuario");
            Console.WriteLine("2. Ver Usuarios");
            Console.WriteLine("3. Buscar Usuario");
            Console.WriteLine("4. Eliminar Usuario");
            Console.WriteLine("0. Regresar.");
            Console.Write("Elija una opcion:");
        }

        public void OpcionUsuario()
        {
            Console.WriteLine("1. Trabajador");
            Console.WriteLine("2. Administrador");
            Console.WriteLine("0. Regresar.");
            Console.Write("Elija una opcion:");
        }
    }
}
