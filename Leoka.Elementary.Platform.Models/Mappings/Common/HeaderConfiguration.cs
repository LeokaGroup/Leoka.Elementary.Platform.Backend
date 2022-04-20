using Leoka.Elementary.Platform.Models.Entities.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leoka.Elementary.Platform.Models.Mappings.Common;

public partial class HeaderConfiguration : IEntityTypeConfiguration<HeaderEntity>
{
    public void Configure(EntityTypeBuilder<HeaderEntity> entity)
    {
        entity.ToTable("Header", "dbo");

        entity.HasKey(e => e.HeaderId);
        
        entity.Property(e => e.HeaderId)
            .HasColumnName("HeaderId")
            .HasColumnType("int4")
            .ValueGeneratedNever();

        entity.Property(e => e.HeaderItem)
            .HasColumnName("HeaderItem")
            .HasColumnType("varchar(100)")
            .HasMaxLength(100)
            .IsRequired();

        entity.Property(e => e.HeaderActionSysName)
            .HasColumnName("HeaderActionSysName")
            .HasColumnType("varchar(150)")
            .HasMaxLength(150)
            .IsRequired();
        ;
        entity.Property(e => e.HeaderItemUrl)
            .HasColumnName("HeaderItemUrl")
            .HasColumnType("text");
        
        entity.Property(e => e.HeaderItemPosition)
            .HasColumnName("HeaderItemPosition")
            .HasColumnType("int4")
            .IsRequired();
        
        entity.HasIndex(u => u.HeaderId)
            .HasName("Header_pkey")
            .IsUnique();

        OnConfigurePartial(entity);
    }

    partial void OnConfigurePartial(EntityTypeBuilder<HeaderEntity> entity);
}