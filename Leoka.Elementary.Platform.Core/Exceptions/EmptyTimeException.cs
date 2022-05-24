namespace Leoka.Elementary.Platform.Core.Exceptions;

/// <summary>
/// Исключение возникает, если не указали свободное время занятий преподавателя.
/// </summary>
public class EmptyTimeException : Exception
{
    public EmptyTimeException() : base("Не указано свободное время занятий!")
    {
    }
}