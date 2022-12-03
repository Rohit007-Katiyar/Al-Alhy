using AhliFans.Core.Feature.Security.Enums;

namespace AhliFans.WebApi.Area.Client.Notification.Setting.Edit;

public record EditSettingRequest(bool? EnableAll, bool? PlaySounds, bool? News, bool? MatchStatus, bool? NightMode,
  string? From, string? To)
{
  public const string Route = $"{nameof(Areas.Client)}/Notifications/Setting";
}
