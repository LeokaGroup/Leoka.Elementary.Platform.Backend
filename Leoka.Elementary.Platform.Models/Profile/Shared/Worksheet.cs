using Leoka.Elementary.Platform.Models.Profile.Input;
using Leoka.Elementary.Platform.Models.Profile.Output;

namespace Leoka.Elementary.Platform.Models.Profile.Shared;

/// <summary>
/// Класс описывает данные анкеты пользователя.
/// </summary>
public class Worksheet
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
    public List<ProfileItemOutput> UserItems { get; set; } = new();
    
    /// <summary>
    /// Список цен пользователя.
    /// </summary>
    public List<UserProfilePrices> UserPrices { get; set; } = new();
    
    /// <summary>
    /// Список длительностей пользователя.
    /// </summary>
    public List<UserProfileDurations> UserDurations { get; set; } = new();
    
    /// <summary>
    /// Список свободного времени пользователя.
    /// </summary>
    public List<UserTimes> UserTimes { get; set; } = new();

    /// <summary>
    /// Список целей подготовки преподавателя.
    /// </summary>
    public List<PurposeTrainingOutput> UserTrainings { get; set; } = new();

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

    /// <summary>
    /// Роль пользователя.
    /// </summary>
    public int UserRole { get; set; }

    /// <summary>
    /// Данные возрастов преподавателя для выбора.
    /// </summary>
    public List<MentorAgeOutput> MentorAge { get; set; } = new();

    /// <summary>
    /// Данные пола преподавателя для выбора.
    /// </summary>
    public List<MentorGenderOutput> MentorGenders { get; set; } = new();

    /// <summary>
    /// Данные комментария студента.
    /// </summary>
    public StudentCommentsOutput StudentComments { get; set; }

    /// <summary>
    /// Данные выбранных возрастов преподавателя студентом.
    /// </summary>
    public StudentAgeMentorOutput StudentAgeMentor { get; set; }

    /// <summary>
    /// Данные выбранного пола преподавателя студентом.
    /// </summary>
    public StudentGenderMentorOutput StudentGenderMentor { get; set; }

    /// <summary>
    /// Список предметов студента.
    /// </summary>
    public List<StudentProfileItemOutput> StudentProfileItems { get; set; } = new();
}