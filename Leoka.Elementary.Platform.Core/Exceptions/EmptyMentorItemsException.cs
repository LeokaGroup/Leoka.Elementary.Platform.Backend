namespace Leoka.Elementary.Platform.Core.Exceptions;

/// <summary>
/// Исключение возникает, если не передали список предметов преподавателя.
/// </summary>
public class EmptyMentorItemsException : Exception
{
    public EmptyMentorItemsException() : base("Не передан список предметов!")
    {
    }
}