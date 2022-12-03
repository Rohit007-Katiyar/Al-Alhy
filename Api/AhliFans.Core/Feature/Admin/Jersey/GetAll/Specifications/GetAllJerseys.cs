using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ardalis.Specification;

namespace AhliFans.Core.Feature.Admin.Jersey.GetAll.Specifications;
public class GetAllJerseys : Specification<Entities.Jersey>
{
  public GetAllJerseys(int pageIndex, int pageSize, bool IsEnabled, bool IsHome)
  {
    Query.AsNoTracking()
      .Include(j => j.CreatedBy)
      .Include(j => j.ModifiedBy)
      .Where(j => j.IsEnabled == IsEnabled && j.IsHome == IsHome)
      .Skip(((pageIndex - 1) * pageSize)).Take(pageSize);
  }
}
