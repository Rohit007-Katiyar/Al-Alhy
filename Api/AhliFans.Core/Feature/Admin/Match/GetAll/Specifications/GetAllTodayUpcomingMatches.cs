using AhliFans.Core.Feature.Enums;
using Ardalis.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AhliFans.Core.Feature.Admin.Match.GetAll.Specifications;


public sealed class GetAllTodayUpcomingMatches : Specification<Entities.Match>
{
    public GetAllTodayUpcomingMatches()
    {
        //bind match list for add photo page inside media section
        Query
          .Include(x => x.League)
          .ThenInclude(y => y.Dates)
          .Include(x => x.OpponentTeam)
          .Include(x => x.Referee)
          .Include(x => x.Stadium)
          .Where(x => x.MatchType == MatchTypes.Upcoming || x.MatchType == MatchTypes.Current)
          .Where(x => x.IsDeleted == false)
          .OrderByDescending(x => x.Date);

    }
}