using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Text;

namespace Fotocopias_UR
{
    internal class Inventario
    {
        private string conexionInventarioLibreria = "Data Source = Libreria.db";
        private string conexionInventarioTienda = "Data Source = Tienda.db";

        //Crear tablas
        public void CrearTablaLibreria()
        {
            using (SQLiteConnection ctl = new SQLiteConnection(conexionInventarioLibreria))
            {
                ctl.Open();
                string sqlLibreria = @"CREATE TABLE IF NOT EXISTS InventarioLibreria(Codigo TEXT PRIMARY KEY NOT NULL, Nombre TEXT NOT NULL, Precio REAL NOT NULL, 
                                       UnidadesDisponibles INTEGER NOT NULL, Marca TEXT NOT NULL, Asignatura TEXT NOT NULL, Descripcion TEXT , Estado TEXT NOT NULL);";
                SQLiteCommand crearLibreria = new SQLiteCommand(sqlLibreria,ctl);
                crearLibreria.ExecuteNonQuery();
            }
        }

        public void CrearTablaTienda()
        {
            using (SQLiteConnection ctl = new SQLiteConnection(conexionInventarioTienda))
            {
                ctl .Open();
                string sqlLibreria = @"CREATE TABLE IF NOT EXISTS InventarioTienda(Codigo TEXT PRIMARY KEY NOT NULL, Nombre TEXT NOT NULL, Precio REAL NOT NULL, 
                                       UnidadesDisponibles INTEGER NOT NULL, Marca TEXT NOT NULL, Asignatura TEXT NOT NULL, Descripcion TEXT , 
                                       Estado TEXT NOT NULL,FechaVencimiento TEXT NOT NULL);";
                SQLiteCommand crearTienda = new SQLiteCommand(sqlLibreria, ctl);
                crearTienda.ExecuteNonQuery();
            }
        }

        //Contar Productos

        public int ContarProductosLibreria()
        {
            int cantidadLibreria;
            using (SQLiteConnection cpl = new SQLiteConnection(conexionInventarioLibreria))
            {
                cpl.Open();
                string contarProductosLibreria = "SELECT COUNT(*) FROM InventarioLibreria";
                SQLiteCommand comandoContarLibreria = new SQLiteCommand(contarProductosLibreria, cpl);
                cantidadLibreria = int.Parse(comandoContarLibreria.ExecuteScalar().ToString());
            }
            return cantidadLibreria;
        }

        public int ContarProductosTienda()
        {
            int cantidadTienda;
            using (SQLiteConnection cpt = new SQLiteConnection(conexionInventarioTienda))
            {
                cpt.Open();
                string contarProductosTienda = "SELECT COUNT(*) FROM InventarioTienda";
                SQLiteCommand comandoContarTienda = new SQLiteCommand(contarProductosTienda, cpt);
                cantidadTienda = int.Parse(comandoContarTienda.ExecuteScalar().ToString());
            }
            return cantidadTienda;
        }

        //Buscar Productos

        public bool BuscarProductoLibreria(string codigo)
        {
            bool codigoValidoLibreria = false;
            using (SQLiteConnection bpl = new SQLiteConnection(conexionInventarioLibreria))
            {
                bpl.Open();
                string buscarCodigoLibreria = "SELECT * FROM InventarioLibreria WHERE Codigo = @codigo";
                SQLiteCommand comandoBuscarL = new SQLiteCommand(buscarCodigoLibreria, bpl);
                comandoBuscarL.Parameters.AddWithValue("@codigo", codigo);
                SQLiteDataReader buscarLibreria = comandoBuscarL.ExecuteReader();
                while (buscarLibreria.Read())
                {
                    codigoValidoLibreria = true;
                }
            }
            return codigoValidoLibreria;
        }

        public bool BuscarProductoTienda(string codigo)
        {
            bool codigoValidoTienda = false;
            using (SQLiteConnection bpc = new SQLiteConnection(conexionInventarioTienda))
            {
                bpc.Open();
                string buscarCodigoTienda = "SELECT * FROM InventarioTienda WHERE Codigo = @codigo";
                SQLiteCommand comandoBuscarT = new SQLiteCommand(buscarCodigoTienda, bpc);
                comandoBuscarT.Parameters.AddWithValue("@codigo", codigo);
                SQLiteDataReader buscarTienda = comandoBuscarT.ExecuteReader();
                while (buscarTienda.Read())
                {
                    codigoValidoTienda = true;
                }
            }
            return codigoValidoTienda;
        }

        //Agregar Productos

        public void AgregarProductos(Libreria libreria)
        {
            string agregarProducto, conexion;
            if (libreria is Tienda)
            {
                agregarProducto = "INSERT INTO InventarioTienda(Codigo, Nombre, Precio, UnidadesDisponibles, Marca, Asignatura, Descripcion, Estado, FechaVencimiento)" +
                        "VALUES(@codigo, @nombre, @precio, @unidadesDisponibles, @marca, @asignatura, @descripcion, @estado, @fechaVencimiento)";
                conexion = conexionInventarioTienda;
            }
            else
            {
                agregarProducto = "INSERT INTO InventarioLibreria(Codigo, Nombre, Precio, UnidadesDisponibles, Marca, Asignatura, Descripcion, Estado)" +
                    "VALUES(@codigo, @nombre, @precio, @unidadesDisponibles, @marca, @asignatura, @descripcion, @estado)";
                conexion = conexionInventarioLibreria;
            }
            using (SQLiteConnection ap = new SQLiteConnection(conexion))
            {
                ap.Open();
                SQLiteCommand comandoAgregar = new SQLiteCommand(agregarProducto, ap);
                comandoAgregar.Parameters.AddWithValue("@codigo", libreria.CodigoProducto);
                comandoAgregar.Parameters.AddWithValue("@nombre", libreria.NombreProducto);
                comandoAgregar.Parameters.AddWithValue("@precio", libreria.Precio);
                comandoAgregar.Parameters.AddWithValue("@unidadesDisponibles", libreria.UnidadesDisponibles);
                comandoAgregar.Parameters.AddWithValue("@marca", libreria.Marca);
                comandoAgregar.Parameters.AddWithValue("@asignatura", libreria.Asignatura);
                comandoAgregar.Parameters.AddWithValue("@descripcion", libreria.Descripcion);
                comandoAgregar.Parameters.AddWithValue("@estado", libreria.Estado);
                if(libreria is Tienda tienda)
                {
                    comandoAgregar.Parameters.AddWithValue("@fechaVencimiento", tienda.FechaVencimiento.ToString());
                }
                comandoAgregar.ExecuteNonQuery();

            }
        }

        // Mostrar Productos

        public void MostarDatosLibreria()
        {
            using(SQLiteConnection mdl = new SQLiteConnection(conexionInventarioLibreria))
            {
                mdl.Open();
                string mostrarL = "SELECT * FROM InventarioLibreria";
                SQLiteCommand comandoMostrarL = new SQLiteCommand(mostrarL, mdl);
                SQLiteDataReader mostrarLibreria = comandoMostrarL.ExecuteReader();
                while(mostrarLibreria.Read()) 
                {
                    Console.WriteLine($"Codigo:{mostrarLibreria["Codigo"]} | Nombre:{mostrarLibreria["Nombre"]} | Precio:{mostrarLibreria["Precio"]} | Unidades disponibles:{mostrarLibreria["UnidadesDisponibles"]} " +
                                      $"| Marca:{mostrarLibreria["Marca"]} | Asignatura:{mostrarLibreria["Asignatura"]} \nDescripcion:{mostrarLibreria["Descripcion"]} | Estado:{mostrarLibreria["Estado"]}");
                    Console.WriteLine();
                }
            }
        }

        public void MostrarDatosTienda()
        {
            using(SQLiteConnection mdt = new SQLiteConnection(conexionInventarioTienda))
            {
                mdt.Open();
                string mostrarT = "SELECT * FROM InventarioTienda";
                SQLiteCommand comandoMostrarT = new SQLiteCommand(mostrarT, mdt);
                SQLiteDataReader mostrarTienda = comandoMostrarT.ExecuteReader();
                while (mostrarTienda.Read())
                {
                    Console.WriteLine($"Codigo:{mostrarTienda["Codigo"]} | Nombre:{mostrarTienda["Nombre"]} | Precio:{mostrarTienda["Precio"]} | Unidades disponibles:{mostrarTienda["UnidadesDisponibles"]} " +
                                               $"| Marca:{mostrarTienda["Marca"]} | Asignatura:{mostrarTienda["Asignatura"]} | Descripcion:{mostrarTienda["Descripcion"]} " +
                                               $"| Estado:{mostrarTienda["Estado"]} | Fecha de vencimiento:{mostrarTienda["FechaVencimiento"]}");
                    Console.WriteLine();
                }
            }
        }

        public void MostarEspesificoLibreria(string codigoEspecifico)
        {
            using (SQLiteConnection mel = new SQLiteConnection(conexionInventarioLibreria))
            {
                mel.Open();
                string buscarCodigoL = "SELECT * FROM InventarioLibreria WHERE Codigo = @codigo";
                SQLiteCommand comandoBuscarL = new SQLiteCommand(buscarCodigoL, mel);
                comandoBuscarL.Parameters.AddWithValue("@codigo", codigoEspecifico);
                SQLiteDataReader mostrarEspecificoLibreria = comandoBuscarL.ExecuteReader();
                while (mostrarEspecificoLibreria.Read())
                {
                    Console.WriteLine($"Codigo:{mostrarEspecificoLibreria["Codigo"]} | Nombre:{mostrarEspecificoLibreria["Nombre"]} | Precio:{mostrarEspecificoLibreria["Precio"]} | Unidades disponibles:{mostrarEspecificoLibreria["UnidadesDisponibles"]} " +
                                      $"| Marca:{mostrarEspecificoLibreria["Marca"]} | Asignatura:{mostrarEspecificoLibreria["Asignatura"]} \nDescripcion:{mostrarEspecificoLibreria["Descripcion"]} | Estado:{mostrarEspecificoLibreria["Estado"]}");
                }
            }
        }

        public void MostarEspesificoTienda(string codigoEspecifico)
        {
            using (SQLiteConnection met = new SQLiteConnection(conexionInventarioTienda))
            {
                met.Open();
                string buscarCodigoT = "SELECT * FROM InventarioTienda WHERE Codigo = @codigo";
                SQLiteCommand comandoBuscarT = new SQLiteCommand(buscarCodigoT, met);
                comandoBuscarT.Parameters.AddWithValue("@codigo", codigoEspecifico);
                SQLiteDataReader mostrarEspecificoTienda = comandoBuscarT.ExecuteReader();
                while (mostrarEspecificoTienda.Read())
                {
                    Console.WriteLine($"Codigo:{mostrarEspecificoTienda["Codigo"]} | Nombre:{mostrarEspecificoTienda["Nombre"]} | Precio:{mostrarEspecificoTienda["Precio"]} | Unidades disponibles:{mostrarEspecificoTienda["UnidadesDisponibles"]} " +
                                               $"| Marca:{mostrarEspecificoTienda["Marca"]} | Asignatura:{mostrarEspecificoTienda["Asignatura"]} | Descripcion:{mostrarEspecificoTienda["Descripcion"]} " +
                                               $"| Estado:{mostrarEspecificoTienda["Estado"]} | Fecha de vencimiento:{mostrarEspecificoTienda["FechaVencimiento"]}");
                }
            }
        }

        public void EliminarProductoLibreria(string codigo)
        {
            using (SQLiteConnection epl = new SQLiteConnection(conexionInventarioLibreria))
            {
                epl.Open();
                string elimimarProductoLibreria = "DELETE FROM InventarioLibreria WHERE Codigo = @codigo";
                SQLiteCommand comandoEliminarL = new SQLiteCommand(elimimarProductoLibreria, epl);
                comandoEliminarL.Parameters.AddWithValue("@codigo", codigo);
                int verificarEliminadoL = comandoEliminarL.ExecuteNonQuery();
                if (verificarEliminadoL > 0)
                    Console.WriteLine("Se elimino el producto!");
                else
                    Console.WriteLine("Producto no encontrado");
            }
        }

        public void EliminarProductoTienda(string codigo)
        {
            using (SQLiteConnection ept = new SQLiteConnection(conexionInventarioTienda))
            {
                ept.Open();
                string elimimarProductoTienda = "DELETE FROM InventarioTienda WHERE Codigo = @codigo";
                SQLiteCommand comandoEliminarT = new SQLiteCommand(elimimarProductoTienda, ept);
                comandoEliminarT.Parameters.AddWithValue("@codigo", codigo);
                int verificarEliminadoT = comandoEliminarT.ExecuteNonQuery();
                if (verificarEliminadoT > 0)
                    Console.WriteLine("Se elimino el producto!");
                else
                    Console.WriteLine("Producto no encontrado");
            }
        }
    }
}
