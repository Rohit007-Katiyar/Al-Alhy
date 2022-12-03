using Ardalis.Specification;

namespace AhliFans.Core.Feature.Admin.MatchCenter.MatchStatistics.Goals;

public class GetGoalsByMatchId : Specification<Entities.MatchGoal>
{
    public GetGoalsByMatchId(int matchId)
    {
        Query
        .AsNoTracking()
        .Include(g => g.Scorer)
        .Where(g => g.MatchId == matchId);
    }
}