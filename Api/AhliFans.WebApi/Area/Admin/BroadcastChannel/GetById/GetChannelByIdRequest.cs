using AhliFans.Core.Feature.Security.Enums;

namespace AhliFans.WebApi.Area.Admin.BroadcastChannel.GetById;

public record GetChannelByIdRequest(int ChannelId)
{
  public const string Route = $"{nameof(Areas.Admin)}/BroadcastChannel";
}
