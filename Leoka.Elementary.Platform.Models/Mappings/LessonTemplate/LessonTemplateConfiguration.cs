using Leoka.Elementary.Platform.Models.Entities.Template;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leoka.Elementary.Platform.Models.Mappings.LessonTemplate;

public partial class LessonTemplateConfiguration : IEntityTypeConfiguration<LessonTemplateEntity>
{
    public void Configure(EntityTypeBuilder<LessonTemplateEntity> entity)
    {
        entity.ToTable("LessonTemplates", "LessonTemplates");

        entity.HasKey(e => e.TemplateId);
        
        entity.Property(e => e.TemplateId)
            .HasColumnName("TemplateId")
            .HasColumnType("bigserial");
        
        entity.Property(e => e.TemplateItemId)
            .HasColumnName("TemplateItemId")
            .HasColumnType("bigint")
            .IsRequired();
        
        entity.Property(e => e.Template)
            .HasColumnName("Template")
            .HasColumnType("xml")
            .IsRequired();

        entity.Property(e => e.TemplateType)
            .HasColumnName("TemplateType")
            .HasColumnType("varchar(300)")
            .IsRequired();
        
        entity.Property(e => e.TemplateName)
            .HasColumnName("TemplateName")
            .HasColumnType("varchar(150)")
            .IsRequired();
        
        entity.HasIndex(u => u.TemplateId)
            .HasDatabaseName("PK_TemplateId")
            .IsUnique();

        OnConfigurePartial(entity);
    }

    partial void OnConfigurePartial(EntityTypeBuilder<LessonTemplateEntity> entity);
}