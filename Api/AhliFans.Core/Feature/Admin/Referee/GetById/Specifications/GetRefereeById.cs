using Ardalis.Specification;

namespace AhliFans.Core.Feature.Admin.Referee.GetById.Specifications;

public sealed class GetRefereeById : Specification<Entities.Referee>, ISingleResultSpecification
{
  public GetRefereeById(int refereeId)
  {
    Query
      .Include(r=>r.Region)
      .Include(r=>r.Nationality)
      .Where(x => x.Id == refereeId);
  }
}
