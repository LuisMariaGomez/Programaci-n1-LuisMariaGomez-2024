using CEntidades.Entidades;

namespace CLogica.Contracts
{
    public interface IAutorLogic
    {
        void AltaAutor(Persona persona, Autor autor);
        void ModificarAutor(string documento, Autor autorActualizado, Persona personaActualizada);
        void BajaAutor(string documento, Persona persona, Autor autor);
        Autor ObtenerAutorPorDocumento(string documento);
        Task<List<Autor>> ObtenerTodosAutores();
    }
}
