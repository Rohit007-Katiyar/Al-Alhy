using Ardalis.Specification;

namespace AhliFans.Core.Feature.Admin.MatchCenter.MatchStatistics.Groups;

public class GetGroupByName : Specification<Entities.MatchStatisticsType>, ISingleResultSpecification
{
  public GetGroupByName(string name, bool isArabic)
  {
    Query.AsNoTracking();
    if (isArabic)
    {
      Query
      .Where(t => t.NameAr == name);
    }
    else
    {
      Query
      .Where(t => t.Name == name);
    }
  }
}
