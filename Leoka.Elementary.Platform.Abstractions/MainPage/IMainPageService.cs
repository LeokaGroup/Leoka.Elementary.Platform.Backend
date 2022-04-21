using Leoka.Elementary.Platform.Models.Common.Output;
using Leoka.Elementary.Platform.Models.MainPage.Output;

namespace Leoka.Elementary.Platform.Abstractions.MainPage;

/// <summary>
/// Абстракция главной страницы.
/// </summary>
public interface IMainPageService
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

    /// <summary>
    /// Метод получит данные для фона студента.
    /// </summary>
    /// <returns>Данные для фона студента.</returns>
    Task<IEnumerable<MainFonStudentOutput>> GetMainFonStudentAsync();
}