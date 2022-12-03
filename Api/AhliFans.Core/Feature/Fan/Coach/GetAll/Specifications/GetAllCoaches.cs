using Ardalis.Specification;

namespace AhliFans.Core.Feature.Fan.Coach.GetAll.Specifications;

public sealed class GetAllCoaches : Specification<Entities.Coach>
{
  public GetAllCoaches(bool isCurrent,int pageIndex, int pageSize, string searchWord,bool isDeleted)
  {
    if (true)
    {
      Query
        .Include(x=>x.City)
        .ThenInclude(y=>y.Country)
        .Include(z=>z.Title)
        .Where(x=>x.IsDeleted == isDeleted)
        .Where(x=>x.IsCurrent == isCurrent)
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
