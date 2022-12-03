using Ardalis.Specification;

namespace AhliFans.Core.Feature.Admin.Trophy.GetById.Specifications;
public sealed class GetTrophyById : Specification<Entities.Trophy>, ISingleResultSpecification
{
  public GetTrophyById(int trophyId)
  {
    Query
      .Include(x=>x.UserModify)
      .Include(x=>x.UserCreate)
      .Include(x=>x.TrophyType)
      .Include(x=>x.TrophyHistories)
      .Where(x => x.Id == trophyId);
  }
}
