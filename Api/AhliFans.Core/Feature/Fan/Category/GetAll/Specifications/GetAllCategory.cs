
using Ardalis.Specification;

namespace AhliFans.Core.Feature.Fan.Category.GetAll.Specifications;
public class GetAllCategory : Specification<Entities.Category>
{
  public GetAllCategory(int pageIndex, int pageSize, bool isDeleted)
  {
    Query.Where(x => x.IsDeleted == isDeleted).Skip(((pageIndex - 1) * pageSize)).Take(pageSize);
  }
}

