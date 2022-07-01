using Leoka.Elementary.Platform.Models.Entities.Profile;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leoka.Elementary.Platform.Models.Mappings.Profile;

public partial class DayWeekConfiguration : IEntityTypeConfiguration<DayWeekEntity>
{
    public void Configure(EntityTypeBuilder<DayWeekEntity> entity)
    {
        entity.ToTable("DaysWeek", "Profile");

        entity.HasKey(e => e.DayId);

        entity.Property(e => e.DayId)
            .HasColumnName("DayId")
            .HasColumnType("serial");

        entity.Property(e => e.DayName)
            .HasColumnName("DayName")
            .HasMaxLength(100)
            .HasColumnType("varchar(100)")
            .IsRequired();

        entity.Property(e => e.DaySysName)
            .HasColumnName("DaySysName")
            .HasColumnType("varchar(100)")
            .HasMaxLength(100)
            .IsRequired();
        
        entity.Property(e => e.Position)
            .HasColumnName("Position")
            .HasColumnType("int4")
            .IsRequired();

        entity.HasIndex(u => u.DayId)
            .HasDatabaseName("PK_DaysWeekDayId")
            .IsUnique();

        OnConfigurePartial(entity);
    }

    partial void OnConfigurePartial(EntityTypeBuilder<DayWeekEntity> entity);
}