namespace Leoka.Elementary.Platform.Models.Entities.Profile;

/// <summary>
/// Класс сопоставляется с таблицей целей подготовки преподавателя Profile.MentorTrainings.
/// </summary>
public class MentorTrainingEntity
{
    /// <summary>
    /// PK.
    /// </summary>
    public long TrainingId { get; set; }

    /// <summary>
    /// Название цели.
    /// </summary>
    public string TrainingName { get; set; }

    /// <summary>
    /// Системное название цели.
    /// </summary>
    public string TrainingSysName { get; set; }

    /// <summary>
    /// Id пользователя.
    /// </summary>
    public long UserId { get; set; }

    /// <summary>
    /// Id цели подготовки.
    /// </summary>
    public int PurposeId { get; set; }

    public PurposeTrainingEntity PurposeTraining { get; set; }
}