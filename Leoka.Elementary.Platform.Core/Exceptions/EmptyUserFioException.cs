namespace Leoka.Elementary.Platform.Core.Exceptions;

public class EmptyUserFioException : Exception
{
    public EmptyUserFioException() : base("ФИО не заполнено!")
    {
    }
}