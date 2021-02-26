using CleanArchitectureDbTest1.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArchitectureDbTest1.Data.Queries
{
    public static partial class DataBaseExtensions
    {
        #region Generated Extensions
        public static DataBase GetByKey(this IQueryable<DataBase> queryable, int idDataBase)
        {
            if (queryable is DbSet<CleanArchitectureDbTest1.Data.Entities.DataBase> dbSet)
                return dbSet.Find(idDataBase);

            return queryable.FirstOrDefault(q => q.IdDataBase == idDataBase);
        }

        public static ValueTask<CleanArchitectureDbTest1.Data.Entities.DataBase> GetByKeyAsync(this IQueryable<CleanArchitectureDbTest1.Data.Entities.DataBase> queryable, int idDataBase)
        {
            if (queryable is DbSet<CleanArchitectureDbTest1.Data.Entities.DataBase> dbSet)
                return dbSet.FindAsync(idDataBase);

            var task = queryable.FirstOrDefaultAsync(q => q.IdDataBase == idDataBase);
            return new ValueTask<DataBase>(task);
        }

        #endregion

    }
}
