using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Leoka.Elementary.Platform.Models.Entities.User;

/// <summary>
/// Класс сопоставляется с таблицей ролей пользователей, которые им присвоены.
/// </summary>
[Table("UserRoles", Schema = "dbo")]
public class UserRoleEntity
{
    [Key]
    public int UserRoleId { get; set; }

    [ForeignKey("RoleId")]
    public int RoleId { get; set; }

    public RoleEntity Role { get; set; }
}