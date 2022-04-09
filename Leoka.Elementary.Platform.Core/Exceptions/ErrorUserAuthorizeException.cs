namespace Leoka.Elementary.Platform.Core.Exceptions;

/// <summary>
/// Исключение возникнет, если такого логина нет в системе.
/// </summary>
public class ErrorUserAuthorizeException : Exception
{
    public ErrorUserAuthorizeException(string email) : base($"Пользователя с учетной записью {email} не существует в системе")
    {

    }
}