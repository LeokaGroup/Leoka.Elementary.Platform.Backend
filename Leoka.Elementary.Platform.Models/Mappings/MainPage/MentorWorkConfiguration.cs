using Leoka.Elementary.Platform.Models.Entities.MainPage;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leoka.Elementary.Platform.Models.Mappings.MainPage;

public partial class MentorWorkConfiguration : IEntityTypeConfiguration<MentorWorkEntity>
{
    public void Configure(EntityTypeBuilder<MentorWorkEntity> entity)
    {
        entity.ToTable("MentorWork", "dbo");

        entity.HasKey(e => e.MentorWorkId);
        
        entity.Property(e => e.MentorWorkId)
            .HasColumnName("MentorWorkId")
            .HasColumnType("int4")
            .ValueGeneratedNever();
        
        entity.Property(e => e.MentorWorkTitle)
            .HasColumnName("MentorWorkTitle")
            .HasColumnType("varchar(100)")
            .HasMaxLength(100)
            .IsRequired();
        
        entity.Property(e => e.MentorWorkSubTitle)
            .HasColumnName("MentorWorkSubTitle")
            .HasColumnType("varchar(100)")
            .HasMaxLength(100)
            .IsRequired();
        
        entity.Property(e => e.MentorWorkButtonText)
            .HasColumnName("MentorWorkButtonText")
            .HasColumnType("varchar(50)")
            .HasMaxLength(50)
            .IsRequired();
        
        entity.Property(e => e.MentorWorkUrl)
            .HasColumnName("MentorWorkUrl")
            .HasColumnType("text")
            .IsRequired();
        
        entity.Property(e => e.UrlIconMentor)
            .HasColumnName("UrlIconMentor")
            .HasColumnType("text");

        entity.HasIndex(u => u.MentorWorkUrl)
            .HasName("MainFonStudent_pkey")
            .IsUnique();
        
        entity.HasIndex(u => u.MentorWorkId)
            .HasName("MentorWork_pkey")
            .IsUnique();

        OnConfigurePartial(entity);
    }

    partial void OnConfigurePartial(EntityTypeBuilder<MentorWorkEntity> entity);
}