using AhliFans.Core.Feature.Security.Enums;

namespace AhliFans.WebApi.Area.Client.Notification.Setting.Get;

public record GetNotificationSettingRequest
{
  public const string Route = $"{nameof(Areas.Client)}/Notifications/Setting";
}
