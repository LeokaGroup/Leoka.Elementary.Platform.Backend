using Leoka.Elementary.Platform.Models.Entities.Profile;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leoka.Elementary.Platform.Models.Mappings.Profile;

public partial class MentorTimeConfiguration : IEntityTypeConfiguration<MentorTimeEntity>
{
    public void Configure(EntityTypeBuilder<MentorTimeEntity> entity)
    {
        entity.ToTable("MentorTimes", "Profile");

        entity.HasKey(e => e.TimeId);
        
        entity.Property(e => e.TimeId)
            .HasColumnName("TimeId")
            .HasColumnType("bigserial");
        
        entity.Property(e => e.TimeStart)
            .HasColumnName("TimeStart")
            .HasColumnType("time")
            .IsRequired();
        
        entity.Property(e => e.TimeEnd)
            .HasColumnName("TimeEnd")
            .HasColumnType("time")
            .IsRequired();
        
        entity.Property(e => e.Day)
            .HasColumnName("Day")
            .HasColumnType("varchar(100)")
            .IsRequired();

        entity.Property(e => e.UserId)
            .HasColumnName("UserId")
            .HasColumnType("bigint")
            .IsRequired();

        entity.HasIndex(u => u.TimeId)
            .HasName("PK_MentorTimesTimeId")
            .IsUnique();

        OnConfigurePartial(entity);
    }

    partial void OnConfigurePartial(EntityTypeBuilder<MentorTimeEntity> entity);
}