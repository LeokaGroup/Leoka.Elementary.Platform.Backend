using AutoMapper;
using Leoka.Elementary.Platform.Models.Entities.MainPage;
using Leoka.Elementary.Platform.Models.MainPage.Output;

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
    }
}