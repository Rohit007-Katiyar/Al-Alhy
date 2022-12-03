using AhliFans.Core.Feature.Security.Enums;

namespace AhliFans.WebApi.Area.Admin.MatchCenter.MatchStatistics.Groups;

public record GetAllStatisticGroupsRequest(int PageIndex, int PageSize, string? Name, string? Lang)
{
  public const string Route = $"{nameof(Areas.Admin)}/MatchCenter/MatchStatistics/Groups";
};
