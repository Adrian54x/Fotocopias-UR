using Fotocopias_UR.UsuariosUR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fotocopias_UR.GeneralUR
{
    internal class Menus
    {

        public string MenuIngreso()
        {;
            Usuario buscar = new Usuario();
            string usuarioIngreso, passIngreso, asignado = "";
            int intentos = 5;
            do
            {
                Console.Clear();
                Console.WriteLine("=== Bienvenido al Sistema Fotocopias UR ===");
                Console.Write("Ingrese su Usuario:");
                usuarioIngreso = Console.ReadLine();
                Console.Write("Ingrese su Contraseña:");
                passIngreso = Console.ReadLine();
                if (!buscar.BuscarValidacionAdmin(usuarioIngreso,passIngreso) && !buscar.BuscarValidacionTrabajador(usuarioIngreso,passIngreso))
                {
                    Console.Write("Usuario no encontrado!");
                    Thread.Sleep(500);
                    Console.Write("-----> Intente otra ves");
                    Thread.Sleep(500);
                    intentos--;
                }
                else
                {
                    if (buscar.BuscarValidacionAdmin(usuarioIngreso, passIngreso))
                    {
                        asignado = "Administrador";
                        DatosGlobales.usuarioActivoCodigo = buscar.ExtraerConectado(usuarioIngreso, passIngreso);
                        DatosGlobales.usuarioActivoNombre = usuarioIngreso;
                    }
                    if(buscar.BuscarValidacionTrabajador(usuarioIngreso, passIngreso))
                    {
                        asignado = "Trabajador";
                        DatosGlobales.usuarioActivoNombre = usuarioIngreso;
                    }
                }
                if (intentos == 0)
                {
                    Console.WriteLine("Llego al limite de intentos!");
                    break;
                }
            } while (!buscar.BuscarValidacionAdmin(usuarioIngreso, passIngreso) && !buscar.BuscarValidacionTrabajador(usuarioIngreso, passIngreso));
            return asignado;
        }

        public void MenuAdmin()
        {
            Console.Clear();
            Console.WriteLine("=== Fotocopias UR ===");
            Console.WriteLine("1. Productos");
            Console.WriteLine("2. Usuario");
            Console.WriteLine("3. Ingresos y Egresos");
            Console.WriteLine("4. Fotocopiadora");
            Console.WriteLine("5. Comentarios");
            Console.WriteLine("0. Salir.");
            Console.Write("Elija una opcion:");
        }

        public void MenuTrabajador()
        {
            Console.Clear();
            Console.WriteLine("=== Fotocopias UR ===");
            Console.WriteLine("1. Ver todos los productos");
            Console.WriteLine("2. Administrar Ventas");
            Console.WriteLine("3. Comentarios");
            Console.WriteLine("0. Salir");
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
            Console.WriteLine("1. Administrador");
            Console.WriteLine("2. Trabajador");
            Console.WriteLine("0. Regresar.");
            Console.Write("Elija una opcion:");
        }

        public void MenuIngresosEgresos()
        {
            Console.Clear();
            Console.WriteLine("--- Ingresos y Egresos ---");
            Console.WriteLine("1. Agregar Ingresos y Egresos");
            Console.WriteLine("2. Ver resumen de ingresos y egresos");
            Console.WriteLine("3. Eliminar Ingreso o Egreso");
            Console.WriteLine("0. Regresar.");
            Console.Write("Elija una opcion:");
        }

        public void OpcionIngresosEgresos()
        {
            Console.WriteLine("1. Ingresos ");
            Console.WriteLine("2. Egresos");
            Console.WriteLine("0. Regresar.");
            Console.Write("Elija una opcion:");
        }

        public void MenuFotocopiadora()
        {
            Console.Clear();
            Console.WriteLine("--- Fotocopiadora ---");
            Console.WriteLine("1. Suministros");
            Console.WriteLine("2. Fotocopias");
            Console.WriteLine("0. Regresar.");
            Console.Write("Elija una opcion:");
        }

        public void OpcionSuministros()
        {
            Console.WriteLine("--- Suministros ---");
            Console.WriteLine("1. Agregar suministro");
            Console.WriteLine("2. Ver suministros");
            Console.WriteLine("0. Regresar.");
            Console.Write("Elija una opcion:");
        }

        public void OpcionFotocopias()
        {
            Console.WriteLine("--- Fotocopias ---");
            Console.WriteLine("1. Agregar fotocopias totales");
            Console.WriteLine("2. Agragar fotocopias sacadas por semana");
            Console.WriteLine("3. Ver fotocopias sacadas por semana");
            Console.WriteLine("0. Regresar.");
            Console.Write("Elija una opcion:");
        }

        public void MenuComentarios()
        {
            Console.WriteLine("--- Comentarios ---");
            Console.WriteLine("1. Ver Comentarios");
            Console.WriteLine("2. Enviar Comentarios");
            Console.WriteLine("0. Regresar.");
            Console.Write("Elija una opcion:");
        }

    }
}
