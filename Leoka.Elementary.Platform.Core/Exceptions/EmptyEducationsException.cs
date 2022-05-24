namespace Leoka.Elementary.Platform.Core.Exceptions;

/// <summary>
/// Исключение возникает, если не передано образование преподавателя.
/// </summary>
public class EmptyEducationsException : Exception
{
    public EmptyEducationsException() : base("Не передано образование!")
    {
    }
}