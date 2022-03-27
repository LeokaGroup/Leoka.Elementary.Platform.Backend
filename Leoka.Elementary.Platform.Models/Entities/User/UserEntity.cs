using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace Leoka.Elementary.Platform.Models.Entities.User;

/// <summary>
/// Класс сопоставляется с таблицей пользователей.
/// </summary>
[Table("Users", Schema = "dbo")]
public class UserEntity : IdentityUser
{
    
}