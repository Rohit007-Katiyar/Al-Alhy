using AhliFans.Core.Feature.Admin.Player.Add.Events;

namespace AhliFans.Core.Feature.Admin.Player.Add.Mapper;
public class PlayerMapper : AutoMapper.Profile
{
  public PlayerMapper()
  {
    CreateMap<AddPlayerEvent, Entities.Player>()
      .ForMember(dest => dest.Pic,
        src => src.MapFrom(src => src.Pic!.FileName))
      .ForMember(dest => dest.Date,
        src => src.MapFrom(src => DateTime.Now))
      .ForMember(dest => dest.CityOfBirthId,
        src => src.MapFrom(src => src.CityOfBirth))
      .ForMember(dest => dest.CountryHeLiveIn,
        src => src.MapFrom(src => src.CountryHeLive))
      .ForMember(dest => dest.CityOfBirth,
        src => src.Ignore())
      .ForMember(dest => dest.Country,
        src => src.Ignore())
      .ForMember(dest => dest.TeamCategoryId,
      src => src.MapFrom(x => x.TeamCategoryId))
      .ReverseMap();
  }
}
