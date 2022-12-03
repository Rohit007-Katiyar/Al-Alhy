using Ardalis.Specification;

namespace AhliFans.Core.Feature.Admin.MatchCenter.MatchStatistics.Groups.Coefficients;

public class GetCoefficientByName : Specification<Entities.MatchStatisticsTypeCoefficient>
{
  public GetCoefficientByName(string name, bool isArabic)
  {
    Query
    .AsNoTracking();

    if (isArabic)
    {
      Query
      .Where(c => c.NameAr == name);
    }
    else
    {
      Query
      .Where(c => c.Name == name);
    }
  }
}
