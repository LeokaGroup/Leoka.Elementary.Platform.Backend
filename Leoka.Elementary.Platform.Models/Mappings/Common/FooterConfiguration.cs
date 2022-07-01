using Leoka.Elementary.Platform.Models.Entities.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leoka.Elementary.Platform.Models.Mappings.Common;

public partial class FooterConfiguration : IEntityTypeConfiguration<FooterEntity>
{
    public void Configure(EntityTypeBuilder<FooterEntity> entity)
    {
        entity.ToTable("Footer", "dbo");

        entity.HasKey(e => e.FooterId);
        
        entity.Property(e => e.FooterId)
            .HasColumnName("FooterId")
            .HasColumnType("int4")
            .ValueGeneratedNever();

        entity.Property(e => e.FirstFooterTitle)
            .HasColumnName("FirstFooterTitle")
            .HasColumnType("varchar(100)")
            .HasMaxLength(100);

        entity.Property(e => e.LastFooterTitle)
            .HasColumnName("LastFooterTitle")
            .HasColumnType("varchar(100)")
            .HasMaxLength(100);
        ;
        entity.Property(e => e.FooterColumnNumber)
            .HasColumnName("FooterColumnNumber")
            .HasColumnType("int4")
            .IsRequired();
        
        entity.Property(e => e.FooterItemText)
            .HasColumnName("FooterItemText")
            .HasColumnType("varchar(150)")
            .HasMaxLength(150)
            .IsRequired();
        
        entity.Property(e => e.FooterItemActionSysName)
            .HasColumnName("FooterItemActionSysName")
            .HasColumnType("varchar(150)")
            .HasMaxLength(150)
            .IsRequired();
        
        entity.Property(e => e.FooterItemUrl)
            .HasColumnName("FooterItemUrl")
            .HasColumnType("text");
        
        entity.Property(e => e.FooterTelegramActionSysName)
            .HasColumnName("FooterTelegramActionSysName")
            .HasColumnType("varchar(150)")
            .HasMaxLength(150)
            .IsRequired();
        
        entity.Property(e => e.FooterTelegramUrl)
            .HasColumnName("FooterTelegramUrl")
            .HasColumnType("text");
        
        entity.Property(e => e.FooterVkActionSysName)
            .HasColumnName("FooterVkActionSysName")
            .HasColumnType("varchar(150)")
            .HasMaxLength(150)
            .IsRequired();
        
        entity.Property(e => e.FooterVkUrl)
            .HasColumnName("FooterVkUrl")
            .HasColumnType("text");
        
        entity.Property(e => e.FooterWhatsAppActionSysName)
            .HasColumnName("FooterWhatsAppActionSysName")
            .HasColumnType("varchar(150)")
            .HasMaxLength(150)
            .IsRequired();
        
        entity.Property(e => e.FooterWhatsAppUrl)
            .HasColumnName("FooterWhatsAppUrl")
            .HasColumnType("text");
        
        entity.Property(e => e.FooterItemPosition)
            .HasColumnName("FooterItemPosition")
            .HasColumnType("int4")
            .IsRequired();

        entity.HasIndex(u => u.FooterId)
            .HasDatabaseName("Footer_pkey")
            .IsUnique();

        OnConfigurePartial(entity);
    }

    partial void OnConfigurePartial(EntityTypeBuilder<FooterEntity> entity);
}