using CDatos.Repositories.Contracts;
using CEntidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CDatos.Contexts;
using Microsoft.EntityFrameworkCore;

namespace CDatos.Repositories
{
    public class CreacionPersonaRepository : Repository<Persona>, ICreacionPersonaRepository
    {
        public CreacionPersonaRepository(LibreriaContext context) : base(context)
        {
        }
        public async  Task<List<Persona>> GetAll()
        {
            try
            {
                return await _context.Persona.ToListAsync();
            }
            catch (Exception) {
                throw;
                    }
        }
    }
}
