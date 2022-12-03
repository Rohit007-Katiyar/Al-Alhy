using Ardalis.Specification;

namespace AhliFans.Core.Feature.Admin.MatchCenter.MatchStatistics.Groups;

public class GetAllStatisticGroups : Specification<Entities.MatchStatisticsType>
{
  public GetAllStatisticGroups(int pageIndex, int pageSize, string? name)
  {
    Query
    .AsNoTracking()
    .Skip((pageIndex - 1) * pageSize)
    .Take(pageSize);
    if (!string.IsNullOrEmpty(name))
    {
      Query
      .Where(g => g.NameAr.Contains(name) || g.Name.Contains(name));
    }
  }
}
