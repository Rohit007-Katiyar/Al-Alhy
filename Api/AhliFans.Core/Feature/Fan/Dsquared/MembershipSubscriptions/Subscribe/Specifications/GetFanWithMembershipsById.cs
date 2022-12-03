using Ardalis.Specification;

namespace AhliFans.Core.Feature.Fan.Dsquared.MembershipSubscriptions.Subscribe.Specifications;

public class GetFanWithMembershipsById : Specification<Security.Entities.Fan>, ISingleResultSpecification
{
  public GetFanWithMembershipsById(Guid fanId)
  {
    Query
      .Include(f => f.Memberships)
      .Where(f => f.Id == fanId);
  }
}
