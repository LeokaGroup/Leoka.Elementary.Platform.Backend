using Leoka.Elementary.Platform.Models.Entities.Profile;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leoka.Elementary.Platform.Models.Mappings.Profile;

public partial class MentorProfileInfoConfiguration : IEntityTypeConfiguration<MentorProfileInfoEntity>
{
    public void Configure(EntityTypeBuilder<MentorProfileInfoEntity> entity)
    {
        entity.ToTable("MentorProfileInfo", "Profile");

        entity.HasKey(e => e.UserProfileInfoId);
        
        entity.Property(e => e.UserProfileInfoId)
            .HasColumnName("UserProfileInfoId")
            .HasColumnType("bigserial")
            .ValueGeneratedNever();
        
        entity.Property(e => e.ProfileIconUrl)
            .HasColumnName("ProfileIconUrl")
            .HasColumnType("text");
        
        entity.Property(e => e.FullName)
            .HasColumnName("FullName")
            .HasColumnType("varchar(300)")
            .IsRequired();
        
        entity.Property(e => e.IsVisibleAllContact)
            .HasColumnName("IsVisibleAllContact")
            .HasColumnType("boolean")
            .IsRequired();
        
        entity.Property(e => e.PhoneNumber)
            .HasColumnName("PhoneNumber")
            .HasColumnType("varchar(100)")
            .IsRequired();
        
        entity.Property(e => e.Email)
            .HasColumnName("Email")
            .HasColumnType("varchar(100)")
            .IsRequired();
        
        entity.Property(e => e.FirstName)
            .HasColumnName("FirstName")
            .HasColumnType("varchar(150)")
            .IsRequired();
        
        entity.Property(e => e.LastName)
            .HasColumnName("LastName")
            .HasColumnType("varchar(150)")
            .IsRequired();
        
        entity.Property(e => e.SecondName)
            .HasColumnName("SecondName")
            .HasColumnType("varchar(150)")
            .IsRequired();
        
        entity.HasIndex(u => u.UserProfileInfoId)
            .HasName("PK_MentorProfileInfoUserProfileInfoId")
            .IsUnique();

        OnConfigurePartial(entity);
    }

    partial void OnConfigurePartial(EntityTypeBuilder<MentorProfileInfoEntity> entity);
}