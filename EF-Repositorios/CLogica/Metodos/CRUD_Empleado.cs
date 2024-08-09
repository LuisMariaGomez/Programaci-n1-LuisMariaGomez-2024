using CDatos.Contexts;
using CEntidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLogica.Metodos
{
    internal class CRUD_Empleado
    {
        public LibreriaContext Context = new LibreriaContext();
        public void AgregarEmpleado(string Documento, string TipoDocumento, string Nombre, string Apellido, string Telefono, string Nacionalidad, string Email, string Cargo, float Sueldo)
        {
            var Empleados = Context.Empleado.ToList();
            bool EmpleadoDuplicado = false;

            foreach (var item in Empleados)
            {
                if (item.Persona.TipoDocumento == TipoDocumento && item.Persona.Documento == Documento)
                {
                    EmpleadoDuplicado = true;
                }
            }
            if (!EmpleadoDuplicado)
            {
                Persona nuevaPersona = new Persona(Documento, TipoDocumento, Nombre, Apellido, Telefono, Nacionalidad, Email);
                Empleado nuevoEmpleado = new Empleado();
                nuevoEmpleado.Cargo = Cargo;
                nuevoEmpleado.Sueldo = Sueldo;

                Context.Persona.Update(nuevaPersona);
                Context.Empleado.Update(nuevoEmpleado);
                Context.SaveChanges();
            }
        }
        public void EliminarCliente(Cliente EmpleadoAEliminar)
        {
            Context.Cliente.Update(EmpleadoAEliminar);
            Context.SaveChanges();
        }
        public void ObeterEmpleados(string NombreAutor)
        {
            var Empleados = Context.Empleado.ToList();
            foreach (var Empleado in Empleados)
            {
                Console.WriteLine($"ID: {Empleado.IdEmpleado}, Nombre: {Empleado.Persona.Nombre}, Apellido{Empleado.Persona.Apellido}");
            }
        }
    }
}
