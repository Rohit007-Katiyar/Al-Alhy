using Ardalis.Specification;

namespace AhliFans.Core.Feature.Admin.MatchCenter.MatchStatistics.Groups.Coefficients;

public class GetStatisticGroupCoefficients : Specification<Entities.MatchStatisticsTypeCoefficient>
{
  public GetStatisticGroupCoefficients(int? statisticGroupId, int pageIndex, int pageSize, string? name)
  {
    Query
    .AsNoTracking()
    .Skip((pageIndex - 1) * pageSize)
    .Take(pageSize);
    if (statisticGroupId != null)
    {
      Query
      .Where(c => c.MatchStatisticsTypeId == statisticGroupId);
    }
    if (!string.IsNullOrEmpty(name))
    {
      Query
      .Where(c => c.NameAr.Contains(name) || c.Name.Contains(name));
    }
  }
}
