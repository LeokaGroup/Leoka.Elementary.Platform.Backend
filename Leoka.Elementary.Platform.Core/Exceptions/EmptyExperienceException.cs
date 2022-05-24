namespace Leoka.Elementary.Platform.Core.Exceptions;

/// <summary>
/// Исключение возникает, если не передан опыт преподавателя.
/// </summary>
public class EmptyExperienceException : Exception
{
    public EmptyExperienceException() : base("Не передан опыт преподавателя!")
    {
    }
}