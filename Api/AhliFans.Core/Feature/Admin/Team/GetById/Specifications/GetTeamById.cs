using Ardalis.Specification;

namespace AhliFans.Core.Feature.Admin.Team.GetById.Specifications;

public sealed class GetTeamById : Specification<Entities.Team>, ISingleResultSpecification
{
  public GetTeamById(int teamId)
  {
    if (true)
    {
      Query
        .Include(x=>x.Region)
        .Include(x => x.Type)
        .Where(x => x.Id == teamId);
    }
  }
}
