using Leoka.Elementary.Platform.Models.Entities.Profile;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leoka.Elementary.Platform.Models.Mappings.Profile;

public partial class MentorProfileItemConfiguration : IEntityTypeConfiguration<MentorProfileItemEntity>
{
    public void Configure(EntityTypeBuilder<MentorProfileItemEntity> entity)
    {
        entity.ToTable("MentorProfileItems", "Profile");

        entity.HasKey(e => e.ItemId);
        
        entity.Property(e => e.ItemId)
            .HasColumnName("ItemId")
            .HasColumnType("bigserial")
            .ValueGeneratedNever();
        
        entity.Property(e => e.ItemName)
            .HasColumnName("ItemName")
            .HasColumnType("varchar(200)")
            .IsRequired();
        
        entity.Property(e => e.ItemSysName)
            .HasColumnName("ItemSysName")
            .HasColumnType("varchar(200)")
            .IsRequired();
        
        entity.Property(e => e.Position)
            .HasColumnName("Position")
            .HasColumnType("int")
            .IsRequired();
        
        entity.Property(e => e.UserId)
            .HasColumnName("UserId")
            .HasColumnType("bigint")
            .IsRequired();

        entity.HasIndex(u => u.ItemId)
            .HasName("PK_MentorProfileItemsItemId")
            .IsUnique();

        OnConfigurePartial(entity);
    }

    partial void OnConfigurePartial(EntityTypeBuilder<MentorProfileItemEntity> entity);
}