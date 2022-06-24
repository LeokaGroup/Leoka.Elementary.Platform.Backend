namespace Leoka.Elementary.Platform.Models.Entities.Profile;

/// <summary>
/// Класс сопоставляется с таблицей Profile.MentorAge.
/// </summary>
public class MentorAgeEntity
{
    /// <summary>
    /// PK.
    /// </summary>
    public int AgeId { get; set; }

    /// <summary>
    /// Возраст от.
    /// </summary>
    public int StartAge { get; set; }
    
    /// <summary>
    /// Возраст до.
    /// </summary>
    public int EndAge { get; set; }
}