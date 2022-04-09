using Leoka.Elementary.Platform.Core.Data;
using Leoka.Elementary.Platform.Services.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Leoka.Elementary.Platform.Tests;

/// <summary>
/// Базовый класс тестов с настройками конфигурации.
/// </summary>
public class BaseServiceTest
{
    protected string PostgreConfigString { get; set; }
    protected IConfiguration AppConfiguration { get; set; }
    protected PostgreDbContext PostgreDbContext;
    protected UserService UserService;
    protected UserRepository UserRepository;

    public BaseServiceTest()
    {
        // Настройка тестовых строк подключения.
        var builder = new ConfigurationBuilder().AddJsonFile("appsettings.json");
        AppConfiguration = builder.Build();
        PostgreConfigString = AppConfiguration["ConnectionStrings:NpgTestSqlConnection"];

        // Настройка тестовых контекстов.
        var optionsBuilder = new DbContextOptionsBuilder<PostgreDbContext>();
        optionsBuilder.UseNpgsql(PostgreConfigString);
        PostgreDbContext = new PostgreDbContext(optionsBuilder.Options);

        UserRepository = new UserRepository(PostgreDbContext);
        UserService = new UserService(UserRepository);
    }
}