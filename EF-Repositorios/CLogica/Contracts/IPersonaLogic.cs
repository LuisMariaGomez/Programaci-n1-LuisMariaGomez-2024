using CEntidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLogica.Contracts
{
    public interface IPersonaLogic  //No hereda de nada porque no hay interfaz de logica generica
    {
        void ModificarPersona(string documento, Persona persona);
        void EliminarPersona(string documento);
        Persona ObtenerPersonaPorDocumento(string documento);
        void ActualizarDatosPersonales(Persona personaExistente, Persona personaActualizada);
        Task<List<Persona>> ObtenerTodos();
    }
}
