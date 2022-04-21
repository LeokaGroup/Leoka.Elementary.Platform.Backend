using Leoka.Elementary.Platform.Models.Common.Output;

namespace Leoka.Elementary.Platform.Abstractions.MainPage;

/// <summary>
/// Абстракция репозитория главнойй страницы.
/// </summary>
public interface IMainPageRepository
{
    /// <summary>
    /// Метод получит список полей хидера.
    /// </summary>
    /// <returns>Список полей хидера.</returns>
    Task<IEnumerable<HeaderOutput>> GetHeaderItemsAsync();
    
    /// <summary>
    /// Метод получит список полей футера.
    /// </summary>
    /// <returns>Список полей футера.</returns>
    Task<IEnumerable<FooterOutput>> GetFooterItemsAsync();
}