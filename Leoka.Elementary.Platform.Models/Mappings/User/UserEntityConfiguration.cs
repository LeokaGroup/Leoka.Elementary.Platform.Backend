﻿using Leoka.Elementary.Platform.Models.Entities.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leoka.Elementary.Platform.Models.Mappings.User;

public partial class UserEntityConfiguration : IEntityTypeConfiguration<UserEntity>
{
    public void Configure(EntityTypeBuilder<UserEntity> entity)
    {
        entity.ToTable("Users", "dbo");

        entity.HasKey(u => u.Id);
        
        entity.Property(e => e.Id)
            .HasColumnName("UserCode")
            .HasColumnType("text")
            .ValueGeneratedNever();

        entity.Property(e => e.UserId)
            .HasColumnName("UserId")
            .HasColumnType("bigint")
            .ValueGeneratedNever();;

        entity.HasIndex(u => u.Id)
            .HasName("PK_Users_Id")
            .IsUnique();

        OnConfigurePartial(entity);
    }

    partial void OnConfigurePartial(EntityTypeBuilder<UserEntity> entity);
}