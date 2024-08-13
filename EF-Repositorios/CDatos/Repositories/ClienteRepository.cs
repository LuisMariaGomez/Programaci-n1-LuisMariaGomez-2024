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
    public class ClienteRepository : Repository<Cliente>, IClienteRepository
    {
        public ClienteRepository(LibreriaContext context) : base(context)
        {
        }
        public async Task<List<Cliente>> GetAll()
        {
            try
            {
                return await _context.Cliente.ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
