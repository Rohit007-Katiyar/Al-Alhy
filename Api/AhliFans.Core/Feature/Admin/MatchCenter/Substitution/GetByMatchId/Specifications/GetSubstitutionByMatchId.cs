using Ardalis.Specification;

namespace AhliFans.Core.Feature.Admin.MatchCenter.Substitution.GetByMatchId.Specifications;

public sealed class GetSubstitutionByMatchId : Specification<Entities.Substitution>
{
  public GetSubstitutionByMatchId(int matchId)
  {
    Query
      .Include(x=>x.Player)
      .Include(x=>x.SubstitutionPlayer)
      .Where(x => x.MatchId == matchId);
  }
}
