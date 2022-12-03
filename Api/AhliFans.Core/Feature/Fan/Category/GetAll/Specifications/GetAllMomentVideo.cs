using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ardalis.Specification;

namespace AhliFans.Core.Feature.Fan.Category.GetAll.Specifications;
public class GetAllMomentVideo : Specification<Entities.MomentVideo>
{
  public GetAllMomentVideo()
  {
    if (true)
    {
      Query
        .Include(x => x.Season)
        .ThenInclude(y => y.Matches)
        .Include(z => z.League)
        .Include(z => z.Category)
        .Include(z => z.Player)
        .OrderByDescending(x => x.Id);
    }
  }
}
