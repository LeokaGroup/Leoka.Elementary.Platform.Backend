using Leoka.Elementary.Platform.Models.Entities.Profile;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leoka.Elementary.Platform.Models.Mappings.Profile;

public partial class MentorEducationConfiguration : IEntityTypeConfiguration<MentorEducationEntity>
{
    public void Configure(EntityTypeBuilder<MentorEducationEntity> entity)
    {
        entity.ToTable("MentorEducations", "Profile");

        entity.HasKey(e => e.EducationId);
        
        entity.Property(e => e.EducationId)
            .HasColumnName("EducationId")
            .HasColumnType("bigserial");
        
        entity.Property(e => e.EducationText)
            .HasColumnName("EducationText")
            .HasColumnType("text")
            .IsRequired();

        entity.Property(e => e.UserId)
            .HasColumnName("UserId")
            .HasColumnType("bigint")
            .IsRequired();

        entity.HasIndex(u => u.EducationId)
            .HasName("PK_MentorEducationsEducationId")
            .IsUnique();

        OnConfigurePartial(entity);
    }

    partial void OnConfigurePartial(EntityTypeBuilder<MentorEducationEntity> entity);
}