using CDatos.Repositories.Contracts;
using CEntidades.Entidades;
using CLogica.Contracts;
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

        public ClienteLogic(IClienteRepository ClienteRepository)
        {
            _ClienteRepository = ClienteRepository;
        }
        void AltaCliente(Persona persona, Cliente cliente)(
            CreacionPersonaAltaPersona(persona)
        )

    }
}
