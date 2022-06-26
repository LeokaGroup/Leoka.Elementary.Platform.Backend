using Leoka.Elementary.Platform.Models.Entities.Profile;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leoka.Elementary.Platform.Models.Mappings.Profile;

public partial class MentorTrainingConfiguration : IEntityTypeConfiguration<UserTrainingEntity>
{
    public void Configure(EntityTypeBuilder<UserTrainingEntity> entity)
    {
        entity.ToTable("MentorTrainings", "Profile");

        entity.HasKey(e => e.TrainingId);
        
        entity.Property(e => e.TrainingId)
            .HasColumnName("TrainingId")
            .HasColumnType("bigserial");

        entity.Property(e => e.UserId)
            .HasColumnName("UserId")
            .HasColumnType("bigint")
            .IsRequired();

        entity.HasIndex(u => u.TrainingId)
            .HasName("PK_MentorTrainingsTrainingId")
            .IsUnique();
        
        entity.HasOne(p => p.PurposeTraining)
            .WithMany(b => b.UserTrainings)
            .HasForeignKey(p => p.PurposeId)
            .HasConstraintName("FK_PurposeTrainingsPurposeId");

        OnConfigurePartial(entity);
    }

    partial void OnConfigurePartial(EntityTypeBuilder<UserTrainingEntity> entity);
}