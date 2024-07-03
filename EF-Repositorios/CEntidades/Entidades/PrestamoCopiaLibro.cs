using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEntidades.Entidades
{
    public class PrestamoCopiaLibro
    {
        public int IdPrestamoCopiaLibro { get; set; }
        public int IdPrestamo { get; set; }
        public int IdCopiaLibro { get; set; }
    }
}
