using AhliFans.Core.Feature.Security.Enums;

namespace AhliFans.WebApi.Area.Admin.BroadcastChannel.Edit;

public record EditChannelRequest(int ChannelId,string Name, string NameAr)
{
  public const string Route = $"{nameof(Areas.Admin)}/BroadcastChannel";
}
