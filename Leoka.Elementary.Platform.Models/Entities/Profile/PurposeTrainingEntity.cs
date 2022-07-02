namespace Leoka.Elementary.Platform.Models.Entities.Profile;

/// <summary>
/// Класс сопоставляется с таблицей целей подготовки Profile.PurposeTrainings.
/// </summary>
public class PurposeTrainingEntity
{
    public PurposeTrainingEntity()
    {
        UserTrainings = new HashSet<UserTrainingEntity>();
    }

    /// <summary>
    /// PK.
    /// </summary>
    public int PurposeId { get; set; }

    /// <summary>
    /// Системное название цели.
    /// </summary>
    public string PurposeSysName { get; set; }

    /// <summary>
    /// Название цели.
    /// </summary>
    public string PurposeName { get; set; }

    public virtual ICollection<UserTrainingEntity> UserTrainings { get; set; }
}