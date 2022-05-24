namespace Leoka.Elementary.Platform.Models.Entities.Profile;

/// <summary>
/// Класс сопоставляется с таблицей сертификатов преподавателя MentorCertificates.
/// </summary>
public class MentorCertificateEntity
{
    /// <summary>
    /// PK.
    /// </summary>
    public long CertificateId { get; set; }

    /// <summary>
    /// Изображение сертификата.
    /// </summary>
    public string CertificateName { get; set; }

    /// <summary>
    /// Id пользователя.
    /// </summary>
    public long UserId { get; set; }
}