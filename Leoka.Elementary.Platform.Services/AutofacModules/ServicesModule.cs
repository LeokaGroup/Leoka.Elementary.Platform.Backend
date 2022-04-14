using Autofac;
using Leoka.Elementary.Platform.Abstractions.User;
using Leoka.Elementary.Platform.Core.Attributes;
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
    }
}