using Leoka.Elementary.Platform.Models.Entities.MainPage;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leoka.Elementary.Platform.Models.Mappings.MainPage;

public partial class MainFonMentorConfiguration : IEntityTypeConfiguration<MainFonMentorEntity>
{
    public void Configure(EntityTypeBuilder<MainFonMentorEntity> entity)
    {
        entity.ToTable("MainFonMentor", "dbo");

        entity.HasKey(e => e.FonId);
        
        entity.Property(e => e.FonId)
            .HasColumnName("FonId")
            .HasColumnType("int4")
            .ValueGeneratedNever();
        
        entity.Property(e => e.FonTitle)
            .HasColumnName("FonTitle")
            .HasColumnType("varchar(200)")
            .HasMaxLength(200)
            .IsRequired();
        
        entity.Property(e => e.FonSubTitle)
            .HasColumnName("FonSubTitle")
            .HasColumnType("varchar(400)")
            .HasMaxLength(400)
            .IsRequired();
        
        entity.Property(e => e.FonSubTitleId)
            .HasColumnName("FonSubTitleId")
            .HasColumnType("int4")
            .IsRequired();

        entity.HasIndex(u => u.FonId)
            .HasName("MainFonStudent_pkey")
            .IsUnique();
        
        entity.HasIndex(u => u.FonSubTitleId)
            .HasName("Uniq_MainFonStudent_FonSubTitleId")
            .IsUnique();

        OnConfigurePartial(entity);
    }

    partial void OnConfigurePartial(EntityTypeBuilder<MainFonMentorEntity> entity);
}