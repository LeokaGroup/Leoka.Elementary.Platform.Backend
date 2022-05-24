namespace Leoka.Elementary.Platform.Core.Exceptions;

/// <summary>
/// Исключение возникает, если не были переданы длительности занятий.
/// </summary>
public class EmptyDurationException : Exception
{
    public EmptyDurationException() : base("Не передан список длительностей занятий!")
    {
    }
}