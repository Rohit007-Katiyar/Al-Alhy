using Ardalis.Specification;

namespace AhliFans.Core.Feature.Fan.MatchCenter.Coach.GetAll.Specification;

public sealed class GetAllCurrentCoaches : Specification<Entities.Coach>
{
  public GetAllCurrentCoaches()
  {
    Query
      .Include(x => x.Title)
      .Where(x => x.IsCurrent == true);
  }
}
