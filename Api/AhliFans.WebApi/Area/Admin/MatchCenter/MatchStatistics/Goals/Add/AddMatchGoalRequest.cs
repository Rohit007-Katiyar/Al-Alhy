using AhliFans.Core.Feature.Security.Enums;

namespace AhliFans.WebApi.Area.Admin.MatchCenter.MatchStatistics.Goals;

public record AddMatchGoalRequest(int MatchId, int? PlayerId, int Minute, bool IsForAhly)
{
    public const string Route = $"{nameof(Areas.Admin)}/MatchCenter/MatchStatistics/Goals";
}