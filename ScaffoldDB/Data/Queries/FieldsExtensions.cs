using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitectureDbTest1.Data.Queries
{
    public static partial class FieldsExtensions
    {
        #region Generated Extensions
        public static IQueryable<CleanArchitectureDbTest1.Data.Entities.Fields> ByFkTablesId(this IQueryable<CleanArchitectureDbTest1.Data.Entities.Fields> queryable, int? fkTablesId)
        {
            return queryable.Where(q => (q.FkTablesId == fkTablesId || (fkTablesId == null && q.FkTablesId == null)));
        }

        public static CleanArchitectureDbTest1.Data.Entities.Fields GetByKey(this IQueryable<CleanArchitectureDbTest1.Data.Entities.Fields> queryable, int idFiled)
        {
            if (queryable is DbSet<CleanArchitectureDbTest1.Data.Entities.Fields> dbSet)
                return dbSet.Find(idFiled);

            return queryable.FirstOrDefault(q => q.IdFiled == idFiled);
        }

        public static ValueTask<CleanArchitectureDbTest1.Data.Entities.Fields> GetByKeyAsync(this IQueryable<CleanArchitectureDbTest1.Data.Entities.Fields> queryable, int idFiled)
        {
            if (queryable is DbSet<CleanArchitectureDbTest1.Data.Entities.Fields> dbSet)
                return dbSet.FindAsync(idFiled);

            var task = queryable.FirstOrDefaultAsync(q => q.IdFiled == idFiled);
            return new ValueTask<CleanArchitectureDbTest1.Data.Entities.Fields>(task);
        }

        #endregion

    }
}
