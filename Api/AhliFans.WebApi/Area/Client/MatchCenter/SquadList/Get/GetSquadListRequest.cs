using AhliFans.Core.Feature.Security.Enums;

namespace AhliFans.WebApi.Area.Client.MatchCenter;

public record GetSquadListRequest(int MatchId, string? Lang, int? GeneralPosition)
{
  public const string Route = $"{nameof(Areas.Client)}/SquadList";
}
