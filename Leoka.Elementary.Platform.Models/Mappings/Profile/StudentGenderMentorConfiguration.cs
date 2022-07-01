using Leoka.Elementary.Platform.Models.Entities.Profile;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leoka.Elementary.Platform.Models.Mappings.Profile;

public partial class StudentGenderMentorConfiguration : IEntityTypeConfiguration<StudentGenderMentorEntity>
{
    public void Configure(EntityTypeBuilder<StudentGenderMentorEntity> entity)
    {
        entity.ToTable("StudentGenderMentor", "Profile");

        entity.HasKey(e => e.StudentGenderMentorId);
        
        entity.Property(e => e.StudentGenderMentorId)
            .HasColumnName("StudentGenderMentorId")
            .HasColumnType("serial")
            .ValueGeneratedNever();
        
        entity.Property(e => e.UserId)
            .HasColumnName("UserId")
            .HasColumnType("bigint")
            .IsRequired();
        
        entity.Property(e => e.GenderId)
            .HasColumnName("GenderId")
            .HasColumnType("int4")
            .IsRequired();
        
        entity.HasIndex(u => u.StudentGenderMentorId)
            .HasDatabaseName("PK_StudentGenderMentorId")
            .IsUnique();
        
        entity.HasOne(p => p.MentorGender)
            .WithMany(b => b.StudentGenderMentors)
            .HasForeignKey(p => p.GenderId)
            .HasConstraintName("FK_MentorGenderGenderId");

        OnConfigurePartial(entity);
    }

    partial void OnConfigurePartial(EntityTypeBuilder<StudentGenderMentorEntity> entity);
}