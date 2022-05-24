using Leoka.Elementary.Platform.Models.Entities.Profile;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leoka.Elementary.Platform.Models.Mappings.Profile;

public partial class MentorCertificateConfiguration : IEntityTypeConfiguration<MentorCertificateEntity>
{
    public void Configure(EntityTypeBuilder<MentorCertificateEntity> entity)
    {
        entity.ToTable("MentorCertificates", "Profile");

        entity.HasKey(e => e.CertificateId);
        
        entity.Property(e => e.CertificateId)
            .HasColumnName("CertificateId")
            .HasColumnType("bigserial");
        
        entity.Property(e => e.CertificateName)
            .HasColumnName("CertificateName")
            .HasColumnType("text")
            .IsRequired();

        entity.Property(e => e.UserId)
            .HasColumnName("UserId")
            .HasColumnType("bigint")
            .IsRequired();

        entity.HasIndex(u => u.CertificateId)
            .HasName("PK_MentorCertificatesCertificateId")
            .IsUnique();

        OnConfigurePartial(entity);
    }

    partial void OnConfigurePartial(EntityTypeBuilder<MentorCertificateEntity> entity);
}