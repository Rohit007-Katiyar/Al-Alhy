using AhliFans.Core.Feature.Entities;
using Ardalis.Specification;

namespace AhliFans.Core.Feature.Admin.MatchCenter.MatchStatistics.Cards;

public class GetCardsByMatchIdWithPlayer : Specification<MatchCard>
{
    public GetCardsByMatchIdWithPlayer(int matchId)
    {
        Query
        .AsNoTracking()
        .Include(c => c.TargetPlayer)
        .Where(c => c.MatchId == matchId);
    }
}