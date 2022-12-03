using Ardalis.Specification;

namespace AhliFans.Core.Feature.Fan.MatchCenter.Vote.GetTopByMatchId.Specifications;

public class GetVotesByMatchId : Specification<Entities.PlayerVote>
{
    public GetVotesByMatchId(int matchId)
    { 
        Query
        .AsNoTrackingWithIdentityResolution()
        .Include(v => v.Player)
        .Where(v => v.MatchId == matchId);
    }
}