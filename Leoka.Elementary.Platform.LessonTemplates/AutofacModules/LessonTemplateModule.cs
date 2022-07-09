using Autofac;
using Leoka.Elementary.Platform.Core.Attributes;
using Leoka.Elementary.Platform.LessonTemplates.Abstractions;
using Leoka.Elementary.Platform.LessonTemplates.Services;

namespace Leoka.Elementary.Platform.LessonTemplates.AutofacModules;

/// <summary>
/// Класс регистрации сервисов автофака.
/// </summary>
[CommonModule]
public sealed class LessonTemplateModule : Module
{
    public static void InitModules(ContainerBuilder builder)
    {
        // Сервис шаблонов урока.
        builder.RegisterType<TemplateService>().Named<ITemplateService>("TemplateService");
        builder.RegisterType<TemplateService>().As<ITemplateService>();
    }
}