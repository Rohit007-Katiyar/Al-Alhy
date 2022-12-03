using System.ComponentModel.DataAnnotations;
using AhliFans.Core.Feature.Security.Enums;

namespace AhliFans.WebApi.Area.Client.VotePanel.Player.Vote;

public record VoteForPlayerRequest([Required] int PlayerId, [Required] int MatchId)
{
  public const string Route = $"{nameof(Areas.Client)}/Vote/Player";
}
