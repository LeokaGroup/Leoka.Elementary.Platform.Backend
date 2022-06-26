using Leoka.Elementary.Platform.Models.Entities.Profile;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leoka.Elementary.Platform.Models.Mappings.Profile;

public partial class StudentProfileItemConfiguration : IEntityTypeConfiguration<StudentProfileItemEntity>
{
    public void Configure(EntityTypeBuilder<StudentProfileItemEntity> entity)
    {
        entity.ToTable("StudentProfileItems", "Profile");

        entity.HasKey(e => e.ItemId);
        
        entity.Property(e => e.ItemId)
            .HasColumnName("ItemId")
            .HasColumnType("bigserial")
            .ValueGeneratedNever();
        
        entity.Property(e => e.UserId)
            .HasColumnName("UserId")
            .HasColumnType("bigint")
            .IsRequired();
        
        entity.Property(e => e.Position)
            .HasColumnName("Position")
            .HasColumnType("int4")
            .IsRequired();
        
        entity.Property(e => e.ItemNumber)
            .HasColumnName("ItemNumber")
            .HasColumnType("int4")
            .IsRequired();
        
        entity.HasIndex(u => u.ItemId)
            .HasName("PK_ItemId")
            .IsUnique();

        OnConfigurePartial(entity);
    }

    partial void OnConfigurePartial(EntityTypeBuilder<StudentProfileItemEntity> entity);
}