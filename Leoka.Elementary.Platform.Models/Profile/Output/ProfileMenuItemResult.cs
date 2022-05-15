namespace Leoka.Elementary.Platform.Models.Profile.Output;

/// <summary>
/// Класс выходной модели со списками для каждого типа меню профиля пользователя. 
/// </summary>
public class ProfileMenuItemResult
{
    /// <summary>
    /// Список с элементами левого меню. 
    /// </summary>
    public IEnumerable<ProfileMenuItemOutput> ProfileLeftMenuItems { get; set; }
    
    /// <summary>
    /// Список с элементами меню в хидере. 
    /// </summary>
    public IEnumerable<ProfileMenuItemOutput> ProfileHeaderMenuItems { get; set; }
    
    /// <summary>
    /// Список с элементами меню в выпадающей секции. 
    /// </summary>
    public IEnumerable<ProfileMenuItemOutput> ProfileDropdownMenuItems { get; set; }
}