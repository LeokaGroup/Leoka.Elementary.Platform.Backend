namespace Leoka.Elementary.Platform.Models.User.Input;

/// <summary>
/// Класс входной модели роли пользователя.
/// </summary>
public class RoleInput
{
    /// <summary>
    /// PK.
    /// </summary>
    public int RoleId { get; set; }

    /// <summary>
    /// Название роли пользователя.
    /// </summary>
    public string RoleName { get; set; }

    /// <summary>
    /// Системное название роли.
    /// </summary>
    public string SysName { get; set; }
}