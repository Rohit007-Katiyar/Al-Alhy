using AhliFans.Core.Feature.Security.Enums;

namespace AhliFans.WebApi.Area.Admin.MatchCenter.MatchStatistics.Groups.Coefficients;

public record GetStatisticGroupCoefficientByIdRequest(int StatisticGroupCoefficientId)
{
  public const string Route = $"{nameof(Areas.Admin)}/MatchCenter/MatchStatistics/Groups/Coefficients/{{StatisticGroupCoefficientId}}";
};
