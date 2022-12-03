using AhliFans.Core.Feature.Entities;
using Ardalis.Specification;

namespace AhliFans.Core.Feature.Admin.LineUp.Edit.Specifications;

public sealed class GetAllMatchPlayersByMatchId : Specification<MatchPlayer>
{
  public GetAllMatchPlayersByMatchId(int matchId)
  {
    Query
      .Where(x => x.MatchId == matchId);
  }
}
