using CDatos.Repositories.Contracts;
using CEntidades.Entidades;
using CLogica.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLogica.Implementations
{
    public class PersonaLogic : IPersonaLogic
    {
        private readonly IPersonaRepository _personaRepository;
        private readonly DbContext _context;
        public PersonaLogic(IPersonaRepository personaRepository, DbContext context)
        {
            _personaRepository = personaRepository;
            _context = context;
        }

        // Se ingresa un Documento y una Persona para actualizar los datos
        public void ModificarPersona(string documento, Persona personaActualizada)
        {
            Persona personaExistente = ObtenerPersonaPorDocumento(documento);

            ActualizarDatosPersonales(personaExistente, personaActualizada);

            _personaRepository.Update(personaExistente);
            _personaRepository.Save();
        }

        public void ActualizarDatosPersonales(Persona personaExistente, Persona personaActualizada)
        {
            personaExistente.Nombre = personaActualizada.Nombre;
            personaExistente.Apellido = personaActualizada.Apellido;
            personaExistente.Telefono = personaActualizada.Telefono;
            personaExistente.Email = personaActualizada.Email;
            personaExistente.Nacionalidad = personaActualizada.Nacionalidad;
        }

        public void EliminarPersona(string documento)
        {
            Persona persona = _personaRepository.FindByCondition(p => p.Documento == documento).FirstOrDefault();
            if (persona == null)
                throw new ArgumentException("Persona no encontrada");
            _personaRepository.Delete(persona);
            _personaRepository.Save();
        }

        public Persona ObtenerPersonaPorDocumento(string documento)
        {
            Persona persona = _personaRepository.FindByCondition(p => p.Documento == documento).FirstOrDefault();

            if (persona == null)
                throw new ArgumentException("Persona no encontrada");

            return persona;
        }
        public async Task<List<Persona>> ObtenerTodos()
        {
            return await _context.Set<Persona>().ToListAsync();
        }
    }
}
