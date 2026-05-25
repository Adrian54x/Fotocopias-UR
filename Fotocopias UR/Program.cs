using Fotocopias_UR;

Menus menus = new Menus();
bool menu = true;
string[] asignaturas = { "Administrador", "Trabajador" }, producto = { "Libreria", "Tienda" };
do
{ 
    try
    {
        string asignado = asignaturas[0];
        if (asignado == asignaturas[0])
        menu = true;
        do
        {
            menus.MenuAdmin();
        } while (menu);
    }
    catch
    {
        Console.WriteLine("Ocurrio un error!");
    }
} while (menu);