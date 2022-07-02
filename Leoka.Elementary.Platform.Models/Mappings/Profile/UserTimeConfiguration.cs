using Leoka.Elementary.Platform.Models.Entities.Profile;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leoka.Elementary.Platform.Models.Mappings.Profile;

public partial class UserTimeConfiguration : IEntityTypeConfiguration<UserTimeEntity>
{
    public void Configure(EntityTypeBuilder<UserTimeEntity> entity)
    {
        entity.ToTable("UserTimes", "Profile");

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
        
        entity.Property(e => e.DayId)
            .HasColumnName("DayId")
            .HasColumnType("int4")
            .IsRequired();

        entity.Property(e => e.UserId)
            .HasColumnName("UserId")
            .HasColumnType("bigint")
            .IsRequired();

        entity.HasIndex(u => u.TimeId)
            .HasDatabaseName("PK_MentorTimesTimeId")
            .IsUnique();

        OnConfigurePartial(entity);
    }

    partial void OnConfigurePartial(EntityTypeBuilder<UserTimeEntity> entity);
}