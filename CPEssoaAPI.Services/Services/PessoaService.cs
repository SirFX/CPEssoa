using CPEssoaAPI.Domain.Entities;
using CPEssoaAPI.Domain.Interfaces.Repository;
using CPEssoaAPI.Domain.Interfaces.Services;
using CPEssoaAPI.Domain.Parameters;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CPEssoaAPI.Services.Services
{
    public class PessoaService : IPessoaService
    {
        private readonly IRepository<Pessoa> _repository;

        public PessoaService(
            IRepository<Pessoa> repository)
        {
            _repository = repository;;
        }

        public async Task<int> Count()
        {
            return await _repository.Count();
        }
        public async Task<bool> Delete(Guid id)
        {
            return await _repository.DeletAsync(id);
        }

        public async Task<Pessoa> Get(Guid id)
        {
            return await _repository.SelectAsync(id);
        }

        public async Task<IEnumerable<Pessoa>> GetAll()
        {
            return await _repository.SelectAsync();
        }

        public async Task<Pessoa> Post(Pessoa entity)
        {
            return await _repository.InsertAsync(entity);
        }

        public async Task<Pessoa> Put(Pessoa entity)
        {
            return await _repository.UpdateAsync(entity);
        }

        public async Task<List<Pessoa>> GetPessoas(ParametersPage pageParameters)
        {
            return await _repository.GetPaginate(pageParameters);
        }
    }
}
