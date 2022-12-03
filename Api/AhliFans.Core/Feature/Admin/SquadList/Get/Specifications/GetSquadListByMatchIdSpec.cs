using Ardalis.Specification;

namespace AhliFans.Core.Feature.Admin.SquadList.Get.Specifications;

public class GetSquadListByMatchIdSpec : Specification<Entities.SquadList>
{
  public GetSquadListByMatchIdSpec(int matchId)
  {
    Query
    .AsNoTracking()
    .Include(sl => sl.Player)
    .Where(sl => sl.MatchId == matchId);
  }
}
