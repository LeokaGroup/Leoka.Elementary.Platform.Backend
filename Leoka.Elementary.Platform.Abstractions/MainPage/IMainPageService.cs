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
    Task<MainFonStudentOutput> GetMainFonStudentAsync();

    /// <summary>
    /// Метод получит данные записи на урок.
    /// </summary>
    /// <returns>Данные записи на урок.</returns>
    Task<ReceptionOutput> GetReceptionAsync();

    /// <summary>
    /// Метод получит данные блока с чего начать.
    /// </summary>
    /// <returns>Данные блока.</returns>
    Task<BeginOutput> GetBeginItemsAsync();
}