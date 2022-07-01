using Leoka.Elementary.Platform.Models.Entities.MainPage;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leoka.Elementary.Platform.Models.Mappings.MainPage;

public partial class MainFonStudentItemConfiguration : IEntityTypeConfiguration<MainFonStudentItemEntity>
{
    public void Configure(EntityTypeBuilder<MainFonStudentItemEntity> entity)
    {
        entity.ToTable("MainFonStudentItems", "dbo");

        entity.HasKey(e => e.ItemId);
        
        entity.Property(e => e.ItemId)
            .HasColumnName("ItemId")
            .HasColumnType("serial")
            .ValueGeneratedNever();
        
        entity.Property(e => e.FonSubTitleId)
            .HasColumnName("FonSubTitleId")
            .HasColumnType("int4")
            .IsRequired();
        
        entity.Property(e => e.FonSubTitleText)
            .HasColumnName("FonSubTitleText")
            .HasColumnType("varchar(150)")
            .HasMaxLength(150)
            .IsRequired();
        
        entity.HasIndex(u => u.ItemId)
            .HasDatabaseName("MainFonStudentItems_pkey")
            .IsUnique();
        
        entity.HasOne(p => p.MainFonStudent)
            .WithMany(b => b.MainFonStudentItems)
            .HasForeignKey(p => p.FonSubTitleId)
            .HasConstraintName("FK_MainFonStudent_FonSubTitleId");
        
        OnConfigurePartial(entity);
    }

    partial void OnConfigurePartial(EntityTypeBuilder<MainFonStudentItemEntity> entity);
}