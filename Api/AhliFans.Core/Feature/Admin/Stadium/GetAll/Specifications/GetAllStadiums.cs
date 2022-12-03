using Ardalis.Specification;

namespace AhliFans.Core.Feature.Admin.Stadium.GetAll.Specifications;

public sealed class GetAllStadiums : Specification<Entities.Stadium>
{
  public GetAllStadiums(int pageIndex,int pageSize,bool isDeleted)
  {
    Query
      .Where(x=>x.IsDeleted == isDeleted)
      .Skip(((pageIndex - 1) * pageSize)).Take(pageSize).OrderByDescending(x=>x.Id);
  }
}
