namespace AhliFans.Core.Feature.Admin.MatchCenter.MatchStatistics.Groups.Coefficients;

public class StatisticGroupCoefficientMapper : AutoMapper.Profile
{
  public StatisticGroupCoefficientMapper()
  {
    CreateMap<Entities.MatchStatisticsTypeCoefficient, StatisticGroupCoefficientDto>()
    .ReverseMap();
  }
}
