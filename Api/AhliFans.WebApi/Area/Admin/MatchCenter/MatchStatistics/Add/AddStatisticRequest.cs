using AhliFans.Core.Feature.Security.Enums;

namespace AhliFans.WebApi.Area.Admin.MatchCenter.MatchStatistics;

public record AddStatisticRequest(int Value, int MatchId, int StatisticsTypeId, int StatisticsCoefficientId)
{
  public const string Route = $"{nameof(Areas.Admin)}/MatchCenter/MatchStatistics";
};
