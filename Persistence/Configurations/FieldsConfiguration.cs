using Domain.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class FieldsConfiguration : IEntityTypeConfiguration<Fields>
    {
        public void Configure(EntityTypeBuilder<Fields> entity)
        {
            entity.HasKey(e => e.IdFiled)
                .HasName("PK_Fields");

            entity.Property(e => e.IdFiled).HasColumnName("idFiled");

            entity.Property(e => e.FieldFriendlyName)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Field_friendly_name");

            entity.Property(e => e.FieldName)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Field_Name");

            entity.Property(e => e.FkTablesId).HasColumnName("Fk_Tables_Id");

            entity.Property(e => e.IsInsertable).HasColumnName("Is_Insertable");

            entity.Property(e => e.IsListable).HasColumnName("Is_Listable");

            entity.Property(e => e.IsNullable).HasColumnName("Is_Nullable");

            entity.Property(e => e.IsUpdatable).HasColumnName("Is_Updatable");

            entity.Property(e => e.IsViewtable).HasColumnName("Is_Viewtable");

            entity.Property(e => e.MaxLength).HasColumnName("Max_Length");

            entity.Property(e => e.RelationId).HasColumnName("Relation_id");

            entity.Property(e => e.RelationValue)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Relation_value");

            entity.Property(e => e.Type)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.FkTables)
                .WithMany(p => p.Fields)
                .HasForeignKey(d => d.FkTablesId)
                .HasConstraintName("Fk_Tables_Id");
        }
    }
}
