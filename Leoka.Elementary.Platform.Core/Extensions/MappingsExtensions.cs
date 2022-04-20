using Leoka.Elementary.Platform.Core.Utils;
using Microsoft.EntityFrameworkCore;

namespace Leoka.Elementary.Platform.Core.Extensions;

/// <summary>
/// Класс настройки конфигураций маппингов во всем проекте. Они лежат в сборке Leoka.Elementary.Platform.Models.
/// </summary>
public static class MappingsExtensions
{
    public static void Configure(ModelBuilder modelBuilder)
    {
        var assembliesMappings =
            AutoFac.GetAssembliesFromApplicationBaseDirectory(x =>
                x.FullName.StartsWith("Leoka.Elementary.Platform.Models"));

        // Применяет все конфигурации маппингов.
        foreach (var item in assembliesMappings)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(item);
        }
    }
}