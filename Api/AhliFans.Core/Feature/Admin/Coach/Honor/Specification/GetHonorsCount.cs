using Ardalis.Specification;

namespace AhliFans.Core.Feature.Admin.Coach.Honor.Specification;

public sealed class GetHonorsCount : Specification<Entities.Honor>
{
  public GetHonorsCount(int trophyId)
  {
    Query
      .Where(x => x.TrophyId == trophyId);
  }
}
