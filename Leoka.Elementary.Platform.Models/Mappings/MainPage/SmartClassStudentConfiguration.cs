using Leoka.Elementary.Platform.Models.Entities.MainPage;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leoka.Elementary.Platform.Models.Mappings.MainPage;

public partial class SmartClassStudentConfiguration : IEntityTypeConfiguration<SmartClassStudentEntity>
{
    public void Configure(EntityTypeBuilder<SmartClassStudentEntity> entity)
    {
        entity.ToTable("SmartClassStudent", "dbo");

        entity.HasKey(e => e.SmartClassId);
        
        entity.Property(e => e.SmartClassId)
            .HasColumnName("SmartClassId")
            .HasColumnType("int4")
            .ValueGeneratedNever();
        
        entity.Property(e => e.SmartClassTitle)
            .HasColumnName("SmartClassTitle")
            .HasColumnType("varchar(150)")
            .HasMaxLength(150)
            .IsRequired();
        
        entity.Property(e => e.SmartClassSubTitle)
            .HasColumnName("SmartClassSubTitle")
            .HasColumnType("varchar(200)")
            .HasMaxLength(200)
            .IsRequired();
        
        entity.Property(e => e.SmartClassUrlPreview)
            .HasColumnName("SmartClassUrlPreview")
            .HasColumnType("text")
            .IsRequired();

        entity.HasIndex(u => u.SmartClassId)
            .HasName("SmartClassStudent_pkey")
            .IsUnique();
        
        entity.HasIndex(u => u.SmartClassItemId)
            .HasName("Uniq_SmartClassStudent_SmartClassItemId")
            .IsUnique();

        OnConfigurePartial(entity);
    }

    partial void OnConfigurePartial(EntityTypeBuilder<SmartClassStudentEntity> entity);
}