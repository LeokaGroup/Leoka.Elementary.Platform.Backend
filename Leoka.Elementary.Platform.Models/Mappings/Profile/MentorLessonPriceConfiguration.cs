using Leoka.Elementary.Platform.Models.Entities.Profile;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leoka.Elementary.Platform.Models.Mappings.Profile;

public partial class MentorLessonPriceConfiguration : IEntityTypeConfiguration<UserLessonPriceEntity>
{
    public void Configure(EntityTypeBuilder<UserLessonPriceEntity> entity)
    {
        entity.ToTable("UserLessonPrices", "Profile");

        entity.HasKey(e => e.PriceId);
        
        entity.Property(e => e.PriceId)
            .HasColumnName("PriceId")
            .HasColumnType("bigserial");
        
        entity.Property(e => e.Price)
            .HasColumnName("Price")
            .HasColumnType("money")
            .IsRequired();
        
        entity.Property(e => e.Unit)
            .HasColumnName("Unit")
            .HasColumnType("varchar(50)")
            .IsRequired();
        
        entity.Property(e => e.UserId)
            .HasColumnName("UserId")
            .HasColumnType("bigint")
            .IsRequired();

        entity.HasIndex(u => u.PriceId)
            .HasName("PK_MentorLessonPricesPriceId")
            .IsUnique();

        OnConfigurePartial(entity);
    }

    partial void OnConfigurePartial(EntityTypeBuilder<UserLessonPriceEntity> entity);
}