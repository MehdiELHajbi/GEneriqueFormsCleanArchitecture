using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitectureDbTest1.Data.Mapping
{
    public partial class DataBaseMap
        : IEntityTypeConfiguration<CleanArchitectureDbTest1.Data.Entities.DataBase>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<CleanArchitectureDbTest1.Data.Entities.DataBase> builder)
        {
            #region Generated Configure
            // table
            builder.ToTable("DataBase", "dbo");

            // key
            builder.HasKey(t => t.IdDataBase);

            // properties
            builder.Property(t => t.IdDataBase)
                .IsRequired()
                .HasColumnName("idDataBase")
                .HasColumnType("int")
                .ValueGeneratedOnAdd();

            builder.Property(t => t.NameDataBase)
                .IsRequired()
                .HasColumnName("NameDataBase")
                .HasColumnType("varchar(50)")
                .HasMaxLength(50);

            builder.Property(t => t.ConnetionName)
                .HasColumnName("ConnetionName")
                .HasColumnType("varchar(50)")
                .HasMaxLength(50);

            builder.Property(t => t.ConnectionString)
                .HasColumnName("ConnectionString")
                .HasColumnType("varchar(50)")
                .HasMaxLength(50);

            builder.Property(t => t.TypeDataBase)
                .HasColumnName("TypeDataBase")
                .HasColumnType("varchar(50)")
                .HasMaxLength(50);

            builder.Property(t => t.Created)
                .IsRequired()
                .HasColumnName("Created")
                .HasColumnType("datetime2");

            builder.Property(t => t.CreatedBy)
                .HasColumnName("CreatedBy")
                .HasColumnType("nvarchar(max)");

            builder.Property(t => t.LastModified)
                .HasColumnName("LastModified")
                .HasColumnType("datetime2");

            builder.Property(t => t.LastModifiedBy)
                .HasColumnName("LastModifiedBy")
                .HasColumnType("nvarchar(max)");

            // relationships
            #endregion
        }

        #region Generated Constants
        public struct Table
        {
            public const string Schema = "dbo";
            public const string Name = "DataBase";
        }

        public struct Columns
        {
            public const string IdDataBase = "idDataBase";
            public const string NameDataBase = "NameDataBase";
            public const string ConnetionName = "ConnetionName";
            public const string ConnectionString = "ConnectionString";
            public const string TypeDataBase = "TypeDataBase";
            public const string Created = "Created";
            public const string CreatedBy = "CreatedBy";
            public const string LastModified = "LastModified";
            public const string LastModifiedBy = "LastModifiedBy";
        }
        #endregion
    }
}
