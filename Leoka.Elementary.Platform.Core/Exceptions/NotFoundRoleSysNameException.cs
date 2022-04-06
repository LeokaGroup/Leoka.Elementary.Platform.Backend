namespace Leoka.Elementary.Platform.Core.Exceptions;

/// <summary>
/// Исключение возникнет, если не было найдено роли по системному имени.
/// </summary>
public class NotFoundRoleSysNameException : Exception
{
    public NotFoundRoleSysNameException(string sysName) : base($"Роли с системным именем {sysName} не найдено")
    {
    }
}