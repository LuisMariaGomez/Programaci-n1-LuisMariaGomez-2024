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
    public class PersonaRepository : Repository<Persona>, ICreacionPersonaRepository
    {
        public PersonaRepository(LibreriaContext context) : base(context)
        {
        }
        public async Task<List<Persona>> GetAll()
        {
            try
            {
                return await _context.Persona.ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
