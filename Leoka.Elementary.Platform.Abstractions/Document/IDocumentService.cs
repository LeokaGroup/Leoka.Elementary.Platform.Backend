using Leoka.Elementary.Platform.Models.Profile.Output;

namespace Leoka.Elementary.Platform.Abstractions.Document;

/// <summary>
/// Абстракция сервиса документов.
/// </summary>
public interface IDocumentService
{
    /// <summary>
    /// Метод получит список сертификатов для профиля пользователя.
    /// </summary>
    /// <param name="account">Аккаунт.</param>
    /// <returns>Список сертификатов.</returns>
    Task<IEnumerable<FileContentResultOutput>> GetProfileCertsAsync(string account);
}