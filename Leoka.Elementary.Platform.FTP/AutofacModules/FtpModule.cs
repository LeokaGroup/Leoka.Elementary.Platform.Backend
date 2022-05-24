using Autofac;
using Leoka.Elementary.Platform.Core.Attributes;
using Leoka.Elementary.Platform.FTP.Abstractions;
using Leoka.Elementary.Platform.FTP.Services;

namespace Leoka.Elementary.Platform.FTP.AutofacModules;

/// <summary>
/// Класс регистрации сервисов автофака.
/// </summary>
[CommonModule]
public sealed class FtpModule : Module
{
    public static void InitModules(ContainerBuilder builder)
    {
        // Сервис FTP.
        builder.RegisterType<FtpService>().Named<IFtpService>("FtpService");
        builder.RegisterType<FtpService>().As<IFtpService>();
    }
}