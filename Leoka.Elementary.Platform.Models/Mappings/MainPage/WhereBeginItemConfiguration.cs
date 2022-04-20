using Leoka.Elementary.Platform.Models.Entities.MainPage;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leoka.Elementary.Platform.Models.Mappings.MainPage;

public partial class WhereBeginItemConfiguration : IEntityTypeConfiguration<WhereBeginItemEntity>
{
    public void Configure(EntityTypeBuilder<WhereBeginItemEntity> entity)
    {
        entity.ToTable("WhereBeginItems", "dbo");

        entity.HasKey(e => e.ItemId);
        
        entity.Property(e => e.ItemId)
            .HasColumnName("ItemId")
            .HasColumnType("int4")
            .ValueGeneratedNever();
        
        entity.Property(e => e.BeginUrlIcon)
            .HasColumnName("BeginUrlIcon")
            .HasColumnType("text")
            .IsRequired();
        
        entity.Property(e => e.BeginTitle)
            .HasColumnName("BeginTitle")
            .HasColumnType("varchar(150)")
            .HasMaxLength(150)
            .IsRequired();
        
        entity.Property(e => e.BeginSubTitle)
            .HasColumnName("BeginSubTitle")
            .HasColumnType("varchar(150)")
            .HasMaxLength(150)
            .IsRequired();
        
        entity.HasIndex(u => u.ItemId)
            .HasName("WhereBeginItems_pkey")
            .IsUnique();
        
        entity.HasIndex(u => u.BeginItemId)
            .HasName("WhereBeginItems_BeginItemId_fkey")
            .IsUnique();
        
        entity.HasOne(p => p.WhereBegin)
            .WithMany(b => b.WhereBeginItems)
            .HasForeignKey(p => p.BeginItemId)
            .HasConstraintName("WhereBeginItems_BeginItemId_fkey");
        
        OnConfigurePartial(entity);
    }

    partial void OnConfigurePartial(EntityTypeBuilder<WhereBeginItemEntity> entity);
}