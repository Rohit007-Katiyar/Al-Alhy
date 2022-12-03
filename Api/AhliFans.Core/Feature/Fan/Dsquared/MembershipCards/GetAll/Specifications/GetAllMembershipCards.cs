using Ardalis.Specification;

namespace AhliFans.Core.Feature.Fan.Dsquared.MembershipCards;
public class GetAllMembershipCards : Specification<Entities.MembershipCard>
{
  public GetAllMembershipCards(int pageIndex, int pageSize, IList<int> subscribedCardsIds)
  {
    Query
      .AsNoTrackingWithIdentityResolution()
      .Skip((pageIndex - 1) * pageSize)
      .Take(pageSize)
      .Where(c => c.IsEnabled && !subscribedCardsIds.Contains(c.Id));
  }
}
