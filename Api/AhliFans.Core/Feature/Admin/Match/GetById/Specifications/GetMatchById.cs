using Ardalis.Specification;

namespace AhliFans.Core.Feature.Admin.Match.GetById.Specifications;

public sealed class GetMatchById : Specification<Entities.Match>, ISingleResultSpecification
{
  public GetMatchById(int matchId)
  {
    Query
      .Include(x => x.League)
      .ThenInclude(y => y.Dates)
      .Include(x => x.OpponentTeam)
      .Include(x => x.Referee)
      .Include(x => x.Stadium)
      .Include(x=>x.BroadcastChannel)
      .Where(x => x.Id == matchId);
  }
}
