using AhliFans.Core.Feature.Entities;
using Ardalis.Specification;

namespace AhliFans.Core.Feature.Fan.Preferences.Get.Specifications;

public sealed class GetPreferenceByUser : Specification<FanPreference>, ISingleResultSpecification
{
  public GetPreferenceByUser(Guid userId)
  {
    Query
      .Include(x=>x.AfricanTrophy)
      .Include(x=>x.LocalTrophy)
      .Include(x=>x.Player)
      .Include(x=>x.Match)
      .ThenInclude(x=>x!.OpponentTeam)
      .Where(x => x.FanId == userId);
  }
}
