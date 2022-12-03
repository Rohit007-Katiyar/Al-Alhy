using Ardalis.Specification;

namespace AhliFans.Core.Feature.Fan.VotePanel.Player;

public class GetClientVoteWithPlayer : Specification<Entities.PlayerVote>, ISingleResultSpecification
{
  public GetClientVoteWithPlayer(Guid fanId)
  {
    Query
      .AsNoTracking()
      .Include(v => v.Player)
      .Where(v => v.FanId == fanId);
  }
}
