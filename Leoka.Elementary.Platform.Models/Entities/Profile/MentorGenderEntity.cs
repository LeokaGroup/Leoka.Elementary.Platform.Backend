namespace Leoka.Elementary.Platform.Models.Entities.Profile;

/// <summary>
/// Класс сопоставляется с таблицей Profile.MentorGender.
/// </summary>
public class MentorGenderEntity
{
    public MentorGenderEntity()
    {
        StudentGenderMentors = new HashSet<StudentGenderMentorEntity>();
    }

    /// <summary>
    /// PK.
    /// </summary>
    public int GenderId { get; set; }

    /// <summary>
    /// Пол преподавателя.
    /// </summary>
    public string GenderName { get; set; }
    
    public virtual ICollection<StudentGenderMentorEntity> StudentGenderMentors { get; set; }
}