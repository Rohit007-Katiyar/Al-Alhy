using AhliFans.Core.Feature.Security.Enums;

namespace AhliFans.WebApi.Area.Client.VotePanel.Player;

public record GetVoteRequest(string? Lang)
{
  public const string Route = $"{nameof(Areas.Client)}/Vote";
};
