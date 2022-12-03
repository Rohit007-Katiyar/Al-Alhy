using Ardalis.Specification;

namespace AhliFans.Core.Feature.Fan.MatchCenter.MatchStatistics.GetByMatchId.Specifications;

public class GetMatchCards : Specification<Entities.MatchCard>
{
    public GetMatchCards(int matchId)
    {
        Query
        .AsNoTracking()
        .Where(c => c.MatchId == matchId);
    }
}