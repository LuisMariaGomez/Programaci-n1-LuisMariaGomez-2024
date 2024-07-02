using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEntidades.Entidades
{
    public class Persona
    {
        public int Id { get; set; }
        public string Nombre { get; set;}
        public string Apellido { get; set; }
        public string Direccion { get; set; }
        public string Contacto { get; set; }
        public string TipoDocumento { get; set; }
        public string Documento { get; set; }
    }
}
