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
    public class ClienteLogic : IClienteLogic, ICreacionPersonaLogic
    {
        private IClienteRepository _ClienteRepository;
        private ICreacionPersonaLogic _CreacionPersonaLogic; // Inyectamos ICreacionPersonaLogic para usar el alta en CreacionPersonaLogic
        private IPersonaLogic _PersonaLogic;
        private ICreacionPersonaRepository _personaRepository; // Inyectamos ICreacionPersonaRepository para poder cargar las cosas de Persona
        private readonly DbContext _context;


        public ClienteLogic(IClienteRepository ClienteRepository, ICreacionPersonaLogic _creacionPersonaLogic, IPersonaLogic _personaRepository, IPersonaLogic _PersonaLogic, DbContext context)
        {
            _ClienteRepository = ClienteRepository;
            _CreacionPersonaLogic = _creacionPersonaLogic;
            _personaRepository = _personaRepository;
            _PersonaLogic = _PersonaLogic;  // Guardamos las instancias
            _context = context;

        }

        // ALTA, BAJA, MODIFICACION, OBTENER - EMPLEADO

        public void AltaCliente(Persona persona, Cliente cliente)
        {
            _CreacionPersonaLogic.AltaPersona(persona);

            ValidarDatosCliete(cliente);


            cliente.Persona = persona;
            _personaRepository.Update(persona);
            _personaRepository.Save();
            _ClienteRepository.Update(cliente);
            _ClienteRepository.Save();
        }

        public void BajaCliente(string documento, Persona persona, Cliente cliente)
        {
            Cliente clienteExistente = ObtenerClientePorDocumento(documento);
            _ClienteRepository.Delete(clienteExistente);
            _ClienteRepository.Save();

            Persona personaExistente = _PersonaLogic.ObtenerPersonaPorDocumento(documento);
            _personaRepository.Delete(personaExistente);
            _personaRepository.Save();
        }

        public void ModificarPersona(string documento, Cliente clienteActualizado, Persona personaActualizada)
        {
            Persona personaExistente = _PersonaLogic.ObtenerPersonaPorDocumento(documento);
            _PersonaLogic.ActualizarDatosPersonales(personaExistente, personaActualizada);
            _personaRepository.Update(personaExistente);
            _personaRepository.Save();

            Cliente clienteExistente = ObtenerClientePorDocumento(documento);
            ActualizarDatosCliente(clienteExistente, clienteActualizado);
            _ClienteRepository.Update(clienteExistente);
            _ClienteRepository.Save();
        }
        public Cliente ObtenerClientePorDocumento(string documento)
        {
            Cliente cliente = _ClienteRepository.FindByCondition(p => p.Persona.Documento == documento).FirstOrDefault();

            if (cliente == null)
                throw new ArgumentException("Persona no encontrada");

            return cliente;
        }
        public async Task<List<Cliente>> ObtenerTodosClientes()
        {
            return await _context.Set<Cliente>().ToListAsync();
        }

        // -------------------------------------------------------------------------------  //

        private void ValidarDatosCliete(Cliente cliente)
        {
            if (cliente.EsSocio is bool && cliente.EsSocio != null)
                throw new ArgumentException("La especificacion de que si el cliente es socio o no es invalida");
            if (cliente.PagaIVA is bool && cliente.PagaIVA != null)
                throw new ArgumentException("La especificacion de que si el cliente es socio o no es invalida");
        }
        public void ActualizarDatosCliente(Cliente clienteExistente, Cliente ClienteActualizada)
        {
            clienteExistente.EsSocio = ClienteActualizada.EsSocio;
            clienteExistente.PagaIVA = ClienteActualizada.PagaIVA;
        }

        // Implementa explicitamente sino sale error de que no se usan

        public bool IsValidStrinng_withLessThanXLetters(string word, int num_letters)
        {
            throw new NotImplementedException();
        }

        public bool ContieneCaracter(string text)
        {
            throw new NotImplementedException();
        }
    }
}
