using AhliFans.Core.Feature.Entities;

namespace AhliFans.Core.Feature.Admin.MatchCenter.MatchStatistics.Groups;

public class AddStatisticsGroupsMapper : AutoMapper.Profile
{
  public AddStatisticsGroupsMapper()
  {
    CreateMap<AddStatisticsGroupEvent, MatchStatisticsType>()
    .ForMember(src => src.CreatedOn, dest => dest.MapFrom(src => DateTime.Now))
    .ForMember(src => src.ModifiedOn, dest => dest.MapFrom(src => DateTime.Now))
    .ReverseMap();
  }
}
