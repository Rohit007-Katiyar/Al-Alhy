using Ardalis.Specification;

namespace AhliFans.Core.Feature.Admin.SquadList.Add.Specifications;

public class CheckPlayersExistSpec : Specification<Entities.Player>
{
  public CheckPlayersExistSpec(IReadOnlyList<int> playersIds)
  {
    Query
    .AsNoTracking()
    .Where(p => playersIds.Contains(p.Id));
  }
}
