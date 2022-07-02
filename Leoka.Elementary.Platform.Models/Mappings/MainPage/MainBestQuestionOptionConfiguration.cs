using Leoka.Elementary.Platform.Models.Entities.MainPage;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leoka.Elementary.Platform.Models.Mappings.MainPage;

public partial class MainBestQuestionOptionConfiguration : IEntityTypeConfiguration<MainBestQuestionOptionEntity>
{
    public void Configure(EntityTypeBuilder<MainBestQuestionOptionEntity> entity)
    {
        entity.ToTable("MainBestQuestionOptions", "dbo");

        entity.HasKey(e => e.MainBestQuestionVariantId);
        
        entity.Property(e => e.MainBestQuestionVariantId)
            .HasColumnName("MainBestQuestionVariantId")
            .HasColumnType("int4")
            .ValueGeneratedNever();

        entity.Property(e => e.QuestionId)
            .HasColumnName("QuestionId")
            .HasColumnType("int4")
            .IsRequired();
        
        entity.HasOne(p => p.MainBestQuestion)
            .WithMany(b => b.MainBestOptions)
            .HasForeignKey(p => p.QuestionId)
            .HasConstraintName("MainBestQuestionOptions_QuestionId_fkey");

        entity.Property(e => e.VariantText)
            .HasColumnName("VariantText")
            .HasColumnType("varchar(150)")
            .HasMaxLength(150)
            .IsRequired();
        ;
        entity.HasIndex(u => u.MainBestQuestionVariantId)
            .HasDatabaseName("MainBestQuestionOptions_pkey")
            .IsUnique();
        
        entity.HasIndex(u => u.QuestionId)
            .HasDatabaseName("Uniq_MainBestQuestionOptions_QuestionId")
            .IsUnique();

        OnConfigurePartial(entity);
    }

    partial void OnConfigurePartial(EntityTypeBuilder<MainBestQuestionOptionEntity> entity);
}