using AhliFans.Core.Feature.Entities;
using Ardalis.Specification;

namespace AhliFans.Core.Feature.Fan.MatchCenter.MatchStatistics.Goals;

public class GetGoalsByMatchIdWithPlayer : Specification<MatchGoal>
{
    public GetGoalsByMatchIdWithPlayer(int matchId)
    {
        Query.AsNoTracking()
        .Include(g => g.Scorer)
        .Where(g => g.MatchId == matchId && g.IsEnabled);
    }
}