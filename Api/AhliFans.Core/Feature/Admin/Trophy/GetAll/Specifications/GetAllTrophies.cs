using Ardalis.Specification;

namespace AhliFans.Core.Feature.Admin.Trophy.GetAll.Specifications;

public sealed class GetAllTrophies : Specification<Entities.Trophy>
{
  public GetAllTrophies(int pageIndex, int pageSize, string? name, int? trophyTypeId, bool isDeleted, bool? isAvailable)
  {
    if (true)
    {
      Query
        .Include(x=>x.TrophyType)
        .Where(z=>z.IsDeleted == isDeleted)
        .Skip(((pageIndex - 1) * pageSize)).Take(pageSize).OrderByDescending(f => f.CreatedOn);
    }

    if (isAvailable != null)
    {
      Query
        .Where(z => z.IsAvailable == isAvailable);
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
