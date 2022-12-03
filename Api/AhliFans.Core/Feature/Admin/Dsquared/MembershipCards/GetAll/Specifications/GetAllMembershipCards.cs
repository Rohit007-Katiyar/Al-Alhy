using Ardalis.Specification;

namespace AhliFans.Core.Feature.Admin.Dsquared.MembershipCards;
public class GetAllMembershipCards : Specification<Entities.MembershipCard>
{
  public GetAllMembershipCards(int pageIndex, int pageSize, bool isEnabled)
  {
    Query
      .AsNoTrackingWithIdentityResolution()
      .Skip((pageIndex - 1) * pageSize)
      .Take(pageSize)
      .Where(c => c.IsEnabled == isEnabled);
  }
}
