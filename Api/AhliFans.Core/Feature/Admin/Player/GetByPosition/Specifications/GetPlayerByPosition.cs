using Ardalis.Specification;

namespace AhliFans.Core.Feature.Admin.Player.GetByPosition.Specifications;

public sealed class GetPlayerByPosition : Specification<Entities.Player>
{
  public GetPlayerByPosition(int? teamId, int generalPosition, int? teamCategoryId)
  {
    if (teamId == null)
    {
      Query
        .Include(x => x.Position)
        .ThenInclude(y => y!.GeneralPosition)
        .Where(y => y.Position!.GeneralPositionId == generalPosition)
        .Where(x => x.TeamId == null);
    }
    else
    {
      Query
        .Include(x => x.Position)
        .ThenInclude(y => y!.GeneralPosition)
        .Where(y => y.Position!.GeneralPositionId == generalPosition)
        .Where(x => x.TeamId == teamId);
    }
    if (teamCategoryId != null)
    {
      Query.Where(x => x.TeamCategoryId == teamCategoryId);
    }
   
  }
}
