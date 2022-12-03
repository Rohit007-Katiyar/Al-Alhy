using Ardalis.Specification;

namespace AhliFans.Core.Feature.Fan.Trophy.GetAll.Specifications;

public sealed class GetAllTrophies : Specification<Entities.Trophy>
{
  public GetAllTrophies(int pageIndex, int pageSize, string? name, int? trophyTypeId)
  {
    if (true)
    {
      Query
        .Include(x=>x.TrophyType)
        .Skip(((pageIndex - 1) * pageSize)).Take(pageSize).OrderByDescending(f => f.CreatedOn);
    }

    if (!string.IsNullOrEmpty(name))
    {
      Query
        .Where(x => x.Name.Contains(name) || x.NameAr.Contains(name));
    }

    if (trophyTypeId != 0 && trophyTypeId != null)
    {
      Query
        .Where(x => x.TrophyTypeId == trophyTypeId);
    }
  }
}
