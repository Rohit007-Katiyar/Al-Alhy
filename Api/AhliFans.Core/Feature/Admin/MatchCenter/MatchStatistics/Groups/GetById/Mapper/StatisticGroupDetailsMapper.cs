namespace AhliFans.Core.Feature.Admin.MatchCenter.MatchStatistics.Groups;

public class StatisticGroupDetailsMapper : AutoMapper.Profile
{
  public StatisticGroupDetailsMapper()
  {
    CreateMap<Entities.MatchStatisticsType, StatisticGroupDetailsDto>()
    .ReverseMap();
  }
}
