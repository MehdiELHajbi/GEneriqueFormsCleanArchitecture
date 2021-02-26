using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitectureDbTest1.Data.Mapping
{
    public partial class FieldsMap
        : IEntityTypeConfiguration<CleanArchitectureDbTest1.Data.Entities.Fields>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<CleanArchitectureDbTest1.Data.Entities.Fields> builder)
        {
            #region Generated Configure
            // table
            builder.ToTable("Fields", "dbo");

            // key
            builder.HasKey(t => t.IdFiled);

            // properties
            builder.Property(t => t.IdFiled)
                .IsRequired()
                .HasColumnName("idFiled")
                .HasColumnType("int")
                .ValueGeneratedOnAdd();

            builder.Property(t => t.FieldFriendlyName)
                .IsRequired()
                .HasColumnName("Field_friendly_name")
                .HasColumnType("varchar(50)")
                .HasMaxLength(50);

            builder.Property(t => t.FieldName)
                .IsRequired()
                .HasColumnName("Field_Name")
                .HasColumnType("varchar(50)")
                .HasMaxLength(50);

            builder.Property(t => t.Type)
                .IsRequired()
                .HasColumnName("Type")
                .HasColumnType("varchar(50)")
                .HasMaxLength(50);

            builder.Property(t => t.MaxLength)
                .IsRequired()
                .HasColumnName("Max_Length")
                .HasColumnType("int");

            builder.Property(t => t.IsId)
                .IsRequired()
                .HasColumnName("IsId")
                .HasColumnType("bit");

            builder.Property(t => t.IsNullable)
                .IsRequired()
                .HasColumnName("Is_Nullable")
                .HasColumnType("bit");

            builder.Property(t => t.IsUpdatable)
                .IsRequired()
                .HasColumnName("Is_Updatable")
                .HasColumnType("bit");

            builder.Property(t => t.IsListable)
                .IsRequired()
                .HasColumnName("Is_Listable")
                .HasColumnType("bit");

            builder.Property(t => t.IsViewtable)
                .IsRequired()
                .HasColumnName("Is_Viewtable")
                .HasColumnType("bit");

            builder.Property(t => t.IsInsertable)
                .HasColumnName("Is_Insertable")
                .HasColumnType("bit");

            builder.Property(t => t.FkTablesId)
                .HasColumnName("Fk_Tables_Id")
                .HasColumnType("int");

            builder.Property(t => t.RelationId)
                .HasColumnName("Relation_id")
                .HasColumnType("int");

            builder.Property(t => t.RelationValue)
                .HasColumnName("Relation_value")
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
            builder.HasOne(t => t.FkTables)
                .WithMany(t => t.FkFields)
                .HasForeignKey(d => d.FkTablesId)
                .HasConstraintName("Fk_Tables_Id");

            #endregion
        }

        #region Generated Constants
        public struct Table
        {
            public const string Schema = "dbo";
            public const string Name = "Fields";
        }

        public struct Columns
        {
            public const string IdFiled = "idFiled";
            public const string FieldFriendlyName = "Field_friendly_name";
            public const string FieldName = "Field_Name";
            public const string Type = "Type";
            public const string MaxLength = "Max_Length";
            public const string IsId = "IsId";
            public const string IsNullable = "Is_Nullable";
            public const string IsUpdatable = "Is_Updatable";
            public const string IsListable = "Is_Listable";
            public const string IsViewtable = "Is_Viewtable";
            public const string IsInsertable = "Is_Insertable";
            public const string FkTablesId = "Fk_Tables_Id";
            public const string RelationId = "Relation_id";
            public const string RelationValue = "Relation_value";
            public const string Created = "Created";
            public const string CreatedBy = "CreatedBy";
            public const string LastModified = "LastModified";
            public const string LastModifiedBy = "LastModifiedBy";
        }
        #endregion
    }
}
