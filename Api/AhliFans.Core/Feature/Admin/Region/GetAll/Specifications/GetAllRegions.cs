using Ardalis.Specification;

namespace AhliFans.Core.Feature.Admin.Region.GetAll.Specifications;

public sealed class GetAllRegions : Specification<Entities.Region>
{
  public GetAllRegions(int pageIndex,int pageSize, string name, bool isDeleted)
  {
    if (true)
    {
      Query
        .Where(x => x.Isdeleted == isDeleted)
        .Skip(((pageIndex - 1) * pageSize)).Take(pageSize).OrderByDescending(x => x.Date);
    }
    if (!string.IsNullOrEmpty(name))
    {
      Query
        .Where(x => x.Name.Contains(name) || x.NameAr.Contains(name));
    }
  }
}
