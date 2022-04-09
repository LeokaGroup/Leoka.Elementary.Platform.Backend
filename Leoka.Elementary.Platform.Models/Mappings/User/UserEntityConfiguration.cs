// using Leoka.Elementary.Platform.Models.Entities.User;
// using Microsoft.EntityFrameworkCore;
// using Microsoft.EntityFrameworkCore.Metadata.Builders;
//
// namespace Leoka.Elementary.Platform.Models.Mappings.User;
//
// public partial class UserEntityConfiguration : IEntityTypeConfiguration<UserEntity>
// {
//     public void Configure(EntityTypeBuilder<UserEntity> entity)
//     {
//         entity.ToTable("Users", "dbo");
//
//         entity.HasKey(e => new { e.UserCode, e.UserId });
//
//         entity.Property(e => e.UserCode)
//             .HasColumnName("UserCode")
//             .HasColumnType("text")
//             .ValueGeneratedOnAdd();
//
//         entity.Property(e => e.UserId)
//             .HasColumnName("UserId")
//             .HasColumnType("bigint")
//             .ValueGeneratedOnAdd();
//         ;
//
//         entity.HasIndex(u => u.UserCode)
//             .HasName("PK_Users_Id")
//             .IsUnique();
//
//         OnConfigurePartial(entity);
//     }
//
//     partial void OnConfigurePartial(EntityTypeBuilder<UserEntity> entity);
// }