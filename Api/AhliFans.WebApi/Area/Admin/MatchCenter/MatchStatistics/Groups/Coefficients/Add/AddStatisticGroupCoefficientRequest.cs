using AhliFans.Core.Feature.Security.Enums;

namespace AhliFans.WebApi.Area.Admin.MatchCenter.MatchStatistics.Groups.Coefficients;

public record AddStatisticGroupCoefficientRequest(int StatisticTypeId, string Name, string NameAr, bool IsPercentage)
{
  public const string Route = $"{nameof(Areas.Admin)}/MatchCenter/MatchStatistics/Groups/Coefficients";
};
