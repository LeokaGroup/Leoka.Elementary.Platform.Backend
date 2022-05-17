namespace Leoka.Elementary.Platform.Core.Exceptions;

/// <summary>
/// Исключение возникает, если не были переданы цены.
/// </summary>
public class EmptyPricesException : Exception
{
    public EmptyPricesException() : base("Не переданы цены!")
    {
    }
}