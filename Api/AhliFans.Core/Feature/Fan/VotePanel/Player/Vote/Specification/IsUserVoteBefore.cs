using AhliFans.Core.Feature.Entities;
using Ardalis.Specification;

namespace AhliFans.Core.Feature.Fan.VotePanel.Player.Vote.Specification;

public sealed class IsUserVoteBefore : Specification<PlayerVote>
{
  public IsUserVoteBefore(Guid fanId,int matchId)
  {
    Query
      .Where(x => x.MatchId == matchId && x.FanId == fanId);
  }
}
