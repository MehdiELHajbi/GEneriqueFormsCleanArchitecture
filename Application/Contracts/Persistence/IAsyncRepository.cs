using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Contracts
{
    public interface IAsyncRepository<T> where T : class
    {
        Task<T> GetByIdAsync(int id);
        Task<IReadOnlyList<T>> ListAllAsync();
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        //Task<IQueryable<T>> GetPagedReponseAsync(int page, int size);

        Task<IReadOnlyList<T>> GetPagedReponseAsync(int page, int size);

        //Task<int> Count(IQueryable<T> listT);
        Task<int> CountAsync();
    }

}
