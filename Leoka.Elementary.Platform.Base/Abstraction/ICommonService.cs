namespace Leoka.Elementary.Platform.Base.Abstraction;

/// <summary>
/// Абстракция общего сервиса.
/// </summary>
public interface ICommonService
{
    /// <summary>
    /// Метод хэширует пароль аналогично как это делает Identity.
    /// </summary>
    /// <param name="password">Исходный пароль без хэша.</param>
    /// <returns>Хэш пароля.</returns>
    Task<string> HashPasswordAsync(string password);
    
    /// <summary>
    /// Метод хэширует строку по SHA-256.
    /// </summary>
    /// <param name="str">Исходная строка с параметрами, которые конкантенированы.</param>
    /// <returns>Измененная строку по SHA-256.</returns>
    Task<string> HashSha256Async(Dictionary<string, object> hashValues);

    Task<bool> VerifyHashedPassword(string hashedPassword, string password);
}