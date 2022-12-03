using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ardalis.Specification;

namespace AhliFans.Core.Feature.Admin.MediaPhoto.GetAll.Specification;
public sealed class GetAllPhotos : Specification<Entities.MediaPhoto>
{
  public GetAllPhotos(int pageIndex, int pageSize, string SearchWord, bool isDeleted)
  {
    if (!string.IsNullOrEmpty(SearchWord))
    {
      Query
        .Include(x => x.Season)
        .ThenInclude(y => y.Matches)
        .Include(z => z.League)
        .Include(z => z.Category)
        .Include(z => z.Player)
        .Include(z => z.Coach)
     .Where(x =>
     //x.Description.Contains(SearchWord) 
     x.Description.Contains(SearchWord)
     //|| x.DescriptionAr.Contains(SearchWord)
     //|| x.PhotoLink==null || x.PhotoLink.Contains(SearchWord)
     ).OrderByDescending(m => m.CreatedOn);
    }
    else
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
  }

}
