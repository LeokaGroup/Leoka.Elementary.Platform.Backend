using Autofac;
using Leoka.Elementary.Platform.Base.Abstraction;
using Leoka.Elementary.Platform.Base.Service;
using Leoka.Elementary.Platform.Core.Attributes;

namespace Leoka.Elementary.Platform.Base.AutofacModules;

/// <summary>
/// Класс регистрации сервисов автофака.
/// </summary>
[CommonModule]
public sealed class BaseModule : Module
{
    public static void InitModules(ContainerBuilder builder)
    {
        builder.RegisterType<CommonService>().Named<ICommonService>("CommonService");
        builder.RegisterType<CommonService>().As<ICommonService>();
    }
}