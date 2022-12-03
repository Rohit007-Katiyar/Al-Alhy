using Ardalis.Specification;

namespace AhliFans.Core.Feature.Admin.MatchCenter.MatchStatistics.Groups.Coefficients;

public class CheckNameExistsForEdit : Specification<Entities.MatchStatisticsTypeCoefficient>
{
  public CheckNameExistsForEdit(int coefficientId, string name, bool isArabic)
  {
    Query
    .AsNoTracking();

    if (isArabic)
    {
      Query
      .Where(c => c.Id != coefficientId && c.NameAr == name);
    }
    else
    {
      Query
      .Where(c => c.Id != coefficientId && c.Name == name);
    }
  }
}
