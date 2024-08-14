using CDatos.Repositories;
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
    public class EmpleadoLogic : IEmpleadoLogic, ICreacionPersonaLogic
    {
        private IEmpleadoRepository _EmpleadoRepository;
        private ICreacionPersonaRepository _personaRepository; // Inyectamos ICreacionPersonaRepository para poder cargar las cosas de DBPersona
        
        private IPersonaLogic _PersonaLogic;                 // Inyectamos IPersonaLogic para usar la busqueda por Documento en CreacionPersonaLogic
        private ICreacionPersonaLogic _CreacionPersonaLogic; // Inyectamos ICreacionPersonaLogic para usar el alta en CreacionPersonaLogic
        private readonly DbContext _context;

        public EmpleadoLogic(IEmpleadoRepository EmpleadoRepository, ICreacionPersonaLogic _creacionPersonaLogic, IPersonaLogic _personaRepository, IPersonaLogic _PersonaLogic, DbContext context)
        {
            _EmpleadoRepository = EmpleadoRepository;
            _CreacionPersonaLogic = _creacionPersonaLogic;
            _personaRepository = _personaRepository;
            _PersonaLogic = _PersonaLogic;  // Guardamos las instancias
            _context = context;

        }

        // ALTA, BAJA, MODIFICACION, OBTENER - EMPLEADO

        public void AltaEmpleado(Persona persona, Empleado empleado)
        {
            _CreacionPersonaLogic.AltaPersona(persona);

            ValidarDatosEmpleado(empleado);


            empleado.Persona = persona;
            _personaRepository.Update(persona);
            _personaRepository.Save();
            _EmpleadoRepository.Update(empleado);
            _EmpleadoRepository.Save();
        }
        public void BajaEmpleado(string documento, Persona persona, Empleado empleado)
        {
            Empleado empleadoExistente = ObtenerEmpleadoPorDocumento(documento);
            _EmpleadoRepository.Delete(empleadoExistente);
            _EmpleadoRepository.Save();

            Persona personaExistente = _PersonaLogic.ObtenerPersonaPorDocumento(documento);
            _personaRepository.Delete(personaExistente);
            _personaRepository.Save();
        }

        public void ModificarEmpleado(string documento, Empleado empleadoActualizado, Persona personaActualizada)
        {
            Persona personaExistente = _PersonaLogic.ObtenerPersonaPorDocumento(documento);
            _PersonaLogic.ActualizarDatosPersonales(personaExistente, personaActualizada);
            _personaRepository.Update(personaExistente);
            _personaRepository.Save();

            Empleado empleadoExistente = ObtenerEmpleadoPorDocumento(documento);
            ActualizarDatosEmpleado(empleadoExistente, empleadoActualizado);
            _EmpleadoRepository.Update(empleadoExistente);
            _EmpleadoRepository.Save();
        }
        public Empleado ObtenerEmpleadoPorDocumento(string documento)
        {
            Empleado empleado = _EmpleadoRepository.FindByCondition(p => p.Persona.Documento == documento).FirstOrDefault();

            if (empleado == null)
                throw new ArgumentException("Persona no encontrada");

            return empleado;
        }
        public async Task<List<Empleado>> ObtenerTodosEmpleados()
        {
            return await _context.Set<Empleado>().ToListAsync();
        }

        // -------------------------------------------------------------------------------  //

        private void ValidarDatosEmpleado(Empleado empleado)
        {
            if (!_CreacionPersonaLogic.IsValidStrinng_withLessThanXLetters(empleado.Cargo, 15))
                throw new ArgumentException("El cargo del empleado es incorrecto");
            if (!_CreacionPersonaLogic.IsValidStrinng_withLessThanXLetters(empleado.Sueldo, 15))
                throw new ArgumentException("El Sueldo del empleado es incorrecto");
        }
        public void ActualizarDatosEmpleado(Empleado EmpleadoExistente, Empleado EmpleadoActualizada)
        {
            EmpleadoExistente.Sueldo = EmpleadoActualizada.Sueldo;
            EmpleadoExistente.Cargo = EmpleadoActualizada.Cargo;
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
