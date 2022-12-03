using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ardalis.Specification;

namespace AhliFans.Core.Feature.Admin.MediaPhoto.GetById.Specification;
public sealed class GetPhotoById : Specification<Entities.MediaPhoto>, ISingleResultSpecification
{
  public GetPhotoById(int photoId)
  {
    Query
        .Include(x => x.Season)
        .Include(y => y.Match)
        .Include(z => z.League)
        .Include(z => z.Category)
        .Include(z => z.Player)
        .Include(z => z.Coach)
      .Where(x => x.Id == photoId);
  }
}
