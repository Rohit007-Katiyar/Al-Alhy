using AhliFans.Core.Feature.Entities;
using Ardalis.Specification;

namespace AhliFans.Core.Feature.Fan.LineUp.GetByMatchId.Specifications;

public sealed class GetLineUpByMatchId : Specification<MatchLineUp>, ISingleResultSpecification
{
  public GetLineUpByMatchId(int matchId,bool isSubstitution)
  {
    Query
      .Include(x=>x.Player)
      .Include(y=>y.Position)
      .ThenInclude(z=>z!.GeneralPosition)
      .Where(x => x.MatchId == matchId && x.IsSubstitute == isSubstitution);
  }
}
