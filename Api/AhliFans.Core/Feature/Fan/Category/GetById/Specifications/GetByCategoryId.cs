
using Ardalis.Specification;


namespace AhliFans.Core.Feature.Fan.Category.GetById.Specifications;
public class GetByCategoryId : Specification<Entities.Category>
{
  public GetByCategoryId(int categoryId)
  {
    if (categoryId > 0)
    {
      Query
        .Where(x => x.Id == categoryId);
    }
  }
}

