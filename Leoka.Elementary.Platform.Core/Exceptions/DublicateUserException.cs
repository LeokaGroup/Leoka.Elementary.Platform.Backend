namespace Leoka.Elementary.Platform.Core.Exceptions;

/// <summary>
/// Исключение возникнет, если такой пользователь уже есть в БД.
/// </summary>
public class DublicateUserException : Exception
{
    public DublicateUserException() : base("Такой пользователь уже зарегистрирован в системе!")
    {
    }
}