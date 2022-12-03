using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ardalis.Specification;

namespace AhliFans.Core.Feature.Fan.Dsquared.MembershipCards;
public class GetFanWithMembershipCards : Specification<Security.Entities.Fan>, ISingleResultSpecification
{
  public GetFanWithMembershipCards(Guid fanId)
  {
    Query
      .AsNoTracking()
      .Include(f => f.Memberships)
      .Where(f => f.Id == fanId);
  }
}
