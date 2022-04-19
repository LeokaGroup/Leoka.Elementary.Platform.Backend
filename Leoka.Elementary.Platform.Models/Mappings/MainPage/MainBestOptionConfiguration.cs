using Leoka.Elementary.Platform.Models.Entities.MainPage;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leoka.Elementary.Platform.Models.Mappings.MainPage;

public partial class MainBestOptionConfiguration : IEntityTypeConfiguration<MainBestOptionEntity>
{
    public void Configure(EntityTypeBuilder<MainBestOptionEntity> entity)
    {
        entity.ToTable("MainBestOptions", "dbo");

        entity.HasKey(e => e.BestOptionId);
        
        entity.Property(e => e.BestOptionId)
            .HasColumnName("BestOptionId")
            .HasColumnType("int4")
            .ValueGeneratedNever();

        entity.Property(e => e.BestOptionTitle)
            .HasColumnName("BestOptionTitle")
            .HasColumnType("varchar(150)")
            .HasMaxLength(150)
            .IsRequired();

        entity.Property(e => e.BestOptionSubTitle)
            .HasColumnName("BestOptionSubTitle")
            .HasColumnType("varchar(150)")
            .HasMaxLength(150)
            .IsRequired();
        ;
        entity.Property(e => e.BestOptionButtonText)
            .HasColumnName("BestOptionButtonText")
            .HasColumnType("varchar(50)")
            .HasMaxLength(50)
            .IsRequired();
        
        entity.HasIndex(u => u.BestOptionId)
            .HasName("MainBestOptions_pkey")
            .IsUnique();
        
        entity.HasIndex(u => u.BestOptionBlockId)
            .HasName("MainBestOptions_BestOptionBlockId_key")
            .IsUnique();

        OnConfigurePartial(entity);
    }

    partial void OnConfigurePartial(EntityTypeBuilder<MainBestOptionEntity> entity);
}