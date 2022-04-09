namespace Leoka.Elementary.Platform.Core.Exceptions;

/// <summary>
/// Исключение возникнет, если пароль неверен.
/// </summary>
public class ErrorUserPasswordException : Exception
{
    public ErrorUserPasswordException() : base("Пароль неверен!")
    {
    }
}