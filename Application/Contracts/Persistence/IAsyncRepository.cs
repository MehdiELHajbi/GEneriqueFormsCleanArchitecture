using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Application.Contracts
{
    //https://blog.dcube.fr/index.php/2019/09/05/generic-repository-unit-of-work-et-entity-framework/
    public interface IAsyncRepository<T> where T : class
    {
        #region CREATE
        Task<T> AddAsync(T entity);
        void Add(IEnumerable<T> entities);
        #endregion

        #region READ
        Task<T> GetFirstOrDefault(
                                    Expression<Func<T, bool>> predicate = null,
                                    Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                    bool disableTracking = true
                                  );
        IEnumerable<T> GetMuliple(
                                   Expression<Func<T, bool>> predicate = null,
                                   Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                   bool disableTracking = true
                                  );

        T GetById(params object[] keyValues);
        Task<T> GetByIdAsync(int id);
        Task<IReadOnlyList<T>> ListAllAsync();
        Task<IReadOnlyList<T>> GetPagedReponseAsync(int page, int size);
        #endregion

        #region  Update
        Task UpdateAsync(T entity);
        #endregion

        #region Delete
        Task DeleteAsync(T entity);
        #endregion

        #region OTHER

        //Gets the count based on a predicate.
        int Count(Expression<Func<T, bool>> predicate = null);
        Task<int> CountAsync(Expression<Func<T, bool>> predicate = null);

        bool Exists(Expression<Func<T, bool>> predicate);
        #endregion












    }

}
