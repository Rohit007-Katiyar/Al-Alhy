using Ardalis.Specification;

namespace AhliFans.Core.Feature.Admin.League.Edit.Specifications;

public sealed class GetAllLeagueDates : Specification<Entities.LeagueDates>
{
  public GetAllLeagueDates(int leagueId)
  {
    Query
      .Where(x => x.LeagueId == leagueId && !x.IsDeleted);
  }
}
