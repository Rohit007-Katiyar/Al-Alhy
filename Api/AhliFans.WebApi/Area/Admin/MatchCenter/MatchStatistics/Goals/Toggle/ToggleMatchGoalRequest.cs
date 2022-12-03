using AhliFans.Core.Feature.Security.Enums;

namespace AhliFans.WebApi.Area.Admin.MatchCenter.MatchStatistics.Goals;

public record ToggleMatchGoalRequest(int GoalId)
{
    public const string Route = $"{nameof(Areas.Admin)}/MatchCenter/MatchStatistics/Goals/{{GoalId}}";
};