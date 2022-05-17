using AutoMapper;
using Leoka.Elementary.Platform.Models.Entities.MainPage;
using Leoka.Elementary.Platform.Models.Entities.Profile;
using Leoka.Elementary.Platform.Models.MainPage.Output;
using Leoka.Elementary.Platform.Models.Profile.Input;
using Leoka.Elementary.Platform.Models.Profile.Output;

namespace Leoka.Elementary.Platform.Core.Mapper;

/// <summary>
/// Класс описывает конфигурацию маппера.
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
        
        CreateMap<MentorProfileItemEntity, MentorProfileItems>();
        CreateMap<MentorLessonPriceEntity, MentorProfileItems>();
        CreateMap<MentorLessonDurationEntity, MentorProfileItems>();
        CreateMap<MentorTimeEntity, MentorTimes>();
        CreateMap<MentorTrainingEntity, MentorTrainings>();
        CreateMap<MentorExperienceEntity, MentorExperience>();
        CreateMap<MentorEducationEntity, MentorEducations>();
        CreateMap<MentorProfileInfoOutput, MentorProfileInfoInput>();
    }
}