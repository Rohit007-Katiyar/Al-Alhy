using Ardalis.Specification;

namespace AhliFans.Core.Feature.Admin.Coach.GetById.Specifications;

public sealed class GetCoachById : Specification<Entities.Coach>, ISingleResultSpecification
{
  public GetCoachById(int coachId)
  {
    Query
      .Include(x=>x.City)
      .ThenInclude(y=>y.Country)
      .Include(z=>z.Title)
      .Include(c => c.TeamCategory)
      .Where(x => x.Id == coachId);
  }
}
