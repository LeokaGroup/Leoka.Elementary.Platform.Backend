using Leoka.Elementary.Platform.Models.Entities.User;
using Microsoft.EntityFrameworkCore;

namespace Leoka.Elementary.Platform.Core.Data;

public class PostgreDbContext : DbContext
{
    // public PostgreDbContext(DbContextOptions<PostgreDbContext> options) : base(options)
    // {
    // }
    
    private readonly DbContextOptions<PostgreDbContext> _options;
    
    public PostgreDbContext(DbContextOptions<PostgreDbContext> options) : base(options)
    {
        _options = options;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // base.OnModelCreating(modelBuilder);
    }

    /// <summary>
    /// Таблица dbo.Users.
    /// </summary>
    public DbSet<UserEntity> Users { get; set; }
    
    /// <summary>
    /// Табилца dbo.UserRoles.
    /// </summary>
    public DbSet<UserRoleEntity> UserRoles { get; set; }
    
    /// <summary>
    /// Таблица dbo.Roles.
    /// </summary>
    public DbSet<RoleEntity> Roles { get; set; }
}