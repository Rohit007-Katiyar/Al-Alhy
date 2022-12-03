using Ardalis.Specification;

namespace AhliFans.Core.Feature.Fan.MatchCenter.Vote.GetTopByMatchId.Specifications;

public class CheckFanVoted : Specification<Entities.PlayerVote>
{
    public CheckFanVoted(Guid fanId, int MatchId)
    {
        Query
        .AsNoTracking()
        .Where(v => v.MatchId == MatchId && v.FanId == fanId);
    }
}