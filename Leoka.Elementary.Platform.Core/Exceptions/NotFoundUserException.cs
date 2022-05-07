namespace Leoka.Elementary.Platform.Core.Exceptions;

/// <summary>
/// Исключение возникнет, если не был передан аккаунт либо не был найден пользователь.
/// </summary>
public class NotFoundUserException : Exception
{
    public NotFoundUserException(string account) : base($"Пользователя с аккаунтом {account} не найдено.")
    {
    }
}