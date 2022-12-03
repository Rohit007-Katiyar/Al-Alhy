using AhliFans.Core.Feature.Security.Enums;

namespace AhliFans.WebApi.Area.Admin.MatchCenter.MatchStatistics;

public record AddStatisticGroupRequest(string Name, string NameAr, bool IsEnabled)
{
  public const string Route = $"{nameof(Areas.Admin)}/MatchCenter/MatchStatistics/Groups";
};
