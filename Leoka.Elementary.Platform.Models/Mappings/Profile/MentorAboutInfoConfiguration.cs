using Leoka.Elementary.Platform.Models.Entities.Profile;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leoka.Elementary.Platform.Models.Mappings.Profile;

public partial class MentorAboutInfoConfiguration : IEntityTypeConfiguration<MentorAboutInfoEntity>
{
    public void Configure(EntityTypeBuilder<MentorAboutInfoEntity> entity)
    {
        entity.ToTable("MentorAboutInfo", "dbo");

        entity.HasKey(e => e.AboutInfoId);
        
        entity.Property(e => e.AboutInfoId)
            .HasColumnName("AboutInfoId")
            .HasColumnType("bigserial")
            .ValueGeneratedNever();
        
        entity.Property(e => e.AboutInfoText)
            .HasColumnName("AboutInfoText")
            .HasColumnType("text")
            .IsRequired();
        
        entity.Property(e => e.Position)
            .HasColumnName("Position")
            .HasColumnType("int4")
            .IsRequired();
        
        entity.Property(e => e.UserId)
            .HasColumnName("UserId")
            .HasColumnType("bigint")
            .IsRequired();

        entity.HasIndex(u => u.AboutInfoId)
            .HasName("PK_MentorAboutInfoAboutInfoId")
            .IsUnique();

        OnConfigurePartial(entity);
    }

    partial void OnConfigurePartial(EntityTypeBuilder<MentorAboutInfoEntity> entity);
}