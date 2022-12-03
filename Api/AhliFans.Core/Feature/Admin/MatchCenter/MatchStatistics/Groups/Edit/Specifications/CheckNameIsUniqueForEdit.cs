using Ardalis.Specification;

namespace AhliFans.Core.Feature.Admin.MatchCenter.MatchStatistics.Groups;

public class CheckNameIsUniqueForEdit : Specification<Entities.MatchStatisticsType>
{
  public CheckNameIsUniqueForEdit(int id, string name, bool isArabic)
  {
    Query
    .AsNoTracking();

    if (isArabic)
    {
      Query
      .Where(t => t.NameAr == name && t.Id != id);
    }
    else
    {
      Query
      .Where(t => t.Name == name && t.Id != id);
    }
  }
}
