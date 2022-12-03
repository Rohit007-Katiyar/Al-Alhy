using AhliFans.Core.Feature.Security.Enums;

namespace AhliFans.WebApi.Area.Admin.SquadList;

public record GetSquadListRequest(int MatchId, string? Lang)
{
  public const string Route = $"{nameof(Areas.Admin)}/squadlist";
};
