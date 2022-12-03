using Ardalis.Specification;

namespace AhliFans.Core.Feature.Admin.Season.GetAll.Specifications;
public sealed class GetAllSeason : Specification<Entities.Season>
{
  public GetAllSeason(int pageIndex, int pageSize, string? name, DateTime? startDate, DateTime? endDate,bool isDeleted)
  {

    if (pageIndex==0 && pageSize==0)
    {
      Query
        .Where(x => x.IsDeleted == isDeleted).
        OrderByDescending(x => x.EndDate);
    }
    else if (true)
    {
      Query
        .Where(x=>x.IsDeleted == isDeleted)
        .Skip(((pageIndex - 1) * pageSize)).Take(pageSize).OrderByDescending(x=>x.EndDate);
    }

    if (!string.IsNullOrEmpty(name))
    {
      Query
        .Where(x => x.Name.Contains(name) || x.NameAr.Contains(name));
    }

    if (startDate != null && endDate != null)
    {
      Query
        .Where(x => x.StartDate <= startDate && x.EndDate >= endDate);
    }

  }
}
