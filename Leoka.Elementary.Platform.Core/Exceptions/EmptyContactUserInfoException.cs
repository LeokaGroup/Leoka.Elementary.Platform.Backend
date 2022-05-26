namespace Leoka.Elementary.Platform.Core.Exceptions;

/// <summary>
/// Исключение возникает, если не заполнена контактная информация пользователя.
/// </summary>
public class EmptyContactUserInfoException : Exception
{
    public EmptyContactUserInfoException(string account) : base($"Не переданы контактные данные для пользователя {account}")
    {
    }
}