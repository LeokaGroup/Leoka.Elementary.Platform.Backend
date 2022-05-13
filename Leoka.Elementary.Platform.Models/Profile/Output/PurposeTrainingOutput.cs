namespace Leoka.Elementary.Platform.Models.Profile.Output;

/// <summary>
/// Класс выходной модели для целей подготовки.
/// </summary>
public class PurposeTrainingOutput
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