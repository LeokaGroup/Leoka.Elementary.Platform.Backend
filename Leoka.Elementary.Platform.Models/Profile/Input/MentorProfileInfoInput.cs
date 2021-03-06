namespace Leoka.Elementary.Platform.Models.Profile.Input;

/// <summary>
/// Класс входной модели анкеты профиля преподавателя.
/// </summary>
public class MentorProfileInfoInput
{
    /// <summary>
    /// Имя.
    /// </summary>
    public string FirstName { get; set; }

    /// <summary>
    /// Фамилия.
    /// </summary>
    public string LastName { get; set; }

    /// <summary>
    /// Отчество.
    /// </summary>
    public string SecondName { get; set; }

    /// <summary>
    /// Номер телефона преподавателя.
    /// </summary>
    public string PhoneNumber { get; set; }

    /// <summary>
    /// Email преподавателя.
    /// </summary>
    public string Email { get; set; }

    /// <summary>
    /// Отображать ли всем контакты.
    /// </summary>
    public bool IsVisibleAllContact { get; set; }

    /// <summary>
    /// Список предметов.
    /// </summary>
    public List<MentorProfileItems> MentorItems { get; set; } = new();
    
    /// <summary>
    /// Список цен преподавателя.
    /// </summary>
    public List<UserProfilePrices> UserPrices { get; set; } = new();
    
    /// <summary>
    /// Список длительностей преподавателя.
    /// </summary>
    public List<UserProfileDurations> UserDurations { get; set; } = new();
    
    /// <summary>
    /// Список свободного времени пользователя.
    /// </summary>
    public List<UserTimes> UserTimes { get; set; } = new();

    /// <summary>
    /// Список целей подготовки пользователя.
    /// </summary>
    public List<UserTrainings> UserTrainings { get; set; } = new();

    /// <summary>
    /// Список опыта преподавателя.
    /// </summary>
    public List<MentorExperience> MentorExperience { get; set; } = new();

    /// <summary>
    /// Список образований преподавателя.
    /// </summary>
    public List<MentorEducations> MentorEducations { get; set; } = new();

    /// <summary>
    /// Список информации о преподавателе.
    /// </summary>
    public List<MentorAboutInfo> MentorAboutInfo { get; set; } = new();
}