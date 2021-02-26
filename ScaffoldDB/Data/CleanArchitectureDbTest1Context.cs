using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CleanArchitectureDbTest1.Data
{
    public partial class CleanArchitectureDbTest1Context : DbContext
    {
        public CleanArchitectureDbTest1Context(DbContextOptions<CleanArchitectureDbTest1Context> options)
            : base(options)
        {
        }

        #region Generated Properties
        public virtual DbSet<CleanArchitectureDbTest1.Data.Entities.DataBase> Databases { get; set; }

        public virtual DbSet<CleanArchitectureDbTest1.Data.Entities.Fields> Fields { get; set; }

        public virtual DbSet<CleanArchitectureDbTest1.Data.Entities.Logs> Logs { get; set; }

        public virtual DbSet<CleanArchitectureDbTest1.Data.Entities.Tables> Tables { get; set; }

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Generated Configuration
            modelBuilder.ApplyConfiguration(new CleanArchitectureDbTest1.Data.Mapping.DataBaseMap());
            modelBuilder.ApplyConfiguration(new CleanArchitectureDbTest1.Data.Mapping.FieldsMap());
            modelBuilder.ApplyConfiguration(new CleanArchitectureDbTest1.Data.Mapping.LogsMap());
            modelBuilder.ApplyConfiguration(new CleanArchitectureDbTest1.Data.Mapping.TablesMap());
            #endregion
        }
    }
}
