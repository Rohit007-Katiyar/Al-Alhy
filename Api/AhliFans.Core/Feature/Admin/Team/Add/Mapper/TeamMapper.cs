using AhliFans.Core.Feature.Admin.Team.Add.Events;

namespace AhliFans.Core.Feature.Admin.Team.Add.Mapper;

public class TeamMapper : AutoMapper.Profile
{
  public TeamMapper()
  {
    CreateMap<AddTeamEvent, Entities.Team>()
      .ForMember(dest => dest.Date, src => src.MapFrom(src => DateTime.Now))
      .ForMember(dest => dest.Logo, src => src.MapFrom(src => src.Logo!.FileName))
      .ReverseMap();
  }
}
