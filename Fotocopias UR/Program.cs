using Fotocopias_UR;
using static System.Runtime.InteropServices.JavaScript.JSType;

Menus menus = new Menus();
Funciones funciones = new Funciones();
Inventario inventario = new Inventario();
bool menu = true;
string[] asignaturas = { "Administrador", "Trabajador" }, producto = { "Libreria", "Tienda" }, estado = { "Activo", "Inactivo" };
do
{ 
    try
    {
        inventario.CrearTablaLibreria();
        inventario.CrearTablaTienda();
        int menuPrincipal, subMenus, opcion;
        string asignado = asignaturas[0];
        menu = true;
        if (asignado == asignaturas[0])
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
                                                inventario.AgregarProductos(funciones.IngresoProductos(producto[0],estado[0]));
                                                break;

                                            case 2:
                                                Console.WriteLine("--- Tienda ---");
                                                inventario.AgregarProductos(funciones.IngresoProductos(producto[1],estado[0]));
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
                                                Console.Write("Busacr:");
                                                eliminarProducto = Console.ReadLine();
                                                inventario.EliminarProductoLibreria(eliminarProducto);
                                                Console.WriteLine("\nPrecione culquier tecla para continuar");
                                                Console.ReadKey();
                                                break;

                                            case 2:
                                                Console.Write("Busacr:");
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
                                    break;
                                case 2:
                                    break;
                                case 3:
                                    break;
                                case 4:
                                    break;

                                default:
                                    funciones.OpcionNoExistente();
                                    break;
                            }
                        } while (subMenus != 0);
                        break;

                    case 3:
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

        if(asignado == asignaturas[1])
        {
            do
            {

            }while(menu);
        }
    }
    catch(Exception erorr)
    {
        Console.WriteLine($"Ocurrio un error!: {erorr.Message}");
        Thread.Sleep(2000);
    }
} while (menu);