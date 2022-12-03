using Ardalis.Specification;

namespace AhliFans.Core.Feature.Admin.SquadList.Update.Specifications;

public class CheckPlayersExist : Specification<Entities.Player>
{
  public CheckPlayersExist(IReadOnlyList<int> playersIds)
  {
    Query
    .AsNoTracking()
    .Where(p => playersIds.Contains(p.Id));
  }
}
