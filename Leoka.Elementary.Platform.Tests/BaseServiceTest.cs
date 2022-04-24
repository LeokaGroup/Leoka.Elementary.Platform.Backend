using AutoMapper;
using Leoka.Elementary.Platform.Access.Service;
using Leoka.Elementary.Platform.Core.Data;
using Leoka.Elementary.Platform.Core.Utils;
using Leoka.Elementary.Platform.Mailings.Services;
using Leoka.Elementary.Platform.Services.MainPage;
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
    protected RoleRepository RoleRepository;
    protected RoleService RoleService;
    protected MailingsService MailingsService;
    protected MainPageService MainPageService;
    protected MainPageRepository MainPageRepository;
    
    public BaseServiceTest()
    {
        // Настройка тестовых строк подключения.
        var builder = new ConfigurationBuilder().AddJsonFile("appsettings.json");
        AppConfiguration = builder.Build();
        PostgreConfigString = AppConfiguration["ConnectionStrings:NpgTestSqlConnection"] ?? string.Empty;
        
        // Настройка тестовых контекстов.
        var optionsBuilder = new DbContextOptionsBuilder<PostgreDbContext>();
        optionsBuilder.UseNpgsql(PostgreConfigString);
        PostgreDbContext = new PostgreDbContext(optionsBuilder.Options);
        MailingsService = new MailingsService(null);
        UserRepository = new UserRepository(PostgreDbContext);
        
        UserService = new UserService(UserRepository, MailingsService);
        RoleRepository = new RoleRepository(PostgreDbContext);
        RoleService = new RoleService(RoleRepository);
        MainPageRepository = new MainPageRepository(PostgreDbContext);
        MainPageService = new MainPageService(MainPageRepository, AutoFac.Resolve<IMapper>());
    }
}