using Autofac;
using Leoka.Elementary.Platform.Abstractions.Document;
using Leoka.Elementary.Platform.Abstractions.MainPage;
using Leoka.Elementary.Platform.Abstractions.Profile;
using Leoka.Elementary.Platform.Abstractions.User;
using Leoka.Elementary.Platform.Core.Attributes;
using Leoka.Elementary.Platform.Services.Document;
using Leoka.Elementary.Platform.Services.MainPage;
using Leoka.Elementary.Platform.Services.Profile;
using Leoka.Elementary.Platform.Services.User;

namespace Leoka.Elementary.Platform.Services.AutofacModules;

/// <summary>
/// Класс регистрации сервисов автофака.
/// </summary>
[CommonModule]
public class ServicesModule : Module
{
    public static void InitModules(ContainerBuilder builder)
    {
        // Сервис пользователя.
        builder.RegisterType<UserService>().Named<IUserService>("UserService");
        builder.RegisterType<UserService>().As<IUserService>();

        // Репозиторий пользователя.
        builder.RegisterType<UserRepository>().Named<IUserRepository>("UserRepository");
        builder.RegisterType<UserRepository>().As<IUserRepository>();
        
        // Сервис главной страницы.
        builder.RegisterType<MainPageService>().Named<IMainPageService>("MainPageService");
        builder.RegisterType<MainPageService>().As<IMainPageService>();
        
        // Репозиторий главной страницы.
        builder.RegisterType<MainPageRepository>().Named<IMainPageRepository>("MainPageRepository");
        builder.RegisterType<MainPageRepository>().As<IMainPageRepository>();
        
        // Сервис профиля пользователя.
        builder.RegisterType<ProfileService>().Named<IProfileService>("ProfileService");
        builder.RegisterType<ProfileService>().As<IProfileService>();
        
        // Репозиторий профиля пользователя.
        builder.RegisterType<ProfileRepository>().Named<IProfileRepository>("ProfileRepository");
        builder.RegisterType<ProfileRepository>().As<IProfileRepository>();
        
        // Сервис документов.
        builder.RegisterType<DocumentService>().Named<IDocumentService>("DocumentService");
        builder.RegisterType<DocumentService>().As<IDocumentService>();
    }
}