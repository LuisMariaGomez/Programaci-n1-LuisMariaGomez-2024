using CDatos.Contexts;
using CDatos.Repositories.Contracts;
using CEntidades.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDatos.Repositories
{
    public class EmpleadoRepository : Repository<Empleado>, IEmpleadoRepository
    {
        public EmpleadoRepository(LibreriaContext context) : base(context)
        {
        }
        public async Task<List<Empleado>> GetAll()
        {
            try
            {
                return await _context.Empleado.ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
