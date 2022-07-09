using Leoka.Elementary.Platform.Models.Entities.Template;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leoka.Elementary.Platform.Models.Mappings.LessonTemplate;

public partial class LessonUserTemplateConfiguration : IEntityTypeConfiguration<LessonUserTemplateEntity>
{
    public void Configure(EntityTypeBuilder<LessonUserTemplateEntity> entity)
    {
        entity.ToTable("LessonUserTemplates", "LessonTemplates");

        entity.HasKey(e => e.TemplateId);
        
        entity.Property(e => e.TemplateId)
            .HasColumnName("TemplateId")
            .HasColumnType("bigserial");

        entity.Property(e => e.Template)
            .HasColumnName("Template")
            .HasColumnType("xml")
            .IsRequired();

        entity.Property(e => e.UserId)
            .HasColumnName("UserId")
            .HasColumnType("bigint")
            .IsRequired();
        
        entity.HasIndex(u => u.TemplateId)
            .HasDatabaseName("PK_TemplateId")
            .IsUnique();

        OnConfigurePartial(entity);
    }

    partial void OnConfigurePartial(EntityTypeBuilder<LessonUserTemplateEntity> entity);
}