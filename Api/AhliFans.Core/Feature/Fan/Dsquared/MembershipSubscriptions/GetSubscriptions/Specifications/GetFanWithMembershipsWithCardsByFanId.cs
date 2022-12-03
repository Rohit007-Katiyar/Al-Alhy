using Ardalis.Specification;

namespace AhliFans.Core.Feature.Fan.Dsquared.MembershipSubscriptions.GetSubscriptions.Specifications;

public class GetFanWithMembershipsWithCardsByFanId : Specification<Security.Entities.Fan>, ISingleResultSpecification
{
  public GetFanWithMembershipsWithCardsByFanId(Guid fanId)
  {
    Query
      .AsNoTracking()
      .Include(f => f.Memberships)
      .ThenInclude(m => m.Card)
      .Where(f => f.Id == fanId);
  }
}
