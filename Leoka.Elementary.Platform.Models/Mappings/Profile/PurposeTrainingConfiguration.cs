using Leoka.Elementary.Platform.Models.Entities.Profile;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leoka.Elementary.Platform.Models.Mappings.Profile;

public partial class PurposeTrainingConfiguration : IEntityTypeConfiguration<PurposeTrainingEntity>
{
    public void Configure(EntityTypeBuilder<PurposeTrainingEntity> entity)
    {
        entity.ToTable("PurposeTrainings", "Profile");

        entity.HasKey(e => e.PurposeId);

        entity.Property(e => e.PurposeId)
            .HasColumnName("PurposeId")
            .HasColumnType("serial");

        entity.Property(e => e.PurposeSysName)
            .HasColumnName("PurposeSysName")
            .HasMaxLength(200)
            .HasColumnType("varchar(200)")
            .IsRequired();

        entity.Property(e => e.PurposeName)
            .HasColumnName("PurposeName")
            .HasColumnType("varchar(200)")
            .HasMaxLength(200)
            .IsRequired();

        entity.HasIndex(u => u.PurposeId)
            .HasName("LessonsDuration_pkey")
            .IsUnique();

        OnConfigurePartial(entity);
    }

    partial void OnConfigurePartial(EntityTypeBuilder<PurposeTrainingEntity> entity);
}