using CDatos.Repositories;
using CDatos.Repositories.Contracts;
using CEntidades.Entidades;
using CLogica.Contracts;

namespace CLogica.Implementations
{
    public class AutorLogic : IAutorLogic
    {
        private IAutorRepository _autorRepository; 

        public AutorLogic(IAutorRepository autorRepository)
        {
            _autorRepository = autorRepository;
        }

        public async Task<List<Autor>> GetAll()
        {
            return await _autorRepository.GetAll();
        }
    }
}
