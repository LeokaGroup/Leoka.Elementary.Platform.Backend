using Leoka.Elementary.Platform.Models.Entities.MainPage;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leoka.Elementary.Platform.Models.Mappings.MainPage;

public partial class SmartClassStudentItemConfiguration : IEntityTypeConfiguration<SmartClassStudentItemEntity>
{
    public void Configure(EntityTypeBuilder<SmartClassStudentItemEntity> entity)
    {
        entity.ToTable("SmartClassStudentItems", "dbo");

        entity.HasKey(e => e.ItemId);
        
        entity.Property(e => e.ItemId)
            .HasColumnName("ItemId")
            .HasColumnType("int4")
            .ValueGeneratedNever();
        
        entity.Property(e => e.SmartItemTitle)
            .HasColumnName("SmartItemTitle")
            .HasColumnType("varchar(200)")
            .HasMaxLength(200)
            .IsRequired();
        
        entity.Property(e => e.SmartItemSubTitle)
            .HasColumnName("SmartItemSubTitle")
            .HasColumnType("varchar(400)")
            .HasMaxLength(400)
            .IsRequired();
        
        entity.HasIndex(u => u.ItemId)
            .HasName("SmartClassStudentItems_pkey")
            .IsUnique();
        
        entity.HasOne(p => p.SmartClassStudent)
            .WithMany(b => b.SmartClassStudentItems)
            .HasForeignKey(p => p.SmartClassItemId)
            .HasConstraintName("MainBestQuestionOptions_QuestionId_fkey");
        
        OnConfigurePartial(entity);
    }

    partial void OnConfigurePartial(EntityTypeBuilder<SmartClassStudentItemEntity> entity);
}