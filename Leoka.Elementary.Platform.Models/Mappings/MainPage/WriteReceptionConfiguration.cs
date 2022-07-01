using Leoka.Elementary.Platform.Models.Entities.MainPage;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leoka.Elementary.Platform.Models.Mappings.MainPage;

public partial class WriteReceptionConfiguration : IEntityTypeConfiguration<WriteReceptionEntity>
{
    public void Configure(EntityTypeBuilder<WriteReceptionEntity> entity)
    {
        entity.ToTable("WriteReception", "dbo");

        entity.HasKey(e => e.WriteReceptionId);
        
        entity.Property(e => e.WriteReceptionId)
            .HasColumnName("WriteReceptionId")
            .HasColumnType("int4")
            .ValueGeneratedNever();
        
        entity.Property(e => e.WriteReceptionText)
            .HasColumnName("WriteReceptionText")
            .HasColumnType("varchar(200)")
            .HasMaxLength(200)
            .IsRequired();
        
        entity.Property(e => e.WriteReceptionButtonText)
            .HasColumnName("WriteReceptionButtonText")
            .HasColumnType("varchar(100)")
            .HasMaxLength(100)
            .IsRequired();
        
        entity.HasIndex(u => u.WriteReceptionId)
            .HasDatabaseName("WriteReception_pkey")
            .IsUnique();
        
        OnConfigurePartial(entity);
    }

    partial void OnConfigurePartial(EntityTypeBuilder<WriteReceptionEntity> entity);
}