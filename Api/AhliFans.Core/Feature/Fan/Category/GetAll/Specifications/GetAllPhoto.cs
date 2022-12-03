using Ardalis.Specification;

namespace AhliFans.Core.Feature.Fan.Category.GetAll.Specifications;
public class GetAllPhoto : Specification<Entities.MediaPhoto>
{
  public GetAllPhoto()
  {
    if (true)
    {
      Query
        .Include(x => x.Season)
        .Include(y => y.Match)
        .Include(z => z.League)
        .Include(z => z.Category)
        .Include(z => z.Player)
        .Include(z => z.Coach)
       .OrderByDescending(x=>x.Id);    
    }
  }
}
