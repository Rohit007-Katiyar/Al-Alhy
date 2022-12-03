using Ardalis.Specification;
namespace AhliFans.Core.Feature.Fan.Coach.GetInfo.Specifications;

public sealed class GetCoachById : Specification<Entities.Coach>, ISingleResultSpecification
{
  public GetCoachById(int coachId)
  {
    Query
      .Include(x=>x.City)
      .ThenInclude(y=>y.Country)
      .Include(z=>z.Title)
      .Where(x => x.Id == coachId);
  }
}
