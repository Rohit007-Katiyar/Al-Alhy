using AhliFans.Core.Feature.Entities;
using Ardalis.Specification;

namespace AhliFans.Core.Feature.Admin.LineUp.GetById.Specifications;

public sealed class GetLineUpByMatchId : Specification<MatchLineUp>, ISingleResultSpecification
{
  public GetLineUpByMatchId(int matchId)
  {
    Query
      .Include(x=>x.Player)
      .Include(y=>y.Position)
      .Where(x => x.MatchId == matchId);
  }
}
