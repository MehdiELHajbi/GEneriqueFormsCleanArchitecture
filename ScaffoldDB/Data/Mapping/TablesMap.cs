using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitectureDbTest1.Data.Mapping
{
    public partial class TablesMap
        : IEntityTypeConfiguration<CleanArchitectureDbTest1.Data.Entities.Tables>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<CleanArchitectureDbTest1.Data.Entities.Tables> builder)
        {
            #region Generated Configure
            // table
            builder.ToTable("Tables", "dbo");

            // key
            builder.HasKey(t => t.IdTable);

            // properties
            builder.Property(t => t.IdTable)
                .IsRequired()
                .HasColumnName("IdTable")
                .HasColumnType("int")
                .ValueGeneratedOnAdd();

            builder.Property(t => t.ObjName)
                .IsRequired()
                .HasColumnName("Obj_name")
                .HasColumnType("nvarchar(50)")
                .HasMaxLength(50);

            builder.Property(t => t.ObjFriendlyName)
                .IsRequired()
                .HasColumnName("Obj_friendly_name")
                .HasColumnType("nvarchar(50)")
                .HasMaxLength(50);

            builder.Property(t => t.CanUpdate)
                .IsRequired()
                .HasColumnName("Can_Update")
                .HasColumnType("bit");

            builder.Property(t => t.CanDelete)
                .IsRequired()
                .HasColumnName("Can_Delete")
                .HasColumnType("bit");

            builder.Property(t => t.CanAdd)
                .IsRequired()
                .HasColumnName("Can_Add")
                .HasColumnType("bit");

            builder.Property(t => t.FkDataBaseId)
                .HasColumnName("Fk_DataBase_Id")
                .HasColumnType("int");

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
            builder.HasOne(t => t.FkDataBase)
                .WithMany(t => t.FkTables)
                .HasForeignKey(d => d.FkDataBaseId)
                .HasConstraintName("FK_Tables_Fk_DataBase");

            #endregion
        }

        #region Generated Constants
        public struct Table
        {
            public const string Schema = "dbo";
            public const string Name = "Tables";
        }

        public struct Columns
        {
            public const string IdTable = "IdTable";
            public const string ObjName = "Obj_name";
            public const string ObjFriendlyName = "Obj_friendly_name";
            public const string CanUpdate = "Can_Update";
            public const string CanDelete = "Can_Delete";
            public const string CanAdd = "Can_Add";
            public const string FkDataBaseId = "Fk_DataBase_Id";
            public const string Created = "Created";
            public const string CreatedBy = "CreatedBy";
            public const string LastModified = "LastModified";
            public const string LastModifiedBy = "LastModifiedBy";
        }
        #endregion
    }
}
