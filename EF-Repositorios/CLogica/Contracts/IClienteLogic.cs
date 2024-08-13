using CEntidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLogica.Implementations
{
    public class IClienteLogic
    {
        void AltaCliente(Persona persona, Cliente cliente);
        void ModificarCliente(string documento, Persona persona);
        void EliminarCliente(string documento);
        Persona ObtenerClientePorDocumento(string documento);
        Task<List<Persona>> ObtenerTodosClientes();
    }
}
