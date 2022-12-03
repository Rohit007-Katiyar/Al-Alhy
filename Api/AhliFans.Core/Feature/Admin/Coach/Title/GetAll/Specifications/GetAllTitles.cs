using Ardalis.Specification;

namespace AhliFans.Core.Feature.Admin.Coach.Title.GetAll.Specifications;
public sealed class GetAllTitles:Specification<Entities.Title>
{
  public GetAllTitles(int pageIndex, int pageSize, string searchWord, bool isDelete)
  {
    if (true)
    {
      Query
        .Where(x=>x.IsDeleted == isDelete)
        .Skip(((pageIndex - 1) * pageSize)).Take(pageSize).OrderByDescending(x=>x.Date);
    }

    if (!string.IsNullOrEmpty(searchWord))
    {
      Query
        .Where(x => x.Text.Contains(searchWord) || x.TextAr.Contains(searchWord));
    }
  }
}
