using Ardalis.Specification;

namespace AhliFans.Core.Feature.Admin.Coach.GetAll.Specifications;

public sealed class GetAllCoaches : Specification<Entities.Coach>
{
  public GetAllCoaches(int pageIndex, int pageSize, string searchWord,bool isDeleted)
  {
    if (pageIndex==0 && pageSize==0)
    {
      Query
        .Include(x => x.City)
        .ThenInclude(y => y.Country)
        .Include(z => z.Title)
        .Where(x => x.IsDeleted == isDeleted)
        .OrderByDescending(x => x.Date);
    }
   else if (true)
    {
      Query
        .Include(x=>x.City)
        .ThenInclude(y=>y.Country)
        .Include(z=>z.Title)
        .Where(x=>x.IsDeleted == isDeleted)
        .Skip(((pageIndex - 1) * pageSize)).Take(pageSize).OrderByDescending(x => x.Date);
    }

    if (!string.IsNullOrEmpty(searchWord))
    {
      Query
        .Where(x => x.FirstName.Contains(searchWord)   ||
                         x.FirstNameAr.Contains(searchWord) ||
                         x.LastName.Contains(searchWord)    ||
                         x.LastNameAr.Contains(searchWord));
    }
  }
}
