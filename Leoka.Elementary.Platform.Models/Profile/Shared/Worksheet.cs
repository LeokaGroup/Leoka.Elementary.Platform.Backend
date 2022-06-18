using Leoka.Elementary.Platform.Models.Profile.Input;
using Leoka.Elementary.Platform.Models.Profile.Output;

namespace Leoka.Elementary.Platform.Models.Profile.Shared;

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
    public List<ProfileItemOutput> MentorItems { get; set; } = new();
    
    /// <summary>
    /// Список цен преподавателя.
    /// </summary>
    public List<MentorProfilePrices> MentorPrices { get; set; } = new();
    
    /// <summary>
    /// Список длительностей преподавателя.
    /// </summary>
    public List<MentorProfileDurations> MentorDurations { get; set; } = new();
    
    /// <summary>
    /// Список свободного времени преподавателя.
    /// </summary>
    public List<MentorTimes> MentorTimes { get; set; } = new();

    /// <summary>
    /// Список целей подготовки преподавателя.
    /// </summary>
    public List<PurposeTrainingOutput> MentorTrainings { get; set; } = new();

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

    // /// <summary>
    // /// Флаг видимости кнопки сохранения предметов.
    // /// </summary>
    // public bool IsVisibleButtonSaveItems
    // {
    //     get => MentorItems.Any();
    //
    //     set => IsVisibleButtonSaveItems = value;
    // }
    //
    // /// <summary>
    // /// Флаг видимости кнопки сохранения цен.
    // /// </summary>
    // public bool IsVisibleButtonSavePrices
    // {
    //     get => MentorPrices.Any();
    //
    //     set => IsVisibleButtonSavePrices = value;
    // }
    //
    // /// <summary>
    // /// Флаг видимости кнопки сохранения длительностей.
    // /// </summary>
    // public bool IsVisibleButtonSaveDurations
    // {
    //     get => MentorDurations.Any();
    //
    //     set => IsVisibleButtonSaveDurations = value;
    // }
    //
    // /// <summary>
    // /// Флаг видимости кнопки сохранения целей тренировок.
    // /// </summary>
    // public bool IsVisibleButtonSaveTrainings
    // {
    //     get => MentorTrainings.Any();
    //
    //     set => IsVisibleButtonSaveTrainings = value;
    // }
    //
    // /// <summary>
    // /// Флаг видимости кнопки сохранения времени.
    // /// </summary>
    // public bool IsVisibleButtonSaveTimes
    // {
    //     get => MentorTimes.Any();
    //
    //     set => IsVisibleButtonSaveTimes = value;
    // }
    //
    // /// <summary>
    // /// Флаг видимости кнопки сохранения информации обо мне.
    // /// </summary>
    // public bool IsVisibleButtonSaveAboutInfo
    // {
    //     get => MentorAboutInfo.Any();
    //
    //     set => IsVisibleButtonSaveAboutInfo = value;
    // }
    //
    // /// <summary>
    // /// Флаг видимости кнопки сохранения образования.
    // /// </summary>
    // public bool IsVisibleButtonSaveEducations
    // {
    //     get => MentorEducations.Any();
    //
    //     set => IsVisibleButtonSaveEducations = value;
    // }
    //
    // /// <summary>
    // /// Флаг видимости кнопки сохранения опыта.
    // /// </summary>
    // public bool IsVisibleButtonSaveExperience
    // {
    //     get => MentorExperience.Any();
    //
    //     set => IsVisibleButtonSaveExperience = value;
    // }
}