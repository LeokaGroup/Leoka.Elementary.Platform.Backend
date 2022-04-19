using Leoka.Elementary.Platform.Models.Entities.MainPage;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leoka.Elementary.Platform.Models.Mappings.MainPage;

public partial class MainBestQuestionConfiguration : IEntityTypeConfiguration<MainBestQuestionEntity>
{
    public void Configure(EntityTypeBuilder<MainBestQuestionEntity> entity)
    {
        entity.ToTable("MainBestQuestions", "dbo");

        entity.HasKey(e => e.QuestionId);
        
        entity.Property(e => e.QuestionId)
            .HasColumnName("QuestionId")
            .HasColumnType("int4")
            .ValueGeneratedNever();

        entity.Property(e => e.MainBestOptionBlockId)
            .HasColumnName("MainBestOptionBlockId")
            .HasColumnType("int4")
            .IsRequired();
        
        entity.HasOne(p => p.MainBestOption)
            .WithMany(b => b.MainBestQuestions)
            .HasForeignKey(p => p.MainBestOptionBlockId)
            .HasConstraintName("MainBestQuestionOptions_QuestionId_fkey");

        entity.Property(e => e.MainBestOptionQuestionText)
            .HasColumnName("MainBestOptionQuestionText")
            .HasColumnType("varchar(150)")
            .HasMaxLength(150)
            .IsRequired();
        ;
        entity.HasIndex(u => u.QuestionId)
            .HasName("MainBestQuestionOptions_pkey")
            .IsUnique();
        
        entity.HasIndex(u => u.MainBestOptionBlockId)
            .HasName("MainBestQuestions_MainBestOptionBlockId_fkey")
            .IsUnique();

        OnConfigurePartial(entity);
    }

    partial void OnConfigurePartial(EntityTypeBuilder<MainBestQuestionEntity> entity);
}