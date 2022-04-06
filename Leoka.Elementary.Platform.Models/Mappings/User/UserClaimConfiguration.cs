using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leoka.Elementary.Platform.Models.Mappings.User;

public partial class UserClaimConfiguration : IEntityTypeConfiguration<IdentityUserClaim<string>>
{
    public void Configure(EntityTypeBuilder<IdentityUserClaim<string>> entity)
    {
        entity.ToTable("UserClaims", "dbo");

        entity.HasKey(u => u.Id);

        entity.Property(e => e.Id)
            .HasColumnName("Id")
            .HasColumnType("bigint");
        
        entity.HasIndex(u => u.Id)
            .HasName("PK_UserClaims_Id")
            .IsUnique();

        OnConfigurePartial(entity);
    }

    partial void OnConfigurePartial(EntityTypeBuilder<IdentityUserClaim<string>> entity);
}