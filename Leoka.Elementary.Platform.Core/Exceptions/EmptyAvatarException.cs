namespace Leoka.Elementary.Platform.Core.Exceptions;

/// <summary>
/// Исключение возникает, если не передали изображение аватара.
/// </summary>
public class EmptyAvatarException : Exception
{
    public EmptyAvatarException(string account) : base($"Не передан аватар пользователя {account}!")
    {
    }
}