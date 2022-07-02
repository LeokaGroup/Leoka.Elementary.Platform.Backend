using Leoka.Elementary.Platform.Models.Entities.Profile;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leoka.Elementary.Platform.Models.Mappings.Profile;

public partial class ProfileInfoConfiguration : IEntityTypeConfiguration<ProfileInfoEntity>
{
    public void Configure(EntityTypeBuilder<ProfileInfoEntity> entity)
    {
        entity.ToTable("ProfileInfos", "Profile");

        entity.HasKey(e => e.ProfileInfoId);
        
        entity.Property(e => e.ProfileInfoId)
            .HasColumnName("ProfileInfoId")
            .HasColumnType("serial");
        
        entity.Property(e => e.ProfileInfoTitle)
            .HasColumnName("ProfileInfoTitle")
            .HasColumnType("varchar(200)")
            .HasMaxLength(200)
            .IsRequired();
        
        entity.Property(e => e.ProfileInfoText)
            .HasColumnName("ProfileInfoText")
            .HasColumnType("text")
            .IsRequired();
        
        entity.Property(e => e.IsVisibleInfo)
            .HasColumnName("IsVisibleInfo")
            .HasColumnType("boolean")
            .IsRequired();
        
        entity.HasIndex(u => u.ProfileInfoId)
            .HasDatabaseName("ProfileInfoId")
            .IsUnique();

        OnConfigurePartial(entity);
    }

    partial void OnConfigurePartial(EntityTypeBuilder<ProfileInfoEntity> entity);
}