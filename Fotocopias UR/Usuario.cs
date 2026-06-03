using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Fotocopias_UR
{
    internal class Usuario
    {
        private string sql, conexionU;
        private string conexionAdministrador = "Data Source = Administrador.db";
        private string conexionTrabajador = "Data Source = Trabajador.db";
        private DatosGlobales asignaturasU = new DatosGlobales();

        //Crear tablas
        public void CrearTablaAdmisitrador()
        {
            using (SQLiteConnection cta = new SQLiteConnection(conexionAdministrador))
            {
                cta.Open();
                string sqlAdministrador = @"CREATE TABLE IF NOT EXISTS Admins(Codigo TEXT PRIMARY KEY NOT NULL, Nombre TEXT NOT NULL, Password TEXT NOT NULL, 
                                            FechaNacimiento TEXT NOT NULL, Asignatura TEXT NOT NULL);";
                SQLiteCommand crearLibreria = new SQLiteCommand(sqlAdministrador, cta);
                crearLibreria.ExecuteNonQuery();
            }
        }

        public void CrearTablaTrabajador()
        {
            using (SQLiteConnection ctt = new SQLiteConnection(conexionTrabajador))
            {
                ctt.Open();
                string sqlAdministrador = @"CREATE TABLE IF NOT EXISTS Trabajador(Codigo TEXT PRIMARY KEY NOT NULL, Nombre TEXT NOT NULL, Password TEXT NOT NULL, 
                                            FechaNacimiento TEXT NOT NULL, Asignatura TEXT NOT NULL, NumeroTelefono INTEGER NOT NULL);";
                SQLiteCommand crearLibreria = new SQLiteCommand(sqlAdministrador, ctt);
                crearLibreria.ExecuteNonQuery();
            }
        }

        //Contar Usuario

        public int ContarAdministradores()
        {
            int cantidadAdmis;
            using (SQLiteConnection ca = new SQLiteConnection(conexionAdministrador))
            {
                ca.Open();
                string contarAdministradores = "SELECT COUNT(*) FROM Admins";
                SQLiteCommand comandoContarAdmins = new SQLiteCommand(contarAdministradores, ca);
                cantidadAdmis = int.Parse(comandoContarAdmins.ExecuteScalar().ToString());
            }
            return cantidadAdmis;
        }

        public int ContarTrabajadores()
        {
            int cantidadTrabajadores;
            using (SQLiteConnection ct = new SQLiteConnection(conexionTrabajador))
            {
                ct.Open();
                string contarTrabajadores = "SELECT COUNT(*) FROM Trabajador";
                SQLiteCommand comandoContarTrabajador = new SQLiteCommand(contarTrabajadores, ct);
                cantidadTrabajadores = int.Parse(comandoContarTrabajador.ExecuteScalar().ToString());
            }
            return cantidadTrabajadores;
        }

        //Buscar Usuario

        public bool BuscarAdministrador(string codigo)
        {
            bool adminEncontrado = false;
            using (SQLiteConnection ba = new SQLiteConnection(conexionAdministrador))
            {
                ba.Open();
                string buscarCodigoAdmin = "SELECT * FROM Admins WHERE Codigo = @codigo";
                SQLiteCommand comandoBuscarA = new SQLiteCommand(buscarCodigoAdmin, ba);
                comandoBuscarA.Parameters.AddWithValue("@codigo", codigo);
                SQLiteDataReader buscarAdmin = comandoBuscarA.ExecuteReader();
                while (buscarAdmin.Read())
                {
                    adminEncontrado = true;
                }
            }
            return adminEncontrado;
        }

        public bool BuscarTrabajador(string codigo)
        {
            bool trabajadorEncontrado = false;
            using (SQLiteConnection bt = new SQLiteConnection(conexionTrabajador))
            {
                bt.Open();
                string buscarCodigoTrabajador = "SELECT * FROM Trabajador WHERE Codigo = @codigo";
                SQLiteCommand comandoBuscarT = new SQLiteCommand(buscarCodigoTrabajador, bt);
                comandoBuscarT.Parameters.AddWithValue("@codigo", codigo);
                SQLiteDataReader buscarTrabajador = comandoBuscarT.ExecuteReader();
                while (buscarTrabajador.Read())
                {
                    trabajadorEncontrado = true;
                }
            }
            return trabajadorEncontrado;
        }

        public bool BuscarValidacionAdmin(string nombre, string pass)
        {
            bool nombreYPassEncontradoA = false;
            using (SQLiteConnection bva = new SQLiteConnection(conexionAdministrador))
            {
                bva.Open();
                string buscarCodigoTrabajador = "SELECT * FROM Admins WHERE Nombre = @nombre AND Password = @password";
                SQLiteCommand comandoBuscarT = new SQLiteCommand(buscarCodigoTrabajador, bva);
                comandoBuscarT.Parameters.AddWithValue("@nombre", nombre);
                comandoBuscarT.Parameters.AddWithValue("@password", pass);
                SQLiteDataReader buscarTrabajador = comandoBuscarT.ExecuteReader();
                while (buscarTrabajador.Read())
                {
                    nombreYPassEncontradoA = true;
                }
            }
            return nombreYPassEncontradoA;
        }

        public bool BuscarValidacionTrabajador(string nombre, string pass)
        {
            bool nombreYPassEncontradoT = false;
            using (SQLiteConnection bvt = new SQLiteConnection(conexionTrabajador))
            {
                bvt.Open();
                string buscarCodigoTrabajador = "SELECT * FROM Trabajador WHERE Nombre = @nombre AND Password = @password";
                SQLiteCommand comandoBuscarT = new SQLiteCommand(buscarCodigoTrabajador, bvt);
                comandoBuscarT.Parameters.AddWithValue("@nombre", nombre);
                comandoBuscarT.Parameters.AddWithValue("@password", pass);
                SQLiteDataReader buscarTrabajador = comandoBuscarT.ExecuteReader();
                while (buscarTrabajador.Read())
                {
                    nombreYPassEncontradoT = true;
                }
            }
            return nombreYPassEncontradoT;
        }

        //Agregar Usuario

        public void AgregarUsuario(Administrador usuario)
        {
            string agregarProducto, conexion;
            if (usuario is Trabajador)
            {
                agregarProducto = "INSERT INTO Trabajador(Codigo, Nombre, Password, FechaNacimiento, Asignatura, NumeroTelefono)" +
                        "VALUES(@codigo, @nombre, @password, @fechaNacimiento, @asignatura, @numeroTelefono)";
                conexion = conexionTrabajador;
            }
            else
            {
                agregarProducto = "INSERT INTO Admins(Codigo, Nombre, Password, FechaNacimiento, Asignatura)" +
                        "VALUES(@codigo, @nombre, @password, @fechaNacimiento, @asignatura)";
                conexion = conexionAdministrador;
            }
            using (SQLiteConnection ap = new SQLiteConnection(conexion))
            {
                ap.Open();
                SQLiteCommand comandoAgregar = new SQLiteCommand(agregarProducto, ap);
                comandoAgregar.Parameters.AddWithValue("@codigo", usuario.CodigoUsuario);
                comandoAgregar.Parameters.AddWithValue("@nombre", usuario.NombreUsuario);
                comandoAgregar.Parameters.AddWithValue("@password", usuario.Password);
                comandoAgregar.Parameters.AddWithValue("@fechaNacimiento", usuario.FechaNacimiento);
                comandoAgregar.Parameters.AddWithValue("@asignatura", usuario.Asignado);
                if (usuario is Trabajador trabajador)
                {
                    comandoAgregar.Parameters.AddWithValue("@numeroTelefono", trabajador.NumeroTelefono);
                }
                comandoAgregar.ExecuteNonQuery();

            }
        }

        //Mostrar Usuarios
        public void MostrarDatosAdmis()
        {
            using (SQLiteConnection mda = new SQLiteConnection(conexionAdministrador))
            {
                mda.Open();
                string mostrarA = "SELECT * FROM Admins";
                SQLiteCommand comandoMostrarA = new SQLiteCommand(mostrarA, mda);
                SQLiteDataReader mostrarAdmis = comandoMostrarA.ExecuteReader();
                Funciones f = new Funciones();
                while (mostrarAdmis.Read())
                {
                    Console.WriteLine($"Codigo:{mostrarAdmis["Codigo"]} | Nombre:{mostrarAdmis["Nombre"]} | Contraseña:{mostrarAdmis["Password"]} | Edad:{f.CalcularEdad(mostrarAdmis["FechaNacimiento"].ToString())}" +
                                      $"| Asignatura::{mostrarAdmis["Asignatura"]}");
                    Console.WriteLine();
                }
            }
        }

        public void MostrarDatosTrabajador()
        {
            using (SQLiteConnection mdt = new SQLiteConnection(conexionTrabajador))
            {
                mdt.Open();
                string mostrarT = "SELECT * FROM Trabajador";
                SQLiteCommand comandoMostrarT = new SQLiteCommand(mostrarT, mdt);
                SQLiteDataReader mostrarTrabajador = comandoMostrarT.ExecuteReader();
                Funciones f = new Funciones();
                while (mostrarTrabajador.Read())
                {
                    Console.WriteLine($"Codigo:{mostrarTrabajador["Codigo"]} | Nombre:{mostrarTrabajador["Nombre"]} | Contraseña:{mostrarTrabajador["Password"]} | Edad:{f.CalcularEdad(mostrarTrabajador["FechaNacimiento"].ToString())}" +
                                      $"| Asignatura:{mostrarTrabajador["Asignatura"]} | Numero de telefono:{mostrarTrabajador["NumeroTelefono"]}");
                    Console.WriteLine();
                }
            }
        }

        public void MostarEspesificoAdmin(string codigoEspecifico)
        {
            using (SQLiteConnection mea = new SQLiteConnection(conexionAdministrador))
            {
                mea.Open();
                string buscarCodigoA = "SELECT * FROM Admins WHERE Codigo = @codigo";
                SQLiteCommand comandoBuscarA = new SQLiteCommand(buscarCodigoA, mea);
                comandoBuscarA.Parameters.AddWithValue("@codigo", codigoEspecifico);
                SQLiteDataReader mostrarEspecificoAdmin = comandoBuscarA.ExecuteReader();
                Funciones f = new Funciones();
                while (mostrarEspecificoAdmin.Read())
                {
                    Console.WriteLine($"Codigo:{mostrarEspecificoAdmin["Codigo"]} | Nombre:{mostrarEspecificoAdmin["Nombre"]} | Contraseña:{mostrarEspecificoAdmin["Password"]} | Edad:{f.CalcularEdad(mostrarEspecificoAdmin["FechaNacimiento"].ToString())}" +
                                      $"| Asignatura:{mostrarEspecificoAdmin["Asignatura"]}");
                }
            }
        }

        public void MostarEspesificoTrabajador(string codigoEspecifico)
        {
            using (SQLiteConnection met = new SQLiteConnection(conexionAdministrador))
            {
                met.Open();
                string buscarCodigoT = "SELECT * FROM Trabajador WHERE Codigo = @codigo";
                SQLiteCommand comandoBuscarT = new SQLiteCommand(buscarCodigoT, met);
                comandoBuscarT.Parameters.AddWithValue("@codigo", codigoEspecifico);
                SQLiteDataReader mostrarEspecificoTrabajador = comandoBuscarT.ExecuteReader();
                Funciones f = new Funciones();
                while (mostrarEspecificoTrabajador.Read())
                {
                    Console.WriteLine($"Codigo:{mostrarEspecificoTrabajador["Codigo"]} | Nombre:{mostrarEspecificoTrabajador["Nombre"]} | Contraseña:{mostrarEspecificoTrabajador["Password"]} | Edad:{f.CalcularEdad(mostrarEspecificoTrabajador["FechaNacimiento"].ToString())}" +
                                      $"| Marca:{mostrarEspecificoTrabajador["Asignatura"]} | Numero de telefono:{mostrarEspecificoTrabajador["NumeroTelefono"]}");
                }
            }
        }

        //Eliminar 

        public void EliminarUsuario(string codigo, string asignatura)
        {
            conexionU = "";
            if(asignatura == asignaturasU.asignatura[0])
            {
                conexionU = conexionAdministrador;
                sql = "DELETE FROM Admins WHERE Codigo = @codigo";
            }
            else if(asignatura == asignaturasU.asignatura[1])
            {
                conexionU = conexionTrabajador;
                sql = "DELETE FROM Trabajador WHERE Codigo = @codigo";
            }
            else
            {
                Console.WriteLine("Erorr!");
            }
            if (asignatura == asignaturasU.asignatura[0] || asignatura == asignaturasU.asignatura[1])
            {
                using (SQLiteConnection eu = new SQLiteConnection(conexionU))
                {
                    eu.Open();
                    SQLiteCommand comandoEliminar = new SQLiteCommand(sql, eu);
                    comandoEliminar.Parameters.AddWithValue("@codigo", codigo);
                    int verificarEliminado = comandoEliminar.ExecuteNonQuery();
                    if (verificarEliminado > 0)
                        Console.WriteLine("Se elimino el usuario!");
                    else
                        Console.WriteLine("Usuario no encontrado");
                }
            }
        }

        //Extraer codigo Conectado
        public string ExtraerConectado(string nombre, string pass)
        {
            string codigo = "";
            using (SQLiteConnection ec = new SQLiteConnection(conexionAdministrador))
            {
                ec.Open();
                string buscarCodigo = "SELECT * FROM Admins WHERE Nombre = @nombre AND Password = @password";
                SQLiteCommand comandoBuscarC = new SQLiteCommand(buscarCodigo, ec);
                comandoBuscarC.Parameters.AddWithValue("@nombre", nombre);
                comandoBuscarC.Parameters.AddWithValue("@password", pass);
                SQLiteDataReader buscarAD = comandoBuscarC.ExecuteReader();
                while (buscarAD.Read())
                {
                    codigo = buscarAD["Codigo"].ToString();
                }
            }
            return codigo;
        }

    }
}
