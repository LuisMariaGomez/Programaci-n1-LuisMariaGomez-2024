using CDatos.Repositories.Contracts;
using CEntidades.Entidades;
using CLogica.Contracts;
using Microsoft.EntityFrameworkCore;

namespace CLogica.Implementations
{
    public class AutorLogic : IAutorLogic, ICreacionPersonaLogic
    {
        private IAutorRepository _autorRepository;
        private ICreacionPersonaRepository _personaRepository; // Inyectamos ICreacionPersonaRepository para poder cargar las cosas de DBPersona

        private IPersonaLogic _PersonaLogic;                 // Inyectamos IPersonaLogic para usar la busqueda por Documento en CreacionPersonaLogic
        private ICreacionPersonaLogic _CreacionPersonaLogic; // Inyectamos ICreacionPersonaLogic para usar el alta en CreacionPersonaLogic
        private readonly DbContext _context;

        public AutorLogic(IAutorRepository IAutorRepository, ICreacionPersonaLogic _creacionPersonaLogic, IPersonaLogic _personaRepository, IPersonaLogic _PersonaLogic, DbContext context)
        {
            _autorRepository = IAutorRepository;
            _CreacionPersonaLogic = _creacionPersonaLogic;
            _personaRepository = _personaRepository;
            _PersonaLogic = _PersonaLogic;  // Guardamos las instancias
            _context = context;

        }

        // ALTA, BAJA, MODIFICACION, OBTENER - EMPLEADO

        public void AltaAutor(Persona persona, Autor autor)
        {
            _CreacionPersonaLogic.AltaPersona(persona);

            ValidarDatosAutor(autor);


            autor.Persona = persona;
            _personaRepository.Update(persona);
            _personaRepository.Save();
            _autorRepository.Update(autor);
            _autorRepository.Save();
        }
        public void BajaAutor(string documento, Persona persona, Autor autor)
        {
            Autor autorExistente = ObtenerAutorPorDocumento(documento);
            _autorRepository.Delete(autorExistente);
            _autorRepository.Save();

            Persona personaExistente = _PersonaLogic.ObtenerPersonaPorDocumento(documento);
            _personaRepository.Delete(personaExistente);
            _personaRepository.Save();
        }

        public void ModificarAutor(string documento, Autor autorActualizado, Persona personaActualizada)
        {
            Persona personaExistente = _PersonaLogic.ObtenerPersonaPorDocumento(documento);
            _PersonaLogic.ActualizarDatosPersonales(personaExistente, personaActualizada);
            _personaRepository.Update(personaExistente);
            _personaRepository.Save();

            Autor autorExistente = ObtenerAutorPorDocumento(documento);
            ActualizarDatosAutor(autorExistente, autorActualizado);
            _autorRepository.Update(autorExistente);
            _autorRepository.Save();
        }
        public Autor ObtenerAutorPorDocumento(string documento)
        {
            Autor autor = _autorRepository.FindByCondition(p => p.Persona.Documento == documento).FirstOrDefault();

            if (autor == null)
                throw new ArgumentException("Persona no encontrada");

            return autor;
        }
        public async Task<List<Autor>> ObtenerTodosAutores()
        {
            return await _context.Set<Autor>().ToListAsync();
        }

        // -------------------------------------------------------------------------------  //

        private void ValidarDatosAutor(Autor autor)
        {
            if (!_CreacionPersonaLogic.IsValidStrinng_withLessThanXLetters(autor.Biografia, 100))
                throw new ArgumentException("El cargo del empleado es incorrecto");
        }
        public void ActualizarDatosAutor(Autor AutorExistente, Autor AutorActualizada)
        {
            AutorExistente.Biografia = AutorActualizada.Biografia;
        }












        // Implementa explicitamente sino sale error de que no se usan (auqnue las uso)
        bool ICreacionPersonaLogic.IsValidStrinng_withLessThanXLetters(string word, int num_letters)
        {
            throw new NotImplementedException();
        }

        bool ICreacionPersonaLogic.ContieneCaracter(string text)
        {
            throw new NotImplementedException();
        }
    }
}
