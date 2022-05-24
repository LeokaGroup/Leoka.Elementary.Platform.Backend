namespace Leoka.Elementary.Platform.Core.Exceptions;

/// <summary>
/// Исключение возникает, если не переданы цели обучения.
/// </summary>
public class EmptyTrainingException : Exception
{
    public EmptyTrainingException() : base("Не переданы цели обучения!")
    {
    }
}