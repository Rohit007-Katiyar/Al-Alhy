using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ardalis.Specification;

namespace AhliFans.Core.Feature.Admin.MomentVideo.GetById.Specification;
public sealed class GetMomentVideoById : Specification<Entities.MomentVideo>, ISingleResultSpecification
{
  public GetMomentVideoById(int MomentVideoId)
  {
    Query
        .Include(x => x.Season)
        .ThenInclude(y => y.Matches)
        .Include(z => z.League)
        .Include(z => z.Category)
        .Include(z => z.Player)
      .Where(x => x.Id == MomentVideoId);
  }
}
