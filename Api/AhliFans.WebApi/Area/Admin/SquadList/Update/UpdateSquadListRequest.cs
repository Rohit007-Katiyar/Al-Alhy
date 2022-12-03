using AhliFans.Core.Feature.Security.Enums;

namespace AhliFans.WebApi.Area.Admin.SquadList;

public record UpdateSquadListRequest(IReadOnlyList<int> PlayersIds, int MatchId)
{
  public const string Route = $"{nameof(Areas.Admin)}/squadlist";
};
