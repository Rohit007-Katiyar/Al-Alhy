using AhliFans.Core.Feature.Security.Enums;

namespace AhliFans.WebApi.Area.Client.Notification.Manual.GetCount;

public record GetNotificationCountRequest
{
  public const string Route = $"{nameof(Areas.Client)}/Notification/Count";
}
