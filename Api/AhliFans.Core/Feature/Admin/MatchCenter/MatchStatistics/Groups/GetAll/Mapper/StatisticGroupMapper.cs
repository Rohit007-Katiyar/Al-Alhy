namespace AhliFans.Core.Feature.Admin.MatchCenter.MatchStatistics.Groups;

public class StatisticGroupMapper : AutoMapper.Profile
{
  public StatisticGroupMapper()
  {
    CreateMap<Entities.MatchStatisticsType, StatisticGroupDto>()
    .ReverseMap();
  }
}
