using Leoka.Elementary.Platform.Models.Entities.Request;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leoka.Elementary.Platform.Models.Mappings.Request;

public partial class RequestConfiguration : IEntityTypeConfiguration<RequestEntity>
{
    public void Configure(EntityTypeBuilder<RequestEntity> entity)
    {
        entity.ToTable("LandingRequest", "dbo");

        entity.HasKey(e => e.RequestId);
        
        entity.Property(e => e.RequestId)
            .HasColumnName("RequestId")
            .HasColumnType("bigserial")
            .ValueGeneratedNever();

        entity.Property(e => e.RequestFirstName)
            .HasColumnName("RequestFirstName")
            .HasColumnType("varchar(100)")
            .HasMaxLength(100)
            .IsRequired();

        entity.Property(e => e.RequestLastName)
            .HasColumnName("RequestLastName")
            .HasColumnType("varchar(100)")
            .HasMaxLength(100)
            .IsRequired();
        
        entity.Property(e => e.RequestEmail)
            .HasColumnName("RequestEmail")
            .HasColumnType("varchar(100)")
            .HasMaxLength(100)
            .IsRequired();
        ;
        entity.Property(e => e.RequestPhoneNumber)
            .HasColumnName("RequestPhoneNumber")
            .HasColumnType("varchar(100)")
            .HasMaxLength(100)
            .IsRequired();
            
        entity.Property(e => e.RequestMessage)
            .HasColumnName("RequestMessage")
            .HasColumnType("text")
            .IsRequired();
        
        entity.Property(e => e.RequestButtonText)
            .HasColumnName("RequestButtonText")
            .HasColumnType("varchar(50)")
            .HasMaxLength(50)
            .IsRequired();
        
        entity.Property(e => e.RequestTitle)
            .HasColumnName("RequestTitle")
            .HasColumnType("varchar(100)")
            .HasMaxLength(100)
            .IsRequired();
        
        entity.Property(e => e.RequestSubTitle)
            .HasColumnName("RequestSubTitle")
            .HasColumnType("varchar(100)")
            .HasMaxLength(100)
            .IsRequired();
        
        entity.HasIndex(u => u.RequestId)
            .HasDatabaseName("LandingRequest_pkey")
            .IsUnique();

        OnConfigurePartial(entity);
    }

    partial void OnConfigurePartial(EntityTypeBuilder<RequestEntity> entity);
}