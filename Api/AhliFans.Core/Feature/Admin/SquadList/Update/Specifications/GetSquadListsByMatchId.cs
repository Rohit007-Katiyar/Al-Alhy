using Ardalis.Specification;

namespace AhliFans.Core.Feature.Admin.SquadList.Update.Specifications;

public class GetSquadListsByMatchId : Specification<Entities.SquadList>
{
  public GetSquadListsByMatchId(int matchId)
  {
    Query
    .Where(sl => sl.MatchId == matchId);
  }
}
