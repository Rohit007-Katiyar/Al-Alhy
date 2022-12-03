using Ardalis.Specification;

namespace AhliFans.Core.Feature.Admin.SquadList.Add.Specifications;

public class CheckPlayersAlreadyExistsSpec : Specification<Entities.SquadList>
{
  public CheckPlayersAlreadyExistsSpec(IReadOnlyList<int> playersIds, int matchId)
  {
    Query
    .AsNoTracking()
    .Where(sl => playersIds.Contains(sl.PlayerId) && sl.MatchId == matchId);
  }
}
