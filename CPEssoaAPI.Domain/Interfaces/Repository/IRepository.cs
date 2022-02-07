using CPEssoaAPI.Domain.Entities;
using CPEssoaAPI.Domain.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CPEssoaAPI.Domain.Interfaces.Repository
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<T> InsertAsync(T item);
        Task<T> UpdateAsync(T item);
        Task<bool> DeletAsync(Guid id);
        Task<T> SelectAsync(Guid id);
        Task<IEnumerable<T>> SelectAsync();
        Task<bool> ExistAsync(Guid id);
        IQueryable<T> FindAll();
        Task<int> Count();
        Task<List<T>> GetPaginate(ParametersPage entity);
    }
}
