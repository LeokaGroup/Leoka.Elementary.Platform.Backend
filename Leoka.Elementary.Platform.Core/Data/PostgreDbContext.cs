using Leoka.Elementary.Platform.Models.Entities.User;
using Microsoft.EntityFrameworkCore;

namespace Leoka.Elementary.Platform.Core.Data;

public class PostgreDbContext : DbContext
{
    private readonly DbContextOptions<PostgreDbContext> _options;

    public PostgreDbContext(DbContextOptions<PostgreDbContext> options) : base(options)
    {
        _options = options;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
    }
    
    /// <summary>
    /// Таблица dbo.Users.
    /// </summary>
    public DbSet<UserEntity> Users { get; set; }
}