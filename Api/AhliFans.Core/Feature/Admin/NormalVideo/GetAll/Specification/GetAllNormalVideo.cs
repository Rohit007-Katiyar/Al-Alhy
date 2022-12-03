using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ardalis.Specification;

namespace AhliFans.Core.Feature.Admin.NormalVideo.GetAll.Specification;
public sealed class GetAllNormalVideo : Specification<Entities.NormalVideo>
{
  public GetAllNormalVideo(int pageIndex, int pageSize, string SearchWord, bool isDeleted)
  {
    if (true)
    {
      Query
        .Include(x => x.Season)
        .ThenInclude(y => y.Matches)
        .Include(z => z.League)
        .Include(z => z.Category)
        .Include(z => z.Player)
        .Include(z => z.Coach)
        .Where(x => x.IsDeleted == isDeleted).OrderByDescending(m => m.CreatedOn)
        .Skip(((pageIndex - 1) * pageSize)).Take(pageSize);
    }

    if (!string.IsNullOrEmpty(SearchWord))
    {
      Query
        .Include(x => x.Season)
        .ThenInclude(y => y.Matches)
        .Include(z => z.League)
        .Include(z => z.Category)
        .Include(z => z.Player)
        .Include(z => z.Coach)
     .Where(x => x.Description.Contains(SearchWord)
     || x.Description.Contains(SearchWord)
     || x.DescriptionAr.Contains(SearchWord)
     || x.VideoURL.Contains(SearchWord)
     ).OrderByDescending(m => m.CreatedOn);
    }
  }
}
