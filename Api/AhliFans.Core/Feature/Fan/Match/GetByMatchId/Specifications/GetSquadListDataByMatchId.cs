using Ardalis.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AhliFans.Core.Feature.Fan.Match.GetByMatchId.Specifications;
public class GetSquadListDataByMatchId : Specification<Entities.SquadList>
{
    public GetSquadListDataByMatchId(int matchId)
    {
        Query
            .AsNoTracking()
            .Include(sl => sl.Player)
            .ThenInclude(p => p.Position)
            .Include(sl => sl.Player)
            .ThenInclude(p => p.Position.GeneralPosition)
    .Where(sl => sl.MatchId == matchId);
    }
}
