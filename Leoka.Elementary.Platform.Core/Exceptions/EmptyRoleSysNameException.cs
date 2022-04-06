namespace Leoka.Elementary.Platform.Core.Exceptions;

/// <summary>
/// Исключение возникает, если пустое системное имя роли.
/// </summary>
public class EmptyRoleSysNameException : Exception
{
    public EmptyRoleSysNameException() : base("Пустое имя системной роли")
    {
    }
}