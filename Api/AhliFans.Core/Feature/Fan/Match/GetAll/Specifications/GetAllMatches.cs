using AhliFans.Core.Feature.Enums;
using Ardalis.Specification;

namespace AhliFans.Core.Feature.Fan.Match.GetAll.Specifications;

public sealed class GetAllMatches : Specification<Entities.Match>
{
  public GetAllMatches(int pageIndex,int pageSize,int leagueId,MatchTypes matchType)
  {
    Query
      .Include(x=>x.League)
      .ThenInclude(y=>y.Dates)
      .Include(x=>x.OpponentTeam)
      .Include(x=>x.Referee)
      .Include(x=>x.Stadium)
      .Where(x=>x.MatchType == matchType)
      .Where(z=>z.League.Id == leagueId )
      .Skip(((pageIndex - 1) * pageSize)).Take(pageSize).OrderByDescending(x => x.Date);
  }
}
