using Fotocopias_UR;
using System.Diagnostics;
using static System.Runtime.InteropServices.JavaScript.JSType;

DatosGlobales asignaturas = new DatosGlobales();
Menus menus = new Menus();
Funciones funciones = new Funciones();
Inventario inventario = new Inventario();
Usuario usuario = new Usuario();
bool menu = true;
do
{ 
    //try
    //{
        inventario.CrearTablaLibreria();
        inventario.CrearTablaTienda();
        usuario.CrearTablaAdmisitrador();
        usuario.CrearTablaTrabajador();
        int menuPrincipal, subMenus, opcion;
        if (usuario.ContarAdministradores() == 0)
        {
            Console.Clear();
            Console.WriteLine("=== Ingrese el Administrador Principal ===");
            string codigo0 = "UR00";

            funciones.ColorComentario("(El usuario tiene que tener 3 o mas caracteres y solo contener letras)");
            Console.Write("Ingrese su Usuario:");
            string usuario0 = funciones.ValidarNombre();

            funciones.ColorComentario("(La contraseña debe tener al menos 1 Mayuscula, 1 Numero y 8 a 15 Caracteres)");
            Console.Write("Ingrese su Contraseña:");
            string pass0 = funciones.PassWord();

            funciones.ColorComentario("(Ejemplo de ingreso de fecha 1/1/2000)");
            Console.Write("Ingrese su fecha de nacimiento:");
            DateTime fecha0 = funciones.FechaNacimiento();

            usuario.AgregarUsuario(new Administrador(codigo0, usuario0, pass0, fecha0, asignaturas.asignatura[0]));
        }
        string asignado = menus.MenuIngreso();
        menu = true;
        if (asignado == asignaturas.asignatura[0])
        {
            do
            {
                Console.Clear();
                menus.MenuAdmin();
                menuPrincipal = funciones.ValidarMenu();
                Console.Clear();
                switch (menuPrincipal)
                {
                    case 0:
                        Console.Write("Saliendo");
                        Thread.Sleep(200);
                        Console.Write(".");
                        Thread.Sleep(200);
                        Console.Write(".");
                        Thread.Sleep(200);
                        Console.Write(".");
                        menu = false;
                        break;

                    case 1:
                        do
                        {
                            menus.MenuProductos();
                            subMenus = funciones.ValidarMenu();
                            Console.Clear();
                            switch (subMenus)
                            {
                                case 0:
                                    funciones.Regresar();
                                    break;

                                case 1:
                                    do
                                    {
                                        Console.WriteLine("--- Agregar Producto ---");
                                        menus.OpcionProductos();
                                        opcion = funciones.ValidarMenu();
                                        Console.Clear();
                                        switch (opcion)
                                        {
                                            case 0:
                                                funciones.Regresar();
                                                break;

                                            case 1:
                                                Console.WriteLine("--- Libreria ---");
                                                inventario.AgregarProductos(funciones.IngresoProductos(asignaturas.producto[0],asignaturas.estado[0]));
                                                break;

                                            case 2:
                                                Console.WriteLine("--- Tienda ---");
                                                inventario.AgregarProductos(funciones.IngresoProductos(asignaturas.producto[1], asignaturas.estado[0]));
                                                break;
                                            default:
                                                funciones.OpcionNoExistente();
                                                break;
                                        }
                                    } while (opcion < 0 || opcion > 2);
                                    break;

                                case 2:
                                    if(inventario.ContarProductosLibreria() == 0 && inventario.ContarProductosTienda() == 0)
                                    {
                                        Console.WriteLine("No ahi ningun producto aun disponible!");   
                                    }
                                    else
                                    {
                                        Console.WriteLine("--- Ver todos los productos ---");
                                        Console.WriteLine("\n*** Libreria ***");
                                        inventario.MostarDatosLibreria();
                                        Console.WriteLine("\n*** Tienda ***");
                                        inventario.MostrarDatosTienda();
                                    }
                                    Console.WriteLine("\nPrecione culquier tecla para continuar");
                                    Console.ReadKey();
                                    break;

                                case 3:
                                    do
                                    {
                                        Console.Clear();
                                        Console.WriteLine("--- Buscar Productos ---");
                                        menus.OpcionProductos();
                                        opcion = funciones.ValidarMenu();
                                        string buscarCodigo;
                                        Console.Clear();
                                        switch (opcion)
                                        {
                                            case 0:
                                                funciones.Regresar();
                                                break;
                                            case 1:
                                                Console.Write("Busacr:");
                                                buscarCodigo = Console.ReadLine();
                                                if(!inventario.BuscarProductoLibreria(buscarCodigo))
                                                {
                                                    Console.WriteLine("Codigo no Existente!");
                                                    Thread.Sleep(1500);
                                                }
                                                else
                                                {
                                                    Console.WriteLine("\nProducto encontrado:");
                                                    inventario.MostarEspesificoLibreria(buscarCodigo);
                                                    Console.WriteLine("\nPrecione culquier tecla para continuar");
                                                    Console.ReadKey();
                                                }
                                                break;
                                            case 2:
                                                Console.Write("Busacr:");
                                                buscarCodigo = Console.ReadLine();
                                                if(!inventario.BuscarProductoTienda(buscarCodigo))
                                                {
                                                    Console.WriteLine("Codigo no Existente!");
                                                    Thread.Sleep(1500);
                                                }
                                                else
                                                {
                                                    Console.WriteLine("\nProducto encontrado:");
                                                    inventario.MostarEspesificoTienda(buscarCodigo);
                                                    Console.WriteLine("\nPrecione culquier tecla para continuar");
                                                    Console.ReadKey();
                                                }
                                                break;

                                            default:
                                                funciones.OpcionNoExistente();
                                                break;
                                        };
                                    } while (opcion != 0);
                                    break;

                                case 4:
                                    do
                                    {
                                        Console.Clear();
                                        Console.WriteLine("--- Eliminar Productos ---");
                                        menus.OpcionProductos();
                                        opcion = funciones.ValidarMenu();
                                        string eliminarProducto;
                                        Console.Clear();
                                        switch (opcion)
                                        {
                                            case 0:
                                                funciones.Regresar();
                                                break;
                                            case 1:
                                                Console.Write("Codigo:");
                                                eliminarProducto = Console.ReadLine();
                                                inventario.EliminarProductoLibreria(eliminarProducto);
                                                Console.WriteLine("\nPrecione culquier tecla para continuar");
                                                Console.ReadKey();
                                                break;

                                            case 2:
                                                Console.Write("Codigo:");
                                                eliminarProducto = Console.ReadLine();
                                                if (!inventario.BuscarProductoLibreria(eliminarProducto))
                                                    inventario.EliminarProductoTienda(eliminarProducto);
                                                    Console.WriteLine("\nPrecione culquier tecla para continuar");
                                                    Console.ReadKey();
                                                break;

                                            default:
                                                funciones.OpcionNoExistente();
                                                break;
                                        }
                                    } while (opcion != 0);
                                    break;

                                default:
                                    funciones.OpcionNoExistente();
                                    break;
                            }
                        } while (subMenus != 0);
                        break;

                    case 2:
                        do
                        {
                            menus.MenuUsuario();
                            subMenus = funciones.ValidarMenu();
                            Console.Clear();
                            switch (subMenus)
                            {
                                case 0:
                                    funciones.Regresar();
                                    break;

                                case 1:
                                    do
                                    {
                                        Console.Clear();
                                        Console.WriteLine("--- Agregar Usuario ---");
                                        menus.OpcionUsuario();
                                        opcion = funciones.ValidarMenu();
                                        Console.Clear();
                                        switch (opcion)
                                        {
                                            case 0:
                                                funciones.Regresar();
                                                break;

                                            case 1:
                                                Console.WriteLine("--- Administrador ---");
                                                usuario.AgregarUsuario(funciones.IngresoUsuarios(asignaturas.asignatura[0]));
                                                break;
                                            case 2:
                                                Console.WriteLine("--- Trabajador ---");
                                                usuario.AgregarUsuario(funciones.IngresoUsuarios(asignaturas.asignatura[1]));
                                                break;

                                            default:
                                                funciones.OpcionNoExistente();
                                                break;
                                        }
                                    } while (opcion != 0);
                                    break;

                                case 2:
                                    Console.WriteLine("--- Ver Usuarios ---");
                                    Console.WriteLine("\n*** Administradores ***");
                                    usuario.MostrarDatosAdmis();
                                    if (usuario.ContarTrabajadores() != 0)
                                    {
                                        Console.WriteLine("\n*** Trabajadores ***");
                                        usuario.MostrarDatosTrabajador();
                                    }
                                    Console.WriteLine("\nPrecione culquier tecla para continuar");
                                    Console.ReadKey();
                                break;

                                case 3:
                                    do
                                    {
                                        Console.Clear();
                                        Console.WriteLine("--- Buscar Usuario ---");
                                        menus.OpcionUsuario();
                                        opcion = funciones.ValidarMenu();
                                        Console.Clear();
                                        switch (opcion)
                                        {
                                            case 0:
                                                funciones.Regresar();
                                                break;
                                            case 1:
                                                Console.Write("codigo:");
                                                string codigoAdmin = Console.ReadLine();
                                                if(usuario.BuscarAdministrador(codigoAdmin))
                                                {
                                                    usuario.MostarEspesificoAdmin(codigoAdmin);
                                                    Console.WriteLine("\nPrecione culquier tecla para continuar");
                                                    Console.ReadKey();
                                                }
                                                else
                                                {
                                                    Console.WriteLine("\nCodigo no existente!");
                                                    Thread.Sleep(1000);
                                                }
                                                break;
                                            case 2:
                                                Console.Write("codigo:");
                                                string codigoTrabajador = Console.ReadLine();
                                                if (usuario.BuscarAdministrador(codigoTrabajador))
                                                {
                                                    usuario.MostarEspesificoAdmin(codigoTrabajador);
                                                    Console.WriteLine("\nPrecione culquier tecla para continuar");
                                                    Console.ReadKey();
                                                }
                                                else
                                                {
                                                    Console.WriteLine("\nCodigo no existente!");
                                                    Thread.Sleep(1000);
                                                }
                                                break;
                                            default:
                                                funciones.OpcionNoExistente();
                                                break;
                                        }
                                    } while (opcion != 0);
                                    break;

                                case 4:
                                    do
                                    {
                                        Console.Clear();
                                        Console.WriteLine("--- Eliminar Usuario ---");
                                        menus.OpcionUsuario();
                                        opcion = funciones.ValidarMenu();
                                        Console.Clear();
                                        switch (opcion)
                                        { 
                                            case 0:
                                                funciones.Regresar();
                                                break;
                                            case 1:
                                                Console.Write("Codigo:");
                                                string eliminarAdmin = Console.ReadLine();
                                                if (eliminarAdmin != "UR00")
                                                {
                                                    if (DatosGlobales.usuarioActivo != eliminarAdmin)
                                                    {
                                                        usuario.EliminarUsuario(eliminarAdmin, asignaturas.asignatura[0]);
                                                    }
                                                    else
                                                    {
                                                    Console.WriteLine("No se puede eliminar usuario Activo!");
                                                    }
                                                }
                                                else
                                                {
                                                Console.WriteLine("Este codigo exacto no se puede eliminar!");
                                                }
                                                Console.WriteLine("\nPrecione culquier tecla para continuar");
                                                Console.ReadKey();
                                            break;
                                            case 2:
                                            Console.Write("Buscar:");
                                            string eliminarTrabajador = Console.ReadLine();
                                            usuario.EliminarUsuario(eliminarTrabajador, asignaturas.asignatura[0]);
                                            Console.WriteLine("\nPrecione culquier tecla para continuar");
                                                Console.ReadKey();
                                            break;
                                            default:
                                                funciones.OpcionNoExistente();
                                                break;
                                        }   
                                    } while (opcion != 0);
                                    break;

                                default:
                                    funciones.OpcionNoExistente();
                                    break;
                            }
                        } while (subMenus != 0);
                        break;

                    case 3:
                        do
                        {
                            Console.Clear();
                            menus.MenuIngresosEgresos();
                            subMenus = funciones.ValidarMenu();
                            switch(subMenus)
                            { 
                                case 0:
                                    funciones.Regresar();
                                    break;

                                case 1:
                                    Console.WriteLine("--- Agregar Ingresos ---");
                                string fecha, cantidad, movito, echoPor;
                                    break;

                                case 2:
                                    Console.WriteLine("2. Agregar Egresos");
                                    break;
                                case 3:
                                    Console.WriteLine("3. Ver resumen de ingresos y egresos");
                                    break;

                                default:
                                    funciones.OpcionNoExistente();
                                    break;
                            }   
                        } while (subMenus != 0);
                        break;

                    case 4:
                        break;
                    case 5:
                        break;
                    case 6:
                        break;
                    default:
                        funciones.OpcionNoExistente();
                        break;
                }

            } while (menuPrincipal != 0);
        }

        if(asignado == asignaturas.asignatura[1])
        {
            do
            {

            }while(menu);
        }
   // }
    //catch(Exception erorr)
    //{
     //   Console.WriteLine($"Ocurrio un error!: {erorr.Message}");
     //   Thread.Sleep(2000);
    //}
} while (menu);

public class DatosGlobales
{
   public string[] asignatura = { "Administrador", "Trabajador" }, producto = { "Libreria", "Tienda" }, estado = { "Activo", "Inactivo" };
   public static string usuarioActivo = "";
        
}