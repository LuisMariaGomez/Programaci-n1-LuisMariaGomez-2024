using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEntidades.Entidades
{
    public class Autor
    {
        public int IdAutor { get; set; }
        public string Biografia { get; set; }
        public Persona Persona { get; set; }
        public ICollection<Libro> Libros { get; set; }

        public Autor( string biografia, Persona persona)
        {
            Biografia = biografia;
            Persona = persona;
            Libros = new List<Libro>();
        }
    }
}
