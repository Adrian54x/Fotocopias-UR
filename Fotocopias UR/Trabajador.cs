using System;
using System.Collections.Generic;
using System.Text;

namespace Fotocopias_UR
{
    internal class Trabajador: Administrador
    {
        private string numeroTelefono;

        public string NumeroTelefono
        {
            get { return numeroTelefono; }
            set 
            {
                string telefonoNumero = "0123456987";
                bool validarTelefono = true;
                foreach (char c in value)
                {
                    if (!telefonoNumero.Contains(c))
                    {
                        validarTelefono = false;
                        break;
                    }
                }
                if (validarTelefono && value.Length >= 8)
                    numeroTelefono = value; 
                else
                    Console.WriteLine("Telefono no valido!");
            }
        }

        public Trabajador(string codigoUsuario, string nombreUsuario, string password, DateTime fechaNacimiento, string asignado, string numeroTelefono)
            : base(codigoUsuario, nombreUsuario, password, fechaNacimiento, asignado)
        {
            NumeroTelefono = numeroTelefono;
        }
    }
}
