using Leoka.Elementary.Platform.Models.Entities.Profile;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leoka.Elementary.Platform.Models.Mappings.Profile;

public partial class StudentLessonDurationConfiguration : IEntityTypeConfiguration<StudentLessonDurationEntity>
{
    public void Configure(EntityTypeBuilder<StudentLessonDurationEntity> entity)
    {
        entity.ToTable("StudentLessonDurations", "Profile");

        entity.HasKey(e => e.DurationId);
        
        entity.Property(e => e.DurationId)
            .HasColumnName("DurationId")
            .HasColumnType("bigserial")
            .ValueGeneratedNever();
        
        entity.Property(e => e.UserId)
            .HasColumnName("UserId")
            .HasColumnType("bigint")
            .IsRequired();

        entity.Property(e => e.Unit)
            .HasColumnName("Unit")
            .HasColumnType("varchar(50)")
            .IsRequired();
        
        entity.Property(e => e.Time)
            .HasColumnName("Time")
            .HasColumnType("int4")
            .IsRequired();
        
        entity.HasIndex(u => u.DurationId)
            .HasName("PK_DurationId")
            .IsUnique();

        OnConfigurePartial(entity);
    }

    partial void OnConfigurePartial(EntityTypeBuilder<StudentLessonDurationEntity> entity);
}