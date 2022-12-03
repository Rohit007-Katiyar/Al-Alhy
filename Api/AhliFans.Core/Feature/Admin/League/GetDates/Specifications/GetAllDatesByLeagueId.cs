using AhliFans.Core.Feature.Entities;
using Ardalis.Specification;

namespace AhliFans.Core.Feature.Admin.League.GetDates.Specifications;

public sealed class GetAllDatesByLeagueId : Specification<LeagueDates>
{
  public GetAllDatesByLeagueId(int leagueId)
  {
    Query
      .Where(x => x.LeagueId == leagueId && !x.IsDeleted);
  }
}
