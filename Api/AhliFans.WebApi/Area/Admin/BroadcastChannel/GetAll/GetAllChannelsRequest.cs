using AhliFans.Core.Feature.Localization;
using AhliFans.Core.Feature.Security.Enums;

namespace AhliFans.WebApi.Area.Admin.BroadcastChannel.GetAll;

public record GetAllChannelsRequest(string Lang = Languages.Ar, int PageIndex = 1, int PageSize = 10)
{
  public const string Route = $"{nameof(Areas.Admin)}/BroadcastChannels";
}
