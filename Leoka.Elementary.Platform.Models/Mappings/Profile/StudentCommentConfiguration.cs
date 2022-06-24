using Leoka.Elementary.Platform.Models.Entities.Profile;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leoka.Elementary.Platform.Models.Mappings.Profile;

public partial class StudentCommentConfiguration : IEntityTypeConfiguration<StudentCommentEntity>
{
    public void Configure(EntityTypeBuilder<StudentCommentEntity> entity)
    {
        entity.ToTable("StudentComments", "Profile");

        entity.HasKey(e => e.CommentId);
        
        entity.Property(e => e.CommentId)
            .HasColumnName("CommentId")
            .HasColumnType("bigserial")
            .ValueGeneratedNever();

        entity.Property(e => e.CommentText)
            .HasColumnName("CommentText")
            .HasColumnType("text");
        
        entity.Property(e => e.UserId)
            .HasColumnName("UserId")
            .HasColumnType("bigint")
            .IsRequired();

        OnConfigurePartial(entity);
    }

    partial void OnConfigurePartial(EntityTypeBuilder<StudentCommentEntity> entity);
}