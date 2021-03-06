﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistence;

namespace Persistence.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("Domain.Entites.DataBase", b =>
                {
                    b.Property<int>("IdDataBase")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("idDataBase")
                        .UseIdentityColumn();

                    b.Property<string>("ConnectionString")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("ConnetionName")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameDataBase")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("TypeDataBase")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("IdDataBase")
                        .HasName("PK_DataBase");

                    b.ToTable("DataBase");
                });

            modelBuilder.Entity("Domain.Entites.Fields", b =>
                {
                    b.Property<int>("IdFiled")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("idFiled")
                        .UseIdentityColumn();

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FieldFriendlyName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("Field_friendly_name");

                    b.Property<string>("FieldName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("Field_Name");

                    b.Property<int?>("FkTablesId")
                        .HasColumnType("int")
                        .HasColumnName("Fk_Tables_Id");

                    b.Property<bool>("IsId")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsInsertable")
                        .HasColumnType("bit")
                        .HasColumnName("Is_Insertable");

                    b.Property<bool>("IsListable")
                        .HasColumnType("bit")
                        .HasColumnName("Is_Listable");

                    b.Property<bool>("IsNullable")
                        .HasColumnType("bit")
                        .HasColumnName("Is_Nullable");

                    b.Property<bool>("IsUpdatable")
                        .HasColumnType("bit")
                        .HasColumnName("Is_Updatable");

                    b.Property<bool>("IsViewtable")
                        .HasColumnType("bit")
                        .HasColumnName("Is_Viewtable");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MaxLength")
                        .HasColumnType("int")
                        .HasColumnName("Max_Length");

                    b.Property<int?>("RelationId")
                        .HasColumnType("int")
                        .HasColumnName("Relation_id");

                    b.Property<string>("RelationValue")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("Relation_value");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("IdFiled")
                        .HasName("PK_Fields");

                    b.HasIndex("FkTablesId");

                    b.ToTable("Fields");
                });

            modelBuilder.Entity("Domain.Entites.Tables", b =>
                {
                    b.Property<int>("IdTable")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<bool>("CanAdd")
                        .HasColumnType("bit")
                        .HasColumnName("Can_Add");

                    b.Property<bool>("CanDelete")
                        .HasColumnType("bit")
                        .HasColumnName("Can_Delete");

                    b.Property<bool>("CanUpdate")
                        .HasColumnType("bit")
                        .HasColumnName("Can_Update");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("FkDataBaseId")
                        .HasColumnType("int")
                        .HasColumnName("Fk_DataBase_Id");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ObjFriendlyName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Obj_friendly_name");

                    b.Property<string>("ObjName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Obj_name");

                    b.HasKey("IdTable")
                        .HasName("PK_Tables");

                    b.HasIndex("FkDataBaseId");

                    b.ToTable("Tables");
                });

            modelBuilder.Entity("Domain.Entites.Fields", b =>
                {
                    b.HasOne("Domain.Entites.Tables", "FkTables")
                        .WithMany("Fields")
                        .HasForeignKey("FkTablesId")
                        .HasConstraintName("Fk_Tables_Id");

                    b.Navigation("FkTables");
                });

            modelBuilder.Entity("Domain.Entites.Tables", b =>
                {
                    b.HasOne("Domain.Entites.DataBase", "FkDataBase")
                        .WithMany("Tables")
                        .HasForeignKey("FkDataBaseId")
                        .HasConstraintName("FK_Tables_Fk_DataBase");

                    b.Navigation("FkDataBase");
                });

            modelBuilder.Entity("Domain.Entites.DataBase", b =>
                {
                    b.Navigation("Tables");
                });

            modelBuilder.Entity("Domain.Entites.Tables", b =>
                {
                    b.Navigation("Fields");
                });
#pragma warning restore 612, 618
        }
    }
}
