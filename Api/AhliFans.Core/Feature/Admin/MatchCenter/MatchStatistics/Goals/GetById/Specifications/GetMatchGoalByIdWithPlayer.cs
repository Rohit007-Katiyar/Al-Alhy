using AhliFans.Core.Feature.Entities;
using Ardalis.Specification;

namespace AhliFans.Core.Feature.Admin.MatchCenter.MatchStatistics.Goals;

public class GetMatchGoalByIdWithPlayer : Specification<MatchGoal>, ISingleResultSpecification
{
    public GetMatchGoalByIdWithPlayer(int id)
    {
        Query
        .AsNoTracking()
        .Include(g => g.Scorer)
        .Where(g => g.Id == id);
    }
}