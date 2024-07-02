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
        public float Sueldo { get; set; }
    }
}
