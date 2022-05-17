namespace Leoka.Elementary.Platform.Core.Exceptions;

public class EmptyContactException : Exception
{
    public EmptyContactException() : base("Не заполнены контактные данные!")
    {
    }
}