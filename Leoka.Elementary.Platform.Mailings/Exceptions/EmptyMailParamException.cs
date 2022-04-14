namespace Leoka.Elementary.Platform.Mailings.Exceptions;

/// <summary>
/// Исключение возникнет, если не был заполнен какой-либо параметр.
/// </summary>
public class EmptyMailParamException : Exception
{
    public EmptyMailParamException(string param) : base($"Не заполнен параметр {param}")
    {
    }
}