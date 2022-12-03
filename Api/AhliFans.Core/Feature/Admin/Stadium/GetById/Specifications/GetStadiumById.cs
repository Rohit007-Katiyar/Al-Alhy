using Ardalis.Specification;

namespace AhliFans.Core.Feature.Admin.Stadium.GetById.Specifications;

public sealed class GetStadiumById : Specification<Entities.Stadium>, ISingleResultSpecification
{
  public GetStadiumById(int stadiumId)
  {
    Query
      .Include(x=>x.Region)
      .Where(x => x.Id == stadiumId);
  }
}
