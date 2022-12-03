using Ardalis.Specification;

namespace AhliFans.Core.Feature.Fan.Referee.GetByMatch.Specifications;

public sealed class GetRefereeByMatch : Specification<Entities.Match>, ISingleResultSpecification
{
  public GetRefereeByMatch(int matchId)
  {
    Query
      .Include(x=>x.Referee)
      .ThenInclude(y=>y.Nationality)
      .Where(x => x.Id == matchId);
  }
}
