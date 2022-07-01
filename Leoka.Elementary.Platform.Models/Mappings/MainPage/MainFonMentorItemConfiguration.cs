using Leoka.Elementary.Platform.Models.Entities.MainPage;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leoka.Elementary.Platform.Models.Mappings.MainPage;

public partial class MainFonMentorItemConfiguration : IEntityTypeConfiguration<MainFonMentorItemEntity>
{
    public void Configure(EntityTypeBuilder<MainFonMentorItemEntity> entity)
    {
        entity.ToTable("MainFonMentorItems", "dbo");

        entity.HasKey(e => e.ItemId);
        
        entity.Property(e => e.ItemId)
            .HasColumnName("ItemId")
            .HasColumnType("serial")
            .ValueGeneratedNever();
        
        entity.Property(e => e.FonSubTitleId)
            .HasColumnName("FonSubTitleId")
            .HasColumnType("int4")
            .IsRequired();
        
        entity.Property(e => e.FonSubTitleTextFirst)
            .HasColumnName("FonSubTitleTextFirst")
            .HasColumnType("varchar(150)")
            .HasMaxLength(150)
            .IsRequired();
        
        entity.Property(e => e.FonSubTitleTextSecond)
            .HasColumnName("FonSubTitleTextSecond")
            .HasColumnType("varchar(150)")
            .HasMaxLength(150)
            .IsRequired();
        
        entity.Property(e => e.FonSubSecondNumber)
            .HasColumnName("FonSubSecondNumber")
            .HasColumnType("int4")
            .IsRequired();
        
        entity.HasIndex(u => u.ItemId)
            .HasDatabaseName("MainFonMentorItems_pkey")
            .IsUnique();

        OnConfigurePartial(entity);
    }

    partial void OnConfigurePartial(EntityTypeBuilder<MainFonMentorItemEntity> entity);
}