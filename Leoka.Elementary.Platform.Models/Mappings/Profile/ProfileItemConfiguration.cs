using Leoka.Elementary.Platform.Models.Entities.Profile;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leoka.Elementary.Platform.Models.Mappings.Profile;

public partial class ProfileItemConfiguration : IEntityTypeConfiguration<ProfileItemEntity>
{
    public void Configure(EntityTypeBuilder<ProfileItemEntity> entity)
    {
        entity.ToTable("ProfileItems", "Profile");

        entity.HasKey(e => e.ProfileItemId);
        
        entity.Property(e => e.ProfileItemId)
            .HasColumnName("ProfileItemId")
            .HasColumnType("serial");
        
        entity.Property(e => e.ItemName)
            .HasColumnName("ItemName")
            .HasColumnType("varchar(200)")
            .HasMaxLength(200)
            .IsRequired();
        
        entity.Property(e => e.ItemSysName)
            .HasColumnName("ItemSysName")
            .HasColumnType("varchar(200)")
            .HasMaxLength(200)
            .IsRequired();
        
        entity.Property(e => e.Position)
            .HasColumnName("Position")
            .HasColumnType("int4")
            .HasDefaultValue(0)
            .IsRequired();
        
        entity.Property(e => e.ItemNumber)
            .HasColumnName("ItemNumber")
            .HasColumnType("int4")
            .HasDefaultValue(0)
            .IsRequired();
        
        entity.HasIndex(u => u.ProfileItemId)
            .HasName("ProfileItems_pkey")
            .IsUnique();

        OnConfigurePartial(entity);
    }

    partial void OnConfigurePartial(EntityTypeBuilder<ProfileItemEntity> entity);
}