using Leoka.Elementary.Platform.Models.Entities.Profile;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leoka.Elementary.Platform.Models.Mappings.Profile;

public partial class MentorLessonDurationConfiguration : IEntityTypeConfiguration<MentorLessonDurationEntity>
{
    public void Configure(EntityTypeBuilder<MentorLessonDurationEntity> entity)
    {
        entity.ToTable("MentorLessonDurations", "Profile");

        entity.HasKey(e => e.DurationId);
        
        entity.Property(e => e.DurationId)
            .HasColumnName("DurationId")
            .HasColumnType("bigserial");
        
        entity.Property(e => e.Time)
            .HasColumnName("Time")
            .HasColumnType("int4")
            .IsRequired();
        
        entity.Property(e => e.Unit)
            .HasColumnName("Unit")
            .HasColumnType("varchar(50)")
            .IsRequired();
        
        entity.Property(e => e.UserId)
            .HasColumnName("UserId")
            .HasColumnType("bigint")
            .IsRequired();

        entity.HasIndex(u => u.DurationId)
            .HasName("PK_MentorLessonDurationsDurationId")
            .IsUnique();

        OnConfigurePartial(entity);
    }

    partial void OnConfigurePartial(EntityTypeBuilder<MentorLessonDurationEntity> entity);
}