using Ardalis.Specification;

namespace AhliFans.Core.Feature.Admin.Team.TeamType.GetAll.Specifications;

public sealed class GetAllTeamTypes : Specification<Entities.TeamType>
{
  public GetAllTeamTypes(bool isDeleted)
  {
    Query
      .Where(x => x.IsDeleted == isDeleted);
  }
}
