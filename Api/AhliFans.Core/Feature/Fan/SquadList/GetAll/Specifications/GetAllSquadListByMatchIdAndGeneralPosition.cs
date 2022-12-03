using Ardalis.Specification;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AhliFans.Core.Feature.Fan.SquadList.GetAll.Specifications;
public class GetAllSquadListByMatchIdAndGeneralPosition : Specification<Entities.SquadList>
{
    public GetAllSquadListByMatchIdAndGeneralPosition()
    {
        Query
        .AsNoTracking()
        .Include(sl => sl.Player)
        .ThenInclude(p => p.Position)
        .Include(sl => sl.Player)
        .ThenInclude(p => p.Position.GeneralPosition);
        //.Where(sl => sl.MatchId == matchId);
        //if (generalPositionId != default)
        //{
        //    Query
        //    .Where(sl => sl.Player.Position.GeneralPositionId == generalPositionId);
        //}
    }
}
