using Leoka.Elementary.Platform.Models.Entities.Profile;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leoka.Elementary.Platform.Models.Mappings.Profile;

public partial class MentorGenderConfigurartion : IEntityTypeConfiguration<MentorGenderEntity>
{
    public void Configure(EntityTypeBuilder<MentorGenderEntity> entity)
    {
        entity.ToTable("MentorGender", "Profile");

        entity.HasKey(e => e.GenderId);
        
        entity.Property(e => e.GenderId)
            .HasColumnName("GenderId")
            .HasColumnType("serial")
            .ValueGeneratedNever();
        
        entity.Property(e => e.GenderName)
            .HasColumnName("GenderName")
            .HasColumnType("varchar(50)")
            .HasMaxLength(50)
            .IsRequired();

        OnConfigurePartial(entity);
    }

    partial void OnConfigurePartial(EntityTypeBuilder<MentorGenderEntity> entity);
}