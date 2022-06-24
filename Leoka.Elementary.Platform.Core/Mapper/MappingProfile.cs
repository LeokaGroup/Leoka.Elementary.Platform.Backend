using AutoMapper;
using Leoka.Elementary.Platform.Models.Entities.MainPage;
using Leoka.Elementary.Platform.Models.Entities.Profile;
using Leoka.Elementary.Platform.Models.MainPage.Output;
using Leoka.Elementary.Platform.Models.Profile.Input;
using Leoka.Elementary.Platform.Models.Profile.Output;

namespace Leoka.Elementary.Platform.Core.Mapper;

/// <summary>
/// Класс конфигурации маппера.
/// </summary>
public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<WhereBeginEntity, BeginOutput>();
        CreateMap<WhereBeginItemEntity, BeginItemsOutput>();
        
        CreateMap<SmartClassStudentEntity, SmartClassStudentOutput>();
        CreateMap<SmartClassStudentItemEntity, SmartClassStudentItemsOutput>();
        
        CreateMap<MainBestQuestionEntity, BestQuestionOutput>();
        CreateMap<MainBestQuestionOptionEntity, BestQuestionVariantItemsOutput>();
        CreateMap<MainBestOptionEntity, OptionOutput>();
        
        CreateMap<MentorProfileItems, MentorProfileItemEntity>();
        CreateMap<MentorProfilePrices, MentorLessonPriceEntity>();
        CreateMap<MentorLessonPriceEntity, MentorProfilePrices>();
        CreateMap<MentorProfileDurations, MentorLessonDurationEntity>();
        CreateMap<MentorTimes, MentorTimeEntity>();
        CreateMap<MentorTimeEntity, MentorTimes>();
        CreateMap<MentorTrainings, MentorTrainingEntity>();
        CreateMap<MentorExperience, MentorExperienceEntity>();
        CreateMap<MentorEducations, MentorEducationEntity>();
        CreateMap<MentorAboutInfo, MentorAboutInfoEntity>();
        CreateMap<MentorAboutInfoEntity, MentorAboutInfo>();
        CreateMap<MentorEducationEntity, MentorEducations>();
        CreateMap<MentorExperienceEntity, MentorExperience>();
        
        CreateMap<MentorProfileInfoInput, MentorProfileInfoOutput>();
        CreateMap<ProfileItemOutput, MentorProfileItemEntity>();
    }
}