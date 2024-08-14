using CEntidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLogica.Implementations
{
    public interface IClienteLogic
    {
        void AltaCliente(Persona persona, Cliente cliente);
        void ModificarPersona(string documento, Cliente clienteActualizado, Persona personaActualizada);
        void BajaCliente(string documento, Persona persona, Cliente cliente);
        Cliente ObtenerClientePorDocumento(string documento);
        Task<List<Cliente>> ObtenerTodosClientes();
    }
}
