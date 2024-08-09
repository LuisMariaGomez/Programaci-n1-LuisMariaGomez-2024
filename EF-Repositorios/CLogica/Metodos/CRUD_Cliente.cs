using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CDatos.Contexts;
using CEntidades.Entidades;


namespace CLogica.Metodos
{
    internal class CRUD_Cliente
    {
        public LibreriaContext Context = new LibreriaContext();
        public void AgregarCliente(string Documento, string TipoDocumento, string Nombre, string Apellido, string Telefono, string Nacionalidad, string Email, bool EsSocio, bool PagaIVA) 
        {
            var Clientes = Context.Cliente.ToList();
            bool ClienteDuplicado = false;

            foreach (var item in Clientes)
            {
                if(item.Persona.TipoDocumento == TipoDocumento && item.Persona.Documento == Documento)
                {
                    ClienteDuplicado = true;
                }
            }
            if (!ClienteDuplicado) {
                Persona nuevaPersona = new Persona(Documento,TipoDocumento,Nombre,Apellido,Telefono,Nacionalidad,Email);
                Cliente nuevoCliente = new Cliente();
                nuevoCliente.EsSocio = EsSocio;
                nuevoCliente.PagaIVA = PagaIVA;

                Context.Persona.Update(nuevaPersona);
                Context.Cliente.Update(nuevoCliente);
                Context.SaveChanges();
            }
        }
        public void EliminarCliente(Cliente ClienteAEliminar)
        {
            Context.Cliente.Update(ClienteAEliminar);
            Context.SaveChanges();
        }
        public void ObeterClientes(string NombreAutor)
        {
            var Clientes = Context.Cliente.ToList();
            foreach (var Cliente in Clientes)
            {
                Console.WriteLine($"ID: {Cliente.IdCliente}, Nombre: {Cliente.Persona.Nombre}, Apellido{Cliente.Persona.Apellido}");
            }
        }

    }
}
