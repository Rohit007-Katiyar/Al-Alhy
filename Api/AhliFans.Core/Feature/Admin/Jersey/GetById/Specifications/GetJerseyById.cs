using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ardalis.Specification;

namespace AhliFans.Core.Feature.Admin.Jersey.GetById.Specifications;
public class GetJerseyById : Specification<Entities.Jersey>, ISingleResultSpecification
{
  public GetJerseyById(int jerseyId)
  {
    Query.AsNoTracking()
      .Include(Jersey => Jersey.CreatedBy)
      .Include(Jersey => Jersey.ModifiedBy)
      .Where(Jersey => Jersey.Id == jerseyId);
  }
}
