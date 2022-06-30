namespace Leoka.Elementary.Platform.Models.Entities.Profile;

/// <summary>
/// Класс сопоставляется с таблицей целей подготовки пользователя Profile.UserTrainings.
/// </summary>
public class UserTrainingEntity
{
    /// <summary>
    /// PK.
    /// </summary>
    public long TrainingId { get; set; }

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