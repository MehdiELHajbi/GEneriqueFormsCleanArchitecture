using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitectureDbTest1.Data.Queries
{
    public static partial class TablesExtensions
    {
        #region Generated Extensions
        public static IQueryable<CleanArchitectureDbTest1.Data.Entities.Tables> ByFkDataBaseId(this IQueryable<CleanArchitectureDbTest1.Data.Entities.Tables> queryable, int? fkDataBaseId)
        {
            return queryable.Where(q => (q.FkDataBaseId == fkDataBaseId || (fkDataBaseId == null && q.FkDataBaseId == null)));
        }

        public static CleanArchitectureDbTest1.Data.Entities.Tables GetByKey(this IQueryable<CleanArchitectureDbTest1.Data.Entities.Tables> queryable, int idTable)
        {
            if (queryable is DbSet<CleanArchitectureDbTest1.Data.Entities.Tables> dbSet)
                return dbSet.Find(idTable);

            return queryable.FirstOrDefault(q => q.IdTable == idTable);
        }

        public static ValueTask<CleanArchitectureDbTest1.Data.Entities.Tables> GetByKeyAsync(this IQueryable<CleanArchitectureDbTest1.Data.Entities.Tables> queryable, int idTable)
        {
            if (queryable is DbSet<CleanArchitectureDbTest1.Data.Entities.Tables> dbSet)
                return dbSet.FindAsync(idTable);

            var task = queryable.FirstOrDefaultAsync(q => q.IdTable == idTable);
            return new ValueTask<CleanArchitectureDbTest1.Data.Entities.Tables>(task);
        }

        #endregion

    }
}
