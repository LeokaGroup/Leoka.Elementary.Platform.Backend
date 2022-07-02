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
            .HasColumnType("bigserial");

        entity.Property(e => e.Position)
            .HasColumnName("Position")
            .HasColumnType("int")
            .IsRequired();
        
        entity.Property(e => e.UserId)
            .HasColumnName("UserId")
            .HasColumnType("bigint")
            .IsRequired();
        
        entity.Property(e => e.ItemNumber)
            .HasColumnName("ItemNumber")
            .HasColumnType("int4")
            .IsRequired();

        entity.HasIndex(u => u.ItemId)
            .HasDatabaseName("PK_MentorProfileItemsItemId")
            .IsUnique();

        OnConfigurePartial(entity);
    }

    partial void OnConfigurePartial(EntityTypeBuilder<MentorProfileItemEntity> entity);
}