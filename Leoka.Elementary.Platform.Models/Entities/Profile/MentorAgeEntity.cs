namespace Leoka.Elementary.Platform.Models.Entities.Profile;

/// <summary>
/// Класс сопоставляется с таблицей Profile.MentorAge.
/// </summary>
public class MentorAgeEntity
{
    public MentorAgeEntity()
    {
        StudentAgeMentors = new HashSet<StudentAgeMentorEntity>();
    }

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
    
    public ICollection<StudentAgeMentorEntity> StudentAgeMentors { get; set; }
}