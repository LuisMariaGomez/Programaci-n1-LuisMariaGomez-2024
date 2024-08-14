using CEntidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLogica.Contracts
{
    public interface IEmpleadoLogic
    {
        void AltaEmpleado(Persona persona, Empleado empleado);
        void ModificarEmpleado(string documento, Empleado empleadoActualizado, Persona personaActualizada);
        void BajaEmpleado(string documento, Persona persona, Empleado empleado);
        Empleado ObtenerEmpleadoPorDocumento(string documento);
        Task<List<Empleado>> ObtenerTodosEmpleados();
    }
}
