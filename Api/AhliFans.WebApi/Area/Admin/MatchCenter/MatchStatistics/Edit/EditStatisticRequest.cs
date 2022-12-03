using AhliFans.Core.Feature.Security.Enums;

namespace AhliFans.WebApi.Area.Admin.MatchCenter.MatchStatistics;

public record EditStatisticRequest(int Id, int Value, int MatchId, int StatisticsTypeId, int StatisticsCoefficientId)
{
  public const string Route = $"{nameof(Areas)}/MatchCenter/MatchStatistics";
};
