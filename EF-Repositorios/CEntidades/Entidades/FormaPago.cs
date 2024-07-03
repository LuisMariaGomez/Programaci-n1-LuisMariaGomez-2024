using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEntidades.Entidades
{
    public class FormaPago
    {
        public int IdFormaPago { get; set; }
        public string Descripcion { get; set; }
        public ICollection<Prestamo> Prestamos { get; set; }// relacion 1:n con prestamo
        public ICollection<Venta> Venta { get; set; }// relacion 1:n con Venta
    }
}
