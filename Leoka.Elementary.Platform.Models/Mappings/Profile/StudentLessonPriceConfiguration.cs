using Leoka.Elementary.Platform.Models.Entities.Profile;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leoka.Elementary.Platform.Models.Mappings.Profile;

public partial class StudentLessonPriceConfiguration : IEntityTypeConfiguration<StudentLessonPriceEntity>
{
    public void Configure(EntityTypeBuilder<StudentLessonPriceEntity> entity)
    {
        entity.ToTable("StudentLessonPrices", "Profile");

        entity.HasKey(e => e.PriceId);
        
        entity.Property(e => e.PriceId)
            .HasColumnName("PriceId")
            .HasColumnType("bigserial")
            .ValueGeneratedNever();
        
        entity.Property(e => e.UserId)
            .HasColumnName("UserId")
            .HasColumnType("bigint")
            .IsRequired();
        
        entity.Property(e => e.Price)
            .HasColumnName("Price")
            .HasColumnType("numeric")
            .IsRequired();
        
        entity.Property(e => e.Unit)
            .HasColumnName("Unit")
            .HasColumnType("varchar(50)")
            .IsRequired();
        
        entity.HasIndex(u => u.PriceId)
            .HasName("PK_PriceId")
            .IsUnique();

        OnConfigurePartial(entity);
    }

    partial void OnConfigurePartial(EntityTypeBuilder<StudentLessonPriceEntity> entity);
}