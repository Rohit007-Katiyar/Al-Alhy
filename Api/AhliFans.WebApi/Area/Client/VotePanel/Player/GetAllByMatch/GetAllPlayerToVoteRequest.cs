using AhliFans.Core.Feature.Localization;
using AhliFans.Core.Feature.Security.Enums;

namespace AhliFans.WebApi.Area.Client.VotePanel.Player.GetAllByMatch;

public record GetAllPlayerToVoteRequest
{
  public const string Route = $"{nameof(Areas.Client)}/Vote/Players";
  public string Lang { get; set; } = Languages.Ar;
  public int MatchId { get; set; }

}
