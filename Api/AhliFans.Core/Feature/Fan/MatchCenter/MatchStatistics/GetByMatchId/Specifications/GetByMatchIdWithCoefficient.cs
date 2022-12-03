using Ardalis.Specification;

namespace AhliFans.Core.Feature.Fan.MatchCenter.MatchStatistics;

public class GetByMatchIdWithCoefficient : Specification<Entities.MatchStatistic>
{
    public GetByMatchIdWithCoefficient(int matchId)
    {
        Query
        .AsNoTracking()
        .Include(stat => stat.StatisticsCoefficient)
        .Where(stat => stat.MatchId == matchId && stat.StatisticsType.IsEnabled);
    }
}