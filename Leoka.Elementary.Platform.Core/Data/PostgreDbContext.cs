using Leoka.Elementary.Platform.Core.Extensions;
using Leoka.Elementary.Platform.Models.Entities.Common;
using Leoka.Elementary.Platform.Models.Entities.MainPage;
using Leoka.Elementary.Platform.Models.Entities.Profile;
using Leoka.Elementary.Platform.Models.Entities.Request;
using Leoka.Elementary.Platform.Models.Entities.User;
using Microsoft.EntityFrameworkCore;

namespace Leoka.Elementary.Platform.Core.Data;

public class PostgreDbContext : DbContext
{
    private readonly DbContextOptions<PostgreDbContext> _options;

    public PostgreDbContext(DbContextOptions<PostgreDbContext> options) : base(options)
    {
        _options = options;
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // base.OnModelCreating(modelBuilder);
        MappingsExtensions.Configure(modelBuilder);
    }
    
    /// <summary>
    /// Таблица dbo.Users.
    /// </summary>
    public DbSet<UserEntity> Users { get; set; }

    /// <summary>
    /// Табилца dbo.UserRoles.
    /// </summary>
    public DbSet<UserRoleEntity> UserRoles { get; set; }

    /// <summary>
    /// Таблица dbo.Roles.
    /// </summary>
    public DbSet<RoleEntity> Roles { get; set; }

    /// <summary>
    /// Таблица dbo.AboutPlatform.
    /// </summary>
    public DbSet<AboutPlatformEntity> AboutPlatforms { get; set; }

    /// <summary>
    /// Таблица dbo.Footer.
    /// </summary>
    public DbSet<FooterEntity> Footer { get; set; }

    /// <summary>
    /// Таблица dbo.Header.
    /// </summary>
    public DbSet<HeaderEntity> Header { get; set; }

    /// <summary>
    /// Таблица dbo.MainBestOptions.
    /// </summary>
    public DbSet<MainBestOptionEntity> MainBestOptions { get; set; }

    /// <summary>
    /// Таблица bo.MainBestQuestionAcceptAnswers.
    /// </summary>
    public DbSet<MainBestQuestionAcceptAnswerEntity> MainBestQuestionAcceptAnswers { get; set; }

    /// <summary>
    /// Таблица dbo.MainBestQuestionOptions.
    /// </summary>
    public DbSet<MainBestQuestionOptionEntity> MainBestQuestionOptions { get; set; }

    /// <summary>
    /// Таблица dbo.MainBestQuestions.
    /// </summary>
    public DbSet<MainBestQuestionEntity> MainBestQuestions { get; set; }

    /// <summary>
    /// Таблица dbo.MainFonStudent.
    /// </summary>
    public DbSet<MainFonStudentEntity> MainFonStudent { get; set; }

    /// <summary>
    /// Таблица dbo.MentorWork.
    /// </summary>
    public DbSet<MentorWorkEntity> MentorWork { get; set; }

    /// <summary>
    /// Таблица dbo.SmartClassStudent.
    /// </summary>
    public DbSet<SmartClassStudentEntity> SmartClassStudent { get; set; }

    /// <summary>
    /// Таблица dbo.SmartClassStudentItems.
    /// </summary>
    public DbSet<SmartClassStudentItemEntity> SmartClassStudentItems { get; set; }

    /// <summary>
    /// Таблица dbo.WhereBegin.
    /// </summary>
    public DbSet<WhereBeginEntity> WhereBegin { get; set; }

    /// <summary>
    /// Таблица dbo.WhereBeginItems.
    /// </summary>
    public DbSet<WhereBeginItemEntity> WhereBeginItems { get; set; }

    /// <summary>
    /// Таблица dbo.WriteReception.
    /// </summary>
    public DbSet<WriteReceptionEntity> WriteReception { get; set; }

    /// <summary>
    /// Таблица dbo.MainFonStudentItem.
    /// </summary>
    public DbSet<MainFonStudentItemEntity> MainFonStudentItems { get; set; }

    /// <summary>
    /// Таблица dbo.Requests.
    /// </summary>
    public DbSet<RequestEntity> Requests { get; set; }

    /// <summary>
    /// Таблица dbo.MainFonMentor.
    /// </summary>
    public DbSet<MainFonMentorEntity> MainFonMentor { get; set; }

    /// <summary>
    /// Таблица dbo.MainFonMentorItems.
    /// </summary>
    public DbSet<MainFonMentorItemEntity> MainFonMentorItems { get; set; }

    /// <summary>
    /// Таблица Profile.ProfileInfos.
    /// </summary>
    public DbSet<ProfileInfoEntity> ProfileInfos { get; set; }

    /// <summary>
    /// Таблица Profile.ProfileMenuItems.
    /// </summary>
    public DbSet<ProfileMenuItemEntity> ProfileMenuItems { get; set; }

    /// <summary>
    /// Таблица Profile.ProfileItems.
    /// </summary>
    public DbSet<ProfileItemEntity> ProfileItems { get; set; }

    /// <summary>
    /// Таблица Profile.LessonsDuration.
    /// </summary>
    public DbSet<LessonDurationEntity> LessonsDuration { get; set; }

    /// <summary>
    /// Таблица Profile.PurposeTrainings.
    /// </summary>
    public DbSet<PurposeTrainingEntity> PurposeTrainings { get; set; }

    /// <summary>
    /// Таблица Profile.MentorProfileInfo.
    /// </summary>
    public DbSet<MentorProfileInfoEntity> MentorProfileInfo { get; set; }

    /// <summary>
    /// Таблица Profile.MentorProfileItems.
    /// </summary>
    public DbSet<MentorProfileItemEntity> MentorProfileItems { get; set; }

    /// <summary>
    /// Таблица Profile.UserLessonPrices.
    /// </summary>
    public DbSet<UserLessonPriceEntity> UserLessonPrices { get; set; }

    /// <summary>
    /// Таблица Profile.MentorLessonDurations.
    /// </summary>
    public DbSet<MentorLessonDurationEntity> MentorLessonDurations { get; set; }

    /// <summary>
    /// Таблица Profile.UserTrainings.
    /// </summary>
    public DbSet<UserTrainingEntity> UserTrainings { get; set; }

    /// <summary>
    /// Таблица Profile.MentorEducations.
    /// </summary>
    public DbSet<MentorEducationEntity> MentorEducations { get; set; }

    /// <summary>
    /// Таблица Profile.MentorExperience.
    /// </summary>
    public DbSet<MentorExperienceEntity> MentorExperience { get; set; }

    /// <summary>
    /// Таблица Profile.MentorCertificates.
    /// </summary>
    public DbSet<MentorCertificateEntity> MentorCertificates { get; set; }

    /// <summary>
    /// Таблица Profile.UserTimes.
    /// </summary>
    public DbSet<UserTimeEntity> UserTimes { get; set; }

    /// <summary>
    /// Таблица Profile.DaysWeek.
    /// </summary>
    public DbSet<DayWeekEntity> DaysWeek { get; set; }

    /// <summary>
    /// Таблица Profile.MentorAboutInfo.
    /// </summary>
    public DbSet<MentorAboutInfoEntity> MentorAboutInfos { get; set; }

    /// <summary>
    /// Таблица Profile.MentorAge.
    /// </summary>
    public DbSet<MentorAgeEntity> MentorAge { get; set; }

    /// <summary>
    /// Таблица Profile.MentorGender.
    /// </summary>
    public DbSet<MentorGenderEntity> MentorGender { get; set; }

    /// <summary>
    /// Таблица Profile.StudentComments.
    /// </summary>
    public DbSet<StudentCommentEntity> StudentComments { get; set; }

    /// <summary>
    /// Таблица Profile.StudentAgeMentor.
    /// </summary>
    public DbSet<StudentAgeMentorEntity> StudentAgeMentor { get; set; }
    
    /// <summary>
    /// Таблица Profile.StudentGenderMentor.
    /// </summary>
    public DbSet<StudentGenderMentorEntity> StudentGenderMentor { get; set; }

    /// <summary>
    /// Таблица Profile.StudentProfileItems.
    /// </summary>
    public DbSet<StudentProfileItemEntity> StudentProfileItems { get; set; }

    /// <summary>
    /// Таблица Profile.StudentLessonPrices.
    /// </summary>
    public DbSet<StudentLessonPriceEntity> StudentLessonPrices { get; set; }
}