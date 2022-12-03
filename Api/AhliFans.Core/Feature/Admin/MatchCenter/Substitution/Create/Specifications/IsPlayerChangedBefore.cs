using Ardalis.Specification;

namespace AhliFans.Core.Feature.Admin.MatchCenter.Substitution.Create.Specifications;

public sealed class IsPlayerChangedBefore : Specification<Entities.Substitution>
{
  public IsPlayerChangedBefore(int matchId,int playerId)
  {
    Query
      .Where(x => x.MatchId == matchId && x.PlayerId == playerId);
  }
}
