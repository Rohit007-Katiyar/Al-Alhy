using AhliFans.Core.Feature.Entities;
using Ardalis.Specification;

namespace AhliFans.Core.Feature.Admin.Preferences.Get.Specifications;

public sealed class GetPreferenceByUser : Specification<FanPreference>, ISingleResultSpecification
{
  public GetPreferenceByUser(Guid userId)
  {
    Query
      .Include(x=>x.AfricanTrophy)
      .Include(x=>x.LocalTrophy)
      .Include(x=>x.Player)
      .Include(x=>x.Match)
      .Where(x => x.FanId == userId);
  }
}
