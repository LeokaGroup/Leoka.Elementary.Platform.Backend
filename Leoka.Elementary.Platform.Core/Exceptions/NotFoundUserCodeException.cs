namespace Leoka.Elementary.Platform.Core.Exceptions;

/// <summary>
/// Исключение возникнет, если пользователя с таким кодом не найдено.
/// </summary>
public class NotFoundUserCodeException : Exception
{
    public NotFoundUserCodeException(string userCode) : base($"Пользователя с кодом {userCode} не найдено в системе!")
    {
    }
}