using Ardalis.Specification;

namespace AhliFans.Core.Feature.Admin.Referee.GetAll.Specifications;

public sealed class GetAllReferees : Specification<Entities.Referee>
{
  public GetAllReferees(int pageIndex, int pageSize, string searchWord,bool isDeleted)
  {
    if (true)
    {
      Query
        .Include(x=>x.Nationality)
        .Where(x=>x.IsDeleted == isDeleted)
        .Skip(((pageIndex - 1) * pageSize)).Take(pageSize).OrderByDescending(x => x.Date);
    }

    if (!string.IsNullOrEmpty(searchWord))
    {
      Query
        .Where(x => x.Name.Contains(searchWord) || x.NameAr.Contains(searchWord));
    }
  }
}
