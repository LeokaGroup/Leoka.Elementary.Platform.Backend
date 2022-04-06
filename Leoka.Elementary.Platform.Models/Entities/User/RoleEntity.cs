using System.ComponentModel.DataAnnotations;
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
    [Key]
    public int RoleId { get; set; }

    /// <summary>
    /// Название роли пользователя.
    /// </summary>
    [Column("RoleName", TypeName = "varchar(200)")]
    public string RoleName { get; set; }

    /// <summary>
    /// Системное название роли.
    /// </summary>
    [Column("RoleSysName", TypeName = "varchar(200)")]
    public string RoleSysName { get; set; }    
}