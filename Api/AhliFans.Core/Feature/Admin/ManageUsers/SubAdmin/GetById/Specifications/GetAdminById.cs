using Ardalis.Specification;

namespace AhliFans.Core.Feature.Admin.ManageUsers.SubAdmin.GetById.Specifications;

public sealed class GetAdminById : Specification<Security.Entities.Admin>, ISingleResultSpecification
{
  public GetAdminById(Guid adminId)
  {
    Query
      .Include(x=>x.UserCreate)
      .Include(x=>x.UserModify)
      .Where(x => x.Id == adminId);

  }
}
