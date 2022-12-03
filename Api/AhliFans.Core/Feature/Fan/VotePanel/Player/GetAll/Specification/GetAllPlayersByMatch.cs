using AhliFans.Core.Feature.Entities;
using Ardalis.Specification;

namespace AhliFans.Core.Feature.Fan.VotePanel.Player.GetAll.Specification;

public sealed class GetAllPlayersByMatch : Specification<MatchPlayer>
{
  public GetAllPlayersByMatch(int matchId)
  {
    Query
      .Include(x=>x.Player)
      .ThenInclude(y=>y.Position)
      .Where(x => x.MatchId == matchId);
  }
}
