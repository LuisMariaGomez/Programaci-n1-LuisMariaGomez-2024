using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace CEntidades.Entidades
{
    public class Persona
    {
        public int IdPersona { get; set; }
        public string? Documento { get; set; }
        public string? TipoDocumento { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string? Telefono { get; set; }
        public string? Nacionalidad { get; set; }
        public string? Email { get; set; }
        public Autor? Autor { get; set; }
        public Cliente? Cliente { get; set; }
        public Empleado? Empleado { get; set; }

        public Persona(string Nombre, string Apellido) { 
            this.Nombre = Nombre;
            this.Apellido = Apellido;
        }
        public Persona(string Documento, string TipoDocumento, string Nombre, string Apellido, string Telefono, string Nacionalidad, string Email)
        {
            this.Documento = Documento; 
            this.TipoDocumento = TipoDocumento;
            this.Nombre = Nombre;
            this.Apellido = Apellido;
            this.Telefono = Telefono;
            this.Nacionalidad = Nacionalidad;
            this.Email = Email;
        }
    }
}
