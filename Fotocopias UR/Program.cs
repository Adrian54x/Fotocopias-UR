using Fotocopias_UR.ArgumentosUR;
using Fotocopias_UR.FotocopiadoraUR;
using Fotocopias_UR.GeneralUR;
using Fotocopias_UR.ProductosUR;
using Fotocopias_UR.UsuariosUR;
using System.Diagnostics;
using static System.Runtime.InteropServices.JavaScript.JSType;

DatosGlobales asignaturas = new DatosGlobales();
Menus menus = new Menus();
Funciones funciones = new Funciones();
Inventario inventario = new Inventario();
Usuario usuario = new Usuario();
Argumentos argumentos = new Argumentos();
Fotocopiadora fotocopias = new Fotocopiadora();
bool menu = true;
do
{ 
    try
    {
        inventario.CrearTablaLibreria();
        inventario.CrearTablaTienda();
        usuario.CrearTablaAdmisitrador();
        usuario.CrearTablaTrabajador();
        argumentos.CrearTablaComentarios();
        argumentos.CrearTablasIngresosEgresos();
        fotocopias.CrearTablaToner();
        fotocopias.CrearTablaResmas();
        fotocopias.CrearTablaCopias();
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
            Console.WriteLine("Operacion realizada!");
            Thread.Sleep(300);
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
                                                Console.WriteLine("Operacion realizada!");
                                                Thread.Sleep(300);
                                                break;

                                            case 2:
                                                Console.WriteLine("--- Tienda ---");
                                                inventario.AgregarProductos(funciones.IngresoProductos(asignaturas.producto[1], asignaturas.estado[0]));
                                                Console.WriteLine("Operacion realizada!");
                                                Thread.Sleep(300);
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
                                                Console.WriteLine("Operacion realizada!");
                                                Thread.Sleep(300);
                                                break;
                                            case 2:
                                                Console.WriteLine("--- Trabajador ---");
                                                usuario.AgregarUsuario(funciones.IngresoUsuarios(asignaturas.asignatura[1]));
                                                Console.WriteLine("Operacion realizada!");
                                                Thread.Sleep(300);
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
                                                    if (DatosGlobales.usuarioActivoCodigo != eliminarAdmin)
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
                                        Console.WriteLine("--- Agregar Ingresos y Egresos ---");
                                        menus.OpcionIngresosEgresos();
                                        opcion = funciones.ValidarMenu();
                                        Console.Clear();
                                        switch (opcion)
                                        {
                                            case 0:
                                                funciones.Regresar();
                                                break;
                                            case 1:
                                                Console.WriteLine("--- Ingresos ---");
                                                argumentos.AgregarIngresosEgresosOComentarios(asignaturas.comentarios[1], funciones.IngresosEgresosYComentario(asignaturas.comentarios[1]));
                                                break;
                                            case 2:
                                            Console.WriteLine("--- Egresos ---");
                                            argumentos.AgregarIngresosEgresosOComentarios(asignaturas.comentarios[2], funciones.IngresosEgresosYComentario(asignaturas.comentarios[2]));
                                                break;
                                            default:
                                                funciones.OpcionNoExistente();
                                                break;
                                        }
                                    } while (opcion != 0);
                                    break;

                                case 2:
                                    Console.WriteLine("--- Ver resumen de ingresos y egresos ---");
                                    Console.WriteLine("\n*** Ingresos ***");
                                    argumentos.MostrarIngresosEgresosYComentarios(asignaturas.comentarios[1]);
                                    Console.WriteLine("\n*** Egresos ***");
                                    argumentos.MostrarIngresosEgresosYComentarios(asignaturas.comentarios[2]);
                                    Console.WriteLine("\n*** Resumen ***");
                                    Console.WriteLine($"Total Ingresos:Q{argumentos.ExtraerIngresosEgresos(asignaturas.comentarios[1])}");
                                    Console.WriteLine($"Total Egresos:Q{argumentos.ExtraerIngresosEgresos(asignaturas.comentarios[2])}");
                                    Console.WriteLine($"Total:Q{argumentos.ExtraerIngresosEgresos(asignaturas.comentarios[1]) - argumentos.ExtraerIngresosEgresos(asignaturas.comentarios[2])}");
                                    Console.WriteLine("\nPrecione culquier tecla para continuar");
                                    Console.ReadKey();
                                    break;

                                case 3:
                                    do
                                    {
                                        Console.Clear();
                                        Console.WriteLine("-- Eliminar Ingreso o Egreso ---");
                                        menus.OpcionIngresosEgresos();
                                        opcion = funciones.ValidarMenu();
                                        Console.Clear();
                                        switch(opcion)
                                        {
                                            case 0:
                                                funciones.Regresar();
                                                break;
                                            case 1:
                                                Console.WriteLine("--- Ingresos ---");
                                                Console.Write("Codigo:");
                                                string eliminarIngreso = Console.ReadLine();
                                                argumentos.EliminarIngresoEgresoYComentario(eliminarIngreso, asignaturas.comentarios[1]);
                                                Console.WriteLine("\nPrecione culquier tecla para continuar");
                                                Console.ReadKey();
                                                break;
                                            case 2:
                                                Console.WriteLine("--- Egresos ---");
                                                Console.Write("Codigo:");
                                                string eliminarEgreso = Console.ReadLine();
                                                argumentos.EliminarIngresoEgresoYComentario(eliminarEgreso, asignaturas.comentarios[2]);
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

                    case 4:
                        do
                        {
                            Console.Clear();
                            menus.MenuFotocopiadora();
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
                                        menus.OpcionSuministros();
                                        opcion = funciones.ValidarMenu();
                                        Console.Clear();
                                        int cantidad;
                                        switch (opcion)
                                        { 
                                            case 0:
                                                funciones.Regresar();
                                                break;

                                            case 1:
                                                Console.WriteLine("--- Agregar suministro ---");
                                                Console.Write("Suministro a agregar (1.Toner / 2.Resma):");
                                                int tipo = funciones.RangoEnteros(1,2);
                                            if (tipo == 1)
                                            {
                                                Console.Write("Cantidad de copias de Toner:");
                                            }
                                            else
                                            {
                                                Console.Write("Cantidad de hojas:");
                                            }
                                                int agregar = funciones.RangoEnteros(10,10000);
                                                Console.Write("Unidades:");
                                                int cantidadSuministro = funciones.RangoEnteros(1, 100);
                                                fotocopias.AgregarSuministro(asignaturas.suministro[tipo-1],agregar,cantidadSuministro);
                                                break;

                                            case 2:
                                                Console.WriteLine("--- Ver suministros ---");
                                                Console.WriteLine("\n*** Toner ***");
                                                fotocopias.VerSuministros(asignaturas.suministro[0]);
                                                Console.WriteLine("\n*** Resmas ***");
                                                fotocopias.VerSuministros(asignaturas.suministro[1]);
                                            Console.WriteLine("\nPrecione culquier tecla para continuar");
                                            Console.ReadKey();
                                            break;

                                            default:
                                                funciones.OpcionNoExistente();
                                                break;
                                        }
                                    } while (opcion != 0);
                                    break;

                                case 2:
                                    do
                                    {
                                        Console.Clear();
                                        menus.OpcionFotocopias();
                                        opcion = funciones.ValidarMenu();
                                        Console.Clear();
                                        switch(opcion)
                                        {
                                            case 0:
                                                funciones.Regresar();
                                                break;
                                            case 1:
                                                Console.WriteLine("--- fotocopias totales ---");
                                                int copias;
                                                funciones.ColorComentario("(Son todas las copias que a sacado durante toda su vida util)");
                                                if (fotocopias.ContarCopias() == 0)
                                                {
                                                    Console.Write("Fotocopias totales:");
                                                    copias = funciones.ValidarMenu();
                                                    fotocopias.AgregarCopias(copias, "");
                                                }
                                                else
                                                {
                                                    bool seguro;
                                                    do
                                                    {
                                                        Console.Write("¿Seguro que quiere modificar la cantidad de copias totales?(Si/No):");
                                                        seguro = funciones.SIoNO();
                                                    } while (seguro);
                                                    if(seguro)
                                                    {
                                                        Console.Write("Fotocopias totales nevas:");
                                                        copias = funciones.ValidarMenu();
                                                        fotocopias.ModificarCopiasTotales(copias);
                                                    }
                                                    else
                                                    {
                                                        funciones.Regresar();
                                                    }
                                            }
                                            break;

                                            case 2:
                                                Console.WriteLine("--- fotocopias sacadas por semana ---");
                                                funciones.ColorComentario("Fecha del dia que se sacaron las copias ejemplo: 28/8/2000");
                                                Console.Write("Fecha:");
                                                DateTime fechaCopia = funciones.FechaArgumento();
                                                int fotocopiasAbsolutas = fotocopias.ExtraerCopiasTotales();
                                                funciones.ColorComentario("(Fotocopias totales que dice la hoja de estado) \n(la cantidad no puede ser menor a la ya establecida)");
                                                Console.Write("fotocopias Totales:");
                                                int fotocopiasNuevas = funciones.RangoEnteros(fotocopiasAbsolutas, fotocopiasAbsolutas*1000);
                                                Console.WriteLine($"Fotocopias sacadas en total:{fotocopiasNuevas - fotocopiasAbsolutas}");
                                                fotocopias.ModificarCopiasTotales(fotocopiasNuevas);
                                                fotocopias.AgregarCopias(fotocopiasNuevas - fotocopiasAbsolutas, fechaCopia.ToString());
                                                break;

                                            case 3:
                                                Console.WriteLine("--- Ver fotocopias sacadas por semana ---");
                                                fotocopias.VerFotocopiasSacadas();
                                                Console.WriteLine("\nPrecione culquier tecla para continuar");
                                                Console.ReadKey();
                                                break;

                                            default:
                                            funciones.OpcionNoExistente();
                                            break;
                                        }
                                    } while (opcion != 0);
                                    break;

                                case 3:
                                default:
                                funciones.OpcionNoExistente();
                                    break;
                            }
                        } while (subMenus != 0);
                        break;

                    case 5:
                        do 
                        {
                            Console.Clear();
                            menus.MenuComentarios();
                            subMenus = funciones.ValidarMenu();
                            Console.Clear();
                            switch (subMenus)
                            {
                                case 0:
                                    funciones.Regresar();
                                    break;

                                case 1:
                                    Console.WriteLine("--- Ver Comentarios ---");
                                    argumentos.MostrarIngresosEgresosYComentarios(asignaturas.comentarios[0]);
                                    Console.WriteLine("\nPrecione culquier tecla para continuar");
                                    Console.ReadKey();
                                    break;

                                case 2:
                                    Console.WriteLine("--- Enviar Comentarios ---");
                                    argumentos.AgregarIngresosEgresosOComentarios(asignaturas.comentarios[0], funciones.IngresosEgresosYComentario(asignaturas.comentarios[0]));
                                    break;

                                default:
                                    funciones.OpcionNoExistente();
                                    break;
                            }
                        } while (subMenus != 0);
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
                Console.Clear();
                menus.MenuTrabajador();
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
                        if (inventario.ContarProductosLibreria() == 0 && inventario.ContarProductosTienda() == 0)
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

                    case 2:
                        Console.WriteLine("--- Administrar Ventas ---");
                        Console.Write("Que porducto vendio(1.Libreria / 2.Tienda):");
                        int tipoProducto = funciones.RangoEnteros(1,2);
                        Console.Write("Clave del porducto:");
                        string claveProducto = Console.ReadLine();
                        if (tipoProducto == 1 && inventario.BuscarProductoLibreria(claveProducto) || tipoProducto == 2 && inventario.BuscarProductoTienda(claveProducto))
                        {
                            funciones.ColorComentario("No puede exeder la cantidad disponible");
                            Console.Write("Cantidad de ventas:");
                            int cantidadActual = inventario.ExtraerCantidadProducto(asignaturas.producto[tipoProducto - 1], claveProducto);
                            int cantidadVentas = funciones.RangoEnteros(1, cantidadActual);
                            int total = cantidadActual -cantidadVentas;
                            inventario.ModificarProducto(asignaturas.producto[tipoProducto - 1], claveProducto,total);
                        }
                        else
                        {
                            Console.WriteLine("Producto no encontrado!");
                            Console.WriteLine("\nPrecione culquier tecla para continuar");
                            Console.ReadKey();
                        }
                        break;

                    case 3:
                        do
                        {
                            Console.Clear();
                            menus.MenuComentarios();
                            subMenus = funciones.ValidarMenu();
                            Console.Clear();
                            switch (subMenus)
                            {
                                case 0:
                                    funciones.Regresar();
                                    break;

                                case 1:
                                    Console.WriteLine("--- Ver Comentarios ---");
                                    argumentos.MostrarIngresosEgresosYComentarios(asignaturas.comentarios[0]);
                                    Console.WriteLine("\nPrecione culquier tecla para continuar");
                                    Console.ReadKey();
                                    break;

                                case 2:
                                    Console.WriteLine("--- Enviar Comentarios ---");
                                    argumentos.AgregarIngresosEgresosOComentarios(asignaturas.comentarios[0], funciones.IngresosEgresosYComentario(asignaturas.comentarios[0]));
                                    break;

                                default:
                                    funciones.OpcionNoExistente();
                                    break;
                            }
                        } while (subMenus != 0);
                        break;

                    default:
                        funciones.OpcionNoExistente();
                        break;
                }
            }while(menu);
        }
   }
   catch(Exception erorr)
   {
       Console.WriteLine($"Ocurrio un error!: {erorr.Message}");
       Thread.Sleep(2000);
  }
} while (menu);