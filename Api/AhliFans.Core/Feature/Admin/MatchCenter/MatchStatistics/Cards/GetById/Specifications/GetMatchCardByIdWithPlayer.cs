using Ardalis.Specification;

namespace AhliFans.Core.Feature.Admin.MatchCenter.MatchStatistics.Cards;

public class GetMatchCardByIdWithPlayer : Specification<Entities.MatchCard>, ISingleResultSpecification
{
    public GetMatchCardByIdWithPlayer(int id)
    {
        Query
        .AsNoTracking()
        .Include(c => c.TargetPlayer)
        .Where(c => c.Id == id);
    }
}