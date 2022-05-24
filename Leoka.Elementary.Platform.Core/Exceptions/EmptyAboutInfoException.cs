namespace Leoka.Elementary.Platform.Core.Exceptions;

public class EmptyAboutInfoException : Exception
{
    public EmptyAboutInfoException() : base("Не передана информация о себе")
    {
    }
}