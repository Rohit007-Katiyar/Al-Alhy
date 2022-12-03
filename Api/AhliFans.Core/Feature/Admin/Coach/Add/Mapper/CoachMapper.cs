using AhliFans.Core.Feature.Admin.Coach.Add.Events;

namespace AhliFans.Core.Feature.Admin.Coach.Add.Mapper;
public class CoachMapper : AutoMapper.Profile
{
  public CoachMapper()
  {
    CreateMap<AddCoachEvent, Entities.Coach>()
      .ForMember(dest => dest.Pic,
        src => src.MapFrom(src => src.Pic == null ? "" :src.Pic.FileName))
      .ForMember(dest => dest.CityId,
        src => src.MapFrom(src => src.CityId))
      .ForMember(dest => dest.CountryId,
        src => src.MapFrom(src => src.CountryId))
      .ForMember(dest => dest.City,
        src => src.Ignore())
      .ForMember(dest => dest.Country,
        src => src.Ignore())
      .ForMember(dest => dest.Date,
        src => src.MapFrom(src => DateTime.Now))
      .ForMember(dest => dest.TeamCategoryId,
       src => src.MapFrom(src => src.TeamCategoryId))
      .ReverseMap();
  }
}
