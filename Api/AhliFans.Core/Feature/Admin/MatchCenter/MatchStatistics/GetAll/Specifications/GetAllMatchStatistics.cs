using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ardalis.Specification;

namespace AhliFans.Core.Feature.Admin.MatchCenter.MatchStatistics;

public class GetAllMatchStatistics : Specification<Entities.MatchStatistic>
{
    public GetAllMatchStatistics(int matchId, int pageIndex, int pageSize)
    {
        Query
        .AsNoTracking()
        .Include(s => s.StatisticsCoefficient)
        .Include(s => s.StatisticsType)
        .Where(s => s.MatchId == matchId)
        .Skip((pageIndex - 1) * pageSize)
        .Take(pageSize);
    }
}
