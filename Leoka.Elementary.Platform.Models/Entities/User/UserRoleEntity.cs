using System.ComponentModel.DataAnnotations.Schema;

namespace Leoka.Elementary.Platform.Models.Entities.User;

/// <summary>
/// Класс сопоставляется с таблицей ролей пользователей, которые на них назначены.
/// </summary>
[Table("UserRoles", Schema = "dbo")]
public class UserRoleEntity
{
    public string Type { get; set; }
}