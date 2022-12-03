using Ardalis.Specification;

namespace AhliFans.Core.Feature.Admin.Season.Add.Specifications;

public sealed class IsSeasonExist : Specification<Entities.Season>
{
  public IsSeasonExist(string seasonName, string seasonNameAr, DateTime seasonDate)
  {
    Query
      .Where(s => s.Name == seasonName && s.NameAr == seasonNameAr && s.CreationDate == seasonDate);
  }
}
