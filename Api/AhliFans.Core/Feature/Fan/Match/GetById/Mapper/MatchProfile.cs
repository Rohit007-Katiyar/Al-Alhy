using AhliFans.Core.Feature.Fan.Match.GetById.DTO;
namespace AhliFans.Core.Feature.Fan.Match.GetById.Mapper;

public class MatchProfile : AutoMapper.Profile
{
  public MatchProfile()
  {
    CreateMap<Entities.Match, MatchDetailsDto>()
      .ForMember(dest => dest.MatchStatus,
        src => src.MapFrom(src => src.MatchStatus))
      .ReverseMap();
  }
}
