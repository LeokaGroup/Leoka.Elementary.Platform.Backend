using Autofac;
using Leoka.Elementary.Platform.Core.Attributes;
using Leoka.Elementary.Platform.Mailings.Abstractions;
using Leoka.Elementary.Platform.Mailings.Services;

namespace Leoka.Elementary.Platform.Mailings.AutofacModules;

/// <summary>
/// Класс регистрации сервисов автофака.
/// </summary>
[CommonModule]
public sealed class MailingModule : Module
{
    public static void InitModules(ContainerBuilder builder)
    {
        // Сервис email-рассылок.
        builder.RegisterType<MailingsService>().Named<IMailingsService>("MailingsService");
        builder.RegisterType<MailingsService>().As<IMailingsService>();
        
    }
}