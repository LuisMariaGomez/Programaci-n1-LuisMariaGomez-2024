using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEntidades.Entidades
{
    public class CopiaLibro
    {
        public int IdCopiaLibro { get; set; }
        public float PrecioPrestamo { get; set; }
        public Libro Libro { get; set; }
        public ICollection<Prestamo> Prestamos { get; set; }    // relacion 1:n con Libro

    }
}
