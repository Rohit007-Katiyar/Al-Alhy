using AhliFans.Core.Feature.Security.Enums;

namespace AhliFans.WebApi.Area.Admin.BroadcastChannel.Add;

public record AddChannelRequest(string Name, string NameAr)
{
  public const string Route = $"{nameof(Areas.Admin)}/BroadcastChannel";
}
