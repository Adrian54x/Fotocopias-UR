using System;
using System.Collections.Generic;
using System.Text;

namespace Fotocopias_UR.UsuariosUR
{
    internal class Administrador
    {
        private string codigoUsuario;
        private string nombreUsuario;
        private string password;
        private DateTime fechaNacimiento;
        private string asignado;

        public string CodigoUsuario
        {
            get { return codigoUsuario; }
            set 
            { 
                if(value.StartsWith("UR0"))
                    codigoUsuario = value;
                else
                    Console.WriteLine("Codigo de usuario no valido!");
            }
        }

        public string NombreUsuario
        {
            get { return nombreUsuario; }
            set 
            {
                bool correcto = true;
                string validar = "AaBbCcDdEeFfGgHhIiJjKkLlMmNnÑñOoPpQqRrSsTtUuVvWwXxYyZzÚÓÍÉÁúóíéá ";
                foreach (char c in value)
                {
                    if (!validar.Contains(c))
                    {
                        correcto = false;
                        break;
                    }
                }
                if (value.Length >= 3 && correcto)
                    nombreUsuario = value; 
                else
                    Console.WriteLine("Nombre de usuario no valido!");
            }
        }

        public string Password
        {
            get { return password; }
            set 
            {
                string validarMayusculas = "ABCDEFGHIJKLMNÑOPQRSTUVWXYZÚÓÍÉÁ", validarNumeros = "1234567890";
                int numeros = 0, letras = 0;
                foreach (char c in value)
                {
                    if(validarMayusculas.Contains(c))
                    {
                        letras++;
                    }
                    if(validarNumeros.Contains(c))
                    {
                        numeros++;
                    }
                }
                if(value.Length >= 8 && value.Length <= 15 && numeros > 0 && letras > 0)
                    password = value; 
                else
                    Console.WriteLine("Contraseña no valida!");
            }
        }

        public DateTime FechaNacimiento
        {
            get { return fechaNacimiento; }
            set 
            {
                if (DateTime.TryParse(value.ToString(), out DateTime x) && (DateTime.Today.Year - value.Year) >= 14 && value.Year > 1925)
                    fechaNacimiento = value; 
                else
                    Console.WriteLine("Fecha de nacimiento no valida!");
            }
        }

        public string Asignado
        {
            get { return asignado; }
            set 
            { 
                if(value == "Administrador" || value == "Trabajador")
                    asignado = value; 
                else
                    Console.WriteLine("Asignatura no valida!");
            }
        }

        public Administrador(string codigoUsuario, string nombreUsuario, string password, DateTime fechaNacimiento, string asignado)
        {
            CodigoUsuario = codigoUsuario;
            NombreUsuario = nombreUsuario;
            Password = password;
            FechaNacimiento = fechaNacimiento;
            Asignado = asignado;
        }
    }
}
