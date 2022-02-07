using CPEssoaAPI.Domain.Entities;
using CPEssoaAPI.Domain.Parameters;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CPEssoaAPI.Domain.Interfaces.Services
{
    public interface IPessoaService
    {
        Task<int> Count();
        Task<Pessoa> Get(Guid id);
        Task<IEnumerable<Pessoa>> GetAll();
        Task<Pessoa> Post(Pessoa entity);
        Task<Pessoa> Put(Pessoa entity);
        Task<bool> Delete(Guid id);
        Task<List<Pessoa>> GetPessoas(ParametersPage pageParameters);
    }
}
