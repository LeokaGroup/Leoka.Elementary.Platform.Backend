using Leoka.Elementary.Platform.Models.Entities.MainPage;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leoka.Elementary.Platform.Models.Mappings.MainPage;

public partial class AboutPlatformConfiguration : IEntityTypeConfiguration<AboutPlatformEntity>
{
    public void Configure(EntityTypeBuilder<AboutPlatformEntity> entity)
    {
        entity.ToTable("AboutPlatform", "dbo");

        entity.HasKey(e => e.AboutId);
        
        entity.Property(e => e.AboutId)
            .HasColumnName("AboutId")
            .HasColumnType("int4")
            .ValueGeneratedNever();

        entity.Property(e => e.AboutTitle)
            .HasColumnName("AboutTitle")
            .HasColumnType("varchar(100)")
            .HasMaxLength(100)
            .IsRequired();

        entity.Property(e => e.AboutSubTitle)
            .HasColumnName("AboutSubTitle")
            .HasColumnType("varchar(100)")
            .HasMaxLength(100)
            .IsRequired();
        ;
        entity.Property(e => e.AboutStudentTitle)
            .HasColumnName("AboutStudentTitle")
            .HasColumnType("varchar(100)")
            .HasMaxLength(100)
            .IsRequired();
        
        entity.Property(e => e.AboutStudentSubTitle)
            .HasColumnName("AboutStudentSubTitle")
            .HasColumnType("varchar(400)")
            .HasMaxLength(400)
            .IsRequired();
        
        entity.Property(e => e.AboutMentorTitle)
            .HasColumnName("AboutMentorTitle")
            .HasColumnType("varchar(100)")
            .HasMaxLength(100)
            .IsRequired();
        
        entity.Property(e => e.AboutMentorSubTitle)
            .HasColumnName("AboutMentorSubTitle")
            .HasColumnType("varchar(400)")
            .HasMaxLength(400)
            .IsRequired();

        entity.Property(e => e.UrlIconStudent)
            .HasColumnName("UrlIconStudent")
            .HasColumnType("text");
        
        entity.Property(e => e.UrlIconMentor)
            .HasColumnName("UrlIconMentor")
            .HasColumnType("text");

        entity.HasIndex(u => u.AboutId)
            .HasName("AboutPlatform_pkey")
            .IsUnique();

        OnConfigurePartial(entity);
    }

    partial void OnConfigurePartial(EntityTypeBuilder<AboutPlatformEntity> entity);
}