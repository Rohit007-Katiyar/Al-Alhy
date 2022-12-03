using Ardalis.Specification;

namespace AhliFans.Core.Feature.Admin.Moment.GetById.Specification;

public sealed class GetMomentById : Specification<Entities.Moment>, ISingleResultSpecification
{
  public GetMomentById(int momentId)
  {
    Query
      .Include(x => x.Player)
      .Include(x => x.Match)
      .ThenInclude(y => y.OpponentTeam)
      .Where(x => x.Id == momentId);
  }
}
