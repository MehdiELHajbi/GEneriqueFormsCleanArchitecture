using Domain.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class DataBaseConfiguration : IEntityTypeConfiguration<DataBase>
    {
        public void Configure(EntityTypeBuilder<DataBase> entity)
        {
            entity.HasKey(e => e.IdDataBase)
                .HasName("PK_DataBase");

            entity.Property(e => e.IdDataBase).HasColumnName("idDataBase");

            entity.Property(e => e.ConnectionString)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.ConnetionName)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.NameDataBase)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.TypeDataBase)
                .HasMaxLength(50)
                .IsUnicode(false);
        }
    }
}
