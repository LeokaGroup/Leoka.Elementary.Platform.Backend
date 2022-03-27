using System.ComponentModel.DataAnnotations.Schema;

namespace Leoka.Elementary.Platform.Models.Entities.User;

/// <summary>
/// Класс сопоставляется с таблицей ролей пользователей.
/// </summary>
[Table("Roles", Schema = "dbo")]
public class RoleEntity
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