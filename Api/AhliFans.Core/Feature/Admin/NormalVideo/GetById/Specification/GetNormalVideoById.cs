using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ardalis.Specification;

namespace AhliFans.Core.Feature.Admin.NormalVideo.GetById.Specification;
public sealed class GetNormalVideoById : Specification<Entities.NormalVideo>, ISingleResultSpecification
{
  public GetNormalVideoById(int normalVideoId)
  {
    Query
        .Include(x => x.Season)
        .Include(x => x.Match)
        //.ThenInclude(y => y.Matches)
        .Include(z => z.League)
        .Include(z => z.Category)
        .Include(z => z.Player)
        .Include(z => z.Coach)
      .Where(x => x.Id == normalVideoId);
  }
}
