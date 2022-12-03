using Ardalis.Specification;

namespace AhliFans.Core.Feature.Fan.SquadList.Get.Specifications;

public class GetSquadListByMatchIdAndGeneralPosition : Specification<Entities.SquadList>
{
  public GetSquadListByMatchIdAndGeneralPosition(int matchId, int? generalPositionId)
  {
    Query
    .AsNoTracking()
    .Include(sl => sl.Player)
    .ThenInclude(p => p.Position)
    .Include(sl => sl.Player)
    .ThenInclude(p => p.Position.GeneralPosition)
    .Where(sl => sl.MatchId == matchId);
    if (generalPositionId != default)
    {
      Query
      .Where(sl => sl.Player.Position.GeneralPositionId == generalPositionId);
    }
  }
}
