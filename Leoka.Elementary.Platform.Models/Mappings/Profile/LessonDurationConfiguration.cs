using Leoka.Elementary.Platform.Models.Entities.Profile;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leoka.Elementary.Platform.Models.Mappings.Profile;

public partial class LessonDurationConfiguration : IEntityTypeConfiguration<LessonDurationEntity>
{
    public void Configure(EntityTypeBuilder<LessonDurationEntity> entity)
    {
        entity.ToTable("LessonsDuration", "Profile");

        entity.HasKey(e => e.DurationId);

        entity.Property(e => e.DurationId)
            .HasColumnName("DurationId")
            .HasColumnType("serial")
            .ValueGeneratedNever();

        entity.Property(e => e.Time)
            .HasColumnName("Time")
            .HasColumnType("int4");

        entity.Property(e => e.Unit)
            .HasColumnName("Unit")
            .HasColumnType("varchar(50)")
            .HasMaxLength(50)
            .HasDefaultValue("мин")
            .IsRequired();

        entity.HasIndex(u => u.DurationId)
            .HasName("LessonsDuration_pkey")
            .IsUnique();

        OnConfigurePartial(entity);
    }

    partial void OnConfigurePartial(EntityTypeBuilder<LessonDurationEntity> entity);
}