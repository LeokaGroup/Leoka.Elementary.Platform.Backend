using Leoka.Elementary.Platform.Models.Entities.Profile;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leoka.Elementary.Platform.Models.Mappings.Profile;

public partial class ProfileMenuItemConfiguration : IEntityTypeConfiguration<ProfileMenuItemEntity>
{
    public void Configure(EntityTypeBuilder<ProfileMenuItemEntity> entity)
    {
        entity.ToTable("ProfileMenuItems", "Profile");

        entity.HasKey(e => e.ProfileMenuId);
        
        entity.Property(e => e.ProfileMenuId)
            .HasColumnName("ProfileMenuId")
            .HasColumnType("serial")
            .ValueGeneratedNever();

        entity.Property(e => e.ProfileItemUrl)
            .HasColumnName("ProfileItemUrl")
            .HasColumnType("text");

        entity.Property(e => e.ProfileItemTitle)
            .HasColumnName("ProfileItemTitle")
            .HasColumnType("varchar(200)")
            .HasMaxLength(200)
            .IsRequired();
        
        entity.Property(e => e.ProfileItemSysName)
            .HasColumnName("ProfileItemSysName")
            .HasColumnType("varchar(200)")
            .HasMaxLength(200)
            .IsRequired();
        
        entity.Property(e => e.Position)
            .HasColumnName("Position")
            .HasColumnType("int")
            .HasDefaultValue(0)
            .IsRequired();
        
        entity.Property(e => e.RoleId)
            .HasColumnName("RoleId")
            .HasColumnType("int")
            .HasDefaultValue(1)
            .IsRequired();
        
        entity.Property(e => e.IsSelectItem)
            .HasColumnName("IsSelectItem")
            .HasColumnType("boolean")
            .IsRequired();
        
        entity.Property(e => e.MenuType)
            .HasColumnName("MenuType")
            .HasColumnType("int4")
            .IsRequired();
        
        entity.Property(e => e.IconUrl)
            .HasColumnName("IconUrl")
            .HasColumnType("text");
        
        entity.Property(e => e.IsVisibleBalance)
            .HasColumnName("IsVisibleBalance")
            .HasColumnType("boolean")
            .IsRequired();
        
        entity.Property(e => e.IsDropdown)
            .HasColumnName("IsDropdown")
            .HasColumnType("boolean")
            .IsRequired();
        
        entity.HasIndex(u => u.ProfileMenuId)
            .HasName("ProfileMenuItems_pkey")
            .IsUnique();

        OnConfigurePartial(entity);
    }

    partial void OnConfigurePartial(EntityTypeBuilder<ProfileMenuItemEntity> entity);
}