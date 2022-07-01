using Leoka.Elementary.Platform.Models.Entities.MainPage;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leoka.Elementary.Platform.Models.Mappings.MainPage;

public partial class WhereBeginConfiguration : IEntityTypeConfiguration<WhereBeginEntity>
{
    public void Configure(EntityTypeBuilder<WhereBeginEntity> entity)
    {
        entity.ToTable("WhereBegin", "dbo");

        entity.HasKey(e => e.WhereBeginId);
        
        entity.Property(e => e.WhereBeginId)
            .HasColumnName("WhereBeginId")
            .HasColumnType("int4")
            .ValueGeneratedNever();
        
        entity.Property(e => e.WhereBeginTitle)
            .HasColumnName("WhereBeginTitle")
            .HasColumnType("varchar(100)")
            .HasMaxLength(100)
            .IsRequired();
        
        entity.Property(e => e.WhereBeginSubTitle)
            .HasColumnName("WhereBeginSubTitle")
            .HasColumnType("varchar(100)")
            .HasMaxLength(100)
            .IsRequired();
        
        entity.Property(e => e.BeginItemId)
            .HasColumnName("BeginItemId")
            .HasColumnType("int4")
            .IsRequired();
        
        entity.HasIndex(u => u.WhereBeginId)
            .HasDatabaseName("WhereBegin_pkey")
            .IsUnique();
        
        entity.HasIndex(u => u.BeginItemId)
            .HasDatabaseName("WhereBegin_BeginItemId_key")
            .IsUnique();
        
        OnConfigurePartial(entity);
    }

    partial void OnConfigurePartial(EntityTypeBuilder<WhereBeginEntity> entity);
}