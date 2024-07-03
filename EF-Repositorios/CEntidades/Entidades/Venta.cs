using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEntidades.Entidades
{
    public class Venta
    {
        public int IdVenta { get; set; }
        public DateTime FechaVenta { get; set; }
        public Cliente Cliente { get; set; }
        public Empleado Empleado { get; set; }
        public FormaPago FormaPago { get; set; }
        public ICollection<Libro> Libros { get; set; }    // relacion 1:n con Venta

    }
}
