namespace Leoka.Elementary.Platform.Models.Entities.Profile;

/// <summary>
/// Класс сопоставляется с таблицей целей подготовки Profile.PurposeTrainings.
/// </summary>
public class PurposeTrainingEntity
{
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
}