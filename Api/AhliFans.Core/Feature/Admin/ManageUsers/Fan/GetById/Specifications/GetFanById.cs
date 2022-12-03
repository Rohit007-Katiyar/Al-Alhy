using Ardalis.Specification;

namespace AhliFans.Core.Feature.Admin.ManageUsers.Fan.GetById.Specifications;

public sealed class GetFanById : Specification<Security.Entities.Fan>, ISingleResultSpecification
{
  public GetFanById(Guid fanId)
  {
    Query
      .Include(x=>x.City)
      .ThenInclude(y=>y.Country)
      .Where(x => x.Id == fanId);
  }
}
