using AhliFans.Core.Feature.Security.Enums;

namespace AhliFans.WebApi.Area.Admin.MatchCenter.MatchStatistics.Groups;

public record GetStatisticGroupByIdRequest(int StatisticGroupId)
{
  public const string Route = $"{nameof(Areas.Admin)}/MatchCenter/MatchStatistics/Groups/{{StatisticGroupId}}";
};
