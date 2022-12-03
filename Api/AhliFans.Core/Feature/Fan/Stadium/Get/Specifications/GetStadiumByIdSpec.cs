using Ardalis.Specification;

namespace AhliFans.Core.Feature.Fan.Stadium.Get.Specifications;

public class GetStadiumByIdSpec : Specification<Entities.Stadium>, ISingleResultSpecification
{
  public GetStadiumByIdSpec(int stadiumId)
  {
    Query
    .AsNoTracking()
    .Include(s => s.Region)
    .Where(s => s.Id == stadiumId);
  }
}
