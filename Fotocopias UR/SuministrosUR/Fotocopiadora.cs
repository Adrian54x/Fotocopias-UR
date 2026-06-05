using Fotocopias_UR.ArgumentosUR;
using Fotocopias_UR.GeneralUR;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace Fotocopias_UR.FotocopiadoraUR
{
    internal class Fotocopiadora
    {
        private string conexionFotocopiadora = "Data Source = Fotocopiadora";
        private string sqlF = "";
        private DatosGlobales g = new DatosGlobales();

        //Crear Tablas

        public void CrearTablaToner()
        {
            using (SQLiteConnection ctT = new SQLiteConnection(conexionFotocopiadora))
            {
                ctT.Open();
                string sqlIE = @"CREATE TABLE IF NOT EXISTS Toner(Codigo INTEGER PRIMARY KEY AUTOINCREMENT, CantidadCopias INTEGER NOT NULL);";
                SQLiteCommand crearToner = new SQLiteCommand(sqlIE, ctT);
                crearToner.ExecuteNonQuery();
            }
        }

        public void CrearTablaResmas()
        {
            using (SQLiteConnection ctR = new SQLiteConnection(conexionFotocopiadora))
            {
                ctR.Open();
                string sqlIE = @"CREATE TABLE IF NOT EXISTS Resma(Codigo INTEGER PRIMARY KEY AUTOINCREMENT, CantidadHojas INTEGER NOT NULL);";
                SQLiteCommand crearResma = new SQLiteCommand(sqlIE, ctR);
                crearResma.ExecuteNonQuery();
            }
        }

        public void CrearTablaCopias()
        {
            using (SQLiteConnection ctC = new SQLiteConnection(conexionFotocopiadora))
            {
                ctC.Open();
                string sqlIE = @"CREATE TABLE IF NOT EXISTS Copias(Codigo INTEGER PRIMARY KEY AUTOINCREMENT, CopiasTotales INTEGER NOT NULL, Fecha TEXT);";
                SQLiteCommand crearCopias = new SQLiteCommand(sqlIE, ctC);
                crearCopias.ExecuteNonQuery();
            }
        }

        //Contar copias

        public int ContarCopias()
        {
            int cantidad;
            using (SQLiteConnection cc = new SQLiteConnection(conexionFotocopiadora))
            {
                cc.Open();
                string contarCopias = "SELECT COUNT(*) FROM Copias";
                SQLiteCommand comandoContar = new SQLiteCommand(contarCopias, cc);
                cantidad = int.Parse(comandoContar.ExecuteScalar().ToString());
            }
            return cantidad;
        }

        //Agregar suministros

        public void AgregarCopias(int copias, string fecha)
        {
            sqlF = "INSERT INTO Copias(CopiasTotales, Fecha) VALUES(@copias, @fecha)";
            using (SQLiteConnection agc = new SQLiteConnection(conexionFotocopiadora))
            {
                agc.Open();
                SQLiteCommand comandoAgregar = new SQLiteCommand(sqlF, agc);
                comandoAgregar.Parameters.AddWithValue("@copias", copias);
                comandoAgregar.Parameters.AddWithValue("@fecha", fecha);
                comandoAgregar.ExecuteNonQuery();
            }
        }

        public void AgregarSuministro(string tipo, int vidaUtil, int cantidad)
        {
            if(tipo == g.suministro[0])
            {
               sqlF = "INSERT INTO Toner(CantidadCopias) VALUES(@cantidad)";
            }
            if(tipo == g.suministro[1])
            {
                sqlF = "INSERT INTO Resma(CantidadHojas) VALUES(@cantidad)";
            }
            for (int i = 0; i < cantidad; i++)
            {
                using (SQLiteConnection ags = new SQLiteConnection(conexionFotocopiadora))
                {
                    ags.Open();
                    SQLiteCommand comandoAgregar = new SQLiteCommand(sqlF, ags);
                    comandoAgregar.Parameters.AddWithValue("@cantidad", vidaUtil);
                    comandoAgregar.ExecuteNonQuery();
                }
            }
        }

        //Ver suministros

        public void VerSuministros(string tipo)
        {
            if (tipo == g.suministro[0])
            {
                sqlF = "SELECT * FROM Toner";
            }
            if (tipo == g.suministro[1])
            {
                sqlF = "SELECT * FROM Resma";
            }
            int cont = 1;
            using (SQLiteConnection ms = new SQLiteConnection(conexionFotocopiadora))
            {
                ms.Open();
                SQLiteCommand comandoMostrarS = new SQLiteCommand(sqlF, ms);
                SQLiteDataReader mostrarSuministros = comandoMostrarS.ExecuteReader();
                if (tipo == g.suministro[0])
                {
                    while (mostrarSuministros.Read())
                    {
                        Console.WriteLine($"Codigo:{cont++} | Capacidad de copias:{mostrarSuministros["CantidadCopias"]}");
                        Console.WriteLine();
                    }
                }
                else
                {
                    while (mostrarSuministros.Read())
                    {
                        Console.WriteLine($"Codigo:{cont++} | Cantidad de hojas:{mostrarSuministros["CantidadHojas"]}");
                        Console.WriteLine();
                    }
                }
            }
        }

        public void VerFotocopiasSacadas()
        {
            sqlF = "SELECT * FROM Copias WHERE Codigo != 1";
            int cont = 1;
            using (SQLiteConnection ms = new SQLiteConnection(conexionFotocopiadora))
            {
                ms.Open();
                SQLiteCommand comandoMostrarS = new SQLiteCommand(sqlF, ms);
                SQLiteDataReader mostrarSuministros = comandoMostrarS.ExecuteReader();
                while (mostrarSuministros.Read())
                {
                        Console.WriteLine($"Codigo:{cont++} | Fecha:{mostrarSuministros["Fecha"]} " +
                            $"| Copias sacadas:{mostrarSuministros["CopiasTotales"]}");
                        Console.WriteLine();
                }
            }
        }

        // Modificar copias

        public void ModificarCopiasTotales(int copias)
        {
            sqlF = "UPDATE Copias SET CopiasTotales = @copiasTotales WHERE Codigo = 1";
            using (SQLiteConnection md = new SQLiteConnection(conexionFotocopiadora))
            {
                md.Open();
                using (SQLiteCommand comandoRemplazar = new SQLiteCommand(sqlF, md))
                {
                    comandoRemplazar.Parameters.AddWithValue("@copiasTotales", copias);
                    comandoRemplazar.ExecuteNonQuery();
                }
            }
        }

        //Extraer Copias totales

        public int ExtraerCopiasTotales()
        {
            int copiasTotales = 0;
            sqlF = "SELECT CopiasTotales FROM Copias WHERE Codigo = 1";
            using (SQLiteConnection ect = new SQLiteConnection(conexionFotocopiadora))
            {
                ect.Open();
                using (SQLiteCommand comandoExtraer = new SQLiteCommand(sqlF, ect))
                {
                    using (SQLiteDataReader extraer = comandoExtraer.ExecuteReader())
                    {
                        if (extraer.Read())
                        {
                            copiasTotales = int.Parse(extraer["CopiasTotales"].ToString());
                        }
                    }
                }
            }
            return copiasTotales;
        }

    }
}
