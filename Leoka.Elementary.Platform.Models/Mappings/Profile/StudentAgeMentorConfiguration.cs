using Leoka.Elementary.Platform.Models.Entities.Profile;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leoka.Elementary.Platform.Models.Mappings.Profile;

public partial class StudentAgeMentorConfiguration : IEntityTypeConfiguration<StudentAgeMentorEntity>
{
     public void Configure(EntityTypeBuilder<StudentAgeMentorEntity> entity)
    {
        entity.ToTable("StudentAgeMentor", "Profile");

        entity.HasKey(e => e.StudentAgeMentorId);
        
        entity.Property(e => e.StudentAgeMentorId)
            .HasColumnName("StudentAgeMentorId")
            .HasColumnType("serial");

        entity.Property(e => e.UserId)
            .HasColumnName("UserId")
            .HasColumnType("int")
            .IsRequired();

        entity.HasIndex(u => u.StudentAgeMentorId)
            .HasName("PK_StudentAgeMentorId")
            .IsUnique();
        
        entity.HasOne(p => p.MentorAge)
            .WithMany(b => b.StudentAgeMentors)
            .HasForeignKey(p => p.MentorAge)
            .HasConstraintName("FK_MentorAgeAgeId");

        OnConfigurePartial(entity);
    }

    partial void OnConfigurePartial(EntityTypeBuilder<StudentAgeMentorEntity> entity);
}