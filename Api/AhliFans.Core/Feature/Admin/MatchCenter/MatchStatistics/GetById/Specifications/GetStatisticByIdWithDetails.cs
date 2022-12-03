using Ardalis.Specification;

namespace AhliFans.Core.Feature.Admin.MatchCenter.MatchStatistics;

public class GetStatisticByIdWithDetails : Specification<Entities.MatchStatistic>, ISingleResultSpecification
{
    public GetStatisticByIdWithDetails(int id)
    {
        Query
        .AsNoTracking()
        .Include(s => s.StatisticsCoefficient)
        .Include(s => s.StatisticsType)
        .Where(s => s.Id == id);
        
    }
}