using AhliFans.Core.Feature.Security.Enums;

namespace AhliFans.WebApi.Area.Client.Notification;

public record GetManualNotificationRequest
{
  public const string Route = $"{nameof(Areas.Client)}/Notifications";
  public int PageIndex { get; set; } = 1;
  public int PageSize { get; set; } = 10;
}
