using AhliFans.Core.Feature.Security.Enums;

namespace AhliFans.WebApi.Area.Admin.MatchCenter.MatchStatistics.Groups.Coefficients;

public record GetAllStatisticGroupCoefficientRequest(int? StatisticTypeId, string? Name, int PageIndex, int PageSize, string? Lang)
{
  public const string Route = $"{nameof(Areas.Admin)}/MatchCenter/MatchStatistics/Groups/Coefficients";
};
