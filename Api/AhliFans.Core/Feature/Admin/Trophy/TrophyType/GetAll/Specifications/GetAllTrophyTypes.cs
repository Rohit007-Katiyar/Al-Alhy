using Ardalis.Specification;

namespace AhliFans.Core.Feature.Admin.Trophy.TrophyType.GetAll.Specifications;

public sealed class GetAllTrophyTypes :  Specification<Entities.TrophyType>
{
  public GetAllTrophyTypes(string name,bool isDeleted)
  {
    if (true)
    {
      Query
        .Where(x => x.IsDeleted == isDeleted);
    }
    if (!string.IsNullOrEmpty(name))
    {
      Query
        .Where(x => x.Name.Contains(name) || x.NameAr.Contains(name));
    }

  }
}
