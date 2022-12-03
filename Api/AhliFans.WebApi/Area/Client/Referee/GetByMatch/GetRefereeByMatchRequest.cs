using AhliFans.Core.Feature.Localization;
using AhliFans.Core.Feature.Security.Enums;

namespace AhliFans.WebApi.Area.Client.Referee;

public record GetRefereeByMatchRequest(int MatchId)
{
  public const string Route = $"{nameof(Areas.Client)}/Match/Referee";
  public string Lang { get; set; } = Languages.Ar;
}
