using AhliFans.Core.Feature.Entities;
using Ardalis.Specification;

namespace AhliFans.Core.Feature.Admin.Trophy.Edit.Specifications;

public sealed class GetAllTrophyYearsByTrophy : Specification<TrophyHistory>
{
  public GetAllTrophyYearsByTrophy(int trophyId)
  {
    Query
      .Where(x => x.TrophyId == trophyId);
  }
}
