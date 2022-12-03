namespace AhliFans.Core.Feature.Admin.MatchCenter.MatchStatistics.Groups.Coefficients;

public class StatisticGroupCoefficientDetailsMapper : AutoMapper.Profile
{
  public StatisticGroupCoefficientDetailsMapper()
  {
    CreateMap<Entities.MatchStatisticsTypeCoefficient, StatisticGroupCoefficientDetailsDto>()
    .ReverseMap();
  }
}
