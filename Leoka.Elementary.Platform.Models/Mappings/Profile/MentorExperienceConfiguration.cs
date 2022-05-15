using Leoka.Elementary.Platform.Models.Entities.Profile;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leoka.Elementary.Platform.Models.Mappings.Profile;

public partial class MentorExperienceConfiguration : IEntityTypeConfiguration<MentorExperienceEntity>
{
    public void Configure(EntityTypeBuilder<MentorExperienceEntity> entity)
    {
        entity.ToTable("MentorExperience", "Profile");

        entity.HasKey(e => e.ExperienceId);
        
        entity.Property(e => e.ExperienceId)
            .HasColumnName("ExperienceId")
            .HasColumnType("bigserial")
            .ValueGeneratedNever();
        
        entity.Property(e => e.ExperienceText)
            .HasColumnName("ExperienceText")
            .HasColumnType("text")
            .IsRequired();

        entity.Property(e => e.UserId)
            .HasColumnName("UserId")
            .HasColumnType("bigint")
            .IsRequired();

        entity.HasIndex(u => u.ExperienceId)
            .HasName("PK_MentorExperienceExperienceId")
            .IsUnique();

        OnConfigurePartial(entity);
    }

    partial void OnConfigurePartial(EntityTypeBuilder<MentorExperienceEntity> entity);
}