using Leoka.Elementary.Platform.Models.Entities.MainPage;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leoka.Elementary.Platform.Models.Mappings.MainPage;

public partial class MainBestQuestionAcceptAnswerConfiguration : IEntityTypeConfiguration<MainBestQuestionAcceptAnswerEntity>
{
    public void Configure(EntityTypeBuilder<MainBestQuestionAcceptAnswerEntity> entity)
    {
        entity.ToTable("MainBestQuestionAcceptAnswers", "dbo");

        entity.HasKey(e => e.AnswerId);
        
        entity.Property(e => e.AnswerId)
            .HasColumnName("AnswerId")
            .HasColumnType("int4")
            .ValueGeneratedNever();

        entity.Property(e => e.SelectedAnswer)
            .HasColumnName("SelectedAnswer")
            .HasColumnType("varchar(45)")
            .HasMaxLength(45);

        entity.HasOne(p => p.MainBestQuestionOption)
            .WithMany(b => b.MainBestQuestionAcceptAnswers)
            .HasForeignKey(p => p.QuestionVariantId)
            .HasConstraintName("MainBestQuestionOptions_QuestionId_fkey");
        
        entity.HasIndex(u => u.AnswerId)
            .HasName("MainBestQuestionAcceptAnswers_pkey")
            .IsUnique();
        
        entity.HasIndex(u => u.QuestionVariantId)
            .HasName("MainBestQuestionAcceptAnswers_QuestionVariantId_fkey")
            .IsUnique();

        OnConfigurePartial(entity);
    }

    partial void OnConfigurePartial(EntityTypeBuilder<MainBestQuestionAcceptAnswerEntity> entity);
}