using Domain.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class TablesConfiguration : IEntityTypeConfiguration<Tables>
    {
        public void Configure(EntityTypeBuilder<Tables> entity)
        {
            entity.HasKey(e => e.IdTable)
                .HasName("PK_Tables");

            entity.Property(e => e.CanAdd).HasColumnName("Can_Add");

            entity.Property(e => e.CanDelete).HasColumnName("Can_Delete");

            entity.Property(e => e.CanUpdate).HasColumnName("Can_Update");

            entity.Property(e => e.FkDataBaseId).HasColumnName("Fk_DataBase_Id");

            entity.Property(e => e.ObjFriendlyName)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("Obj_friendly_name");

            entity.Property(e => e.ObjName)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("Obj_name");

            entity.HasOne(d => d.FkDataBase)
                .WithMany(p => p.Tables)
                .HasForeignKey(d => d.FkDataBaseId)
                .HasConstraintName("FK_Tables_Fk_DataBase");
        }
    }
}
