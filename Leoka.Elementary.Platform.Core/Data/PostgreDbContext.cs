using Leoka.Elementary.Platform.Models.Entities.Common;
using Leoka.Elementary.Platform.Models.Entities.MainPage;
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
    
    /// <summary>
    /// Таблица dbo.AboutPlatform.
    /// </summary>
    public DbSet<AboutPlatformEntity> AboutPlatforms { get; set; }

    /// <summary>
    /// Таблица dbo.Footer.
    /// </summary>
    public DbSet<FooterEntity> Footer { get; set; }

    /// <summary>
    /// Таблица dbo.Header.
    /// </summary>
    public DbSet<HeaderEntity> Header { get; set; }

    /// <summary>
    /// Таблица dbo.MainBestOptions.
    /// </summary>
    public DbSet<MainBestOptionEntity> MainBestOptions { get; set; }

    /// <summary>
    /// Таблица bo.MainBestQuestionAcceptAnswers.
    /// </summary>
    public DbSet<MainBestQuestionAcceptAnswerEntity> MainBestQuestionAcceptAnswers { get; set; }

    /// <summary>
    /// Таблица dbo.MainBestQuestionOptions.
    /// </summary>
    public DbSet<MainBestQuestionOptionEntity> MainBestQuestionOptions { get; set; }

    /// <summary>
    /// Таблица dbo.MainBestQuestions.
    /// </summary>
    public DbSet<MainBestQuestionEntity> MainBestQuestions { get; set; }
}