using AhliFans.Core.Feature.Entities;
using Ardalis.Specification;

namespace AhliFans.Core.Feature.Admin.LineUp.Add.Specifications;

public sealed class IsMatchHasLineUp : Specification<MatchLineUp>
{
  public IsMatchHasLineUp(int matchId)
  {
    Query
      .Where(x => x.MatchId == matchId);
  }
}
