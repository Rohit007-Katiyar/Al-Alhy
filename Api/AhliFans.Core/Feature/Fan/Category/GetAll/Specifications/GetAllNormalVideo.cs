using Ardalis.Specification;

namespace AhliFans.Core.Feature.Fan.Category.GetAll.Specifications;
public class GetAllNormalVideo : Specification<Entities.NormalVideo>
{
  public GetAllNormalVideo()
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
        .OrderByDescending(x => x.Id);
    }
  }
}
