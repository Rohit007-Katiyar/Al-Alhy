using AhliFans.Core.Feature.Enums;
using Ardalis.Specification;

namespace AhliFans.Core.Feature.Fan.MatchCenter.Match.GetAll.Specification;

public sealed class GetAllMatchesByType : Specification<Entities.Match>
{
  public GetAllMatchesByType(int pageIndex, int pageSize, MatchTypes matchType)
  {

    Query
      .AsNoTracking()
      .Include(x => x.League)
      .ThenInclude(y => y.Dates)
      .Include(x => x.OpponentTeam)
      .Include(x => x.Referee)
      .Include(x => x.Stadium)
      .Skip(((pageIndex - 1) * pageSize)).Take(pageSize).OrderByDescending(x => x.Date);
    if (matchType != MatchTypes.All)
    {
      Query
      .Where(x => x.MatchType == matchType && x.IsDeleted == false);
    }

    Query
    .Where(x => !x.IsDeleted);
  }
}
