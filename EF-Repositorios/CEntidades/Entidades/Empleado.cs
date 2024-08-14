using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEntidades.Entidades
{
    public class Empleado
    {
        public int IdEmpleado { get; set; }
        public string Cargo { get; set; }
        public DateTime FechaIngreso { get; set; }
        public string Sueldo { get; set; }
        public Persona Persona { get; set; }//Para herencia de Persona
        public ICollection<Prestamo> Prestamos { get; set; }// relacion 1:n con Prestamo
        public ICollection<Venta> Venta { get; set; }// relacion 1:n con Venta


    }
}
