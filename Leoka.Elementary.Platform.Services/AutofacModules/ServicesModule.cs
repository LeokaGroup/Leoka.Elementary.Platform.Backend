using Autofac;
using Leoka.Elementary.Platform.Abstractions.User;
using Leoka.Elementary.Platform.Core.Attributes;
using Leoka.Elementary.Platform.Models.Entities.User;
using Leoka.Elementary.Platform.Services.User;
using Microsoft.AspNetCore.Identity;

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
        
        builder.RegisterType<SignInManager<UserEntity>>().InstancePerLifetimeScope();
        builder.RegisterType<UserManager<UserEntity>>().InstancePerLifetimeScope();
    }
}