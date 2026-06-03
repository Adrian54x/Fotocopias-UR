using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Text;

namespace Fotocopias_UR
{
    internal class Argumentos
    {
        private string conexionArgumentos = "Data Source = Argumentos";
        private DatosGlobales g = new DatosGlobales();

        public void CrearTablasIngresosEgresos()
        {
            using (SQLiteConnection ctIE = new SQLiteConnection(conexionArgumentos))
            {
                ctIE.Open();
                string sqlIE = @"CREATE TABLE IF NOT EXISTS Ingresos(Codigo INTEGER PRIMARY KEY AUTOINCREMENT, Fecha TEXT NOT NULL, Cantidad REAL NOT NULL, 
                                Motivo TEXT NOT NULL, Autor TEXT NOT NULL);";
                SQLiteCommand crearIE = new SQLiteCommand(sqlIE, ctIE);
                crearIE.ExecuteNonQuery();
            }

            using (SQLiteConnection ctIE = new SQLiteConnection(conexionArgumentos))
            {
                ctIE.Open();
                string sqlIE = @"CREATE TABLE IF NOT EXISTS Egresos(Codigo INTEGER PRIMARY KEY AUTOINCREMENT, Fecha TEXT NOT NULL, Cantidad REAL NOT NULL, 
                                Motivo TEXT NOT NULL, Autor TEXT NOT NULL);";
                SQLiteCommand crearIE = new SQLiteCommand(sqlIE, ctIE);
                crearIE.ExecuteNonQuery();
            }
        }

        public void CrearTablaComentarios()
        {
            using (SQLiteConnection ctC = new SQLiteConnection(conexionArgumentos))
            {
                ctC.Open();
                string sqlIE = @"CREATE TABLE IF NOT EXISTS Comentario(Codigo INTEGER PRIMARY KEY AUTOINCREMENT, Fecha TEXT NOT NULL, 
                                Motivo TEXT NOT NULL, Autor TEXT NOT NULL);";
                SQLiteCommand crearC = new SQLiteCommand(sqlIE, ctC);
                crearC.ExecuteNonQuery();
            }
        }

        public void AgregarIngresosEgresosOComentarios(string tipo, Comentarios datos)
        {
            DatosGlobales f = new DatosGlobales();
            string agrgar = "";
            if (tipo == f.comentarios[0])
            {
                agrgar = "INSERT INTO Comentario(Fecha, Motivo, Autor) VALUES(@fecha, @motivo, @autor);";
            }
            if(tipo == f.comentarios[1])
            {
                agrgar = "INSERT INTO Ingresos(Fecha, Cantidad, Motivo, Autor) VALUES(@fecha, @cantidad, @motivo, @autor);";
            }
            if(tipo == f.comentarios[2])
            {
                agrgar = "INSERT INTO Egresos(Fecha, Cantidad, Motivo, Autor) VALUES(@fecha, @cantidad, @motivo, @autor);";
            }
            using (SQLiteConnection aiec = new SQLiteConnection(conexionArgumentos))
            {
                aiec.Open();
                SQLiteCommand comandoAgregar = new SQLiteCommand(agrgar, aiec);
                comandoAgregar.Parameters.AddWithValue("@fecha", datos.Fecha);
                comandoAgregar.Parameters.AddWithValue("@motivo", datos.Movito);
                comandoAgregar.Parameters.AddWithValue("@autor", datos.Autor);
                if (datos is IngresoEgreso ie)
                { 
                    comandoAgregar.Parameters.AddWithValue("@cantidad", ie.Cantidad);
                }
                comandoAgregar.ExecuteNonQuery();

            }
        }

        public void MostrarIngresosEgresosYComentarios(string tipo)
        {
            string mostrar = "";
            if (tipo == g.comentarios[0])
            {
                mostrar = "SELECT * FROM Comentario";
            }
            if(tipo == g.comentarios[1])
            {
                mostrar = "SELECT * FROM Ingresos";
            }
            if(tipo == g.comentarios[2])
            {
                mostrar = "SELECT * FROM Egresos";
            }
            using (SQLiteConnection miec = new SQLiteConnection(conexionArgumentos))
            {
                miec.Open();            
                SQLiteCommand comandoMostrarMIEC = new SQLiteCommand(mostrar, miec);
                SQLiteDataReader mostrarMIEC = comandoMostrarMIEC.ExecuteReader();
                if (tipo == g.comentarios[0])
                {
                    while (mostrarMIEC.Read())
                    {
                        Console.WriteLine($"Codigo:{mostrarMIEC["Codigo"]} | Fecha:{mostrarMIEC["Fecha"]} | Motivo:{mostrarMIEC["Motivo"]} | Echo por:{mostrarMIEC["Autor"]}");
                        Console.WriteLine();
                    }
                }
                else
                {
                    while (mostrarMIEC.Read())
                    {
                        Console.WriteLine($"Codigo:{mostrarMIEC["Codigo"]} | Fecha:{mostrarMIEC["Fecha"]} | Cantidad:Q{mostrarMIEC["Cantidad"]} | Motivo:{mostrarMIEC["Motivo"]} " +
                            $"| Echo por:{mostrarMIEC["Autor"]}");                        
                        Console.WriteLine();
                    }
                }
            }
        }

        public double ExtraerIngresosEgresos(string tipo)
        {
            double ingresoEgreso = 0;
            string extraer = "";
            if(tipo == g.comentarios[1])
            {
                extraer = "SELECT * FROM Ingresos";
            }
            if(tipo == g.comentarios[2])
            {
                extraer = "SELECT * FROM Egresos";
            }
            using(SQLiteConnection eie = new SQLiteConnection(conexionArgumentos))
            {
                eie.Open();
                SQLiteCommand comandoExtraer = new SQLiteCommand(extraer, eie);
                SQLiteDataReader mostrarrIE = comandoExtraer.ExecuteReader();
                while (mostrarrIE.Read())
                {
                    ingresoEgreso +=  double.Parse(mostrarrIE["Cantidad"].ToString());
                }
            }
            return ingresoEgreso;
        }

        public void EliminarIngresoEgresoYComentario(string codigo, string tipo)
        {
            string eliminar = "";
            if (tipo == g.comentarios[0])
            {
                eliminar = "DELETE FROM Comentario WHERE Codigo = @codigo";
            }
            if (tipo == g.comentarios[1])
            {
                eliminar = "DELETE FROM Ingresos WHERE Codigo = @codigo";
            }
            if (tipo == g.comentarios[2])
            {
                eliminar = "DELETE FROM Egresos WHERE Codigo = @codigo";
            }
            using (SQLiteConnection eiec = new SQLiteConnection(conexionArgumentos))
            {
                eiec.Open();
                SQLiteCommand comandoEliminarEIEC = new SQLiteCommand(eliminar, eiec);
                comandoEliminarEIEC.Parameters.AddWithValue("@codigo", codigo);
                int verificarEliminado = comandoEliminarEIEC.ExecuteNonQuery();
                if (verificarEliminado > 0)
                {
                    if (tipo == g.comentarios[0])
                        Console.WriteLine("Se elimino el comentario!");
                    if (tipo == g.comentarios[1])
                        Console.WriteLine("Se elimino el Ingreso!");
                    if (tipo == g.comentarios[2])
                        Console.WriteLine("Se elimino el Egreso!");
                }
                else
                    Console.WriteLine("Codigo no existente!");
            }
        }

    }
}
