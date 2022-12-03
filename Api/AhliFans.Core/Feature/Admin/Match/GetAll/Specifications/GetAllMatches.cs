using Ardalis.Specification;
using MatchTypes = AhliFans.Core.Feature.Enums.MatchTypes;

namespace AhliFans.Core.Feature.Admin.Match.GetAll.Specifications;

public sealed class GetAllMatches : Specification<Entities.Match>
{
    public GetAllMatches(int pageIndex, int pageSize, int leagueId, bool isDeleted, bool? isAvailable, MatchTypes matchType)
    {
        //bind match list for add photo page inside media section

        if (pageIndex == 0 && pageSize == 0)
        {
            Query
              .Include(x => x.League)
              .ThenInclude(y => y.Dates)
              .Include(x => x.OpponentTeam)
              .Include(x => x.Referee)
              .Include(x => x.Stadium)
              .Where(x => x.IsDeleted == isDeleted)
              .Where(x => x.MatchType == matchType)
              .Where(z => z.League.Id == leagueId).OrderByDescending(x => x.Date);

        }
        else if (isAvailable != null)
        {
            Query
              .Include(x => x.League)
              .ThenInclude(y => y.Dates)
              .Include(x => x.OpponentTeam)
              .Include(x => x.Referee)
              .Include(x => x.Stadium)
              .Where(x => x.IsDeleted == isDeleted)
              .Where(x => x.IsAvailable == isAvailable)
              .Where(x => x.MatchType == matchType)
              .Where(z => z.League.Id == leagueId)
              .Skip(((pageIndex - 1) * pageSize)).Take(pageSize).OrderByDescending(x => x.Date);
        }
        else
        {
            Query
              .Include(x => x.League)
              .ThenInclude(y => y.Dates)
              .Include(x => x.OpponentTeam)
              .Include(x => x.Referee)
              .Include(x => x.Stadium)
              .Where(x => x.IsDeleted == isDeleted)
              .Where(x => x.MatchType == matchType)
              .Where(z => z.League.Id == leagueId)
              .Skip(((pageIndex - 1) * pageSize)).Take(pageSize).OrderByDescending(x => x.Date);
        }
    }
}
