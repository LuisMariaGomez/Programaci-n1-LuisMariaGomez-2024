using CDatos.Contexts;
using CEntidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLogica.Metodos
{
    internal class CRUD_Autor
    {
        public LibreriaContext Context = new LibreriaContext();
        public void AgregarAutor(string NombreAutor, string ApellidoAutor, string Biografia)
        {
            var nuevaPersona = new Persona(NombreAutor, ApellidoAutor);
            var nuevoAutor = new Autor(Biografia, nuevaPersona);

            Context.Persona.Update(nuevaPersona);
            Context.Autor.Update(nuevoAutor);
            Context.SaveChanges();
        }
        public void EliminarAutor(Autor AutorAEliminar)
        {
            Context.Autor.Update(AutorAEliminar);
            Context.SaveChanges();
        }
        public void ObeterAutores(string NombreAutor)
        {
            var Autores  = Context.Autor.ToList();
            foreach (var Autor in Autores)
            {
                Console.WriteLine($"ID: {Autor.IdAutor}, Nombre: {Autor.Persona.Nombre}, Apellido{Autor.Persona.Apellido}, Biografia: {Autor.Biografia}");
            }
        }
        public void ActualizarAutor(string CampoAActualizar, ) 
        {
        }

    }
}
