namespace Leoka.Elementary.Platform.Core.Exceptions;

/// <summary>
/// Исключение возникнет, если роль пользователя неизвестна.
/// </summary>
public class NotFoundUserRoleException : Exception
{
    public NotFoundUserRoleException(string account) : base($"Роль пользователя {account} не определена.")
    {
    }
}