using AhliFans.Core.Feature.Security.Enums;

namespace AhliFans.WebApi.Area.Client.VotePanel.Moment.Vote;

public record VoteForMomentRequest(int MomentId)
{
  public const string Route = $"{nameof(Areas.Client)}/Vote/Moment";
}
