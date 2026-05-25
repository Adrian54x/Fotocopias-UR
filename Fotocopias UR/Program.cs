using Fotocopias_UR;

Menus menus = new Menus();
Funciones funciones = new Funciones();
bool menu = true;
string[] asignaturas = { "Administrador", "Trabajador" }, producto = { "Libreria", "Tienda" };
do
{ 
    try
    {
        int menuPrincipal, subMenus;
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
                        menus.MenuProductos();
                        break;
                    case 2:
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
    catch
    {
        Console.WriteLine("Ocurrio un error!");
    }
} while (menu);