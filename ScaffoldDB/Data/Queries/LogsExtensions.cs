using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitectureDbTest1.Data.Queries
{
    public static partial class LogsExtensions
    {
        #region Generated Extensions
        public static CleanArchitectureDbTest1.Data.Entities.Logs GetByKey(this IQueryable<CleanArchitectureDbTest1.Data.Entities.Logs> queryable, int id)
        {
            if (queryable is DbSet<CleanArchitectureDbTest1.Data.Entities.Logs> dbSet)
                return dbSet.Find(id);

            return queryable.FirstOrDefault(q => q.Id == id);
        }

        public static ValueTask<CleanArchitectureDbTest1.Data.Entities.Logs> GetByKeyAsync(this IQueryable<CleanArchitectureDbTest1.Data.Entities.Logs> queryable, int id)
        {
            if (queryable is DbSet<CleanArchitectureDbTest1.Data.Entities.Logs> dbSet)
                return dbSet.FindAsync(id);

            var task = queryable.FirstOrDefaultAsync(q => q.Id == id);
            return new ValueTask<CleanArchitectureDbTest1.Data.Entities.Logs>(task);
        }

        #endregion

    }
}
