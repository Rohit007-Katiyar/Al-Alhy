using Ardalis.Specification;

namespace AhliFans.Core.Feature.Fan.Trophy.TrophyType.GetAll.Specifications;

public sealed class GetAllTrophyTypes :  Specification<Entities.TrophyType>
{
  public GetAllTrophyTypes(string? name)
  {
    if (!string.IsNullOrEmpty(name))
    {
      Query
        .Where(x => x.Name.Contains(name) || x.NameAr.Contains(name));
    }
  }
}
