using AhliFans.Core.Feature.Admin.Match.Add.Events;
using AhliFans.Core.Feature.Enums;

namespace AhliFans.Core.Feature.Admin.Match.Add.Mapper;

public class MatchMapper :AutoMapper.Profile
{
  public MatchMapper()
  {
    CreateMap<AddMatchEvent, Entities.Match>()
      .ForMember(dest => dest.Date,
        src => src.MapFrom(src => DateTime.Now))
      .ForMember(dest => dest.MatchType,
        src => src.MapFrom(src => src.MatchType))
      .ForMember(dest => dest.MatchStatus,
        src => src.MapFrom(src => src.MatchStatus))
      .ForMember(dest => dest.RefereeId,
        src => src.MapFrom(src => src.RefereeId)) 
      .ForMember(dest => dest.IsAvailable,
        src => src.MapFrom(src => true)) 
      .ForMember(dest => dest.LeagueId,
        src => src.MapFrom(src => src.LeagueId)) 
      .ForMember(dest => dest.LeagueDateId,
        src => src.MapFrom(src => src.LeagueDateId))
      .ReverseMap();
  }
}
