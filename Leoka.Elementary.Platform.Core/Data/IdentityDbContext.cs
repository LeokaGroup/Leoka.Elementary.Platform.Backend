using Leoka.Elementary.Platform.Models.Entities.User;
using Leoka.Elementary.Platform.Models.Mappings.User;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Leoka.Elementary.Platform.Core.Data;

public class IdentityDbContext : IdentityDbContext<UserEntity>
{
    public IdentityDbContext(DbContextOptions<IdentityDbContext> options) : base(options) { }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new UserEntityConfiguration());
        modelBuilder.ApplyConfiguration(new UserClaimConfiguration());

        // modelBuilder.Entity<IdentityUserClaim<string>>(entity =>
        // {
        //     entity.ToTable("UserClaims");
        //
        //     // entity.Property(u => u.UserId)
        //     //     .HasColumnType("bigint")
        //     //     .HasColumnName("UserId");
        //
        //     // entity.Ignore(e => e.UserId);
        // });

        // modelBuilder.Entity<IdentityUserClaim<string>>()
        //     .HasOne(t => t.UserId)
        //     .WithMany()
        //     .Map(m =>
        //     {
        //         m.ToTable("CourseInstructor");
        //         m.MapLeftKey("CourseID");
        //         m.MapRightKey("InstructorID");
        //     });;
        
        // modelBuilder.Entity<IdentityUserClaim<string>>()
        //     .re(t => t.)
        //     .WithRequiredPrincipal();
    }
}