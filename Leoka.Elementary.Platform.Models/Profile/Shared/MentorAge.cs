namespace Leoka.Elementary.Platform.Models.Profile.Shared;

/// <summary>
/// Класс модели возраста преподавателя.
/// </summary>
public class MentorAge
{
    /// <summary>
    /// PK.
    /// </summary>
    public int AgeId { get; set; }

    /// <summary>
    /// Возраст от.
    /// </summary>
    public string StartAge { get; set; }
    
    /// <summary>
    /// Возраст до.
    /// </summary>
    public string EndAge { get; set; }

    /// <summary>
    /// Объединенный диапазон возраста разделяя дефисом.
    /// </summary>
    public string FullAge => EndAge is not null ? StartAge + "-" + EndAge : StartAge;
}