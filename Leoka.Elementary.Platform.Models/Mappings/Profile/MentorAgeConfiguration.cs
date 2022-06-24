using Leoka.Elementary.Platform.Models.Entities.Profile;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leoka.Elementary.Platform.Models.Mappings.Profile;

public partial class MentorAgeConfiguration : IEntityTypeConfiguration<MentorAgeEntity>
{
    public void Configure(EntityTypeBuilder<MentorAgeEntity> entity)
    {
        entity.ToTable("MentorAge", "Profile");

        entity.HasKey(e => e.AgeId);
        
        entity.Property(e => e.AgeId)
            .HasColumnName("AgeId")
            .HasColumnType("serial")
            .ValueGeneratedNever();

        entity.Property(e => e.StartAge)
            .HasColumnName("StartAge")
            .HasColumnType("varchar(50)");

        entity.Property(e => e.EndAge)
            .HasColumnName("EndAge")
            .HasColumnType("varchar(50)");

        OnConfigurePartial(entity);
    }

    partial void OnConfigurePartial(EntityTypeBuilder<MentorAgeEntity> entity);
}