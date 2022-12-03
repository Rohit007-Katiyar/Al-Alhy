using Ardalis.Specification;

namespace AhliFans.Core.Feature.Fan.Match.GetById.Specifications;

public sealed class GetMatchById : Specification<Entities.Match>, ISingleResultSpecification
{
  public GetMatchById(int id)
  {
    Query.AsNoTracking()
    .Include(m => m.League)
    .ThenInclude(league => league.Dates)
    .Include(m => m.BroadcastChannel)
    .Include(m => m.OpponentTeam)
    .Include(m => m.Referee)
    .Include(m => m.Stadium)
    .Where(m => m.Id == id);
  }
}
