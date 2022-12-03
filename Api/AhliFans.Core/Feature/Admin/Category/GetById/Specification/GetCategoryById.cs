using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ardalis.Specification;

namespace AhliFans.Core.Feature.Admin.Category.GetById.Specification;
public class GetCategoryById : Specification<Entities.Category>, ISingleResultSpecification
{
  public GetCategoryById(int categoryId)
  {
    Query.AsNoTracking()
      .Include(Category => Category.CreatedBy)
      .Include(Category => Category.ModifiedBy)
      .Where(Category => Category.Id == categoryId);
  }
}
