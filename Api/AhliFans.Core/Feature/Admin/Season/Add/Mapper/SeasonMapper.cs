using AhliFans.Core.Feature.Admin.Season.Add.Events;

namespace AhliFans.Core.Feature.Admin.Season.Add.Mapper;

public class SeasonMapper : AutoMapper.Profile
{
  public SeasonMapper()
  {
    CreateMap<AddSeasonEvent,Entities.Season>()
      .ForMember(dest => dest.CreationDate,
        src => src.MapFrom(src => DateTime.Now))
      .ReverseMap();
  }
}
