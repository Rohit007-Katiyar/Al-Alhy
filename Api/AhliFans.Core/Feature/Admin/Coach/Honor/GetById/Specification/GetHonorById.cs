using Ardalis.Specification;

namespace AhliFans.Core.Feature.Admin.Coach.Honor.GetById.Specification;

public sealed class GetHonorById : Specification<Entities.Honor>, ISingleResultSpecification
{
  public GetHonorById(int honorId)
  {
    Query
      .Include(x=>x.Trophy)
      .Include(x=>x.Coach)
      .Where(x => x.Id == honorId);
  }
}
